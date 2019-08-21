﻿namespace Intillegio.Common.Exceptions
{
    public class InvalidUserException : IntillegioBaseException
    {
        private const string message = "User not found!";

        public InvalidUserException() : base(message)
        {
        }
    }
}
