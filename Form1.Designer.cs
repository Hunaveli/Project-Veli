using System.Drawing;
using System.Windows.Forms;

namespace Project_Veli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.connect = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.paintballMode = new System.Windows.Forms.Button();
            this.cartoonMode = new System.Windows.Forms.Button();
            this.playerGroup = new System.Windows.Forms.GroupBox();
            this.povValue = new System.Windows.Forms.Label();
            this.povScale = new System.Windows.Forms.Button();
            this.moneyButton = new System.Windows.Forms.Button();
            this.selfMoney = new System.Windows.Forms.Button();
            this.dropWeapon = new System.Windows.Forms.Button();
            this.zmWeapons = new System.Windows.Forms.ComboBox();
            this.zmWeapon = new System.Windows.Forms.Button();
            this.povScaleValue = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lowGravity = new System.Windows.Forms.Button();
            this.playerSpeedLabel = new System.Windows.Forms.Label();
            this.timescaleLabel = new System.Windows.Forms.Label();
            this.jumpHeight = new System.Windows.Forms.Button();
            this.zombSpawn = new System.Windows.Forms.Button();
            this.fallDamage = new System.Windows.Forms.Button();
            this.timescaleBar = new System.Windows.Forms.TrackBar();
            this.timescale = new System.Windows.Forms.Button();
            this.playerSpeed = new System.Windows.Forms.TrackBar();
            this.playerSpeedButton = new System.Windows.Forms.Button();
            this.restartMap = new System.Windows.Forms.Button();
            this.slowMotion = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gamertagBox = new System.Windows.Forms.TextBox();
            this.setGamertag = new System.Windows.Forms.Button();
            this.bindNoClip = new System.Windows.Forms.Button();
            this.unAmmo = new System.Windows.Forms.Button();
            this.godMode = new System.Windows.Forms.Button();
            this.noClip = new System.Windows.Forms.Button();
            this.thirdPerson = new System.Windows.Forms.Button();
            this.ammoButton = new System.Windows.Forms.Button();
            this.infoBox = new System.Windows.Forms.GroupBox();
            this.screenshotButton = new System.Windows.Forms.Button();
            this.customNotiBox = new System.Windows.Forms.TextBox();
            this.customNoti = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.ipLabel = new System.Windows.Forms.Label();
            this.cpuBox = new System.Windows.Forms.TextBox();
            this.cpuLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.bo1zombMods = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.prestigeButton = new System.Windows.Forms.Button();
            this.prestigeSelection = new System.Windows.Forms.NumericUpDown();
            this.statBox = new System.Windows.Forms.GroupBox();
            this.killsButton = new System.Windows.Forms.Button();
            this.killsSelection = new System.Windows.Forms.NumericUpDown();
            this.groupBox3.SuspendLayout();
            this.playerGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.povScaleValue)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timescaleBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerSpeed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.infoBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.bo1zombMods.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prestigeSelection)).BeginInit();
            this.statBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.killsSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // connect
            // 
            this.connect.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.connect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.connect.Location = new System.Drawing.Point(12, 12);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(560, 33);
            this.connect.TabIndex = 0;
            this.connect.Text = "Connect To Xbox";
            this.connect.UseVisualStyleBackColor = false;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.paintballMode);
            this.groupBox3.Controls.Add(this.cartoonMode);
            this.groupBox3.Location = new System.Drawing.Point(6, 146);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(240, 144);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Misc Mods";
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(122, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 22);
            this.button3.TabIndex = 9;
            this.button3.Text = "Sun [Red]";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(6, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 22);
            this.button2.TabIndex = 8;
            this.button2.Text = "Black/White Mode";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(6, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 22);
            this.button1.TabIndex = 7;
            this.button1.Text = "Score Color [Red]";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // paintballMode
            // 
            this.paintballMode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.paintballMode.Location = new System.Drawing.Point(6, 45);
            this.paintballMode.Name = "paintballMode";
            this.paintballMode.Size = new System.Drawing.Size(112, 22);
            this.paintballMode.TabIndex = 6;
            this.paintballMode.Text = "Paintball Mode";
            this.paintballMode.UseVisualStyleBackColor = true;
            this.paintballMode.Click += new System.EventHandler(this.paintballMode_Click);
            // 
            // cartoonMode
            // 
            this.cartoonMode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cartoonMode.Location = new System.Drawing.Point(6, 17);
            this.cartoonMode.Name = "cartoonMode";
            this.cartoonMode.Size = new System.Drawing.Size(112, 22);
            this.cartoonMode.TabIndex = 5;
            this.cartoonMode.Text = "Cartoon Mode";
            this.cartoonMode.UseVisualStyleBackColor = true;
            this.cartoonMode.Click += new System.EventHandler(this.cartoonMode_Click);
            // 
            // playerGroup
            // 
            this.playerGroup.Controls.Add(this.povValue);
            this.playerGroup.Controls.Add(this.povScale);
            this.playerGroup.Controls.Add(this.moneyButton);
            this.playerGroup.Controls.Add(this.selfMoney);
            this.playerGroup.Controls.Add(this.dropWeapon);
            this.playerGroup.Controls.Add(this.zmWeapons);
            this.playerGroup.Controls.Add(this.zmWeapon);
            this.playerGroup.Controls.Add(this.povScaleValue);
            this.playerGroup.Location = new System.Drawing.Point(252, 163);
            this.playerGroup.Name = "playerGroup";
            this.playerGroup.Size = new System.Drawing.Size(302, 127);
            this.playerGroup.TabIndex = 6;
            this.playerGroup.TabStop = false;
            this.playerGroup.Text = "Player Mods";
            // 
            // povValue
            // 
            this.povValue.AutoSize = true;
            this.povValue.ForeColor = System.Drawing.Color.DarkOrchid;
            this.povValue.Location = new System.Drawing.Point(256, 21);
            this.povValue.Name = "povValue";
            this.povValue.Size = new System.Drawing.Size(40, 13);
            this.povValue.TabIndex = 15;
            this.povValue.Text = "65 (65)";
            // 
            // povScale
            // 
            this.povScale.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.povScale.Location = new System.Drawing.Point(6, 17);
            this.povScale.Name = "povScale";
            this.povScale.Size = new System.Drawing.Size(91, 21);
            this.povScale.TabIndex = 14;
            this.povScale.Text = "POV:";
            this.povScale.UseVisualStyleBackColor = true;
            this.povScale.Click += new System.EventHandler(this.povScale_Click);
            // 
            // moneyButton
            // 
            this.moneyButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.moneyButton.Location = new System.Drawing.Point(200, 71);
            this.moneyButton.Name = "moneyButton";
            this.moneyButton.Size = new System.Drawing.Size(91, 22);
            this.moneyButton.TabIndex = 2;
            this.moneyButton.Text = "Give All $";
            this.moneyButton.UseVisualStyleBackColor = true;
            this.moneyButton.Click += new System.EventHandler(this.moneyButton_Click);
            // 
            // selfMoney
            // 
            this.selfMoney.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.selfMoney.Location = new System.Drawing.Point(103, 71);
            this.selfMoney.Name = "selfMoney";
            this.selfMoney.Size = new System.Drawing.Size(91, 22);
            this.selfMoney.TabIndex = 6;
            this.selfMoney.Text = "Give Self $";
            this.selfMoney.UseVisualStyleBackColor = true;
            this.selfMoney.Click += new System.EventHandler(this.selfMoney_Click);
            // 
            // dropWeapon
            // 
            this.dropWeapon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dropWeapon.Location = new System.Drawing.Point(6, 71);
            this.dropWeapon.Name = "dropWeapon";
            this.dropWeapon.Size = new System.Drawing.Size(91, 22);
            this.dropWeapon.TabIndex = 5;
            this.dropWeapon.Text = "Drop Weapon";
            this.dropWeapon.UseVisualStyleBackColor = true;
            this.dropWeapon.Click += new System.EventHandler(this.dropWeapon_Click);
            // 
            // zmWeapons
            // 
            this.zmWeapons.BackColor = System.Drawing.SystemColors.Control;
            this.zmWeapons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.zmWeapons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zmWeapons.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.zmWeapons.FormattingEnabled = true;
            this.zmWeapons.Items.AddRange(new object[] {
            "ray_gun_zm",
            "ray_gun_upgraded_zm",
            "thundergun_zm",
            "thundergun_upgraded_zm",
            "tesla_gun_upgraded_zm",
            "shrink_ray_upgraded_zm",
            "microwavegun_upgraded_zm",
            "humangun_upgraded_zm",
            "freezegun_upgraded_zm",
            "zombie_cymbal_monkey",
            "ak47_zm",
            "m1911_upgraded_zm",
            "sniper_explosive_upgraded_zm",
            "defaultweapon",
            "zombie_perk_bottle_jugg"});
            this.zmWeapons.Location = new System.Drawing.Point(103, 44);
            this.zmWeapons.Name = "zmWeapons";
            this.zmWeapons.Size = new System.Drawing.Size(188, 21);
            this.zmWeapons.TabIndex = 3;
            this.zmWeapons.Text = "[Pick ZM Weapons]";
            // 
            // zmWeapon
            // 
            this.zmWeapon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.zmWeapon.Location = new System.Drawing.Point(6, 44);
            this.zmWeapon.Name = "zmWeapon";
            this.zmWeapon.Size = new System.Drawing.Size(91, 22);
            this.zmWeapon.TabIndex = 4;
            this.zmWeapon.Text = "Select Weapon";
            this.zmWeapon.UseVisualStyleBackColor = true;
            this.zmWeapon.Click += new System.EventHandler(this.zmWeapon_Click);
            // 
            // povScaleValue
            // 
            this.povScaleValue.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.povScaleValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.povScaleValue.Location = new System.Drawing.Point(103, 17);
            this.povScaleValue.Maximum = 160;
            this.povScaleValue.Minimum = 1;
            this.povScaleValue.Name = "povScaleValue";
            this.povScaleValue.Size = new System.Drawing.Size(151, 45);
            this.povScaleValue.TabIndex = 13;
            this.povScaleValue.Value = 80;
            this.povScaleValue.Scroll += new System.EventHandler(this.povScaleValue_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lowGravity);
            this.groupBox2.Controls.Add(this.playerSpeedLabel);
            this.groupBox2.Controls.Add(this.timescaleLabel);
            this.groupBox2.Controls.Add(this.jumpHeight);
            this.groupBox2.Controls.Add(this.zombSpawn);
            this.groupBox2.Controls.Add(this.fallDamage);
            this.groupBox2.Controls.Add(this.timescaleBar);
            this.groupBox2.Controls.Add(this.timescale);
            this.groupBox2.Controls.Add(this.playerSpeed);
            this.groupBox2.Controls.Add(this.playerSpeedButton);
            this.groupBox2.Controls.Add(this.restartMap);
            this.groupBox2.Controls.Add(this.slowMotion);
            this.groupBox2.Location = new System.Drawing.Point(252, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 151);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Game Settings";
            // 
            // lowGravity
            // 
            this.lowGravity.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lowGravity.Location = new System.Drawing.Point(6, 95);
            this.lowGravity.Name = "lowGravity";
            this.lowGravity.Size = new System.Drawing.Size(91, 22);
            this.lowGravity.TabIndex = 18;
            this.lowGravity.Text = "Low Gravity";
            this.lowGravity.UseVisualStyleBackColor = true;
            this.lowGravity.Click += new System.EventHandler(this.lowGravity_Click);
            // 
            // playerSpeedLabel
            // 
            this.playerSpeedLabel.AutoSize = true;
            this.playerSpeedLabel.ForeColor = System.Drawing.Color.DarkOrchid;
            this.playerSpeedLabel.Location = new System.Drawing.Point(248, 24);
            this.playerSpeedLabel.Name = "playerSpeedLabel";
            this.playerSpeedLabel.Size = new System.Drawing.Size(52, 13);
            this.playerSpeedLabel.TabIndex = 17;
            this.playerSpeedLabel.Text = "499 (175)";
            // 
            // timescaleLabel
            // 
            this.timescaleLabel.AutoSize = true;
            this.timescaleLabel.ForeColor = System.Drawing.Color.DarkOrchid;
            this.timescaleLabel.Location = new System.Drawing.Point(256, 51);
            this.timescaleLabel.Name = "timescaleLabel";
            this.timescaleLabel.Size = new System.Drawing.Size(34, 13);
            this.timescaleLabel.TabIndex = 16;
            this.timescaleLabel.Text = "5 (10)";
            // 
            // jumpHeight
            // 
            this.jumpHeight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.jumpHeight.Location = new System.Drawing.Point(200, 95);
            this.jumpHeight.Name = "jumpHeight";
            this.jumpHeight.Size = new System.Drawing.Size(91, 22);
            this.jumpHeight.TabIndex = 10;
            this.jumpHeight.Text = "Jump High";
            this.jumpHeight.UseVisualStyleBackColor = true;
            this.jumpHeight.Click += new System.EventHandler(this.jumpHeight_Click);
            // 
            // zombSpawn
            // 
            this.zombSpawn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.zombSpawn.Location = new System.Drawing.Point(103, 95);
            this.zombSpawn.Name = "zombSpawn";
            this.zombSpawn.Size = new System.Drawing.Size(91, 22);
            this.zombSpawn.TabIndex = 11;
            this.zombSpawn.Text = "Disable Zombs";
            this.zombSpawn.UseVisualStyleBackColor = true;
            this.zombSpawn.Click += new System.EventHandler(this.zombSpawn_Click);
            // 
            // fallDamage
            // 
            this.fallDamage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fallDamage.Location = new System.Drawing.Point(200, 123);
            this.fallDamage.Name = "fallDamage";
            this.fallDamage.Size = new System.Drawing.Size(91, 22);
            this.fallDamage.TabIndex = 9;
            this.fallDamage.Text = "No Fall Damage";
            this.fallDamage.UseVisualStyleBackColor = true;
            this.fallDamage.Click += new System.EventHandler(this.fallDamage_Click);
            // 
            // timescaleBar
            // 
            this.timescaleBar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.timescaleBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.timescaleBar.Location = new System.Drawing.Point(103, 47);
            this.timescaleBar.Minimum = 1;
            this.timescaleBar.Name = "timescaleBar";
            this.timescaleBar.Size = new System.Drawing.Size(151, 45);
            this.timescaleBar.TabIndex = 8;
            this.timescaleBar.Value = 5;
            this.timescaleBar.Scroll += new System.EventHandler(this.timescaleBar_Scroll);
            // 
            // timescale
            // 
            this.timescale.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.timescale.Location = new System.Drawing.Point(11, 47);
            this.timescale.Name = "timescale";
            this.timescale.Size = new System.Drawing.Size(91, 22);
            this.timescale.TabIndex = 7;
            this.timescale.Text = "Timescale:";
            this.timescale.UseVisualStyleBackColor = true;
            this.timescale.Click += new System.EventHandler(this.timescale_Click);
            // 
            // playerSpeed
            // 
            this.playerSpeed.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.playerSpeed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playerSpeed.Location = new System.Drawing.Point(103, 19);
            this.playerSpeed.Maximum = 999;
            this.playerSpeed.Minimum = 100;
            this.playerSpeed.Name = "playerSpeed";
            this.playerSpeed.Size = new System.Drawing.Size(151, 45);
            this.playerSpeed.TabIndex = 5;
            this.playerSpeed.Value = 499;
            this.playerSpeed.Scroll += new System.EventHandler(this.playerSpeed_Scroll);
            // 
            // playerSpeedButton
            // 
            this.playerSpeedButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.playerSpeedButton.Location = new System.Drawing.Point(11, 19);
            this.playerSpeedButton.Name = "playerSpeedButton";
            this.playerSpeedButton.Size = new System.Drawing.Size(91, 22);
            this.playerSpeedButton.TabIndex = 6;
            this.playerSpeedButton.Text = "Player Speed:";
            this.playerSpeedButton.UseVisualStyleBackColor = true;
            this.playerSpeedButton.Click += new System.EventHandler(this.playerSpeedButton_Click);
            // 
            // restartMap
            // 
            this.restartMap.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.restartMap.Location = new System.Drawing.Point(103, 123);
            this.restartMap.Name = "restartMap";
            this.restartMap.Size = new System.Drawing.Size(91, 22);
            this.restartMap.TabIndex = 2;
            this.restartMap.Text = "Quick Restart";
            this.restartMap.UseVisualStyleBackColor = true;
            this.restartMap.Click += new System.EventHandler(this.restartMap_Click);
            // 
            // slowMotion
            // 
            this.slowMotion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.slowMotion.Location = new System.Drawing.Point(6, 123);
            this.slowMotion.Name = "slowMotion";
            this.slowMotion.Size = new System.Drawing.Size(91, 22);
            this.slowMotion.TabIndex = 1;
            this.slowMotion.Text = "Slow Motion";
            this.slowMotion.UseVisualStyleBackColor = true;
            this.slowMotion.Click += new System.EventHandler(this.slowMotion_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gamertagBox);
            this.groupBox1.Controls.Add(this.setGamertag);
            this.groupBox1.Controls.Add(this.bindNoClip);
            this.groupBox1.Controls.Add(this.unAmmo);
            this.groupBox1.Controls.Add(this.godMode);
            this.groupBox1.Controls.Add(this.noClip);
            this.groupBox1.Controls.Add(this.thirdPerson);
            this.groupBox1.Controls.Add(this.ammoButton);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 134);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Mods";
            // 
            // gamertagBox
            // 
            this.gamertagBox.BackColor = System.Drawing.SystemColors.Control;
            this.gamertagBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamertagBox.Location = new System.Drawing.Point(80, 19);
            this.gamertagBox.MaxLength = 31;
            this.gamertagBox.Name = "gamertagBox";
            this.gamertagBox.Size = new System.Drawing.Size(154, 20);
            this.gamertagBox.TabIndex = 9;
            this.gamertagBox.Text = "[Enter Gamertag Here]";
            // 
            // setGamertag
            // 
            this.setGamertag.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.setGamertag.Location = new System.Drawing.Point(6, 19);
            this.setGamertag.Name = "setGamertag";
            this.setGamertag.Size = new System.Drawing.Size(68, 22);
            this.setGamertag.TabIndex = 6;
            this.setGamertag.Text = "Gamertag:";
            this.setGamertag.UseVisualStyleBackColor = true;
            this.setGamertag.Click += new System.EventHandler(this.setGamertag_Click);
            // 
            // bindNoClip
            // 
            this.bindNoClip.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bindNoClip.Location = new System.Drawing.Point(122, 75);
            this.bindNoClip.Name = "bindNoClip";
            this.bindNoClip.Size = new System.Drawing.Size(112, 22);
            this.bindNoClip.TabIndex = 5;
            this.bindNoClip.Text = "Bind No-Clip";
            this.bindNoClip.UseVisualStyleBackColor = true;
            this.bindNoClip.Click += new System.EventHandler(this.bindNoClip_Click);
            // 
            // unAmmo
            // 
            this.unAmmo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.unAmmo.Location = new System.Drawing.Point(122, 103);
            this.unAmmo.Name = "unAmmo";
            this.unAmmo.Size = new System.Drawing.Size(112, 22);
            this.unAmmo.TabIndex = 4;
            this.unAmmo.Text = "Infinite Ammo";
            this.unAmmo.UseVisualStyleBackColor = true;
            this.unAmmo.Click += new System.EventHandler(this.unAmmo_Click);
            // 
            // godMode
            // 
            this.godMode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.godMode.Location = new System.Drawing.Point(6, 47);
            this.godMode.Name = "godMode";
            this.godMode.Size = new System.Drawing.Size(112, 22);
            this.godMode.TabIndex = 0;
            this.godMode.Text = "God Mode";
            this.godMode.UseVisualStyleBackColor = true;
            this.godMode.Click += new System.EventHandler(this.godMode_Click);
            // 
            // noClip
            // 
            this.noClip.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.noClip.Location = new System.Drawing.Point(6, 75);
            this.noClip.Name = "noClip";
            this.noClip.Size = new System.Drawing.Size(112, 22);
            this.noClip.TabIndex = 1;
            this.noClip.Text = "No-Clip";
            this.noClip.UseVisualStyleBackColor = true;
            this.noClip.Click += new System.EventHandler(this.noClip_Click);
            // 
            // thirdPerson
            // 
            this.thirdPerson.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.thirdPerson.Location = new System.Drawing.Point(122, 47);
            this.thirdPerson.Name = "thirdPerson";
            this.thirdPerson.Size = new System.Drawing.Size(112, 22);
            this.thirdPerson.TabIndex = 3;
            this.thirdPerson.Text = "3rd Person";
            this.thirdPerson.UseVisualStyleBackColor = true;
            this.thirdPerson.Click += new System.EventHandler(this.thirdPerson_Click);
            // 
            // ammoButton
            // 
            this.ammoButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ammoButton.Location = new System.Drawing.Point(6, 103);
            this.ammoButton.Name = "ammoButton";
            this.ammoButton.Size = new System.Drawing.Size(112, 22);
            this.ammoButton.TabIndex = 2;
            this.ammoButton.Text = "Give Ammo";
            this.ammoButton.UseVisualStyleBackColor = true;
            this.ammoButton.Click += new System.EventHandler(this.ammoButton_Click);
            // 
            // infoBox
            // 
            this.infoBox.Controls.Add(this.screenshotButton);
            this.infoBox.Controls.Add(this.customNotiBox);
            this.infoBox.Controls.Add(this.customNoti);
            this.infoBox.Controls.Add(this.versionLabel);
            this.infoBox.Controls.Add(this.copyrightLabel);
            this.infoBox.Controls.Add(this.ipBox);
            this.infoBox.Controls.Add(this.ipLabel);
            this.infoBox.Controls.Add(this.cpuBox);
            this.infoBox.Controls.Add(this.cpuLabel);
            this.infoBox.Location = new System.Drawing.Point(12, 51);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(560, 67);
            this.infoBox.TabIndex = 4;
            this.infoBox.TabStop = false;
            this.infoBox.Text = "Info";
            // 
            // screenshotButton
            // 
            this.screenshotButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.screenshotButton.Location = new System.Drawing.Point(196, 38);
            this.screenshotButton.Name = "screenshotButton";
            this.screenshotButton.Size = new System.Drawing.Size(100, 20);
            this.screenshotButton.TabIndex = 10;
            this.screenshotButton.Text = "Shut Down Xbox";
            this.screenshotButton.UseVisualStyleBackColor = true;
            this.screenshotButton.Click += new System.EventHandler(this.screenshotButton_Click);
            // 
            // customNotiBox
            // 
            this.customNotiBox.BackColor = System.Drawing.SystemColors.Control;
            this.customNotiBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customNotiBox.Location = new System.Drawing.Point(301, 14);
            this.customNotiBox.Name = "customNotiBox";
            this.customNotiBox.Size = new System.Drawing.Size(242, 20);
            this.customNotiBox.TabIndex = 8;
            this.customNotiBox.Text = "[Enter Custom Notification Here]";
            // 
            // customNoti
            // 
            this.customNoti.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.customNoti.Location = new System.Drawing.Point(196, 14);
            this.customNoti.Name = "customNoti";
            this.customNoti.Size = new System.Drawing.Size(100, 20);
            this.customNoti.TabIndex = 9;
            this.customNoti.Text = "Custom Noti:";
            this.customNoti.UseVisualStyleBackColor = true;
            this.customNoti.Click += new System.EventHandler(this.customNoti_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.versionLabel.Location = new System.Drawing.Point(298, 42);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(121, 13);
            this.versionLabel.TabIndex = 6;
            this.versionLabel.Text = "Project Veli v0.8 [BETA]";
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.ForeColor = System.Drawing.Color.DarkOrchid;
            this.copyrightLabel.Location = new System.Drawing.Point(419, 42);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(129, 13);
            this.copyrightLabel.TabIndex = 5;
            this.copyrightLabel.Text = "Developed by @Hunaveli";
            // 
            // ipBox
            // 
            this.ipBox.BackColor = System.Drawing.SystemColors.Control;
            this.ipBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ipBox.Location = new System.Drawing.Point(68, 38);
            this.ipBox.Name = "ipBox";
            this.ipBox.ReadOnly = true;
            this.ipBox.Size = new System.Drawing.Size(121, 20);
            this.ipBox.TabIndex = 3;
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ipLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ipLabel.Location = new System.Drawing.Point(9, 41);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(47, 13);
            this.ipLabel.TabIndex = 2;
            this.ipLabel.Text = "Xbox IP:";
            // 
            // cpuBox
            // 
            this.cpuBox.BackColor = System.Drawing.SystemColors.Control;
            this.cpuBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpuBox.Location = new System.Drawing.Point(68, 14);
            this.cpuBox.Name = "cpuBox";
            this.cpuBox.ReadOnly = true;
            this.cpuBox.Size = new System.Drawing.Size(121, 20);
            this.cpuBox.TabIndex = 1;
            // 
            // cpuLabel
            // 
            this.cpuLabel.AutoSize = true;
            this.cpuLabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cpuLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cpuLabel.Location = new System.Drawing.Point(9, 17);
            this.cpuLabel.Name = "cpuLabel";
            this.cpuLabel.Size = new System.Drawing.Size(53, 13);
            this.cpuLabel.TabIndex = 0;
            this.cpuLabel.Text = "CPU Key:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.bo1zombMods);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Location = new System.Drawing.Point(5, 124);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(567, 322);
            this.tabControl1.TabIndex = 5;
            // 
            // bo1zombMods
            // 
            this.bo1zombMods.BackColor = System.Drawing.Color.Silver;
            this.bo1zombMods.Controls.Add(this.groupBox3);
            this.bo1zombMods.Controls.Add(this.playerGroup);
            this.bo1zombMods.Controls.Add(this.groupBox1);
            this.bo1zombMods.Controls.Add(this.groupBox2);
            this.bo1zombMods.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.bo1zombMods.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bo1zombMods.Location = new System.Drawing.Point(4, 22);
            this.bo1zombMods.Name = "bo1zombMods";
            this.bo1zombMods.Padding = new System.Windows.Forms.Padding(3);
            this.bo1zombMods.Size = new System.Drawing.Size(559, 296);
            this.bo1zombMods.TabIndex = 0;
            this.bo1zombMods.Text = "BO1 [TU11] Zombies";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tabPage2.Controls.Add(this.statBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(559, 296);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "BO1 [TU11] Multiplayer";
            // 
            // prestigeButton
            // 
            this.prestigeButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.prestigeButton.Location = new System.Drawing.Point(9, 19);
            this.prestigeButton.Name = "prestigeButton";
            this.prestigeButton.Size = new System.Drawing.Size(75, 20);
            this.prestigeButton.TabIndex = 0;
            this.prestigeButton.Text = "Prestige";
            this.prestigeButton.UseVisualStyleBackColor = true;
            this.prestigeButton.Click += new System.EventHandler(this.prestigeButton_Click);
            // 
            // prestigeSelection
            // 
            this.prestigeSelection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prestigeSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prestigeSelection.Location = new System.Drawing.Point(88, 19);
            this.prestigeSelection.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.prestigeSelection.Name = "prestigeSelection";
            this.prestigeSelection.Size = new System.Drawing.Size(105, 20);
            this.prestigeSelection.TabIndex = 1;
            // 
            // statBox
            // 
            this.statBox.Controls.Add(this.killsSelection);
            this.statBox.Controls.Add(this.killsButton);
            this.statBox.Controls.Add(this.prestigeButton);
            this.statBox.Controls.Add(this.prestigeSelection);
            this.statBox.Location = new System.Drawing.Point(6, 3);
            this.statBox.Name = "statBox";
            this.statBox.Size = new System.Drawing.Size(199, 77);
            this.statBox.TabIndex = 2;
            this.statBox.TabStop = false;
            this.statBox.Text = "Stats";
            // 
            // killsButton
            // 
            this.killsButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.killsButton.Location = new System.Drawing.Point(9, 43);
            this.killsButton.Name = "killsButton";
            this.killsButton.Size = new System.Drawing.Size(75, 20);
            this.killsButton.TabIndex = 2;
            this.killsButton.Text = "Kills";
            this.killsButton.UseVisualStyleBackColor = true;
            // 
            // killsSelection
            // 
            this.killsSelection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.killsSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.killsSelection.Location = new System.Drawing.Point(88, 43);
            this.killsSelection.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.killsSelection.Name = "killsSelection";
            this.killsSelection.Size = new System.Drawing.Size(105, 20);
            this.killsSelection.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(577, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.connect);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Veli";
            this.groupBox3.ResumeLayout(false);
            this.playerGroup.ResumeLayout(false);
            this.playerGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.povScaleValue)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timescaleBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerSpeed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.infoBox.ResumeLayout(false);
            this.infoBox.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.bo1zombMods.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prestigeSelection)).EndInit();
            this.statBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.killsSelection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button connect;
        private Button godMode;
        private Button noClip;
        private Button ammoButton;
        private Button thirdPerson;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button slowMotion;
        private Button restartMap;
        private GroupBox infoBox;
        private Label cpuLabel;
        private TextBox cpuBox;
        private TextBox ipBox;
        private Label ipLabel;
        private Label copyrightLabel;
        private GroupBox playerGroup;
        private Button moneyButton;
        private ComboBox zmWeapons;
        private Button zmWeapon;
        private Button playerSpeedButton;
        private TrackBar playerSpeed;
        private TrackBar timescaleBar;
        private Button timescale;
        private Button unAmmo;
        private Button fallDamage;
        private Button jumpHeight;
        private Label versionLabel;
        private Button customNoti;
        private TextBox customNotiBox;
        private Button screenshotButton;
        private Button bindNoClip;
        private Button dropWeapon;
        private Button selfMoney;
        private GroupBox groupBox3;
        private Button cartoonMode;
        private Button paintballMode;
        private Button button1;
        private Button zombSpawn;
        private Button setGamertag;
        private TextBox gamertagBox;
        private TrackBar povScaleValue;
        private Button button2;
        private Button povScale;
        private Label povValue;
        private Label playerSpeedLabel;
        private Label timescaleLabel;
        private Button button3;
        private Button lowGravity;
        private TabControl tabControl1;
        private TabPage bo1zombMods;
        private TabPage tabPage2;
        private Button prestigeButton;
        private NumericUpDown prestigeSelection;
        private GroupBox statBox;
        private NumericUpDown killsSelection;
        private Button killsButton;
    }
}

