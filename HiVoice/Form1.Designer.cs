
namespace HiVoice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pb_eqo = new HiVoice.EqoPicturebox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.nimaColorPicker1 = new HiVoice.NimaColorPicker();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_record = new System.Windows.Forms.Button();
            this.btn_recorder = new System.Windows.Forms.Button();
            this.timer_voice_freq = new System.Windows.Forms.Timer(this.components);
            this.pb_fft_type = new HiVoice.EqoPicturebox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eqo)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nimaColorPicker1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_fft_type)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pb_fft_type);
            this.panel1.Controls.Add(this.pb_eqo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1022, 509);
            this.panel1.TabIndex = 0;
            // 
            // pb_eqo
            // 
            this.pb_eqo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pb_eqo.Image = ((System.Drawing.Image)(resources.GetObject("pb_eqo.Image")));
            this.pb_eqo.Location = new System.Drawing.Point(0, 0);
            this.pb_eqo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_eqo.Name = "pb_eqo";
            this.pb_eqo.Size = new System.Drawing.Size(1020, 196);
            this.pb_eqo.TabIndex = 0;
            this.pb_eqo.TabStop = false;
            this.pb_eqo.Click += new System.EventHandler(this.pb_eqo_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1022, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(346, 509);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(346, 509);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Black;
            this.tabPage1.Controls.Add(this.nimaColorPicker1);
            this.tabPage1.ForeColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Size = new System.Drawing.Size(338, 481);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Color Settings";
            // 
            // nimaColorPicker1
            // 
            this.nimaColorPicker1.Image = global::HiVoice.Properties.Resources.Color_circle__RGB__svg;
            this.nimaColorPicker1.Location = new System.Drawing.Point(7, 6);
            this.nimaColorPicker1.Name = "nimaColorPicker1";
            this.nimaColorPicker1.Size = new System.Drawing.Size(323, 232);
            this.nimaColorPicker1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.nimaColorPicker1.TabIndex = 0;
            this.nimaColorPicker1.TabStop = false;
            this.nimaColorPicker1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.nimaColorPicker1_MouseMove);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Size = new System.Drawing.Size(338, 481);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_record);
            this.panel3.Controls.Add(this.btn_recorder);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 509);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1368, 39);
            this.panel3.TabIndex = 0;
            // 
            // btn_record
            // 
            this.btn_record.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_record.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_record.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_record.Font = new System.Drawing.Font("Georgia", 8F);
            this.btn_record.ForeColor = System.Drawing.Color.Red;
            this.btn_record.Location = new System.Drawing.Point(1164, 0);
            this.btn_record.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btn_record.Name = "btn_record";
            this.btn_record.Size = new System.Drawing.Size(102, 39);
            this.btn_record.TabIndex = 1;
            this.btn_record.Text = "Record";
            this.btn_record.UseVisualStyleBackColor = false;
            this.btn_record.Click += new System.EventHandler(this.btn_record_Click);
            // 
            // btn_recorder
            // 
            this.btn_recorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_recorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_recorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_recorder.Font = new System.Drawing.Font("Georgia", 8F);
            this.btn_recorder.ForeColor = System.Drawing.Color.Red;
            this.btn_recorder.Location = new System.Drawing.Point(1266, 0);
            this.btn_recorder.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btn_recorder.Name = "btn_recorder";
            this.btn_recorder.Size = new System.Drawing.Size(102, 39);
            this.btn_recorder.TabIndex = 0;
            this.btn_recorder.Text = "Start";
            this.btn_recorder.UseVisualStyleBackColor = false;
            // 
            // timer_voice_freq
            // 
            this.timer_voice_freq.Enabled = true;
            this.timer_voice_freq.Interval = 10;
            this.timer_voice_freq.Tick += new System.EventHandler(this.timer_voice_freq_Tick);
            // 
            // pb_fft_type
            // 
            this.pb_fft_type.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pb_fft_type.Dock = System.Windows.Forms.DockStyle.Top;
            this.pb_fft_type.Image = ((System.Drawing.Image)(resources.GetObject("pb_fft_type.Image")));
            this.pb_fft_type.Location = new System.Drawing.Point(0, 196);
            this.pb_fft_type.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_fft_type.Name = "pb_fft_type";
            this.pb_fft_type.Size = new System.Drawing.Size(1020, 196);
            this.pb_fft_type.TabIndex = 1;
            this.pb_fft_type.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1368, 548);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_eqo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nimaColorPicker1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_fft_type)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_recorder;
        private EqoPicturebox pb_eqo;
        private System.Windows.Forms.Timer timer_voice_freq;
        private System.Windows.Forms.Button btn_record;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private NimaColorPicker nimaColorPicker1;
        private EqoPicturebox pb_fft_type;
    }
}

