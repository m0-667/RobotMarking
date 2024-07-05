using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HansAdvInterfaceCSharpTest;
using RobotMarking.MarkTools;
using RobotMarking.Model;
using RobotMarking.Pages;
using RobotMarking.Sdk;
using RobotMarking.Service;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MessageBox = System.Windows.MessageBox;

namespace RobotMarking
{
    /// <summary>
    /// MarkWin.xaml 的交互逻辑
    /// </summary>
    public partial class MarkingPage : System.Windows.Controls.Page
    {
        Form form;
        object elementId = null;
        uint g_uCard = 0;
        bool m_bMarking = false;
        CInterStroke[] m_listCustom = new CInterStroke[100];
        double m_dbViewRate = 1.0;
        double m_dbViewX = 0;
        double m_dbViewY = 0;
        bool bDrawing = false;
        bool m_bWaitTouch = false;
        bool m_bWaitEnd = false;
        int m_nWaitTimeForTouch = 0;
        string m_strHansFileName = "default.bs";//当前模板名字

        public MarkingPage()
        {
            InitializeComponent();
            AddToolsGroupBtn();
            UiS.Instance.SetToolsGroupBtn(SelectBtn);
            AttachFrame();
            NewFileAsync();
            //Task.Delay(500);
            InitialSystem();
            CheckRedLight();
        }

       

        private void AddToolsGroupBtn()
        {
            UiS.Instance.AddToolsGroupBtn(this.SelectBtn);
            UiS.Instance.AddToolsGroupBtn(this.TextBtn);
            UiS.Instance.AddToolsGroupBtn(this.CodeBtn);
            UiS.Instance.AddToolsGroupBtn(this.LineBtn);
            UiS.Instance.AddToolsGroupBtn(this.RectBtn);
            UiS.Instance.AddToolsGroupBtn(this.CircleBtn);
        }

        private void AttachFrame()
        {
            AttachObjList();
            AttachObjProperty();
        }

        private void AttachObjList()
        {
            var page = UiS.Instance.GetPage(typeof(MarkingParasPage).Name);
            if (page == null)
            {
                page = new MarkingParasPage();
                UiS.Instance.AddPage(typeof(MarkingParasPage).Name, page);
            }
            page.Height = this.MarkingParas.Height;
            page.Width = this.MarkingParas.Width;
            this.MarkingParas.Content = page;

        }

        private void AttachObjProperty()
        {
            var page = UiS.Instance.GetPage(typeof(ObjPropertyPage).Name);
            if (page == null)
            {
                page = new ObjPropertyPage();
                UiS.Instance.AddPage(typeof(ObjPropertyPage).Name, page);
            }
            page.Height = this.ObjectProperty.Height;
            page.Width = this.ObjectProperty.Width;
            this.ObjectProperty.Content = page;
        }

        private async void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Preview();
        }


