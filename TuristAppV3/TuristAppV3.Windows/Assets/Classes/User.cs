using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using Windows.Data.Xml.Dom;
using Windows.Security.Authentication.OnlineId;
using Windows.Storage;

namespace TuristAppV3
{
    static class User
    {
        public static Boolean loggedIn = false;
        public static Dictionary<string, string> users;  

        static User()
        {
            users = new Dictionary<string, string>();
        }

        public static Boolean Login(string user, string password)
        {
            if (!CheckLogin(user, password)) return false;
            loggedIn = true;
            return true;
        }

        private static bool CheckLogin(string user, string password)
        {
            var doc = XDocument.Load("XML/Users.xml");
            return doc.Descendants("user").Any(e => e.Element("name").Value == user && e.Element("password").Value == password) || users.Any(u => u.Key == user && u.Value == password);
        }

        private static bool CheckForName(string user)
        {
            var doc = XDocument.Load("XML/Users.xml");
            return doc.Descendants("user").Any(e => e.Element("name").Value == user) || users.Any(u => u.Key == user);
        }

        public static Boolean CreateUser(string user, string password)
        {
            if (CheckForName(user)) return false;
            users.Add(user, password);
            return true;
        }
    }
}
