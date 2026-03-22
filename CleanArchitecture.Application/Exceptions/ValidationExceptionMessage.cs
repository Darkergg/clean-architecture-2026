using FluentValidation.Results;

namespace CleanArchitecture.Application.Exceptions
{
    public class ValidationExceptionMessage : ApplicationException
    {
        public ValidationExceptionMessage(): base("Se presentaron uno o mas errores de validacion")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationExceptionMessage(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }

    }
}