namespace WoW_Character_Viewer_Classic.Dialogs
{
    partial class ArmorItemsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArmorItemsDialog));
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.openGLControl = new SharpGL.OpenGLControl();
            this.clothRadioButton = new System.Windows.Forms.RadioButton();
            this.leatherRadioButton = new System.Windows.Forms.RadioButton();
            this.mailRadioButton = new System.Windows.Forms.RadioButton();
            this.plateRadioButton = new System.Windows.Forms.RadioButton();
            this.itemsListBox = new WoW_Character_Viewer_Classic.Controls.ItemsListBox();
            this.armorTooltip = new WoW_Character_Viewer_Classic.Controls.ArmorTooltip();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.ForeColor = System.Drawing.Color.White;
            this.searchTextBox.Location = new System.Drawing.Point(12, 38);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(194, 20);
            this.searchTextBox.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Maroon;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.searchButton.Location = new System.Drawing.Point(212, 38);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 20);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.BackColor = System.Drawing.Color.Maroon;
            this.acceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.acceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.acceptButton.Location = new System.Drawing.Point(12, 267);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(100, 30);
            this.acceptButton.TabIndex = 3;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Maroon;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cancelButton.Location = new System.Drawing.Point(212, 267);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // openGLControl
            // 
            this.openGLControl.DrawFPS = false;
            this.openGLControl.FrameRate = 30;
            this.openGLControl.Location = new System.Drawing.Point(318, 38);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.FBO;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(259, 259);
            this.openGLControl.TabIndex = 5;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            // 
            // clothRadioButton
            // 
            this.clothRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.clothRadioButton.ForeColor = System.Drawing.Color.White;
            this.clothRadioButton.Location = new System.Drawing.Point(12, 12);
            this.clothRadioButton.Name = "clothRadioButton";
            this.clothRadioButton.Size = new System.Drawing.Size(80, 20);
            this.clothRadioButton.TabIndex = 6;
            this.clothRadioButton.TabStop = true;
            this.clothRadioButton.Text = "Cloth";
            this.clothRadioButton.UseVisualStyleBackColor = true;
            this.clothRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // leatherRadioButton
            // 
            this.leatherRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.leatherRadioButton.ForeColor = System.Drawing.Color.White;
            this.leatherRadioButton.Location = new System.Drawing.Point(98, 12);
            this.leatherRadioButton.Name = "leatherRadioButton";
            this.leatherRadioButton.Size = new System.Drawing.Size(80, 20);
            this.leatherRadioButton.TabIndex = 7;
            this.leatherRadioButton.TabStop = true;
            this.leatherRadioButton.Text = "Leather";
            this.leatherRadioButton.UseVisualStyleBackColor = true;
            this.leatherRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // mailRadioButton
            // 
            this.mailRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mailRadioButton.ForeColor = System.Drawing.Color.White;
            this.mailRadioButton.Location = new System.Drawing.Point(184, 12);
            this.mailRadioButton.Name = "mailRadioButton";
            this.mailRadioButton.Size = new System.Drawing.Size(80, 20);
            this.mailRadioButton.TabIndex = 8;
            this.mailRadioButton.TabStop = true;
            this.mailRadioButton.Text = "Mail";
            this.mailRadioButton.UseVisualStyleBackColor = true;
            this.mailRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // plateRadioButton
            // 
            this.plateRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.plateRadioButton.ForeColor = System.Drawing.Color.White;
            this.plateRadioButton.Location = new System.Drawing.Point(270, 12);
            this.plateRadioButton.Name = "plateRadioButton";
            this.plateRadioButton.Size = new System.Drawing.Size(80, 20);
            this.plateRadioButton.TabIndex = 9;
            this.plateRadioButton.TabStop = true;
            this.plateRadioButton.Text = "Plate";
            this.plateRadioButton.UseVisualStyleBackColor = true;
            this.plateRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // itemsListBox
            // 
            this.itemsListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.itemsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.itemsListBox.ForeColor = System.Drawing.Color.White;
            this.itemsListBox.FormattingEnabled = true;
            this.itemsListBox.Location = new System.Drawing.Point(12, 64);
            this.itemsListBox.Name = "itemsListBox";
            this.itemsListBox.Size = new System.Drawing.Size(300, 197);
            this.itemsListBox.TabIndex = 2;
            this.itemsListBox.SelectedIndexChanged += new System.EventHandler(this.itemsListBox_SelectedIndexChanged);
            // 
            // armorTooltip
            // 
            this.armorTooltip.AutomaticDelay = 0;
            this.armorTooltip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.armorTooltip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.armorTooltip.ForeColor = System.Drawing.Color.White;
            this.armorTooltip.Item = null;
            this.armorTooltip.OwnerDraw = true;
            this.armorTooltip.UseAnimation = false;
            this.armorTooltip.UseFading = false;
            // 
            // ArmorItemsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(589, 309);
            this.Controls.Add(this.plateRadioButton);
            this.Controls.Add(this.mailRadioButton);
            this.Controls.Add(this.leatherRadioButton);
            this.Controls.Add(this.clothRadioButton);
            this.Controls.Add(this.openGLControl);
            this.Controls.Add(this.itemsListBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.ForeColor = System.Drawing.Color.Yellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArmorItemsDialog";
            this.Text = "Items";
            this.LocationChanged += new System.EventHandler(this.ArmorItemsDialog_LocationChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArmorItemsDialog_KeyDown);
            this.Move += new System.EventHandler(this.ArmorItemsDialog_Move);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private Controls.ItemsListBox itemsListBox;
        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.RadioButton clothRadioButton;
        private System.Windows.Forms.RadioButton leatherRadioButton;
        private System.Windows.Forms.RadioButton mailRadioButton;
        private System.Windows.Forms.RadioButton plateRadioButton;
        private Controls.ArmorTooltip armorTooltip;
    }
}