        private void AttachFormToPanel(int idx = 0)
        {
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            MyImageTab panel = new MyImageTab
            {
            };
            panel.Paint += OnPaint;
            host.Child = panel;
            ((this.MyTabControl.Items[idx] as TabItem).Content as Grid).Children.Add(host);
            MarkingPreviewFileModel markingPreviewFileModel = UiS.Instance.GetMarkingPreviewFileModel(idx);
            markingPreviewFileModel.Host = host;
            markingPreviewFileModel.Panel = panel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as System.Windows.Controls.Button).Name)
            {
                case "InitialSystemBtn":
                    InitialSystem();
                    break;
                case "CloseSystemBtn":
                    CloseSystem();
                    break;
                case "OpenTemplateFileBtn":
                    OpenTemplateFile();
                    break;
                case "NewFileBtn":
                    NewFileAsync();
                    break;
                case "SaveFileBtn":
                    SaveFile();
                    break;
                case "MarkBtn":
                    StartMark();
                    break;
                case "RedBtn":
                    ISetRedLight();
                    break;
                default:
                    break;
            }
        }
        int counter = 0;
        private async Task NewFileAsync()
        {
            counter++;
            TabItem tabItem = new TabItem();
            tabItem.Header = "New" + counter;
            Grid grid = new Grid();
            grid.Margin = new Thickness(5, 5, 5, 5);
            //System.Windows.Controls.TextBox textBox = new System.Windows.Controls.TextBox();
            //textBox.Text = "git" + counter;
            //textBox.Width = grid.Width;
            //textBox.Height = grid.Height;
            //grid.Children.Add(textBox);
            tabItem.Content = grid;
            this.MyTabControl.Items.Add(tabItem);
            this.MyTabControl.SelectedIndex = this.MyTabControl.Items.Count - 1;
            UiS.Instance.SetTabItemHeader(tabItem.Header.ToString(), this.MyTabControl);
            AttachFormToPanel(this.MyTabControl.SelectedIndex);
            OpenDefautTemplateFile(tabItem.Header.ToString());
        }

        private void SaveFile()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".bs";
            dlg.Filter = "BS documents (.bs)|*.bs";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string szfilename = dlg.FileName;
                int nRet = CSharpInterface.HS_SaveMarkFile(0, szfilename);
                if (nRet == 0)
                {
                    UiS.Instance.SetTabItemHeader(szfilename, this.MyTabControl);
                    System.Windows.MessageBox.Show("SaveMarkFile success!");
                }
                else
                {
                    ShowLastError();
                }

            }
        }

        private void ISetRedLight()
        {
            bool bOpen = false;
            if (CSharpInterface.HS_GetRedLight(g_uCard, ref bOpen) == 0)
            {
                if (CSharpInterface.HS_ISetRedLight(g_uCard, !bOpen) == 0)
                {
                    CheckRedLight();
                    return;
                }
            }

            ShowLastError();
        }

        private void CheckRedLight()
        {
            bool bOpen = false;
            if (CSharpInterface.HS_GetRedLight(g_uCard, ref bOpen) == 0)
            {
                if (bOpen)
                {
                    this.RedBtn.Content = "Close Red";
                }
                else
                {
                    this.RedBtn.Content = "Open Red";
                }
            }
            else
            {
                ShowLastError();
            }
        }
        private async void OpenDefautTemplateFile(string fn = "default.bs")
        {
            m_strHansFileName = fn;
            TabItem tabItem = this.MyTabControl.SelectedItem as TabItem;
            tabItem.Header = m_strHansFileName;
            SwitchDoc(m_strHansFileName);
        }
        private void OpenTemplateFile()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "HS File(*.BS)|*.BS";
            openFileDialog.Title = "Improt Hans file";
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                if (CSharpInterface.HS_LoadMarkFile(g_uCard, openFileDialog.FileName) == 0)
                {
                    AppS.Instance.TipA("打开模板文件 " + openFileDialog.SafeFileName + " 成功!");
                    m_strHansFileName = openFileDialog.SafeFileName;
                    TabItem tabItem = this.MyTabControl.SelectedItem as TabItem;
                    tabItem.Header = m_strHansFileName;
                    SwitchDoc(m_strHansFileName);
                }
                else
                {
                    System.Windows.MessageBox.Show(ShowLastError());
                }
            }
        }
        public void SelectSize()
        {
            double dbLeft = 0.0;
            double dbTop = 0.0;
            double dbRight = 0.0;
            double dbBottom = 0.0;
            if (CSharpInterface.HS_GetObjProperty(g_uCard, ref dbLeft, ref dbTop, ref dbRight, ref dbBottom) == 0)
            {
                AppS.Instance.TipA("对象属性:宽[" + (dbLeft - dbRight).ToString("f2") + "mm,高:" + (dbTop - dbBottom).ToString("f2") + "mm,中心(" + ((dbRight - dbLeft) * 0.5).ToString("f2") + (dbTop - dbBottom) * 0.5 + ")]");
                //tsslabObjSize.Text = "对象属性:宽[" + (dbLeft - dbRight).ToString("f2") + "mm,高:" + (dbTop - dbBottom).ToString("f2") + "mm,中心(" + ((dbRight - dbLeft) * 0.5).ToString("f2") + (dbTop - dbBottom) * 0.5 + ")]";
            }
            else
            {
                ShowLastError();
            }
        }
        private void StartMark()
        {
            // this.Cursor = System.Windows.Forms.Cursors.WaitCursor;//鼠标为忙碌状态
            int nRet = CSharpInterface.HS_Mark(g_uCard, 0, m_bWaitTouch, m_bWaitEnd, m_nWaitTimeForTouch, true);
            if (0 == nRet)
            {
                m_bMarking = true;
                AppS.Instance.TipA("打标成功！");
            }
            else
            {
                ShowLastError();
            }
            //this.Cursor = System.Windows.Forms.Cursors.Arrow;//设置鼠标为正常状态
        }

        private void CloseSystem()
        {
            CSharpInterface.HS_FreeStrokeList(g_uCard, m_listCustom);
            int nRet = CSharpInterface.HS_CloseMachine();
            if (0 == nRet)
            {
                AppS.Instance.TipA("释放成功");
                // tbNote.Text = "释放成功!";
                // tsslabCardStatus.Text = "卡状态:未初始化!!!";

                // m_bInitOk = false;

                // tsslabMarkRange.Text = "打标范围:";
                // Refresh();
            }
            else
            {
                ShowLastError();
                // tsslabCardStatus.Text = "卡状态:初始化成功!!!";
            }
            // UpdateView();
        }

        private void InitialSystem()
        {
            this.Cursor = System.Windows.Input.Cursors.Wait;
            int nRet = CSharpInterface.HS_InitialMachine(AppS.Instance.CurrentDir);
            if (nRet == 0)
            {
                this.Tip.Text = "打标系统初始化成功！";
                CSharpInterface.g_strPathName = AppS.Instance.CurrentDir;
                // m_bInitOk = true;

                double px = 0, py = 0;
                CSharpInterface.HS_GetMarkRange(g_uCard, ref px, ref py);
                // tsslabMarkRange.Text = "打标范围:" + px.ToString() + "*" + py.ToString() + "mm";
                //设置预览滑标
                // tbrX.SetRange(-(int)(px / 2), (int)(px / 2));
                // tbrY.SetRange(-(int)(py / 2), (int)(py / 2));
                // tbrS.SetRange(0, 100);
                // ResetPreview();设置滑标位置

                //add 2022/3/8
                // myImageTab1.TabPages.Add("default");
                //OpenDefautTemplateFile();

                //by xcf 2022/05/05
                uint uCard = 0;
                CSharpInterface.HS_GetCardNumber(ref uCard);
                // comboBox_Card.Items.Clear();
                // for (int i = 0; i < uCard; i++)
                // {
                //     string str = "Card:" + (i + 1).ToString();
                //     comboBox_Card.Items.Add(str);
                // }
                // if (uCard > 0)
                // {
                //     comboBox_Card.SelectedIndex = 0;
                //     g_uCard = 0;
                // }

            }
            else
            {
                //OpenDefautTemplateFile();
                this.Tip.Text = "状态：初始化失败！";
            }
            UpdateView();
            //this.Cursor = System.Windows.Forms.Cursors.Arrow;//设置鼠标为正常状态
            this.Cursor = System.Windows.Input.Cursors.Arrow;

        }
        //如果初始化未完成，则将其他按钮设置为不可用，反之则设置为可用
        public void UpdateView()
        {
            //btnModule.Enabled = btnRelease.Enabled = btnModulesClose.Enabled = m_bInitOk;
            //groupBox2.Enabled = groupBox3.Enabled = groupBox4.Enabled = groupBox5.Enabled = groupBox6.Enabled = m_bInitOk;
            //myImageTab1.Enabled = m_bInitOk;
            //groupBox7.Enabled = m_bInitOk;
            //comboBox_Card.Enabled = m_bInitOk;
            //btn_MarkAll.Enabled = m_bInitOk;

            //if (myImageTab1 != null)
            //    myImageTab1.Enabled = m_bInitOk;
        }
        void SwitchDoc(string strFile)  //注意：C++版本的Demo多了HS_GetObjList和HS_SelectObjects；两个函数
        {
            if (string.IsNullOrEmpty(strFile))
            {
                return;
            }
            int nRet = CSharpInterface.HS_SetCurDoc(g_uCard, strFile);
            if (nRet == 0)
            {
                ResetPreview();
                Preview();
            }
            else
            {
                ShowLastError();
            }
        }
        void ResetPreview()
        {
            // this.tbrX.Value = 0;
            // this.m_dbViewX = 0.0;
            // this.tbrY.Value = 0;
            // this.m_dbViewY = 0.0;
            // this.tbrS.Value = 30;
            // this.m_dbViewRate = 1.0;
            Preview();
        }
        void Preview()
        {
            UpdateLayout();
            int idx = this.MyTabControl.SelectedIndex;
            MarkingPreviewFileModel markingPreviewFileModel = UiS.Instance.GetMarkingPreviewFileModel(idx);
            markingPreviewFileModel.Host.UpdateLayout();
            markingPreviewFileModel.Panel.Update();
            if (bDrawing)
                return;
            bDrawing = true;
            if (markingPreviewFileModel.Panel == null)
                return;
            IntPtr ptr = markingPreviewFileModel.Panel.Handle;
            if (ptr != null)
            {
                int nRet = CSharpInterface.HS_PreviewGraph(g_uCard, ptr, m_dbViewX, m_dbViewY, m_dbViewRate);
                if (nRet != 0)
                {
                    ShowLastError();
                }
            }
            bDrawing = false;
        }
        string ShowLastError()
        {
            int nErr = 0;
            StringBuilder szBuff = new StringBuilder(200);
            CSharpInterface.HS_GetLastError(g_uCard, ref nErr, szBuff, 200);
            this.Tip.Text = szBuff.ToString();
            return szBuff.ToString();
        }

        private void TextBtnClick(object sender, RoutedEventArgs e)
        {

        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem tabItem = this.MyTabControl.SelectedItem as TabItem;
            SwitchDoc(tabItem.Header.ToString());
        }



        private void ToolsClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = (System.Windows.Controls.Button)sender;
            UiS.Instance.SetToolsGroupBtn(btn);
            switch (btn.Name)
            {
                case "SelectBtn":
                    UiS.Instance.SetToolsGroupBtn(btn);

                    break;
                case "TextBtn":
                    UiS.Instance.SetToolsGroupBtn(btn);
                    AddText();
                    break;
                case "CodeBtn":
                    UiS.Instance.SetToolsGroupBtn(btn);
                    AddCode();
                    break;
                case "LineBtn":
                    UiS.Instance.SetToolsGroupBtn(btn);
                    AddLine();
                    break;
                case "RectBtn":
                    UiS.Instance.SetToolsGroupBtn(btn);

                    AddRect();
                    break;
                case "CorcleBtn":
                    UiS.Instance.SetToolsGroupBtn(btn);

                    AddCircle();
                    break;
            }
        }

        private void SelectToolsGroupBtn(System.Windows.Controls.Button btn)
        {
            UiS.Instance.SetToolsGroupBtn(SelectBtn);

        }
        private async void AddText()
        {
            TextTools.Instance.AddText();
            Preview();
        }
        private async void AddCode()
        {
            Preview();
        }
        private async void AddLine()
        {
            Preview();
        }
        private async void AddRect()
        {
            Preview();
        }
        private async void AddCircle()
        {
            Preview();
        }

        private void Preview_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Preview();
        }
        public void OnPaint(object sender, PaintEventArgs e)
        {
            Preview();
        }
    }
}
