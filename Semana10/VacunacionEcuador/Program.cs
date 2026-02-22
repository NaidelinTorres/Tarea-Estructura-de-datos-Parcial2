using System;
using System.Collections.Generic;

namespace VacunacionEcuador
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear el conjunto de 500 ciudadanos
            HashSet<string> ciudadanos = new HashSet<string>();
            for (int i = 1; i <= 500; i++)
            {
                ciudadanos.Add("Ciudadano " + i);
            }

            // Crear el conjunto de 75 vacunados con Pfizer
            HashSet<string> pfizer = new HashSet<string>();
            for (int i = 1; i <= 75; i++)
            {
                pfizer.Add("Ciudadano " + i);
            }

            // Crear el conjunto de 75 vacunados con AstraZeneca
            // Se genera intersección del 51 al 75
            HashSet<string> astraZeneca = new HashSet<string>();
            for (int i = 51; i <= 125; i++)
            {
                astraZeneca.Add("Ciudadano " + i);
            }

            // Ciudadanos no vacunados
            HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
            noVacunados.ExceptWith(pfizer);
            noVacunados.ExceptWith(astraZeneca);

            // Ciudadanos con ambas dosis
            HashSet<string> ambasDosis = new HashSet<string>(pfizer);
            ambasDosis.IntersectWith(astraZeneca);

            // Ciudadanos solo Pfizer
            HashSet<string> soloPfizer = new HashSet<string>(pfizer);
            soloPfizer.ExceptWith(astraZeneca);

            // Ciudadanos solo AstraZeneca
            HashSet<string> soloAstraZeneca = new HashSet<string>(astraZeneca);
            soloAstraZeneca.ExceptWith(pfizer);

            // Mostrar resultados
            Console.WriteLine("=== Campaña de Vacunación COVID-19 - Ecuador ===\n");

            Console.WriteLine("Total ciudadanos: " + ciudadanos.Count);
            Console.WriteLine("No vacunados: " + noVacunados.Count);
            Console.WriteLine("Ambas dosis: " + ambasDosis.Count);
            Console.WriteLine("Solo Pfizer: " + soloPfizer.Count);
            Console.WriteLine("Solo AstraZeneca: " + soloAstraZeneca.Count);

            Console.ReadKey();
        }
    }
}