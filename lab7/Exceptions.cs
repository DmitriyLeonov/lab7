using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public class DateException : ArgumentOutOfRangeException
    {
        public DateException() { }

        public DateException(string message) : base(message) { }

        public DateException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class SubjectMissingException : Exception
    {
        public SubjectMissingException() { } 
        
        public SubjectMissingException(string message) : base(message) { }

        public SubjectMissingException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class SubjectNotExistException : ArgumentException
    {
        public SubjectNotExistException() { }

        public SubjectNotExistException(string message) : base(message) { }

        public SubjectNotExistException(string message, Exception innerException) : base(message, innerException) { }
    }
}
