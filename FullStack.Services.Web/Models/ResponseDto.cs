namespace FullStack.Services.Web.Models
{
    public class ResponseDto
    {
        public object Result { get; set; }
        public bool ISSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
