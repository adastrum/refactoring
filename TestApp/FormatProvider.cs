using System.Collections.Generic;

namespace TestApp
{
    public interface IFormatProvider
    {
        IEnumerable<string> GetSupportedFormats();
    }

    public class FormatProvider : IFormatProvider
    {
        public IEnumerable<string> GetSupportedFormats()
        {
            return new List<string> { DataFormats.WrittenSum, DataFormats.SumInRoubles };
        }
    }

    // todo: use resources
    public class DataFormats
    {
        public const string WrittenSum = "сумма прописью";

        public const string SumInRoubles = "сумма в рублях";
    }
}
