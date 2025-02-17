namespace PawCare.View.hewan
{
    partial class FormHewan
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.image = new System.Windows.Forms.Button();
            this.btn_save_animal = new System.Windows.Forms.Button();
            this.category_id = new System.Windows.Forms.ComboBox();
            this.age = new System.Windows.Forms.TextBox();
            this.animal_name = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.category_name = new System.Windows.Forms.TextBox();
            this.btn_save_category = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_gender = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CB_gender);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.image);
            this.groupBox1.Controls.Add(this.btn_save_animal);
            this.groupBox1.Controls.Add(this.category_id);
            this.groupBox1.Controls.Add(this.age);
            this.groupBox1.Controls.Add(this.animal_name);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(401, 54);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(263, 250);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            this.image.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_save_animal
            // 
            this.btn_save_animal.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_animal.Location = new System.Drawing.Point(103, 209);
            this.btn_save_animal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_save_animal.Name = "btn_save_animal";
            this.btn_save_animal.Size = new System.Drawing.Size(152, 31);
            this.btn_save_animal.TabIndex = 5;
            this.btn_save_animal.Text = "Simpan";
            this.btn_save_animal.UseVisualStyleBackColor = true;
            this.btn_save_animal.Click += new System.EventHandler(this.btn_save_animal_Click);
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
            // age
            // 
            this.age.Location = new System.Drawing.Point(103, 91);
            this.age.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(152, 22);
            this.age.TabIndex = 2;
            // 
            // animal_name
            // 
            this.animal_name.Location = new System.Drawing.Point(103, 31);
            this.animal_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.animal_name.Name = "animal_name";
            this.animal_name.Size = new System.Drawing.Size(152, 22);
            this.animal_name.TabIndex = 0;
            this.animal_name.TextChanged += new System.EventHandler(this.animal_name_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(63, 59);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(332, 245);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(501, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Data Hewan";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(677, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Kategori Hewan";
            // 
            // category_name
            // 
            this.category_name.Location = new System.Drawing.Point(679, 86);
            this.category_name.Name = "category_name";
            this.category_name.Size = new System.Drawing.Size(100, 22);
            this.category_name.TabIndex = 9;
            // 
            // btn_save_category
            // 
            this.btn_save_category.Location = new System.Drawing.Point(679, 113);
            this.btn_save_category.Name = "btn_save_category";
            this.btn_save_category.Size = new System.Drawing.Size(100, 23);
            this.btn_save_category.TabIndex = 10;
            this.btn_save_category.Text = "Simpan";
            this.btn_save_category.UseVisualStyleBackColor = true;
            this.btn_save_category.Click += new System.EventHandler(this.btn_save_category_Click);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Gender";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Umur";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Kategori";
            // 
            // CB_gender
            // 
            this.CB_gender.FormattingEnabled = true;
            this.CB_gender.Items.AddRange(new object[] {
            "Jantan",
            "Betina"});
            this.CB_gender.Location = new System.Drawing.Point(103, 62);
            this.CB_gender.Name = "CB_gender";
            this.CB_gender.Size = new System.Drawing.Size(152, 24);
            this.CB_gender.TabIndex = 12;
            this.CB_gender.SelectedIndexChanged += new System.EventHandler(this.CB_gender_SelectedIndexChanged);
            // 
            // FormHewan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkTurquoise;
            this.ClientSize = new System.Drawing.Size(821, 360);
            this.Controls.Add(this.btn_save_category);
            this.Controls.Add(this.category_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormHewan";
            this.Text = "FormHewan";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_save_animal;
        private System.Windows.Forms.ComboBox category_id;
        private System.Windows.Forms.TextBox age;
        private System.Windows.Forms.TextBox animal_name;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button image;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox category_name;
        private System.Windows.Forms.Button btn_save_category;
        private System.Windows.Forms.ComboBox CB_gender;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}