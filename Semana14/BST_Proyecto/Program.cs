class Program
{
    static void Main()
    {
        BST arbol = new BST();
        string? opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("=====  SISTEMA ÁRBOL BST =====");
            Console.WriteLine("1. Insertar valor");
            Console.WriteLine("2. Buscar valor");
            Console.WriteLine("3. Eliminar valor");
            Console.WriteLine("4. Mostrar recorridos");
            Console.WriteLine("5. Información del árbol");
            Console.WriteLine("6. Limpiar árbol");
            Console.WriteLine("0. Salir");

            Console.Write("\nSeleccione opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese valor: ");
                    string? valor = Console.ReadLine();

                    if (!string.IsNullOrEmpty(valor))
                    {
                        arbol.Insert(valor);
                        Console.WriteLine("Valor insertado.");
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;

                case "2":
                    Console.Write("Valor a buscar: ");
                    string? buscar = Console.ReadLine();

                    if (!string.IsNullOrEmpty(buscar) && arbol.Search(arbol.Root, buscar) != null)
                        Console.WriteLine("Valor encontrado.");
                    else
                        Console.WriteLine("No existe.");
                    break;

                case "3":
                    Console.Write("Valor a eliminar: ");
                    string? eliminar = Console.ReadLine();

                    if (!string.IsNullOrEmpty(eliminar))
                    {
                        arbol.Root = arbol.Delete(arbol.Root, eliminar);
                        Console.WriteLine("Operación realizada.");
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;

                case "4":
                    Console.Write("\nPreorden: ");
                    arbol.PreOrder(arbol.Root);

                    Console.Write("\nInorden: ");
                    arbol.InOrder(arbol.Root);

                    Console.Write("\nPostorden: ");
                    arbol.PostOrder(arbol.Root);

                    Console.WriteLine();
                    break;

                case "5":
                    Console.WriteLine($"Mínimo: {arbol.FindMin(arbol.Root)?.Value}");
                    Console.WriteLine($"Máximo: {arbol.FindMax(arbol.Root)?.Value}");
                    Console.WriteLine($"Altura: {arbol.Height(arbol.Root)}");
                    Console.WriteLine($"Total nodos: {arbol.Count(arbol.Root)}");
                    break;

                case "6":
                    arbol.Clear();
                    Console.WriteLine("Árbol limpiado.");
                    break;

                case "0":
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();

        } while (opcion != "0");
    }
}