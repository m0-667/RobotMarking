using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMarking.Service
{
    internal class AppS
    {
        public string CurrentDir = "";
        public string ResourceDir = "";
        public string DataDir = "";
        public Action<string> TipA;

        public static AppS Instance = new AppS();
        private AppS()
        {
            Init();
        }

        private void Init()
        {
            CurrentDir = Environment.CurrentDirectory;
            ResourceDir = $"{CurrentDir}/Resources";
            DataDir = $"{ResourceDir}/Data";
        }

    }
}
