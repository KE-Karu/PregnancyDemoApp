using GraphQL.Types;

namespace PregnancyDemoApp.InputTypes
{
    public class PersonsInputType : InputObjectGraphType
    {
        public PersonsInputType()
        {
            Name = "AddPersonInput";
            Field<StringGraphType>("natIdNr");
            Field<StringGraphType>("firstName");
            Field<StringGraphType>("lastName");
            Field<StringGraphType>("address");
            Field<StringGraphType>("gender");
            //Field<StringGraphType>("obstetrician");
        }
    }
}
