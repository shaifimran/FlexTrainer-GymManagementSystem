namespace Database_Project_GymTrainer
{
    partial class Member_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Member_Login));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.member_login_email = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.member_login_password = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton5 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(224, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email *";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(224, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password *";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkLabel1.Location = new System.Drawing.Point(272, 329);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(280, 28);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Don\'t have an account? Sign Up !";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(333, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 42);
            this.label2.TabIndex = 7;
            this.label2.Text = "MEMBER LOGIN";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // member_login_email
            // 
            this.member_login_email.Location = new System.Drawing.Point(340, 187);
            this.member_login_email.Name = "member_login_email";
            this.member_login_email.Size = new System.Drawing.Size(225, 27);
            this.member_login_email.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.member_login_email.StateCommon.Border.Rounding = 5;
            this.member_login_email.TabIndex = 11;
            this.member_login_email.TextChanged += new System.EventHandler(this.kryptonTextBox1_TextChanged);
            // 
            // member_login_password
            // 
            this.member_login_password.Location = new System.Drawing.Point(340, 220);
            this.member_login_password.Name = "member_login_password";
            this.member_login_password.PasswordChar = '•';
            this.member_login_password.Size = new System.Drawing.Size(225, 27);
            this.member_login_password.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.member_login_password.StateCommon.Border.Rounding = 5;
            this.member_login_password.TabIndex = 13;
            this.member_login_password.TextChanged += new System.EventHandler(this.kryptonTextBox3_TextChanged);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(464, 253);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton1.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton1.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton1.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton1.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.kryptonButton1.OverrideFocus.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.kryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.kryptonButton1.Size = new System.Drawing.Size(101, 51);
            this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Rounding = 30;
            this.kryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButton1.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonButton1.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton1.StateDisabled.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton1.StateDisabled.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton1.StateDisabled.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton1.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton1.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton1.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton1.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.kryptonButton1.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.kryptonButton1.TabIndex = 14;
            this.kryptonButton1.Values.Text = "Login";
            this.kryptonButton1.Click += new System.EventHandler(this.button3_Click);
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.Location = new System.Drawing.Point(23, 377);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton4.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton4.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton4.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton4.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton4.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.kryptonButton4.OverrideFocus.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.kryptonButton4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.kryptonButton4.Size = new System.Drawing.Size(115, 51);
            this.kryptonButton4.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonButton4.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton4.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton4.StateCommon.Border.Rounding = 30;
            this.kryptonButton4.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButton4.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kryptonButton4.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonButton4.StateDisabled.Back.Color1 = System.Drawing.Color.White;
            this.kryptonButton4.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton4.StateDisabled.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton4.StateDisabled.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton4.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton4.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.kryptonButton4.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.kryptonButton4.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButton4.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kryptonButton4.StatePressed.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StatePressed.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton4.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton4.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton4.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton4.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton4.StateTracking.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateTracking.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton4.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton4.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton4.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton4.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton4.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton4.TabIndex = 59;
            this.kryptonButton4.Values.Text = "Go back";
            this.kryptonButton4.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, -80);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(257, 264);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 84;
            this.pictureBox2.TabStop = false;
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(571, 210);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton2.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton2.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton2.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton2.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton2.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.kryptonButton2.OverrideFocus.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.kryptonButton2.Size = new System.Drawing.Size(57, 49);
            this.kryptonButton2.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StateCommon.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton2.StateCommon.Border.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StateCommon.Border.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton2.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton2.StateCommon.Border.Rounding = 30;
            this.kryptonButton2.StateCommon.Content.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.kryptonButton2.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButton2.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kryptonButton2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonButton2.StateDisabled.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StateDisabled.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StateDisabled.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton2.StateDisabled.Border.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StateDisabled.Border.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StateDisabled.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton2.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton2.StateDisabled.Content.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton2.StateNormal.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StateNormal.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StateNormal.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton2.StateNormal.Border.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StateNormal.Border.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton2.StateNormal.Content.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.kryptonButton2.StatePressed.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StatePressed.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StatePressed.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton2.StatePressed.Border.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StatePressed.Border.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StatePressed.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton2.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton2.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.kryptonButton2.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton2.StateTracking.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton2.StateTracking.Border.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StateTracking.Border.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton2.StateTracking.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton2.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton2.TabIndex = 90;
            this.kryptonButton2.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton2.Values.Image")));
            this.kryptonButton2.Values.Text = "";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // kryptonButton5
            // 
            this.kryptonButton5.Location = new System.Drawing.Point(571, 210);
            this.kryptonButton5.Name = "kryptonButton5";
            this.kryptonButton5.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton5.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton5.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton5.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(2)))), ((int)(((byte)(8)))));
            this.kryptonButton5.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton5.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.kryptonButton5.OverrideFocus.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.kryptonButton5.Size = new System.Drawing.Size(57, 49);
            this.kryptonButton5.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StateCommon.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton5.StateCommon.Border.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StateCommon.Border.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton5.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton5.StateCommon.Border.Rounding = 30;
            this.kryptonButton5.StateCommon.Content.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.kryptonButton5.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButton5.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kryptonButton5.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonButton5.StateDisabled.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StateDisabled.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StateDisabled.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton5.StateDisabled.Border.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StateDisabled.Border.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StateDisabled.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton5.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton5.StateDisabled.Content.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton5.StateNormal.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StateNormal.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StateNormal.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton5.StateNormal.Border.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StateNormal.Border.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton5.StateNormal.Content.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.kryptonButton5.StatePressed.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StatePressed.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StatePressed.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton5.StatePressed.Border.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StatePressed.Border.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StatePressed.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton5.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton5.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.kryptonButton5.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton5.StateTracking.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton5.StateTracking.Border.Color1 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StateTracking.Border.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton5.StateTracking.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonButton5.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton5.TabIndex = 89;
            this.kryptonButton5.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton5.Values.Image")));
            this.kryptonButton5.Values.Text = "";
            this.kryptonButton5.Click += new System.EventHandler(this.kryptonButton5_Click);
            // 
            // Member_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.kryptonButton5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.kryptonButton4);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.member_login_password);
            this.Controls.Add(this.member_login_email);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Member_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Member_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox member_login_email;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox member_login_password;
        public ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        public ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
        private System.Windows.Forms.PictureBox pictureBox2;
        public ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        public ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton5;
    }
}