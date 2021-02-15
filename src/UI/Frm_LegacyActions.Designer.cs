﻿namespace AITool
{
    partial class Frm_LegacyActions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_LegacyActions));
            this.cb_mask_telegram = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxMQTT = new System.Windows.Forms.GroupBox();
            this.cb_MQTT_enabled = new System.Windows.Forms.CheckBox();
            this.linkLabelMqttSettings = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_MQTT_Topic = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_MQTT_Topic_Cancel = new System.Windows.Forms.TextBox();
            this.tb_MQTT_Payload = new System.Windows.Forms.TextBox();
            this.cb_MQTT_SendImage = new System.Windows.Forms.CheckBox();
            this.tb_MQTT_Payload_cancel = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBoxTelegram = new System.Windows.Forms.GroupBox();
            this.cb_telegram = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_telegram_caption = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_telegram_active_time = new System.Windows.Forms.TextBox();
            this.tb_telegram_triggering_objects = new System.Windows.Forms.TextBox();
            this.tb_RunExternalProgram = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tb_network_folder = new System.Windows.Forms.TextBox();
            this.groupBoxPushover = new System.Windows.Forms.GroupBox();
            this.cb_Pushover_Enabled = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_pushover_triggering_objects = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tb_Pushover_Title = new System.Windows.Forms.TextBox();
            this.cb_pushover_active_time = new System.Windows.Forms.TextBox();
            this.tb_Pushover_Message = new System.Windows.Forms.TextBox();
            this.tb_Pushover_Device = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tb_Pushover_sound = new System.Windows.Forms.TextBox();
            this.tb_Pushover_Priority = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_jpeg_merge_quality = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_queue_actions = new System.Windows.Forms.CheckBox();
            this.cb_mergeannotations = new System.Windows.Forms.CheckBox();
            this.tb_network_folder_filename = new System.Windows.Forms.TextBox();
            this.tb_Sounds = new System.Windows.Forms.TextBox();
            this.cb_PlaySound = new System.Windows.Forms.CheckBox();
            this.tb_RunExternalProgramArgs = new System.Windows.Forms.TextBox();
            this.cb_RunProgram = new System.Windows.Forms.CheckBox();
            this.cb_copyAlertImages = new System.Windows.Forms.CheckBox();
            this.tbCancelUrl = new System.Windows.Forms.TextBox();
            this.tbTriggerUrl = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTriggerUrl = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Confidence = new System.Windows.Forms.Label();
            this.lbl_DetectionFormat = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_ConfidenceFormat = new System.Windows.Forms.TextBox();
            this.tb_DetectionFormat = new System.Windows.Forms.TextBox();
            this.tb_cooldown = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btTest = new System.Windows.Forms.Button();
            this.bt_variables = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_sound_cooldown = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBoxMQTT.SuspendLayout();
            this.groupBoxTelegram.SuspendLayout();
            this.groupBoxPushover.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.Location = new System.Drawing.Point(802, 654);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.Location = new System.Drawing.Point(724, 654);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.groupBoxMQTT);
            this.groupBox1.Controls.Add(this.groupBoxTelegram);
            this.groupBox1.Controls.Add(this.tb_RunExternalProgram);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.tb_network_folder);
            this.groupBox1.Controls.Add(this.groupBoxPushover);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tb_jpeg_merge_quality);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cb_queue_actions);
            this.groupBox1.Controls.Add(this.cb_mergeannotations);
            this.groupBox1.Controls.Add(this.tb_network_folder_filename);
            this.groupBox1.Controls.Add(this.tb_Sounds);
            this.groupBox1.Controls.Add(this.cb_PlaySound);
            this.groupBox1.Controls.Add(this.tb_RunExternalProgramArgs);
            this.groupBox1.Controls.Add(this.cb_RunProgram);
            this.groupBox1.Controls.Add(this.cb_copyAlertImages);
            this.groupBox1.Controls.Add(this.tbCancelUrl);
            this.groupBox1.Controls.Add(this.tbTriggerUrl);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblTriggerUrl);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbl_Confidence);
            this.groupBox1.Controls.Add(this.lbl_DetectionFormat);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tb_ConfidenceFormat);
            this.groupBox1.Controls.Add(this.tb_DetectionFormat);
            this.groupBox1.Controls.Add(this.tb_sound_cooldown);
            this.groupBox1.Controls.Add(this.tb_cooldown);
            this.groupBox1.Location = new System.Drawing.Point(8, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(864, 632);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // cb_mask_telegram
            // 
            this.cb_mask_telegram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_mask_telegram.AutoSize = true;
            this.cb_mask_telegram.Location = new System.Drawing.Point(790, 24);
            this.cb_mask_telegram.Name = "cb_mask_telegram";
            this.cb_mask_telegram.Size = new System.Drawing.Size(54, 19);
            this.cb_mask_telegram.TabIndex = 47;
            this.cb_mask_telegram.Text = "Mask";
            this.cb_mask_telegram.UseVisualStyleBackColor = true;
            // 
            // 
            // groupBoxMQTT
            // 
            this.groupBoxMQTT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMQTT.Controls.Add(this.cb_MQTT_enabled);
            this.groupBoxMQTT.Controls.Add(this.linkLabelMqttSettings);
            this.groupBoxMQTT.Controls.Add(this.label1);
            this.groupBoxMQTT.Controls.Add(this.tb_MQTT_Topic);
            this.groupBoxMQTT.Controls.Add(this.label9);
            this.groupBoxMQTT.Controls.Add(this.tb_MQTT_Topic_Cancel);
            this.groupBoxMQTT.Controls.Add(this.tb_MQTT_Payload);
            this.groupBoxMQTT.Controls.Add(this.cb_MQTT_SendImage);
            this.groupBoxMQTT.Controls.Add(this.tb_MQTT_Payload_cancel);
            this.groupBoxMQTT.Controls.Add(this.label12);
            this.groupBoxMQTT.Controls.Add(this.label13);
            this.groupBoxMQTT.Location = new System.Drawing.Point(3, 288);
            this.groupBoxMQTT.Name = "groupBoxMQTT";
            this.groupBoxMQTT.Size = new System.Drawing.Size(853, 87);
            this.groupBoxMQTT.TabIndex = 53;
            this.groupBoxMQTT.TabStop = false;
            // 
            // cb_MQTT_enabled
            // 
            this.cb_MQTT_enabled.AutoSize = true;
            this.cb_MQTT_enabled.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cb_MQTT_enabled.Location = new System.Drawing.Point(6, 0);
            this.cb_MQTT_enabled.Name = "cb_MQTT_enabled";
            this.cb_MQTT_enabled.Size = new System.Drawing.Size(138, 19);
            this.cb_MQTT_enabled.TabIndex = 35;
            this.cb_MQTT_enabled.Text = "Send MQTT Message:";
            this.toolTip1.SetToolTip(this.cb_MQTT_enabled, "For now, see JSON config file for server, port, username, password settings");
            this.cb_MQTT_enabled.UseVisualStyleBackColor = true;
            this.cb_MQTT_enabled.CheckedChanged += new System.EventHandler(this.cb_MQTT_enabled_CheckedChanged);
            // 
            // linkLabelMqttSettings
            // 
            this.linkLabelMqttSettings.AutoSize = true;
            this.linkLabelMqttSettings.Location = new System.Drawing.Point(150, 1);
            this.linkLabelMqttSettings.Name = "linkLabelMqttSettings";
            this.linkLabelMqttSettings.Size = new System.Drawing.Size(49, 15);
            this.linkLabelMqttSettings.TabIndex = 41;
            this.linkLabelMqttSettings.TabStop = true;
            this.linkLabelMqttSettings.Text = "Settings";
            this.toolTip1.SetToolTip(this.linkLabelMqttSettings, "Global MQTT Settings");
            this.linkLabelMqttSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMqttSettings_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Trigger Topic:";
            // 
            // tb_MQTT_Topic
            // 
            this.tb_MQTT_Topic.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MQTT_Topic.Location = new System.Drawing.Point(87, 25);
            this.tb_MQTT_Topic.Name = "tb_MQTT_Topic";
            this.tb_MQTT_Topic.Size = new System.Drawing.Size(219, 20);
            this.tb_MQTT_Topic.TabIndex = 37;
            this.tb_MQTT_Topic.Tag = "";
            this.toolTip1.SetToolTip(this.tb_MQTT_Topic, "Specify more than one topic/payload by using the PIPE | symbol between each.");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(4, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 15);
            this.label9.TabIndex = 36;
            this.label9.Text = "Cancel Topic:";
            // 
            // tb_MQTT_Topic_Cancel
            // 
            this.tb_MQTT_Topic_Cancel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MQTT_Topic_Cancel.Location = new System.Drawing.Point(87, 53);
            this.tb_MQTT_Topic_Cancel.Name = "tb_MQTT_Topic_Cancel";
            this.tb_MQTT_Topic_Cancel.Size = new System.Drawing.Size(219, 20);
            this.tb_MQTT_Topic_Cancel.TabIndex = 37;
            this.tb_MQTT_Topic_Cancel.Tag = "";
            this.toolTip1.SetToolTip(this.tb_MQTT_Topic_Cancel, "Specify more than one topic/payload by using the PIPE | symbol between each.");
            // 
            // tb_MQTT_Payload
            // 
            this.tb_MQTT_Payload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_MQTT_Payload.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MQTT_Payload.Location = new System.Drawing.Point(392, 25);
            this.tb_MQTT_Payload.Name = "tb_MQTT_Payload";
            this.tb_MQTT_Payload.Size = new System.Drawing.Size(340, 20);
            this.tb_MQTT_Payload.TabIndex = 38;
            this.tb_MQTT_Payload.Tag = "";
            this.toolTip1.SetToolTip(this.tb_MQTT_Payload, "Specify more than one topic/payload by using the PIPE | symbol between each.");
            // 
            // cb_MQTT_SendImage
            // 
            this.cb_MQTT_SendImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_MQTT_SendImage.AutoSize = true;
            this.cb_MQTT_SendImage.Location = new System.Drawing.Point(757, 27);
            this.cb_MQTT_SendImage.Name = "cb_MQTT_SendImage";
            this.cb_MQTT_SendImage.Size = new System.Drawing.Size(88, 19);
            this.cb_MQTT_SendImage.TabIndex = 50;
            this.cb_MQTT_SendImage.Text = "Send Image";
            this.toolTip1.SetToolTip(this.cb_MQTT_SendImage, "If one of the topics has /image and the image checkbox is checked, then the actua" +
        "l image with the detection will be sent.\r\n (use | to Separate multiple topics or" +
        " payloads.)");
            this.cb_MQTT_SendImage.UseVisualStyleBackColor = true;
            // 
            // tb_MQTT_Payload_cancel
            // 
            this.tb_MQTT_Payload_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_MQTT_Payload_cancel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MQTT_Payload_cancel.Location = new System.Drawing.Point(392, 53);
            this.tb_MQTT_Payload_cancel.Name = "tb_MQTT_Payload_cancel";
            this.tb_MQTT_Payload_cancel.Size = new System.Drawing.Size(450, 20);
            this.tb_MQTT_Payload_cancel.TabIndex = 38;
            this.tb_MQTT_Payload_cancel.Tag = "";
            this.toolTip1.SetToolTip(this.tb_MQTT_Payload_cancel, "Specify more than one topic/payload by using the PIPE | symbol between each.");
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(334, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 15);
            this.label12.TabIndex = 39;
            this.label12.Text = "Payload:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.DarkRed;
            this.label13.Location = new System.Drawing.Point(334, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 15);
            this.label13.TabIndex = 39;
            this.label13.Text = "Payload:";
            // 
            // groupBoxTelegram
            // 
            this.groupBoxTelegram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTelegram.Controls.Add(this.cb_telegram);
            this.groupBoxTelegram.Controls.Add(this.label7);
            this.groupBoxTelegram.Controls.Add(this.tb_telegram_caption);
            this.groupBoxTelegram.Controls.Add(this.label20);
            this.groupBoxTelegram.Controls.Add(this.label4);
            this.groupBoxTelegram.Controls.Add(this.cb_telegram_active_time);
            this.groupBoxTelegram.Controls.Add(this.tb_telegram_triggering_objects);
            this.groupBoxTelegram.Location = new System.Drawing.Point(3, 108);
            this.groupBoxTelegram.Name = "groupBoxTelegram";
            this.groupBoxTelegram.Size = new System.Drawing.Size(853, 58);
            this.groupBoxTelegram.TabIndex = 52;
            this.groupBoxTelegram.TabStop = false;
            // 
            // cb_telegram
            // 
            this.cb_telegram.AutoSize = true;
            this.cb_telegram.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cb_telegram.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cb_telegram.Location = new System.Drawing.Point(8, 0);
            this.cb_telegram.Margin = new System.Windows.Forms.Padding(10, 6, 5, 6);
            this.cb_telegram.Name = "cb_telegram";
            this.cb_telegram.Size = new System.Drawing.Size(184, 19);
            this.cb_telegram.TabIndex = 24;
            this.cb_telegram.Text = "Send alert images to Telegram";
            this.cb_telegram.UseVisualStyleBackColor = false;
            this.cb_telegram.CheckedChanged += new System.EventHandler(this.cb_telegram_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 15);
            this.label7.TabIndex = 43;
            this.label7.Text = "Title:";
            // 
            // tb_telegram_caption
            // 
            this.tb_telegram_caption.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_telegram_caption.Location = new System.Drawing.Point(55, 25);
            this.tb_telegram_caption.Name = "tb_telegram_caption";
            this.tb_telegram_caption.Size = new System.Drawing.Size(219, 20);
            this.tb_telegram_caption.TabIndex = 42;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(581, 28);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(36, 15);
            this.label20.TabIndex = 44;
            this.label20.Text = "Time:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 44;
            this.label4.Text = "Objects:";
            // 
            // cb_telegram_active_time
            // 
            this.cb_telegram_active_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_telegram_active_time.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_telegram_active_time.Location = new System.Drawing.Point(623, 25);
            this.cb_telegram_active_time.Name = "cb_telegram_active_time";
            this.cb_telegram_active_time.Size = new System.Drawing.Size(219, 20);
            this.cb_telegram_active_time.TabIndex = 45;
            this.toolTip1.SetToolTip(this.cb_telegram_active_time, "Time range (24 hr) when sending to Telegram is active");
            // 
            // tb_telegram_triggering_objects
            // 
            this.tb_telegram_triggering_objects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_telegram_triggering_objects.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_telegram_triggering_objects.Location = new System.Drawing.Point(341, 25);
            this.tb_telegram_triggering_objects.Name = "tb_telegram_triggering_objects";
            this.tb_telegram_triggering_objects.Size = new System.Drawing.Size(219, 20);
            this.tb_telegram_triggering_objects.TabIndex = 45;
            this.toolTip1.SetToolTip(this.tb_telegram_triggering_objects, "Leave blank for ALL or list objects you want telegrams to be\r\nsent for - \"Person," +
        " VelociRabbit, etc\".  Not case sensitive.");
            // 
            // tb_RunExternalProgram
            // 
            this.tb_RunExternalProgram.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tb_RunExternalProgram.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tb_RunExternalProgram.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_RunExternalProgram.Location = new System.Drawing.Point(191, 416);
            this.tb_RunExternalProgram.Name = "tb_RunExternalProgram";
            this.tb_RunExternalProgram.Size = new System.Drawing.Size(295, 20);
            this.tb_RunExternalProgram.TabIndex = 31;
            this.toolTip1.SetToolTip(this.tb_RunExternalProgram, "Path to EXE, BAT, etc");
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(489, 388);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 15);
            this.label15.TabIndex = 44;
            this.label15.Text = "Filename:";
            // 
            // tb_network_folder
            // 
            this.tb_network_folder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tb_network_folder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tb_network_folder.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_network_folder.Location = new System.Drawing.Point(191, 385);
            this.tb_network_folder.Name = "tb_network_folder";
            this.tb_network_folder.Size = new System.Drawing.Size(295, 20);
            this.tb_network_folder.TabIndex = 28;
            // 
            // groupBoxPushover
            // 
            this.groupBoxPushover.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPushover.Controls.Add(this.cb_Pushover_Enabled);
            this.groupBoxPushover.Controls.Add(this.label8);
            this.groupBoxPushover.Controls.Add(this.tb_pushover_triggering_objects);
            this.groupBoxPushover.Controls.Add(this.label21);
            this.groupBoxPushover.Controls.Add(this.tb_Pushover_Title);
            this.groupBoxPushover.Controls.Add(this.cb_pushover_active_time);
            this.groupBoxPushover.Controls.Add(this.tb_Pushover_Message);
            this.groupBoxPushover.Controls.Add(this.tb_Pushover_Device);
            this.groupBoxPushover.Controls.Add(this.label17);
            this.groupBoxPushover.Controls.Add(this.tb_Pushover_sound);
            this.groupBoxPushover.Controls.Add(this.tb_Pushover_Priority);
            this.groupBoxPushover.Controls.Add(this.label10);
            this.groupBoxPushover.Controls.Add(this.label16);
            this.groupBoxPushover.Controls.Add(this.label18);
            this.groupBoxPushover.Controls.Add(this.label19);
            this.groupBoxPushover.Location = new System.Drawing.Point(3, 172);
            this.groupBoxPushover.Name = "groupBoxPushover";
            this.groupBoxPushover.Size = new System.Drawing.Size(853, 110);
            this.groupBoxPushover.TabIndex = 51;
            this.groupBoxPushover.TabStop = false;
            // 
            // cb_Pushover_Enabled
            // 
            this.cb_Pushover_Enabled.AutoSize = true;
            this.cb_Pushover_Enabled.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cb_Pushover_Enabled.Location = new System.Drawing.Point(8, 0);
            this.cb_Pushover_Enabled.Name = "cb_Pushover_Enabled";
            this.cb_Pushover_Enabled.Size = new System.Drawing.Size(185, 19);
            this.cb_Pushover_Enabled.TabIndex = 35;
            this.cb_Pushover_Enabled.Text = "Send alert images to Pushover";
            this.cb_Pushover_Enabled.UseVisualStyleBackColor = true;
            this.cb_Pushover_Enabled.CheckedChanged += new System.EventHandler(this.cb_Pushover_Enabled_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 15);
            this.label8.TabIndex = 36;
            this.label8.Text = "Title:";
            // 
            // tb_pushover_triggering_objects
            // 
            this.tb_pushover_triggering_objects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_pushover_triggering_objects.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_pushover_triggering_objects.Location = new System.Drawing.Point(623, 50);
            this.tb_pushover_triggering_objects.Name = "tb_pushover_triggering_objects";
            this.tb_pushover_triggering_objects.Size = new System.Drawing.Size(219, 20);
            this.tb_pushover_triggering_objects.TabIndex = 45;
            this.toolTip1.SetToolTip(this.tb_pushover_triggering_objects, "A list of objects that trigger send to pushover. Leave empty for default camera o" +
        "bjects.\r\n");
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 83);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(36, 15);
            this.label21.TabIndex = 44;
            this.label21.Text = "Time:";
            // 
            // tb_Pushover_Title
            // 
            this.tb_Pushover_Title.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Pushover_Title.Location = new System.Drawing.Point(55, 22);
            this.tb_Pushover_Title.Name = "tb_Pushover_Title";
            this.tb_Pushover_Title.Size = new System.Drawing.Size(219, 20);
            this.tb_Pushover_Title.TabIndex = 37;
            this.tb_Pushover_Title.Tag = "";
            this.toolTip1.SetToolTip(this.tb_Pushover_Title, "Specify more than one title/message/device by using the PIPE | symbol between eac" +
        "h.");
            // 
            // cb_pushover_active_time
            // 
            this.cb_pushover_active_time.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_pushover_active_time.Location = new System.Drawing.Point(55, 79);
            this.cb_pushover_active_time.Name = "cb_pushover_active_time";
            this.cb_pushover_active_time.Size = new System.Drawing.Size(219, 20);
            this.cb_pushover_active_time.TabIndex = 45;
            this.toolTip1.SetToolTip(this.cb_pushover_active_time, "Time range (24 hr) when sending to Pushover is active");
            // 
            // tb_Pushover_Message
            // 
            this.tb_Pushover_Message.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Pushover_Message.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Pushover_Message.Location = new System.Drawing.Point(341, 22);
            this.tb_Pushover_Message.Name = "tb_Pushover_Message";
            this.tb_Pushover_Message.Size = new System.Drawing.Size(219, 20);
            this.tb_Pushover_Message.TabIndex = 38;
            this.tb_Pushover_Message.Tag = "";
            this.toolTip1.SetToolTip(this.tb_Pushover_Message, "Specify more than one title/message/device by using the PIPE | symbol between eac" +
        "h.");
            // 
            // tb_Pushover_Device
            // 
            this.tb_Pushover_Device.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Pushover_Device.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Pushover_Device.Location = new System.Drawing.Point(623, 21);
            this.tb_Pushover_Device.Name = "tb_Pushover_Device";
            this.tb_Pushover_Device.Size = new System.Drawing.Size(219, 20);
            this.tb_Pushover_Device.TabIndex = 38;
            this.tb_Pushover_Device.Tag = "";
            this.toolTip1.SetToolTip(this.tb_Pushover_Device, "Specify more than one title/message/device by using the PIPE | symbol between eac" +
        "h.");
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(567, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 15);
            this.label17.TabIndex = 44;
            this.label17.Text = "Objects:";
            // 
            // tb_Pushover_sound
            // 
            this.tb_Pushover_sound.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Pushover_sound.Location = new System.Drawing.Point(55, 51);
            this.tb_Pushover_sound.Name = "tb_Pushover_sound";
            this.tb_Pushover_sound.Size = new System.Drawing.Size(219, 20);
            this.tb_Pushover_sound.TabIndex = 38;
            this.tb_Pushover_sound.Tag = "";
            this.toolTip1.SetToolTip(this.tb_Pushover_sound, "specify a sound name Pushover supports such as bike, bugle, cosmic, etc");
            // 
            // tb_Pushover_Priority
            // 
            this.tb_Pushover_Priority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Pushover_Priority.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Pushover_Priority.Location = new System.Drawing.Point(341, 51);
            this.tb_Pushover_Priority.Name = "tb_Pushover_Priority";
            this.tb_Pushover_Priority.Size = new System.Drawing.Size(219, 20);
            this.tb_Pushover_Priority.TabIndex = 38;
            this.tb_Pushover_Priority.Tag = "";
            this.toolTip1.SetToolTip(this.tb_Pushover_Priority, "Lowest, Low, Normal, High, Emergency");
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(279, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 15);
            this.label10.TabIndex = 39;
            this.label10.Text = "Message:";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(572, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 15);
            this.label16.TabIndex = 39;
            this.label16.Text = "Device:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 55);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 15);
            this.label18.TabIndex = 39;
            this.label18.Text = "Sound:";
            this.toolTip1.SetToolTip(this.label18, "The name of the sound you want to play");
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(287, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 15);
            this.label19.TabIndex = 39;
            this.label19.Text = "Priority:";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(498, 419);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 15);
            this.label14.TabIndex = 40;
            this.label14.Text = "Params:";
            // 
            // tb_jpeg_merge_quality
            // 
            this.tb_jpeg_merge_quality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_jpeg_merge_quality.Location = new System.Drawing.Point(794, 17);
            this.tb_jpeg_merge_quality.Name = "tb_jpeg_merge_quality";
            this.tb_jpeg_merge_quality.Size = new System.Drawing.Size(62, 23);
            this.tb_jpeg_merge_quality.TabIndex = 49;
            this.toolTip1.SetToolTip(this.tb_jpeg_merge_quality, "The larger the number, the higher the image quality AND SIZE.   If you lower this" +
        " number to\r\n50 or below, images will be smaller and sent to Telegram faster.");
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(608, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 15);
            this.label2.TabIndex = 48;
            this.label2.Text = "Merge JPEG Save Quality (1-100):";
            // 
            // cb_queue_actions
            // 
            this.cb_queue_actions.AutoSize = true;
            this.cb_queue_actions.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cb_queue_actions.Location = new System.Drawing.Point(263, 19);
            this.cb_queue_actions.Name = "cb_queue_actions";
            this.cb_queue_actions.Size = new System.Drawing.Size(104, 19);
            this.cb_queue_actions.TabIndex = 47;
            this.cb_queue_actions.Text = "Queue Actions";
            this.toolTip1.SetToolTip(this.cb_queue_actions, resources.GetString("cb_queue_actions.ToolTip"));
            this.cb_queue_actions.UseVisualStyleBackColor = true;
            // 
            // cb_mergeannotations
            // 
            this.cb_mergeannotations.AutoSize = true;
            this.cb_mergeannotations.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cb_mergeannotations.Location = new System.Drawing.Point(392, 19);
            this.cb_mergeannotations.Name = "cb_mergeannotations";
            this.cb_mergeannotations.Size = new System.Drawing.Size(193, 19);
            this.cb_mergeannotations.TabIndex = 46;
            this.cb_mergeannotations.Text = "Merge Annotations Into Images";
            this.toolTip1.SetToolTip(this.cb_mergeannotations, "Merge detected object text and rectangles into actual image.");
            this.cb_mergeannotations.UseVisualStyleBackColor = true;
            this.cb_mergeannotations.CheckedChanged += new System.EventHandler(this.cb_mergeannotations_CheckedChanged);
            // 
            // tb_network_folder_filename
            // 
            this.tb_network_folder_filename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_network_folder_filename.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_network_folder_filename.Location = new System.Drawing.Point(550, 385);
            this.tb_network_folder_filename.Name = "tb_network_folder_filename";
            this.tb_network_folder_filename.Size = new System.Drawing.Size(295, 20);
            this.tb_network_folder_filename.TabIndex = 45;
            this.toolTip1.SetToolTip(this.tb_network_folder_filename, "The filename to be created in the network folder NOT including file extension.  F" +
        "or example, [camera] would be saved as MYCAMERA.JPG");
            // 
            // tb_Sounds
            // 
            this.tb_Sounds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Sounds.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Sounds.Location = new System.Drawing.Point(191, 444);
            this.tb_Sounds.Name = "tb_Sounds";
            this.tb_Sounds.Size = new System.Drawing.Size(500, 20);
            this.tb_Sounds.TabIndex = 34;
            this.toolTip1.SetToolTip(this.tb_Sounds, resources.GetString("tb_Sounds.ToolTip"));
            // 
            // cb_PlaySound
            // 
            this.cb_PlaySound.AutoSize = true;
            this.cb_PlaySound.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cb_PlaySound.Location = new System.Drawing.Point(9, 446);
            this.cb_PlaySound.Name = "cb_PlaySound";
            this.cb_PlaySound.Size = new System.Drawing.Size(88, 19);
            this.cb_PlaySound.TabIndex = 33;
            this.cb_PlaySound.Text = "Play Sound:";
            this.cb_PlaySound.UseVisualStyleBackColor = true;
            this.cb_PlaySound.CheckedChanged += new System.EventHandler(this.cb_PlaySound_CheckedChanged);
            // 
            // tb_RunExternalProgramArgs
            // 
            this.tb_RunExternalProgramArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_RunExternalProgramArgs.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_RunExternalProgramArgs.Location = new System.Drawing.Point(550, 416);
            this.tb_RunExternalProgramArgs.Name = "tb_RunExternalProgramArgs";
            this.tb_RunExternalProgramArgs.Size = new System.Drawing.Size(295, 20);
            this.tb_RunExternalProgramArgs.TabIndex = 32;
            this.toolTip1.SetToolTip(this.tb_RunExternalProgramArgs, "Command line arguments to run the external app or script");
            // 
            // cb_RunProgram
            // 
            this.cb_RunProgram.AutoSize = true;
            this.cb_RunProgram.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cb_RunProgram.Location = new System.Drawing.Point(9, 417);
            this.cb_RunProgram.Name = "cb_RunProgram";
            this.cb_RunProgram.Size = new System.Drawing.Size(144, 19);
            this.cb_RunProgram.TabIndex = 30;
            this.cb_RunProgram.Text = "Run external program:";
            this.cb_RunProgram.UseVisualStyleBackColor = true;
            this.cb_RunProgram.CheckedChanged += new System.EventHandler(this.cb_RunProgram_CheckedChanged);
            // 
            // cb_copyAlertImages
            // 
            this.cb_copyAlertImages.AutoSize = true;
            this.cb_copyAlertImages.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cb_copyAlertImages.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cb_copyAlertImages.Location = new System.Drawing.Point(9, 386);
            this.cb_copyAlertImages.Margin = new System.Windows.Forms.Padding(40, 8, 7, 8);
            this.cb_copyAlertImages.Name = "cb_copyAlertImages";
            this.cb_copyAlertImages.Size = new System.Drawing.Size(172, 19);
            this.cb_copyAlertImages.TabIndex = 27;
            this.cb_copyAlertImages.Text = "Copy alert images to folder:";
            this.toolTip1.SetToolTip(this.cb_copyAlertImages, "When an object in an image is detected, copy the image to the\r\n folder specified");
            this.cb_copyAlertImages.UseVisualStyleBackColor = false;
            this.cb_copyAlertImages.CheckedChanged += new System.EventHandler(this.cb_copyAlertImages_CheckedChanged);
            // 
            // tbCancelUrl
            // 
            this.tbCancelUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCancelUrl.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCancelUrl.Location = new System.Drawing.Point(9, 575);
            this.tbCancelUrl.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.tbCancelUrl.Multiline = true;
            this.tbCancelUrl.Name = "tbCancelUrl";
            this.tbCancelUrl.Size = new System.Drawing.Size(836, 50);
            this.tbCancelUrl.TabIndex = 22;
            this.toolTip1.SetToolTip(this.tbCancelUrl, "URLs that cancel the alert - For BI, use ");
            // 
            // tbTriggerUrl
            // 
            this.tbTriggerUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTriggerUrl.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTriggerUrl.Location = new System.Drawing.Point(9, 496);
            this.tbTriggerUrl.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.tbTriggerUrl.Multiline = true;
            this.tbTriggerUrl.Name = "tbTriggerUrl";
            this.tbTriggerUrl.Size = new System.Drawing.Size(836, 50);
            this.tbTriggerUrl.TabIndex = 22;
            this.tbTriggerUrl.Text = "test\r\ntest2\r\ntest3";
            this.toolTip1.SetToolTip(this.tbTriggerUrl, "A list of URLs each on their own line OR seperated with commas that will be trigg" +
        "ered on an alert");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label11.ForeColor = System.Drawing.Color.DarkRed;
            this.label11.Location = new System.Drawing.Point(5, 556);
            this.label11.Margin = new System.Windows.Forms.Padding(35, 0, 5, 0);
            this.label11.MinimumSize = new System.Drawing.Size(158, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(158, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "Cancel URL(s):";
            // 
            // lblTriggerUrl
            // 
            this.lblTriggerUrl.AutoSize = true;
            this.lblTriggerUrl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTriggerUrl.Location = new System.Drawing.Point(5, 477);
            this.lblTriggerUrl.Margin = new System.Windows.Forms.Padding(35, 0, 5, 0);
            this.lblTriggerUrl.MinimumSize = new System.Drawing.Size(158, 0);
            this.lblTriggerUrl.Name = "lblTriggerUrl";
            this.lblTriggerUrl.Size = new System.Drawing.Size(158, 15);
            this.lblTriggerUrl.TabIndex = 1;
            this.lblTriggerUrl.Text = "Trigger URL(s):";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label24.Location = new System.Drawing.Point(6, 77);
            this.label24.Margin = new System.Windows.Forms.Padding(35, 0, 5, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(118, 15);
            this.label24.TabIndex = 0;
            this.label24.Text = "[Confidence] format:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label22.Location = new System.Drawing.Point(16, 49);
            this.label22.Margin = new System.Windows.Forms.Padding(35, 0, 5, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(108, 15);
            this.label22.TabIndex = 0;
            this.label22.Text = "[Detection] format:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(30, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(35, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cooldown Time:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Confidence
            // 
            this.lbl_Confidence.AutoSize = true;
            this.lbl_Confidence.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_Confidence.Location = new System.Drawing.Point(389, 79);
            this.lbl_Confidence.Margin = new System.Windows.Forms.Padding(2, 0, 5, 0);
            this.lbl_Confidence.Name = "lbl_Confidence";
            this.lbl_Confidence.Size = new System.Drawing.Size(10, 15);
            this.lbl_Confidence.TabIndex = 2;
            this.lbl_Confidence.Text = ".";
            // 
            // lbl_DetectionFormat
            // 
            this.lbl_DetectionFormat.AutoSize = true;
            this.lbl_DetectionFormat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_DetectionFormat.Location = new System.Drawing.Point(389, 49);
            this.lbl_DetectionFormat.Margin = new System.Windows.Forms.Padding(2, 0, 5, 0);
            this.lbl_DetectionFormat.Name = "lbl_DetectionFormat";
            this.lbl_DetectionFormat.Size = new System.Drawing.Size(10, 15);
            this.lbl_DetectionFormat.TabIndex = 2;
            this.lbl_DetectionFormat.Text = ".";
            this.lbl_DetectionFormat.Click += new System.EventHandler(this.lbl_DetectionFormat_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(183, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Seconds";
            // 
            // tb_ConfidenceFormat
            // 
            this.tb_ConfidenceFormat.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ConfidenceFormat.Location = new System.Drawing.Point(127, 76);
            this.tb_ConfidenceFormat.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.tb_ConfidenceFormat.Name = "tb_ConfidenceFormat";
            this.tb_ConfidenceFormat.Size = new System.Drawing.Size(259, 20);
            this.tb_ConfidenceFormat.TabIndex = 21;
            this.tb_ConfidenceFormat.TextChanged += new System.EventHandler(this.tb_ConfidenceFormat_TextChanged);
            // 
            // tb_DetectionFormat
            // 
            this.tb_DetectionFormat.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_DetectionFormat.Location = new System.Drawing.Point(127, 46);
            this.tb_DetectionFormat.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.tb_DetectionFormat.Name = "tb_DetectionFormat";
            this.tb_DetectionFormat.Size = new System.Drawing.Size(259, 20);
            this.tb_DetectionFormat.TabIndex = 21;
            this.toolTip1.SetToolTip(this.tb_DetectionFormat, "This is the format for each individual detection");
            this.tb_DetectionFormat.TextChanged += new System.EventHandler(this.tb_DetectionFormat_TextChanged);
            // 
            // tb_cooldown
            // 
            this.tb_cooldown.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_cooldown.Location = new System.Drawing.Point(127, 19);
            this.tb_cooldown.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.tb_cooldown.Name = "tb_cooldown";
            this.tb_cooldown.Size = new System.Drawing.Size(44, 20);
            this.tb_cooldown.TabIndex = 21;
            // 
            // btTest
            // 
            this.btTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btTest.Location = new System.Drawing.Point(647, 654);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(70, 30);
            this.btTest.TabIndex = 6;
            this.btTest.Text = "Test";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // bt_variables
            // 
            this.bt_variables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_variables.BackColor = System.Drawing.SystemColors.Info;
            this.bt_variables.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_variables.Location = new System.Drawing.Point(8, 653);
            this.bt_variables.Name = "bt_variables";
            this.bt_variables.Size = new System.Drawing.Size(70, 30);
            this.bt_variables.TabIndex = 54;
            this.bt_variables.Text = "Variables";
            this.bt_variables.UseVisualStyleBackColor = false;
            this.bt_variables.Click += new System.EventHandler(this.bt_variables_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(697, 447);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 15);
            this.label3.TabIndex = 40;
            this.label3.Text = "Cooldown Secs:";
            // 
            // tb_sound_cooldown
            // 
            this.tb_sound_cooldown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_sound_cooldown.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_sound_cooldown.Location = new System.Drawing.Point(801, 444);
            this.tb_sound_cooldown.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.tb_sound_cooldown.Name = "tb_sound_cooldown";
            this.tb_sound_cooldown.Size = new System.Drawing.Size(44, 20);
            this.tb_sound_cooldown.TabIndex = 21;
            // 
            // Frm_LegacyActions
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(880, 692);
            this.Controls.Add(this.bt_variables);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btTest);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(896, 731);
            this.Name = "Frm_LegacyActions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Actions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_LegacyActions_FormClosing);
            this.Load += new System.EventHandler(this.Frm_LegacyActions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxMQTT.ResumeLayout(false);
            this.groupBoxMQTT.PerformLayout();
            this.groupBoxTelegram.ResumeLayout(false);
            this.groupBoxTelegram.PerformLayout();
            this.groupBoxPushover.ResumeLayout(false);
            this.groupBoxPushover.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTriggerUrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.TextBox tbTriggerUrl;
        public System.Windows.Forms.CheckBox cb_telegram;
        public System.Windows.Forms.TextBox tb_cooldown;
        public System.Windows.Forms.CheckBox cb_copyAlertImages;
        public System.Windows.Forms.TextBox tb_network_folder;
        public System.Windows.Forms.CheckBox cb_RunProgram;
        public System.Windows.Forms.TextBox tb_RunExternalProgram;
        public System.Windows.Forms.TextBox tb_RunExternalProgramArgs;
        public System.Windows.Forms.TextBox tb_Sounds;
        public System.Windows.Forms.CheckBox cb_PlaySound;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tb_MQTT_Payload;
        public System.Windows.Forms.TextBox tb_MQTT_Topic;
        public System.Windows.Forms.CheckBox cb_MQTT_enabled;
        private System.Windows.Forms.LinkLabel linkLabelMqttSettings;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox tb_telegram_caption;
        public System.Windows.Forms.TextBox tb_network_folder_filename;
        public System.Windows.Forms.CheckBox cb_mergeannotations;
        public System.Windows.Forms.TextBox tb_MQTT_Payload_cancel;
        public System.Windows.Forms.TextBox tb_MQTT_Topic_Cancel;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox tbCancelUrl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.CheckBox cb_queue_actions;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tb_jpeg_merge_quality;
        public System.Windows.Forms.TextBox tb_telegram_triggering_objects;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox cb_mask_telegram;
        public System.Windows.Forms.CheckBox cb_MQTT_SendImage;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox tb_Pushover_Message;
        public System.Windows.Forms.TextBox tb_Pushover_Title;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.CheckBox cb_Pushover_Enabled;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox tb_Pushover_Device;
        public System.Windows.Forms.TextBox tb_pushover_triggering_objects;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.TextBox tb_Pushover_sound;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.TextBox tb_Pushover_Priority;
        public System.Windows.Forms.GroupBox groupBoxPushover;
        public System.Windows.Forms.GroupBox groupBoxTelegram;
        public System.Windows.Forms.GroupBox groupBoxMQTT;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox cb_telegram_active_time;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.TextBox cb_pushover_active_time;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.TextBox tb_DetectionFormat;
        public System.Windows.Forms.Label lbl_DetectionFormat;
        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.Label lbl_Confidence;
        public System.Windows.Forms.TextBox tb_ConfidenceFormat;
        private System.Windows.Forms.Button bt_variables;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tb_sound_cooldown;
    }
}