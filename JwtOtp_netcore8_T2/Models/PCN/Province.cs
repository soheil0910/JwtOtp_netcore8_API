using System.ComponentModel.DataAnnotations;

namespace JwtOtp_netcore8_T2.Models.PCN
{
    public class Province
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    

        public List<City> Cities { get; set; }
    }
}
