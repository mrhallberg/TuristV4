using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TuristAppV3.Annotations;

namespace TuristAppV3.Model
{
    class DetailModel : INotifyPropertyChanged
    {
        private string _title;
        private string _beskrivelse;
        private string _billede;
        private string _link;
        private int _oversigt;
        private string _tlf;
        private string _aabningstider;


        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        public string Beskrivelse
        {
            get { return _beskrivelse; }
            set { _beskrivelse = value; OnPropertyChanged(); }
        }

        public string Billede
        {
            get { return _billede; }
            set { _billede = value; OnPropertyChanged(); }
        }

        public string Link
        {
            get { return _link; }
            set { _link = value; OnPropertyChanged(); }
        }

        public int Oversigt
        {
            get { return _oversigt; }
            set { _oversigt = value; OnPropertyChanged(); }
        }

        public string Tlf
        {
            get { return _tlf; }
            set { _tlf = value; OnPropertyChanged(); }
        }

        public string Aabningstider
        {
            get { return _aabningstider; }
            set { _aabningstider = value; OnPropertyChanged(); }
        }

        public DetailModel(string title, string beskrivelse, string billede, string link, int oversigt, string tlf, string aabningstider)
        {
            _title = title;
            _beskrivelse = beskrivelse;
            _billede = billede;
            _link = link;
            _oversigt = oversigt;
            _tlf = tlf;
            _aabningstider = aabningstider;
        }

        public void SetValues(string title, string beskrivelse, string billede, string link, int oversigt, string tlf, string aabningstider)
        {
            Title = title;
            Beskrivelse = beskrivelse;
            Billede = billede;
            Link = link;
            Oversigt = oversigt;
            Tlf = tlf;
            Aabningstider = aabningstider;
        }

        #region 

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
