using System;
using System.Globalization;

namespace Travels.Application.Exceptions;

public abstract class BaseException : Exception
{
    private BaseException() : base() { }

    public BaseException(string message) : base(message) { }

    public BaseException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}
