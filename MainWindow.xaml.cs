using Microsoft.Win32;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using RobotMarking.Sdk;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using RobotMarking.Service;

namespace RobotMarking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        public MainWindow()
        {
            InitializeComponent();
            UiS.Instance.ChangeRightFrame = ChangeRightFrame;
            AppS.Instance.TipA = TipA;
            this.RightGroup.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            AddLeftGroupBtn();
            InitFrame();
        }

        private void AddLeftGroupBtn()
        {
            UiS.Instance.AddLeftGroupBtn(this.MainBtn);
            UiS.Instance.AddLeftGroupBtn(this.RobotBtn);
            UiS.Instance.AddLeftGroupBtn(this.LaserBtn);
            UiS.Instance.AddLeftGroupBtn(this.DeviceBtn);
            UiS.Instance.AddLeftGroupBtn(this.AlarmBtn);
            UiS.Instance.AddLeftGroupBtn(this.ContactBtn);
        }

        public void TipA(string msg)
        {
            this.Tip.Content = msg;
        }
        private void InitFrame()
        {
            var page = UiS.Instance.GetPage(typeof(MarkingPage).Name);
            if (page == null)
            {
                page = new MarkingPage();
                UiS.Instance.AddPage(typeof(MarkingPage).Name, page);
            }
            page.Height = this.RightGroup.Height;
            page.Width = this.RightGroup.Width;
            this.RightGroup.Content = page;
            UiS.Instance.SetLeftGroupBtn(this.LaserBtn);
        }

        private void LaserBtn_Click(object sender, RoutedEventArgs e)
        {
            var page = UiS.Instance.GetPage(typeof(MarkingPage).Name);
            if (page == null)
            {
                page = new MarkingPage();
                UiS.Instance.AddPage(typeof(MarkingPage).Name, page);
            }
            page.Height = this.RightGroup.Height;
            page.Width = this.RightGroup.Width;
            this.RightGroup.Content = page;
            UiS.Instance.SetLeftGroupBtn(this.LaserBtn);
        }
        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            var page = UiS.Instance.GetPage(typeof(MainPage).Name);
            if (page == null)
            {
                page = new MainPage();
                UiS.Instance.AddPage(typeof(MainPage).Name, page);
            }
            page.Height = this.RightGroup.Height;
            page.Width = this.RightGroup.Width;
            this.RightGroup.Content = page;
            UiS.Instance.SetLeftGroupBtn(this.MainBtn);
        }
        private void RobotBtn_Click(object sender, RoutedEventArgs e)
        {
            var page = UiS.Instance.GetPage(typeof(RobotPage).Name);
            if (page == null)
            {
                page = new RobotPage();
                UiS.Instance.AddPage(typeof(RobotPage).Name, page);
            }
            page.Height = this.RightGroup.Height;
            page.Width = this.RightGroup.Width;
            this.RightGroup.Content = page;
            UiS.Instance.SetLeftGroupBtn(this.RobotBtn);
        }

        private void DeviceBtn_Click(object sender, RoutedEventArgs e)
        {
            UiS.Instance.SetLeftGroupBtn(this.DeviceBtn);
        }

        private void AlarmBtn_Click(object sender, RoutedEventArgs e)
        {
            var page = UiS.Instance.GetPage(typeof(AlarmPage).Name);
            if (page == null)
            {
                page = new AlarmPage();
                UiS.Instance.AddPage(typeof(AlarmPage).Name, page);
            }
            page.Height = this.RightGroup.Height;
            page.Width = this.RightGroup.Width;
            this.RightGroup.Content = page;
            UiS.Instance.SetLeftGroupBtn(this.AlarmBtn);
        }
        private void ContactBtn_Click(object sender, RoutedEventArgs e)
        {
            UiS.Instance.SetLeftGroupBtn(this.ContactBtn);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //UiDataS.Instance.MainForm.saveDataBtn_Click(sender, e);
        }
        private void Input_Click(object sender, RoutedEventArgs e)
        {
            //UiDataS.Instance.MainForm.loadDataBtn_Click(sender, e);
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void RobotIp_Click(object sender, System.EventArgs e)
        {
            //RobotIpForm robotIpForm = new RobotIpForm();
            //robotIpForm.Show();
        }
        private void AboutUs_Click(object sender, System.EventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show($"机器人打标机,版本号:{Config.Version}");
        }
        public void ChangeRightFrame()
        {
            OnSizeChanged(null, null);
            //UpdateLayout();   
            //var tmp = RightGroup.Width;
            //RightGroup.Width -= 500;
            //RightGroup.Width = tmp;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
        private void Window_StateChanged(object sender, EventArgs e)
        {
            //if (WindowState != WindowState.Normal)
            //{
            //    WindowState = WindowState.Normal;
            //}
        }


    }
}