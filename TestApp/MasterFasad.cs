using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    public class MasterFasad : MasterBase
    {
        public override void TryGetData(out IEnumerable<Data> data)
        {
            var postavshikDannyh = new MasterHelper();

            var o_O = new Master(postavshikDannyh);

            o_O.TryGetData(out data);

            data.Select(pls =>
            {
                Logger.Log(pls);
                return pls;
            }).ToList();

        }

        public static DataAssertor ass;

        public void TryGetProcessedData(out IEnumerable<Data> wtf)
        {
            var postavschchik = new MasterHelper();

            var o_O = new Master(postavschchik);
            o_O.TryGetData(out wtf);
            wtf.Select(pls =>
            {
                Logger.Log(pls);
                return pls;
            }).ToList();

            if (ass == null)
                ass = new DataAssertor();

            wtf = (IEnumerable<Data>)ass.Process(wtf);
        }

        public class DataAssertor
        {

            public static int begno = 1;
            public static int endno = 9999;

            // ≈сли данные - это массив, провер€ем, что он не пустой. ≈сли данные не массив, провер€ем, что это не null
            public object Process(object data)
            {
                if (data is IEnumerable<Data>)
                {
                    int temp;
                    return ((IEnumerable<Data>)data)
                        .Where(x => int.TryParse(x.Number, out temp))
                        .Where(x => int.Parse(x.Number) >= begno && int.Parse(x.Number) <= endno);
                }
                throw new NotSupportedException();
            }

        }

    }
}