namespace PawCare.View.Peralatan
{
    partial class FormPeralatan
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
            this.table_category = new System.Windows.Forms.TableLayoutPanel();
            this.btn_save_category = new System.Windows.Forms.Button();
            this.category_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.image = new System.Windows.Forms.Button();
            this.btn_save_equipment = new System.Windows.Forms.Button();
            this.category_id = new System.Windows.Forms.ComboBox();
            this.amount = new System.Windows.Forms.TextBox();
            this.equipment_name = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_category
            // 
            this.table_category.ColumnCount = 2;
            this.table_category.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_category.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_category.Location = new System.Drawing.Point(671, 207);
            this.table_category.Name = "table_category";
            this.table_category.RowCount = 2;
            this.table_category.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_category.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_category.Size = new System.Drawing.Size(194, 152);
            this.table_category.TabIndex = 18;
            this.table_category.Paint += new System.Windows.Forms.PaintEventHandler(this.table_category_Paint);
            // 
            // btn_save_category
            // 
            this.btn_save_category.Location = new System.Drawing.Point(670, 168);
            this.btn_save_category.Name = "btn_save_category";
            this.btn_save_category.Size = new System.Drawing.Size(195, 23);
            this.btn_save_category.TabIndex = 17;
            this.btn_save_category.Text = "Simpan";
            this.btn_save_category.UseVisualStyleBackColor = true;
            this.btn_save_category.Click += new System.EventHandler(this.btn_save_category_Click);
            // 
            // category_name
            // 
            this.category_name.Location = new System.Drawing.Point(670, 141);
            this.category_name.Name = "category_name";
            this.category_name.Size = new System.Drawing.Size(195, 22);
            this.category_name.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(668, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Kategori Hewan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(492, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Data Hewan";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(54, 114);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(332, 245);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.image);
            this.groupBox1.Controls.Add(this.btn_save_equipment);
            this.groupBox1.Controls.Add(this.category_id);
            this.groupBox1.Controls.Add(this.amount);
            this.groupBox1.Controls.Add(this.equipment_name);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(392, 109);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(263, 250);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(279, 98);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(99, 152);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Kategori";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Gambar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Jumlah";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nama Hewan";
            // 
            // image
            // 
            this.image.Location = new System.Drawing.Point(103, 121);
            this.image.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(152, 26);
            this.image.TabIndex = 6;
            this.image.Text = "Pilih Gambar";
            this.image.UseVisualStyleBackColor = true;
            // 
            // btn_save_equipment
            // 
            this.btn_save_equipment.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_equipment.Location = new System.Drawing.Point(103, 209);
            this.btn_save_equipment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_save_equipment.Name = "btn_save_equipment";
            this.btn_save_equipment.Size = new System.Drawing.Size(152, 31);
            this.btn_save_equipment.TabIndex = 5;
            this.btn_save_equipment.Text = "Simpan";
            this.btn_save_equipment.UseVisualStyleBackColor = true;
            // 
            // category_id
            // 
            this.category_id.FormattingEnabled = true;
            this.category_id.Location = new System.Drawing.Point(103, 155);
            this.category_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.category_id.Name = "category_id";
            this.category_id.Size = new System.Drawing.Size(152, 24);
            this.category_id.TabIndex = 4;
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(103, 91);
            this.amount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(152, 22);
            this.amount.TabIndex = 2;
            // 
            // equipment_name
            // 
            this.equipment_name.Location = new System.Drawing.Point(103, 31);
            this.equipment_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.equipment_name.Name = "equipment_name";
            this.equipment_name.Size = new System.Drawing.Size(152, 22);
            this.equipment_name.TabIndex = 0;
            // 
            // FormPeralatan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 450);
            this.Controls.Add(this.table_category);
            this.Controls.Add(this.btn_save_category);
            this.Controls.Add(this.category_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormPeralatan";
            this.Text = "FormPeralatan";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_category;
        private System.Windows.Forms.Button btn_save_category;
        private System.Windows.Forms.TextBox category_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button image;
        private System.Windows.Forms.Button btn_save_equipment;
        private System.Windows.Forms.ComboBox category_id;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.TextBox equipment_name;
    }
}