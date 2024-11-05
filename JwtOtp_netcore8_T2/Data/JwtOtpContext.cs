using JwtOtp_netcore8_T2.Models;
using JwtOtp_netcore8_T2.Models.PCN;
using JwtOtp_netcore8_T2.Repositories;
using JwtOtp_netcore8_T2.Seed_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Text.Json;

namespace JwtOtp_netcore8_T2.Data
{
    public class JwtOtpContext : DbContext
    {

        

        public JwtOtpContext(DbContextOptions<JwtOtpContext> options) : base(options)
        {
          
        }

        public DbSet<JwtToken> JwtToken { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Neighborhood> Neighborhood { get; set; }
        public DbSet<Province> Province { get; set; }








        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Province>().HasData(SeedDataProvince());
            modelBuilder.Entity<City>().HasData(SeedDataCity());
            modelBuilder.Entity<Neighborhood>().HasData(SeedDataNeighborhood());

            base.OnModelCreating(modelBuilder);
        }

        #region SeedData

        
        public List<Province> SeedDataProvince()
        {
            int idsum = 0;
            var list = new List<Province>();

            var DataJson = File.ReadAllText("Seed Data/همه استان ها.json");
            var data = JsonSerializer.Deserialize<List<JsonOstanDto>>(DataJson);
            for (int i = 0; i < data.Count; i++)
            {
                idsum++;
                list.Add(new Province
                {
                    Id = idsum,
                    Name = data[i].value,
                });
            }



            return list;

        }



        public List<City> SeedDataCity()
        {
           
            int idsumCity = 0;
            var listCity = new List<City>();
            var DataJson = System.IO.File.ReadAllText("Seed Data/همه استان ها.json");
            var data = JsonSerializer.Deserialize<List<JsonOstanDto>>(DataJson);
            for (int x = 0; x < data.Count; x++)
            {
                string folderPath = "Seed Data/Ostan/" + data[x].value + ".json";
                if (System.IO.File.Exists(folderPath))
                {
                    var DataJsonCity = System.IO.File.ReadAllText(folderPath);
                    var dataCity = JsonSerializer.Deserialize<List<JsonOstanDto>>(DataJsonCity);


                    for (int i = 0; i < dataCity.Count; i++)
                    {
                        idsumCity++;
                        listCity.Add(new City
                        {
                            Id = idsumCity,
                            Name = dataCity[i].value,
                            provinceId = x + 1,
                        });
                    }
                }
            }


            return listCity;

        }






        
        public List<Neighborhood> SeedDataNeighborhood()
        {
            int idsum = 0;
            var list = new List<Neighborhood>();

            var DataJson = File.ReadAllText("Seed Data/تهران.json");
            var data = JsonSerializer.Deserialize<List<JsonDto>>(DataJson);
            for (int i = 0; i < data.Count; i++)
            {
                idsum++;
                list.Add(new Neighborhood
                {
                    Id = idsum,
                    Name = data[i].title,
                    Description = data[i].description,
                    CityId = 71,

                });
            }



            DataJson = File.ReadAllText("Seed Data/مشهد.json");
            data = JsonSerializer.Deserialize<List<JsonDto>>(DataJson);
            for (int i = 0; i < data.Count; i++)
            {
                idsum++;
                list.Add(new Neighborhood
                {
                    Id = idsum,
                    Name = data[i].title,
                    Description = data[i].description,
                    CityId = 115,

                });
            }





            DataJson = File.ReadAllText("Seed Data/کرج.json");
            data = JsonSerializer.Deserialize<List<JsonDto>>(DataJson);
            for (int i = 0; i < data.Count; i++)
            {
                idsum++;
                list.Add(new Neighborhood
                {
                    Id = idsum,
                    Name = data[i].title,
                    Description = data[i].description,
                    CityId = 46,

                });
            }




            DataJson = File.ReadAllText("Seed Data/اهواز.json");
            data = JsonSerializer.Deserialize<List<JsonDto>>(DataJson);
            for (int i = 0; i < data.Count; i++)
            {
                idsum++;
                list.Add(new Neighborhood
                {
                    Id = idsum,
                    Name = data[i].title,
                    Description = data[i].description,
                    CityId = 135,

                });
            }



            DataJson = File.ReadAllText("Seed Data/شیراز.json");
            data = JsonSerializer.Deserialize<List<JsonDto>>(DataJson);
            for (int i = 0; i < data.Count; i++)
            {
                idsum++;
                list.Add(new Neighborhood
                {
                    Id = idsum,
                    Name = data[i].title,
                    Description = data[i].description,
                    CityId = 171,

                });
            }



            DataJson = File.ReadAllText("Seed Data/رشت.json");
            data = JsonSerializer.Deserialize<List<JsonDto>>(DataJson);
            for (int i = 0; i < data.Count; i++)
            {
                idsum++;
                list.Add(new Neighborhood
                {
                    Id = idsum,
                    Name = data[i].title,
                    Description = data[i].description,
                    CityId = 265,

                });
            }




            DataJson = File.ReadAllText("Seed Data/اصفهان.json");
            data = JsonSerializer.Deserialize<List<JsonDto>>(DataJson);
            for (int i = 0; i < data.Count; i++)
            {
                idsum++;
                list.Add(new Neighborhood
                {
                    Id = idsum,
                    Name = data[i].title,
                    Description = data[i].description,
                    CityId = 29,

                });
            }






            DataJson = File.ReadAllText("Seed Data/قم.json");
            data = JsonSerializer.Deserialize<List<JsonDto>>(DataJson);
            for (int i = 0; i < data.Count; i++)
            {
                idsum++;
                list.Add(new Neighborhood
                {
                    Id = idsum,
                    Name = data[i].title,
                    Description = data[i].description,
                    CityId = 195,

                });
            }


            return list;
        }

        #endregion


    }


}

