using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TuristAppV3.Annotations;
using TuristAppV3.Model;
using TuristAppV3.View;

namespace TuristAppV3.ViewModel
{
    class DetailViewModel : INotifyPropertyChanged
    {
        public static ObservableCollection<DetailModel> details { get; set; }
        public static DetailModel _selectedDetail;
        public static DetailModel Default = new DetailModel("","","","",99,"","");

        public DetailViewModel()
        {
            details = new ObservableCollection<DetailModel>();
            LoadXml();
        }

        public DetailModel SelectedDetail
        {
            get { return _selectedDetail; }
            set { _selectedDetail = value; OnPropertyChanged(); }
        }

        public String HomePage
        {
            get { return OversigtViewModel.Language.Equals("Danish") ? "Besøg Hjemmeside" : "Visit Website";}
        }
        public void LoadXml()
        {
            var doc = XDocument.Load(OversigtViewModel.GetXmlPath() + "/Detaljer.xml");
            details.Clear();
            foreach (var k in doc.Descendants("item"))
            {
                if (Convert.ToInt16(k.Element("oversigt").Value) == OversigtViewModel._selectedOversigt.getID())
                {
                    var openList = k.Element("openTitle").Value + "\n";
                    foreach (var e in k.Descendants("open"))
                    {
                        var s = "\t";
                        if (e.Element("dag").Value.Count() < 8)
                        {
                            s += "\t";
                        }
                        openList += e.Element("dag").Value + s + e.Element("tid").Value + "\n";
                    }
                    var phoneList = k.Element("phoneTitle").Value + "\n";
                    foreach (var e in k.Descendants("phone"))
                    {
                        var s = "\t";
                        if (e.Element("phoneName").Value.Count() < 6)
                        {
                            s += "\t";
                        }
                        phoneList += e.Element("phoneName").Value + s + e.Element("phoneNumber").Value + "\n";
                    }
                    details.Add(new DetailModel(k.Element("title").Value, k.Element("text").Value, k.Element("image").Value, k.Element("link").Value, Convert.ToInt16(k.Element("oversigt").Value), phoneList, openList));
                }
            }
        }

        public void ChangeLanguage()
        {
            var doc = XDocument.Load(OversigtViewModel.GetXmlPath() + "/Detaljer.xml");
            var i = 0;
            foreach (var k in doc.Descendants("item"))
            {
                if (Convert.ToInt16(k.Element("oversigt").Value) == OversigtViewModel._selectedOversigt.getID())
                {
                    var openList = k.Element("openTitle").Value + "\n";
                    foreach (var e in k.Descendants("open"))
                    {
                        var s = "\t";
                        if (e.Element("dag").Value.Count() < 8)
                        {
                            s += "\t";
                        }
                        openList += e.Element("dag").Value + s + e.Element("tid").Value + "\n";
                    }
                    var phoneList = k.Element("phoneTitle").Value + "\n";
                    foreach (var e in k.Descendants("phone"))
                    {
                        var s = "\t";
                        if (e.Element("phoneName").Value.Count() < 6)
                        {
                            s += "\t";
                        }
                        phoneList += e.Element("phoneName").Value + s + e.Element("phoneNumber").Value + "\n";
                    }
                    details[i].SetValues(k.Element("title").Value, k.Element("text").Value, k.Element("image").Value, k.Element("link").Value,
                        Convert.ToInt16(k.Element("oversigt").Value), phoneList, openList);
                    i++;
                }
            }
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
