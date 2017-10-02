using System;
using System.Linq;

namespace TestApp
{
    public interface IFormatValidator
    {
        FormatValidationResult Validate(string format);
    }

    public class FormatValidator : IFormatValidator
    {
        private readonly IFormatProvider _formatProvider;

        public FormatValidator(IFormatProvider formatProvider)
        {
            _formatProvider = formatProvider;
        }

        // todo: initialize from constructor (in case of config file)
        private const int MinLength = 3;
        private const int MaxLength = 28;

        public FormatValidationResult Validate(string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return FormatValidationResult.NullOrEmpty;
            }

            var formatLength = format.Length;
            if (formatLength <= MinLength || formatLength >= MaxLength)
            {
                return FormatValidationResult.LengthOutOfRange;
            }

            if (!_formatProvider.GetSupportedFormats().Contains(format))
            {
                return FormatValidationResult.NotSupported;
            }

            return FormatValidationResult.Valid;
        }
    }

    public enum FormatValidationResult
    {
        Valid,
        NullOrEmpty,
        LengthOutOfRange,
        NotSupported
    }
    public class FormatValidationException : Exception
    {
        public FormatValidationException()
        {
            
        }

        public FormatValidationException(FormatValidationResult formatValidationResult)
        {
            // todo: proper message strings
        }
    }
}
