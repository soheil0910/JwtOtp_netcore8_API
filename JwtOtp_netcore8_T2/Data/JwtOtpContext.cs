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


        #region Code JAvaScript Divar Gereftan Data Shahr ha
        /*
        let items = document.querySelectorAll('.kt-control-row');
let data = [];

items.forEach(item => {
    let title = item.querySelector('p.kt-control-row__title');
    let description = item.querySelector('div.kt-base-row__description');
    
    data.push({
        title: title ? title.innerText : null,
        description: description ? description.innerText : null
    });
});

// تبدیل داده‌ها به فرمت JSON
let jsonData = JSON.stringify(data, null, 2);

// ایجاد یک عنصر لینک برای دانلود فایل
let downloadLink = document.createElement('a');
downloadLink.href = URL.createObjectURL(new Blob([jsonData], { type: 'application/json' }));
downloadLink.download = 'data.json';

// اضافه کردن لینک به صفحه و کلیک خودکار برای شروع دانلود
document.body.appendChild(downloadLink);
downloadLink.click();
document.body.removeChild(downloadLink);





برای اون فایل شهر هاست باید اسکرول رو خراب کرد
نال پزیر و تبق گفته ها همه چیش اوکی 

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////از هم دیگه جداست

برای اسکرول صفحه ام از این کد استفاده میکنیم

let previousItems = [];

async function autoScroll(element) {
    return new Promise((resolve) => {
        let totalHeight = 0;
        let distance = 100;
        let timer = setInterval(() => {
            element.scrollBy(0, distance);
            totalHeight += distance;

            if (totalHeight >= element.scrollHeight - element.clientHeight) {
                clearInterval(timer);
                resolve();
            }
        }, 100);
    });
}

async function getAllItems() {
    let listElement = document.querySelector('.multi-select-modal__scroll'); // اینجا کلاس المان لیست خود را جایگزین کنید
    await autoScroll(listElement);

    let items = listElement.querySelectorAll('p.kt-control-row__title');
    let values = Array.from(items).map(item => item.innerText);
   
    // اضافه کردن آیتم‌های جدید به آرایه‌ی قبلی
    previousItems = [...previousItems, ...values];

    displayItems(previousItems); // نمایش تمام آیتم‌ها
}

function displayItems(items) {
    console.log("All Items:", items);
}

// فراخوانی تابع برای واکشی همه آیتم‌ها
getAllItems();




///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////همه استان ها رو میده




let items = document.querySelectorAll('.kt-selector-row');
let result = [];

items.forEach(item => {
    let title = item.querySelector('.kt-selector-row__title').innerText;
    result.push({ value: title });
});

let json = JSON.stringify(result, null, 2);
let blob = new Blob([json], { type: 'application/json' });
let url = URL.createObjectURL(blob);
let link = document.createElement('a');
link.href = url;
link.download = 'data.json';
link.click();
URL.revokeObjectURL(url);




        */
        #endregion


    }


}

