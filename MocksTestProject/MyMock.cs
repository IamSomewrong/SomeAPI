using Microsoft.Extensions.Logging;
using SomeAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MocksTestProject
{
    internal class MyMock: ILogger<PersonController>
    {
        public int LogCallsCount { get; private set; }

        public MyMock()
        {
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            LogCallsCount++;
        }
    }
}
