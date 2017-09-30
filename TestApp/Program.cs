//Задание на рефакторинг

//В прилагаемом файле - пример кода, требующего рефакторинга.
//Необходимо выполнить рефакторинг, обеспечив соблюдение практик и принципов ООП.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    // Задание на рефакторинг

    // Необходимо выполнить рефакторинг приведенного кода, обеспечив соблюдение практик и принципов ООП.

    class Program
    {
        private static MasterBase mMaster;
        private static IEnumerable<Data> o_O;

        static void Main(string[] args)
        {
            mMaster = new MasterFasad();

            mMaster.TryGetData(out o_O);
        }


    }

    public class Data
    {
        public string Name { get; set; }
        public string Number { get; set; }

        internal Data Format(string format)
        {
            return this;
        }
    }

    public static class Logger
    {
        public static void Log(object data)
        {
            Console.WriteLine(data.ToString());
        }
    }

    public abstract class MasterBase
    {
        public virtual void TryGetData(out IEnumerable<Data> data)
        {
            throw new NotImplementedException();
        }
    }

    public interface MasterHelperContract
    {
        IEnumerable<Data> GetFormattedData(string name, string format);
    }

    public static class Database
    {
        public static IEnumerable<Data> _data = new List<Data>();
        private static bool _closed = false;

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

    public class MasterHelper : MasterHelperContract, IDisposable
    {
        private Data[] innerData;

        public MasterHelper()
        {
            innerData = toArray(Database.GetData());
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
            else
            {
                if (format != "")
                {
                    if (format.Length >= 28)
                        throw new ArgumentOutOfRangeException("Превышена длина формата");
                    else if (format.Length <= 3)
                        throw new ArgumentOutOfRangeException("Превышена длина формата");

                    if (format != "сумма прописью" || format != "сумма в рублях")
                        throw new NotSupportedException();
                }
                else
                    throw new ArgumentException();
            }
            return;
        }

        public IEnumerable<Data> GetFormattedData(string name, string format)
        {
            validate(name);
            return innerData.Where(id => id.Name.StartsWith(name)).Select(x => x.Format(format));
        }
    }

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

            // Если данные - это массив, проверяем, что он не пустой. Если данные не массив, проверяем, что это не null
            public object Process(object data)
            {
                if (data is IEnumerable<TestApp.Definitions.DataDef.Data>)
                {
                    int temp;
                    return ((IEnumerable<TestApp.Definitions.DataDef.Data>)data)
                        .Where(x => int.TryParse(x.Number, out temp))
                        .Where(x => int.Parse(x.Number) >= begno && int.Parse(x.Number) <= endno);
                }
                else
                {
                    throw new NotSupportedException();
                }


            }

        }

    }
}