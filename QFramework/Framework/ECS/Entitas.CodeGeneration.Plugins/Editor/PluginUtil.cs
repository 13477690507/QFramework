using System;
using Entitas.CodeGeneration.CodeGenerator;
using System.Collections.Generic;
using Entitas.Utils;
using QFramework;

namespace Entitas.CodeGeneration.Plugins
{
    public static class PluginUtil
    {
        static Dictionary<string, AssemblyResolver> mResolvers = new Dictionary<string, AssemblyResolver>();

        public static AssemblyResolver GetAssembliesResolver(string[] assemblies, string[] basePaths)
        {
            var key = assemblies.ToCSV();
            if (!mResolvers.ContainsKey(key))
            {
                var resolver = new AssemblyResolver(AppDomain.CurrentDomain, basePaths);
//                foreach (var path in assemblies)
//                {
//                    resolver.Load(path);
//                }
                resolver.LoadUnityAssemblies();
                mResolvers.Add(key, resolver);
            }

            return mResolvers[key];
        }
    }
}