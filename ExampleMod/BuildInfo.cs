using System.Reflection;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
[assembly: AssemblyTitle(Example.BuildInfo.Name)]
[assembly: AssemblyProduct(Example.BuildInfo.GUID)]
[assembly: AssemblyVersion(Example.BuildInfo.Version)]
[assembly: AssemblyCompany("com.github.ljoonal")]
namespace Example
{
	public static class BuildInfo
	{
		public const string Version = "0.0.1";

		public const string Name = "Example Mod";

		public const string Author = "ljoonal";

		public const string Link = "https://github.com/ljoonal/Neos-Mods-Template";

		public const string GUID = "com.github.ljoonal.neos.examplemod";
	}
}
