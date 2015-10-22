using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GenericHelper
{
    public class FileLogger
    {
        private static string directory_path = string.Empty;
        public static bool Initialize()
        {
            try
            {
                var location = System.Reflection.Assembly.GetEntryAssembly().Location;
                directory_path = Path.GetDirectoryName(location);
                if (!Directory.Exists(directory_path + @"\" + DateTime.Now.Year.ToString() + @"\" + DateTime.Now.Month.ToString() + @"\" + DateTime.Now.Day.ToString() + @"\" + DateTime.Now.Hour.ToString()))
                    Directory.CreateDirectory(directory_path + @"\" + DateTime.Now.Year.ToString() + @"\" + DateTime.Now.Month.ToString() + @"\" + DateTime.Now.Day.ToString() + @"\" + DateTime.Now.Hour.ToString());
                directory_path = directory_path + @"\" + DateTime.Now.Year.ToString() + @"\" + DateTime.Now.Month.ToString() + @"\" + DateTime.Now.Day.ToString() + @"\" + DateTime.Now.Hour.ToString() + @"\ServiceActivities.log";
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static bool LogIt(StringBuilder sbLine)
        {
            try
            {
                using (System.IO.StreamWriter swWriter = new System.IO.StreamWriter(directory_path, true))
                {
                    swWriter.Write(DateTime.Now.ToLongTimeString());
                    swWriter.Write("/t");
                    swWriter.WriteLine(sbLine.ToString());
                    swWriter.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool LogIt(StringBuilder sbLine, bool onCondition)
        {
            if (onCondition)
            {
                try
                {
                    
                    using (System.IO.StreamWriter swWriter = new System.IO.StreamWriter(directory_path, true))
                    {
                        swWriter.Write(DateTime.Now.ToLongTimeString());
                        swWriter.Write("/t");
                        swWriter.WriteLine(sbLine.ToString());
                        swWriter.Close();
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return true;
        }
        public static bool RemoveUnwanted()
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
