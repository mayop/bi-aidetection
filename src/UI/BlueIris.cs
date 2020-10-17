﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using static AITool.AITOOL;

namespace AITool
{
    public class BlueIris
    {
        public List<String> ClipPaths = new List<String>();
        public List<String> Cameras = new List<String>();
        public string AppPath = "";
        public string URL = "";
        public bool IsValid = false;
        
        public BlueIris()
        {
            //initialize
            RefreshInfo();
        }

        public void RefreshInfo()
        {
            using var Trace = new Trace();  //This c# 8.0 using feature will auto dispose when the function is left.

            try
            {
                Log("Reading BlueIris settings from registry...");

                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Perspective Software\\Blue Iris\\clips\\folders"))
                {
                    if (key != null)
                    {
                        foreach (var sk in key.GetSubKeyNames())
                        {

                            using (RegistryKey curkey = key.OpenSubKey(sk))
                            {
                                if (curkey != null)
                                {
                                    string path = Convert.ToString(curkey.GetValue("path"));
                                    if (!string.IsNullOrWhiteSpace(path))
                                    {
                                        this.ClipPaths.Add(path.Trim());
                                    }
                                }

                            }
                        }
                    }

                }

                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Perspective Software\\Blue Iris\\Cameras"))
                {
                    if (key != null)
                    {
                        foreach (var sk in key.GetSubKeyNames())
                        {

                            using (RegistryKey curkey = key.OpenSubKey(sk))
                            {
                                if (curkey != null)
                                {
                                    bool enabled = (Convert.ToInt32(curkey.GetValue("enabled")) == 1);
                                    if (enabled)
                                    {
                                        string shortname = Convert.ToString(curkey.GetValue("shortname"));
                                        if (!string.IsNullOrWhiteSpace(shortname))
                                        {
                                            this.Cameras.Add(shortname);
                                        }
                                    }
                                }

                            }
                        }
                    }

                }

                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Perspective Software\\Blue Iris\\Install"))
                {
                    if (key != null)
                    {
                        string ap = Convert.ToString(key.GetValue("AppPath4"));
                        if (!string.IsNullOrWhiteSpace(ap))
                        {
                            this.AppPath = ap;
                        }
                    }

                }

                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Perspective Software\\Blue Iris\\server"))
                {
                    if (key != null)
                    {
                        bool httpslan = (Convert.ToInt32(key.GetValue("httpslan")) == 1);
                        string lanip = Convert.ToString(key.GetValue("lanip"));
                        string port = Convert.ToString(key.GetValue("port"));
                        if (!string.IsNullOrWhiteSpace(lanip))
                        {
                            if (httpslan)  //maybe need to check secureonly setting also??
                            {
                                this.URL = "https://" + lanip.Trim() + ":" + port.Trim();
                            }
                            else
                            {
                                this.URL = "http://" + lanip.Trim() + ":" + port.Trim();
                            }
                        }
                    }

                }


                this.IsValid = (this.ClipPaths.Count > 0 && this.ClipPaths.Count > 0 && !String.IsNullOrWhiteSpace(this.AppPath));

            }
            catch (Exception ex)
            {
                Log("Error: Got error while reading BlueIris registry: " + Global.ExMsg(ex));
                this.IsValid = false;
            }
}
    }
}
