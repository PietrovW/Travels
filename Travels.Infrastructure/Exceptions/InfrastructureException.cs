using Travels.Core.Exceptions;

namespace Travels.Infrastructure.Exceptions
{
    public class InfrastructureException : BaseException
    {

        public InfrastructureException(string message, params object[] args)
            :base(message: message,args: args)
        {

        }
    }
}
