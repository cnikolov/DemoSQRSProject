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
    public class GetPersonListHandler : IRequestHandler<GetPersonListQuery, List<PersonModel>>
    {
        private readonly IRepository _repository;

        //MediatR doesnt replace DI, its just an improvment.
        public GetPersonListHandler(IRepository repository)
        {
            _repository = repository;
        }
        public Task<List<PersonModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
           var people = _repository.GetPeople();
           return Task.FromResult(people);
        }
    }
}
