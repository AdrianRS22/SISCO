namespace SISCO.Web.Extensions
{
    public static class StringExtensions
    {
        public static string ConvertirPrecio(this decimal precio)
        {
            var precioFormateado = precio.ToString("#,##0");
            return $"₡{precioFormateado}";
        }
    }
}