public class BST
{
    // Nodo raíz del árbol
    public Node? Root;

    // Constructor
    public BST()
    {
        Root = null;
    }

    // ================= INSERTAR =================
    public void Insert(string value)
    {
        Root = InsertRec(Root, value);
    }

    private Node InsertRec(Node? root, string value)
    {
        if (root == null)
            return new Node(value);

        if (value == root.Value)
            return root;

        if (string.Compare(value, root.Value) < 0)
            root.Left = InsertRec(root.Left, value);
        else
            root.Right = InsertRec(root.Right, value);

        return root;
    }

    // ================= BUSCAR =================
    public Node? Search(Node? root, string value)
    {
        if (root == null || root.Value == value)
            return root;

        if (string.Compare(value, root.Value) < 0)
            return Search(root.Left, value);

        return Search(root.Right, value);
    }

    // ================= ELIMINAR =================
    public Node? Delete(Node? root, string value)
    {
        if (root == null) return null;

        if (string.Compare(value, root.Value) < 0)
            root.Left = Delete(root.Left, value);

        else if (string.Compare(value, root.Value) > 0)
            root.Right = Delete(root.Right, value);

        else
        {
            if (root.Left == null) return root.Right;
            if (root.Right == null) return root.Left;

            root.Value = MinValue(root.Right!);
            root.Right = Delete(root.Right, root.Value);
        }

        return root;
    }

    private string MinValue(Node root)
    {
        while (root.Left != null)
            root = root.Left;

        return root.Value;
    }

    // ================= RECORRIDOS =================
    public void PreOrder(Node? node)
    {
        if (node != null)
        {
            Console.Write(node.Value + " ");
            PreOrder(node.Left);
            PreOrder(node.Right);
        }
    }

    public void InOrder(Node? node)
    {
        if (node != null)
        {
            InOrder(node.Left);
            Console.Write(node.Value + " ");
            InOrder(node.Right);
        }
    }

    public void PostOrder(Node? node)
    {
        if (node != null)
        {
            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.Write(node.Value + " ");
        }
    }

    // ================= INFORMACIÓN =================
    public Node? FindMin(Node? root)
    {
        while (root?.Left != null)
            root = root.Left;
        return root;
    }

    public Node? FindMax(Node? root)
    {
        while (root?.Right != null)
            root = root.Right;
        return root;
    }

    public int Height(Node? root)
    {
        if (root == null) return -1;

        return Math.Max(Height(root.Left), Height(root.Right)) + 1;
    }

    public int Count(Node? root)
    {
        if (root == null) return 0;
        return 1 + Count(root.Left) + Count(root.Right);
    }

    public void Clear()
    {
        Root = null;
    }
}