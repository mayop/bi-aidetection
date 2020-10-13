﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AITool
{
    public partial class Frm_LegacyActions:Form
    {
        public Camera cam;

        public Frm_LegacyActions()
        {
            InitializeComponent();
        }

        private void Frm_LegacyActions_Load(object sender, EventArgs e)
        {
            Global_GUI.RestoreWindowState(this);
        }

        private void Frm_LegacyActions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global_GUI.SaveWindowState(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void linkLabelMqttSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Frm_MQTTSettings frm = new Frm_MQTTSettings())
            {

                frm.cam = this.cam;

                frm.tb_ServerPort.Text = AppSettings.Settings.mqtt_serverandport;
                frm.cb_UseTLS.Checked = AppSettings.Settings.mqtt_UseTLS;
                frm.tb_Password.Text = AppSettings.Settings.mqtt_password;
                frm.tb_Username.Text = AppSettings.Settings.mqtt_username;

                frm.tb_Topic.Text = tb_MQTT_Topic.Text.Trim();
                frm.tb_Payload.Text = tb_MQTT_Payload.Text.Trim();

                if (frm.ShowDialog() == DialogResult.OK)
                {

                    AppSettings.Settings.mqtt_UseTLS = frm.cb_UseTLS.Checked;
                    AppSettings.Settings.mqtt_username = frm.tb_Username.Text.Trim();
                    AppSettings.Settings.mqtt_serverandport = frm.tb_ServerPort.Text.Trim();
                    AppSettings.Settings.mqtt_password = frm.tb_Password.Text.Trim();

                    this.tb_MQTT_Payload.Text = frm.tb_Payload.Text.Trim();
                    this.tb_MQTT_Topic.Text = frm.tb_Topic.Text.Trim();


                    AppSettings.Save();

                }
            }
        }

        private async void btTest_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btTest.Enabled = false;
            try
            {
                using (Global_GUI.CursorWait cw = new Global_GUI.CursorWait())
                {
                    Global.Log("----------------------- TESTING TRIGGERS ----------------------------");

                    if (!string.IsNullOrEmpty(this.cam.last_image_file_with_detections) && File.Exists(this.cam.last_image_file_with_detections))
                    {
                        //test by copying the file as a new file into the watched folder'
                        string folder = Path.GetDirectoryName(this.cam.last_image_file_with_detections);
                        string filename = Path.GetFileNameWithoutExtension(this.cam.last_image_file_with_detections);
                        string ext = Path.GetExtension(this.cam.last_image_file_with_detections);
                        string testfile = Path.Combine(folder, $"{filename}_AITOOLTEST_{DateTime.Now.TimeOfDay.TotalSeconds}{ext}");
                        File.Copy(this.cam.last_image_file_with_detections, testfile, true);
                        string str = "Created test image file based on last detected object for the camera: " + testfile;
                        Global.Log(str);
                        MessageBox.Show(str, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //do a generic test of the trigger
                        //bool result = await AITOOL.Trigger(cam, null, true);
                        bool result = await AITOOL.TriggerActionQueue.AddTriggerActionAsync(TriggerType.All, cam, null, null, true, true, null, "");

                        if (result)
                        {
                            MessageBox.Show($"Succeeded! See log for details.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Failed. See log for details.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                    Global.Log("---------------------- DONE TESTING TRIGGERS -------------------------");
                }
            }
            catch { }
            finally
            {
                btnCancel.Enabled = true;
                btnSave.Enabled = true;
                btTest.Enabled = true;

            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AITOOL.ReplaceParams(this.cam, null, label3.Text));
        }

        private void cb_mergeannotations_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_mergeannotations.Checked)
                tb_jpeg_merge_quality.Enabled = true;
            else
                tb_jpeg_merge_quality.Enabled = false;

        }
    }
}
