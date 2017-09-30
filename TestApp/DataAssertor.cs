using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    public interface IDataAssertor
    {
        object Process(object data);
    }

    public class DataAssertor : IDataAssertor
    {
        // todo: initialize from constructor (in case of config file)
        private const int From = 1;
        private const int To = 9999;

        // ≈сли данные - это массив, провер€ем, что он не пустой. ≈сли данные не массив, провер€ем, что это не null
        public object Process(object data)
        {
            if (data is IEnumerable<Data>)
            {
                int temp;
                return ((IEnumerable<Data>)data)
                    .Where(x => int.TryParse(x.Number, out temp))
                    .Where(x => int.Parse(x.Number) >= From && int.Parse(x.Number) <= To);
            }
            throw new NotSupportedException();
        }
    }
}