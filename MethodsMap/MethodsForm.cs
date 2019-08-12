using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace MethodsMap {
	internal partial class MethodsForm : Form {
		private static readonly MethodInfo MethodInfo_InvokeMethodFast = typeof(RuntimeMethodHandle).GetMethod("InvokeMethodFast", BindingFlags.NonPublic | BindingFlags.Instance);
		private static readonly Type Type_RuntimeMethodInfo = typeof(object).Module.GetType("System.Reflection.RuntimeMethodInfo");
		private static readonly PropertyInfo PropertyInfo_Signature = Type_RuntimeMethodInfo.GetProperty("Signature", BindingFlags.NonPublic | BindingFlags.Instance);
		private static readonly FieldInfo FieldInfo_m_methodAttributes = Type_RuntimeMethodInfo.GetField("m_methodAttributes", BindingFlags.NonPublic | BindingFlags.Instance);

		private readonly Dictionary<ListViewItem, RuntimeMethodHandle> _methodHandles;
		private Module[] _modules;
		private string _keyword;

		public Module[] Modules {
			get => _modules;
			set => _modules = value;
		}

		public string Keyword {
			get => _keyword;
			set => _keyword = value;
		}

		public MethodsForm() {
			_methodHandles = new Dictionary<ListViewItem, RuntimeMethodHandle>();
			_keyword = string.Empty;
			Text = GetTitle();
			InitializeComponent();
			typeof(ListView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, _lvwMethods, new object[] { true });
			_lvwMethods_Resize(_lvwMethods, new EventArgs());
			_modules = new Module[] {
				Assembly.GetEntryAssembly().ManifestModule
			};
			RefreshMethodsList();
		}

		private void _lvwMethods_Resize(object sender, EventArgs e) {
			_chMethodAddress.Width = IntPtr.Size == 8 ? 200 : 100;
			_chMethodHandle.Width = IntPtr.Size == 8 ? 200 : 100;
			_chMethodToken.Width = 100;
			_chMethodFullName.Width = _lvwMethods.Width - _chMethodToken.Width - _chMethodAddress.Width - _chMethodHandle.Width - 17;
		}

		private void _mnuRefresh_Click(object sender, EventArgs e) {
			RefreshMethodsList();
		}

		private void _mnuFilter_Click(object sender, EventArgs e) {
			Module[] _oldModules;

			_oldModules = _modules;
			using (FilterForm form = new FilterForm(this))
				form.ShowDialog();
			if (ReferenceEquals(_oldModules, _modules))
				//操作实际上未执行
				return;
			RefreshMethodsList();
		}

		private void _mnuPrepareMethod_Click(object sender, EventArgs e) {
			if (_lvwMethods.SelectedItems.Count == 0)
				return;

			foreach (ListViewItem item in _lvwMethods.SelectedItems)
				try {
					RuntimeHelpers.PrepareMethod(_methodHandles[item]);
				}
				catch {
				}
			RefreshMethodsList();
		}

		private void _mnuNullInvoke_Click(object sender, EventArgs e) {
			if (_lvwMethods.SelectedItems.Count == 0)
				return;

			foreach (ListViewItem item in _lvwMethods.SelectedItems)
				try {
					RuntimeMethodHandle methodHandle;
					MethodBase methodBase;
					MethodInfo methodInfo;

					methodHandle = _methodHandles[item];
					methodBase = MethodBase.GetMethodFromHandle(methodHandle);
					methodInfo = methodBase as MethodInfo;
					if (methodInfo == null) {
						MessageBox.Show(methodBase.ToString() + " 不是 " + nameof(MethodInfo));
						continue;
					}
					NullInvoke(methodHandle, methodInfo);
				}
				catch {
				}
			RefreshMethodsList();
		}

		private void _mnuCopy_Click(object sender, EventArgs e) {
			if (_lvwMethods.SelectedItems.Count == 0)
				return;

			List<string> strings;
			int maxLength;
			StringBuilder sb;

			strings = new List<string>(_lvwMethods.SelectedItems.Count);
			maxLength = 0;
			foreach (ListViewItem listViewItem in _lvwMethods.SelectedItems) {
				strings.Add(listViewItem.Text);
				if (listViewItem.Text.Length > maxLength)
					maxLength = listViewItem.Text.Length;
			}
			maxLength += 8;
			sb = new StringBuilder();
			for (int i = 0; i < strings.Count; i++) {
				sb.Append(strings[i]);
				sb.Append(' ', maxLength - strings[i].Length);
				sb.Append(_lvwMethods.SelectedItems[i].SubItems[1].Text);
				sb.Append(' ', 4);
				sb.Append(_lvwMethods.SelectedItems[i].SubItems[2].Text);
				sb.Append(' ', 4);
				sb.Append(_lvwMethods.SelectedItems[i].SubItems[3].Text);
				sb.AppendLine();
			}
			Clipboard.Clear();
			Clipboard.SetText(sb.ToString());
			strings.Clear();
		}

		private void RefreshMethodsList() {
			List<ListViewItem> itemList;

			_lvwMethods.Items.Clear();
			_methodHandles.Clear();
			itemList = new List<ListViewItem>();
			foreach (Module module in _modules) {
				for (int i = 0x06000001; i < int.MaxValue; i++) {
					MethodBase methodBase;
					string methodFullName;
					ListViewItem item;

					try {
						methodBase = module.ResolveMethod(i);
					}
					catch (ArgumentOutOfRangeException) {
						break;
					}
					catch {
						item = new ListViewItem("Invalid MethodToken: " + i.ToString("X8"));
						continue;
					}
					if (methodBase.IsGenericMethodDefinition)
						continue;
					methodFullName = methodBase.ToString();
					if (methodBase.DeclaringType != null)
						methodFullName = methodFullName.Insert(methodFullName.IndexOf(' ') + 1, methodBase.DeclaringType.FullName + ".");
					item = new ListViewItem(methodFullName);
					item.SubItems.Add("0x" + i.ToString("X8"));
					item.SubItems.Add("0x" + methodBase.MethodHandle.GetFunctionPointer().ToString(IntPtr.Size == 8 ? "X16" : "X8"));
					item.SubItems.Add("0x" + methodBase.MethodHandle.Value.ToString(IntPtr.Size == 8 ? "X16" : "X8"));
					if (string.IsNullOrEmpty(_keyword))
						itemList.Add(item);
					else
						foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
							if (subItem.Text.Contains(_keyword)) {
								itemList.Add(item);
								break;
							}
					_methodHandles.Add(item, methodBase.MethodHandle);
				}
			}
			_lvwMethods.Items.AddRange(itemList.ToArray());
		}

		private static object NullInvoke(RuntimeMethodHandle methodHandle, MethodInfo methodInfo) {
			object[] parameters;

			parameters = new object[] {
				null,
				new object[methodInfo.GetParameters().Length],
				PropertyInfo_Signature.GetValue(methodInfo, null),
				FieldInfo_m_methodAttributes.GetValue(methodInfo),
				methodInfo.DeclaringType == null ? default : methodInfo.DeclaringType.TypeHandle
			};
			return MethodInfo_InvokeMethodFast.Invoke(methodHandle, parameters);
		}

		private static string GetTitle() {
			string productName;
			string version;
			string copyright;
			int firstBlankIndex;
			string copyrightOwnerName;
			string copyrightYear;

			productName = GetAssemblyAttribute<AssemblyProductAttribute>().Product;
			version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			copyright = GetAssemblyAttribute<AssemblyCopyrightAttribute>().Copyright.Substring(12);
			firstBlankIndex = copyright.IndexOf(' ');
			copyrightOwnerName = copyright.Substring(firstBlankIndex + 1);
			copyrightYear = copyright.Substring(0, firstBlankIndex);
			return $"{productName} v{version} by {copyrightOwnerName} {copyrightYear}";
		}

		private static T GetAssemblyAttribute<T>() {
			return (T)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(T), false)[0];
		}
	}
}
