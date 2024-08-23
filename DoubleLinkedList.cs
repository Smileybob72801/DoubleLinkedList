using System.Collections;

namespace DoubleLinkedList
{
    public class DoubleLinkedList<T> : ILinkedList<T>
    {
        public Node<T>? Head { get; set; }
        public Node<T>? Tail { get; set; }

        public int Count { get; set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            AddToEnd(item);
        }

        public void AddToEnd(T item)
        {
            Node<T> newNode = new(item);

            Head ??= newNode;

            if (Tail is null)
            {
                Tail = newNode;
            }
            else
            {
                Tail.NextNode = newNode;
                newNode.PreviousNode = Tail;
                Tail = newNode;
            }

            Count++;
        }

        public void AddToFront(T item)
        {
            Node<T> newNode = new(item);

            Tail ??= newNode;

            if (Head is null)
            {
                Head = newNode;
            }
            else
            {
                Head.PreviousNode = newNode;
                newNode.NextNode = Head;
                Head = newNode;
            }

            Count++;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            Node<T>? currentNode = Head;

            while (currentNode is not null)
            {
                T data = currentNode.Data;

                if ( (data is null && item is null) ||
                    (data is not null && data.Equals(item)))
                {
                    return true;
                }

                currentNode = currentNode.NextNode;
            }

            return false;
        }

        public void CopyTo(T?[] array, int arrayIndex)
        {
            ArgumentNullException.ThrowIfNull(array);

            if (arrayIndex < 0 || arrayIndex >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("Insufficient space in target array.");

            Node<T>? currentNode = Head;

            while (currentNode is not null)
            {
                array[arrayIndex] = currentNode.Data;

                arrayIndex++;

                currentNode = currentNode.NextNode;
            }
        }

        public bool Remove(T item)
        {
            Node<T>? currentNode = Head;

            while (currentNode is not null)
            {
                T data = currentNode.Data;

                if ((data is null && item is null) ||
                    (data is not null && data.Equals(item)))
                {
                    if (currentNode.Equals(Head))
                        Head = currentNode.NextNode;

                    if (currentNode.Equals(Tail))
                        Tail = currentNode.PreviousNode;

                    if (currentNode.PreviousNode is not null)
                        currentNode.PreviousNode.NextNode = currentNode.NextNode;

                    if (currentNode.NextNode is not null)
                        currentNode.NextNode.PreviousNode = currentNode.PreviousNode;

                    if (Head is null)
                        Tail = null;

                    Count--;

                    return true;
                }

                currentNode = currentNode.NextNode;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? currentNode = Head;

            while (currentNode is not null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Node<T>? currentNode = Head;

            while (currentNode is not null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.NextNode;
            }
        }
    }
}
