using GraphQL;
using GraphQL.Types;
using PregnancyDemoApp.InputTypes;
using PregnancyDemoApp.Models;
using PregnancyDemoApp.Repositories;
using PregnancyDemoApp.Types;

namespace PregnancyDemoApp.Mutations
{
    public class PregnanciesMutation : ObjectGraphType<object>
    {
        public PregnanciesMutation(IPersonRepository personRepository, IChildbirthRepository birthRepository)
        {
            Name = "PersonalRelationsMutation";

            #region Person
            FieldAsync<PersonsType>(
                "createPerson",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PersonsInputType>> { Name = "person" }
                    ),
                resolve: async context =>
                {
                    var personInput = context.GetArgument<Person>("person");
                    return await personRepository.Add(personInput);

                }
            );

            FieldAsync<PersonsType>(
                "updatePerson",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PersonsInputType>> { Name = "person" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "personId" }
                    ),
                resolve: async context =>
                {
                    var personInput = context.GetArgument<Person>("person");
                    var personId = context.GetArgument<int>("personId");

                    var personInfoRetrived = await personRepository.GetById(personId);
                    if (personInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Person info."));
                        return null;
                    }
                    personInfoRetrived.NatIdNr = personInput.NatIdNr;
                    personInfoRetrived.FirstName = personInput.FirstName;
                    personInfoRetrived.LastName = personInput.LastName;
                    personInfoRetrived.Address = personInput.Address;
                    personInfoRetrived.Gender = personInput.Gender;

                    return await personRepository.Update(personInfoRetrived);
                }
            );

            FieldAsync<StringGraphType>(
                "deletePerson",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "personId" }),
                resolve: async context =>
                {
                    var personId = context.GetArgument<int>("personId");

                    var personInfoRetrived = await personRepository.GetById(personId);
                    if (personInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Person info."));
                        return null;
                    }
                    await personRepository.Delete(personId);
                    return $"Person ID {personId} with Name {personInfoRetrived.FullName} has been deleted succesfully.";
                }
            );
            #endregion


            //#region Personal Relations
            //FieldAsync<PersonalRelationsType>(
            //    "addPersonalRelation",
            //    arguments: new QueryArguments(new QueryArgument<NonNullGraphType<PersonalRelationsInputType>> { Name = "personalRelation" }),
            //    resolve: async context =>
            //    {
            //        var personalDisease = context.GetArgument<PersonalRelations>("personalRelation");
            //        return await birthRepository.Add(personalDisease);
            //    }
            //);

            //FieldAsync<PersonalRelationsType>(
            //    "updatePersonalRelation",
            //    arguments: new QueryArguments(
            //        new QueryArgument<NonNullGraphType<PersonalRelationsInputType>> { Name = "personalRelation" },
            //        new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "relationId" }
            //        ),
            //    resolve: async context =>
            //    {
            //        var relationInput = context.GetArgument<PersonalRelations>("personalRelation");
            //        var relationId = context.GetArgument<int>("relationId");

            //        var relationInfoRetrived = await birthRepository.GetById(relationId);
            //        if (relationInfoRetrived == null)
            //        {
            //            context.Errors.Add(new ExecutionError("Couldn't find Relation info."));
            //            return null;
            //        }
            //        relationInfoRetrived.PersonId = relationInput.PersonId;
            //        relationInfoRetrived.RelativeId = relationInput.RelativeId;
            //        relationInfoRetrived.RelationType = relationInput.RelationType;
            //        relationInfoRetrived.ReverseRelationType = relationInput.ReverseRelationType;

            //        return await birthRepository.Update(relationInfoRetrived);
            //    }
            //);

            //FieldAsync<StringGraphType>(
            //    "deletePersonalRelation",
            //    arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "personalRelationId" }),
            //    resolve: async context =>
            //    {
            //        var relationId = context.GetArgument<int>("personalRelationId");

            //        var relationInfoRetrived = await birthRepository.GetById(relationId);
            //        if (relationInfoRetrived == null)
            //        {
            //            context.Errors.Add(new ExecutionError("Couldn't find Personal Relation info."));
            //            return null;
            //        }
            //        await birthRepository.Delete(relationId);
            //        return $"Personal Relation ID {relationId} has been deleted succesfully.";
            //    }
            //);
            //#endregion
        }
    }
}
