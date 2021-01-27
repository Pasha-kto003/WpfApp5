using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfApp5
{
    internal class Data
    {
        static List<Phone> phones = new List<Phone>();

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
        }
    }
}