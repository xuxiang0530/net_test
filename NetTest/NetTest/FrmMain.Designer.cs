namespace NetTest
{
    partial class FrmMain
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
            this.textJobOne = new System.Windows.Forms.TextBox();
            this.textJobTwo = new System.Windows.Forms.TextBox();
            this.txt_Input = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.chbOne = new System.Windows.Forms.CheckBox();
            this.chbTwo = new System.Windows.Forms.CheckBox();
            this.grbText1 = new System.Windows.Forms.GroupBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.grbText2 = new System.Windows.Forms.GroupBox();
            this.grbText1.SuspendLayout();
            this.grbText2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textJobOne
            // 
            this.textJobOne.Location = new System.Drawing.Point(6, 24);
            this.textJobOne.Multiline = true;
            this.textJobOne.Name = "textJobOne";
            this.textJobOne.Size = new System.Drawing.Size(432, 375);
            this.textJobOne.TabIndex = 0;
            // 
            // textJobTwo
            // 
            this.textJobTwo.Location = new System.Drawing.Point(6, 24);
            this.textJobTwo.Multiline = true;
            this.textJobTwo.Name = "textJobTwo";
            this.textJobTwo.Size = new System.Drawing.Size(432, 375);
            this.textJobTwo.TabIndex = 1;
            // 
            // txt_Input
            // 
            this.txt_Input.Location = new System.Drawing.Point(51, 432);
            this.txt_Input.Name = "txt_Input";
            this.txt_Input.Size = new System.Drawing.Size(754, 25);
            this.txt_Input.TabIndex = 2;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(838, 434);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "提交";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // chbOne
            // 
            this.chbOne.AutoSize = true;
            this.chbOne.Location = new System.Drawing.Point(982, 384);
            this.chbOne.Name = "chbOne";
            this.chbOne.Size = new System.Drawing.Size(82, 19);
            this.chbOne.TabIndex = 4;
            this.chbOne.Text = "文本区1";
            this.chbOne.UseVisualStyleBackColor = true;
            // 
            // chbTwo
            // 
            this.chbTwo.AutoSize = true;
            this.chbTwo.Location = new System.Drawing.Point(982, 409);
            this.chbTwo.Name = "chbTwo";
            this.chbTwo.Size = new System.Drawing.Size(82, 19);
            this.chbTwo.TabIndex = 5;
            this.chbTwo.Text = "文本区2";
            this.chbTwo.UseVisualStyleBackColor = true;
            // 
            // grbText1
            // 
            this.grbText1.Controls.Add(this.textJobOne);
            this.grbText1.Location = new System.Drawing.Point(25, 21);
            this.grbText1.Name = "grbText1";
            this.grbText1.Size = new System.Drawing.Size(467, 405);
            this.grbText1.TabIndex = 6;
            this.grbText1.TabStop = false;
            this.grbText1.Text = "GroupJob1";
            // 
            // grbText2
            // 
            this.grbText2.Controls.Add(this.textJobTwo);
            this.grbText2.Location = new System.Drawing.Point(521, 21);
            this.grbText2.Name = "grbText2";
            this.grbText2.Size = new System.Drawing.Size(455, 407);
            this.grbText2.TabIndex = 7;
            this.grbText2.TabStop = false;
            this.grbText2.Text = "GroupJob2";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 487);
            this.Controls.Add(this.grbText2);
            this.Controls.Add(this.grbText1);
            this.Controls.Add(this.chbTwo);
            this.Controls.Add(this.chbOne);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_Input);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.grbText1.ResumeLayout(false);
            this.grbText1.PerformLayout();
            this.grbText2.ResumeLayout(false);
            this.grbText2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textJobOne;
        private System.Windows.Forms.TextBox textJobTwo;
        private System.Windows.Forms.TextBox txt_Input;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.CheckBox chbOne;
        private System.Windows.Forms.CheckBox chbTwo;
        private System.Windows.Forms.GroupBox grbText1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.GroupBox grbText2;
    }
}