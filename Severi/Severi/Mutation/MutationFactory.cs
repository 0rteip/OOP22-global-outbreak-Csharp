using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Severi.Mutation
{
    internal interface MutationFactory
    {
        Mutation CreateMutation(int cost, string name, float increase, TypeMutation type, string description);
    }
}
