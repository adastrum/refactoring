using System;

namespace TestApp
{
    public interface ILogger
    {
        void Log(object data);
    }

    public class Logger : ILogger
    {
        public void Log(object data)
        {
            Console.WriteLine(data);
        }
    }
}