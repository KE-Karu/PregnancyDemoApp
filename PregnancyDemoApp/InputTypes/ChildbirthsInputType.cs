using GraphQL.Types;

namespace PregnancyDemoApp.InputTypes
{
    public class ChildbirthsInputType : InputObjectGraphType
    {
        public ChildbirthsInputType()
        {
            Name = "AddBirthInput";
            Field<StringGraphType>("notes");
            Field<NonNullGraphType<IntGraphType>>("pregnancyId");
            Field<DateGraphType>("startDate");
            Field<DateGraphType>("endDate");
        }
    }
}