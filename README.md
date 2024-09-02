# DoubleLinkedList

**DoubleLinkedList** is a C# console application that implements a doubly linked list data structure. It provides functionality to add, remove, and traverse nodes in both forward and reverse directions.

## Features

- ➕ **Add Items:** Add nodes to the front or the end of the list.
- ➖ **Remove Items:** Remove nodes or items from the list efficiently.
- 🔄 **Reverse Nodes:** Reverse the order of nodes in the list.
- 🔍 **Search:** Check if an item exists in the list.
- ❌ **Remove Elements:** Remove elements from the list by value or by node.
- 📋 **Copy:** Copy the list's contents to an array.
- ♻️ **Enumerate:** Iterate through the list using `foreach`.

## Build The Project
1. Clone the repository:
```bash
git clone https://github.com/Smileybob72801/DoubleLinkedList.git
```

2. Navigate to project directory:
```bash
cd DoubleLinkedList
```

3. Build the project
```bash
dotnet build
```

4. Run the app:
```bash
dotnet run
```

## Code Usage

Here’s an example of how you can use the DoubleLinkedList class:

```csharp
var list = new DoubleLinkedList<int>();

list.Add(1);
list.Add(2);
list.AddItemToFront(0);

foreach (var item in list)
{
    Console.WriteLine(item);  // Outputs: 0, 1, 2
}

list.ReverseNodes();

foreach (var item in list)
{
    Console.WriteLine(item);  // Outputs: 2, 1, 0
}
```

## Technologies Used
- **C#** for the implementation of the doubly linked list.
- **.NET Core** for compiling and running the application.

## Prerequisites
- **.NET SDK 8.0** or later

## Future Enhancements
- ⚡ Performance Optimization: Optimize the list operations for large datasets.
- 🔄 Circular Linked List: Plan to extend the implementation to support circular linked lists.
- 📏 Length Limitation: Add a feature to limit the number of elements in the list.
- 📈 Advanced Traversal Methods: Implement more complex traversal and searching algorithms.
