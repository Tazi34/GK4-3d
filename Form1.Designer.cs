namespace GK_4
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.shadingLabel = new System.Windows.Forms.Label();
            this.constantShadingRadioButton = new System.Windows.Forms.RadioButton();
            this.gouraudShadingRadioButton = new System.Windows.Forms.RadioButton();
            this.phongShadingRadioButton = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cameraLabel = new System.Windows.Forms.Label();
            this.stationaryCameraRadioButton = new System.Windows.Forms.RadioButton();
            this.followingCameraRadioButton = new System.Windows.Forms.RadioButton();
            this.movingCameraRadioButton = new System.Windows.Forms.RadioButton();
            this.cameraPoistionContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.xNumeric = new System.Windows.Forms.NumericUpDown();
            this.yNumeric = new System.Windows.Forms.NumericUpDown();
            this.zNumeric = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.cameraPoistionContainer.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.xNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.yNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.zNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 231F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 644F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(915, 647);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(350, 346);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(669, 635);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.cameraPoistionContainer);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(684, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(225, 635);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.shadingLabel);
            this.flowLayoutPanel3.Controls.Add(this.constantShadingRadioButton);
            this.flowLayoutPanel3.Controls.Add(this.gouraudShadingRadioButton);
            this.flowLayoutPanel3.Controls.Add(this.phongShadingRadioButton);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.MinimumSize = new System.Drawing.Size(175, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(175, 164);
            this.flowLayoutPanel3.TabIndex = 13;
            // 
            // shadingLabel
            // 
            this.shadingLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shadingLabel.Location = new System.Drawing.Point(3, 0);
            this.shadingLabel.MaximumSize = new System.Drawing.Size(175, 35);
            this.shadingLabel.MinimumSize = new System.Drawing.Size(70, 35);
            this.shadingLabel.Name = "shadingLabel";
            this.shadingLabel.Size = new System.Drawing.Size(140, 35);
            this.shadingLabel.TabIndex = 19;
            this.shadingLabel.Text = "Shading:";
            this.shadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // constantShadingRadioButton
            // 
            this.constantShadingRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.constantShadingRadioButton.Location = new System.Drawing.Point(3, 38);
            this.constantShadingRadioButton.MaximumSize = new System.Drawing.Size(175, 35);
            this.constantShadingRadioButton.MinimumSize = new System.Drawing.Size(70, 35);
            this.constantShadingRadioButton.Name = "constantShadingRadioButton";
            this.constantShadingRadioButton.Size = new System.Drawing.Size(140, 35);
            this.constantShadingRadioButton.TabIndex = 17;
            this.constantShadingRadioButton.TabStop = true;
            this.constantShadingRadioButton.Text = "Constant";
            this.constantShadingRadioButton.UseVisualStyleBackColor = true;
            this.constantShadingRadioButton.CheckedChanged +=
                new System.EventHandler(this.constantShadingRadioButton_CheckedChanged);
            // 
            // gouraudShadingRadioButton
            // 
            this.gouraudShadingRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gouraudShadingRadioButton.Location = new System.Drawing.Point(3, 79);
            this.gouraudShadingRadioButton.MaximumSize = new System.Drawing.Size(175, 35);
            this.gouraudShadingRadioButton.MinimumSize = new System.Drawing.Size(70, 35);
            this.gouraudShadingRadioButton.Name = "gouraudShadingRadioButton";
            this.gouraudShadingRadioButton.Size = new System.Drawing.Size(140, 35);
            this.gouraudShadingRadioButton.TabIndex = 16;
            this.gouraudShadingRadioButton.TabStop = true;
            this.gouraudShadingRadioButton.Text = "Gouraud";
            this.gouraudShadingRadioButton.UseVisualStyleBackColor = true;
            this.gouraudShadingRadioButton.CheckedChanged +=
                new System.EventHandler(this.gouraudShadingRadioButton_CheckedChanged);
            // 
            // phongShadingRadioButton
            // 
            this.phongShadingRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phongShadingRadioButton.Location = new System.Drawing.Point(3, 120);
            this.phongShadingRadioButton.MaximumSize = new System.Drawing.Size(175, 35);
            this.phongShadingRadioButton.MinimumSize = new System.Drawing.Size(70, 35);
            this.phongShadingRadioButton.Name = "phongShadingRadioButton";
            this.phongShadingRadioButton.Size = new System.Drawing.Size(140, 35);
            this.phongShadingRadioButton.TabIndex = 15;
            this.phongShadingRadioButton.TabStop = true;
            this.phongShadingRadioButton.Text = "Phong";
            this.phongShadingRadioButton.UseVisualStyleBackColor = true;
            this.phongShadingRadioButton.CheckedChanged +=
                new System.EventHandler(this.phongShadingRadioButton_CheckedChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.cameraLabel);
            this.flowLayoutPanel2.Controls.Add(this.stationaryCameraRadioButton);
            this.flowLayoutPanel2.Controls.Add(this.followingCameraRadioButton);
            this.flowLayoutPanel2.Controls.Add(this.movingCameraRadioButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 173);
            this.flowLayoutPanel2.MinimumSize = new System.Drawing.Size(175, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(175, 164);
            this.flowLayoutPanel2.TabIndex = 14;
            // 
            // cameraLabel
            // 
            this.cameraLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraLabel.Location = new System.Drawing.Point(3, 0);
            this.cameraLabel.MaximumSize = new System.Drawing.Size(175, 35);
            this.cameraLabel.MinimumSize = new System.Drawing.Size(70, 35);
            this.cameraLabel.Name = "cameraLabel";
            this.cameraLabel.Size = new System.Drawing.Size(140, 35);
            this.cameraLabel.TabIndex = 19;
            this.cameraLabel.Text = "Camera:";
            this.cameraLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stationaryCameraRadioButton
            // 
            this.stationaryCameraRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stationaryCameraRadioButton.Location = new System.Drawing.Point(3, 38);
            this.stationaryCameraRadioButton.MaximumSize = new System.Drawing.Size(175, 35);
            this.stationaryCameraRadioButton.MinimumSize = new System.Drawing.Size(70, 35);
            this.stationaryCameraRadioButton.Name = "stationaryCameraRadioButton";
            this.stationaryCameraRadioButton.Size = new System.Drawing.Size(140, 35);
            this.stationaryCameraRadioButton.TabIndex = 17;
            this.stationaryCameraRadioButton.TabStop = true;
            this.stationaryCameraRadioButton.Text = "Stationary";
            this.stationaryCameraRadioButton.UseVisualStyleBackColor = true;
            this.stationaryCameraRadioButton.CheckedChanged +=
                new System.EventHandler(this.stationaryCameraRadioButton_CheckedChanged);
            // 
            // followingCameraRadioButton
            // 
            this.followingCameraRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.followingCameraRadioButton.Location = new System.Drawing.Point(3, 79);
            this.followingCameraRadioButton.MaximumSize = new System.Drawing.Size(175, 35);
            this.followingCameraRadioButton.MinimumSize = new System.Drawing.Size(70, 35);
            this.followingCameraRadioButton.Name = "followingCameraRadioButton";
            this.followingCameraRadioButton.Size = new System.Drawing.Size(140, 35);
            this.followingCameraRadioButton.TabIndex = 16;
            this.followingCameraRadioButton.TabStop = true;
            this.followingCameraRadioButton.Text = "Following";
            this.followingCameraRadioButton.UseVisualStyleBackColor = true;
            this.followingCameraRadioButton.CheckedChanged +=
                new System.EventHandler(this.followingCameraRadioButton_CheckedChanged);
            // 
            // movingCameraRadioButton
            // 
            this.movingCameraRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.movingCameraRadioButton.Location = new System.Drawing.Point(3, 120);
            this.movingCameraRadioButton.MaximumSize = new System.Drawing.Size(175, 35);
            this.movingCameraRadioButton.MinimumSize = new System.Drawing.Size(70, 35);
            this.movingCameraRadioButton.Name = "movingCameraRadioButton";
            this.movingCameraRadioButton.Size = new System.Drawing.Size(140, 35);
            this.movingCameraRadioButton.TabIndex = 15;
            this.movingCameraRadioButton.TabStop = true;
            this.movingCameraRadioButton.Text = "Moving";
            this.movingCameraRadioButton.UseVisualStyleBackColor = true;
            this.movingCameraRadioButton.CheckedChanged +=
                new System.EventHandler(this.movingCameraRadioButton_CheckedChanged);
            // 
            // cameraPoistionContainer
            // 
            this.cameraPoistionContainer.Controls.Add(this.label4);
            this.cameraPoistionContainer.Controls.Add(this.tableLayoutPanel3);
            this.cameraPoistionContainer.Location = new System.Drawing.Point(3, 343);
            this.cameraPoistionContainer.MinimumSize = new System.Drawing.Size(175, 0);
            this.cameraPoistionContainer.Name = "cameraPoistionContainer";
            this.cameraPoistionContainer.Size = new System.Drawing.Size(175, 136);
            this.cameraPoistionContainer.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.MaximumSize = new System.Drawing.Size(175, 35);
            this.label4.MinimumSize = new System.Drawing.Size(70, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 35);
            this.label4.TabIndex = 20;
            this.label4.Text = "Position:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.xNumeric, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.yNumeric, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.zNumeric, 1, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(168, 85);
            this.tableLayoutPanel3.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "y";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "z";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "x";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xNumeric
            // 
            this.xNumeric.Location = new System.Drawing.Point(53, 3);
            this.xNumeric.Minimum = new decimal(new int[] {100, 0, 0, -2147483648});
            this.xNumeric.Name = "xNumeric";
            this.xNumeric.Size = new System.Drawing.Size(111, 23);
            this.xNumeric.TabIndex = 3;
            this.xNumeric.ValueChanged += new System.EventHandler(this.xNumeric_ValueChanged);
            // 
            // yNumeric
            // 
            this.yNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yNumeric.Location = new System.Drawing.Point(53, 32);
            this.yNumeric.Minimum = new decimal(new int[] {100, 0, 0, -2147483648});
            this.yNumeric.Name = "yNumeric";
            this.yNumeric.Size = new System.Drawing.Size(112, 23);
            this.yNumeric.TabIndex = 4;
            this.yNumeric.ValueChanged += new System.EventHandler(this.yNumeric_ValueChanged);
            // 
            // zNumeric
            // 
            this.zNumeric.Location = new System.Drawing.Point(53, 61);
            this.zNumeric.Minimum = new decimal(new int[] {100, 0, 0, -2147483648});
            this.zNumeric.Name = "zNumeric";
            this.zNumeric.Size = new System.Drawing.Size(111, 23);
            this.zNumeric.TabIndex = 5;
            this.zNumeric.ValueChanged += new System.EventHandler(this.zNumeric_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 647);
            this.Controls.Add(this.tableLayoutPanel2);
            this.MaximumSize = new System.Drawing.Size(1397, 1032);
            this.MinimumSize = new System.Drawing.Size(931, 686);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.cameraPoistionContainer.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.xNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.yNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.zNumeric)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label shadingLabel;
        private System.Windows.Forms.RadioButton constantShadingRadioButton;
        private System.Windows.Forms.RadioButton gouraudShadingRadioButton;
        private System.Windows.Forms.RadioButton phongShadingRadioButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label cameraLabel;
        private System.Windows.Forms.RadioButton stationaryCameraRadioButton;
        private System.Windows.Forms.RadioButton followingCameraRadioButton;
        private System.Windows.Forms.RadioButton movingCameraRadioButton;
        private System.Windows.Forms.FlowLayoutPanel cameraPoistionContainer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown zNumeric;
        private System.Windows.Forms.NumericUpDown yNumeric;
        private System.Windows.Forms.NumericUpDown xNumeric;
        private System.Windows.Forms.Button button1;
    }
}

