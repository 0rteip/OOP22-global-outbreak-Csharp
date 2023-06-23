using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Severi.Mutation
{
    internal interface MutationManager
    {
        void AddToActivate(string mutationName);
        void RemoveToActivate(string mutationName);
        bool IsActivated(string mutationName);
        HashSet<string> GetActivatedMutations();
    }
}
