using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.UI.Xaml.Controls.Primitives;
using TuristAppV3.Annotations;
using TuristAppV3.Model;

namespace TuristAppV3.ViewModel
{
    public class OversigtViewModel : INotifyPropertyChanged
    {
        public static ObservableCollection<OversigtModel> Kategorier { get; set; }
        public static string Language = "Danish";
        public static OversigtModel Default = new OversigtModel("", "", "", 99);

        public static OversigtModel _selectedOversigt;

        public OversigtModel SelectedOversigt
        {
            get { return _selectedOversigt; }
            set { _selectedOversigt = value; OnPropertyChanged();}
        }

        public OversigtViewModel()
        {
            SelectedOversigt = Default;
            Kategorier = new ObservableCollection<OversigtModel>();
            LoadXml();
        }

        public void LoadXml()
        {
            var doc = XDocument.Load(GetXmlPath() + "/Oversigt.xml");
            Kategorier.Clear();
            foreach (var k in doc.Descendants("kategori"))
            {
                Kategorier.Add(new OversigtModel(k.Element("title").Value, k.Element("image").Value,
                    k.Element("text").Value, Convert.ToInt16(k.Element("id").Value)));
            }
        }

        public void ChangeLanguage()
        {
            var doc = XDocument.Load(GetXmlPath() + "/Oversigt.xml");
            var i = 0;
            foreach (var k in doc.Descendants("kategori"))
            {
                Kategorier[i].SetValues(k.Element("title").Value, k.Element("image").Value, k.Element("text").Value, Convert.ToInt16(k.Element("id").Value));
                i++;
            }
        }

        public static string GetXmlPath()
        {
            return "XML/" + Language;
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
