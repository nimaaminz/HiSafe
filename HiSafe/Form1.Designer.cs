
namespace HiSafe
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
            this.ComboBoxCamera = new System.Windows.Forms.ComboBox();
            this.CameraNameLbl = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.main_cam_picbox = new System.Windows.Forms.PictureBox();
            this.log_lbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.setting_btn = new System.Windows.Forms.Button();
            this.FPS_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.main_cam_picbox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComboBoxCamera
            // 
            this.ComboBoxCamera.FormattingEnabled = true;
            this.ComboBoxCamera.Location = new System.Drawing.Point(90, 13);
            this.ComboBoxCamera.Name = "ComboBoxCamera";
            this.ComboBoxCamera.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxCamera.TabIndex = 0;
            // 
            // CameraNameLbl
            // 
            this.CameraNameLbl.Location = new System.Drawing.Point(12, 13);
            this.CameraNameLbl.Name = "CameraNameLbl";
            this.CameraNameLbl.Size = new System.Drawing.Size(72, 21);
            this.CameraNameLbl.TabIndex = 1;
            this.CameraNameLbl.Text = "Camera";
            this.CameraNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(283, 12);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(52, 21);
            this.StartBtn.TabIndex = 2;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // main_cam_picbox
            // 
            this.main_cam_picbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_cam_picbox.Location = new System.Drawing.Point(0, 0);
            this.main_cam_picbox.Name = "main_cam_picbox";
            this.main_cam_picbox.Size = new System.Drawing.Size(318, 238);
            this.main_cam_picbox.TabIndex = 3;
            this.main_cam_picbox.TabStop = false;
            // 
            // log_lbl
            // 
            this.log_lbl.AutoSize = true;
            this.log_lbl.Location = new System.Drawing.Point(15, 35);
            this.log_lbl.Name = "log_lbl";
            this.log_lbl.Size = new System.Drawing.Size(25, 13);
            this.log_lbl.TabIndex = 4;
            this.log_lbl.Text = "Log";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.FPS_label);
            this.panel1.Controls.Add(this.main_cam_picbox);
            this.panel1.Location = new System.Drawing.Point(18, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 240);
            this.panel1.TabIndex = 5;
            // 
            // setting_btn
            // 
            this.setting_btn.Location = new System.Drawing.Point(365, 44);
            this.setting_btn.Name = "setting_btn";
            this.setting_btn.Size = new System.Drawing.Size(52, 21);
            this.setting_btn.TabIndex = 6;
            this.setting_btn.Text = "Settings";
            this.setting_btn.UseVisualStyleBackColor = true;
            this.setting_btn.Click += new System.EventHandler(this.setting_btn_Click);
            // 
            // FPS_label
            // 
            this.FPS_label.AutoSize = true;
            this.FPS_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FPS_label.ForeColor = System.Drawing.Color.ForestGreen;
            this.FPS_label.Location = new System.Drawing.Point(9, 7);
            this.FPS_label.Name = "FPS_label";
            this.FPS_label.Size = new System.Drawing.Size(57, 16);
            this.FPS_label.TabIndex = 4;
            this.FPS_label.Text = "FPS : 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 385);
            this.Controls.Add(this.setting_btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.log_lbl);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.CameraNameLbl);
            this.Controls.Add(this.ComboBoxCamera);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.main_cam_picbox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxCamera;
        private System.Windows.Forms.Label CameraNameLbl;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.PictureBox main_cam_picbox;
        private System.Windows.Forms.Label log_lbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button setting_btn;
        private System.Windows.Forms.Label FPS_label;
    }
}

