using System.Threading;
using System.Threading.Tasks;
using DataAccessLibrary.Repositories;
using MediatR;

namespace WebAPI.Queries
{
    public static class GetHeroById
    {
        public record Query(int id) : IRequest<HeroViewModel>;

        public record HeroViewModel(string FirstName, string LastName);

        public class Handler : IRequestHandler<Query,HeroViewModel>
        {
            private readonly IHeroRepository _heroRepository;

            public Handler(IHeroRepository heroRepository)
            {
                _heroRepository = heroRepository;
            }
            public async Task<HeroViewModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var hero = await _heroRepository.GetHeroById(request.id);
                return hero != null ? new HeroViewModel(hero.FirstName, hero.LastName) : null;
            }
        }
    }
}