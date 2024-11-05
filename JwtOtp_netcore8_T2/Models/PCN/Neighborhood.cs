using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtOtp_netcore8_T2.Models.PCN
{
    public class Neighborhood
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]

        public City city { get; set; } 
    }
}
