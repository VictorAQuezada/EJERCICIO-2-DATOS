using System;
using Xamarin.Forms;

namespace DatosYTiposApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Mensaje de bienvenida
            ResultLabel.Text = "¡Bienvenido, Víctor Quezada! Ingresa un valor para determinar su tipo.";
        }

        private void OnDetermineDataTypeClicked(object sender, EventArgs e)
        {
            try
            {
                string input = InputField.Text;

                if (string.IsNullOrWhiteSpace(input))
                {
                    ResultLabel.Text = "⚠️ La entrada no puede estar vacía. Por favor, ingresa un valor.";
                    return;
                }

                string result = DetermineDataType(input);
                ResultLabel.Text = $"✅ {result}";
            }
            catch (Exception ex)
            {
                ResultLabel.Text = $"❌ Error: {ex.Message}";
            }
        }

        private string DetermineDataType(string input)
        {
            if (int.TryParse(input, out _))
                return "El tipo de dato es: int (Número Entero)";

            if (double.TryParse(input, out _))
                return "El tipo de dato es: double (Número Decimal)";

            if (DateTime.TryParse(input, out DateTime parsedDate))
                return $"El tipo de dato es: DateTime (Fecha y Hora)\nFormato: {parsedDate:yyyy-MM-dd}";

            if (bool.TryParse(input, out _))
                return "El tipo de dato es: bool (Verdadero o Falso)";

            if (input.Length == 1)
                return "El tipo de dato es: char (Carácter)";

            if (decimal.TryParse(input, out _))
                return "El tipo de dato es: decimal (Número Decimal de Alta Precisión)";

            return "El tipo de dato es: string (Texto)";
        }
    }
}