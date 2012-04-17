using System.Text.RegularExpressions;

namespace SpeakEasy.GitHub
{
    public class UnderscoreNamingConvention : INamingConvention
    {
        public string ConvertPropertyNameToParameterName(string propertyName)
        {
            return Regex.Replace(propertyName, "([a-z])([A-Z])", "$1_$2").ToLower();
        }
    }
}