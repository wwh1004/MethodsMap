using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace MethodsMap {
	internal partial class FilterForm : Form {
		private readonly MethodsForm _methodsForm;

		private Dictionary<ListViewItem, Module> _modulesDictionary;

		public FilterForm(MethodsForm methodsForm) {
			if (methodsForm == null)
				throw new ArgumentNullException(nameof(methodsForm));

			_methodsForm = methodsForm;
			_modulesDictionary = new Dictionary<ListViewItem, Module>();
			_methodsForm.Keyword = string.Empty;
			InitializeComponent();
		}

		private void FilterForm_Load(object sender, EventArgs e) {
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
				foreach (Module module in assembly.GetModules()) {
					ListViewItem listViewItem;

					listViewItem = new ListViewItem(module.ScopeName);
					_modulesDictionary.Add(listViewItem, module);
					_lvwModules.Items.Add(listViewItem);
				}
		}

		private void _tbSearchText_TextChanged(object sender, EventArgs e) => _methodsForm.Keyword = _tbSearchText.Text;

		private void _btnCancel_Click(object sender, EventArgs e) {
			_modulesDictionary = null;
			Dispose();
		}

		private void _btnOK_Click(object sender, EventArgs e) {
			List<Module> moduleList;

			moduleList = new List<Module>();
			foreach (ListViewItem item in _lvwModules.CheckedItems)
				if (item.Checked)
					moduleList.Add(_modulesDictionary[item]);
			_methodsForm.Modules = moduleList.ToArray();
			_modulesDictionary = null;
			Dispose();
		}
	}
}
