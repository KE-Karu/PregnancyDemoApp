using GraphQL.Types;

namespace PregnancyDemoApp.InputTypes
{
    public class PregnanciesInputType : InputObjectGraphType
    {
        public PregnanciesInputType()
        {
            Name = "AddPregnancyInput";
            Field<NonNullGraphType<IntGraphType>>("childbirthId");
            Field<NonNullGraphType<IntGraphType>>("motherId");
            Field<NonNullGraphType<IntGraphType>>("obstetricianId");
            Field<DateGraphType>("dueDate");
        }
    }
}
