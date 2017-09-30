using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    public interface IMaster
    {
        void TryGetData(out IEnumerable<Data> data);
    }

    public class Master : IMaster
    {
        private readonly IMasterHelper _helper;

        public Master(IMasterHelper helper)
        {
            _helper = helper;
        }

        public void TryGetData(out IEnumerable<Data> data)
        {
            // todo: move strings to method parameters
            data = _helper.GetFormattedData("price", "сумма прописью");

            if (!data.Any())
                throw new InvalidOperationException();
        }
    }
}