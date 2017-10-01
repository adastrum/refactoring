using System.Collections.Generic;

namespace TestApp
{
    public interface IMasterFacade
    {
        IEnumerable<Data> TryGetData();
        IEnumerable<Data> TryGetProcessedData();
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

        public IEnumerable<Data> TryGetData()
        {
            var data = _master.TryGetData();
            return data;

        }

        public IEnumerable<Data> TryGetProcessedData()
        {
            var data = _master.TryGetData();
            var processedData = _dataAssertor.Process(data);
            return processedData;
        }
    }
}
