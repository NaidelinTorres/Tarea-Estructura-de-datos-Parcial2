using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// Clase principal del programa
class TraductorNaidelin
{
    static void Main()
    {
        // Encabezado informativo del programa
        Console.WriteLine("=================================================");
        Console.WriteLine("        TRADUCTOR BÁSICO ESPAÑOL - INGLÉS");
        Console.WriteLine("        Desarrollo: Naidelin");
        Console.WriteLine("=================================================");

        // Diccionario que almacena palabras en español (clave)
        // y su traducción en inglés (valor)
        Dictionary<string, string> espIng = new Dictionary<string, string>()
        {
            {"tiempo", "time"},
            {"persona", "person"},
            {"año", "year"},
            {"camino", "way"},
            {"forma", "way"},
            {"día", "day"},
            {"cosa", "thing"},
            {"hombre", "man"},
            {"mundo", "world"},
            {"vida", "life"},
            {"mano", "hand"},
            {"parte", "part"},
            {"niño", "child"},
            {"niña", "child"},
            {"ojo", "eye"},
            {"mujer", "woman"},
            {"lugar", "place"},
            {"trabajo", "work"},
            {"semana", "week"},
            {"caso", "case"},
            {"punto", "point"},
            {"tema", "point"},
            {"gobierno", "government"},
            {"empresa", "company"},
            {"compañía", "company"}
        };

        // Diccionario que almacenará automáticamente
        // las traducciones de inglés a español
        Dictionary<string, string> ingEsp = new Dictionary<string, string>();

        // Generación automática del diccionario inverso
        // Se recorren los elementos del primer diccionario
        foreach (var item in espIng)
        {
            // Se evita agregar claves repetidas
            if (!ingEsp.ContainsKey(item.Value))
            {
                ingEsp.Add(item.Value, item.Key);
            }
        }

        int opcion;

        // Bucle principal del menú
        do
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            // Validación para evitar errores si el usuario ingresa texto
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:

                    // Submenú para elegir el tipo de traducción
                    Console.WriteLine("\nSeleccione el tipo de traducción:");
                    Console.WriteLine("1. Español → Inglés");
                    Console.WriteLine("2. Inglés → Español");
                    Console.Write("Opción: ");

                    // Validación de opción correcta
                    if (!int.TryParse(Console.ReadLine(), out int tipo) || (tipo != 1 && tipo != 2))
                    {
                        Console.WriteLine("Tipo de traducción inválido.");
                        break;
                    }

                    // Solicita la frase al usuario
                    Console.Write("\nIngrese la frase: ");
                    string frase = (Console.ReadLine() ?? "").ToLower();

                    // Eliminación de signos de puntuación
                    frase = Regex.Replace(frase, @"[^\w\s]", "");

                    // Separación de la frase en palabras individuales
                    string[] palabras = frase.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    int contador = 0;

                    Console.WriteLine("\nResultado de la traducción:");

                    // Recorrido de cada palabra
                    foreach (string palabra in palabras)
                    {
                        if (tipo == 1) // Español → Inglés
                        {
                            // Se busca la palabra en el diccionario
                            if (espIng.TryGetValue(palabra, out var traduccion))
                            {
                                Console.Write(traduccion + " ");
                                contador++;
                            }
                            else
                            {
                                // Si no existe, se imprime la palabra original
                                Console.Write(palabra + " ");
                            }
                        }
                        else // Inglés → Español
                        {
                            if (ingEsp.TryGetValue(palabra, out var traduccion))
                            {
                                Console.Write(traduccion + " ");
                                contador++;
                            }
                            else
                            {
                                Console.Write(palabra + " ");
                            }
                        }
                    }

                    // Muestra la cantidad de palabras traducidas correctamente
                    Console.WriteLine($"\nPalabras traducidas correctamente: {contador}");
                    break;

                case 2:

                    // Permite agregar nuevas palabras al diccionario
                    Console.Write("\nIngrese la palabra en español: ");
                    string esp = (Console.ReadLine() ?? "").ToLower();

                    Console.Write("Ingrese la palabra en inglés: ");
                    string ing = (Console.ReadLine() ?? "").ToLower();

                    // Validación para evitar valores vacíos
                    if (string.IsNullOrWhiteSpace(esp) || string.IsNullOrWhiteSpace(ing))
                    {
                        Console.WriteLine("No se permiten valores vacíos.");
                        break;
                    }

                    // Verifica si la palabra ya existe antes de agregarla
                    if (!espIng.ContainsKey(esp))
                    {
                        espIng.Add(esp, ing);

                        // También se agrega al diccionario inverso
                        if (!ingEsp.ContainsKey(ing))
                        {
                            ingEsp.Add(ing, esp);
                        }

                        Console.WriteLine("Palabras agregadas correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("La palabra ya existe en el diccionario.");
                    }

                    break;

                case 0:
                    // Finaliza la ejecución del programa
                    Console.WriteLine("Programa finalizado.");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 0);
    }
}