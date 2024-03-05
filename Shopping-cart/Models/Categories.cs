using System.ComponentModel;

namespace Shopping_cart.Models
{
	public enum ProductCategories
	{
		[Description("Men's Apparel")]
		mens_apparel = 1,

		[Description("Mobile's and Gadgets")]
		Mobiles_and_gadgets,

		[Description("Home Entertainment")]
		Home_entertainment,

		[Description("Health & Personal Care")]
		Health_and_personal_care
	}

	public static class ExtendBuiltInClasses
	{
		public static string GetDescription(this ProductCategories value)
		{
            var field = value.GetType().GetField(value.ToString()); // Reflection
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)); // Get the custom attribute and cast it to description attribute
            return attribute.Description;
        }
	}
}
