using RobotMarking.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Button = System.Windows.Controls.Button;
using Color = System.Windows.Media.Color;

namespace RobotMarking.Service
{
    internal class UiS
    {
        public Action ChangeRightFrame;
        public Dictionary<string, Page> pages = new Dictionary<string, Page>();
        public List<Button> LeftBtnGroup = new List<Button>();
        public List<Button> ToolsBtnGroup = new List<Button>();
        public List<MarkingPreviewFileModel> PreviewTabItems = new List<MarkingPreviewFileModel>();
        public int LayerParaPageMode = 1;
        public static UiS Instance = new UiS();
        private UiS() { }


        public Page GetPage(string name)
        {
            if (pages.ContainsKey(name))
            {
                return pages[name];
            }
            return null;
        }

        internal void AddPage(string v, Page page)
        {
            if (!pages.ContainsKey(v))
            {
                pages.Add(v, page);
            }
        }

        internal void AddLeftGroupBtn(Button btn)
        {
            foreach (Button button in LeftBtnGroup)
            {
                if (btn.Name == button.Name)
                {
                    return;
                }
            }
            this.LeftBtnGroup.Add(btn);
        }
        internal void SetLeftGroupBtn(Button btn)
        {
            foreach (Button button in LeftBtnGroup)
            {
                if (btn.Name == button.Name)
                {
                    Color color = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#ccf783");
                    button.Background = new SolidColorBrush(color);
                }
                else
                {
                    Color color = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF");
                    button.Background = new SolidColorBrush(color);
                }
            }

        }

        internal void SetTabItemHeader(string szfilename, System.Windows.Controls.TabControl myTabControl)
        {
            int currentItem = myTabControl.SelectedIndex;
            FileInfo fileInfo = new FileInfo(szfilename);
            MarkingPreviewFileModel markingPreviewFileModel = new MarkingPreviewFileModel();
            markingPreviewFileModel.SafeName = fileInfo.Name;
            markingPreviewFileModel.FullName = fileInfo.FullName;
            if (currentItem > PreviewTabItems.Count - 1)
            {
                PreviewTabItems.Add(markingPreviewFileModel);
            }
            else
            {
                PreviewTabItems[currentItem] = markingPreviewFileModel;
            }
            (myTabControl.Items[currentItem] as TabItem).Header = markingPreviewFileModel.SafeName;
        }

        internal MarkingPreviewFileModel GetMarkingPreviewFileModel(int idx)
        {
            if (idx > PreviewTabItems.Count - 1)
            {
                MarkingPreviewFileModel markingPreviewFileModel = new MarkingPreviewFileModel();
                PreviewTabItems.Add(markingPreviewFileModel);
                return markingPreviewFileModel;
            }
            return PreviewTabItems[idx];
        }

        internal void AddToolsGroupBtn(Button btn)
        {
            foreach (Button button in ToolsBtnGroup)
            {
                if (btn.Name == button.Name)
                {
                    return;
                }
            }
            this.ToolsBtnGroup.Add(btn);
        }
        internal void SetToolsGroupBtn(Button btn)
        {
            foreach (Button button in ToolsBtnGroup)
            {
                if (btn.Name == button.Name)
                {
                    button.Background = new SolidColorBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString("#ccf783"));
                }
                else
                {
                    button.Background = new SolidColorBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));
                }
            }

        }
    }
}
