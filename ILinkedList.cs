namespace DoubleLinkedList
{
    public interface ILinkedList<T> : ICollection<T>
    {
        void AddItemToFront(T? item);
        void AddItemToEnd(T? item);
        void AddNode(Node<T?> newNode);
        void InsertAfterNode(Node<T?> newNode, Node<T?> originalNode);
        void InsertBeforeNode(Node<T?> newNode, Node<T?> originalNode);
        void ReverseNodes();
        void RemoveNode(Node<T?> node);
    }
}
