using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Severi.Mutation
{
    internal class MutationFactoryImpl : MutationFactory
    { 
        public Mutation CreateMutation(int cost, string name, float increase, TypeMutation type, string description)
        {
            return new MutationImpl(cost, name, increase, type, description);
        }
    }
}
