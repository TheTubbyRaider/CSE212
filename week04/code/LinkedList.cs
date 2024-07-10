using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList : IEnumerable<int> {
    private Node? _head;
    private Node? _tail;

    // Node class for linked list nodes
    private class Node {
        public int Data;
        public Node? Next;
        public Node? Prev;

        public Node(int data) {
            Data = data;
        }
    }

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value) {
        Node newNode = new Node(value);

        if (_head is null) {
            _head = newNode;
            _tail = newNode;
        } else {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value) {
        Node newNode = new Node(value);

        if (_tail is null) {
            _head = newNode;
            _tail = newNode;
        } else {
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead() {
        if (_head == _tail) {
            _head = null;
            _tail = null;
        } else if (_head is not null) {
            _head.Next!.Prev = null;
            _head = _head.Next;
        }
    }

    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail() {
        if (_tail == _head) {
            _head = null;
            _tail = null;
        } else if (_tail is not null) {
            _tail.Prev!.Next = null;
            _tail = _tail.Prev;
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue) {
        Node? curr = _head;

        while (curr is not null) {
            if (curr.Data == value) {
                if (curr == _tail) {
                    InsertTail(newValue);
                } else {
                    Node newNode = new Node(newValue);
                    newNode.Prev = curr;
                    newNode.Next = curr.Next;
                    curr.Next!.Prev = newNode;
                    curr.Next = newNode;
                }
                return;
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value) {
        Node? curr = _head;

        while (curr is not null) {
            if (curr.Data == value) {
                if (curr == _head) {
                    RemoveHead();
                } else if (curr == _tail) {
                    RemoveTail();
                } else {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }
                return;
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value with 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue) {
        Node? curr = _head;

        while (curr is not null) {
            if (curr.Data == oldValue) {
                curr.Data = newValue;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Yields all values in the linked list (forward iteration)
    /// </summary>
    public IEnumerator<int> GetEnumerator() {
        Node? curr = _head;
        while (curr is not null) {
            yield return curr.Data;
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable<int> Reverse() {
        Node? curr = _tail;
        while (curr is not null) {
            yield return curr.Data;
            curr = curr.Prev;
        }
    }

    /// <summary>
    /// Required for IEnumerable implementation
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public override string ToString() {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public bool HeadAndTailAreNull() {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public bool HeadAndTailAreNotNull() {
        return _head is not null && _tail is not null;
    }
}
