namespace CustomTestingFramework.Core.Interfaces;

public interface ITestRunner
{
    List<Test> RunTests(string pathToTestLibrary);
}