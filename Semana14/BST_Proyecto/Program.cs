// <summary>
// Programa principal que permite interactuar con el Árbol Binario de Búsqueda (BST)
// mediante un menú en consola.
// </summary>
class Program
{
    static void Main()
    {
        // Se crea una instancia del árbol
        BST arbol = new BST();

        // Variable para almacenar la opción del usuario
        string? opcion;

        // Bucle principal del menú
        do
        {
            Console.Clear(); // Limpia la pantalla

            // Menú de opciones
            Console.WriteLine("===== 🌳 SISTEMA ÁRBOL BST =====");
            Console.WriteLine("1. Insertar valor");
            Console.WriteLine("2. Buscar valor");
            Console.WriteLine("3. Eliminar valor");
            Console.WriteLine("4. Mostrar recorridos");
            Console.WriteLine("5. Información del árbol");
            Console.WriteLine("6. Limpiar árbol");
            Console.WriteLine("0. Salir");

            Console.Write("\nSeleccione opción: ");
            opcion = Console.ReadLine(); // Captura la opción

            // Evaluación de la opción seleccionada
            switch (opcion)
            {
                case "1":
                    // INSERTAR VALOR EN EL ÁRBOL
                    Console.Write("Ingrese valor: ");
                    string? valor = Console.ReadLine();

                    // Validación: evita valores nulos o vacíos
                    if (!string.IsNullOrEmpty(valor))
                    {
                        arbol.Insert(valor); // Inserta el valor
                        Console.WriteLine("Valor insertado.");
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;

                case "2":
                    // BUSCAR UN VALOR EN EL ÁRBOL
                    Console.Write("Valor a buscar: ");
                    string? buscar = Console.ReadLine();

                    // Se verifica si existe en el árbol
                    if (!string.IsNullOrEmpty(buscar) && arbol.Search(arbol.Root, buscar) != null)
                        Console.WriteLine("Valor encontrado.");
                    else
                        Console.WriteLine("No existe.");
                    break;

                case "3":
                    // ELIMINAR UN NODO DEL ÁRBOL
                    Console.Write("Valor a eliminar: ");
                    string? eliminar = Console.ReadLine();

                    // Validación del dato
                    if (!string.IsNullOrEmpty(eliminar))
                    {
                        // Se actualiza la raíz después de eliminar
                        arbol.Root = arbol.Delete(arbol.Root, eliminar);
                        Console.WriteLine("Operación realizada.");
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;

                case "4":
                    // MOSTRAR RECORRIDOS DEL ÁRBOL

                    Console.Write("\nPreorden: ");
                    arbol.PreOrder(arbol.Root); // Raíz - Izquierda - Derecha

                    Console.Write("\nInorden: ");
                    arbol.InOrder(arbol.Root); // Izquierda - Raíz - Derecha (ordenado)

                    Console.Write("\nPostorden: ");
                    arbol.PostOrder(arbol.Root); // Izquierda - Derecha - Raíz

                    Console.WriteLine();
                    break;

                case "5":
                    // MOSTRAR INFORMACIÓN DEL ÁRBOL

                    // Nodo con valor mínimo
                    Console.WriteLine($"Mínimo: {arbol.FindMin(arbol.Root)?.Value}");

                    // Nodo con valor máximo
                    Console.WriteLine($"Máximo: {arbol.FindMax(arbol.Root)?.Value}");

                    // Altura del árbol
                    Console.WriteLine($"Altura: {arbol.Height(arbol.Root)}");

                    // Total de nodos
                    Console.WriteLine($"Total nodos: {arbol.Count(arbol.Root)}");
                    break;

                case "6":
                    // LIMPIAR EL ÁRBOL (elimina todos los nodos)
                    arbol.Clear();
                    Console.WriteLine("Árbol limpiado.");
                    break;

                case "0":
                    // SALIR DEL PROGRAMA
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    // OPCIÓN NO VÁLIDA
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            // Pausa para que el usuario vea el resultado
            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();

        } while (opcion != "0"); // Repite hasta que el usuario salga
    }
}