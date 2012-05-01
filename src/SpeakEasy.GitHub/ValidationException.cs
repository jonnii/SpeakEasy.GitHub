using System;
using SpeakEasy.GitHub.Models;

namespace SpeakEasy.GitHub
{
    public class ValidationException : Exception
    {
        public ValidationException(Error error)
        {
            Error = error;
        }

        public Error Error { get; set; }
    }
}