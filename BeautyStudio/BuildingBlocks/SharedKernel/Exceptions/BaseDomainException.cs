namespace SharedKernel.Exceptions
{
    using System;
    public abstract class BaseDomainException : Exception
    {
        private string? error;

        public string Error
        {
            get => this.error ?? base.Message;
            set => this.error = value;
        }

        protected BaseDomainException() { }

        protected BaseDomainException(string message) : base(message) { }

        protected BaseDomainException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
