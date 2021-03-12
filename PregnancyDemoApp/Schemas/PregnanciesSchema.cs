using GraphQL.Types;
using GraphQL.Utilities;
using PregnancyDemoApp.Mutations;
using PregnancyDemoApp.Queries;
using System;

namespace PregnancyDemoApp.Schemas
{
    public class PregnanciesSchema : Schema
    {
        public PregnanciesSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<PregnanciesQuery>();
            Mutation = provider.GetRequiredService<PregnanciesMutation>();
        }
    }
}
