namespace TestApp
{
    public class Data
    {
        public string Name { get; set; }
        public string Number { get; set; }

        internal Data Format(string format)
        {
            return this;
        }
    }
}