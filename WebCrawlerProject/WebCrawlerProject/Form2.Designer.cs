namespace WebCrawlerProject
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.keyLb = new System.Windows.Forms.Label();
            this.registerBtn = new System.Windows.Forms.Button();
            this.keyTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dayLb = new System.Windows.Forms.Label();
            this.daysTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.emailLb = new System.Windows.Forms.Label();
            this.getKeyBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.keyLb);
            this.groupBox2.Controls.Add(this.registerBtn);
            this.groupBox2.Controls.Add(this.keyTxt);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(8, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 82);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registration";
            // 
            // keyLb
            // 
            this.keyLb.AutoSize = true;
            this.keyLb.ForeColor = System.Drawing.Color.Red;
            this.keyLb.Location = new System.Drawing.Point(76, 52);
            this.keyLb.Name = "keyLb";
            this.keyLb.Size = new System.Drawing.Size(0, 13);
            this.keyLb.TabIndex = 3;
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(179, 51);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(75, 23);
            this.registerBtn.TabIndex = 2;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // keyTxt
            // 
            this.keyTxt.Location = new System.Drawing.Point(76, 25);
            this.keyTxt.Name = "keyTxt";
            this.keyTxt.Size = new System.Drawing.Size(178, 20);
            this.keyTxt.TabIndex = 1;
            this.keyTxt.TextChanged += new System.EventHandler(this.keyTxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Serial Key : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dayLb);
            this.groupBox1.Controls.Add(this.daysTxt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.emailLb);
            this.groupBox1.Controls.Add(this.getKeyBtn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.emailTxt);
            this.groupBox1.Location = new System.Drawing.Point(8, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 169);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User\'s information";
            // 
            // dayLb
            // 
            this.dayLb.AutoSize = true;
            this.dayLb.ForeColor = System.Drawing.Color.Red;
            this.dayLb.Location = new System.Drawing.Point(76, 103);
            this.dayLb.Name = "dayLb";
            this.dayLb.Size = new System.Drawing.Size(0, 13);
            this.dayLb.TabIndex = 6;
            // 
            // daysTxt
            // 
            this.daysTxt.Location = new System.Drawing.Point(77, 76);
            this.daysTxt.Name = "daysTxt";
            this.daysTxt.Size = new System.Drawing.Size(177, 20);
            this.daysTxt.TabIndex = 5;
            this.daysTxt.TextChanged += new System.EventHandler(this.daysTxt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Trial days : ";
            // 
            // emailLb
            // 
            this.emailLb.AutoSize = true;
            this.emailLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLb.ForeColor = System.Drawing.Color.Red;
            this.emailLb.Location = new System.Drawing.Point(76, 51);
            this.emailLb.Name = "emailLb";
            this.emailLb.Size = new System.Drawing.Size(0, 13);
            this.emailLb.TabIndex = 3;
            // 
            // getKeyBtn
            // 
            this.getKeyBtn.Location = new System.Drawing.Point(179, 136);
            this.getKeyBtn.Name = "getKeyBtn";
            this.getKeyBtn.Size = new System.Drawing.Size(75, 23);
            this.getKeyBtn.TabIndex = 2;
            this.getKeyBtn.Text = "Get Key";
            this.getKeyBtn.UseVisualStyleBackColor = true;
            this.getKeyBtn.Click += new System.EventHandler(this.getKeyBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your Email :";
            // 
            // emailTxt
            // 
            this.emailTxt.Location = new System.Drawing.Point(76, 24);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(178, 20);
            this.emailTxt.TabIndex = 1;
            this.emailTxt.TextChanged += new System.EventHandler(this.emailTxt_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 263);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Tag", global::WebCrawlerProject.Properties.Settings.Default, "ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = global::WebCrawlerProject.Properties.Settings.Default.ID;
            this.Text = "Registration";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label keyLb;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.TextBox keyTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label emailLb;
        private System.Windows.Forms.Button getKeyBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.TextBox daysTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label dayLb;
    }
}