namespace ActiveDirectoryTree
{
    partial class FADTreeView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tvAD = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvAD
            // 
            this.tvAD.Location = new System.Drawing.Point(12, 12);
            this.tvAD.Name = "tvAD";
            this.tvAD.Size = new System.Drawing.Size(652, 557);
            this.tvAD.TabIndex = 0;
            this.tvAD.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvAD_NodeMouseDoubleClick);
            // 
            // FADTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 603);
            this.Controls.Add(this.tvAD);
            this.Name = "FADTreeView";
            this.Text = "Дерево Active Directory";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvAD;
    }
}

