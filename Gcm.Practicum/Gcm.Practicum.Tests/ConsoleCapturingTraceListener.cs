using System.Diagnostics;
using System.Text;

namespace Gcm.Practicum.Tests
{
    /// <summary>
    /// Captures console output for use by tests.
    /// </summary>
    internal class ConsoleCapturingTraceListener : TraceListener
    {
        private readonly StringBuilder stringBuilder = new StringBuilder();

        public string Output
        {
            get { return stringBuilder.ToString(); }
        }

        public override void Write(string message)
        {
            stringBuilder.Append(message);
        }

        public override void WriteLine(string message)
        {
            stringBuilder.Append(message);
            stringBuilder.AppendLine();
        }
    }
}