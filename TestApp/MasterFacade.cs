using System.Collections.Generic;

namespace TestApp
{
    public interface IMasterFacade
    {
        IEnumerable<Data> GetData(string name, string format);

        IEnumerable<Data> GetProcessedData(string name, string format);
    }

    public class MasterFacade : IMasterFacade
    {
        private readonly IMaster _master;
        private readonly DataAssertor _dataAssertor;

        public MasterFacade(IMaster master, DataAssertor dataAssertor)
        {
            _master = master;
            _dataAssertor = dataAssertor;
        }

        public IEnumerable<Data> GetData(string name, string format)
        {
            var data = _master.GetData(name, format);
            return data;

        }

        public IEnumerable<Data> GetProcessedData(string name, string format)
        {
            var data = GetData(name, format);
            var processedData = _dataAssertor.Process(data);
            return processedData;
        }
    }
}
