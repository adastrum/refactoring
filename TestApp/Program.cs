using System.Collections.Generic;

namespace TestApp
{
    // Задание на рефакторинг

    // Необходимо выполнить рефакторинг приведенного кода, обеспечив соблюдение практик и принципов ООП.

    class Program
    {
        private static MasterBase _mMaster;
        private static IEnumerable<Data> _data;

        static void Main()
        {
            _mMaster = new MasterFasad();

            _mMaster.TryGetData(out _data);
        }
    }
}