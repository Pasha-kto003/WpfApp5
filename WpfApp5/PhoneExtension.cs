using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace WpfApp5
{
    public static class PhoneExtension
    {
        
        static DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Phone));

        public static void SaveJson(this Phone phone)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "DB");
            if (phone.ID == 0)
                phone.ID = DateTime.Now.Ticks;
            //int countFiles = Directory.GetFiles(path).Length;
            using (var file = File.Create(Path.Combine(path, $"{phone.ID}.phone"))) //{countFiles}
            {
                json.WriteObject(file, phone);
            }
        }
        public static void DeleteJson(this Phone phone)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "DB");

            if (File.Exists(Path.Combine(path, $"{ phone.ID}.phone")))
                File.Delete(Path.Combine(path, $"{ phone.ID}.phone"));
        }
    }
}
