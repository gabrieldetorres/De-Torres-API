using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OvertimeDL
{
    public class JsonClass
    {
        private List<OvetimeClass3> ov = new List<OvetimeClass3>();

        private string _jsonFileName;

        public JsonClass()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Jsonfile.json";

            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (ov.Count <= 0)
            {
                ov.Add(new OvetimeClass3 { Id = 100, Name = "Gab", TimeIn = TimeSpan.FromHours(9), Timeout = TimeSpan.FromHours(17)
                });
              

                SaveDataToJsonFile();
            }
        }

        private void SaveDataToJsonFile()
        {
            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<OvetimeClass3>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , ov);
            }
        }

        private void RetrieveDataFromJsonFile()
        {
            using (var jsonFileReader = File.OpenText(this._jsonFileName))
            {
                this.ov = JsonSerializer.Deserialize<List<OvetimeClass3>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }

        public void Add(OvetimeClass3 overtime)
        {
            ov.Add(overtime);
            SaveDataToJsonFile();
        }

        public List<OvetimeClass3> GetTime()
        {
            RetrieveDataFromJsonFile();
            return ov;
        }
    }
}
