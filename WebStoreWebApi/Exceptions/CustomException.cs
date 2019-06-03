using Newtonsoft.Json;
using System;

namespace WebStoreWebApi.Exceptions
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }

        public string Description { get; set; }

        public CustomException(int statusCode, string message, string description) : base(message)
        {
            StatusCode = statusCode;
            Description = description;
        }
    }

    public class ExceptionDetails
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public string Discription { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
