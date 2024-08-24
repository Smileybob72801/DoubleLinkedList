﻿using System.Collections;

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

        public void Reverse()
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
            Node<T?>? currentNode;

            if (_head is null)
            {
                Console.WriteLine($"Hi! this is the private {nameof(GetNodes)} method here, " +
                    "telling you that you cannot iterate through a linked list with no head!" +
                    $"{Environment.NewLine}Did you use the Clear method, " +
                    "or the Remove method on a linked list with just one node?");
                yield break;
            }
            else
            {
                currentNode = _head;
            }

            while (currentNode is not null)
            {
                yield return currentNode;
                currentNode = currentNode.NextNode;
            }
        }
    }
}
