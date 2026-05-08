using System;

namespace Vidrotec.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}
