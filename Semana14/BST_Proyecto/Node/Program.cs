public class Node
{
    public string Value;
    public Node? Left;
    public Node? Right;

    public Node(string value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}