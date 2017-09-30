using System.Collections.Generic;

namespace TestApp
{
    public class MasterFacadeDecorator : IMasterFacade
    {
        private readonly IMasterFacade _decorated;
        private readonly Logger _logger;

        public MasterFacadeDecorator(IMasterFacade decorated, Logger logger)
        {
            _decorated = decorated;
            _logger = logger;
        }

        public void TryGetData(out IEnumerable<Data> data)
        {
            _decorated.TryGetData(out data);

            Log(data);
        }

        public void TryGetProcessedData(out IEnumerable<Data> data)
        {
            _decorated.TryGetProcessedData(out data);

            Log(data);
        }

        private void Log(IEnumerable<Data> data)
        {
            foreach (var item in data)
            {
                _logger.Log(item);
            }
        }
    }
}
