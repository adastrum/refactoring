using System;

namespace TestApp
{
    public interface ILogger
    {
        void Log<T>(T data);
    }

    public class Logger : ILogger
    {
        public void Log<T>(T data)
        {
            Console.WriteLine(data);
        }
    }
}