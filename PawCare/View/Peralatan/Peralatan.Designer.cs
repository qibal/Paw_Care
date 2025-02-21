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
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 71);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(633, 405);
            this.flowLayoutPanel1.TabIndex = 6;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // btn_view_add
            // 
            this.btn_view_add.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btn_view_add.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_view_add.ForeColor = System.Drawing.Color.Snow;
            this.btn_view_add.Location = new System.Drawing.Point(579, 32);
            this.btn_view_add.Margin = new System.Windows.Forms.Padding(2);
            this.btn_view_add.Name = "btn_view_add";
            this.btn_view_add.Size = new System.Drawing.Size(63, 21);
            this.btn_view_add.TabIndex = 5;
            this.btn_view_add.Text = "Tambah +";
            this.btn_view_add.UseVisualStyleBackColor = false;
            this.btn_view_add.Click += new System.EventHandler(this.btn_view_add_Click);
            // 
            // Peralatan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 501);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btn_view_add);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Peralatan";
            this.Text = "Peralatan";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_view_add;
    }
}