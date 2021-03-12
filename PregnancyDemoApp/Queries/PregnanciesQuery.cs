using GraphQL;
using GraphQL.Types;
using PregnancyDemoApp.Repositories;
using PregnancyDemoApp.Types;

namespace PregnancyDemoApp.Queries
{
    public class PregnanciesQuery : ObjectGraphType
    {
        public PregnanciesQuery(IPersonRepository personRepository, IChildbirthRepository birthRepository,
            IPregnancyRepository pregnancyRepository, IObstetricianRepository obstetricianRepository)
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


            Field<ChildbirthsType>(
                "childbirth",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "Id" }),
                resolve: context => birthRepository.GetById(context.GetArgument<int>("Id"))
                );

            Field<ListGraphType<ChildbirthsType>>(
                "childbirths", "returns list of all childbirths",
                resolve: context => birthRepository.GetAll()
                );


            Field<PregnanciesType>(
                "pregnancy",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "Id" }),
                resolve: context => pregnancyRepository.GetById(context.GetArgument<int>("Id"))
                );

            Field<ListGraphType<PregnanciesType>>(
                "pregnancies", "returns list of all persons pregnancies",
                resolve: context => pregnancyRepository.GetAll()
                );


            Field<ObstetriciansType>(
                "obstetrician",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "Id" }),
                resolve: context => obstetricianRepository.GetById(context.GetArgument<int>("Id"))
                );

            Field<ListGraphType<ObstetriciansType>>(
                "obstetricians", "returns list of all obstetricians",
                resolve: context => obstetricianRepository.GetAll()
                );
        }
    }
}