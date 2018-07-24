using System.Windows.Forms;

namespace MethodsMap {
	public static class InjectingLauncher {
		public static int Launch(string arg) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MethodsForm());
			return 1;
		}
	}
}
