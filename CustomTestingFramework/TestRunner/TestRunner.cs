using System.Reflection;
using CustomTestingFramework.Core.Exceptions;
using CustomTestingFramework.Core.Interfaces;

namespace CustomTestingFramework.Core;

public class TestRunner: ITestRunner
{
    public List<Test> RunTests(string pathToTestLibrary)
    {
        var results = new List<Test>();
        var assembly = Assembly.LoadFrom(pathToTestLibrary);
        var types = assembly.GetTypes();
        var testClasses = types.Where(t => t.IsClass && t.IsPublic && t.CustomAttributes
            .Any(attribute => attribute.AttributeType == typeof(TestClassAttribute)));
        foreach (var testClass in testClasses)
        {
            
            
            var testMethods = testClass.GetMethods().Where(m => m.CustomAttributes.Any(attribute=> attribute.AttributeType == typeof(TestMethodAttribute)));
            if (testMethods.Any())
            {
                var instanceOfTestClass = Activator.CreateInstance(testClass);
                foreach (var testMethod in testMethods)
                {
                    var testResult = new Test();
                    testResult.Name = $"{testClass.Name}:{testMethod.Name}";
                    try
                    {
                        testMethod.Invoke(instanceOfTestClass, null);
                        testResult.Success = true;
                    }
                    catch (TestException exception)
                    {
                        testResult.Success = false;
                        testResult.ErrorMessage = "Oooups, something went wrong " + exception.Message;
                    }
                    catch (Exception exception)
                    {
                        testResult.Success = false;
                        testResult.ErrorMessage = $"{exception.GetType().Name}:{exception.Message}";
                    }
                    finally
                    {
                        results.Add(testResult);
                    }
                }
            }
        }
        return results;
    }
}