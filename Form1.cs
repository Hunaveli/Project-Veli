﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XDevkit;
using JRPC_Client;
using XRPCLib;
using XRPCPlusPlus;
using System.Diagnostics.Eventing.Reader;
using System.Threading;
using System.Diagnostics;

namespace Project_Veli
{
    public partial class Form1 : Form
    {
        XRPC xbox = new XRPC();
        IXboxConsole console;
        public Form1()
        {
            InitializeComponent();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            try 
            {
                xbox.Connect();
                if (xbox.activeConnection == true && console.Connect(out console))
                {
                    MessageBox.Show("The Tool has succesfully connected, happy modding!", 
                        "Connected to Console!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    console.XNotify("Connected to Project Veli v0.7\nDeveloped by @Hunaveli", 14);
                    connect.Text = "Connected!";
                    cpuBox.Text = console.GetCPUKey(); ipBox.Text = console.XboxIP();
                }
                else
                {
                    MessageBox.Show("The Tool has failed to connect!", 
                        "Something went wrong, check instructions.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
            catch (Exception)
            {
                MessageBox.Show("The Tool has failed to connect!", 
                    "Something went wrong, check instructions.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sendCmd(String cmd)
        {
            xbox.Call(0x8230FD58, 0, cmd);
        }

        private void errorMessage()
        {
            MessageBox.Show("Failed to send command, something went wrong!",
                    "Project Veli Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void godMode_Click(object sender, EventArgs e)
        {
            try
            {
                sendCmd("god");
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void noClip_Click(object sender, EventArgs e)
        {
            try
            {
                sendCmd("noclip");
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void ammoButton_Click(object sender, EventArgs e)
        {
            try
            {
                sendCmd("give ammo");
                xbox.Call(0x82329850, new object[] { -1, 0, "c \"Ammo Has Been ^1Given!\"" });
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void thirdPerson_Click(object sender, EventArgs e)
        {
            try
            {
                sendCmd("toggle cg_thirdperson");
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void slowMotion_Click(object sender, EventArgs e)
        {
            try
            {
                sendCmd("toggle timescale 0.2 1");
                if (slowMotion.Text == "Slow Motion")
                {
                    slowMotion.Text = "Revert Game Speed";
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Slow-Motion: ^2Enabled!\"" });
                }
                else
                {
                    slowMotion.Text = "Slow Motion";
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Slow-Motion: ^1Disabled!\"" });
                }
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void restartMap_Click(object sender, EventArgs e)
        {
            try
            {
                sendCmd("map_restart");
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void moneyButton_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] Values = { 0x00, 0x06, 0x68, 0xA0 };
                xbox.SetMemory(0x82DC33B4, Values);
                xbox.SetMemory(0x82DC50DC, Values);
                xbox.SetMemory(0x82DC6E04, Values);
                xbox.SetMemory(0x82DC8B2C, Values);
                xbox.Call(0x82329850, new object[] { -1, 0, "c \"^2$420k ^6has been granted to ^1ALL ^6players.\"" });
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void zmWeapon_Click(object sender, EventArgs e)
        {
            try
            {
                sendCmd("give " + zmWeapons.SelectedItem);
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void playerSpeedButton_Click(object sender, EventArgs e)
        {
            try
            {
                sendCmd("g_speed " + playerSpeed.Value);
                xbox.Call(0x82329850, new object[] { -1, 0, "c \"Player Speed Set To: ^6" + playerSpeed.Value.ToString() + "\"" });
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void timescale_Click(object sender, EventArgs e)
        {
            try
            {
                sendCmd("toggle timescale " + timescaleBar.Value);
                xbox.Call(0x82329850, new object[] { -1, 0, "c \"Timescale Set To: ^6" + timescaleBar.Value.ToString() + "\"" });
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void unAmmo_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] Values = { 0xFF, 0xFF, 0xFF, 0xFF };
                xbox.Call(0x82329850, new object[] { -1, 0, "c \"Infinite Ammo: ^2Enabled!\"" });
                xbox.SetMemory(0x82143E8C, Values);
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void fallDamage_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] Values = { 0x64, 0x00, 0x00, 0x00 };
                xbox.SetMemory(0x820054E0, Values);
                xbox.Call(0x82329850, new object[] { -1, 0, "c \"No Fall Damage: ^2Enabled!\"" });
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void jumpHeight_Click(object sender, EventArgs e)
        {
            try
            {
                if (jumpHeight.Text == "Jump High")
                {
                    byte[] Values = { 0x48, 0x00, 0x00, 0x00 };
                    xbox.SetMemory(0x82002B60, Values);
                    jumpHeight.Text = "Normal Jump";
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Jump High: ^2Enabled!\"" });
                    MessageBox.Show("MAKE SURE TO DISABLE FALL DAMAGE!\n\nYou will die from jump height if you do not do so.",
                            "Jump High Is Enabled!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    byte[] ogValues = { 0x42, 0x1C, 0x00, 0x00 };
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Jump High: ^1Disabled!\"" });
                    xbox.SetMemory(0x82002B60, ogValues);
                    jumpHeight.Text = "Jump High";
                }
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void customNoti_Click(object sender, EventArgs e)
        {
            try
            {
                uint notiType = 0;
                /*if (smileNotiCheck.GetItemChecked(0) == true)
                {
                    notiType = 14;
                }*/
                console.XNotify(customNotiBox.Text, notiType);
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void screenshotButton_Click(object sender, EventArgs e)
        {
            try
            {
                console.ShutDownConsole();
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void bindNoClip_Click(object sender, EventArgs e)
        {
            try
            {
                sendCmd("bind DPAD_DOWN noclip");
                MessageBox.Show("No-Clip has successfully been binded\nto the 'DOWN D-PAD' button.",
                        "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xbox.Call(0x82329850, new object[] { -1, 0, "c \"No-Clip has been binded to the ^2'DOWN D-PAD'\"" });
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void dropWeapon_Click(object sender, EventArgs e)
        {
            try
            {
                sendCmd("dropweapon");
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void selfMoney_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] Values = { 0x00, 0x06, 0x68, 0xA0 };
                xbox.SetMemory(0x82DC33B4, Values);
                xbox.Call(0x82329850, new object[] { -1, 0, "c \"^2$420k ^6has been given.\"" });
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void cartoonMode_Click(object sender, EventArgs e)
        {
            try
            {
                sendCmd("toggle r_fullbright 1 0");
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void paintballMode_Click(object sender, EventArgs e)
        {
            try
            {
                sendCmd("toggle r_debuglayers");
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Score Color [Red]")
            {
                try
                {
                    sendCmd("cg_scorescolor_gamertag_0 1 0 0 1");
                    button1.Text = "Score Color [Yellow]";
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Score Color Set To: ^1Red\"" });
                }
                catch (Exception)
                {
                    errorMessage();
                }
            }
            else if (button1.Text == "Score Color [Yellow]")
            {
                try
                {
                    sendCmd("cg_scorescolor_gamertag_0 1 1 0 0");
                    button1.Text = "Score Color [Pink]";
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Score Color Set To: ^3Yellow\"" });
                }
                catch (Exception)
                {
                    errorMessage();
                }
            }
            else if (button1.Text == "Score Color [Pink]")
            {
                try
                {
                    sendCmd("cg_scorescolor_gamertag_0 1 0 1 0");
                    button1.Text = "Score Color [Cyan]";
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Score Color Set To: ^6Pink\"" });
                }
                catch (Exception)
                {
                    errorMessage();
                }
            }
            else if (button1.Text == "Score Color [Cyan]")
            {
                try
                {
                    sendCmd("cg_scorescolor_gamertag_0 0 1 1 0");
                    button1.Text = "Score Color [Blue]";
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Score Color Set To: ^5Cyan\"" });
                }
                catch (Exception)
                {
                    errorMessage();
                }
            }
            else if (button1.Text == "Score Color [Blue]")
            {
                try
                {
                    sendCmd("cg_scorescolor_gamertag_0 0 0 1 0");
                    button1.Text = "Score Color [Revert]";
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Score Color Set To: ^4Blue\"" });
                }
                catch (Exception)
                {
                    errorMessage();
                }
            }
            else if (button1.Text == "Score Color [Black]")
            {
                try
                {
                    sendCmd("cg_scorescolor_gamertag_0 0 0 0 1");
                    button1.Text = "Score Color [Revert]";
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Score Color Set To: ^0Black\"" });
                }
                catch (Exception)
                {
                    errorMessage();
                }
            }
            else if (button1.Text == "Score Color [Revert]")
            {
                try
                {
                    sendCmd("cg_scorescolor_gamertag_0 1 1 1 1");
                    button1.Text = "Score Color [Red]";
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Score Color Set To: ^8Default\"" });
                }
                catch (Exception)
                {
                    errorMessage();
                }
            }
        }

        private void zombSpawn_Click(object sender, EventArgs e)
        {
            if (zombSpawn.Text == "Disable Zombs")
            {
                try
                {
                    sendCmd("G_Ai 0");
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Zombies: ^1Disabled!\"" });
                    zombSpawn.Text = "Enable Zombs";
                }
                catch (Exception)
                {
                    errorMessage();
                }
            }
            else
            {
                try
                {
                    sendCmd("G_Ai 1");
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Zombies: ^2Re-Enabled!\"" });
                    zombSpawn.Text = "Disable Zombs";
                } 
                catch (Exception)
                {
                    errorMessage();
                }
            }
        }

        private void povScale_Click(object sender, EventArgs e)
        {
            try
            {
                sendCmd("cg_fov " + povScaleValue.Value);
                xbox.Call(0x82329850, new object[] { -1, 0, "c \"FOV: ^6" + povScaleValue.Value.ToString() + "\"" });
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void playerSpeed_Scroll(object sender, EventArgs e)
        {
            playerSpeedLabel.Text = playerSpeed.Value.ToString() + " (175)";
        }

        private void povScaleValue_Scroll(object sender, EventArgs e)
        {
            povValue.Text = povScaleValue.Value.ToString() + " (65)";
        }

        private void timescaleBar_Scroll(object sender, EventArgs e)
        {
            timescaleLabel.Text = timescaleBar.Value.ToString() + " (10)";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sendCmd("toggle r_colormap 1 2 3 0");
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (button3.Text == "Sun [Red]")
                {
                    xbox.Call(0x82329850, new object[] { -1, 0, "v r_lightTweakSunColor \"1 0 0 0\"" });
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Sun Set To: ^1Red\"" });
                    button3.Text = "Sun [Purple]";
                }
                else if (button3.Text == "Sun [Purple]")
                {
                    xbox.Call(0x82329850, new object[] { -1, 0, "v r_lightTweakSunColor \"1 0 1 0\"" });
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Sun Set To: ^6Purple\"" });
                    button3.Text = "Sun [White]";
                }
                else if (button3.Text == "Sun [White]")
                {
                    xbox.Call(0x82329850, new object[] { -1, 0, "v r_lightTweakSunColor \"1 1 1 0\"" });
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Sun Set To: White\"" });
                    button3.Text = "Sun [Blue]";
                }
                else if (button3.Text == "Sun [Blue]")
                {
                    xbox.Call(0x82329850, new object[] { -1, 0, "v r_lightTweakSunColor \"0 0 1 0\"" });
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Sun Set To: ^4Blue\"" });
                    button3.Text = "Sun [Off]";
                }
                else if (button3.Text == "Sun [Off]")
                {
                    xbox.Call(0x82329850, new object[] { -1, 0, "v r_lightTweakSunColor \"0 0 0 0\"" });
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Sun Set To: ^0Dark\"" });
                    button3.Text = "Sun [Default]";
                }
                else if (button3.Text == "Sun [Default]")
                {
                    xbox.Call(0x82329850, new object[] { -1, 0, "v r_lightTweakSunColor \"1 1 1 1\"" });
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Sun Set To: ^8Default\"" });
                    button3.Text = "Sun [Red]";
                }
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void lowGravity_Click(object sender, EventArgs e)
        {
            try
            {
                if (lowGravity.Text == "Low Gravity")
                {
                    xbox.Call(0x82329850, new object[] { -1, 0, "v bg_gravity \"100\"" });
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Low Gravity: ^2Enabled\"" });
                    lowGravity.Text = "Disable Gravity";
                }
                else
                {
                    xbox.Call(0x82329850, new object[] { -1, 0, "v bg_gravity \"800\"" });
                    xbox.Call(0x82329850, new object[] { -1, 0, "c \"Low Gravity: ^1Disabled\"" });
                    lowGravity.Text = "Low Gravity";
                }
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void setGamertag_Click(object sender, EventArgs e)
        {
            try
            {
                // Patch, shoutout Heaventh and Gamer7112
                xbox.SetMemory(0x824FA18C, new byte[] { 0x60, 0x00, 0x00, 0x00 });
                xbox.SetMemory(0x83D077F0, new byte[] { 0x7C, 0x83, 0x23, 0x78, 0x3D, 0x60, 0x83, 0xD0, 0x38, 0x8B, 0x78, 0x68, 0x38, 0x00, 0x00, 0x20, 0x3D, 0x60, 0x82, 0x3F, 0x39, 0x6B, 0xE5, 0x18, 0x7D, 0x69, 0x03, 0xA6, 0x4E, 0x80, 0x04, 0x20 });
                xbox.SetMemory(0x826CF418, new byte[] { 0x3D, 0x60, 0x83, 0xD0, 0x39, 0x6B, 0x77, 0xF0, 0x7D, 0x69, 0x03, 0xA6, 0x4E, 0x80, 0x04, 0x20 });

                // I did this part, @Hunaveli
                byte[] gamertag = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                char[] gamertagText = gamertagBox.Text.ToCharArray();

                for (int b = 0; b < gamertagText.Length; b++)
                {
                    char temp = gamertagText[b];
                    byte textByte = (byte)temp;
                    gamertag[b] = textByte;
                }

                xbox.SetMemory(0x83D07868, gamertag);
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void prestigeButton_Click(object sender, EventArgs e)
        {
            try
            {
                string prestige = prestigeSelection.Value.ToString();
                int prestigeInt = int.Parse(prestige);
                byte[] Values = { ((byte)prestigeInt) };
                xbox.SetMemory(0x84085720 + 0x90DD, Values);
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void killsButton_Click(object sender, EventArgs e)
        {
            try
            {
                string kills = killsSelection.Value.ToString();
                int killsInt = int.Parse(kills);
                byte[] Values = { ((byte)killsInt) };
                xbox.SetMemory(0x84085720 + 0x8E29, Values);
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void deathsButtonBO_Click(object sender, EventArgs e)
        {
            try
            {
                string deaths = deathSelectionBO.Value.ToString();
                int deathsInt = int.Parse(deaths);
                byte[] Values = { ((byte)deathsInt) };
                xbox.SetMemory(0x84085720 + 0x8CF5, Values);
            }
            catch (Exception)
            {
                errorMessage();
            }
        }

        private void maxRankBO_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] rankLevel = { 0x31 };
                xbox.SetMemory(0x84085720 + 0x90E1, rankLevel);
                byte[] rankXP = { 0xA4, 0x43, 0x13, 0x00, 0x02, 0x00, 0x00, 0x00, 0x2B };
                xbox.SetMemory(0x84085720 + 0x90E5, rankXP);
            }
            catch (Exception)
            {
                errorMessage();
            }
        }
    }
}
