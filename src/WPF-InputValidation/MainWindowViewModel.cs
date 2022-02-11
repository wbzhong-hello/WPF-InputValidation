using System;

namespace ShowValidationError
{
    // All TextBox inputs use OneWayToSource binding mode
    // This view model only demonstrates how to validate the input
    // An MVVM framework is not necessary
    public class MainWindowViewModel
    {
        private string _DefaultStyleInput;
        private string _TooltipStyleInput;
        private string _ErrorTemplateStyleInput;
        private string _CustomControlStyleInput;

        public string DefaultStyleInput
        {
            get => _DefaultStyleInput;
            set
            {
                ValidateInput(value);
                _DefaultStyleInput = value;
            }
        }

        public string TooltipStyleInput
        {
            get => _TooltipStyleInput;
            set
            {
                ValidateInput(value);
                _TooltipStyleInput = value;
            }
        }

        public string ErrorTemplateStyleInput
        {
            get => _ErrorTemplateStyleInput;
            set
            {
                ValidateInput(value);
                _ErrorTemplateStyleInput = value;
            }
        }

        public string CustomControlStyleInput
        {
            get => _CustomControlStyleInput;
            set
            {
                ValidateInput(value);
                _CustomControlStyleInput = value;
            }
        }

        private void ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("The input cannot be empty.");

            if (!int.TryParse(input, out int value))
                throw new ArgumentException("The input format is incorrect.");

            if (value < 0 || value > 100)
                throw new ArgumentException("The value is out of range.");
        }
    }
}
