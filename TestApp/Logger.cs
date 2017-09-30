using System;

namespace TestApp
{
    public static class Logger
    {
        public static void Log(object data)
        {
            Console.WriteLine(data.ToString());
        }
    }
}