using System;

namespace JWS.Bittrex.Api.Exceptions
{
    public class JsonConversionException : Exception
    {
        public string Json { get; }
        public Type TargetType { get; }

        public JsonConversionException(string message, Exception innerException, string json, Type targetType) : base(message, innerException)
        {
            Json = json;
            TargetType = targetType;
        }
    }
}
