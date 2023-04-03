using System.Reflection;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
[assembly: AssemblyTitle(CloudChange.BuildInfo.Name)]
[assembly: AssemblyProduct(CloudChange.BuildInfo.GUID)]
[assembly: AssemblyVersion(CloudChange.BuildInfo.Version)]
[assembly: AssemblyCompany("net.lexevo")]
namespace CloudChange
{
	public static class BuildInfo
	{
		public const string Version = "1.0.0";

		public const string Name = "Cloud Change";

		public const string Author = "Lexevo";

		public const string Link = "https://github.com/Lexevolution/Cloud-Change";

		public const string GUID = "net.lexevo.cloudchange";
	}
}
