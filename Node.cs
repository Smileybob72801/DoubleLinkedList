namespace DoubleLinkedList
{
    public class Node<T>(T? data)
    {
        public T? Data { get; } = data;
        public Node<T?>? NextNode { get; set; }
        public Node<T?>? PreviousNode { get; set; }
        public ILinkedList<T?>? Container { get; set; }

        public override string ToString() =>
            $"{nameof(Data)}: {Data}{Environment.NewLine}" +
            $"{nameof(NextNode)}: {(NextNode is null ? "null" : NextNode.Data)}{Environment.NewLine}" +
            $"{nameof(PreviousNode)}: {(PreviousNode is null ? "null" : PreviousNode.Data)}{Environment.NewLine}";
    }
}
