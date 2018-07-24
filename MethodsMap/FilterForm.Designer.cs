namespace MethodsMap {
	partial class FilterForm {
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
            System.Windows.Forms.Label _lbSearchText;
            this._btnOK = new System.Windows.Forms.Button();
            this._tbSearchText = new System.Windows.Forms.TextBox();
            this._btnCancel = new System.Windows.Forms.Button();
            this._lvwModules = new System.Windows.Forms.ListView();
            _lbSearchText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _lbSearchText
            // 
            _lbSearchText.AutoSize = true;
            _lbSearchText.Location = new System.Drawing.Point(12, 9);
            _lbSearchText.Name = "_lbSearchText";
            _lbSearchText.Size = new System.Drawing.Size(50, 17);
            _lbSearchText.TabIndex = 1;
            _lbSearchText.Text = "Search:";
            // 
            // _btnOK
            // 
            this._btnOK.Location = new System.Drawing.Point(280, 388);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(85, 30);
            this._btnOK.TabIndex = 0;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // _tbSearchText
            // 
            this._tbSearchText.Location = new System.Drawing.Point(68, 6);
            this._tbSearchText.Name = "_tbSearchText";
            this._tbSearchText.Size = new System.Drawing.Size(297, 23);
            this._tbSearchText.TabIndex = 2;
            this._tbSearchText.TextChanged += new System.EventHandler(this._tbSearchText_TextChanged);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(12, 388);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(85, 30);
            this._btnCancel.TabIndex = 3;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _lvwModules
            // 
            this._lvwModules.CheckBoxes = true;
            this._lvwModules.Location = new System.Drawing.Point(12, 35);
            this._lvwModules.Name = "_lvwModules";
            this._lvwModules.Size = new System.Drawing.Size(353, 347);
            this._lvwModules.TabIndex = 4;
            this._lvwModules.UseCompatibleStateImageBehavior = false;
            this._lvwModules.View = System.Windows.Forms.View.List;
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 430);
            this.Controls.Add(this._lvwModules);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._tbSearchText);
            this.Controls.Add(_lbSearchText);
            this.Controls.Add(this._btnOK);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filter";
            this.Load += new System.EventHandler(this.FilterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _btnOK;
		private System.Windows.Forms.TextBox _tbSearchText;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.ListView _lvwModules;
	}
}
