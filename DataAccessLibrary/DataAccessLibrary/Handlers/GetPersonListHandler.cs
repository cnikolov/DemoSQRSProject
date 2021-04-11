using DataAccessLibrary.Models;
using DataAccessLibrary.Queries;
using DataAccessLibrary.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLibrary.Handlers
{
    public class GetPersonListHandler : IRequestHandler<GetPersonListQuery, List<HeroModel>>
    {
        private readonly IDataAccessLayer _repository;

        //MediatR doesnt replace DI, its just an improvment.
        public GetPersonListHandler(IDataAccessLayer repository)
        {
            _repository = repository;
        }
        public Task<List<HeroModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
           var heroes = _repository.GetHeroes();
           return Task.FromResult(heroes);
        }
    }
}
