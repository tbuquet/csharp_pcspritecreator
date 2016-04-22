namespace PCSpriteCreator
{
    partial class Main
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
            this.grpRender = new System.Windows.Forms.GroupBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.ddpHeight = new System.Windows.Forms.NumericUpDown();
            this.ddpWidth = new System.Windows.Forms.NumericUpDown();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.ddpPosY = new System.Windows.Forms.NumericUpDown();
            this.ddpPosX = new System.Windows.Forms.NumericUpDown();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnCenter = new System.Windows.Forms.Button();
            this.AnimPreview = new System.Windows.Forms.PictureBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSaveAnimation = new System.Windows.Forms.Button();
            this.btnLoadAnimation = new System.Windows.Forms.Button();
            this.btnNewAnimation = new System.Windows.Forms.Button();
            this.grpDirections = new System.Windows.Forms.GroupBox();
            this.rad8Directions = new System.Windows.Forms.RadioButton();
            this.rad4Directions = new System.Windows.Forms.RadioButton();
            this.txtCharacterName = new System.Windows.Forms.TextBox();
            this.grpCharacterName = new System.Windows.Forms.GroupBox();
            this.grpAnimationName = new System.Windows.Forms.GroupBox();
            this.txtAnimationName = new System.Windows.Forms.TextBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.listUpLeft = new PCSpriteCreator.ListDirection();
            this.listDownLeft = new PCSpriteCreator.ListDirection();
            this.listDownRight = new PCSpriteCreator.ListDirection();
            this.listUpRight = new PCSpriteCreator.ListDirection();
            this.listLeft = new PCSpriteCreator.ListDirection();
            this.listDown = new PCSpriteCreator.ListDirection();
            this.listRight = new PCSpriteCreator.ListDirection();
            this.listUp = new PCSpriteCreator.ListDirection();
            this.grpRender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddpHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddpWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddpPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddpPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimPreview)).BeginInit();
            this.grpDirections.SuspendLayout();
            this.grpCharacterName.SuspendLayout();
            this.grpAnimationName.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRender
            // 
            this.grpRender.Controls.Add(this.lblHeight);
            this.grpRender.Controls.Add(this.lblWidth);
            this.grpRender.Controls.Add(this.ddpHeight);
            this.grpRender.Controls.Add(this.ddpWidth);
            this.grpRender.Controls.Add(this.lblY);
            this.grpRender.Controls.Add(this.lblX);
            this.grpRender.Controls.Add(this.ddpPosY);
            this.grpRender.Controls.Add(this.ddpPosX);
            this.grpRender.Controls.Add(this.btnRight);
            this.grpRender.Controls.Add(this.btnDown);
            this.grpRender.Controls.Add(this.btnPreview);
            this.grpRender.Controls.Add(this.btnCenter);
            this.grpRender.Controls.Add(this.AnimPreview);
            this.grpRender.Controls.Add(this.btnUp);
            this.grpRender.Controls.Add(this.button1);
            this.grpRender.Location = new System.Drawing.Point(442, 12);
            this.grpRender.Name = "grpRender";
            this.grpRender.Size = new System.Drawing.Size(312, 387);
            this.grpRender.TabIndex = 0;
            this.grpRender.TabStop = false;
            this.grpRender.Text = "Render";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(137, 365);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(13, 13);
            this.lblHeight.TabIndex = 15;
            this.lblHeight.Text = "h";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(63, 365);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(15, 13);
            this.lblWidth.TabIndex = 14;
            this.lblWidth.Text = "w";
            // 
            // ddpHeight
            // 
            this.ddpHeight.Location = new System.Drawing.Point(78, 361);
            this.ddpHeight.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.ddpHeight.Name = "ddpHeight";
            this.ddpHeight.Size = new System.Drawing.Size(53, 20);
            this.ddpHeight.TabIndex = 13;
            this.ddpHeight.ValueChanged += new System.EventHandler(this.ddpHeight_ValueChanged);
            // 
            // ddpWidth
            // 
            this.ddpWidth.Location = new System.Drawing.Point(6, 361);
            this.ddpWidth.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.ddpWidth.Name = "ddpWidth";
            this.ddpWidth.Size = new System.Drawing.Size(53, 20);
            this.ddpWidth.TabIndex = 12;
            this.ddpWidth.ValueChanged += new System.EventHandler(this.ddpWidth_ValueChanged);
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(137, 333);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(12, 13);
            this.lblY.TabIndex = 11;
            this.lblY.Text = "y";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(63, 333);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(12, 13);
            this.lblX.TabIndex = 10;
            this.lblX.Text = "x";
            // 
            // ddpPosY
            // 
            this.ddpPosY.Location = new System.Drawing.Point(78, 329);
            this.ddpPosY.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.ddpPosY.Minimum = new decimal(new int[] {
            1920,
            0,
            0,
            -2147483648});
            this.ddpPosY.Name = "ddpPosY";
            this.ddpPosY.Size = new System.Drawing.Size(53, 20);
            this.ddpPosY.TabIndex = 9;
            this.ddpPosY.ValueChanged += new System.EventHandler(this.ddpPosY_ValueChanged);
            // 
            // ddpPosX
            // 
            this.ddpPosX.Location = new System.Drawing.Point(6, 329);
            this.ddpPosX.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.ddpPosX.Minimum = new decimal(new int[] {
            1920,
            0,
            0,
            -2147483648});
            this.ddpPosX.Name = "ddpPosX";
            this.ddpPosX.Size = new System.Drawing.Size(53, 20);
            this.ddpPosX.TabIndex = 8;
            this.ddpPosX.ValueChanged += new System.EventHandler(this.ddpPosX_ValueChanged);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(258, 313);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(50, 20);
            this.btnRight.TabIndex = 6;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(209, 332);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(50, 20);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(6, 292);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(112, 25);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnCenter
            // 
            this.btnCenter.Location = new System.Drawing.Point(209, 313);
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.Size = new System.Drawing.Size(50, 20);
            this.btnCenter.TabIndex = 2;
            this.btnCenter.Text = "Center";
            this.btnCenter.UseVisualStyleBackColor = true;
            this.btnCenter.Click += new System.EventHandler(this.btnCenter_Click);
            // 
            // AnimPreview
            // 
            this.AnimPreview.Location = new System.Drawing.Point(3, 16);
            this.AnimPreview.Name = "AnimPreview";
            this.AnimPreview.Size = new System.Drawing.Size(306, 273);
            this.AnimPreview.TabIndex = 0;
            this.AnimPreview.TabStop = false;
            this.AnimPreview.DoubleClick += new System.EventHandler(this.AnimPreview_DoubleClick);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(209, 294);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(50, 20);
            this.btnUp.TabIndex = 4;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(160, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 20);
            this.button1.TabIndex = 7;
            this.button1.Text = "Left";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSaveAnimation
            // 
            this.btnSaveAnimation.Location = new System.Drawing.Point(654, 405);
            this.btnSaveAnimation.Name = "btnSaveAnimation";
            this.btnSaveAnimation.Size = new System.Drawing.Size(100, 30);
            this.btnSaveAnimation.TabIndex = 1;
            this.btnSaveAnimation.Text = "Save animation";
            this.btnSaveAnimation.UseVisualStyleBackColor = true;
            this.btnSaveAnimation.Click += new System.EventHandler(this.btnSaveAnimation_Click);
            // 
            // btnLoadAnimation
            // 
            this.btnLoadAnimation.Location = new System.Drawing.Point(548, 405);
            this.btnLoadAnimation.Name = "btnLoadAnimation";
            this.btnLoadAnimation.Size = new System.Drawing.Size(100, 30);
            this.btnLoadAnimation.TabIndex = 2;
            this.btnLoadAnimation.Text = "Load animation";
            this.btnLoadAnimation.UseVisualStyleBackColor = true;
            this.btnLoadAnimation.Click += new System.EventHandler(this.btnLoadAnimation_Click);
            // 
            // btnNewAnimation
            // 
            this.btnNewAnimation.Location = new System.Drawing.Point(442, 405);
            this.btnNewAnimation.Name = "btnNewAnimation";
            this.btnNewAnimation.Size = new System.Drawing.Size(100, 30);
            this.btnNewAnimation.TabIndex = 3;
            this.btnNewAnimation.Text = "New animation";
            this.btnNewAnimation.UseVisualStyleBackColor = true;
            this.btnNewAnimation.Click += new System.EventHandler(this.btnNewAnimation_Click);
            // 
            // grpDirections
            // 
            this.grpDirections.Controls.Add(this.rad8Directions);
            this.grpDirections.Controls.Add(this.rad4Directions);
            this.grpDirections.Location = new System.Drawing.Point(12, 12);
            this.grpDirections.Name = "grpDirections";
            this.grpDirections.Size = new System.Drawing.Size(180, 50);
            this.grpDirections.TabIndex = 4;
            this.grpDirections.TabStop = false;
            this.grpDirections.Text = "Directions";
            // 
            // rad8Directions
            // 
            this.rad8Directions.AutoSize = true;
            this.rad8Directions.Enabled = false;
            this.rad8Directions.Location = new System.Drawing.Point(84, 19);
            this.rad8Directions.Name = "rad8Directions";
            this.rad8Directions.Size = new System.Drawing.Size(82, 17);
            this.rad8Directions.TabIndex = 1;
            this.rad8Directions.Text = " 8 directions";
            this.rad8Directions.UseVisualStyleBackColor = true;
            // 
            // rad4Directions
            // 
            this.rad4Directions.AutoSize = true;
            this.rad4Directions.Location = new System.Drawing.Point(6, 19);
            this.rad4Directions.Name = "rad4Directions";
            this.rad4Directions.Size = new System.Drawing.Size(79, 17);
            this.rad4Directions.TabIndex = 0;
            this.rad4Directions.Text = "4 directions";
            this.rad4Directions.UseVisualStyleBackColor = true;
            // 
            // txtCharacterName
            // 
            this.txtCharacterName.Location = new System.Drawing.Point(6, 18);
            this.txtCharacterName.Name = "txtCharacterName";
            this.txtCharacterName.Size = new System.Drawing.Size(107, 20);
            this.txtCharacterName.TabIndex = 2;
            this.txtCharacterName.TextChanged += new System.EventHandler(this.txtCharacterName_TextChanged);
            // 
            // grpCharacterName
            // 
            this.grpCharacterName.Controls.Add(this.txtCharacterName);
            this.grpCharacterName.Location = new System.Drawing.Point(198, 12);
            this.grpCharacterName.Name = "grpCharacterName";
            this.grpCharacterName.Size = new System.Drawing.Size(119, 50);
            this.grpCharacterName.TabIndex = 5;
            this.grpCharacterName.TabStop = false;
            this.grpCharacterName.Text = "Character name";
            // 
            // grpAnimationName
            // 
            this.grpAnimationName.Controls.Add(this.txtAnimationName);
            this.grpAnimationName.Location = new System.Drawing.Point(323, 12);
            this.grpAnimationName.Name = "grpAnimationName";
            this.grpAnimationName.Size = new System.Drawing.Size(113, 50);
            this.grpAnimationName.TabIndex = 6;
            this.grpAnimationName.TabStop = false;
            this.grpAnimationName.Text = "Animation name";
            // 
            // txtAnimationName
            // 
            this.txtAnimationName.Location = new System.Drawing.Point(6, 18);
            this.txtAnimationName.Name = "txtAnimationName";
            this.txtAnimationName.Size = new System.Drawing.Size(101, 20);
            this.txtAnimationName.TabIndex = 2;
            this.txtAnimationName.TextChanged += new System.EventHandler(this.txtAnimationName_TextChanged);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // listUpLeft
            // 
            this.listUpLeft.AllowDrop = true;
            this.listUpLeft.Label = "Up-Left";
            this.listUpLeft.Location = new System.Drawing.Point(330, 251);
            this.listUpLeft.Name = "listUpLeft";
            this.listUpLeft.SelectedAnim = null;
            this.listUpLeft.SelectedSprite = null;
            this.listUpLeft.Size = new System.Drawing.Size(100, 161);
            this.listUpLeft.Sprites = null;
            this.listUpLeft.TabIndex = 14;
            // 
            // listDownLeft
            // 
            this.listDownLeft.AllowDrop = true;
            this.listDownLeft.Label = "Down-Left";
            this.listDownLeft.Location = new System.Drawing.Point(224, 251);
            this.listDownLeft.Name = "listDownLeft";
            this.listDownLeft.SelectedAnim = null;
            this.listDownLeft.SelectedSprite = null;
            this.listDownLeft.Size = new System.Drawing.Size(100, 161);
            this.listDownLeft.Sprites = null;
            this.listDownLeft.TabIndex = 13;
            // 
            // listDownRight
            // 
            this.listDownRight.AllowDrop = true;
            this.listDownRight.Label = "Down-Right";
            this.listDownRight.Location = new System.Drawing.Point(118, 251);
            this.listDownRight.Name = "listDownRight";
            this.listDownRight.SelectedAnim = null;
            this.listDownRight.SelectedSprite = null;
            this.listDownRight.Size = new System.Drawing.Size(100, 161);
            this.listDownRight.Sprites = null;
            this.listDownRight.TabIndex = 12;
            // 
            // listUpRight
            // 
            this.listUpRight.AllowDrop = true;
            this.listUpRight.Label = "Up-Right";
            this.listUpRight.Location = new System.Drawing.Point(12, 251);
            this.listUpRight.Name = "listUpRight";
            this.listUpRight.SelectedAnim = null;
            this.listUpRight.SelectedSprite = null;
            this.listUpRight.Size = new System.Drawing.Size(100, 161);
            this.listUpRight.Sprites = null;
            this.listUpRight.TabIndex = 11;
            // 
            // listLeft
            // 
            this.listLeft.AllowDrop = true;
            this.listLeft.Label = "Left";
            this.listLeft.Location = new System.Drawing.Point(330, 82);
            this.listLeft.Name = "listLeft";
            this.listLeft.SelectedAnim = null;
            this.listLeft.SelectedSprite = null;
            this.listLeft.Size = new System.Drawing.Size(100, 163);
            this.listLeft.Sprites = null;
            this.listLeft.TabIndex = 10;
            // 
            // listDown
            // 
            this.listDown.AllowDrop = true;
            this.listDown.Label = "Down";
            this.listDown.Location = new System.Drawing.Point(224, 82);
            this.listDown.Name = "listDown";
            this.listDown.SelectedAnim = null;
            this.listDown.SelectedSprite = null;
            this.listDown.Size = new System.Drawing.Size(100, 163);
            this.listDown.Sprites = null;
            this.listDown.TabIndex = 9;
            // 
            // listRight
            // 
            this.listRight.AllowDrop = true;
            this.listRight.Label = "Right";
            this.listRight.Location = new System.Drawing.Point(118, 82);
            this.listRight.Name = "listRight";
            this.listRight.SelectedAnim = null;
            this.listRight.SelectedSprite = null;
            this.listRight.Size = new System.Drawing.Size(100, 163);
            this.listRight.Sprites = null;
            this.listRight.TabIndex = 8;
            // 
            // listUp
            // 
            this.listUp.AllowDrop = true;
            this.listUp.Label = "Up";
            this.listUp.Location = new System.Drawing.Point(12, 82);
            this.listUp.Name = "listUp";
            this.listUp.SelectedAnim = null;
            this.listUp.SelectedSprite = null;
            this.listUp.Size = new System.Drawing.Size(100, 163);
            this.listUp.Sprites = null;
            this.listUp.TabIndex = 7;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 445);
            this.Controls.Add(this.listUpLeft);
            this.Controls.Add(this.listDownLeft);
            this.Controls.Add(this.listDownRight);
            this.Controls.Add(this.listUpRight);
            this.Controls.Add(this.listLeft);
            this.Controls.Add(this.listDown);
            this.Controls.Add(this.listRight);
            this.Controls.Add(this.listUp);
            this.Controls.Add(this.grpAnimationName);
            this.Controls.Add(this.grpCharacterName);
            this.Controls.Add(this.grpDirections);
            this.Controls.Add(this.btnNewAnimation);
            this.Controls.Add(this.btnLoadAnimation);
            this.Controls.Add(this.btnSaveAnimation);
            this.Controls.Add(this.grpRender);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Character Animator Maker for Replica Studio";
            this.grpRender.ResumeLayout(false);
            this.grpRender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddpHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddpWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddpPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddpPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimPreview)).EndInit();
            this.grpDirections.ResumeLayout(false);
            this.grpDirections.PerformLayout();
            this.grpCharacterName.ResumeLayout(false);
            this.grpCharacterName.PerformLayout();
            this.grpAnimationName.ResumeLayout(false);
            this.grpAnimationName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRender;
        private System.Windows.Forms.Button btnSaveAnimation;
        private System.Windows.Forms.Button btnLoadAnimation;
        private System.Windows.Forms.Button btnNewAnimation;
        private System.Windows.Forms.GroupBox grpDirections;
        private System.Windows.Forms.RadioButton rad4Directions;
        private System.Windows.Forms.RadioButton rad8Directions;
        private System.Windows.Forms.TextBox txtCharacterName;
        private System.Windows.Forms.GroupBox grpCharacterName;
        private System.Windows.Forms.GroupBox grpAnimationName;
        private System.Windows.Forms.TextBox txtAnimationName;
        private System.Windows.Forms.PictureBox AnimPreview;
        private ListDirection listUp;
        private ListDirection listRight;
        private ListDirection listDown;
        private ListDirection listLeft;
        private ListDirection listUpLeft;
        private ListDirection listDownLeft;
        private ListDirection listDownRight;
        private ListDirection listUpRight;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.Button btnCenter;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.NumericUpDown ddpPosY;
        private System.Windows.Forms.NumericUpDown ddpPosX;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.NumericUpDown ddpHeight;
        private System.Windows.Forms.NumericUpDown ddpWidth;
    }
}