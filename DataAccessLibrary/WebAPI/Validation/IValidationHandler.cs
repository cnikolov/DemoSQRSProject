using System.Threading.Tasks;

namespace WebAPI.Validation
{
    //Work around for DI to work.
    public interface IValidationHandler
    {
    }

    public interface IValidationHandler<T> : IValidationHandler
    {
        Task<ValidationResult> Validate(T request);
    }
}
