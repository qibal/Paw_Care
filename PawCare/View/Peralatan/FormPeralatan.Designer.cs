namespace PawCare.View.Peralatan
{
    partial class FormPeralatan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox categoryNameTextBox;
        private System.Windows.Forms.Button addCategoryButton;

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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "FormPeralatan";




            // Add controls for category input
            this.categoryNameTextBox = new System.Windows.Forms.TextBox();
            this.addCategoryButton = new System.Windows.Forms.Button();
            this.addCategoryButton.Text = "Add Category";
            this.addCategoryButton.Click += new System.EventHandler(this.addCategoryButton_Click);

            this.Controls.Add(this.categoryNameTextBox);
            this.Controls.Add(this.addCategoryButton);
        }

        #endregion
    }
}