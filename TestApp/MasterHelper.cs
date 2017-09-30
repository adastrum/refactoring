using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    public interface IMasterHelper
    {
        IEnumerable<Data> GetFormattedData(string name, string format);
    }

    public class MasterHelper : IMasterHelper
    {
        // todo: initialize from constructor (in case of config file)
        private const int MinLength = 3;
        private const int MaxLength = 28;

        private readonly IDataFormatter _dataFormatter;

        public MasterHelper(IDataFormatter dataFormatter)
        {
            _dataFormatter = dataFormatter;
        }

        private void Validate(string format)
        {
            if (format == null)
                throw new ArgumentNullException();
            if (format != "")
            {
                if (format.Length >= MaxLength)
                    throw new ArgumentOutOfRangeException("Превышена длина формата");
                if (format.Length <= MinLength)
                    throw new ArgumentOutOfRangeException("Превышена длина формата");

                if (format != "сумма прописью" || format != "сумма в рублях")
                    throw new NotSupportedException();
            }
            else
                throw new ArgumentException();
        }

        public IEnumerable<Data> GetFormattedData(string name, string format)
        {
            Validate(name);

            using (var database = new Database())
            {
                var data = database.GetData();
                var result =
                    data
                        .Where(x => x.Name.StartsWith(name))
                        .Select(x => _dataFormatter.Format(format, x));
                return result;
            }
        }
    }
}