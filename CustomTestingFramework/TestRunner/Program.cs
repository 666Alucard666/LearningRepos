using CustomTestingFramework.Core;

Console.Write("Hello, write here path to your library! ");
var path = Console.ReadLine();
var run = new TestRunner();
run.RunTests(path);