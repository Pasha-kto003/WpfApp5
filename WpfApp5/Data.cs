using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace WpfApp5
{
    internal class Data
    {
        static List<Phone> phones = new List<Phone>();

        static Data()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "DB");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Phone));
            var files = Directory.GetFiles(path);
                foreach(var file in files)
                if (file.EndsWith(".phone"))
                    using (var fs = File.Open(file, FileMode.Open, FileAccess.ReadWrite))
                    {
                        var phone = (Phone)json.ReadObject(fs);
                        phones.Add(phone);
                    }
        }

        internal static ObservableCollection<Phone> GetAllPhones()
        {
            return new ObservableCollection<Phone>(phones);
        }

        internal static void FillResultsBySearch(ObservableCollection<Phone> results, string searchText)
        {
            if (searchText.Length < 3)
                return;
            results.Clear();
            var temp = phones.Where(s => s.Number.Contains(searchText) || s.Owner.Contains(searchText));
            foreach (var item in temp)
                results.Add(item);
        }

        internal static Phone CreateNewPhone()
        {
            var p = new Phone();
            phones.Add(p);
            return p;
        }

        internal static void RemovePhone(Phone selectedPhone)
        {
            phones.Remove(selectedPhone);
            selectedPhone.DeleteJson();
        }
    }
}