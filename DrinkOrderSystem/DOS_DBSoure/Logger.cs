using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_DBSoure
{
    public class Logger
    {
        internal static void WriteLog(Exception ex)
        {
            //為了查出錯的時候的錯誤訊息，錯誤訊息會寫進Log.log的檔案裡
            string msg =
                $@"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
                   {ex.ToString()}
                    ";

            string logPath = "D:\\Logs\\Log.log";
            string folderPath = System.IO.Path.GetDirectoryName(logPath);

            if (!System.IO.Directory.Exists(folderPath))
                System.IO.Directory.CreateDirectory(folderPath);

            if (!System.IO.File.Exists(logPath))
                System.IO.File.Create(logPath);

            System.IO.File.AppendAllText(logPath, msg);

            throw ex;
        }
    }
}
