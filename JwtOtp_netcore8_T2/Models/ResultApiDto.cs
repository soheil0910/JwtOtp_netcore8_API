namespace JwtOtp_netcore8_T2.Models
{
    public class ResultApiDto
    {



        public bool Status { get; set; }
        public int StatusNum { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public object? value { get; set; } = null;

    }
}
