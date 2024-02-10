// See https://aka.ms/new-console-template for more information
using KHADotNetCore.ConsoleApp.AdoDotNetExamples;

Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
adoDotNetExample.Edit(2);
//adoDotNetExample.Create("Testing Title", "Testing Author", "Testing Content");
adoDotNetExample.Update(1004,"Testing Title 1004", "Testing Author 1004", "Testing Content 1004");
adoDotNetExample.Delete(1003);
adoDotNetExample.Read();

Console.ReadKey();
