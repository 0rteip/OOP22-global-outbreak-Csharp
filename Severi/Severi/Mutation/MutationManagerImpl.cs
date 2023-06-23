using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Severi.Mutation
{
    internal class MutationManagerImpl : MutationManager
    {

        private readonly HashSet<string> activateMutation;

        public MutationManagerImpl()
        {
            activateMutation = new HashSet<string>();
        }

        public void AddToActivate(string mutationName)
        {
            activateMutation.Add(mutationName);
        }

        public void RemoveToActivate(string mutationName)
        {
            activateMutation.Remove(mutationName);
        }

        public bool IsActivated(string mutationName)
        {
            return activateMutation.Contains(mutationName);
        }

        public HashSet<string> GetActivatedMutations()
        {
            return new HashSet<string>(activateMutation);
        }
    }
}
