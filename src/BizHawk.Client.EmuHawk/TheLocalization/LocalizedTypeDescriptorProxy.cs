using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace BizHawk.Client.EmuHawk
{
	// Wrap a Object，customize TypeDescriptor to translate.
	public class TheLocalizedTypeDescriptorProxy : ICustomTypeDescriptor
	{
		private readonly object _target;
		public TheLocalizedTypeDescriptorProxy(object target)
		{
			_target = target;
		}

		public AttributeCollection GetAttributes()
			=> TypeDescriptor.GetAttributes(_target);

		public string GetClassName()
			=> TypeDescriptor.GetClassName(_target);

		public string GetComponentName()
			=> TypeDescriptor.GetComponentName(_target);

		public TypeConverter GetConverter()
			=> TypeDescriptor.GetConverter(_target);

		public EventDescriptor GetDefaultEvent()
			=> TypeDescriptor.GetDefaultEvent(_target);

		public PropertyDescriptor GetDefaultProperty()
			=> TypeDescriptor.GetDefaultProperty(_target);

		public object GetEditor(Type editorBaseType)
			=> TypeDescriptor.GetEditor(_target, editorBaseType);

		public EventDescriptorCollection GetEvents()
			=> GetEvents((Attribute[]) null);

		public EventDescriptorCollection GetEvents(Attribute[] attributes)
			=> TypeDescriptor.GetEvents(_target, attributes);

		public PropertyDescriptorCollection GetProperties()
			=> GetProperties(null);

		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			var originalProps = TypeDescriptor.GetProperties(_target, attributes);
			var wrapped = new List<PropertyDescriptor>();
			foreach (PropertyDescriptor pd in originalProps)
			{
				wrapped.Add(new TranslatedPropertyDescriptor(pd));
			}
			return new PropertyDescriptorCollection(wrapped.ToArray(), readOnly: true);
		}

		public object GetPropertyOwner(PropertyDescriptor pd)
		{
			return _target;
		}
	}

	// Wrap a enum, to translate enum value. 
	internal class LocalizedEnumConverter : EnumConverter
	{
		public LocalizedEnumConverter(Type type) : base(type)
		{
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string) && value != null)
			{
				var enumName = Enum.GetName(EnumType, value);
				if (enumName != null)
				{
					return TheLocalizater.TranslateText(enumName, context: EnumType.Name);
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string strVal)
			{
				foreach (var enumObj in Enum.GetValues(EnumType))
				{
					var rawKey = Enum.GetName(EnumType, enumObj)!;
					var display = TheLocalizater.TranslateText(rawKey, context: EnumType.Name);
					if (display == strVal)
					{
						return enumObj;
					}
				}
			}
			return base.ConvertFrom(context, culture, value);
		}

		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(Enum.GetValues(EnumType));
		}
	}

	// Wrap a PropertyDescriptor, to translate DisplayName, Category, Description ...
	internal class TranslatedPropertyDescriptor : PropertyDescriptor
	{
		private readonly PropertyDescriptor _inner;

		public TranslatedPropertyDescriptor(PropertyDescriptor inner)
			: base(inner.Name, inner.Attributes.Cast<Attribute>().ToArray())
		{
			_inner = inner;
		}

		public override string DisplayName
		{
			get
			{
				return TheLocalizater.TranslateText(_inner.Name);
			}
		}

		public override string Description
		{
			get
			{
				var descAttr = _inner.Attributes.OfType<DescriptionAttribute>().FirstOrDefault();
				if (descAttr == null) return string.Empty;
				return TheLocalizater.TranslateText(descAttr.Description);
			}
		}

		public override string Category
		{
			get
			{
				var catAttr = _inner.Attributes.OfType<CategoryAttribute>().FirstOrDefault();
				if (catAttr == null) return string.Empty;
				return TheLocalizater.TranslateText(catAttr.Category);
			}
		}

		public override bool IsReadOnly => _inner.IsReadOnly;
		public override Type PropertyType => _inner.PropertyType;
		public override Type ComponentType => _inner.ComponentType;

		//
		public override TypeConverter Converter
		{
			get
			{
				if (_inner.PropertyType.IsEnum)
				{
					return new LocalizedEnumConverter(_inner.PropertyType);
				}
				return _inner.Converter;
			}
		}

		private object Unwrap(object component)
		{
			if (component is TheLocalizedTypeDescriptorProxy proxy)
				return proxy.GetPropertyOwner(null);
			return component;
		}

		public override object GetValue(object component)
		{
			var realObj = Unwrap(component);
			return _inner.GetValue(realObj);
		}

		public override void SetValue(object component, object value)
		{
			var realObj = Unwrap(component);
			_inner.SetValue(realObj, value);
		}

		public override bool CanResetValue(object component)
		{
			var realObj = Unwrap(component);
			return _inner.CanResetValue(realObj);
		}

		public override void ResetValue(object component)
		{
			var realObj = Unwrap(component);
			_inner.ResetValue(realObj);
		}

		public override bool ShouldSerializeValue(object component)
		{
			var realObj = Unwrap(component);
			return _inner.ShouldSerializeValue(realObj);
		}
	}
}
