﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AITool
{

    public enum TriggerType
    {
        Unknown,
        All,
        DownloadURL,
        PostURL,
        TelegramImageUpload,
        TelegramText,
        Sound,
        Run,
        MQTT,
        Pushover
    }
    public class CameraTriggerAction
    {
        public TriggerType Type = TriggerType.Unknown;
        public string Description = "";
        public string LastResponse = "";
    }

    public class ImageResItem : IEquatable<ImageResItem>
    {
        public int Width = 0;
        public int Height = 0;
        public long Count = 0;
        public string LastFileName = "";
        public long LastFileSize = 0;
        public float LastFileDPI = 0;
        public DateTime LastSeenDate = DateTime.MinValue;

        public ImageResItem() { }
        public ImageResItem(ClsImageQueueItem CurImg)
        {
            this.Count = 1;
            this.Height = CurImg.Height;
            this.Width = CurImg.Width;
            this.LastFileName = CurImg.image_path;
            this.LastSeenDate = CurImg.TimeCreated;
            this.LastFileSize = CurImg.FileSize;
            this.LastFileDPI = CurImg.DPI;

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ImageResItem);
        }

        public bool Equals(ImageResItem other)
        {
            return other != null &&
                   Width == other.Width &&
                   Height == other.Height;
        }

        public override int GetHashCode()
        {
            int hashCode = 859600377;
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{this.Width}x{this.Height}";
        }

        public static bool operator ==(ImageResItem left, ImageResItem right)
        {
            return EqualityComparer<ImageResItem>.Default.Equals(left, right);
        }

        public static bool operator !=(ImageResItem left, ImageResItem right)
        {
            return !(left == right);
        }
    }
    public class Camera : IEquatable<Camera>
    {
        public string Name { get; set; } = "";
        public string Prefix { get; set; } = "";
        public string BICamName { get; set; } = "";
        public string MaskFileName { get; set; } = "";
        public string triggering_objects_as_string { get; set; } = "person, bear, elephant, car, truck, bicycle, motorcycle, bus, dog, horse, boat, train, airplane, zebra, giraffe, cow, sheep, cat, bird";
        public string additional_triggering_objects_as_string { get; set; } = "SUV, VAN, Pickup Truck, Meat Popsicle";
        public string[] triggering_objects { get; set; } = new string[0];
        public string trigger_urls_as_string { get; set; } = "";
        public string[] trigger_urls { get; set; } = new string[0];
        public string cancel_urls_as_string { get; set; } = "";
        public string[] cancel_urls { get; set; } = new string[0];
        //public List<CameraTriggerAction> trigger_action_list { get; set; } = new List<CameraTriggerAction>();
        public bool trigger_url_cancels { get; set; } = false;
        public bool telegram_enabled { get; set; } = false;
        public string telegram_caption { get; set; } = "[camera] - [SummaryNonEscaped]";  //cam.name + " - " + cam.last_detections_summary
        public string telegram_triggering_objects { get; set; } = "";
        public string telegram_chatid { get; set; } = "";
        public string telegram_active_time_range { get; set; } = "00:00:00-23:59:59";
        public bool enabled { get; set; } = true;
        public double cooldown_time { get; set; } = 0;
        public int cooldown_time_seconds { get; set; } = 5;
        public int sound_cooldown_time_seconds { get; set; } = 5;
        public int threshold_lower { get; set; } = 1;
        public int threshold_upper { get; set; } = 100;

        public bool telegram_mask_enabled = false; // Mayo Added

        //watch folder for each camera
        public string input_path { get; set; } = "";
        public bool input_path_includesubfolders { get; set; } = false;

        public bool Action_image_copy_enabled { get; set; } = false;
        public bool Action_image_merge_detections { get; set; } = false;
        public bool Action_image_merge_detections_makecopy { get; set; } = true;
        public long Action_image_merge_jpegquality { get; set; } = 90;
        public string Action_network_folder { get; set; } = "";
        public string Action_network_folder_filename { get; set; } = "[ImageFilenameNoExt]";
        public int Action_network_folder_purge_older_than_days { get; set; } = 30;
        public bool Action_RunProgram { get; set; } = false;
        public string Action_RunProgramString { get; set; } = "";
        public string Action_RunProgramArgsString { get; set; } = "";
        public bool Action_PlaySounds { get; set; } = false;
        public string Action_Sounds { get; set; } = @"person ; C:\example\YOYO.WAV | bird ; C:\example\TWEET.WAV";

        public bool Action_mqtt_enabled { get; set; } = false;
        public string Action_mqtt_topic { get; set; } = "ai/[camera]/motion";
        public string Action_mqtt_payload { get; set; } = "[detections]";
        public string Action_mqtt_topic_cancel { get; set; } = "ai/[camera]/motioncancel";
        public string Action_mqtt_payload_cancel { get; set; } = "cancel";
        public bool Action_mqtt_retain_message { get; set; } = false;
        public bool Action_mqtt_send_image { get; set; } = false;
        public bool Action_queued { get; set; } = false;

        public bool Action_pushover_enabled { get; set; } = false;
        public string Action_pushover_title { get; set; } = "AI Detection - [camera]";
        public string Action_pushover_message { get; set; } = "[SummaryNonEscaped]";
        public string Action_pushover_device { get; set; } = "";
        public string Action_pushover_triggering_objects { get; set; } = "";
        public string Action_pushover_Priority { get; set; } = "Normal";
        public string Action_pushover_Sound { get; set; } = "pushover";
        public int Action_pushover_retry_seconds { get; set; } = 60;
        public int Action_pushover_expire_seconds { get; set; } = 10800;
        public string Action_pushover_retrycallback_url { get; set; } = "";
        public string Action_pushover_SupplementaryUrl { get; set; } = "";
        public string Action_pushover_active_time_range { get; set; } = "00:00:00-23:59:59";

        [JsonIgnore]
        public bool Action_Cancel_Timer_Enabled { get; set; } = false;
        [JsonIgnore]
        public DateTime Action_Cancel_Start_Time { get; set; } = DateTime.MinValue;

        public MaskManager maskManager { get; set; } = new MaskManager();
        public int mask_brush_size { get; set; } = 35;

        //stats
        public int stats_alerts { get; set; } = 0; //alert image contained relevant object counter
        public int stats_false_alerts { get; set; } = 0; //alert image contained no object counter
        public int stats_irrelevant_alerts { get; set; } = 0; //alert image contained irrelevant object counter

        public int stats_skipped_images { get; set; } = 0; //Images that were skipped due to cooldown or retry count

        [JsonIgnore]
        public int stats_skipped_images_session { get; set; } = 0; //Images that were skipped due to cooldown or retry count


        public string last_image_file { get; set; } = "";
        public string last_image_file_with_detections { get; set; } = "";

        public int XOffset { get; set; } = 0;   //these are for when deepstack is having a problem with detection rectangle being in the wrong location
        public int YOffset { get; set; } = 0;   //  Can be negative numbers

        public string ImageAdjustProfile { get; set; } = "Default";

        public string DetectionDisplayFormat { get; set; } = "[Label] [[Detail]] [confidence]";

        //Keep a list of image resolutions and the last image file name with that resolution.  This will help us keep track of which image mask to use
        public List<ImageResItem> ImageResolutions { get; set; } = new List<ImageResItem>();

        public int PredSizeMinPercentOfImage { get; set; } = 1;   //prediction must be at least this % of the image
        public int PredSizeMaxPercentOfImage { get; set; } = 95;
        public int PredSizeMinHeight { get; set; } = 0;
        public int PredSizeMinWidth { get; set; } = 0;
        public int PredSizeMaxHeight { get; set; } = 0;
        public int PredSizeMaxWidth { get; set; } = 0;

        public int MergePredictionsMinMatchPercent { get; set; } = 85;   //when combining predictions from multiple sources (deepstack/aws for example) the two objects have to match at least this much to be considered the same

        [JsonIgnore]
        public ThreadSafe.Datetime last_trigger_time { get; set; } = new ThreadSafe.Datetime(DateTime.MinValue);
        [JsonIgnore]
        public ThreadSafe.Datetime last_sound_time { get; set; } = new ThreadSafe.Datetime(DateTime.MinValue);

        [JsonIgnore]
        public string LastGetCameraMatchResult { get; set; } = "";

        [JsonIgnore]
        public List<string> last_detections { get; set; } = new List<string>(); //stores objects that were detected last
        [JsonIgnore]
        public List<string> last_details { get; set; } = new List<string>(); //stores objects that were detected last
        [JsonIgnore]
        public List<float> last_confidences { get; set; } = new List<float>(); //stores last objects confidences
        [JsonIgnore]
        public List<string> last_positions { get; set; } = new List<string>(); //stores last objects positions
        [JsonIgnore]
        public String last_detections_summary; //summary text of last detection
        [JsonIgnore]
        private object CamLock { get; set; } = new object();


        public string GetMaskFile(bool MustExist, ClsImageQueueItem CurImg = null, ImageResItem ir = null)
        {
            string ret = "";

            lock (CamLock)
            {
                try
                {
                    String resstr = "";

                    if (CurImg != null)
                    {
                        resstr = $"_{CurImg.Width}x{CurImg.Height}";
                    }
                    else if (ir == null && this.ImageResolutions.Count > 0)
                    {
                        ir = this.ImageResolutions[0];  //the first one should be the most recent image processed because of the sort.
                        resstr = $"_{ir.Width}x{ir.Height}";
                    }
                    else if (ir != null)
                    {
                        resstr = $"_{ir.Width}x{ir.Height}";
                    }

                    string CamMaskFile = "";
                    if (!string.IsNullOrEmpty(this.MaskFileName))
                    {
                        if (this.MaskFileName.Contains("\\") && this.MaskFileName.Contains("."))
                            CamMaskFile = this.MaskFileName;
                        else if (this.MaskFileName.Contains("."))
                            CamMaskFile = Path.Combine(Path.GetDirectoryName(AppSettings.Settings.SettingsFileName), $"{this.MaskFileName}");
                        else
                            CamMaskFile = Path.Combine(Path.GetDirectoryName(AppSettings.Settings.SettingsFileName), $"{this.MaskFileName}.bmp");

                        //Add WidthxHeight to filename
                        string ResFile = Path.Combine(Path.GetDirectoryName(CamMaskFile), $"{Path.GetFileNameWithoutExtension(CamMaskFile)}{resstr}.bmp");

                        bool resempty = string.IsNullOrEmpty(resstr);
                        bool cammaskexist = File.Exists(CamMaskFile);
                        bool resexist = File.Exists(ResFile);
                        if (!resempty && cammaskexist && !Path.GetFileName(CamMaskFile).Contains("_") && !resexist)
                        {
                            //lets rename it to appropriate ResFile name
                            string tmpresstr = "";
                            using (FileStream fileStream = new FileStream(CamMaskFile, FileMode.Open, FileAccess.Read))
                            {
                                using Image img = Image.FromStream(fileStream, false, false);
                                tmpresstr = $"_{img.Width}x{img.Height}";
                            }
                            if (tmpresstr == resstr)
                            {
                                AITOOL.Log($"Debug: Renaming mask file from '{CamMaskFile}' to '{ResFile}'...");
                                File.Move(CamMaskFile, ResFile);
                            }
                            else
                            {
                                AITOOL.Log($"Debug: Cannot rename mask file because it does not match the current image resolution of '{resstr}' (!={tmpresstr}):  MaskFile='{CamMaskFile}'...");
                            }
                        }
                        else
                        {
                            //AITOOL.Log($"Debug: ResEmpty={resempty}, CamMaskExist={cammaskexist}, ResMaskFileExist={resexist}, CurRes={resstr}, MaskRes={resstr}, CamMaskFile='{CamMaskFile}', ResMaskFile={ResFile}...");
                        }

                        if (MustExist)
                        {
                            if (File.Exists(ResFile))
                            {
                                return ResFile;
                            }
                            else
                            {
                                return "";
                            }
                        }
                        else
                        {
                            return ResFile;
                        }

                    }

                }
                catch (Exception ex)
                {

                    AITOOL.Log("Error: " + ex.Msg());
                }

            }

            return ret;

        }
        public bool UpdateImageResolutions(ClsImageQueueItem CurImg)
        {

            bool ret = false;

            if (!CurImg.IsValid())
                return ret;

            lock (CamLock)
            {
                ImageResItem newri = new ImageResItem(CurImg);

                int idx = this.ImageResolutions.IndexOf(newri);
                bool updated = false;

                if (idx > -1)
                {
                    if (CurImg.TimeCreated > this.ImageResolutions[idx].LastSeenDate)
                    {
                        updated = true;
                        this.ImageResolutions[idx].LastFileName = CurImg.image_path;
                        this.ImageResolutions[idx].LastSeenDate = CurImg.TimeCreated;
                        this.ImageResolutions[idx].LastFileSize = CurImg.FileSize;
                        this.ImageResolutions[idx].LastFileDPI = CurImg.DPI;
                        this.ImageResolutions[idx].Count++;
                    }
                }
                else
                {
                    ret = true;
                    this.ImageResolutions.Add(newri);
                }

                //sort so most recent is at top of list

                if (ret || updated)
                    this.ImageResolutions = this.ImageResolutions.OrderByDescending(x => x.LastSeenDate).ToList();

            }

            return ret;

        }
        public async Task ScanImagesAsync(int MaxFiles = 3000, int MaxTimeScanningMS = 60000, int MaxDaysOld = -4)
        {
            await Task.Run(() => ScanImages(MaxFiles, MaxTimeScanningMS, MaxDaysOld));
        }
        public void ScanImages(int MaxFiles = 3000, int MaxTimeScanningMS = 60000, int MaxDaysOld = -4)
        {
            using var Trace = new Trace();  //This c# 8.0 using feature will auto dispose when the function is done.

            List<FileInfo> files = new List<FileInfo>();

            Stopwatch fscansw = Stopwatch.StartNew();

            if (!string.IsNullOrEmpty(this.input_path) && Directory.Exists(this.input_path))
            {
                List<FileInfo> newfiles = Global.GetFiles(this.input_path, $"{this.Prefix}*.jpg", this.input_path_includesubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly, DateTime.Now.AddDays(MaxDaysOld), DateTime.Now, MaxFiles);
                files.AddRange(newfiles);
                AITOOL.Log($"Debug: Found {newfiles.Count} {this.Prefix}*.jpg files in {this.input_path}");
            }

            if (files.Count < MaxFiles && !string.IsNullOrEmpty(AppSettings.Settings.input_path) && AppSettings.Settings.input_path != this.input_path && Directory.Exists(AppSettings.Settings.input_path))
            {
                List<FileInfo> newfiles = Global.GetFiles(AppSettings.Settings.input_path, $"{this.Prefix}*.jpg", AppSettings.Settings.input_path_includesubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly, DateTime.Now.AddDays(MaxDaysOld), DateTime.Now, MaxFiles);
                files.AddRange(newfiles);
                AITOOL.Log($"Debug: Found {newfiles.Count} {this.Prefix}*.jpg files in {AppSettings.Settings.input_path}");
            }

            if (files.Count < MaxFiles && !string.IsNullOrEmpty(this.Action_network_folder) && Directory.Exists(this.Action_network_folder))
            {
                List<FileInfo> newfiles = Global.GetFiles(this.Action_network_folder, $"{this.Prefix}*.jpg", SearchOption.TopDirectoryOnly, DateTime.Now.AddDays(MaxDaysOld), DateTime.Now, MaxFiles);
                files.AddRange(newfiles);
                AITOOL.Log($"Debug: Found {newfiles.Count} {this.Prefix}*.jpg files in {this.Action_network_folder}");
            }

            if (!string.IsNullOrEmpty(this.last_image_file) && File.Exists(this.last_image_file))
            {
                if (!files.Any(x => string.Equals(x.FullName, this.last_image_file, StringComparison.OrdinalIgnoreCase)))
                {
                    files.Add(new FileInfo(this.last_image_file));
                }
            }

            files = files.OrderByDescending(t => t.CreationTime).ToList();

            fscansw.Stop();


            int cnt = 0;
            int updated = 0;
            int invalid = 0;

            AITOOL.Log($"Debug: Found {files.Count} images in {fscansw.ElapsedMilliseconds} ms. Scanning images...");

            Stopwatch sw = Stopwatch.StartNew();

            foreach (FileInfo fi in files)
            {

                try
                {
                    ClsImageQueueItem img = new ClsImageQueueItem(fi.FullName, 0, true);
                    if (img.IsValid())
                    {
                        if (this.UpdateImageResolutions(img))
                            updated++;

                        cnt++;
                    }
                    else
                    {
                        invalid++;
                    }
                }
                catch (Exception ex)
                {
                    invalid++;
                    AITOOL.Log($"Debug: {fi.Name}: {ex.Message}");
                }

                if (sw.ElapsedMilliseconds >= MaxTimeScanningMS)
                {
                    AITOOL.Log($"Debug: Max search time exceeded: {sw.ElapsedMilliseconds} ms >= {MaxTimeScanningMS} ms");
                    break;
                }

            }

            sw.Stop();

            string reseseses = "";
            foreach (ImageResItem res in this.ImageResolutions)
            {
                reseseses += $"{res.ToString()};";
            }

            if (string.IsNullOrEmpty(this.last_image_file) && files.Count > 0)
                this.last_image_file = files[0].FullName;

            AITOOL.Log($"Debug: {cnt} of {files.Count} image files processed, {updated} new resolutions found ({invalid} invalid) in {sw.ElapsedMilliseconds} ms (Max={MaxTimeScanningMS} ms), {this.ImageResolutions.Count} different image resolutions found: {reseseses}");

        }

        //public ResultType IsRelevantObject(ClsPrediction pred)
        //{
        //    if (Global.IsInList(pred.Label, this.triggering_objects_as_string, TrueIfEmpty: false) || Global.IsInList(pred.Label, this.additional_triggering_objects_as_string, TrueIfEmpty: false))
        //        return ResultType.Relevant;
        //    else
        //        return ResultType.UnwantedObject;

        //}
        public ResultType IsRelevantSize(ClsPrediction pred)
        {
            ResultType ret = ResultType.Relevant;

            if (pred.RectWidth == 0 || pred.RectHeight == 0 || pred.ImageHeight == 0 || pred.ImageWidth == 0)
                return ResultType.Unknown;

            //public int PredSizeMinPercentOfImage = 1;   //prediction must be at least this % of the image
            //public int PredSizeMaxPercentOfImage = 95;
            //public int PredSizeMinHeight = 0;
            //public int PredSizeMinWidth = 0;
            //public int PredSizeMaxHeight = 0;
            //public int PredSizeMaxWidth = 0;

            if (this.PredSizeMinPercentOfImage > 0 || this.PredSizeMaxPercentOfImage > 0)
            {
                if (pred.PercentOfImage < this.PredSizeMinPercentOfImage)
                    ret = ResultType.TooSmallPercent;
                else if (this.PredSizeMaxPercentOfImage > 0 && pred.PercentOfImage > this.PredSizeMaxPercentOfImage)
                    ret = ResultType.TooLargePercent;
            }

            if (ret == ResultType.Relevant)
            {
                if (pred.RectWidth < this.PredSizeMinWidth)
                    ret = ResultType.TooSmallWidth;
                else if (pred.RectHeight < this.PredSizeMinHeight)
                    ret = ResultType.TooSmallHeight;
                else if (this.PredSizeMaxWidth > 0 && pred.RectWidth > this.PredSizeMaxWidth)
                    ret = ResultType.TooLargeWidth;
                else if (this.PredSizeMaxHeight > 0 && pred.RectHeight > this.PredSizeMaxHeight)
                    ret = ResultType.TooLargeHeight;
            }

            return ret;
        }
        public Camera(string Name = "")
        {

            this.Name = Name;
            this.BICamName = Name;
            this.Prefix = Name;
        }

        public void ReadConfig(string config_path)
        {
            //retrieve whole config file content
            string[] content = System.IO.File.ReadAllLines(config_path);

            //import config data into variables, cut out relevant data between " "
            this.Name = Path.GetFileNameWithoutExtension(config_path);
            this.Prefix = content[2].Split('"')[1];

            //read triggering objects
            this.triggering_objects_as_string = content[1].Split('"')[1].Replace(" ", ""); //take the second line, split it between every ", take the part after the first ", remove every " " in this part
            this.triggering_objects = Global.Split(this.triggering_objects_as_string, ",").ToArray(); //split the row of triggering objects between every ','

            //input_path = AppSettings.Settings.input_path;

            //read trigger urls
            this.trigger_urls_as_string = content[0].Split('"')[1]; //takes the first line, cuts out everything between the first and the second " marker; all trigger urls in one string, ! still contains possible spaces etc.
            this.trigger_urls = this.trigger_urls_as_string.Replace(" ", "").Split(','); //all trigger urls in an array
            this.trigger_urls = this.trigger_urls.Except(new string[] { "" }).ToArray(); //remove empty entries

            //rewrite trigger_urls_as_string without possible empty entires
            int i = 0;
            this.trigger_urls_as_string = "";
            foreach (string c in this.trigger_urls)
            {
                this.trigger_urls_as_string += c;
                if (i < (this.trigger_urls.Length - 1))
                {
                    this.trigger_urls_as_string += " | ";
                }
                i++;
            }

            //read telegram enabled
            if (content[3].Split('"')[1].Replace(" ", "") == "yes")
            {
                this.telegram_enabled = true;
            }
            else
            {
                this.telegram_enabled = false;
            }

            //read enabled
            if (content[4].Split('"')[1].Replace(" ", "") == "yes")
            {
                this.enabled = true;
            }
            else
            {
                this.enabled = false;
            }
            double outvaldbl = 0;
            int outvalint = 0;
            Double.TryParse(content[5].Split('"')[1], out outvaldbl); //read cooldown time
            this.cooldown_time = outvaldbl;
            //read lower and upper threshold. Only load if line containing threshold values already exists (>version 1.58).
            if (content[6] != "")
            {
                Int32.TryParse(content[6].Split('"')[1].Split(',')[0], out outvalint); //read lower threshold
                this.threshold_lower = outvalint;
                Int32.TryParse(content[6].Split('"')[1].Split(',')[1], out outvalint); //read upper threshold
                this.threshold_upper = outvalint;
            }
            else //if config file from older version, set values to 0% and 100%
            {
                this.threshold_lower = 0;
                this.threshold_upper = 100;
            }


            //read stats

            Int32.TryParse(content[7].Split('"')[1].Split(',')[0], out outvalint); //bedeutet: Zeile 7 (6+1), aufgetrennt an ", 2tes (1+1) Resultat, aufgeteilt an ',', davon 1. Resultat  
            this.stats_alerts = outvalint;
            Int32.TryParse(content[7].Split('"')[1].Split(',')[1], out outvalint);
            this.stats_irrelevant_alerts = outvalint;
            Int32.TryParse(content[7].Split('"')[1].Split(',')[2], out outvalint);
            this.stats_false_alerts = outvalint;
        }


        //one correct alarm counter
        public void IncrementAlerts()
        {
            this.stats_alerts++;
            AppSettings.SaveAsync();
            //WriteConfig(name, prefix, triggering_objects_as_string, trigger_urls_as_string, telegram_enabled, enabled, cooldown_time, threshold_lower, threshold_upper);
        }

        //one alarm that contained no objects counter
        public void IncrementFalseAlerts()
        {
            this.stats_false_alerts++;
            AppSettings.SaveAsync();
            //WriteConfig(name, prefix, triggering_objects_as_string, trigger_urls_as_string, telegram_enabled, enabled, cooldown_time, threshold_lower, threshold_upper);
        }

        //one alarm that contained irrelevant objects counter
        public void IncrementIrrelevantAlerts()
        {
            this.stats_irrelevant_alerts++;
            AppSettings.SaveAsync();
            //WriteConfig(name, prefix, triggering_objects_as_string, trigger_urls_as_string, telegram_enabled, enabled, cooldown_time, threshold_lower, threshold_upper);
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Camera);
        }

        public bool Equals(Camera other)
        {
            return other != null &&
                   string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public static bool operator ==(Camera left, Camera right)
        {
            return EqualityComparer<Camera>.Default.Equals(left, right);
        }

        public static bool operator !=(Camera left, Camera right)
        {
            return !(left == right);
        }
    }
}
