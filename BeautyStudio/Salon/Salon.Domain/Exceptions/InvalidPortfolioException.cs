namespace Salon.Domain.Exceptions
{
    using SharedKernel.Exceptions;

    public class InvalidPortfolioException : BaseDomainException
    {
        public InvalidPortfolioException() { }
        public InvalidPortfolioException(string error) => this.Error = error;
    }
}
