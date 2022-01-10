using System;
using System.IO;

namespace Nez.Systems
{
    /// <summary>
    /// the only difference between this class and NezContentManager is that this one can load embedded resources from the Nez.dll
    /// </summary>
    sealed class NezGlobalContentManager : NezContentManager
    {
        public NezGlobalContentManager(IServiceProvider serviceProvider, string rootDirectory) : base(serviceProvider, rootDirectory)
        {}

        /// <summary>
        /// override that will load embedded resources if they have the "nez://" prefix
        /// </summary>
        /// <returns>The stream.</returns>
        /// <param name="assetName">Asset name.</param>
        protected override Stream OpenStream(string assetName)
        {
            if (assetName.StartsWith("nez://"))
            {
                var assembly = GetType().Assembly;

#if FNA
				// for FNA, we will just search for the file by name since the assembly name will not be known at runtime
				foreach (var item in assembly.GetManifestResourceNames())
				{
					if (item.EndsWith(assetName.Substring(assetName.Length - 20)))
					{
						assetName = "nez://" + item;
						break;
					}
				}
#endif
                return assembly.GetManifestResourceStream(assetName.Substring(6));
            }

            return base.OpenStream(assetName);
        }
    }
}