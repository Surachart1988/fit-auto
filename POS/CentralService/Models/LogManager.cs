﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CentralService.Models
{
    public class LogManager
    {
        private static bool isWriteLog = true;
        private static string logPath = null;

        public static bool IsWriteLog
        {
            get { return isWriteLog; }
            set { isWriteLog = value; }
        }

        public static string LogPath
        {
            get { return logPath; }
            set { logPath = value; }
        }

        public static string GetTrackId()
        {
            try
            {
                return String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static void WriteLog(string text)
        //{
        //    try
        //    {
        //        if (isWriteLog)
        //        {
        //            text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ") + text + Environment.NewLine;
        //            System.IO.File.AppendAllText(logPath + "Log-" + DateTime.Now.ToString("yyyyMMdd") + ".txt", text);
        //        }
        //    }
        //    catch
        //    {

        //    }

        //}
        public static void VerifyDir(string path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (!dir.Exists)
                {
                    dir.Create();
                }
            }
            catch { }
        }

        public static void WriteLog(string strLog)
        {
            string path = "C:/Log/";
            VerifyDir(path);
            string fileName = "FIT_POS_"+DateTime.Now.ToString("ddMMyyyy_hhmmmss") + ".txt";
            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(path + fileName, true);
                file.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + ": " + strLog);
                file.Close();
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public static void WriteException(Exception ex)
        {
            try
            {
                WriteLog(ex.Message);
                WriteLog(ex.StackTrace);
            }
            catch
            {

            }

        }
    }
}
