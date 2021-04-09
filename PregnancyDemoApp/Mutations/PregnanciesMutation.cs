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
        public PregnanciesMutation(IPersonRepository personRepository, IChildbirthRepository birthRepository,
            IObstetricianRepository obstetricianRepository, IPregnancyRepository pregnancyRepository)
        {
            Name = "PregnancyMutation";

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
                    //return $"Person has been created succesfully.";

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
                    personInfoRetrived.Sex = personInput.Sex;
                    personInfoRetrived.DateOfBirth = personInput.DateOfBirth;
                    //personInfoRetrived.DateOfDeath = personInput.DateOfDeath;
                    return await personRepository.Update(personInfoRetrived);
                    // return $"Person ID {personId} with Name {personInfoRetrived.FullName} has been updated succesfully.";
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


            #region Childbirth
            FieldAsync<ChildbirthsType>(
                "addChildbirth",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ChildbirthsInputType>> { Name = "childbirth" }),
                resolve: async context =>
                {
                    var birth = context.GetArgument<Childbirth>("childbirth");
                    return await birthRepository.Add(birth);
                    //return $"Childbirth has been created succesfully.";
                }
            );

            FieldAsync<ChildbirthsType>(
                "updateChildbirth",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ChildbirthsInputType>> { Name = "childbirth" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "birthId" }
                    ),
                resolve: async context =>
                {
                    var birthInput = context.GetArgument<Childbirth>("childbirth");
                    var birthId = context.GetArgument<int>("birthId");

                    var birthInfoRetrived = await birthRepository.GetById(birthId);
                    if (birthInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Birth info."));
                        return null;
                    }
                    birthInfoRetrived.Notes = birthInput.Notes;
                    birthInfoRetrived.PregnancyId = birthInput.PregnancyId;
                    //birthInfoRetrived.StartDate = birthInput.StartDate;
                    //birthInfoRetrived.EndDate = birthInput.EndDate;
                    return await birthRepository.Update(birthInfoRetrived);
                    //return $"Childbirth ID {birthId} has been updated succesfully.";
                }
            );

            FieldAsync<StringGraphType>(
                "deleteChildbirth",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "birthId" }),
                resolve: async context =>
                {
                    var birthId = context.GetArgument<int>("birthId");

                    var birthInfoRetrived = await birthRepository.GetById(birthId);
                    if (birthInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Birth info."));
                        return null;
                    }
                    await birthRepository.Delete(birthId);
                    return $"Childbirth ID {birthId} has been deleted succesfully.";
                }
            );
            #endregion


            #region Pregnancy
            FieldAsync<PregnanciesType>(
                "addPregnancy",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<PregnanciesInputType>> { Name = "pregnancy" }),
                resolve: async context =>
                {
                    var pregnancy = context.GetArgument<Pregnancy>("pregnancy");
                    return await pregnancyRepository.Add(pregnancy);
                    //return $"Pregnancy has been created succesfully.";
                }
            );

            FieldAsync<PregnanciesType>(
                "updatePregnancy",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PregnanciesInputType>> { Name = "pregnancy" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "pregnancyId" }
                    ),
                resolve: async context =>
                {
                    var pregnancyInput = context.GetArgument<Pregnancy>("pregnancy");
                    var pregnancyId = context.GetArgument<int>("pregnancyId");

                    var pregnancyInfoRetrived = await pregnancyRepository.GetById(pregnancyId);
                    if (pregnancyInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Pregnancy info."));
                        return null;
                    }
                    pregnancyInfoRetrived.PersonId = pregnancyInput.PersonId;
                    pregnancyInfoRetrived.ObstetricianId = pregnancyInput.ObstetricianId;
                    //pregnancyInfoRetrived.ChildbirthId = pregnancyInput.ChildbirthId;
                    pregnancyInfoRetrived.DueDate = pregnancyInput.DueDate;
                    return await pregnancyRepository.Update(pregnancyInfoRetrived);
                    //return $"Pregnancy ID {pregnancyId} has been updated succesfully.";
                }
            );

            FieldAsync<StringGraphType>(
                "deletePregnancy",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "PregnancyId" }),
                resolve: async context =>
                {
                    var pregnancyId = context.GetArgument<int>("PregnancyId");

                    var pregnancyInfoRetrived = await pregnancyRepository.GetById(pregnancyId);
                    if (pregnancyInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Pregnancy info."));
                        return null;
                    }
                    await pregnancyRepository.Delete(pregnancyId);
                    return $"Pregnancy ID {pregnancyId} has been deleted succesfully.";
                }
            );
            #endregion


            #region Obstetrician
            FieldAsync<ObstetriciansType>(
                "addObstetrician",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ObstetriciansInputType>> { Name = "obstetrician" }),
                resolve: async context =>
                {
                    var obstetricianDisease = context.GetArgument<Obstetrician>("obstetrician");
                    return await obstetricianRepository.Add(obstetricianDisease);
                    //return $"Obstetrician has been created succesfully.";
                }
            );

            FieldAsync<ObstetriciansType>(
                "updateObstetrician",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ObstetriciansInputType>> { Name = "obstetrician" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "obstetricianId" }
                    ),
                resolve: async context =>
                {
                    var obstetricianInput = context.GetArgument<Obstetrician>("obstetrician");
                    var obstetricianId = context.GetArgument<int>("obstetricianId");

                    var obstetricianInfoRetrived = await obstetricianRepository.GetById(obstetricianId);
                    if (obstetricianInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Obstetrician info."));
                        return null;
                    }
                    obstetricianInfoRetrived.PersonId = obstetricianInput.PersonId;
                    return await obstetricianRepository.Update(obstetricianInfoRetrived);
                    //return $"Obstetrician ID {obstetricianId} has been updated succesfully.";
                }
            );

            FieldAsync<StringGraphType>(
                "deleteObstetrician",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "obstetricianId" }),
                resolve: async context =>
                {
                    var obstetricianId = context.GetArgument<int>("obstetricianId");

                    var obstetricianInfoRetrived = await obstetricianRepository.GetById(obstetricianId);
                    if (obstetricianInfoRetrived == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find Obstetrician info."));
                        return null;
                    }
                    await obstetricianRepository.Delete(obstetricianId);
                    return $"Obstetrician ID {obstetricianId} has been deleted succesfully.";
                }
            );
            #endregion
        }
    }
}
