using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Tools
{
    public static class PrintTools
    {
        // 1. Denne funktion tager imod en hel liste/samling
        public static void PrintCollection<T>(this IEnumerable<T> collection) where T : class
        {
            if (collection == null || !collection.Any())
            {
                Console.WriteLine("Samlingen er tom eller null.");
                return;
            }

            int count = 1;
            foreach (var item in collection)
            {
                Console.WriteLine($"\n[Element nr. {count++}]");
                //PrintProperties(item); // Kalder den individuelle printer
                item.PrintProperties(); // Kalder den individuelle printer
                Console.WriteLine(new string('-', 35));
            }
        }

        // 2. Denne funktion udskriver det enkelte objekt (forbedret version)
        public static void PrintProperties<T>(this T obj) where T : class
        {
            if (obj == null) return;

            // Vi bruger obj.GetType() for at se om det er en Student eller Employee
            Type type = obj.GetType();

            // Hent alle public properties
            PropertyInfo[] properties = type.GetProperties();

            Console.WriteLine($"Objekt Type    : {type.Name, -15}");
            foreach (var prop in properties)
            {
                // SIKKERHED: Spring indexere over (f.eks. Item[int]), 
                // da de kræver parametre og ellers kaster 'TargetParameterCountException'
                if (prop.GetIndexParameters().Length > 0) continue;

                try
                {
                    object value = prop.GetValue(obj) ?? "null";
                    Console.WriteLine($"{prop.Name,-15}: {value}");
                }
                catch (Exception ex)
                {
                    // Hvis en property ikke kan læses, skriver vi fejlen i stedet for at gå ned
                    Console.WriteLine($"{prop.Name,-15}: Fejl ({ex.Message})");
                }
            }
        }
    }
}

