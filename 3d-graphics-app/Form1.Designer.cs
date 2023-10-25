using System.Windows.Forms;

namespace _3d_graphics_app
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
      this.canva = new System.Windows.Forms.PictureBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.ControllsGrpBox = new System.Windows.Forms.GroupBox();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.panel7 = new System.Windows.Forms.Panel();
      this.mTrackBar = new System.Windows.Forms.TrackBar();
      this.label6 = new System.Windows.Forms.Label();
      this.panel6 = new System.Windows.Forms.Panel();
      this.kdTrackBar = new System.Windows.Forms.TrackBar();
      this.label5 = new System.Windows.Forms.Label();
      this.panel5 = new System.Windows.Forms.Panel();
      this.ksTrackBar = new System.Windows.Forms.TrackBar();
      this.label4 = new System.Windows.Forms.Label();
      this.panel4 = new System.Windows.Forms.Panel();
      this.kaTrackBar = new System.Windows.Forms.TrackBar();
      this.label3 = new System.Windows.Forms.Label();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.RightBttn = new System.Windows.Forms.Button();
      this.DownBttn = new System.Windows.Forms.Button();
      this.LeftBttn = new System.Windows.Forms.Button();
      this.UpBttn = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.dynamicCameraRadioBtn = new System.Windows.Forms.RadioButton();
      this.staticCameraRadioBtn = new System.Windows.Forms.RadioButton();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.panel3 = new System.Windows.Forms.Panel();
      this.fogMaxTrackBar = new System.Windows.Forms.TrackBar();
      this.label2 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.fogMinTrackBar = new System.Windows.Forms.TrackBar();
      this.label1 = new System.Windows.Forms.Label();
      this.dayRdioBttn = new System.Windows.Forms.RadioButton();
      this.nightRdioBttn = new System.Windows.Forms.RadioButton();
      this.animationTimer = new System.Windows.Forms.Timer(this.components);
      this.fovNumericUpDown = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this.canva)).BeginInit();
      this.panel1.SuspendLayout();
      this.ControllsGrpBox.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.panel7.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).BeginInit();
      this.panel6.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).BeginInit();
      this.panel5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).BeginInit();
      this.panel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.kaTrackBar)).BeginInit();
      this.groupBox3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.panel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.fogMaxTrackBar)).BeginInit();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.fogMinTrackBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.fovNumericUpDown)).BeginInit();
      this.SuspendLayout();
      // 
      // canva
      // 
      this.canva.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
      this.canva.Location = new System.Drawing.Point(0, 0);
      this.canva.Name = "canva";
      this.canva.Size = new System.Drawing.Size(502, 442);
      this.canva.TabIndex = 0;
      this.canva.TabStop = false;
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.Controls.Add(this.canva);
      this.panel1.Location = new System.Drawing.Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(547, 446);
      this.panel1.TabIndex = 1;
      // 
      // ControllsGrpBox
      // 
      this.ControllsGrpBox.Controls.Add(this.groupBox4);
      this.ControllsGrpBox.Controls.Add(this.groupBox3);
      this.ControllsGrpBox.Controls.Add(this.groupBox2);
      this.ControllsGrpBox.Controls.Add(this.groupBox1);
      this.ControllsGrpBox.Dock = System.Windows.Forms.DockStyle.Right;
      this.ControllsGrpBox.Location = new System.Drawing.Point(553, 0);
      this.ControllsGrpBox.Name = "ControllsGrpBox";
      this.ControllsGrpBox.Size = new System.Drawing.Size(247, 450);
      this.ControllsGrpBox.TabIndex = 2;
      this.ControllsGrpBox.TabStop = false;
      this.ControllsGrpBox.Text = "Controlls";
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.panel7);
      this.groupBox4.Controls.Add(this.panel6);
      this.groupBox4.Controls.Add(this.panel5);
      this.groupBox4.Controls.Add(this.panel4);
      this.groupBox4.Location = new System.Drawing.Point(6, 344);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(223, 100);
      this.groupBox4.TabIndex = 3;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Light";
      // 
      // panel7
      // 
      this.panel7.Controls.Add(this.mTrackBar);
      this.panel7.Controls.Add(this.label6);
      this.panel7.Location = new System.Drawing.Point(121, 21);
      this.panel7.Name = "panel7";
      this.panel7.Size = new System.Drawing.Size(99, 24);
      this.panel7.TabIndex = 7;
      // 
      // mTrackBar
      // 
      this.mTrackBar.Dock = System.Windows.Forms.DockStyle.Right;
      this.mTrackBar.Location = new System.Drawing.Point(16, 0);
      this.mTrackBar.Maximum = 100;
      this.mTrackBar.Name = "mTrackBar";
      this.mTrackBar.Size = new System.Drawing.Size(83, 24);
      this.mTrackBar.TabIndex = 1;
      this.mTrackBar.Value = 10;
      this.mTrackBar.Scroll += new System.EventHandler(this.mTrackBar_Scroll);
      // 
      // label6
      // 
      this.label6.Dock = System.Windows.Forms.DockStyle.Left;
      this.label6.Location = new System.Drawing.Point(0, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(31, 24);
      this.label6.TabIndex = 0;
      this.label6.Text = "M";
      // 
      // panel6
      // 
      this.panel6.Controls.Add(this.kdTrackBar);
      this.panel6.Controls.Add(this.label5);
      this.panel6.Location = new System.Drawing.Point(9, 70);
      this.panel6.Name = "panel6";
      this.panel6.Size = new System.Drawing.Size(106, 24);
      this.panel6.TabIndex = 6;
      // 
      // kdTrackBar
      // 
      this.kdTrackBar.Dock = System.Windows.Forms.DockStyle.Right;
      this.kdTrackBar.Location = new System.Drawing.Point(23, 0);
      this.kdTrackBar.Maximum = 100;
      this.kdTrackBar.Name = "kdTrackBar";
      this.kdTrackBar.Size = new System.Drawing.Size(83, 24);
      this.kdTrackBar.TabIndex = 1;
      this.kdTrackBar.Value = 10;
      this.kdTrackBar.Scroll += new System.EventHandler(this.kdTrackBar_Scroll);
      // 
      // label5
      // 
      this.label5.Dock = System.Windows.Forms.DockStyle.Left;
      this.label5.Location = new System.Drawing.Point(0, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(34, 24);
      this.label5.TabIndex = 0;
      this.label5.Text = "Kd";
      // 
      // panel5
      // 
      this.panel5.Controls.Add(this.ksTrackBar);
      this.panel5.Controls.Add(this.label4);
      this.panel5.Location = new System.Drawing.Point(6, 48);
      this.panel5.Name = "panel5";
      this.panel5.Size = new System.Drawing.Size(106, 24);
      this.panel5.TabIndex = 5;
      // 
      // ksTrackBar
      // 
      this.ksTrackBar.Dock = System.Windows.Forms.DockStyle.Right;
      this.ksTrackBar.Location = new System.Drawing.Point(26, 0);
      this.ksTrackBar.Maximum = 100;
      this.ksTrackBar.Name = "ksTrackBar";
      this.ksTrackBar.Size = new System.Drawing.Size(80, 24);
      this.ksTrackBar.TabIndex = 1;
      this.ksTrackBar.Value = 10;
      this.ksTrackBar.Scroll += new System.EventHandler(this.ksTrackBar_Scroll);
      // 
      // label4
      // 
      this.label4.Dock = System.Windows.Forms.DockStyle.Left;
      this.label4.Location = new System.Drawing.Point(0, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(37, 24);
      this.label4.TabIndex = 0;
      this.label4.Text = "Ks";
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.kaTrackBar);
      this.panel4.Controls.Add(this.label3);
      this.panel4.Location = new System.Drawing.Point(6, 21);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(109, 24);
      this.panel4.TabIndex = 4;
      // 
      // kaTrackBar
      // 
      this.kaTrackBar.Dock = System.Windows.Forms.DockStyle.Right;
      this.kaTrackBar.Location = new System.Drawing.Point(26, 0);
      this.kaTrackBar.Maximum = 100;
      this.kaTrackBar.Name = "kaTrackBar";
      this.kaTrackBar.Size = new System.Drawing.Size(83, 24);
      this.kaTrackBar.TabIndex = 1;
      this.kaTrackBar.Value = 2;
      this.kaTrackBar.Scroll += new System.EventHandler(this.kaTrackBar_Scroll);
      // 
      // label3
      // 
      this.label3.Dock = System.Windows.Forms.DockStyle.Left;
      this.label3.Location = new System.Drawing.Point(0, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(65, 24);
      this.label3.TabIndex = 0;
      this.label3.Text = "Ka";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.RightBttn);
      this.groupBox3.Controls.Add(this.DownBttn);
      this.groupBox3.Controls.Add(this.LeftBttn);
      this.groupBox3.Controls.Add(this.UpBttn);
      this.groupBox3.Location = new System.Drawing.Point(3, 236);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(232, 100);
      this.groupBox3.TabIndex = 2;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Object Control";
      // 
      // RightBttn
      // 
      this.RightBttn.Location = new System.Drawing.Point(151, 50);
      this.RightBttn.Name = "RightBttn";
      this.RightBttn.Size = new System.Drawing.Size(75, 23);
      this.RightBttn.TabIndex = 3;
      this.RightBttn.Text = "Right";
      this.RightBttn.UseVisualStyleBackColor = true;
      this.RightBttn.Click += new System.EventHandler(this.RightBttn_Click);
      // 
      // DownBttn
      // 
      this.DownBttn.Location = new System.Drawing.Point(77, 77);
      this.DownBttn.Name = "DownBttn";
      this.DownBttn.Size = new System.Drawing.Size(75, 23);
      this.DownBttn.TabIndex = 2;
      this.DownBttn.Text = "Down";
      this.DownBttn.UseVisualStyleBackColor = true;
      this.DownBttn.Click += new System.EventHandler(this.DownBttn_Click);
      // 
      // LeftBttn
      // 
      this.LeftBttn.Location = new System.Drawing.Point(3, 50);
      this.LeftBttn.Name = "LeftBttn";
      this.LeftBttn.Size = new System.Drawing.Size(75, 23);
      this.LeftBttn.TabIndex = 1;
      this.LeftBttn.Text = "Left";
      this.LeftBttn.UseVisualStyleBackColor = true;
      this.LeftBttn.Click += new System.EventHandler(this.LeftBttn_Click);
      // 
      // UpBttn
      // 
      this.UpBttn.Location = new System.Drawing.Point(77, 21);
      this.UpBttn.Name = "UpBttn";
      this.UpBttn.Size = new System.Drawing.Size(75, 23);
      this.UpBttn.TabIndex = 0;
      this.UpBttn.Text = "Up";
      this.UpBttn.UseVisualStyleBackColor = true;
      this.UpBttn.Click += new System.EventHandler(this.UpBttn_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.fovNumericUpDown);
      this.groupBox2.Controls.Add(this.dynamicCameraRadioBtn);
      this.groupBox2.Controls.Add(this.staticCameraRadioBtn);
      this.groupBox2.Location = new System.Drawing.Point(6, 149);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(229, 81);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Camera";
      // 
      // dynamicCameraRadioBtn
      // 
      this.dynamicCameraRadioBtn.Location = new System.Drawing.Point(6, 51);
      this.dynamicCameraRadioBtn.Name = "dynamicCameraRadioBtn";
      this.dynamicCameraRadioBtn.Size = new System.Drawing.Size(123, 24);
      this.dynamicCameraRadioBtn.TabIndex = 1;
      this.dynamicCameraRadioBtn.Tag = "cameraOpt";
      this.dynamicCameraRadioBtn.Text = "Dynamic";
      this.dynamicCameraRadioBtn.UseVisualStyleBackColor = true;
      this.dynamicCameraRadioBtn.CheckedChanged += new System.EventHandler(this.dynamicCameraRadioBtn_CheckedChanged_1);
      // 
      // staticCameraRadioBtn
      // 
      this.staticCameraRadioBtn.Checked = true;
      this.staticCameraRadioBtn.Location = new System.Drawing.Point(6, 21);
      this.staticCameraRadioBtn.Name = "staticCameraRadioBtn";
      this.staticCameraRadioBtn.Size = new System.Drawing.Size(123, 24);
      this.staticCameraRadioBtn.TabIndex = 0;
      this.staticCameraRadioBtn.TabStop = true;
      this.staticCameraRadioBtn.Tag = "cameraOpt";
      this.staticCameraRadioBtn.Text = "Static Camera";
      this.staticCameraRadioBtn.UseVisualStyleBackColor = true;
      this.staticCameraRadioBtn.CheckedChanged += new System.EventHandler(this.staticCameraRadioBtn_CheckedChanged_1);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.panel3);
      this.groupBox1.Controls.Add(this.panel2);
      this.groupBox1.Controls.Add(this.dayRdioBttn);
      this.groupBox1.Controls.Add(this.nightRdioBttn);
      this.groupBox1.Location = new System.Drawing.Point(6, 21);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(187, 122);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Weather";
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.fogMaxTrackBar);
      this.panel3.Controls.Add(this.label2);
      this.panel3.Location = new System.Drawing.Point(6, 81);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(175, 24);
      this.panel3.TabIndex = 3;
      // 
      // fogMaxTrackBar
      // 
      this.fogMaxTrackBar.Dock = System.Windows.Forms.DockStyle.Right;
      this.fogMaxTrackBar.Location = new System.Drawing.Point(92, 0);
      this.fogMaxTrackBar.Maximum = 50;
      this.fogMaxTrackBar.Name = "fogMaxTrackBar";
      this.fogMaxTrackBar.Size = new System.Drawing.Size(83, 24);
      this.fogMaxTrackBar.TabIndex = 1;
      this.fogMaxTrackBar.Value = 15;
      this.fogMaxTrackBar.Scroll += new System.EventHandler(this.fogMaxTrackBar_Scroll);
      // 
      // label2
      // 
      this.label2.Dock = System.Windows.Forms.DockStyle.Left;
      this.label2.Location = new System.Drawing.Point(0, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(65, 24);
      this.label2.TabIndex = 0;
      this.label2.Text = "fog Max";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.fogMinTrackBar);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Location = new System.Drawing.Point(6, 51);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(175, 24);
      this.panel2.TabIndex = 2;
      // 
      // fogMinTrackBar
      // 
      this.fogMinTrackBar.Dock = System.Windows.Forms.DockStyle.Right;
      this.fogMinTrackBar.Location = new System.Drawing.Point(92, 0);
      this.fogMinTrackBar.Maximum = 50;
      this.fogMinTrackBar.Name = "fogMinTrackBar";
      this.fogMinTrackBar.Size = new System.Drawing.Size(83, 24);
      this.fogMinTrackBar.TabIndex = 1;
      this.fogMinTrackBar.Value = 13;
      this.fogMinTrackBar.Scroll += new System.EventHandler(this.fogMinTrackBar_Scroll);
      // 
      // label1
      // 
      this.label1.Dock = System.Windows.Forms.DockStyle.Left;
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(65, 24);
      this.label1.TabIndex = 0;
      this.label1.Text = "fog Min";
      // 
      // dayRdioBttn
      // 
      this.dayRdioBttn.Location = new System.Drawing.Point(6, 21);
      this.dayRdioBttn.Name = "dayRdioBttn";
      this.dayRdioBttn.Size = new System.Drawing.Size(77, 24);
      this.dayRdioBttn.TabIndex = 1;
      this.dayRdioBttn.TabStop = true;
      this.dayRdioBttn.Tag = "daySetting";
      this.dayRdioBttn.Text = "Day";
      this.dayRdioBttn.UseVisualStyleBackColor = true;
      this.dayRdioBttn.CheckedChanged += new System.EventHandler(this.dayRdioBttn_CheckedChanged_1);
      // 
      // nightRdioBttn
      // 
      this.nightRdioBttn.Location = new System.Drawing.Point(89, 21);
      this.nightRdioBttn.Name = "nightRdioBttn";
      this.nightRdioBttn.Size = new System.Drawing.Size(79, 24);
      this.nightRdioBttn.TabIndex = 0;
      this.nightRdioBttn.TabStop = true;
      this.nightRdioBttn.Tag = "daySetting";
      this.nightRdioBttn.Text = "Night";
      this.nightRdioBttn.UseVisualStyleBackColor = true;
      this.nightRdioBttn.CheckedChanged += new System.EventHandler(this.nightRdioBttn_CheckedChanged_1);
      // 
      // animationTimer
      // 
      this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick_1);
      // 
      // fovNumericUpDown
      // 
      this.fovNumericUpDown.Increment = new decimal(new int[] { 5, 0, 0, 0 });
      this.fovNumericUpDown.Location = new System.Drawing.Point(148, 38);
      this.fovNumericUpDown.Minimum = new decimal(new int[] { 45, 0, 0, 0 });
      this.fovNumericUpDown.Name = "fovNumericUpDown";
      this.fovNumericUpDown.Size = new System.Drawing.Size(72, 22);
      this.fovNumericUpDown.TabIndex = 2;
      this.fovNumericUpDown.Value = new decimal(new int[] { 45, 0, 0, 0 });
      this.fovNumericUpDown.ValueChanged += new System.EventHandler(this.fovNumericUpDown_ValueChanged);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.ControllsGrpBox);
      this.Controls.Add(this.panel1);
      this.Location = new System.Drawing.Point(15, 15);
      this.Name = "Form1";
      this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
      this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.canva)).EndInit();
      this.panel1.ResumeLayout(false);
      this.ControllsGrpBox.ResumeLayout(false);
      this.groupBox4.ResumeLayout(false);
      this.panel7.ResumeLayout(false);
      this.panel7.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).EndInit();
      this.panel6.ResumeLayout(false);
      this.panel6.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).EndInit();
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).EndInit();
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.kaTrackBar)).EndInit();
      this.groupBox3.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.fogMaxTrackBar)).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.fogMinTrackBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.fovNumericUpDown)).EndInit();
      this.ResumeLayout(false);
    }

    private System.Windows.Forms.NumericUpDown fovNumericUpDown;

    private System.Windows.Forms.Panel panel7;
    private System.Windows.Forms.TrackBar mTrackBar;
    private System.Windows.Forms.Label label6;

    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.TrackBar kaTrackBar;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.TrackBar ksTrackBar;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Panel panel6;
    private System.Windows.Forms.TrackBar kdTrackBar;
    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Button UpBttn;
    private System.Windows.Forms.Button LeftBttn;
    private System.Windows.Forms.Button DownBttn;
    private System.Windows.Forms.Button RightBttn;

    private System.Windows.Forms.RadioButton dynamicCameraRadioBtn;

    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.RadioButton staticCameraRadioBtn;

    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.TrackBar fogMaxTrackBar;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.TrackBar fogMinTrackBar;

    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton nightRdioBttn;
    private System.Windows.Forms.RadioButton dayRdioBttn;

    private System.Windows.Forms.Timer animationTimer;
    
    private System.Windows.Forms.GroupBox ControllsGrpBox;

    private System.Windows.Forms.Panel panel1;

    private System.Windows.Forms.PictureBox canva;

    #endregion

  }
}

