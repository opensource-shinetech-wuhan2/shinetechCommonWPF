using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Plugin
{
    /// <summary>
    /// Plugin Manager
    /// </summary>
    /// <typeparam name="T">Plugin Type</typeparam>
    public static class PluginManager
    {
        private static readonly CompositionContainer container = null;

        static PluginManager ()
        {
            var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var catalog = new DirectoryCatalog(dir.FullName,"*.dll");
            container = new CompositionContainer(catalog);
        }

        /// <summary>
        /// load plugins immediately
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> LoadPlugins<T>()
        {
            container.ComposeParts();
            IEnumerable<T> plugins = container.GetExportedValues<T>();
            return plugins;
        }

        /// <summary>
        /// lazy load plugins
        /// </summary>
        /// <param name="attributedParts"></param>
        public static void LoadPluginsLazy (params object[] attributedParts)
        {
            container.ComposeParts(attributedParts);
        }
    }
}
