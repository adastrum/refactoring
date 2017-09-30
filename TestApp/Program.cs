using System.Collections.Generic;

namespace TestApp
{
    // Задание на рефакторинг
    // Необходимо выполнить рефакторинг приведенного кода, обеспечив соблюдение практик и принципов ООП.

    class Program
    {
        static void Main()
        {
            // todo: use IoC
            var dataFormatter = new DataFormatter();
            var masterHelper = new MasterHelper(dataFormatter);
            var master = new Master(masterHelper);
            var dataAssertor = new DataAssertor();
            var masterFacade = new MasterFacade(master, dataAssertor);
            var logger = new Logger();
            var masterFacadeDecorator = new MasterFacadeDecorator(masterFacade, logger);

            IEnumerable<Data> data;

            masterFacadeDecorator.TryGetData(out data);
        }
    }
}