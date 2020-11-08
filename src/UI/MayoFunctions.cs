using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

using System.Linq;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;
using System.Threading.Tasks;

//using SixLabors.ImageSharp;

using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

using File = System.IO.File;


namespace AITool
{   public class MayoFunctions
    {
        static ITelegramBotClient botClient;

        public async Task<string> MergeImageAnnotations(ClsTriggerActionQueueItem AQI)
        {
            int countr = 0;
            string detections = "";
            string lasttext = "";
            string lastposition = "";
            string OutputImageFile = "";
            string CurSrv = "";
            bool bSendTelegramMessage = false;

            try
            {
                Global.LogMessage("Merging image annotations: " + AQI.CurImg.image_path);

                if (System.IO.File.Exists(AQI.CurImg.image_path))
                {
                    Stopwatch sw = Stopwatch.StartNew();                    

                    using (Bitmap img = new Bitmap(AQI.CurImg.image_path))
                    {
                        using (Graphics g = Graphics.FromImage(img))
                        {
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode = SmoothingMode.HighQuality;
                            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            //http://csharphelper.com/blog/2014/09/understand-font-aliasing-issues-in-c/
                            g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;


                            System.Drawing.Color color = new System.Drawing.Color();

                            if (AQI.Hist != null && !string.IsNullOrEmpty(AQI.Hist.PredictionsJSON))
                            {
                                System.Drawing.Rectangle rect;
                                System.Drawing.SizeF size;
                                Brush rectBrush;
                                Color boxColor;                                

                                List<ClsPrediction> predictions = new List<ClsPrediction>();

                                predictions = Global.SetJSONString<List<ClsPrediction>>(AQI.Hist.PredictionsJSON);

                                foreach (var pred in predictions)
                                {
                                    bool Merge = false;

                                    if (AppSettings.Settings.HistoryOnlyDisplayRelevantObjects && pred.Result == ResultType.Relevant)
                                        Merge = true;
                                    else if (!AppSettings.Settings.HistoryOnlyDisplayRelevantObjects)
                                        Merge = true;

                                    if (Merge)
                                    {
                                        lasttext = pred.ToString();
                                        //lasttext = $"{cam.last_detections[i]} {String.Format(AppSettings.Settings.DisplayPercentageFormat, AQI.cam.last_confidences[i] * 100)}";  

                                        int xmin = pred.XMin + AQI.cam.XOffset;
                                        int ymin = pred.YMin + AQI.cam.YOffset;
                                        int xmax = pred.XMax;
                                        int ymax = pred.YMax;

                                        if (AQI.cam.telegram_mask_enabled && !bSendTelegramMessage)
                                        {
                                            bSendTelegramMessage ^= this.TelegramOutsideMask(AQI.cam.name, xmin, xmax, ymin, ymax, img.Width, img.Height);
                                        }

                                        int penSize = 2;
                                        if (img.Height > 1200) { penSize = 4; }
                                        else if (img.Height >= 800 && img.Height <= 1200) { penSize = 3; }

                                        boxColor = Color.FromArgb(150, this.GetBoxColor(AQI.cam.last_detections[countr]));
                                        rect = new System.Drawing.Rectangle(xmin, ymin, xmax - xmin, ymax - ymin);
                                        using (Pen pen = new Pen(boxColor, penSize)) { g.DrawRectangle(pen, rect); } //draw rectangle

                                        // Text Color       
                                        Brush textColor = (boxColor.GetBrightness() > 0.5 ? Brushes.Black : Brushes.White);

                                        float fontSize = AppSettings.Settings.RectDetectionTextSize * ((float)img.Height / 1080); // Scale for image sizes
                                        if (fontSize < 8) { fontSize = 8; }
                                        Font textFont = new Font(AppSettings.Settings.RectDetectionTextFont, fontSize);

                                        //object name text below rectangle
                                        rect = new System.Drawing.Rectangle(xmin - 1, ymax, (int)img.Width, (int)img.Height); //sets bounding box for drawn text
                                        rectBrush = new SolidBrush(boxColor); //sets background rectangle color

                                        size = g.MeasureString(lasttext, textFont); //finds size of text to draw the background rectangle
                                        g.FillRectangle(rectBrush, xmin - 1, ymax, size.Width, size.Height); //draw background rectangle for detection text
                                        g.DrawString(lasttext, textFont, textColor, rect); //draw detection text

                                        g.Flush();
                                        countr++;
                                    }
                                }
                            }
                            else
                            {
                                //Use the old way -this code really doesnt need to be here but leaving just to make sure
                                detections = AQI.cam.last_detections_summary;
                                if (string.IsNullOrEmpty(detections))
                                    detections = "";

                                string label = Global.GetWordBetween(detections, "", ":");

                                if (label.Contains("irrelevant") || label.Contains("confidence") || label.Contains("masked") || label.Contains("errors"))
                                {
                                    detections = detections.Split(':')[1]; //removes the "1x masked, 3x irrelevant:" before the actual detection, otherwise this would be displayed in the detection tags

                                    if (label.Contains("masked"))
                                    {
                                        color = System.Drawing.Color.FromArgb(AppSettings.Settings.RectMaskedColorAlpha, AppSettings.Settings.RectMaskedColor);
                                    }
                                    else
                                    {
                                        color = System.Drawing.Color.FromArgb(AppSettings.Settings.RectIrrelevantColorAlpha, AppSettings.Settings.RectIrrelevantColor);
                                    }
                                }
                                else
                                {
                                    color = System.Drawing.Color.FromArgb(AppSettings.Settings.RectRelevantColorAlpha, AppSettings.Settings.RectRelevantColor);
                                }

                                //List<string> detectlist = Global.Split(detections, "|;");
                                countr = AQI.cam.last_detections.Count();

                                //display a rectangle around each relevant object


                                for (int i = 0; i < countr; i++)
                                {
                                    //({ Math.Round((user.confidence * 100), 2).ToString() }%)
                                    lasttext = $"{AQI.cam.last_detections[i]} {String.Format(AppSettings.Settings.DisplayPercentageFormat, AQI.cam.last_confidences[i])}";
                                    lastposition = AQI.cam.last_positions[i];  //load 'xmin,ymin,xmax,ymax' from third column into a string

                                    //store xmin, ymin, xmax, ymax in separate variables
                                    Int32.TryParse(lastposition.Split(',')[0], out int xmin);
                                    Int32.TryParse(lastposition.Split(',')[1], out int ymin);
                                    Int32.TryParse(lastposition.Split(',')[2], out int xmax);
                                    Int32.TryParse(lastposition.Split(',')[3], out int ymax);

                                    xmin = xmin + AQI.cam.XOffset;
                                    ymin = ymin + AQI.cam.YOffset;

                                    System.Drawing.Rectangle rect = new System.Drawing.Rectangle(xmin, ymin, xmax - xmin, ymax - ymin);


                                    using (Pen pen = new Pen(color, AppSettings.Settings.RectBorderWidth))
                                    {
                                        g.DrawRectangle(pen, rect); //draw rectangle
                                    }

                                    //we need this since people can change the border width in the json file
                                    int halfbrd = AppSettings.Settings.RectBorderWidth / 2;

                                    //object name text below rectangle
                                    rect = new System.Drawing.Rectangle(xmin - halfbrd, ymax + halfbrd, img.Width, img.Height); //sets bounding box for drawn text


                                    Brush brush = new SolidBrush(color); //sets background rectangle color

                                    System.Drawing.SizeF size = g.MeasureString(lasttext, new Font(AppSettings.Settings.RectDetectionTextFont, AppSettings.Settings.RectDetectionTextSize)); //finds size of text to draw the background rectangle
                                    g.FillRectangle(brush, xmin - halfbrd, ymax + halfbrd, size.Width, size.Height); //draw grey background rectangle for detection text
                                    g.DrawString(lasttext, new Font(AppSettings.Settings.RectDetectionTextFont, AppSettings.Settings.RectDetectionTextSize), Brushes.Black, rect); //draw detection text

                                    g.Flush();

                                    //Global.LogMessage($"...{i}, LastText='{lasttext}' - LastPosition='{lastposition}'");
                                }

                            }


                            if (countr > 0)
                            {

                                GraphicsState gs = g.Save();

                                ImageCodecInfo jpgEncoder = this.GetImageEncoder(ImageFormat.Jpeg);

                                // Create an Encoder object based on the GUID  
                                // for the Quality parameter category.  
                                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

                                // Create an EncoderParameters object.  
                                // An EncoderParameters object has an array of EncoderParameter  
                                // objects. In this case, there is only one  
                                // EncoderParameter object in the array.  
                                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, AQI.cam.Action_image_merge_jpegquality);  //100=least compression, largest file size, best quality
                                myEncoderParameters.Param[0] = myEncoderParameter;

                                Global.WaitFileAccessResult result = new Global.WaitFileAccessResult();
                                result.Success = true; //assume true

                                if (AQI.cam.Action_image_merge_detections_makecopy)
                                    OutputImageFile = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), Path.GetFileName(AQI.CurImg.image_path));
                                else
                                    OutputImageFile = AQI.CurImg.image_path;

                                if (System.IO.File.Exists(OutputImageFile))
                                {
                                    result = await Global.WaitForFileAccessAsync(OutputImageFile, FileSystemRights.FullControl, FileShare.ReadWrite);
                                }

                                if (result.Success)
                                {
                                    img.Save(OutputImageFile, jpgEncoder, myEncoderParameters);
                                    if (AQI.cam.telegram_mask_enabled && bSendTelegramMessage)
                                    {
                                        string telegram_file = "temp\\" + Path.GetFileName(OutputImageFile).Insert((Path.GetFileName(OutputImageFile).Length - 4), "_telegram");
                                        img.Save(telegram_file, jpgEncoder, myEncoderParameters);
                                    }
                                    Log($"Debug: Merged {countr} detections in {sw.ElapsedMilliseconds}ms into image {OutputImageFile}");
                                }
                                else
                                {
                                    Log($"Error: Could not gain access to write merged file {OutputImageFile}");
                                }

                            }
                            else
                            {
                                Log($"Debug: No detections to merge.  Time={sw.ElapsedMilliseconds}ms, {OutputImageFile}");

                            }
                        }
                    }
                }
                else
                {
                    Global.LogMessage("Error: could not find last image with detections: " + AQI.CurImg.image_path);
                }
            }
            catch (Exception ex)
            {
                Global.LogMessage($"Error: Detections='{detections}', LastText='{lasttext}', LastPostions='{lastposition}' - " + Global.ExMsg(ex));
            }

            return OutputImageFile;
        }


        public async void MergeImageAnnotationsOld(Camera cam, ClsTriggerActionQueueItem AQI)
        {
            int countr = 0;
            string detections = "";
            string lasttext = "";
            string lastposition = "";
            string OutputImageFile = "";

            try
            {
                Global.LogMessage("Merging image annotations: " + AQI.CurImg.image_path);

                if (File.Exists(AQI.CurImg.image_path))
                {
                    Stopwatch sw = Stopwatch.StartNew();

                    using (Bitmap img = new Bitmap(AQI.CurImg.image_path))
                    {
                        /*
                        using (Graphics gfxImage = Graphics.FromImage(img))
                        {
                            System.Drawing.Rectangle rect;
                            System.Drawing.SizeF size;
                            Brush rectBrush;
                            Color boxColor;
                            bool bSendTelegramMessage = false;

                            gfxImage.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            gfxImage.SmoothingMode = SmoothingMode.HighQuality;
                            gfxImage.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            gfxImage.CompositingQuality = CompositingQuality.HighQuality;
                            //gfxImage.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;

                            System.Drawing.Color color = new System.Drawing.Color();
                            detections = cam.last_detections_summary;
                            if (string.IsNullOrEmpty(detections))
                                detections = "";                         

                            //List<string> detectlist = Global.Split(detections, "|;");
                            countr = cam.last_detections.Count();

                            //display a rectangle around each relevant object
                            for (int i = 0; i < countr; i++)
                            {
                                //({ Math.Round((user.confidence * 100), 2).ToString() }%)
                                lasttext = $"{cam.last_detections[i]} {String.Format(AppSettings.Settings.DisplayPercentageFormat, cam.last_confidences[i] * 100)}";
                                lastposition = cam.last_positions[i];  //load 'xmin,ymin,xmax,ymax' from third column into a string

                                //store xmin, ymin, xmax, ymax in separate variables
                                int xmin = pred.xmin + AQI.cam.XOffset;
                                int ymin = pred.ymin + AQI.cam.YOffset;
                                int xmax = pred.xmax;
                                int ymax = pred.ymax;                   

                                if (cam.telegram_mask_enabled && !bSendTelegramMessage) {
                                    bSendTelegramMessage ^= this.TelegramOutsideMask(cam.name, xmin, xmax, ymin, ymax, img.Width, img.Height);                                    
                                }

                                int penSize = 2;
                                if (img.Height > 1200) { penSize = 4; }
                                else if (img.Height >= 800 && img.Height <= 1200) { penSize = 3; }
                             
                                boxColor = Color.FromArgb(150, this.GetBoxColor(cam.last_detections[i]));                                
                                rect = new System.Drawing.Rectangle(xmin, ymin, xmax - xmin, ymax - ymin);
                                using (Pen pen = new Pen(boxColor, penSize)) { gfxImage.DrawRectangle(pen, rect); } //draw rectangle

                                // Text Color       
                                Brush textColor = (boxColor.GetBrightness() > 0.5 ? Brushes.Black : Brushes.White);

                                float fontSize = AppSettings.Settings.RectDetectionTextSize * ((float)img.Height / 1080); // Scale for image sizes
                                if (fontSize < 8) { fontSize = 8; }
                                Font textFont = new Font(AppSettings.Settings.RectDetectionTextFont, fontSize);

                                //object name text below rectangle
                                rect = new System.Drawing.Rectangle(xmin - 1, ymax, (int)img.Width, (int)img.Height); //sets bounding box for drawn text
                                rectBrush = new SolidBrush(boxColor); //sets background rectangle color

                                size = gfxImage.MeasureString(lasttext, textFont); //finds size of text to draw the background rectangle
                                gfxImage.FillRectangle(rectBrush, xmin - 1, ymax, size.Width, size.Height); //draw background rectangle for detection text
                                gfxImage.DrawString(lasttext, textFont, textColor, rect); //draw detection text

                                gfxImage.Flush();
                            }

                            if (countr > 0)
                            {
                                GraphicsState gs = gfxImage.Save();
                                ImageCodecInfo jpgEncoder = GetImageEncoder(ImageFormat.Jpeg);
                                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, cam.Action_image_merge_jpegquality);  //100=least compression, largest file size, best quality
                                myEncoderParameters.Param[0] = myEncoderParameter;

                                bool Success = true;

                                if (File.Exists(OutputImageFile))
                                {
                                    Success = await Global.WaitForFileAccessAsync(OutputImageFile, FileSystemRights.FullControl, FileShare.ReadWrite);
                                }

                                if (Success)
                                {
                                    img.Save(OutputImageFile, jpgEncoder, myEncoderParameters);
                                    if (cam.telegram_mask_enabled && bSendTelegramMessage)
                                    {
                                        string telegram_file = "temp\\" + Path.GetFileName(OutputImageFile).Insert((Path.GetFileName(OutputImageFile).Length - 4), "_telegram"); 
                                        img.Save(telegram_file, jpgEncoder, myEncoderParameters);
                                    }                                    

                                    Global.LogMessage($"Merged {countr} detections in {sw.ElapsedMilliseconds}ms into image {OutputImageFile}");
                                }
                                else
                                {
                                    Global.LogMessage($"Error: Could not gain access to write merged file {OutputImageFile}");
                                }
                            }
                            else
                            {
                                Global.LogMessage($"No detections to merge.  Time={sw.ElapsedMilliseconds}ms, {OutputImageFile}");
                            }
                        }
                        */
                    }
                }
                else
                {
                    Global.LogMessage("Error: could not find last image with detections: " + cam.last_image_file_with_detections);
                }
            }
            catch (Exception ex)
            {
                Global.LogMessage($"Error: Detections='{detections}', LastText='{lasttext}', LastPostions='{lastposition}' - " + Global.ExMsg(ex));
            }
        }

        // ************************************************************************
        private ImageCodecInfo GetImageEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        
        // ************************************************************************
        public Color GetBoxColor(string objectType)
        {
            Color boxColor;

            switch (objectType.ToLower())
            {
                case "person":
                    boxColor = Color.Red;
                    break;
                case "car":
                case "truck":
                case "boat":
                case "bicycle":
                case "motorcycle":
                    boxColor = Color.Gold;
                    break;
                case "horse":
                case "dog":
                case "sheep":
                case "bird":
                case "cow":
                case "cat":                
                case "bear":
                    boxColor = Color.LightBlue;
                    break;
                case "irrelevant":
                case "masked":
                    boxColor = Color.LightGray;
                    break;
                default: boxColor = Color.Green; break;
            }

            return boxColor;
        }

        // ************************************************************************
        public static string GetDetectionIcon(string objectType)
        {
            string emojiCode;

            switch (objectType.ToLower())
            {
                case "person": emojiCode = "\U0001F468"; break;
                case "car": emojiCode = "\U0001F697"; break;
                case "truck": emojiCode = "\U0001F69A"; break;
                case "boat": emojiCode = "\U0001F6E5"; break;
                case "bicycle": emojiCode = "\U0001F6B2"; break;
                case "bus": emojiCode = "\U0001F68C"; break;
                case "motorcycle": emojiCode = "\U0001F3CD"; break;
                case "horse": emojiCode = "\U0001F434"; break;
                case "dog": emojiCode = "\U0001F436"; break;
                //case "sheep": emojiCode = "\U000"; break;
                case "bird": emojiCode = "\U0001F426"; break;
                case "cow": emojiCode = "\U0001F42E"; break;
                case "cat": emojiCode = "\U0001F63A"; break;
                case "bear": emojiCode = "\U0001F43B"; break;                
                default: emojiCode = objectType; break;
            }
            
            return emojiCode;
        }

        // ************************************************************************
        public void DrectoryCheck()
        {   
            if (!Directory.Exists("./cameras/masks/"))
            {
                Directory.CreateDirectory("./cameras/masks");
            }

            if (!Directory.Exists("./detections/"))
            {
                Directory.CreateDirectory("./detections");                
            }

            if (!Directory.Exists("./temp/"))
            {
                Directory.CreateDirectory("./temp");
            }
        }

        // ************************************************************************
        public void PurgeFiles(string directory, string extension, int days)
        {
            foreach (string file in Directory.GetFiles(directory,"*", SearchOption.AllDirectories))
            {                
                FileInfo fileInfo = new FileInfo(file);

                if (fileInfo.Extension == extension && fileInfo.LastWriteTime < DateTime.Now.AddDays(0 - days))
                {
                    fileInfo.Delete();                    
                }                           
            }
        }

        // ************************************************************************
        public async Task<bool> SendImageToTelegram(ClsTriggerActionQueueItem AQI)
        {
            bool bReturn = false;

            string telegram_file = "temp\\" + Path.GetFileName(AQI.CurImg.image_path).Insert((Path.GetFileName(AQI.CurImg.image_path).Length - 4), "_telegram");            

            if (AppSettings.Settings.telegram_chatids.Count > 0 && AppSettings.Settings.telegram_token != "" && File.Exists(telegram_file))
            {
                //string image_caption = AITOOL.ReplaceParams(cam, CurImg, cam.telegram_caption);
                string image_caption = AITOOL.ReplaceParams(AQI.cam, AQI.Hist, AQI.CurImg, AQI.cam.telegram_caption);
                //telegram upload sometimes fails               
                try
                {
                    using (var image_telegram = System.IO.File.OpenRead(telegram_file))
                    {
                        var bot = new TelegramBotClient(AppSettings.Settings.telegram_token);

                        //upload image to Telegram servers and send to first chat
                        Log($"      uploading image to chat \"{AppSettings.Settings.telegram_chatids[0]}\"");
                        var message = await bot.SendPhotoAsync(AppSettings.Settings.telegram_chatids[0], new InputOnlineFile(image_telegram, "image.jpg"), image_caption); // Mayo Change
                        string file_id = message.Photo[0].FileId; //get file_id of uploaded image

                        //share uploaded image with all remaining telegram chats (if multiple chat_ids given) using file_id 
                        foreach (string chatid in AppSettings.Settings.telegram_chatids.Skip(1))
                        {
                            Log($"      uploading image to chat \"{chatid}\"");
                            await bot.SendPhotoAsync(chatid, file_id, image_caption);
                        }

                        bReturn = true;
                    }

                    if (File.Exists(telegram_file)) { File.Delete(telegram_file); }
                }
                catch(Exception ex)
                {
                    Log($"ERROR: Could not upload image {telegram_file} to Telegram: {Global.ExMsg(ex)}");
                }

            }

            return bReturn;
        }

        // ************************************************************************
        public bool TelegramOutsideMask(string cameraname, double xmin, double xmax, double ymin, double ymax, int width, int height)
        {
            string strMaskFile = $"cameras\\masks\\{cameraname}_{width}x{height}_telegram";            

            try
            {
                if (File.Exists(strMaskFile + ".bmp")){
                    strMaskFile = strMaskFile + ".bmp";
                }else if (File.Exists(strMaskFile + ".png")){
                    strMaskFile = strMaskFile + ".png";
                }else{
                    Log($"     ->Camera has no telegram mask '{strMaskFile}', the object is OUTSIDE of the masked area.");
                    return true;
                }

                if (File.Exists(strMaskFile)) //only check if mask image exists
                {
                    //load mask file (in the image all places that have color (transparency > 9 [0-255 scale]) are masked)
                    using (var mask_img = new Bitmap(strMaskFile))
                    {
                        //if any coordinates of the object are outside of the mask image, th mask image must be too small.
                        if (mask_img.Width != width || mask_img.Height != height)
                        {
                            Log($"ERROR: The resolution of the telegram mask '{strMaskFile}' does not equal the resolution of the processed image. Skipping privacy mask feature. Image: {width}x{height}, Mask: {mask_img.Width}x{mask_img.Height}");
                            return true;
                        }

                        Log("         Checking if the object is in a telegram masked area...");

                        //relative x and y locations of the 9 detection points
                        double[] x_factor = new double[] { 0.25, 0.5, 0.75, 0.25, 0.5, 0.75, 0.25, 0.5, 0.75 };
                        double[] y_factor = new double[] { 0.25, 0.25, 0.25, 0.5, 0.5, 0.5, 0.75, 0.75, 0.75 };

                        int result = 0; //counts how many of the 9 points are outside of masked area(s)

                        //check the transparency of the mask image in all 9 detection points
                        for (int i = 0; i < 9; i++)
                        {
                            //get image point coordinates (and converting double to int)
                            int x = (int)(xmin + (xmax - xmin) * x_factor[i]);
                            int y = (int)(ymin + (ymax - ymin) * y_factor[i]);

                            // Get the color of the pixel
                            System.Drawing.Color pixelColor = mask_img.GetPixel(x, y);

                            //if the pixel is transparent (A refers to the alpha channel), the point is outside of masked area(s)
                            if ( strMaskFile.EndsWith(".png") )
                            {
                                //if the pixel is transparent (A refers to the alpha channel), the point is outside of masked area(s)
                                if (pixelColor.A < 10)
                                {
                                    result++;
                                }
                            }
                            else
                            {
                                if (pixelColor.A == 0)  // object is in a transparent section of the image (not masked)
                                {
                                    result++;
                                }
                            }
                        }

                        Log($"         { result.ToString() } of 9 detection points are outside of telegram masked areas."); //print how many of the 9 detection points are outside of masked areas.

                        if (result > 4) //if 5 or more of the 9 detection points are outside of masked areas, the majority of the object is outside of masked area(s)
                        {
                            Log("      ->The object is OUTSIDE of telegram masked area(s).");
                            return true;
                        }
                        else //if 4 or less of 9 detection points are outside, then 5 or more points are in masked areas and the majority of the object is so too
                        {
                            Log("      ->The object is INSIDE a telegram masked area.");
                            return false;
                        }

                    }
                }
                else //if mask image does not exist, object is outside the non-existing masked area
                {
                    Log("     ->Camera has no telegram mask or camera image size differs from mask.");
                    return true;
                }
            }
            catch
            {
                Log($"ERROR while loading the telegram mask file {strMaskFile}.");
                return true;
            }

        }
        // ************************************************************************
        public void Log(string strMessage)
        {
            Global.LogMessage(strMessage);
        }

        // ************************************************************************
        public void StartTelegramListener(string access_token)
        {
            botClient = new TelegramBotClient(access_token);
            botClient.OnMessage += TelegramBot_OnMessage;
            botClient.StartReceiving();
            //botClient.StopReceiving();
        }
        // ************************************************************************
        public static async void TelegramBot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                string strReply = "";
                string strCommand = e.Message.Text.Split(' ')[0].Trim();

                switch (strCommand)
                {
                    case "/info": strReply = "Info Command"; break;
                    case "/version":
                        string AssemVer = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                        strReply = $"Version {AssemVer} built on {Global.RetrieveLinkerTimestamp()}";
                        break;
                    default: strReply = "Invalid Command" ; break;
                }
                
                await botClient.SendTextMessageAsync( chatId: e.Message.Chat, text: strReply);
            }
        }

        // ************************************************************************
        // Legacy Functions
        // ************************************************************************
        public void SaveDetectedImage(Bitmap detectedImage, string fileprefix, string filesuffix, string image_path)
        {
            try
            {
                if (detectedImage != null)
                {
                    string saveFile = "detections\\" + fileprefix.ToLower() + "\\" + Path.GetFileName(image_path);

                    if (!Directory.Exists("./detections/" + fileprefix.ToLower())) { Directory.CreateDirectory("./detections/" + fileprefix.ToLower()); }
                    detectedImage.Save(saveFile.Insert((saveFile.Length - 4), filesuffix));

                    /*
                    using (EncoderParameters encoderParameters = new EncoderParameters(1))
                    using (EncoderParameter encoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 95L))
                    {
                        ImageCodecInfo codecInfo = ImageCodecInfo.GetImageDecoders().First(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
                        encoderParameters.Param[0] = encoderParameter;                        
                        detectedImage.Save(saveFile, codecInfo, encoderParameters);
                    }    
                    */

                    //Bitmap resized = new Bitmap(detectedImage, new Size(detectedImage.Width / 4, detectedImage.Height / 4));
                    //resized.Save(saveFile.Insert( (saveFile.Length - 4), "_thumb") );
                }
            }
            catch (Exception ex)
            {

            }
        }

        // ************************************************************************       
        public void DrawObjectBoxes(ref Bitmap img, string objectType, int _xmin, int _ymin, int _xmax, int _ymax, string text)
        {
            using (Graphics gfxImage = Graphics.FromImage(img))
            {
                System.Drawing.Rectangle rect;
                System.Drawing.SizeF size;
                Brush rectBrush;

                //get dimensions of the image and the picturebox
                float imgWidth = img.Width;
                float imgHeight = img.Height;
                float boxWidth = img.Width; // pictureBox1.Width;
                float boxHeight = img.Height;  //pictureBox1.Height;

                //these variables store the padding between image border and picturebox border
                int absX = 0;
                int absY = 0;
        
                //because the sizemode of the picturebox is set to 'zoom', the image is scaled down
                float scale = 1;

                //Comparing the aspect ratio of both the control and the image itself.
                if (imgWidth / imgHeight > boxWidth / boxHeight) //if the image is p.e. 16:9 and the picturebox is 4:3
                {
                    scale = boxWidth / imgWidth; //get scale factor
                    absY = (int)(boxHeight - scale * imgHeight) / 2; //padding on top and below the image
                }
                else //if the image is p.e. 4:3 and the picturebox is widescreen 16:9
                {
                    scale = boxHeight / imgHeight; //get scale factor
                    absX = (int)(boxWidth - scale * imgWidth) / 2; //padding left and right of the image
                }

                //2. inputted position values are for the original image size. As the image is probably smaller in the picturebox, the positions must be adapted. 
                int xmin = (int)(scale * _xmin) + absX;
                int xmax = (int)(scale * _xmax) + absX;
                int ymin = (int)(scale * _ymin) + absY;
                int ymax = (int)(scale * _ymax) + absY;

                int penSize = 2;
                if (img.Height > 1200) { penSize = 4; }
                else if(img.Height >=800 && img.Height <= 1200) { penSize = 3; }      


                //3. paint rectangle                
                Color boxColor = Color.FromArgb(150, this.GetBoxColor(objectType) );               
                rect = new System.Drawing.Rectangle(xmin, ymin, xmax - xmin, ymax - ymin);
                using (Pen pen = new Pen(boxColor, penSize)) { gfxImage.DrawRectangle(pen, rect); } //draw rectangle

                // Text Color       
                Brush textColor = (boxColor.GetBrightness() > 0.5 ? Brushes.Black : Brushes.White);

                float fontSize = 12 * ((float)img.Height / 1080); // Scale for image sizes
                if (fontSize < 8) { fontSize = 8; }
                Font textFont = new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Regular);

                //object name text below rectangle
                rect = new System.Drawing.Rectangle(xmin - 1, ymax, (int)boxWidth, (int)boxHeight); //sets bounding box for drawn text
                rectBrush = new SolidBrush(boxColor); //sets background rectangle color

                gfxImage.SmoothingMode = SmoothingMode.HighQuality;
                gfxImage.CompositingQuality = CompositingQuality.HighQuality;

                size = gfxImage.MeasureString(text, textFont); //finds size of text to draw the background rectangle
                gfxImage.FillRectangle(rectBrush, xmin - 1, ymax, size.Width, size.Height); //draw background rectangle for detection text
                gfxImage.DrawString(text, textFont, textColor, rect); //draw detection text
            }
        }

        // ************************************************************************
        public bool IsRunningCheck()
        {
            Process aProcess = Process.GetCurrentProcess();
            string aProcName = aProcess.ProcessName;

            if (Process.GetProcessesByName(aProcName).Length > 1) { return true; } else { return false; }
        }


    }

}
