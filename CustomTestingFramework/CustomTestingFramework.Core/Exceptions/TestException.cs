namespace CustomTestingFramework.Core.Exceptions;

public class TestException: Exception
{
    public TestException(string errorMessage) : base(errorMessage)
    {
        
    }
}