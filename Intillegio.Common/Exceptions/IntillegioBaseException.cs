using System;

namespace Intillegio.Common.Exceptions
{
    public class IntillegioBaseException : Exception
    {
        protected IntillegioBaseException(string message) : base(message)
        {

        }
    }
}
