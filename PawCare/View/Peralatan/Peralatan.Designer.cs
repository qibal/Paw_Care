namespace PawCare.View.Peralatan
{
    partial class Peralatan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_view_add = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 87);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(844, 498);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // btn_view_add
            // 
            this.btn_view_add.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btn_view_add.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_view_add.ForeColor = System.Drawing.Color.Snow;
            this.btn_view_add.Location = new System.Drawing.Point(772, 40);
            this.btn_view_add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_view_add.Name = "btn_view_add";
            this.btn_view_add.Size = new System.Drawing.Size(84, 26);
            this.btn_view_add.TabIndex = 5;
            this.btn_view_add.Text = "Tambah +";
            this.btn_view_add.UseVisualStyleBackColor = false;
            this.btn_view_add.Click += new System.EventHandler(this.btn_view_add_Click);
            // 
            // btn_export
            // 
            this.btn_export.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btn_export.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_export.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.ForeColor = System.Drawing.Color.Snow;
            this.btn_export.Location = new System.Drawing.Point(678, 40);
            this.btn_export.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(72, 26);
            this.btn_export.TabIndex = 4;
            this.btn_export.Text = "Export +";
            this.btn_export.UseVisualStyleBackColor = false;
            // 
            // Peralatan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 617);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btn_view_add);
            this.Controls.Add(this.btn_export);
            this.Name = "Peralatan";
            this.Text = "Peralatan";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_view_add;
        private System.Windows.Forms.Button btn_export;
    }
}