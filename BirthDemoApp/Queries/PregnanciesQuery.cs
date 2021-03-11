using GraphQL;
using GraphQL.Types;
using PregnancyDemoApp.Repositories;
using PregnancyDemoApp.Types;

namespace PregnancyDemoApp.Queries
{
    public class PregnanciesQuery : ObjectGraphType
    {
        public PregnanciesQuery(IPersonRepository personRepository, IChildbirthRepository birthRepository)
        {
            Name = "PersonsRelationsQuery";

            Field<PersonsType>(
               "person",
               arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "Id" }),
               resolve: context => personRepository.GetById(context.GetArgument<int>("Id"))
               );

            Field<ListGraphType<PersonsType>>(
                "persons", "Returns list of persons",
                resolve: context => personRepository.GetAll()
                );

            //Field<PersonalRelationsType>(
            //    "relation",
            //    arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "Id" }),
            //    resolve: context => birthRepository.GetById(context.GetArgument<int>("Id"))
            //    );

            //Field<ListGraphType<PersonalRelationsType>>(
            //    "relations", "returns list of all persons relations",
            //    resolve: context => birthRepository.GetAll()
            //    );
        }
    }
}
