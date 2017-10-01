using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    public interface IMaster
    {
        IEnumerable<Data> TryGetData();
    }

    public class Master : IMaster
    {
        private readonly IMasterHelper _helper;

        public Master(IMasterHelper helper)
        {
            _helper = helper;
        }

        public IEnumerable<Data> TryGetData()
        {
            // todo: move strings to method parameters
            var data = _helper.GetFormattedData("price", "сумма прописью");

            if (!data.Any())
                throw new InvalidOperationException();

            return data;
        }
    }
}