namespace FullStack.Services.Web.Utility
{
    public class SD
    {
        public static string StudentApiBase { get; set; }
        public static string AuthApiBase { get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
