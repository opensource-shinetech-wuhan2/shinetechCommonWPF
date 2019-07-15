using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
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
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var pluginsPath = Path.Combine(dir,"plugins");
            if(!Directory.Exists(pluginsPath))
                Directory.CreateDirectory(pluginsPath);

            var catalog = new DirectoryCatalog(pluginsPath,"*.dll");
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
