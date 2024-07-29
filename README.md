# MemoryManagementDemo

## Overview

This project demonstrates memory management in C# using the `IDisposable` interface and manual garbage collection. It includes examples of creating large arrays and disposing of them to manage memory usage efficiently.

## Classes

### BaseViewModel

The `BaseViewModel` class implements the `IDisposable` interface to provide a standard pattern for disposing of resources. It includes a finalizer to ensure that resources are released even if the `Dispose` method is not called explicitly.

### DerivedViewModelA and DerivedViewModelB

These classes inherit from `BaseViewModel` and implement the `Dispose` method. They also include a method to allocate a large array to demonstrate memory usage.

## Usage

The `Program` class in the `Main` method demonstrates the following:

1. Allocating large arrays in `DerivedViewModelA` and `DerivedViewModelB`.
2. Displaying memory usage before and after allocation.
3. Manually disposing of the objects to release memory.
4. Displaying memory usage after disposal.

## Screenshots

### Memory Usage Before and After Disposal

![Memory Usage](https://github.com/Erfan4708/MemoryManagementDemo/blob/master/Resources/memory_usage.png)

### Memory Usage Graph

![Memory Usage Graph](https://github.com/Erfan4708/MemoryManagementDemo/blob/master/Resources/memory_usage_graph.png)


## Code Example

```csharp
using System;
using System.Threading.Tasks;

using GCTest.ViewModels.ViewModels;

namespace GCTest
{
    class Program
    {
        static void Main()
        {
            Task.Delay(2000).Wait();    

            DisplayMemory("Memory usage before allocating large array");

            DerivedViewModelA viewModelAWithoutUsing = new DerivedViewModelA();
            viewModelAWithoutUsing.AllocateLargeArray(100); // 100 MB
            DisplayMemory("Memory usage for DerivedViewModelA");
            Task.Delay(2000).Wait();

            // Manually disposing DerivedViewModelA
            viewModelAWithoutUsing.Dispose();
            DisplayMemory("Memory usage after manual dispose for DerivedViewModelA");
            Task.Delay(2000).Wait();

            DerivedViewModelB viewModelBWithoutUsing = new DerivedViewModelB();
            viewModelBWithoutUsing.AllocateLargeArray(50); // 50 MB
            DisplayMemory("Memory usage for DerivedViewModelB");
            Task.Delay(2000).Wait();

            // Manually disposing DerivedViewModelB
            viewModelBWithoutUsing.Dispose();
            DisplayMemory("Memory usage after manual dispose for DerivedViewModelB");
            Task.Delay(2000).Wait();

            Console.ReadLine();
        }

        // Function to display memory usage
        static void DisplayMemory(string message)
        {
            Console.WriteLine($"{message}: {GC.GetTotalMemory(true) / (1024 * 1024)} MB");
            Console.WriteLine();
        }
    }
}
```

## Conclusion
This project illustrates the importance of proper resource management in C#. By implementing the IDisposable interface and ensuring that resources are disposed of correctly, we can prevent memory leaks and improve the performance of our applications.

