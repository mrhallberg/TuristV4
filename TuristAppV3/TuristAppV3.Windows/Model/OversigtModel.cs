using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TuristAppV3.Annotations;

namespace TuristAppV3.Model
{
    public class OversigtModel : INotifyPropertyChanged
    {
        private string _title;
        private string _billede;
        private string _tekst;
        private int ID;

        public String Tekst
        {
            get { return _tekst; }
            set { _tekst = value; OnPropertyChanged(); }
        }

        public String Billede
        {
            get { return _billede; }
            set { _billede = value; OnPropertyChanged(); }
        }

        public String Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        public int getID()
        {
            return ID;
        }

        public OversigtModel(string title, string billede, string tekst, int id)
        {
            _title = title;
            _billede = billede;
            _tekst = tekst;
            ID = id;
        }

        public override string ToString()
        {
            return _title;
        }

        public void SetValues(string title, string billede, string tekst, int id)
        {
            Tekst = tekst;
            Title = title;
            Billede = billede;
            ID = id;
        }

        #region propertychanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
