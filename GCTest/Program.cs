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
