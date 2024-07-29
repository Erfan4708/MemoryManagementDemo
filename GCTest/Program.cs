using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    class Program
    {
        // Function to display memory usage
        static void DisplayMemory(string message)
        {
            Console.WriteLine($"{message}: {GC.GetTotalMemory(true) / (1024 * 1024)} MB");
            Console.WriteLine();
        }
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
    }

}
