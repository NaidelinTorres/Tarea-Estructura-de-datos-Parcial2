// <summary>
// Clase que representa un nodo dentro del Árbol Binario de Búsqueda (BST).
// Cada nodo contiene un valor y referencias a sus hijos izquierdo y derecho.
// </summary>
public class Node
{
    // Valor almacenado en el nodo
    public string Value;

    // Referencia al hijo izquierdo (puede ser null)
    public Node? Left;

    // Referencia al hijo derecho (puede ser null)
    public Node? Right;

    // <summary>
    // Constructor que inicializa el nodo con un valor específico
    // y sin hijos (nodos vacíos).
    // </summary>
    public Node(string value)
    {
        Value = value;   // Asigna el valor al nodo
        Left = null;     // Inicialmente no tiene hijo izquierdo
        Right = null;    // Inicialmente no tiene hijo derecho
    }
}