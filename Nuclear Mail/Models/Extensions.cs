using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Xml;

namespace Nuclear_Mail.Models
{
    public static class Extensions
    {
        public static UIElement CloneViaXamlSerialization(this UIElement orig)
        {
            if (orig == null) return null;

            string s = XamlWriter.Save(orig);
            StringReader stringReader = new StringReader(s);
            XmlReader xmlReader = XmlTextReader.Create(stringReader);
            return (UIElement)XamlReader.Load(xmlReader);
        }
    }
}
