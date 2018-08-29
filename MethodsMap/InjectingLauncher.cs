using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace MethodsMap {
	public static class InjectingLauncher {
		public static int Launch(string arg) {
			Module module;

			module = Assembly.GetExecutingAssembly().ManifestModule;
			for (int i = 0x06000001; i < int.MaxValue; i++) {
				MethodBase methodBase;

				try {
					methodBase = module.ResolveMethod(i);
				}
				catch (ArgumentOutOfRangeException) {
					// 遍历完所有方法
					break;
				}
				catch {
					continue;
				}
				if (methodBase.IsGenericMethodDefinition)
					continue;
				RuntimeHelpers.PrepareMethod(methodBase.MethodHandle);
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MethodsForm());
			return 1;
		}
	}
}
