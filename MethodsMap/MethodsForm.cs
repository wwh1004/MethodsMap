using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace MethodsMap {
	internal partial class MethodsForm : Form {

		private Module[] _modules;

		private string _keyword;

		private Dictionary<ListViewItem, RuntimeMethodHandle> _methodHandlesMap;

		public Module[] Modules {
			get => _modules;
			set => _modules = value;
		}

		public string Keyword {
			get => _keyword;
			set => _keyword = value;
		}

		public MethodsForm() {
			_modules = new Module[0];
			_keyword = string.Empty;
			_methodHandlesMap = new Dictionary<ListViewItem, RuntimeMethodHandle>();
			Text = GetAssemblyAttribute<AssemblyProductAttribute>().Product + " v" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " by " + GetAssemblyAttribute<AssemblyCopyrightAttribute>().Copyright.Substring(17);
			InitializeComponent();
			_lvwMethods_Resize(_lvwMethods, new EventArgs());
		}

		private static T GetAssemblyAttribute<T>() => (T)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(T), false)[0];

		private void _lvwMethods_Resize(object sender, EventArgs e) {
			_chMethodAddress.Width = IntPtr.Size == 8 ? 200 : 100;
			_chMethodToken.Width = 100;
			_chMethodFullName.Width = _lvwMethods.Width - _chMethodToken.Width - _chMethodAddress.Width - 17;
		}

		private void _mnuRefresh_Click(object sender, EventArgs e) => RefreshMethodsList();

		private void _mnuFilter_Click(object sender, EventArgs e) {
			Module[] _oldModules;

			_oldModules = _modules;
			new FilterForm(this).ShowDialog();
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
					RuntimeHelpers.PrepareMethod(_methodHandlesMap[item]);
				}
				catch {
				}
			RefreshMethodsList();
		}

		private void _mnuCopy_Click(object sender, EventArgs e) {
			if (_lvwMethods.SelectedItems.Count == 0)
				return;

			List<string> stringList;
			int maxLength;
			StringBuilder builder;

			stringList = new List<string>(_lvwMethods.SelectedItems.Count);
			maxLength = 0;
			foreach (ListViewItem listViewItem in _lvwMethods.SelectedItems) {
				stringList.Add(listViewItem.Text);
				if (listViewItem.Text.Length > maxLength)
					maxLength = listViewItem.Text.Length;
			}
			maxLength += 8;
			builder = new StringBuilder();
			for (int i = 0; i < stringList.Count; i++) {
				builder.Append(stringList[i]);
				builder.Append(' ', maxLength - stringList[i].Length);
				builder.Append(_lvwMethods.SelectedItems[i].SubItems[1].Text);
				builder.Append(' ', 4);
				builder.Append(_lvwMethods.SelectedItems[i].SubItems[2].Text);
				builder.AppendLine();
			}
			Clipboard.Clear();
			Clipboard.SetText(builder.ToString());
			stringList.Clear();
			builder = null;
		}

		private void RefreshMethodsList() {
			List<ListViewItem> itemList;

			_lvwMethods.Items.Clear();
			_methodHandlesMap.Clear();
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
						// 遍历完所有方法
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
					if (string.IsNullOrEmpty(_keyword))
						itemList.Add(item);
					else
						foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
							if (subItem.Text.Contains(_keyword)) {
								itemList.Add(item);
								break;
							}
					_methodHandlesMap.Add(item, methodBase.MethodHandle);
				}
			}
			_lvwMethods.Items.AddRange(itemList.ToArray());
		}
	}
}
