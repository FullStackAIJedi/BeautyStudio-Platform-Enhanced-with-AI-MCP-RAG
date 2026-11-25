namespace Shop.Application.Common.Exceptions
{
    using FluentValidation.Results;

    public class ModelValidationException : Exception
    {
        public ModelValidationException()
            : base("One or more validation errors have occurred.")
            => this.Errors = new Dictionary<string, string[]>();

        public ModelValidationException(IEnumerable<ValidationFailure> errors)
            : this()
        {
            var failureGroups = errors
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage);

            foreach (var failureGroup in failureGroups)
            {
                this.Errors.Add(failureGroup.Key, failureGroup.ToArray());
            }
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
