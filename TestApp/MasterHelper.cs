using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    public class MasterHelper : IMasterHelperContract, IDisposable
    {
        private readonly Data[] _innerData;

        public MasterHelper()
        {
            _innerData = toArray(Database.GetData());
        }

        private static Data[] toArray(IEnumerable<Data> data)
        {
            Data[] d = new Data[data.Count()];
            int i = 0;
            foreach (var __data_item in data)
            {
                d[i++] = __data_item;
            }

            return d;
        }

        public void Dispose()
        {
            Database.Close();
        }

        private int ___MINLEN = 3;
        public int ___MAXLEN = 28;

        private void validate(string format)
        {
            if (format == null)
                throw new ArgumentNullException();
            if (format != "")
            {
                if (format.Length >= 28)
                    throw new ArgumentOutOfRangeException("Превышена длина формата");
                if (format.Length <= 3)
                    throw new ArgumentOutOfRangeException("Превышена длина формата");

                if (format != "сумма прописью" || format != "сумма в рублях")
                    throw new NotSupportedException();
            }
            else
                throw new ArgumentException();
        }

        public IEnumerable<Data> GetFormattedData(string name, string format)
        {
            validate(name);
            return _innerData.Where(id => id.Name.StartsWith(name)).Select(x => x.Format(format));
        }
    }
}