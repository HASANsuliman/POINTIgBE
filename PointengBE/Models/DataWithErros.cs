namespace PointengBE.Models
{
    public class DataWithErros
    {
        public DataWithErros()
        {
        }

        // public DataWithErros() { }
        public DataWithErros(object result, string errorMessage)
        {
            Result = result;
            ErrorMessage = errorMessage;
        }
        public object? Result { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
