using JwtOtp_netcore8_T2.Data;
using JwtOtp_netcore8_T2.Models;
using JwtOtp_netcore8_T2.Models.PCN;
using System.Text.Json;

namespace JwtOtp_netcore8_T2.Seed_Data
{
    public class seedData
    {
       


        public List<City> listCity { get; set; }


        

        public static seedData _seedData { get; set; } = new seedData();




        //public List<City> SeedDataCity()
        //{
        //    int idsum = 0;
        //    var list = new List<City>();

        //    var DataJson = File.ReadAllText("Seed Data/Ostan/همه استان ها.json");
        //    var data = JsonSerializer.Deserialize<List<JsonOstanDto>>(DataJson);
        //    for (int i = 0; i < data.Count; i++)
        //    {
        //        idsum++;
        //        list.Add(new City
        //        {
        //            Id = idsum,
        //            Name = data[i].value,
        //            provinceId = 1,
        //        });
        //    }

        //    return list;

        //}


        //public seedData()
        //{

        //}


        public seedData()
        {
            
            int idsum = 0;
            var list = new List<City>();
            //var ProvincAll = _context.Province.ToList();

            var DataJson = File.ReadAllText("Seed Data/Ostan/همه استان ها.json");
            var data = JsonSerializer.Deserialize<List<JsonOstanDto>>(DataJson);


            for (int i = 0; i < data.Count; i++)
            {
                idsum++;
                list.Add(new City
                {
                    Id = idsum,
                    Name = data[i].value,
                    provinceId = 1,
                });
            }





            string folderPath = "Seed Data/Ostan";

            // دریافت نام همه فایل‌های موجود در پوشه
            string[] fileNames = Directory.GetFiles(folderPath);

            // اگر فقط نام فایل‌ها (بدون مسیر کامل) را می‌خواهید
            for (int i = 0; i < fileNames.Length; i++)
            {
                fileNames[i] = Path.GetFileName(fileNames[i]);
            }
            List<string> fileNamesx = Directory.GetFiles(folderPath).Select(Path.GetFileName).ToList();

            List<string> fileNamesz = Directory.GetFiles(folderPath)
                                  .Select(Path.GetFileNameWithoutExtension)
                                  .ToList();

            var x = 1;
            //return list;

        }

    }
}
