
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ComboBoxCamera = new System.Windows.Forms.ComboBox();
            this.CameraNameLbl = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.log_lbl = new System.Windows.Forms.Label();
            this.setting_btn = new System.Windows.Forms.Button();
            this.main_picbox = new HiSafe.HiSafePictureBox();
            this.graph_picturebox = new System.Windows.Forms.PictureBox();
            this.graph_timer = new System.Windows.Forms.Timer(this.components);
            this.hiSafeAverageColors1 = new HiSafe.HiSafeAverageColors();
            this.data_reader = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.main_picbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_picturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiSafeAverageColors1)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboBoxCamera
            // 
            this.ComboBoxCamera.FormattingEnabled = true;
            this.ComboBoxCamera.Location = new System.Drawing.Point(90, 14);
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
            this.StartBtn.Location = new System.Drawing.Point(283, 13);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(52, 21);
            this.StartBtn.TabIndex = 2;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
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
            // setting_btn
            // 
            this.setting_btn.Location = new System.Drawing.Point(283, 14);
            this.setting_btn.Name = "setting_btn";
            this.setting_btn.Size = new System.Drawing.Size(52, 21);
            this.setting_btn.TabIndex = 6;
            this.setting_btn.Text = "Settings";
            this.setting_btn.UseVisualStyleBackColor = true;
            this.setting_btn.Click += new System.EventHandler(this.setting_btn_Click);
            // 
            // main_picbox
            // 
            this.main_picbox.Image = ((System.Drawing.Image)(resources.GetObject("main_picbox.Image")));
            this.main_picbox.Location = new System.Drawing.Point(338, 51);
            this.main_picbox.Name = "main_picbox";
            this.main_picbox.Size = new System.Drawing.Size(320, 240);
            this.main_picbox.TabIndex = 7;
            this.main_picbox.TabStop = false;
            // 
            // graph_picturebox
            // 
            this.graph_picturebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graph_picturebox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.graph_picturebox.Location = new System.Drawing.Point(12, 51);
            this.graph_picturebox.Name = "graph_picturebox";
            this.graph_picturebox.Size = new System.Drawing.Size(320, 240);
            this.graph_picturebox.TabIndex = 8;
            this.graph_picturebox.TabStop = false;
            // 
            // graph_timer
            // 
            this.graph_timer.Interval = 10;
            this.graph_timer.Tick += new System.EventHandler(this.graph_timer_Tick);
            // 
            // hiSafeAverageColors1
            // 
            this.hiSafeAverageColors1.Location = new System.Drawing.Point(679, 51);
            this.hiSafeAverageColors1.Name = "hiSafeAverageColors1";
            this.hiSafeAverageColors1.Size = new System.Drawing.Size(320, 240);
            this.hiSafeAverageColors1.TabIndex = 9;
            this.hiSafeAverageColors1.TabStop = false;
            // 
            // data_reader
            // 
            this.data_reader.Interval = 33;
            this.data_reader.Tick += new System.EventHandler(this.data_reader_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 297);
            this.Controls.Add(this.hiSafeAverageColors1);
            this.Controls.Add(this.graph_picturebox);
            this.Controls.Add(this.main_picbox);
            this.Controls.Add(this.log_lbl);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.CameraNameLbl);
            this.Controls.Add(this.ComboBoxCamera);
            this.Controls.Add(this.setting_btn);
            this.Name = "Form1";
            this.Text = "HiSafe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.main_picbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_picturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiSafeAverageColors1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxCamera;
        private System.Windows.Forms.Label CameraNameLbl;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label log_lbl;
        private System.Windows.Forms.Button setting_btn;
        private HiSafePictureBox main_picbox;
        private System.Windows.Forms.PictureBox graph_picturebox;
        private System.Windows.Forms.Timer graph_timer;
        private HiSafeAverageColors hiSafeAverageColors1;
        private System.Windows.Forms.Timer data_reader;
    }
}

