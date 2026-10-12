using System.ComponentModel.DataAnnotations;

namespace Programacion2ClientesBlazor.Validations
{
    public class NumeroNoTrivialAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var texto = value.ToString()?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(texto))
            {
                return ValidationResult.Success;
            }

            var digitos = new string(
                texto.Where(char.IsDigit).ToArray()
            );

            if (digitos.Length < 2)
            {
                return ValidationResult.Success;
            }

            if (digitos.All(c => c == digitos[0]))
            {
                return new ValidationResult(
                    ErrorMessage ??
                    "El valor no puede contener únicamente dígitos repetidos."
                );
            }

            if (EsSecuenciaAscendente(digitos) ||
                EsSecuenciaDescendente(digitos))
            {
                return new ValidationResult(
                    ErrorMessage ??
                    "El valor no puede ser una secuencia numérica consecutiva."
                );
            }

            return ValidationResult.Success;
        }

        private static bool EsSecuenciaAscendente(string valor)
        {
            for (int i = 1; i < valor.Length; i++)
            {
                var anterior = valor[i - 1] - '0';
                var actual = valor[i] - '0';

                if (actual != (anterior + 1) % 10)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool EsSecuenciaDescendente(string valor)
        {
            for (int i = 1; i < valor.Length; i++)
            {
                var anterior = valor[i - 1] - '0';
                var actual = valor[i] - '0';

                var esperado =
                    anterior == 0 ? 9 : anterior - 1;

                if (actual != esperado)
                {
                    return false;
                }
            }

            return true;
        }
    }
}