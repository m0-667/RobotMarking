using RobotMarking.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMarking.Service
{
    internal class MyLogS
    {
        private string path = "mylogmylog.txt";
        public static MyLogS Instance = new MyLogS();

        private MyLogS()
        {
        }

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="content"></param>
        public void LogContent(string content)
        {
            FileUtilsS.Instance().WriteFileInAppend(
                DateUtils.CurrenDateTime() + ":" + content, Path.Combine("D:/", path));
        }
    }
}
