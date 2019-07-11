using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Plugin
{
    public interface IMetaData
    {
        string Name { get; }
        string Author { get; }
        string Desc { get; }
        string Version { get; }
    }
}
