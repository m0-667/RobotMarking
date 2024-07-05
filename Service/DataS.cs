using RobotMarking.Controller;
using RobotMarking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMarking.Service
{
    class DataS
    {
        public LayerParaCon LayerParaCon = new LayerParaCon();

        public static DataS Instance = new DataS();

        private DataS()
        {
        }
    }
}
