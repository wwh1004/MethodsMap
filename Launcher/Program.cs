using System;
using MethodsMap;

namespace Launcher {
	internal static class Program {
		[STAThread]
		private static void Main(string[] args) => InjectingLauncher.Launch(null);
	}
}
