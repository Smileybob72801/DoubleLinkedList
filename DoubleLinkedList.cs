using System.Collections;

namespace DoubleLinkedList
{
    public class DoubleLinkedList<T> : ILinkedList<T?>
    {
        private Node<T?>? _head;
        private Node<T?>? _tail;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T? item)
        {
            AddToEnd(item);
        }

        public void AddToEnd(T? item)
        {
            Node<T?> newNode = new(item);

            _head ??= newNode;

            if (_tail is not null)
            {
                _tail.NextNode = newNode;
                newNode.PreviousNode = _tail;
            }

            _tail = newNode;

            Count++;
        }

        public void AddToFront(T? item)
        {
            Node<T?> newNode = new(item);

            _tail ??= newNode;

            if (_head is not null)
            {
                _head.PreviousNode = newNode;
                newNode.NextNode = _head;
            }

            _head = newNode;

            Count++;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public bool Contains(T? item)
        {
            Node<T?>? currentNode = _head;

            while (currentNode is not null)
            {
                T? data = currentNode.Data;

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

            Node<T?>? currentNode = _head;

            while (currentNode is not null)
            {
                array[arrayIndex] = currentNode.Data;

                arrayIndex++;

                currentNode = currentNode.NextNode;
            }
        }

        public bool Remove(T? item)
        {
            Node<T?>? currentNode = _head;

            while (currentNode is not null)
            {
                T? data = currentNode.Data;

                if ((data is null && item is null) ||
                    (data is not null && data.Equals(item)))
                {
                    if (currentNode.Equals(_head))
                        _head = currentNode.NextNode;

                    if (currentNode.Equals(_tail))
                        _tail = currentNode.PreviousNode;

                    if (currentNode.PreviousNode is not null)
                        currentNode.PreviousNode.NextNode = currentNode.NextNode;

                    if (currentNode.NextNode is not null)
                        currentNode.NextNode.PreviousNode = currentNode.PreviousNode;

                    if (_head is null)
                        _tail = null;

                    Count--;

                    return true;
                }

                currentNode = currentNode.NextNode;
            }

            return false;
        }

        public IEnumerator<T?> GetEnumerator()
        {
            Node<T?>? currentNode = _head;

            while (currentNode is not null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Node<T?>? currentNode = _head;

            while (currentNode is not null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.NextNode;
            }
        }
    }
}
