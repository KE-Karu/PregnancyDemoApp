using GraphQL.Types;

namespace PregnancyDemoApp.InputTypes
{
    public class ObstetriciansInputType : InputObjectGraphType
    {
        public ObstetriciansInputType()
        {
            Name = "AddObstetricianInput";
            Field<NonNullGraphType<IntGraphType>>("personId");
            Field<StringGraphType>("firstName");
            Field<StringGraphType>("lastName");
        }
    }
}
