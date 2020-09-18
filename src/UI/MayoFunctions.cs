using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Diagnostics;

using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Media;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet.Client.Publishing;
using Newtonsoft.Json;

using File = System.IO.File;

namespace AITool
{   public class MayoFunctions
    {
        //static ITelegramBotClient botClient;

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
                default: boxColor = Color.Green; break;
            }

            return boxColor;
        }
        // ************************************************************************

        public bool IsRunningCheck()
        {
            Process aProcess = Process.GetCurrentProcess();
            string aProcName = aProcess.ProcessName;

            if (Process.GetProcessesByName(aProcName).Length > 1) { return true; } else { return false; }
        }

        // ************************************************************************
        public void DrectoryCheck()
        {
            if (!Directory.Exists("./detections/"))
            {
                Directory.CreateDirectory("./detections");                
            }  
        }

        // ************************************************************************
        public void PurgeFiles(string directory, string extension, int days)
        {
            foreach (string file in Directory.GetFiles(directory,"*", SearchOption.AllDirectories))
            {                
                FileInfo fi = new FileInfo(file);

                if (fi.Extension == extension && fi.LastWriteTime < DateTime.Now.AddDays(0 - days))
                {
                    fi.Delete();                    
                }                           
            }
        }

        // ************************************************************************
        public async Task TelegramUploadLegacy(string image_path, string image_caption)
        {
            if (AppSettings.Settings.telegram_chatids.Count > 0 && AppSettings.Settings.telegram_token != "" && File.Exists(image_path))
            {
                //telegram upload sometimes fails
                Stopwatch sw = Stopwatch.StartNew();
                try
                {
                    using (var image_telegram = System.IO.File.OpenRead(image_path))
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
                    }
                }
                catch
                {

                }

            }
        }

        // ************************************************************************
        public bool TelegramOutsideMask(string cameraname, double xmin, double xmax, double ymin, double ymax, int width, int height)
        {
            string strMaskFile = $"cameras\\{cameraname}_{width}x{height}_telegram.png";

            try
            {
                if (System.IO.File.Exists(strMaskFile)) //only check if mask image exists
                {
                    //load mask file (in the image all places that have color (transparency > 9 [0-255 scale]) are masked)
                    using (var mask_img = new Bitmap(strMaskFile))
                    {
                        //if any coordinates of the object are outside of the mask image, th mask image must be too small.
                        if (mask_img.Width != width || mask_img.Height != height)
                        {
                            Log($"ERROR: The resolution of the mask '{strMaskFile}' does not equal the resolution of the processed image. Skipping privacy mask feature. Image: {width}x{height}, Mask: {mask_img.Width}x{mask_img.Height}");
                            return true;
                        }

                        Log("         Checking if the object is in a masked area...");

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
                            if (pixelColor.A < 10)
                            {
                                result++;
                            }
                        }

                        Log($"         { result.ToString() } of 9 detection points are outside of masked areas."); //print how many of the 9 detection points are outside of masked areas.

                        if (result > 4) //if 5 or more of the 9 detection points are outside of masked areas, the majority of the object is outside of masked area(s)
                        {
                            Log("      ->The object is OUTSIDE of masked area(s).");
                            return true;
                        }
                        else //if 4 or less of 9 detection points are outside, then 5 or more points are in masked areas and the majority of the object is so too
                        {
                            Log("      ->The object is INSIDE a masked area.");
                            return false;
                        }

                    }
                }
                else //if mask image does not exist, object is outside the non-existing masked area
                {
                    Log("     ->Camera has no mask, the object is OUTSIDE of the masked area.");
                    return true;
                }

            }
            catch
            {
                Log($"ERROR while loading the mask file ./cameras/{cameraname}.png.");
                return true;
            }

        }

        public void Log(string message)
        {

        }

        // ************************************************************************
        /*
         * public void StartTelegramListener(string access_token)
        {
            botClient = new TelegramBotClient(access_token);

            var me = botClient.GetMeAsync().Result;
            botClient.OnMessage += TelegramBot_OnMessage;
            botClient.StartReceiving();

            //botClient.StopReceiving();
        }
        // ************************************************************************
        public static async void TelegramBot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {              

                //if (e.Message.Text == "quit") {  }
                await botClient.SendTextMessageAsync( chatId: e.Message.Chat, text: "You said:\n" + e.Message.Text  );
            }
        }

        */

    }

}
