namespace LoginToTheVoid
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            usa = new TextBox();
            passwad = new TextBox();
            label1 = new Label();
            label2 = new Label();
            gud = new Label();
            bad = new Label();
            login = new Button();
            newusa = new Button();
            message = new Label();
            SuspendLayout();
            // 
            // usa
            // 
            usa.Location = new Point(227, 81);
            usa.Name = "usa";
            usa.Size = new Size(314, 23);
            usa.TabIndex = 0;
            // 
            // passwad
            // 
            passwad.Location = new Point(227, 110);
            passwad.Name = "passwad";
            passwad.Size = new Size(314, 23);
            passwad.TabIndex = 1;
            passwad.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(196, 84);
            label1.Name = "label1";
            label1.Size = new Size(25, 15);
            label1.TabIndex = 2;
            label1.Text = "usa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(169, 113);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 3;
            label2.Text = "passwad";
            // 
            // gud
            // 
            gud.AutoSize = true;
            gud.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gud.ForeColor = Color.FromArgb(0, 192, 0);
            gud.Location = new Point(263, 210);
            gud.Name = "gud";
            gud.Size = new Size(79, 45);
            gud.TabIndex = 4;
            gud.Text = "gud";
            // 
            // bad
            // 
            bad.AutoSize = true;
            bad.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bad.ForeColor = Color.FromArgb(192, 0, 0);
            bad.Location = new Point(420, 210);
            bad.Name = "bad";
            bad.Size = new Size(77, 45);
            bad.TabIndex = 5;
            bad.Text = "bad";
            // 
            // login
            // 
            login.Location = new Point(227, 139);
            login.Name = "login";
            login.Size = new Size(75, 23);
            login.TabIndex = 6;
            login.Text = "log in";
            login.UseVisualStyleBackColor = true;
            login.Click += login_Click;
            // 
            // newusa
            // 
            newusa.Location = new Point(308, 139);
            newusa.Name = "newusa";
            newusa.Size = new Size(75, 23);
            newusa.TabIndex = 7;
            newusa.Text = "new usa";
            newusa.UseVisualStyleBackColor = true;
            newusa.Click += newusa_Click;
            // 
            // message
            // 
            message.AutoSize = true;
            message.Location = new Point(263, 292);
            message.Name = "message";
            message.Size = new Size(53, 15);
            message.TabIndex = 8;
            message.Text = "message";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(message);
            Controls.Add(newusa);
            Controls.Add(bad);
            Controls.Add(gud);
            Controls.Add(login);
            Controls.Add(usa);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passwad);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Password Memory Test";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usa;
        private TextBox passwad;
        private Label label1;
        private Label label2;
        private Label gud;
        private Label bad;
        private Button login;
        private Button newusa;
        private Label message;
    }
}
