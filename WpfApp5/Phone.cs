using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp5
{
    public class Phone : INotifyPropertyChanged
    {
        private string number;
        private string owner;

        public string Number { get => number; set { number = value; Signal(); } }
        public string Owner { get => owner; set { owner = value; Signal(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        void Signal([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));


    }
}