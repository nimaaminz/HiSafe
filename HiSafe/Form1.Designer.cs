
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
            this.graph_timer = new System.Windows.Forms.Timer(this.components);
            this.data_reader = new System.Windows.Forms.Timer(this.components);
            this.frame_show = new System.Windows.Forms.CheckBox();
            this.db_staus_lbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.hiSafeGraphPerformance = new HiSafe.HiSafeGraphPerformance();
            this.hiSafeAverageColors1 = new HiSafe.HiSafeAverageColors();
            this.main_picbox = new HiSafe.HiSafePictureBox();
            this.timer_database = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.hiSafeGraphPerformance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiSafeAverageColors1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_picbox)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboBoxCamera
            // 
            this.ComboBoxCamera.FormattingEnabled = true;
            this.ComboBoxCamera.Location = new System.Drawing.Point(58, 14);
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
            this.StartBtn.Location = new System.Drawing.Point(185, 14);
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
            this.setting_btn.Location = new System.Drawing.Point(185, 13);
            this.setting_btn.Name = "setting_btn";
            this.setting_btn.Size = new System.Drawing.Size(52, 21);
            this.setting_btn.TabIndex = 6;
            this.setting_btn.Text = "Settings";
            this.setting_btn.UseVisualStyleBackColor = true;
            this.setting_btn.Click += new System.EventHandler(this.setting_btn_Click);
            // 
            // graph_timer
            // 
            this.graph_timer.Interval = 15;
            this.graph_timer.Tick += new System.EventHandler(this.graph_timer_Tick);
            // 
            // data_reader
            // 
            this.data_reader.Interval = 33;
            this.data_reader.Tick += new System.EventHandler(this.data_reader_Tick);
            // 
            // frame_show
            // 
            this.frame_show.AutoSize = true;
            this.frame_show.Checked = true;
            this.frame_show.CheckState = System.Windows.Forms.CheckState.Checked;
            this.frame_show.Location = new System.Drawing.Point(602, 28);
            this.frame_show.Name = "frame_show";
            this.frame_show.Size = new System.Drawing.Size(56, 17);
            this.frame_show.TabIndex = 10;
            this.frame_show.Text = "Show ";
            this.frame_show.UseVisualStyleBackColor = true;
            this.frame_show.CheckedChanged += new System.EventHandler(this.frame_show_CheckedChanged);
            // 
            // db_staus_lbl
            // 
            this.db_staus_lbl.AutoSize = true;
            this.db_staus_lbl.Location = new System.Drawing.Point(676, 22);
            this.db_staus_lbl.Name = "db_staus_lbl";
            this.db_staus_lbl.Size = new System.Drawing.Size(86, 13);
            this.db_staus_lbl.TabIndex = 12;
            this.db_staus_lbl.Text = "Database Status";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(338, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 27);
            this.button1.TabIndex = 13;
            this.button1.Text = "Last Detect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hiSafeGraphPerformance
            // 
            this.hiSafeGraphPerformance.Location = new System.Drawing.Point(12, 51);
            this.hiSafeGraphPerformance.Name = "hiSafeGraphPerformance";
            this.hiSafeGraphPerformance.Size = new System.Drawing.Size(320, 240);
            this.hiSafeGraphPerformance.TabIndex = 11;
            this.hiSafeGraphPerformance.TabStop = false;
            // 
            // hiSafeAverageColors1
            // 
            this.hiSafeAverageColors1.Image = ((System.Drawing.Image)(resources.GetObject("hiSafeAverageColors1.Image")));
            this.hiSafeAverageColors1.Location = new System.Drawing.Point(679, 51);
            this.hiSafeAverageColors1.Name = "hiSafeAverageColors1";
            this.hiSafeAverageColors1.Size = new System.Drawing.Size(320, 240);
            this.hiSafeAverageColors1.TabIndex = 9;
            this.hiSafeAverageColors1.TabStop = false;
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
            // timer_database
            // 
            this.timer_database.Enabled = true;
            this.timer_database.Interval = 1000;
            this.timer_database.Tick += new System.EventHandler(this.timer_database_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 297);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.db_staus_lbl);
            this.Controls.Add(this.hiSafeGraphPerformance);
            this.Controls.Add(this.frame_show);
            this.Controls.Add(this.hiSafeAverageColors1);
            this.Controls.Add(this.main_picbox);
            this.Controls.Add(this.log_lbl);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.ComboBoxCamera);
            this.Controls.Add(this.setting_btn);
            this.Controls.Add(this.CameraNameLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "HiSafe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hiSafeGraphPerformance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiSafeAverageColors1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_picbox)).EndInit();
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
        private System.Windows.Forms.Timer graph_timer;
        private HiSafeAverageColors hiSafeAverageColors1;
        private System.Windows.Forms.Timer data_reader;
        private System.Windows.Forms.CheckBox frame_show;
        private HiSafeGraphPerformance hiSafeGraphPerformance;
        private System.Windows.Forms.Label db_staus_lbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer_database;
    }
}

