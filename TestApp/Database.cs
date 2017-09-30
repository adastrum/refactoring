using System;
using System.Collections.Generic;

namespace TestApp
{
    public static class Database
    {
        public static IEnumerable<Data> _data = new List<Data>();
        private static bool _closed;

        public static IEnumerable<Data> GetData()
        {
            if (_closed)
                throw new InvalidOperationException("Db closed");

            return _data;
        }

        public static void Close()
        {
            _closed = true;
        }
    }
}