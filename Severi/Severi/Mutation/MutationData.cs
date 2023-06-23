using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Severi.Mutation
{
    internal class MutationData
    {
        private readonly List<Mutation> mutations;
        private readonly MutationFactory mutationFactory;

        public MutationData(MutationFactory mutationFactory)
        {
            this.mutationFactory = mutationFactory;
            mutations = new List<Mutation>();
        }

        public List<Mutation> GetMutations()
        {
            return new List<Mutation>(mutations);
        }

        public void LoadMutationFromJson(int cost, string name, float increase, TypeMutation type, string description)
        {
            Mutation mutation = mutationFactory.CreateMutation(cost, name, increase, type, description);
            mutations.Add(mutation);
        }
    }
}
