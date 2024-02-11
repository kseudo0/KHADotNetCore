// See https://aka.ms/new-console-template for more information
using KHADotNetCore.ConsoleApp.AdoDotNetExamples;
using KHADotNetCore.ConsoleApp.DapperExamples;
using KHADotNetCore.ConsoleApp.EFCoreExamples;

Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
adoDotNetExample.Edit(2);
//adoDotNetExample.Create("Testing Title", "Testing Author", "Testing Content");
adoDotNetExample.Update(1004,"Testing Title 1004", "Testing Author 1004", "Testing Content 1004");
adoDotNetExample.Delete(1003);
adoDotNetExample.Read();
Console.WriteLine("----------------------------");

DapperExample dapperExample = new DapperExample();
dapperExample.Edit(3);
//dapperExample.Create("Dapper Title", "Dapper Author", "Dapper Content");
dapperExample.Update(1005, "Testing Dapper Title 1004", "Testing Dapper Author 1004", "Testing Dapper Content 1004");
dapperExample.Delete(1005);
dapperExample.Read();
Console.WriteLine("----------------------------");

EFCoreExample efCoreExample = new EFCoreExample();
efCoreExample.Edit(2);
//efCoreExample.Create("EfTitle","EF Author","EF Content");
//efCoreExample.Update(1006,"EfTitle Update","EF Author Update","EF Content Update");
efCoreExample.Read();
efCoreExample.Delete(7);
Console.ReadKey();
