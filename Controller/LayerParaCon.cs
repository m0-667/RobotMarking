using Newtonsoft.Json;
using RobotMarking.Model;
using RobotMarking.Sdk;
using RobotMarking.Service;
using System.IO;

namespace RobotMarking.Controller
{
    class LayerParaCon
    {
        public LayerParaModel? LayerParaModel = new LayerParaModel();
        LAYERPARA m_layerPara = new LAYERPARA();
        int m_nLayerNo;
        public LayerParaCon()
        {
            LoadPara();
        }

        internal void LoadCurrentData()
        {
            LoadPara();
        }

        internal void LoadDefaultData()
        {
            string fn = $"{AppS.Instance.DataDir}/defaultLP.json";
            string content = File.ReadAllText(fn);
            if (string.IsNullOrEmpty(content))
            {
                MessageBox.Show("没有找到对应的数据!");
            }
            LayerParaModel = JsonConvert.DeserializeObject<LayerParaModel>(content);
        }

        internal void SaveCurrentData()
        {
            string fn = $"{AppS.Instance.DataDir}/currentLP.json";
            string content = JsonConvert.SerializeObject(LayerParaModel);
            File.WriteAllText(fn, content);
            SetLayerPara();
        }



        private void LoadPara()
        {
            string fn = $"{AppS.Instance.DataDir}/currentLP.json";
            if (!File.Exists(fn))
            {
                fn = $"{AppS.Instance.DataDir}/defaultLP.json";
            }
            string content = File.ReadAllText(fn);
            if (string.IsNullOrEmpty(content))
            {
                MessageBox.Show("没有找到对应的数据!");
            }
            LayerParaModel = JsonConvert.DeserializeObject<LayerParaModel>(content);
        }


        private void GetLayerPara()
        {
            m_nLayerNo = 0;
            int nRet = CSharpInterface.HS_GetLayerPara(0, m_nLayerNo, ref m_layerPara);

            if (nRet != 0)
            {
                MessageBox.Show("读取层参数数据失败！\n返回值：" + nRet.ToString() + "\n错误信息："
                    + CSharpInterface.GetError().ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SetLayerPara()
        {
            m_layerPara.nCount = LayerParaModel.nCount;
            m_layerPara.dbCurrent = LayerParaModel.dbCurrent;
            m_layerPara.dbCurrentR = LayerParaModel.dbCurrentR;
            m_layerPara.dbFPKInitRate = LayerParaModel.dbFPKInitRate;
            m_layerPara.dbFPKCurRate = LayerParaModel.dbFPKCurRate;
            m_layerPara.dbFPKLenRate = LayerParaModel.dbFPKLenRate;
            m_layerPara.dbFPKMaxPRate = LayerParaModel.dbFPKMaxPRate;
            m_layerPara.nFpkTime = LayerParaModel.nFpkTime;
            m_layerPara.nJumpDelay = LayerParaModel.nJumpDelay;
            m_layerPara.dbJumpV = LayerParaModel.dbJumpV;
            m_layerPara.nLaserOffDelay = LayerParaModel.nLaserOffDelay;
            m_layerPara.nLaserOnDelay = LayerParaModel.nLaserOnDelay;
            m_layerPara.nLayerDelay = LayerParaModel.nLayerDelay;
            m_layerPara.dbMarkV = LayerParaModel.dbMarkV;
            m_layerPara.nMoveLineDelay = LayerParaModel.nMoveLineDelay;
            m_layerPara.dbPowerR = LayerParaModel.dbPowerR;
            m_layerPara.dbQFre = LayerParaModel.dbQFre;
            m_layerPara.dbQRls = LayerParaModel.dbQRls;
            m_layerPara.nQuality = LayerParaModel.nQuality;
            m_layerPara.nRoundDelay = LayerParaModel.nRoundDelay;
            m_layerPara.dbSimmerCur = LayerParaModel.dbSimmerCur;
            m_layerPara.nWaveForm = LayerParaModel.nWaveForm;
            m_layerPara.nLaserPulse = LayerParaModel.nLaserPulse;

            m_nLayerNo = 0;
            int nRet = CSharpInterface.HS_SetLayerPara(0, m_nLayerNo, ref m_layerPara);
            if (nRet == 0)
            {
                MessageBox.Show("层参数设置成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("层参数设置失败！\n返回值：" + nRet.ToString() + "\n错误信息："
                                           + CSharpInterface.GetError().ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
