using RobotMarking.Sdk;
using RobotMarking.Service;
using System.Text;
using System.Windows.Controls;

namespace RobotMarking.Pages
{
    /// <summary>
    /// ObjListPage.xaml 的交互逻辑
    /// </summary>
    public partial class ObjListPage : Page
    {
        public ObjListPage()
        {
            InitializeComponent();
        }

        public void ReLoadObjList()
        {
            cmbObjList.Items.Clear();
            //cmbObjList.Items.Add("NONE");
            //cmbObjList.Items.Add("ALL");
            byte[,] szObjList = new byte[100, 50];
            byte[] objname = new byte[50];
            int n = 0;

            int nRet = CSharpInterface.HS_GetObjList(0, szObjList, ref n);
            if (nRet == 0)
            {
                for (int i = 0; i < n; ++i)
                {
                    for (int t = 0; t < 50; t++) objname[t] = szObjList[i, t];
                    string str = Encoding.Default.GetString(objname);
                    cmbObjList.Items.Add(str);
                    //MessageBox.Show(str);
                    //MessageBox.Show(cmbObjList.Items[i].ToString());
                    
                    MyLogS.Instance.LogContent(str);
                    MyLogS.Instance.LogContent("中文");
                }
                CSharpInterface.HS_SelectObjects(0, null, false);
                this.cmbObjList.SelectedValue = 0;//选择第一项
            }
            else
            {

            }
        }
    }
}
