namespace pet
{
    partial class Form1
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
            this.sign_in_button = new System.Windows.Forms.Button();
            this.sign_up_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.autho_log_tbox = new System.Windows.Forms.TextBox();
            this.autho_pass_tbox = new System.Windows.Forms.TextBox();
            this.Exit_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sign_in_button
            // 
            this.sign_in_button.Location = new System.Drawing.Point(257, 250);
            this.sign_in_button.Name = "sign_in_button";
            this.sign_in_button.Size = new System.Drawing.Size(75, 23);
            this.sign_in_button.TabIndex = 0;
            this.sign_in_button.Text = "Sign in";
            this.sign_in_button.UseVisualStyleBackColor = true;
            this.sign_in_button.Click += new System.EventHandler(this.sign_in_Click);
            // 
            // sign_up_button
            // 
            this.sign_up_button.Location = new System.Drawing.Point(422, 250);
            this.sign_up_button.Name = "sign_up_button";
            this.sign_up_button.Size = new System.Drawing.Size(75, 23);
            this.sign_up_button.TabIndex = 1;
            this.sign_up_button.Text = "Sign up";
            this.sign_up_button.UseVisualStyleBackColor = true;
            this.sign_up_button.Click += new System.EventHandler(this.sign_up_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(257, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(257, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // autho_log_tbox
            // 
            this.autho_log_tbox.Location = new System.Drawing.Point(397, 134);
            this.autho_log_tbox.Name = "autho_log_tbox";
            this.autho_log_tbox.Size = new System.Drawing.Size(100, 20);
            this.autho_log_tbox.TabIndex = 4;
            // 
            // autho_pass_tbox
            // 
            this.autho_pass_tbox.Location = new System.Drawing.Point(397, 198);
            this.autho_pass_tbox.Name = "autho_pass_tbox";
            this.autho_pass_tbox.Size = new System.Drawing.Size(100, 20);
            this.autho_pass_tbox.TabIndex = 5;
            // 
            // Exit_button
            // 
            this.Exit_button.Location = new System.Drawing.Point(715, 415);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(73, 23);
            this.Exit_button.TabIndex = 6;
            this.Exit_button.Text = "Exit";
            this.Exit_button.UseVisualStyleBackColor = true;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.autho_pass_tbox);
            this.Controls.Add(this.autho_log_tbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sign_up_button);
            this.Controls.Add(this.sign_in_button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button Exit_button;

        private System.Windows.Forms.Button sign_in_button;
        private System.Windows.Forms.Button sign_up_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox autho_log_tbox;
        private System.Windows.Forms.TextBox autho_pass_tbox;

        #endregion
    }
}