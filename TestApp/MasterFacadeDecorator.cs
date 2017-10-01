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

        public IEnumerable<Data> TryGetData()
        {
            var data = _decorated.TryGetData();

            Log(data);

            return data;
        }

        public IEnumerable<Data> TryGetProcessedData()
        {
            var processedData = _decorated.TryGetProcessedData();

            Log(processedData);

            return processedData;
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
