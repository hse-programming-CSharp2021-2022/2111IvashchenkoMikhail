using System;

namespace Seminar_12._11
{
    public class NotADragonException : Exception
    {
        public NotADragonException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}