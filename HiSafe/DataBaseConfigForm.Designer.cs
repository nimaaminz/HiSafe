
namespace HadronWarrantyCaed
{
    partial class DataBaseConfigForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ip_name_host_txt = new System.Windows.Forms.TextBox();
            this.host_port_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.username_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.password_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.test_host_server_btn = new System.Windows.Forms.Button();
            this.connect_db_btn = new System.Windows.Forms.Button();
            this.date_time_label = new System.Windows.Forms.Label();
            this.database_name_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.db_conenction_status_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host IP/Name";
            // 
            // ip_name_host_txt
            // 
            this.ip_name_host_txt.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip_name_host_txt.Location = new System.Drawing.Point(130, 22);
            this.ip_name_host_txt.Name = "ip_name_host_txt";
            this.ip_name_host_txt.Size = new System.Drawing.Size(185, 24);
            this.ip_name_host_txt.TabIndex = 1;
            this.ip_name_host_txt.Text = "localhost";
            // 
            // host_port_txt
            // 
            this.host_port_txt.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.host_port_txt.Location = new System.Drawing.Point(230, 56);
            this.host_port_txt.Name = "host_port_txt";
            this.host_port_txt.Size = new System.Drawing.Size(85, 24);
            this.host_port_txt.TabIndex = 3;
            this.host_port_txt.Text = "3306";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Host Port";
            // 
            // username_txt
            // 
            this.username_txt.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_txt.Location = new System.Drawing.Point(130, 116);
            this.username_txt.Name = "username_txt";
            this.username_txt.Size = new System.Drawing.Size(185, 24);
            this.username_txt.TabIndex = 5;
            this.username_txt.Text = "root";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username";
            // 
            // password_txt
            // 
            this.password_txt.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_txt.Location = new System.Drawing.Point(130, 146);
            this.password_txt.Name = "password_txt";
            this.password_txt.PasswordChar = '*';
            this.password_txt.Size = new System.Drawing.Size(185, 24);
            this.password_txt.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(12, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password";
            // 
            // test_host_server_btn
            // 
            this.test_host_server_btn.Location = new System.Drawing.Point(83, 234);
            this.test_host_server_btn.Name = "test_host_server_btn";
            this.test_host_server_btn.Size = new System.Drawing.Size(71, 37);
            this.test_host_server_btn.TabIndex = 8;
            this.test_host_server_btn.Text = "Ping Test";
            this.test_host_server_btn.UseVisualStyleBackColor = true;
            this.test_host_server_btn.Click += new System.EventHandler(this.test_host_server_btn_Click);
            // 
            // connect_db_btn
            // 
            this.connect_db_btn.Location = new System.Drawing.Point(169, 234);
            this.connect_db_btn.Name = "connect_db_btn";
            this.connect_db_btn.Size = new System.Drawing.Size(71, 37);
            this.connect_db_btn.TabIndex = 9;
            this.connect_db_btn.Text = "Conenct";
            this.connect_db_btn.UseVisualStyleBackColor = true;
            this.connect_db_btn.Click += new System.EventHandler(this.connect_db_btn_Click);
            // 
            // date_time_label
            // 
            this.date_time_label.AutoSize = true;
            this.date_time_label.BackColor = System.Drawing.Color.Transparent;
            this.date_time_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_time_label.ForeColor = System.Drawing.Color.Silver;
            this.date_time_label.Location = new System.Drawing.Point(79, 279);
            this.date_time_label.Name = "date_time_label";
            this.date_time_label.Size = new System.Drawing.Size(170, 13);
            this.date_time_label.TabIndex = 19;
            this.date_time_label.Text = "The Supported Database Is MySql";
            // 
            // database_name_txt
            // 
            this.database_name_txt.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.database_name_txt.Location = new System.Drawing.Point(130, 86);
            this.database_name_txt.Name = "database_name_txt";
            this.database_name_txt.Size = new System.Drawing.Size(185, 24);
            this.database_name_txt.TabIndex = 21;
            this.database_name_txt.Text = "hisafe_db";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(12, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = "Database";
            // 
            // db_conenction_status_label
            // 
            this.db_conenction_status_label.AutoSize = true;
            this.db_conenction_status_label.BackColor = System.Drawing.Color.Transparent;
            this.db_conenction_status_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.db_conenction_status_label.ForeColor = System.Drawing.Color.Silver;
            this.db_conenction_status_label.Location = new System.Drawing.Point(13, 186);
            this.db_conenction_status_label.Name = "db_conenction_status_label";
            this.db_conenction_status_label.Size = new System.Drawing.Size(0, 13);
            this.db_conenction_status_label.TabIndex = 22;
            // 
            // DataBaseConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 311);
            this.Controls.Add(this.db_conenction_status_label);
            this.Controls.Add(this.database_name_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.date_time_label);
            this.Controls.Add(this.connect_db_btn);
            this.Controls.Add(this.test_host_server_btn);
            this.Controls.Add(this.password_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.username_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.host_port_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ip_name_host_txt);
            this.Controls.Add(this.label1);
            this.Name = "DataBaseConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Config";
            this.Load += new System.EventHandler(this.DataBaseConfigForm_Load);
            this.VisibleChanged += new System.EventHandler(this.DataBaseConfigForm_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ip_name_host_txt;
        private System.Windows.Forms.TextBox host_port_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox password_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button test_host_server_btn;
        private System.Windows.Forms.Button connect_db_btn;
        private System.Windows.Forms.Label date_time_label;
        private System.Windows.Forms.TextBox database_name_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label db_conenction_status_label;
    }
}