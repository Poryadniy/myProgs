using System.ComponentModel;

namespace pet
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Reg_login_tbox = new System.Windows.Forms.TextBox();
            this.Reg_password_tbox = new System.Windows.Forms.TextBox();
            this.Reg_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Reg_country_tbox = new System.Windows.Forms.TextBox();
            this.Pass_gen_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(270, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(270, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // Reg_login_tbox
            // 
            this.Reg_login_tbox.Location = new System.Drawing.Point(376, 153);
            this.Reg_login_tbox.Name = "Reg_login_tbox";
            this.Reg_login_tbox.Size = new System.Drawing.Size(100, 20);
            this.Reg_login_tbox.TabIndex = 2;
            // 
            // Reg_password_tbox
            // 
            this.Reg_password_tbox.Location = new System.Drawing.Point(376, 190);
            this.Reg_password_tbox.Name = "Reg_password_tbox";
            this.Reg_password_tbox.Size = new System.Drawing.Size(100, 20);
            this.Reg_password_tbox.TabIndex = 3;
            // 
            // Reg_button
            // 
            this.Reg_button.Location = new System.Drawing.Point(328, 261);
            this.Reg_button.Name = "Reg_button";
            this.Reg_button.Size = new System.Drawing.Size(75, 23);
            this.Reg_button.TabIndex = 4;
            this.Reg_button.Text = "Register";
            this.Reg_button.UseVisualStyleBackColor = true;
            this.Reg_button.Click += new System.EventHandler(this.Reg_button_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(270, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Country";
            // 
            // Reg_country_tbox
            // 
            this.Reg_country_tbox.Location = new System.Drawing.Point(376, 228);
            this.Reg_country_tbox.Name = "Reg_country_tbox";
            this.Reg_country_tbox.Size = new System.Drawing.Size(100, 20);
            this.Reg_country_tbox.TabIndex = 6;
            // 
            // Pass_gen_button
            // 
            this.Pass_gen_button.Location = new System.Drawing.Point(607, 414);
            this.Pass_gen_button.Name = "Pass_gen_button";
            this.Pass_gen_button.Size = new System.Drawing.Size(59, 23);
            this.Pass_gen_button.TabIndex = 7;
            this.Pass_gen_button.Text = "Generate";
            this.Pass_gen_button.UseVisualStyleBackColor = true;
            this.Pass_gen_button.Click += new System.EventHandler(this.Pass_gen_button_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(455, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(345, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "If you want to generate a password, you can click on the button below";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Pass_gen_button);
            this.Controls.Add(this.Reg_country_tbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Reg_button);
            this.Controls.Add(this.Reg_password_tbox);
            this.Controls.Add(this.Reg_login_tbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Register";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button Pass_gen_button;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Reg_country_tbox;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Reg_login_tbox;
        private System.Windows.Forms.TextBox Reg_password_tbox;
        private System.Windows.Forms.Button Reg_button;

        #endregion
    }
}