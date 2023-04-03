using System.Reflection;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
[assembly: AssemblyTitle(Template.BuildInfo.Name)]
[assembly: AssemblyProduct(Template.BuildInfo.GUID)]
[assembly: AssemblyVersion(Template.BuildInfo.Version)]
[assembly: AssemblyCompany("com.github.ljoonal")]
namespace Template
{
	public static class BuildInfo
	{
		public const string Version = "0.0.1";

		public const string Name = "Template Mod";

		public const string Author = "ljoonal";

		public const string Link = "https://github.com/ljoonal/Neos-Mods-Template";

		public const string GUID = "com.github.ljoonal.neos.templatemod";
	}
}
