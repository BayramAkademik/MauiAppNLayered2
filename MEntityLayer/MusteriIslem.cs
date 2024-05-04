using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MEntityLayer
{
    public class MusteriIslem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        string mid, id, detay;
        double tutar;

        public string ID
        {
            get
            {
                if (id == null)
                    id = Guid.NewGuid().ToString();
                return id;
            }
            set { id = value; }
        }

        public string MusteriID
        {
            get=> mid;
            set => mid = value;
        }

        public string Detay
        {
            get => detay;
            set
            {
                detay = value;
                NotifyPropertyChanged();
            }
        }

        public double Tutar
        {
            get => tutar;
            set
            {
                tutar = value;
                NotifyPropertyChanged();
            }
        }
    }
}
