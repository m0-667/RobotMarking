using RobotMarking.Service;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RobotMarking.Pages
{
    /// <summary>
    /// MarkingParas.xaml 的交互逻辑
    /// </summary>
    public partial class MarkingParasPage : Page
    {
        public MarkingParasPage()
        {
            InitializeComponent();
            LoadCurrentData();
            SetMode(UiS.Instance.LayerParaPageMode);
        }

        private void SetMode(int mode)
        {
            UiS.Instance.LayerParaPageMode = mode;
            switch (mode)
            {
                case 1:
                    this.Normal.Visibility = Visibility.Visible;
                    this.Advance.Visibility = Visibility.Collapsed;
                    this.NormalBtn.Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#ccf783"));
                    this.AdvanceBtn.Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#ffffff"));
                    break;
                case 2:
                    this.Normal.Visibility = Visibility.Collapsed;
                    this.Advance.Visibility = Visibility.Visible;
                    this.NormalBtn.Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#ffffff"));
                    this.AdvanceBtn.Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#ccf783"));
                    break;

            }
        }

        private void LoadCurrentData()
        {
            DataS.Instance.LayerParaCon.LoadCurrentData();
            FillData();
        }

        private void FillData()
        {
            this.nCount.Text = DataS.Instance.LayerParaCon.LayerParaModel.nCount.ToString("#0");
            this.dbMarkV.Text = DataS.Instance.LayerParaCon.LayerParaModel.dbMarkV.ToString("#0.000");
            this.dbJumpV.Text = DataS.Instance.LayerParaCon.LayerParaModel.dbJumpV.ToString("#0.000");
            this.dbQFre.Text = DataS.Instance.LayerParaCon.LayerParaModel.dbQFre.ToString("#0.000");
            this.nLayerDelay.Text = DataS.Instance.LayerParaCon.LayerParaModel.nLayerDelay.ToString("#0");
            this.nLaserOnDelay.Text = DataS.Instance.LayerParaCon.LayerParaModel.nLaserOnDelay.ToString("#0");
            this.nLaserOffDelay.Text = DataS.Instance.LayerParaCon.LayerParaModel.nLaserOffDelay.ToString("#0");
            this.nMoveLineDelay.Text = DataS.Instance.LayerParaCon.LayerParaModel.nMoveLineDelay.ToString("#0");
            this.nJumpDelay.Text = DataS.Instance.LayerParaCon.LayerParaModel.nJumpDelay.ToString("#0");
            this.nRoundDelay.Text = DataS.Instance.LayerParaCon.LayerParaModel.nRoundDelay.ToString("#0");
            this.nWaveForm.Text = DataS.Instance.LayerParaCon.LayerParaModel.nWaveForm.ToString("#0");
            this.dbPower.Text = DataS.Instance.LayerParaCon.LayerParaModel.dbPower.ToString("#0.000");
            this.nLaserPulse.Text = DataS.Instance.LayerParaCon.LayerParaModel.nLaserPulse.ToString("#0");
        }

        private void Normal_Click(object sender, RoutedEventArgs e)
        {
            SetMode(1);
        }
        private void Advance_Click(object sender, RoutedEventArgs e)
        {
            SetMode(2);
        }



        private void Default_Click(object sender, RoutedEventArgs e)
        {
            DataS.Instance.LayerParaCon.LoadDefaultData();
            FillData();
            System.Windows.MessageBox.Show("已导入默认参数!");
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            DataS.Instance.LayerParaCon.LayerParaModel.nCount = int.Parse(this.nCount.Text);
            DataS.Instance.LayerParaCon.LayerParaModel.dbMarkV = double.Parse(this.dbMarkV.Text);
            DataS.Instance.LayerParaCon.LayerParaModel.dbJumpV = double.Parse(this.dbJumpV.Text);
            DataS.Instance.LayerParaCon.LayerParaModel.dbQFre = double.Parse(this.dbQFre.Text);
            DataS.Instance.LayerParaCon.LayerParaModel.nLayerDelay = int.Parse(this.nLayerDelay.Text);
            DataS.Instance.LayerParaCon.LayerParaModel.nLaserOnDelay = int.Parse(this.nLaserOnDelay.Text);
            DataS.Instance.LayerParaCon.LayerParaModel.nLaserOffDelay = int.Parse(this.nLaserOffDelay.Text);
            DataS.Instance.LayerParaCon.LayerParaModel.nMoveLineDelay = int.Parse(this.nMoveLineDelay.Text);
            DataS.Instance.LayerParaCon.LayerParaModel.nJumpDelay = int.Parse(this.nJumpDelay.Text);
            DataS.Instance.LayerParaCon.LayerParaModel.nRoundDelay = int.Parse(this.nRoundDelay.Text);
            DataS.Instance.LayerParaCon.LayerParaModel.nWaveForm = int.Parse(this.nWaveForm.Text);
            DataS.Instance.LayerParaCon.LayerParaModel.dbPower = double.Parse(this.dbPower.Text);
            DataS.Instance.LayerParaCon.LayerParaModel.nLaserPulse = int.Parse(this.nLaserPulse.Text);
            DataS.Instance.LayerParaCon.SaveCurrentData();
            System.Windows.MessageBox.Show("当前参数已保存完成!");

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("这个功能需要确定,删除什么!");
        }
    }
}
