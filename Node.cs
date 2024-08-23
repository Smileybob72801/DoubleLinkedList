namespace DoubleLinkedList
{
    public class Node<T>(T data)
    {
        public T Data { get; } = data;
        public Node<T>? NextNode { get; set; }
        public Node<T>? PreviousNode { get; set; }
    }
}
