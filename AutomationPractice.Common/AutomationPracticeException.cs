namespace AutomationPractice.Common;

[Serializable]
public class AutomationPracticeException : Exception
{
    public AutomationPracticeException() { }
    public AutomationPracticeException(string message) : base(message) { }
    public AutomationPracticeException(string message, Exception inner) : base(message, inner) { }
    protected AutomationPracticeException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}