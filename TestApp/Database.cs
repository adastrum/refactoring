using System;
using System.Collections.Generic;

namespace TestApp
{
    public class Database : IDisposable
    {
        private bool _closed;

        public IEnumerable<Data> GetData()
        {
            if (_closed)
                throw new InvalidOperationException("Db closed");

            return new List<Data>();
        }

        public void Close()
        {
            _closed = true;
        }

        public void Dispose()
        {
            Close();
        }
    }
}