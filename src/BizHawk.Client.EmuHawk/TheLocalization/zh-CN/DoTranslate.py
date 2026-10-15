#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
翻译工作台
    -- by deepseek

用途:
    从未翻译 JSON 文件读取未翻译的键，
    通过两种视图进行翻译编辑，将翻译完成的条目写入字典 JSON 文件，
    并从未翻译中删除已翻译的条目。

两种视图:
    1. 键值视图: 逐条浏览与编辑翻译。
    2. 文本视图: 直接编辑完整 JSON 文本，适合批量翻译。

保存行为:
    - 值非空的条目写入字典文件（覆盖式写入）。
    - 值非空的条目从未翻译文件中删除。
    - 值仍为空的条目原样保留在未翻译文件中。

运行:
    python DoTranslate.py
"""

import json
import os
import sys
import tkinter as tk
from collections import OrderedDict
from tkinter import ttk, filedialog, messagebox


# ============================================================
# 常量
# ============================================================

APP_TITLE = "翻译对照工作台"
WINDOW_SIZE = "1200x800"
WINDOW_MIN_SIZE = (900, 600)
SCALING = 1.2

FONT_KEY = ("Consolas", 11)
FONT_VALUE = ("Microsoft YaHei UI", 12)
FONT_JSON = ("Consolas", 11)
FONT_UI = ("Microsoft YaHei UI", 10)


# ============================================================
# 主程序
# ============================================================

class TranslationWorkbench:
    """翻译对照工具主窗口。"""

    def __init__(self, root: tk.Tk):
        self.root = root
        self.root.title(APP_TITLE)
        self.root.geometry(WINDOW_SIZE)
        self.root.minsize(*WINDOW_MIN_SIZE)

        # 状态数据
        self.data: "OrderedDict[str, str]" = OrderedDict()  # 内存中的键值对
        self.file_a: str = "UntranslatedTexts.json"         # 待翻译文件路径
        self.file_b: str = "TextTranslateDictionary.json"   # 翻译输出文件路径
        self.current_idx: int = None                        # 当前选中条目的索引
        self._last_json: str = ""                           # 上次渲染的 JSON 文本

        self._build_ui()
        self._bind_events()

    # ------------------------------------------------------------
    # UI 构建
    # ------------------------------------------------------------

    def _build_ui(self) -> None:
        self._build_notebook()
        self._build_statusbar()
        self._load()

    def _build_notebook(self) -> None:
        """两个视图页签。"""
        self.notebook = ttk.Notebook(self.root)
        self.notebook.pack(fill=tk.BOTH, expand=True, padx=6, pady=4)

        self.page_kv = ttk.Frame(self.notebook)
        self.notebook.add(self.page_kv, text="   表格视图   ")
        self._build_page_kv()

        self.page_json = ttk.Frame(self.notebook)
        self.notebook.add(self.page_json, text="   文本视图   ")
        self._build_page_json()

    def _build_page_kv(self) -> None:
        """页面1：表格视图。"""
        paned = ttk.PanedWindow(self.page_kv, orient=tk.HORIZONTAL)
        paned.pack(fill=tk.BOTH, expand=True, padx=4, pady=4)

        # -- 左侧：键列表 --
        left = ttk.Frame(paned)
        paned.add(left, weight=1)

        header = ttk.Frame(left)
        header.pack(fill=tk.X)
        ttk.Label(header, text="列表", font=FONT_UI).pack(side=tk.LEFT)
        self.counter_var = tk.StringVar(value="")
        ttk.Label(header, textvariable=self.counter_var, foreground="#666").pack(side=tk.RIGHT)

        list_frame = ttk.Frame(left)
        list_frame.pack(fill=tk.BOTH, expand=True, pady=(4, 0))

        self.tree = ttk.Treeview(
            list_frame, columns=("status",), show="tree headings", selectmode="browse")
        self.tree.heading("#0", text="原文")
        self.tree.heading("status", text="已翻译？")
        self.tree.column("#0", width=220, anchor=tk.W)
        self.tree.column("status", width=60, anchor=tk.CENTER)
        self.tree.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)

        sb = ttk.Scrollbar(list_frame, orient=tk.VERTICAL, command=self.tree.yview)
        sb.pack(side=tk.RIGHT, fill=tk.Y)
        self.tree.configure(yscrollcommand=sb.set)

        # -- 右侧：详情 --
        right = ttk.Frame(paned)
        paned.add(right, weight=2)

        ttk.Label(right, text="原文（只读）:", font=FONT_UI).pack(anchor=tk.W)
        self.key_text = tk.Text(
            right, height=5, wrap=tk.WORD, font=FONT_KEY,
            bg="#f5f5f5", state=tk.DISABLED)
        self.key_text.pack(fill=tk.X, pady=(2, 8))

        ttk.Label(right, text="译文（可编辑）:", font=FONT_UI).pack(anchor=tk.W)
        self.value_text = tk.Text(right, height=10, wrap=tk.WORD, font=FONT_VALUE)
        self.value_text.pack(fill=tk.BOTH, expand=True, pady=(2, 8))

        buttons = ttk.Frame(right)
        buttons.pack(fill=tk.X)
        ttk.Button(buttons, text="使用原文", command=self._use_original).pack(side=tk.LEFT, padx=2)
        ttk.Button(buttons, text="保存", command=self._save).pack(side=tk.RIGHT, padx=2)

    def _build_page_json(self) -> None:
        """页面2：文本视图。"""
        hint = ttk.Frame(self.page_json)
        hint.pack(fill=tk.X, padx=4, pady=(6, 2))
        ttk.Label(
            hint,
            text="在下方直接编辑 JSON 文本（原文不可修改，仅可更改译文）。编辑完成后点击“确定”。",
            foreground="#666", font=FONT_UI).pack(side=tk.LEFT)

        text_frame = ttk.Frame(self.page_json)
        text_frame.pack(fill=tk.BOTH, expand=True, padx=4, pady=2)

        self.json_text = tk.Text(text_frame, wrap=tk.NONE, font=FONT_JSON, undo=True)
        self.json_text.grid(row=0, column=0, sticky="nsew")

        ysb = ttk.Scrollbar(text_frame, orient=tk.VERTICAL, command=self.json_text.yview)
        ysb.grid(row=0, column=1, sticky="ns")
        xsb = ttk.Scrollbar(text_frame, orient=tk.HORIZONTAL, command=self.json_text.xview)
        xsb.grid(row=1, column=0, sticky="ew")
        self.json_text.configure(yscrollcommand=ysb.set, xscrollcommand=xsb.set)

        text_frame.grid_rowconfigure(0, weight=1)
        text_frame.grid_columnconfigure(0, weight=1)

        buttons = ttk.Frame(self.page_json)
        buttons.pack(fill=tk.X, padx=4, pady=(2, 6))
        ttk.Button(buttons, text="重新加载", command=self._refresh_json_view).pack(side=tk.LEFT, padx=2)
        ttk.Button(buttons, text="保存", command=self._save).pack(side=tk.RIGHT, padx=2)
        ttk.Button(buttons, text="确定", command=self._apply_json_text).pack(side=tk.RIGHT, padx=2)

    def _build_statusbar(self) -> None:
        self.status_var = tk.StringVar(value="状态：")
        status = ttk.Label(
            self.root, textvariable=self.status_var, relief=tk.SUNKEN,
            anchor=tk.W, padding=(8, 3), font=FONT_UI)
        status.pack(fill=tk.X, side=tk.BOTTOM)

    def _bind_events(self) -> None:
        self.tree.bind("<<TreeviewSelect>>", self._on_tree_select)
        self.value_text.bind("<KeyRelease>", lambda e: self._sync_value_to_memory())
        self.notebook.bind("<<NotebookTabChanged>>", self._on_tab_changed)

    # ------------------------------------------------------------
    # 加载
    # ------------------------------------------------------------

    def _load(self) -> None:
        path_a = self.file_a
        path_b = self.file_b

        try:
            with open(path_a, "r", encoding="utf-8-sig") as f:
                raw = json.load(f, object_pairs_hook=OrderedDict)
        except Exception as exc:
            messagebox.showerror(APP_TITLE, f"读取待翻译文件失败：\n{exc}")
            return

        if not isinstance(raw, dict):
            messagebox.showerror(APP_TITLE, "待翻译的文件不是一个 JSON 对象。")
            return

        # 规范化：值统一为字符串
        normalized: "OrderedDict[str, str]" = OrderedDict()
        for k, v in raw.items():
            if v is None:
                normalized[k] = ""
            elif isinstance(v, str):
                normalized[k] = v
            else:
                normalized[k] = str(v)

        self.data = normalized
        self.file_a = path_a
        self.file_b = path_b
        self.current_idx = None

        self._clear_detail_panel()
        self._refresh_tree()
        self._refresh_json_view()

        total = len(self.data)
        empty = sum(1 for v in self.data.values() if not v)
        self.status_var.set(
            f"已加载： 共 {total} 条，其中 {empty} 条待翻译。")

    # ------------------------------------------------------------
    # 列表刷新
    # ------------------------------------------------------------

    def _refresh_tree(self) -> None:
        self.tree.delete(*self.tree.get_children())
        for i, (key, value) in enumerate(self.data.items()):
            mark = "✔" if value else ""
            self.tree.insert("", tk.END, iid=str(i), text=self._shorten(key), values=(mark,))

        total = len(self.data)
        done = sum(1 for v in self.data.values() if v)
        self.counter_var.set(f"已完成 {done}/{total}")

        if self.current_idx is not None and self.current_idx < total:
            iid = str(self.current_idx)
            if self.tree.exists(iid):
                self.tree.selection_set(iid)
                self.tree.see(iid)

    @staticmethod
    def _shorten(text: str, limit: int = 60) -> str:
        s = text.replace("\n", " ").replace("\r", " ")
        return s if len(s) <= limit else s[:limit - 3] + "..."

    def _on_tree_select(self, event) -> None:
        self._sync_value_to_memory()

        sel = self.tree.selection()
        if not sel:
            self.current_idx = None
            return

        idx = int(sel[0])
        if idx >= len(self.data):
            return

        self.current_idx = idx
        keys = list(self.data.keys())
        key = keys[idx]
        value = self.data[key]

        self.key_text.configure(state=tk.NORMAL)
        self.key_text.delete("1.0", tk.END)
        self.key_text.insert("1.0", key)
        self.key_text.configure(state=tk.DISABLED)

        self.value_text.delete("1.0", tk.END)
        self.value_text.insert("1.0", value)
        self.value_text.focus_set()

    def _sync_value_to_memory(self) -> None:
        if self.current_idx is None or self.current_idx >= len(self.data):
            return

        keys = list(self.data.keys())
        key = keys[self.current_idx]

        new_value = self.value_text.get("1.0", tk.END)
        if new_value.endswith("\n"):
            new_value = new_value[:-1]

        if self.data[key] == new_value:
            return

        self.data[key] = new_value

        iid = str(self.current_idx)
        if self.tree.exists(iid):
            self.tree.set(iid, "status", "✔" if new_value else "")

        total = len(self.data)
        done = sum(1 for v in self.data.values() if v)
        self.counter_var.set(f"已完成 {done}/{total}")

    def _clear_detail_panel(self) -> None:
        self.key_text.configure(state=tk.NORMAL)
        self.key_text.delete("1.0", tk.END)
        self.key_text.configure(state=tk.DISABLED)
        self.value_text.delete("1.0", tk.END)

    # ------------------------------------------------------------
    # 使用原文
    # ------------------------------------------------------------

    def _use_original(self) -> None:
        if self.current_idx is None:
            messagebox.showinfo(APP_TITLE, "请先在左侧列表中选择一个条目。")
            return

        keys = list(self.data.keys())
        if self.current_idx >= len(keys):
            return

        key = keys[self.current_idx]
        self.value_text.delete("1.0", tk.END)
        self.value_text.insert("1.0", key)
        self._sync_value_to_memory()

    # ------------------------------------------------------------
    # 文本视图
    # ------------------------------------------------------------

    def _refresh_json_view(self) -> None:
        text = json.dumps(self.data, ensure_ascii=False, indent=4)
        self.json_text.delete("1.0", tk.END)
        self.json_text.insert("1.0", text)
        self._last_json = text

    def _apply_json_text(self) -> None:
        raw = self.json_text.get("1.0", tk.END)
        try:
            parsed = json.loads(raw, object_pairs_hook=OrderedDict)
        except json.JSONDecodeError as exc:
            messagebox.showerror(APP_TITLE, f"JSON 解析失败：\n{exc}")
            return

        if not isinstance(parsed, dict):
            messagebox.showerror(APP_TITLE, "JSON 根必须是一个对象。")
            return

        original_keys = set(self.data.keys())
        parsed_keys = set(parsed.keys())
        extra_keys = parsed_keys - original_keys
        missing_keys = original_keys - parsed_keys

        # 删除不存在的键
        for k in list(parsed.keys()):
            if k in extra_keys:
                del parsed[k]

        # 按原顺序重组，缺的填空
        result: "OrderedDict[str, str]" = OrderedDict()
        for k in self.data:
            v = parsed.get(k, "")
            if v is None:
                result[k] = ""
            elif isinstance(v, str):
                result[k] = v
            else:
                result[k] = str(v)

        # 生成提示
        lines = [f"总共读取到 {len(parsed_keys)} 个条目。"]
        if extra_keys:
            lines.append("")
            lines.append(f"检测到 {len(extra_keys)} 个原文件中不存在的键，已删除：")
            for k in list(extra_keys)[:10]:
                lines.append(f"    {self._shorten(k, 50)}")
            if len(extra_keys) > 10:
                lines.append(f"    ... 共 {len(extra_keys)} 个")
        if missing_keys:
            lines.append("")
            lines.append(f"有 {len(missing_keys)} 个原有键未出现在文本中，已保留为空值：")
            for k in list(missing_keys)[:10]:
                lines.append(f"    {self._shorten(k, 50)}")
            if len(missing_keys) > 10:
                lines.append(f"    ... 共 {len(missing_keys)} 个")

        messagebox.showinfo(APP_TITLE, "\n".join(lines))

        self.data = result
        self.current_idx = None
        self._clear_detail_panel()
        self._refresh_tree()
        self._refresh_json_view()

    # ------------------------------------------------------------
    # 页签切换
    # ------------------------------------------------------------

    def _on_tab_changed(self, event) -> None:
        idx = self.notebook.index(self.notebook.select())
        if idx == 0:
            # 切到键值视图：从内存数据重建列表
            self._refresh_tree()
        else:
            # 切到文本视图：先同步未提交的编辑
            self._sync_value_to_memory()
            # 如果用户未编辑过当前文本，则重新渲染
            current = self.json_text.get("1.0", tk.END)
            if current.rstrip("\n") == self._last_json:
                self._refresh_json_view()

    # ------------------------------------------------------------
    # 保存
    # ------------------------------------------------------------

    def _save(self) -> None:
        self._sync_value_to_memory()

        # 分离已翻译和未翻译
        translated: "OrderedDict[str, str]" = OrderedDict()
        remaining: "OrderedDict[str, str]" = OrderedDict()
        for k, v in self.data.items():
            if v and v.strip():
                translated[k] = v
            else:
                remaining[k] = v

        if not translated:
            messagebox.showinfo(APP_TITLE, "当前没有已翻译的条目。")
            return

        # 读取并合并已有到字典文件
        existing_b: "OrderedDict[str, str]" = OrderedDict()
        if os.path.isfile(self.file_b):
            try:
                with open(self.file_b, "r", encoding="utf-8-sig") as f:
                    loaded = json.load(f, object_pairs_hook=OrderedDict)
                if isinstance(loaded, dict):
                    existing_b = loaded
            except Exception:
                existing_b = OrderedDict()

        existing_b.update(translated)

        # 写入字典
        try:
            with open(self.file_b, "w", encoding="utf-8") as f:
                json.dump(existing_b, f, ensure_ascii=False, indent=4)
        except Exception as exc:
            messagebox.showerror(APP_TITLE, f"写入翻译输出文件失败：\n{exc}")
            return

        # 写入未翻译（删除已翻译条目）
        try:
            with open(self.file_a, "w", encoding="utf-8") as f:
                json.dump(remaining, f, ensure_ascii=False, indent=4)
        except Exception as exc:
            messagebox.showerror(APP_TITLE, f"写入待翻译文件失败：\n{exc}")
            return

        # 更新内存与界面
        self.data = remaining
        self.current_idx = None
        self._clear_detail_panel()
        self._refresh_tree()
        self._refresh_json_view()

        messagebox.showinfo(
            APP_TITLE,
            f"本次总共编辑了 {len(translated)} 个条目，"
            f"将写入 {os.path.basename(self.file_b)}。\n"
            f"还剩 {len(remaining)} 个条目为空。")

        self.status_var.set(
            f"保存完成：写入 {len(translated)} 条到 {os.path.basename(self.file_b)}，"
            f"待翻译文件剩余 {len(remaining)} 条。")


# ============================================================
# 入口
# ============================================================

def main() -> int:
    root = tk.Tk()
    try:
        root.tk.call("tk", "scaling", SCALING)
    except Exception:
        pass
    TranslationWorkbench(root)
    root.mainloop()
    return 0


if __name__ == "__main__":
    sys.exit(main())