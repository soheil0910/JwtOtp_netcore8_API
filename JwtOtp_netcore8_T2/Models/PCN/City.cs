using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtOtp_netcore8_T2.Models.PCN
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int provinceId { get; set; }
        [ForeignKey("provinceId")]
        public Province province { get; set; }
        public List<Neighborhood> neighborhood { get; set; }
    }
}
