using JwtOtp_netcore8_T2.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtOtp_netcore8_T2.Data
{
    public class JwtOtpContext : DbContext
    {

        public JwtOtpContext(DbContextOptions<JwtOtpContext> options) : base(options)
        {

        }

        public DbSet<JwtToken> JwtToken { get; set; }
        public DbSet<Users> Users { get; set; }
        //public DbSet<OTPCode> OTPCode { get; set; }
        //public DbSet<JwtToken> JwtToken { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Users>()
        //        .HasData(
        //        new Users()
        //        {
        //            Id = 1,
        //            Name = "soheil",
        //            Email = "soheil0910line@gmail.com",
        //            phone_number = "09106778366",
        //            status = true,

        //        });



        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
