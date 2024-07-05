using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMarking.Model
{
    class LayerParaModel
    {
        public int nCount; //打标次数
        public double dbMarkV; //矢量打标速度(mm/s)
        public double dbJumpV; //矢量空跳速度(mm/s)
        public double dbQFre; //Q频(KHz)
        public double dbQRls; //Q释放(us)
        public double dbCurrent; //电流(A)
        public int nFpkTime; //首脉冲抑制时间
        public double dbFPKInitRate; //首点比例(0.0~1.0)
        public double dbFPKLenRate; //抑制长度系数(0.0~0.999)
        public double dbFPKMaxPRate; //峰值能量比例(0.0~1.0)
        public double dbFPKCurRate; //首脉冲电流系数(0.0~1.0)
        public int nQuality; //打标质量系数
        public int nLayerDelay; //层延时
        public int nLaserOnDelay; //激光开延时(us)
        public int nLaserOffDelay; //激光关延时(us)
        public int nMoveLineDelay; //走笔延时(us)
        public int nJumpDelay; //跳转延时(us)
        public int nRoundDelay; //拐弯延时(us)
        public double dbCurrentR; //电流(%)
        public double dbSimmerCur; //维持电流(%)
        public int nWaveForm; //波形   和HS_ILaserOn2 中nLaserMode: 激光模式（波形号）一致
        public double dbPower; //维持功率(%)
        public double dbPowerR; //功率(%)
        public int nLaserPulse; //激光脉宽（ns）
    }
}
