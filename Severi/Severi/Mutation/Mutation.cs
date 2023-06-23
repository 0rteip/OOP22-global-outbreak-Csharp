using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Severi.Mutation
{
    internal interface Mutation
    {

        int GetCost();
        float GetIncrease();
        string GetName();
        TypeMutation GetType();
        string GetDescription();
        void Increase();
        void Decrease();
    }
}
