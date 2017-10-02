using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    public interface IMaster
    {
        IEnumerable<Data> GetData(string name, string format);
    }

    public class Master : IMaster
    {
        private readonly IMasterHelper _helper;

        public Master(IMasterHelper helper)
        {
            _helper = helper;
        }

        public IEnumerable<Data> GetData(string name, string format)
        {
            // todo: move strings to method parameters
            var data = _helper.GetFormattedData(name, format);

            if (!data.Any())
                throw new InvalidOperationException();

            return data;
        }
    }
}