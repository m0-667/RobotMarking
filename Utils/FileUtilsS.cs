using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMarking.Utils
{
    internal class FileUtilsS
    {
        const string Logpath = "./log.log";
        private static FileUtilsS Server = new FileUtilsS();
        public static FileUtilsS Instance()
        {
            return Server;
        }

        public void FilesList(FileSystemInfo info, string ext, List<string> filesContains)
        {
            if (!info.Exists) return;
            DirectoryInfo dir = info as DirectoryInfo;
            //不是目录
            if (dir == null) return;
            FileSystemInfo[] files = dir.GetFileSystemInfos();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = files[i] as FileInfo;
                //是文件
                if (file != null)
                {
                    if (string.IsNullOrEmpty(ext))
                    {
                        filesContains.Add(file.FullName);
                    }
                    else if (file.Extension.Equals(ext))
                    {
                        filesContains.Add(file.FullName);
                    }
                }
                //对于子目录，进行递归调用
                else
                {
                    FilesList(files[i], ext, filesContains);
                }
            }
        }
        public void SubDirList(string path, List<string> subDir)
        {
            DirectoryInfo di = new DirectoryInfo(path); //初始化制定路径
            DirectoryInfo[] dirs = di.GetDirectories(); //取得路径数组
            for (int i = 0; i < dirs.Length; i++)
            {
                subDir.Add(path + dirs[i].Name);
            }
        }

        /// <summary>
        /// 搜文件
        /// </summary>
        /// <param name="opt"></param>
        /// <param name="path"></param>
        public static void SearchFiles(string opt = "", string path = Logpath)
        {
            var dir = new DirectoryInfo(path);
            foreach (FileInfo item in dir.GetFiles(opt))
            {
                Console.WriteLine("{0,-12:N0} {1,-20:g} {2}", item.Length, item.CreationTime, item.FullName); //可视化的意义
            }
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="content"></param>
        /// <param name="path"></param>
        public void WriteFileInAppend(string content = "", string path = Logpath)
        {
            using (StreamWriter writer = File.AppendText(path)) //没有该文件可以创建并写入,有则直接追加,原来的内容保持
            {
                writer.WriteLine("");
                writer.WriteLine(content);
            }
        }
        public void WriteFileInNew(string content = "", string path = Logpath)
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.WriteLine(content);
            }
        }
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="content"></param>
        public void WriteFileForLog(string content)
        {
            using (StreamWriter writer = File.AppendText(Logpath)) //没有该文件可以创建并写入,有则直接追加,原来的内容保持
            {
                writer.WriteLine(DateUtils.CurrenDateTime() + ":" + content);
            }
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string OpenFile(string path = Logpath)
        {
            if (!File.Exists(path))
            {
                return "";
            }

            var content = "";
            using (StreamReader sr = new StreamReader(path))
            {
                var line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    content += line;
                }
            }

            return content;
        }



        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="info"></param>
        /// <param name="length"></param>
        public void CreateModelFile(string path, string name, byte[] info, int length)
        {
            FileInfo t = new FileInfo(path + "/" + name);

            Stream sw = !t.Exists ? t.Create() : t.OpenWrite();

            sw.Write(info, 0, length);
            sw.Close();
            sw.Dispose();
        }

        public void DeleteFile(string path)
        {
            try
            {
                FileAttributes attr = File.GetAttributes(path);
                if (attr == FileAttributes.Directory)
                {
                    Directory.Delete(path, true); //加上true,一样会有目录不是空的的异常
                }
                else
                {
                    File.Delete(path);
                }
            }
            catch (Exception)
            {
            }
        }
        public void DeleteDir(string path)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                di.Delete(true);
            }
            catch (Exception)
            {
            }
        }
        public void CreateDir(string path)
        {
            if (Directory.Exists(path))
            {
            }
            else
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
