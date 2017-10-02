using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    public interface IMasterHelper
    {
        IEnumerable<Data> GetFormattedData(string name, string format);
    }

    public class MasterHelper : IMasterHelper
    {

        private readonly IDataFormatter _dataFormatter;
        private readonly IFormatValidator _formatValidator;

        public MasterHelper(IDataFormatter dataFormatter, IFormatValidator formatValidator)
        {
            _dataFormatter = dataFormatter;
            _formatValidator = formatValidator;
        }

        public IEnumerable<Data> GetFormattedData(string name, string format)
        {
            var validationResult = _formatValidator.Validate(format);

            if (validationResult == FormatValidationResult.Valid)
            {
                using (var database = new Database())
                {
                    var data = database.GetData();
                    var result =
                        data
                            .Where(x => x.Name.StartsWith(name))
                            .Select(x => _dataFormatter.Format(format, x));
                    return result;
                }
            }

            throw new FormatValidationException(validationResult);
        }
    }
}