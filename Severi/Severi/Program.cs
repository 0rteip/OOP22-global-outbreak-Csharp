using System;
using System.Collections.Generic;
using System.Linq;
using Severi;
using Severi.Mutation;

namespace SeveriApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("classe di prova");

            MutationFactory factory = new MutationFactoryImpl();
            MutationData mutationData = new MutationData(factory);
            MutationManager mutationManager = new MutationManagerImpl();
            MutationReader mutationReader = new MutationReaderImpl(mutationData);

            // leggo tutte le mutazioni dal file
            mutationReader.ReadMutation();

            Console.WriteLine("stampo tutti i nomi delle mutazioni con i relativi costi");
            List<Mutation> mutations = mutationData.GetMutations();
            mutations.ForEach(mutation => Console.WriteLine("nome " + mutation.GetName() + " costo " + mutation.GetCost()));

            // attivo i potenziamenti con drugresistance
            Console.WriteLine("attivo i poteniamenti che hanno il tipo drugresistance");
            List<Mutation> mutationsOfTypeDr = mutations.Where(mutation => mutation.GetType() == TypeMutation.DRUGRESISTANCE).ToList();
            mutationsOfTypeDr.ForEach(mutation => mutation.Increase());
            mutationsOfTypeDr.ForEach(mutation => mutationManager.AddToActivate(mutation.GetName()));

            // stampo i potenziamenti attivi
            Console.WriteLine("stampo i nomi dei potenziamenti attivi");
            HashSet<string> mutationsActive = mutationManager.GetActivatedMutations();
            foreach (string item in mutationsActive)
            {
                Console.WriteLine(item);
            }
        }
    }
}