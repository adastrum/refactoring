using System.Collections.Generic;

namespace TestApp
{
    public interface IMasterHelperContract
    {
        IEnumerable<Data> GetFormattedData(string name, string format);
    }
}