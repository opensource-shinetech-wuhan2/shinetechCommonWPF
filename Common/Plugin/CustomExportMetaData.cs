using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Plugin
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class,AllowMultiple =false,Inherited =false)]
    public class CustomExportMetaData :ExportAttribute,IMetaData
    {
        public string Name { get; private set; }

        public string Author { get; private set; }

        public string Desc { get; private set; }

        public string Version { get; private set; }

        public CustomExportMetaData (string name)
        {
            Name = name;
        }

        public CustomExportMetaData (string name,string desc) : this(name)
        {
            Desc = desc;
        }

        public CustomExportMetaData (string name,string desc,string author) : this(name,desc)
        {
            Author = author;
        }

        public CustomExportMetaData (string name,string desc,string author,string version) : this(name,desc,author)
        {
            Version = version;
        }
    }
}
