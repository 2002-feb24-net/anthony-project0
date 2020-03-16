using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project0.Library
{
    class Serialization
    {
        string UserFilePath = "../../../User_Data.json";
        string StoreFilePath = "../../../Store_Data.json";
        string ProductFilePath = "../../../Product_Data.json";

        List<Person> data = null;

        private async static Task<string> ReadFromJSON(string filePath)
        {
            using var sr = new StreamReader(filePath);
            Task<string> textTask = sr.ReadToEndAsync();
            string text = await textTask;
            return text;

        }

        private async static Task WriteFileJSON(string text,  string path)
        {
            FileStream file = null;
            file = new FileStream(path, FileMode.Create);
            byte[] data = Encoding.UTF8.GetBytes(text);
            await file.WriteAsync(data);
        }

        static string ConvertUserToJSON(List<Person> data)
        {
            return JsonSerializer.Serialize(data);
        }

        static string ConvertStoreToJSON(List<Store> data)
        {
            return JsonSerializer.Serialize(data);
        }
    }
}