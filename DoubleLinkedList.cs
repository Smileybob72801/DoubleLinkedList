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
            AddItemToEnd(item);
        }

        public void AddItemToEnd(T? item)
        {
            Node<T?> newNode = new(item)
            {
                Container = this
            };

            _head ??= newNode;

            if (_tail is not null)
            {
                _tail.NextNode = newNode;
                newNode.PreviousNode = _tail;
            }

            _tail = newNode;

            Count++;
        }

        public void AddItemToFront(T? item)
        {
            Node<T?> newNode = new(item)
            {
                Container = this
            };

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
            foreach(Node<T?> node in GetNodes())
            {
                node.NextNode = null;
                node.PreviousNode = null;
            }

            _head = null;
            _tail = null;

            Count = 0;
        }

        public bool Contains(T? item)
        {
            foreach (Node<T?> node in GetNodes())
            {
                T? data = node.Data;

                if ((data is null && item is null) ||
                    (data is not null && data.Equals(item)))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T?[] array, int arrayIndex)
        {
            ArgumentNullException.ThrowIfNull(array);

            if (arrayIndex < 0 || arrayIndex >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            if (array.Length < Count + arrayIndex)
                throw new ArgumentException("Insufficient space in target array.");

            foreach (Node<T?> node in GetNodes())
            {
                array[arrayIndex] = node.Data;
                arrayIndex++;
            }
        }

        public void AddNode(Node<T?> newNode)
        {
            ArgumentNullException.ThrowIfNull(newNode);

            if (_head is null)
            {
                _head = newNode;
                _tail = newNode;
                newNode.Container = this;
            }
            else if (_tail is not null)
            {
                InsertAfterNode(newNode, _tail);
            }
            else
            {
                throw new InvalidOperationException(
                    $"{nameof(_tail)} is null, cannot insert node.");
            }
        }

        public void InsertAfterNode(Node<T?> newNode, Node<T?> originalNode)
        {
            ArgumentNullException.ThrowIfNull(newNode);
            ArgumentNullException.ThrowIfNull(originalNode);

            newNode.Container = this;

            Node<T?>? originalNextNode = originalNode.NextNode;

            newNode.PreviousNode = originalNode;
            newNode.NextNode = originalNextNode;

            if (originalNextNode is not null)
                originalNextNode.PreviousNode = newNode;

            originalNode.NextNode = newNode;

            if (originalNode.Equals(_tail))
                _tail = newNode;

            Count++;
        }

        public void InsertBeforeNode(Node<T?> newNode, Node<T?> originalNode)
        {
            ArgumentNullException.ThrowIfNull(newNode);
            ArgumentNullException.ThrowIfNull(originalNode);

            newNode.Container = this;

            Node<T?>? originalPreviousNode = originalNode.PreviousNode;

            newNode.NextNode = originalNode;
            newNode.PreviousNode = originalPreviousNode;

            if (originalPreviousNode is not null)
                originalPreviousNode.NextNode = newNode;

            if (originalNode.Equals(_head))
                _head = newNode;

            Count++;
        }

        public bool Remove(T? item)
        {
            foreach (Node<T?> node in GetNodes())
            {
                T? data = node.Data;

                if ((data is null && item is null) ||
                    (data is not null && data.Equals(item)))
                {
                    if (node.Equals(_head))
                        _head = node.NextNode;

                    if (node.Equals(_tail))
                        _tail = node.PreviousNode;

                    if (node.NextNode is not null)
                        node.NextNode.PreviousNode = node.PreviousNode;

                    if (node.PreviousNode is not null)
                        node.PreviousNode.NextNode = node.NextNode;

                    if (_head is null)
                        _tail = null;

                    Count--;

                    return true;
                }
            }

            return false;
        }

        public void RemoveNode(Node<T?> node)
        {
            ArgumentNullException.ThrowIfNull(node);

            if (node.Container?.Equals(this) != true)
                throw new InvalidOperationException("Node is not in this container.");

            var originalNextNode = node.NextNode;
            var originalPreviousNode = node.PreviousNode;

            if (originalPreviousNode is not null)
                originalPreviousNode.NextNode = originalNextNode;

            if (originalNextNode is not null)
                originalNextNode.PreviousNode = originalPreviousNode;

            if (node.Equals(_head))
                _head = originalNextNode;

            if (node.Equals(_tail))
                _tail = originalPreviousNode;

            Count--;
        }

        public void ReverseNodes()
        {
            Node<T?>? currentNode = _head;
            Node<T?>? tempNode = null;

            while (currentNode is not null)
            {
                tempNode = currentNode.PreviousNode;
                currentNode.PreviousNode = currentNode.NextNode;
                currentNode.NextNode = tempNode;
                currentNode = currentNode.PreviousNode;
            }

            if (tempNode is not null)
            {
                tempNode = _head;
                _head = _tail;
                _tail = tempNode;
            }
        }

        public IEnumerator<T?> GetEnumerator()
        {
            foreach (Node<T?> node in GetNodes())
            {
                yield return node.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();

        private IEnumerable<Node<T?>> GetNodes()
        {
            Node<T?>? currentNode = _head;

            while (currentNode is not null)
            {
                yield return currentNode;
                currentNode = currentNode.NextNode;
            }
        }
    }
}
