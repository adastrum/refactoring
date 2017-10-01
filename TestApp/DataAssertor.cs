using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    public interface IDataAssertor
    {
        // todo: interface constraint + marker interface for Data -> where T: IEnumerable<IData>
        T Process<T>(T data);
    }

    public class DataAssertor : IDataAssertor
    {
        // todo: initialize from constructor (in case of config file)
        private const int From = 1;
        private const int To = 9999;

        // ≈сли данные - это массив, провер€ем, что он не пустой. ≈сли данные не массив, провер€ем, что это не null
        public T Process<T>(T data)
        {
            var enumerable = data as IEnumerable<Data>;

            if (enumerable == null)
                throw new NotSupportedException();

            var result = enumerable
                .Where(x =>
                {
                    int temp;
                    return int.TryParse(x.Number, out temp) && temp >= From && temp <= To;
                });

            return (T)result;
        }
    }
}
