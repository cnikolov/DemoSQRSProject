using DataAccessLibrary.Models;
using MediatR;
using System.Collections.Generic;

namespace DataAccessLibrary.Queries
{
    //Shorthand For
    public record GetPersonListQuery() : IRequest<List<PersonModel>>;

    //Longhand
    public class GetPersonListQueryOld : IRequest<List<PersonModel>>
    {

    }

}
