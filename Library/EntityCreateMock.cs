using System;
using System.Reflection;

namespace CreateRandomEntityValuesLibrary
{
    public static partial class Entity
	{
		private static int countParameterNumeric = 0;
		private static int countParameterChar = 0;
		private static int countParameterByte = 0;
		private static char[] parameterCharValue = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

		public static object CreateMock<T>() where T : new()
		{
			var objectToFill = new T();

			foreach (PropertyInfo propertyInfo in objectToFill.GetType().GetProperties())
            {
				if(propertyInfo.CanRead && !string.IsNullOrEmpty(propertyInfo.Name))
                {
					string value = typeValue(propertyInfo.PropertyType.Name, propertyInfo.Name);
					PropertyInfo propertyInfoSet = 
						objectToFill.GetType().GetProperty(propertyInfo.Name);

					if (value != null)
					{
						if (value == "guid")
                        {
							propertyInfoSet.SetValue(objectToFill, Convert.ChangeType(
							Guid.NewGuid(), propertyInfoSet.PropertyType), null);
						}
						else
                        {
							propertyInfoSet.SetValue(objectToFill, Convert.ChangeType(
							value, propertyInfoSet.PropertyType), null);
						}
					}
				}
			}

			return objectToFill;
		}

		private static string typeValue(string type, string name)
        {
			switch (type.ToLower())
			{
				case string i when i.Contains("int") || i.Contains("double") || 
				i.Contains("long") || i.Contains("float") || i.Contains("decimal") ||
				i.Contains("short"):
					countParameterNumeric++;
					return countParameterNumeric.ToString();
				case string i when i.Contains("char"):
					if(countParameterChar == 25) { countParameterChar = 0; }
					var charValue = parameterCharValue[countParameterChar];
					countParameterChar++;
					return charValue.ToString();
				case string i when i.Contains("bool"):
					return true.ToString();
				case string i when i.Contains("byte"):
					countParameterByte++;
					return countParameterByte.ToString(); ;
				case string i when i.Contains("string"):
					return name+"_test";
				case string i when i.Contains("guid"):
					return "guid";
				case string i when i.Contains("object"):
					return "object";
				default:
					return null;
			}
		}
	}
}
