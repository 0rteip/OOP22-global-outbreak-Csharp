using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Severi.Mutation
{
    internal class MutationImpl : Mutation
    {
        private readonly string _name;
        private readonly int _cost;
        private readonly float _increase;
        private readonly TypeMutation _type;
        private readonly string _description;



        public MutationImpl(int cost, string name, float increase, TypeMutation type, string description)
        {
            this._cost = cost;
            this._name = name;
            this._increase = increase;
            this._type = type;
            this._description = description;
        }

        public int GetCost()
        {
            return _cost;
        }

        public float GetIncrease()
        {
            return this._increase;
        }

        public string GetName()
        {
            return this._name;
        }

        public TypeMutation GetType()
        {
            return this._type;
        }

        public string GetDescription()
        {
            return this._description;
        }

        public void Increase()
        {
            SelectType(_increase);
        }

        public void Decrease()
        {
            float decrease = -_increase;
            SelectType(decrease);
        }

        private void SelectType(float increment)
        {
            switch (this._type)
            {
                case TypeMutation.TRASMISSION:
                    Console.WriteLine("disease.UpdateInfectivity" + increment);
                    break;
                case TypeMutation.AIR:
                    Console.WriteLine(" disease.UpdateAirInfectivity" + increment);
                    break;
                case TypeMutation.LAND:
                    Console.WriteLine(" disease.UpdateLandInfectivity" + increment);
                    break;
                case TypeMutation.SEA:
                    Console.WriteLine(" disease.UpdateSeaInfectivity" + increment);
                    break;
                case TypeMutation.SYMPTOMS:
                    Console.WriteLine("disease.UpdateLethality" + increment);
                    break;
                case TypeMutation.HEATRESISTANCE:
                    Console.WriteLine("disease.UpdateHeatInfectivity" + increment);
                    break;
                case TypeMutation.COLDRESISTANCE:
                    Console.WriteLine("disease.UpdateColdInfectivity" + increment);
                    break;
                case TypeMutation.DRUGRESISTANCE:
                    Console.WriteLine("disease.UpdateCureResistance" + increment);
                    break;
                default:
                    Console.WriteLine("Type {0} not found.", _type);
                    break;
            }
        }

    }
}
