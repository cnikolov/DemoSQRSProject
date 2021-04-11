using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLibrary.Repositories;
using MediatR;
using WebAPI.Response;
using WebAPI.Validation;

namespace WebAPI.Command
{
    public static class AddHero
    {
        public record Command(string FirstName, string LastName) : IRequest<Response>;

        public class AddHeroValidator : IValidationHandler<Command>
        {
            private readonly IHeroRepository _repository;

            public AddHeroValidator(IHeroRepository repository) => _repository = repository;
            public async Task<ValidationResult> Validate(Command request)
            {
                var heroes = await _repository.GetHeroes();
                if (heroes.Any(x => x.FirstName.Equals(request.FirstName, StringComparison.OrdinalIgnoreCase) ||
                                    x.LastName.Equals(request.LastName, StringComparison.OrdinalIgnoreCase)))
                {
                    return new ValidationResult{ Error = "Hero with that name already exists", IsSuccessful = false};
                }
                return ValidationResult.Success;
            }
        }

        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly IHeroRepository _repository;

            public Handler(IHeroRepository repository)
            {
                _repository = repository;
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var insertedHero = await _repository.InsertHero(request.FirstName, request.LastName);
                return new Response {Id = insertedHero.Id};
            }
        }

        public record Response : BaseResponse
        {
            public int Id { get; set; }
        };
    }
}
