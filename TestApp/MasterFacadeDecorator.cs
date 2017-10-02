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

        public IEnumerable<Data> GetData(string name, string format)
        {
            var data = _decorated.GetData(name, format);

            Log(data);

            return data;
        }

        public IEnumerable<Data> GetProcessedData(string name, string format)
        {
            var processedData = _decorated.GetProcessedData(name, format);

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
