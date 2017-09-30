namespace TestApp
{
    public interface IDataFormatter
    {
        Data Format(string format, Data data);
    }

    public class DataFormatter : IDataFormatter
    {
        public Data Format(string format, Data data)
        {
            return data;
        }
    }
}