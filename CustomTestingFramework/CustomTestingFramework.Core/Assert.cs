using CustomTestingFramework.Core.Exceptions;

namespace CustomTestingFramework.Core;

public static class Assert
{
    public static void IsTrue(bool expression, string error = null)
    {
        if (!expression)
        {
            throw new TestException(error);
        }
    }

    public static void AreEqual(object expected, object actual, string error = null)
    {
        if (!expected.Equals(actual))
        {
            throw new TestException(error);
        }
    }
}