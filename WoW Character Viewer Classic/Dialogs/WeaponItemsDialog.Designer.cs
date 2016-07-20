namespace WoW_Character_Viewer_Classic.Dialogs
{
    partial class WeaponItemsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeaponItemsDialog));
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.openGLControl = new SharpGL.OpenGLControl();
            this.daggerRadioButton = new System.Windows.Forms.RadioButton();
            this.fistWeaponRadioButton = new System.Windows.Forms.RadioButton();
            this.axe1HRadioButton = new System.Windows.Forms.RadioButton();
            this.mace1HRadioButton = new System.Windows.Forms.RadioButton();
            this.sword1HRadioButton = new System.Windows.Forms.RadioButton();
            this.polearmRadioButton = new System.Windows.Forms.RadioButton();
            this.staffRadioButton = new System.Windows.Forms.RadioButton();
            this.axe2HRadioButton = new System.Windows.Forms.RadioButton();
            this.mace2HRadioButton = new System.Windows.Forms.RadioButton();
            this.sword2HRadioButton = new System.Windows.Forms.RadioButton();
            this.bowRadioButton = new System.Windows.Forms.RadioButton();
            this.crossbowRadioButton = new System.Windows.Forms.RadioButton();
            this.gunRadioButton = new System.Windows.Forms.RadioButton();
            this.thrownRadioButton = new System.Windows.Forms.RadioButton();
            this.wandRadioButton = new System.Windows.Forms.RadioButton();
            this.shieldRadioButton = new System.Windows.Forms.RadioButton();
            this.heldInOffHandRadioButton = new System.Windows.Forms.RadioButton();
            this.itemsListBox = new WoW_Character_Viewer_Classic.Controls.ItemsListBox();
            this.weaponTooltip = new WoW_Character_Viewer_Classic.Controls.WeaponTooltip();
            this.shieldTooltip = new WoW_Character_Viewer_Classic.Controls.ShieldTooltip();
            this.heldInOffHandTooltip = new WoW_Character_Viewer_Classic.Controls.HeldInOffHandTooltip();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.ForeColor = System.Drawing.Color.White;
            this.searchTextBox.Location = new System.Drawing.Point(12, 116);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(194, 20);
            this.searchTextBox.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Maroon;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.searchButton.Location = new System.Drawing.Point(212, 114);
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
            this.acceptButton.Location = new System.Drawing.Point(12, 345);
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
            this.cancelButton.Location = new System.Drawing.Point(212, 345);
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
            this.openGLControl.Location = new System.Drawing.Point(318, 116);
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
            // daggerRadioButton
            // 
            this.daggerRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.daggerRadioButton.ForeColor = System.Drawing.Color.White;
            this.daggerRadioButton.Location = new System.Drawing.Point(12, 12);
            this.daggerRadioButton.Name = "daggerRadioButton";
            this.daggerRadioButton.Size = new System.Drawing.Size(100, 20);
            this.daggerRadioButton.TabIndex = 6;
            this.daggerRadioButton.TabStop = true;
            this.daggerRadioButton.Text = "Dagger";
            this.daggerRadioButton.UseVisualStyleBackColor = true;
            this.daggerRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // fistWeaponRadioButton
            // 
            this.fistWeaponRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fistWeaponRadioButton.ForeColor = System.Drawing.Color.White;
            this.fistWeaponRadioButton.Location = new System.Drawing.Point(118, 12);
            this.fistWeaponRadioButton.Name = "fistWeaponRadioButton";
            this.fistWeaponRadioButton.Size = new System.Drawing.Size(100, 20);
            this.fistWeaponRadioButton.TabIndex = 7;
            this.fistWeaponRadioButton.TabStop = true;
            this.fistWeaponRadioButton.Text = "Fist Weapon";
            this.fistWeaponRadioButton.UseVisualStyleBackColor = true;
            this.fistWeaponRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // axe1HRadioButton
            // 
            this.axe1HRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.axe1HRadioButton.ForeColor = System.Drawing.Color.White;
            this.axe1HRadioButton.Location = new System.Drawing.Point(224, 12);
            this.axe1HRadioButton.Name = "axe1HRadioButton";
            this.axe1HRadioButton.Size = new System.Drawing.Size(100, 20);
            this.axe1HRadioButton.TabIndex = 8;
            this.axe1HRadioButton.TabStop = true;
            this.axe1HRadioButton.Text = "1H Axe";
            this.axe1HRadioButton.UseVisualStyleBackColor = true;
            this.axe1HRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // mace1HRadioButton
            // 
            this.mace1HRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mace1HRadioButton.ForeColor = System.Drawing.Color.White;
            this.mace1HRadioButton.Location = new System.Drawing.Point(330, 12);
            this.mace1HRadioButton.Name = "mace1HRadioButton";
            this.mace1HRadioButton.Size = new System.Drawing.Size(100, 20);
            this.mace1HRadioButton.TabIndex = 9;
            this.mace1HRadioButton.TabStop = true;
            this.mace1HRadioButton.Text = "1H Mace";
            this.mace1HRadioButton.UseVisualStyleBackColor = true;
            this.mace1HRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // sword1HRadioButton
            // 
            this.sword1HRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sword1HRadioButton.ForeColor = System.Drawing.Color.White;
            this.sword1HRadioButton.Location = new System.Drawing.Point(436, 12);
            this.sword1HRadioButton.Name = "sword1HRadioButton";
            this.sword1HRadioButton.Size = new System.Drawing.Size(100, 20);
            this.sword1HRadioButton.TabIndex = 10;
            this.sword1HRadioButton.TabStop = true;
            this.sword1HRadioButton.Text = "1H Sword";
            this.sword1HRadioButton.UseVisualStyleBackColor = true;
            this.sword1HRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // polearmRadioButton
            // 
            this.polearmRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.polearmRadioButton.ForeColor = System.Drawing.Color.White;
            this.polearmRadioButton.Location = new System.Drawing.Point(12, 38);
            this.polearmRadioButton.Name = "polearmRadioButton";
            this.polearmRadioButton.Size = new System.Drawing.Size(100, 20);
            this.polearmRadioButton.TabIndex = 11;
            this.polearmRadioButton.TabStop = true;
            this.polearmRadioButton.Text = "Polearm";
            this.polearmRadioButton.UseVisualStyleBackColor = true;
            this.polearmRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // staffRadioButton
            // 
            this.staffRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.staffRadioButton.ForeColor = System.Drawing.Color.White;
            this.staffRadioButton.Location = new System.Drawing.Point(118, 38);
            this.staffRadioButton.Name = "staffRadioButton";
            this.staffRadioButton.Size = new System.Drawing.Size(100, 20);
            this.staffRadioButton.TabIndex = 12;
            this.staffRadioButton.TabStop = true;
            this.staffRadioButton.Text = "Staff";
            this.staffRadioButton.UseVisualStyleBackColor = true;
            this.staffRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // axe2HRadioButton
            // 
            this.axe2HRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.axe2HRadioButton.ForeColor = System.Drawing.Color.White;
            this.axe2HRadioButton.Location = new System.Drawing.Point(224, 38);
            this.axe2HRadioButton.Name = "axe2HRadioButton";
            this.axe2HRadioButton.Size = new System.Drawing.Size(100, 20);
            this.axe2HRadioButton.TabIndex = 13;
            this.axe2HRadioButton.TabStop = true;
            this.axe2HRadioButton.Text = "2H Axe";
            this.axe2HRadioButton.UseVisualStyleBackColor = true;
            this.axe2HRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // mace2HRadioButton
            // 
            this.mace2HRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mace2HRadioButton.ForeColor = System.Drawing.Color.White;
            this.mace2HRadioButton.Location = new System.Drawing.Point(330, 38);
            this.mace2HRadioButton.Name = "mace2HRadioButton";
            this.mace2HRadioButton.Size = new System.Drawing.Size(100, 20);
            this.mace2HRadioButton.TabIndex = 14;
            this.mace2HRadioButton.TabStop = true;
            this.mace2HRadioButton.Text = "2H Mace";
            this.mace2HRadioButton.UseVisualStyleBackColor = true;
            this.mace2HRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // sword2HRadioButton
            // 
            this.sword2HRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sword2HRadioButton.ForeColor = System.Drawing.Color.White;
            this.sword2HRadioButton.Location = new System.Drawing.Point(436, 38);
            this.sword2HRadioButton.Name = "sword2HRadioButton";
            this.sword2HRadioButton.Size = new System.Drawing.Size(100, 20);
            this.sword2HRadioButton.TabIndex = 15;
            this.sword2HRadioButton.TabStop = true;
            this.sword2HRadioButton.Text = "2H Sword";
            this.sword2HRadioButton.UseVisualStyleBackColor = true;
            this.sword2HRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // bowRadioButton
            // 
            this.bowRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bowRadioButton.ForeColor = System.Drawing.Color.White;
            this.bowRadioButton.Location = new System.Drawing.Point(12, 64);
            this.bowRadioButton.Name = "bowRadioButton";
            this.bowRadioButton.Size = new System.Drawing.Size(100, 20);
            this.bowRadioButton.TabIndex = 16;
            this.bowRadioButton.TabStop = true;
            this.bowRadioButton.Text = "Bow";
            this.bowRadioButton.UseVisualStyleBackColor = true;
            this.bowRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // crossbowRadioButton
            // 
            this.crossbowRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.crossbowRadioButton.ForeColor = System.Drawing.Color.White;
            this.crossbowRadioButton.Location = new System.Drawing.Point(118, 64);
            this.crossbowRadioButton.Name = "crossbowRadioButton";
            this.crossbowRadioButton.Size = new System.Drawing.Size(100, 20);
            this.crossbowRadioButton.TabIndex = 17;
            this.crossbowRadioButton.TabStop = true;
            this.crossbowRadioButton.Text = "Crossbow";
            this.crossbowRadioButton.UseVisualStyleBackColor = true;
            this.crossbowRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // gunRadioButton
            // 
            this.gunRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gunRadioButton.ForeColor = System.Drawing.Color.White;
            this.gunRadioButton.Location = new System.Drawing.Point(224, 64);
            this.gunRadioButton.Name = "gunRadioButton";
            this.gunRadioButton.Size = new System.Drawing.Size(100, 20);
            this.gunRadioButton.TabIndex = 18;
            this.gunRadioButton.TabStop = true;
            this.gunRadioButton.Text = "Gun";
            this.gunRadioButton.UseVisualStyleBackColor = true;
            this.gunRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // thrownRadioButton
            // 
            this.thrownRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.thrownRadioButton.ForeColor = System.Drawing.Color.White;
            this.thrownRadioButton.Location = new System.Drawing.Point(330, 64);
            this.thrownRadioButton.Name = "thrownRadioButton";
            this.thrownRadioButton.Size = new System.Drawing.Size(100, 20);
            this.thrownRadioButton.TabIndex = 19;
            this.thrownRadioButton.TabStop = true;
            this.thrownRadioButton.Text = "Thrown";
            this.thrownRadioButton.UseVisualStyleBackColor = true;
            this.thrownRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // wandRadioButton
            // 
            this.wandRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wandRadioButton.ForeColor = System.Drawing.Color.White;
            this.wandRadioButton.Location = new System.Drawing.Point(436, 64);
            this.wandRadioButton.Name = "wandRadioButton";
            this.wandRadioButton.Size = new System.Drawing.Size(100, 20);
            this.wandRadioButton.TabIndex = 20;
            this.wandRadioButton.TabStop = true;
            this.wandRadioButton.Text = "Wand";
            this.wandRadioButton.UseVisualStyleBackColor = true;
            this.wandRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // shieldRadioButton
            // 
            this.shieldRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.shieldRadioButton.ForeColor = System.Drawing.Color.White;
            this.shieldRadioButton.Location = new System.Drawing.Point(12, 90);
            this.shieldRadioButton.Name = "shieldRadioButton";
            this.shieldRadioButton.Size = new System.Drawing.Size(100, 20);
            this.shieldRadioButton.TabIndex = 21;
            this.shieldRadioButton.TabStop = true;
            this.shieldRadioButton.Text = "Shield";
            this.shieldRadioButton.UseVisualStyleBackColor = true;
            this.shieldRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // heldInOffHandRadioButton
            // 
            this.heldInOffHandRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.heldInOffHandRadioButton.ForeColor = System.Drawing.Color.White;
            this.heldInOffHandRadioButton.Location = new System.Drawing.Point(118, 90);
            this.heldInOffHandRadioButton.Name = "heldInOffHandRadioButton";
            this.heldInOffHandRadioButton.Size = new System.Drawing.Size(120, 20);
            this.heldInOffHandRadioButton.TabIndex = 22;
            this.heldInOffHandRadioButton.TabStop = true;
            this.heldInOffHandRadioButton.Text = "Held In Off-Hand";
            this.heldInOffHandRadioButton.UseVisualStyleBackColor = true;
            this.heldInOffHandRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // itemsListBox
            // 
            this.itemsListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.itemsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.itemsListBox.ForeColor = System.Drawing.Color.White;
            this.itemsListBox.FormattingEnabled = true;
            this.itemsListBox.Location = new System.Drawing.Point(12, 142);
            this.itemsListBox.Name = "itemsListBox";
            this.itemsListBox.Size = new System.Drawing.Size(300, 197);
            this.itemsListBox.TabIndex = 2;
            this.itemsListBox.SelectedIndexChanged += new System.EventHandler(this.itemsListBox_SelectedIndexChanged);
            this.itemsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.itemsListBox_MouseDoubleClick);
            // 
            // weaponTooltip
            // 
            this.weaponTooltip.AutomaticDelay = 0;
            this.weaponTooltip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.weaponTooltip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.weaponTooltip.ForeColor = System.Drawing.Color.White;
            this.weaponTooltip.Item = null;
            this.weaponTooltip.OwnerDraw = true;
            this.weaponTooltip.UseAnimation = false;
            this.weaponTooltip.UseFading = false;
            // 
            // shieldTooltip
            // 
            this.shieldTooltip.AutomaticDelay = 0;
            this.shieldTooltip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.shieldTooltip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.shieldTooltip.ForeColor = System.Drawing.Color.White;
            this.shieldTooltip.Item = null;
            this.shieldTooltip.OwnerDraw = true;
            this.shieldTooltip.UseAnimation = false;
            this.shieldTooltip.UseFading = false;
            // 
            // heldInOffHandTooltip
            // 
            this.heldInOffHandTooltip.AutomaticDelay = 0;
            this.heldInOffHandTooltip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.heldInOffHandTooltip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.heldInOffHandTooltip.ForeColor = System.Drawing.Color.White;
            this.heldInOffHandTooltip.Item = null;
            this.heldInOffHandTooltip.OwnerDraw = true;
            this.heldInOffHandTooltip.UseAnimation = false;
            this.heldInOffHandTooltip.UseFading = false;
            // 
            // WeaponItemsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(589, 387);
            this.Controls.Add(this.heldInOffHandRadioButton);
            this.Controls.Add(this.shieldRadioButton);
            this.Controls.Add(this.wandRadioButton);
            this.Controls.Add(this.thrownRadioButton);
            this.Controls.Add(this.gunRadioButton);
            this.Controls.Add(this.crossbowRadioButton);
            this.Controls.Add(this.bowRadioButton);
            this.Controls.Add(this.sword2HRadioButton);
            this.Controls.Add(this.mace2HRadioButton);
            this.Controls.Add(this.axe2HRadioButton);
            this.Controls.Add(this.staffRadioButton);
            this.Controls.Add(this.polearmRadioButton);
            this.Controls.Add(this.sword1HRadioButton);
            this.Controls.Add(this.mace1HRadioButton);
            this.Controls.Add(this.axe1HRadioButton);
            this.Controls.Add(this.fistWeaponRadioButton);
            this.Controls.Add(this.daggerRadioButton);
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
            this.Name = "WeaponItemsDialog";
            this.Text = "Items";
            this.LocationChanged += new System.EventHandler(this.WeaopnItemsDialog_LocationChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WeaponItemsDialog_KeyDown);
            this.Move += new System.EventHandler(this.WeaponItemsDialog_Move);
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
        private System.Windows.Forms.RadioButton daggerRadioButton;
        private System.Windows.Forms.RadioButton fistWeaponRadioButton;
        private System.Windows.Forms.RadioButton axe1HRadioButton;
        private System.Windows.Forms.RadioButton mace1HRadioButton;
        private System.Windows.Forms.RadioButton sword1HRadioButton;
        private System.Windows.Forms.RadioButton polearmRadioButton;
        private System.Windows.Forms.RadioButton staffRadioButton;
        private System.Windows.Forms.RadioButton axe2HRadioButton;
        private System.Windows.Forms.RadioButton mace2HRadioButton;
        private System.Windows.Forms.RadioButton sword2HRadioButton;
        private System.Windows.Forms.RadioButton bowRadioButton;
        private System.Windows.Forms.RadioButton crossbowRadioButton;
        private System.Windows.Forms.RadioButton gunRadioButton;
        private System.Windows.Forms.RadioButton thrownRadioButton;
        private System.Windows.Forms.RadioButton wandRadioButton;
        private System.Windows.Forms.RadioButton shieldRadioButton;
        private System.Windows.Forms.RadioButton heldInOffHandRadioButton;
        private Controls.WeaponTooltip weaponTooltip;
        private Controls.ShieldTooltip shieldTooltip;
        private Controls.HeldInOffHandTooltip heldInOffHandTooltip;
    }
}