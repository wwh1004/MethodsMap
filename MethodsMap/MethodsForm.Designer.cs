namespace MethodsMap {
	partial class MethodsForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MethodsForm));
            this._lvwMethods = new System.Windows.Forms.ListView();
            this._chMethodFullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._chMethodToken = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._chMethodAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._mnuMethodsContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuFilter = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuPrepareMethod = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._mnuMethodsContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // _lvwMethods
            // 
            this._lvwMethods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._lvwMethods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._chMethodFullName,
            this._chMethodToken,
            this._chMethodAddress});
            this._lvwMethods.ContextMenuStrip = this._mnuMethodsContext;
            this._lvwMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lvwMethods.FullRowSelect = true;
            this._lvwMethods.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._lvwMethods.Location = new System.Drawing.Point(0, 0);
            this._lvwMethods.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._lvwMethods.Name = "_lvwMethods";
            this._lvwMethods.Size = new System.Drawing.Size(936, 528);
            this._lvwMethods.TabIndex = 0;
            this._lvwMethods.UseCompatibleStateImageBehavior = false;
            this._lvwMethods.View = System.Windows.Forms.View.Details;
            this._lvwMethods.Resize += new System.EventHandler(this._lvwMethods_Resize);
            // 
            // _chMethodFullName
            // 
            this._chMethodFullName.Text = "FullName";
            // 
            // _chMethodToken
            // 
            this._chMethodToken.Text = "Token";
            // 
            // _chMethodAddress
            // 
            this._chMethodAddress.Text = "Address";
            // 
            // _mnuMethodsContext
            // 
            this._mnuMethodsContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuRefresh,
            this._mnuFilter,
            toolStripSeparator1,
            this._mnuPrepareMethod,
            this._mnuCopy});
            this._mnuMethodsContext.Name = "_mnuMethodsContext";
            this._mnuMethodsContext.Size = new System.Drawing.Size(169, 98);
            // 
            // _mnuRefresh
            // 
            this._mnuRefresh.Name = "_mnuRefresh";
            this._mnuRefresh.Size = new System.Drawing.Size(168, 22);
            this._mnuRefresh.Text = "Refresh";
            this._mnuRefresh.Click += new System.EventHandler(this._mnuRefresh_Click);
            // 
            // _mnuFilter
            // 
            this._mnuFilter.Name = "_mnuFilter";
            this._mnuFilter.Size = new System.Drawing.Size(168, 22);
            this._mnuFilter.Text = "Filter...";
            this._mnuFilter.Click += new System.EventHandler(this._mnuFilter_Click);
            // 
            // _mnuPrepareMethod
            // 
            this._mnuPrepareMethod.Name = "_mnuPrepareMethod";
            this._mnuPrepareMethod.Size = new System.Drawing.Size(168, 22);
            this._mnuPrepareMethod.Text = "PrepareMethod";
            this._mnuPrepareMethod.Click += new System.EventHandler(this._mnuPrepareMethod_Click);
            // 
            // _mnuCopy
            // 
            this._mnuCopy.Name = "_mnuCopy";
            this._mnuCopy.Size = new System.Drawing.Size(168, 22);
            this._mnuCopy.Text = "Copy";
            this._mnuCopy.Click += new System.EventHandler(this._mnuCopy_Click);
            // 
            // MethodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 528);
            this.Controls.Add(this._lvwMethods);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MethodsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this._mnuMethodsContext.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView _lvwMethods;
		private System.Windows.Forms.ColumnHeader _chMethodFullName;
		private System.Windows.Forms.ColumnHeader _chMethodAddress;
		private System.Windows.Forms.ContextMenuStrip _mnuMethodsContext;
		private System.Windows.Forms.ToolStripMenuItem _mnuRefresh;
		private System.Windows.Forms.ToolStripMenuItem _mnuFilter;
		private System.Windows.Forms.ToolStripMenuItem _mnuCopy;
		private System.Windows.Forms.ColumnHeader _chMethodToken;
		private System.Windows.Forms.ToolStripMenuItem _mnuPrepareMethod;
	}
}
