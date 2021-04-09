using GraphQL.Types;

namespace PregnancyDemoApp.InputTypes
{
    public class PregnanciesInputType : InputObjectGraphType
    {
        public PregnanciesInputType()
        {
            Name = "AddPregnancyInput";

            Field<NonNullGraphType<IntGraphType>>("personId");
            Field<IntGraphType>("obstetricianId");
            Field<DateGraphType>("dueDate");
        }
    }
}
