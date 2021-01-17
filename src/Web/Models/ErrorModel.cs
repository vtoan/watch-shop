namespace Web.Models
{
    public class ErrorModel
    {
        public string Message { get; set; }

        public string Action { get; set; }

        public ErrorModel(string mess, string act = "")
        {
            Message = mess;
            Action = act;
        }
    }
}