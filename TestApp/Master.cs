using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    public class Master : MasterBase
    {
        private static MasterHelper _helper;

        public Master(MasterHelper helper)
        {
            _helper = helper;
        }

        public override void TryGetData(out IEnumerable<Data> data)
        {
            data = _helper.GetFormattedData("price", "сумма прописью");

            if (data.ToList().Count == 0)
                throw new InvalidOperationException();
        }
    }
}