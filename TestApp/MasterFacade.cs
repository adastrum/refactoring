using System.Collections.Generic;

namespace TestApp
{
    public interface IMasterFacade
    {
        void TryGetData(out IEnumerable<Data> data);
        void TryGetProcessedData(out IEnumerable<Data> data);
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

        public void TryGetData(out IEnumerable<Data> data)
        {
            _master.TryGetData(out data);

        }

        public void TryGetProcessedData(out IEnumerable<Data> data)
        {
            _master.TryGetData(out data);

            data = (IEnumerable<Data>)_dataAssertor.Process(data);
        }
    }
}