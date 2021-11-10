using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public class DateException : ApplicationException
    {
        public DateException() { }

        public DateException(string message) : base(message) { }

        public DateException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class SubjectMissingException : ApplicationException
    {
        public SubjectMissingException() { } 
        
        public SubjectMissingException(string message) : base(message) { }

        public SubjectMissingException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class SubjectNotExistException : ApplicationException
    {
        public SubjectNotExistException() { }

        public SubjectNotExistException(string message) : base(message) { }

        public SubjectNotExistException(string message, Exception innerException) : base(message, innerException) { }
    }
}
