using System.Runtime.InteropServices;
using System.Text;

namespace RobotMarking.Sdk
{
    static public class CSharpInterface
    {
        public static string g_strPathName = "";

        public delegate void MsgFlyMarkCall(uint nCard, int nID, ulong nMarkTime);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_GetDllVersion",
         CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_GetDllVersion(ref ushort pMainVer, ref ushort pDllVer);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_GetLastError",
         CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_GetLastError(uint uCard, ref int nError, StringBuilder lpszMsg, int nSize);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_InitialMachine",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]

        public static extern int HS_InitialMachine(string strPath);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_LoadMarkFile",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_LoadMarkFile(uint uCard, string strFileName);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_Mark",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]

        public static extern int HS_Mark(uint uCard, int nType, bool bWaitTouch, bool bWaitEnd, int nOverTime, bool bMarkAll);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_CloseMachine",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]

        public static extern int HS_CloseMachine();

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_FreeStrokeList",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]

        public static extern int HS_FreeStrokeList(uint uCard, CInterStroke[] m_listCustom);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_GetMarkRange",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_GetMarkRange(uint uCard, ref double pX, ref double pY);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_CloseMarkFile",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_CloseMarkFile(uint uCard, string szFileName, bool bSave);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_IsTouch",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_IsTouch(uint uCard, ref int nTouchFlag);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_CheckTouch",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_CheckTouch(uint uCard, nint hWnd, bool bActive);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_ReadPort",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_ReadPort(uint uCard, ref ushort nValue);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_WritePort",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]

        public static extern int HS_WritePort(uint uCard, uint dbValue, int dbMask);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_IsMarkEnd",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_IsMarkEnd(uint uCard, ref int pFlag);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_GetMarkTime",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_GetMarkTime(uint uCard, ref int nMarkTime);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_MarkStop",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_MarkStop(uint uCard);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_ChangeTextByNameW",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_ChangeTextByNameW(uint uCard, string strName, byte[] strText);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_GetObjProperty",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_GetObjProperty(uint uCard, ref double dbLeft, ref double dbTop, ref double dbRight, ref double dbBottom);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_GetTextByName",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_GetTextByName(uint uCard, string szTextName, StringBuilder szText, ref int nMaxCount);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_GetTextByNameW",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_GetTextByNameW(uint uCard, string szTextName, byte[] szText, ref int nMaxCount);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_PreviewGraph",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_PreviewGraph(uint uCard, nint hWnd, double dbCenterX, double dbCenterY, double dbScale);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_Move",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_Move(uint uCard, double dbMoveX, double dbMoveY);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_Rotate",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_Rotate(uint uCard, double x, double y, double dbRotate);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_ChangeTextByName",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_ChangeTextByName(uint uCard, string lpszTextName, string lpszText);

        //add 2022/2/28
        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_ReadOutPort",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_ReadOutPort(uint uCard, ref ushort nReadPort);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_GetTimeDogInfoID",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool HS_GetTimeDogInfoID(byte[] id, byte[] compid, byte[] devid);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_SetCurDoc",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_SetCurDoc(uint uCard, string strFile);

        //iBit:   输出口号
        //bState :true    高电平
        //		  false   低电平
        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_WriteOutPortBit",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool HS_WriteOutPortBit(uint uCard, int iBit, bool bState);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_GetCardNumber",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_GetCardNumber(ref uint uCardNum);

        //add 2022/05/16
        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_MarkStorke",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_MarkStorke(uint uCard, int nType, tgStroke[] pStroke, int nNum);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_SetMarkModel",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_SetMarkModel(uint uCard, int nMarkModel, int nFlyType, bool bFlyReveral, double dbSpeed, MsgFlyMarkCall MyDelegate);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_GetObjList",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_GetObjList(uint uCard, byte[,] szObjList, ref int pCount);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_SelectObjects",
        CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_SelectObjects(uint uCard, string lpszObjName, bool bSelected);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_AddText",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_AddText(uint uCard, string szStr, double dbHeight, double dbWidthRatio, bool bModel,
            string szTextName, double dbPosX, double dbPosY, int nAlign, double dbAngle,
            int nLayer, bool bHatch, int nHatchLayer, string szObjName);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_AddText2",
       CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_AddText2(double dbCharSpace, double dbLineSpace);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_ISetRedLight",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_ISetRedLight(uint uCard, bool bOpen);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_GetRedLight",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_GetRedLight(uint uCard, ref bool bOpen);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_SaveMarkFile",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_SaveMarkFile(uint uCard, string szFile);


        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_GetLayerPara",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_GetLayerPara(uint uCard, int nLayer, ref LAYERPARA pPara);

        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_SetLayerPara",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_SetLayerPara(uint uCard, int nLayer, ref LAYERPARA pPara);



        // 自定义命令发送
        [DllImport("HansAdvInterfaceU.dll", EntryPoint = "HS_SendCustomCmd",
        CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int HS_SendCustomCmd(uint uCard, long inCmd, long outCmd);

        /*
                    // 示例：发送自定义命令实现

                    // 下发的数据
                    USERCMD_PARA cmd_down = new USERCMD_PARA();
                    cmd_down.wPara = new UInt16[16];
                    cmd_down.wPara[0] = 6; // 固定值
                    cmd_down.wPara[1] = 39024; // 命令号
                    //cmd_down.wPara[2] = 1111; // 其他数据位

                    // 接收的数据
                    USERCMD_PARA cmd_ret = new USERCMD_PARA();
                    cmd_ret.wPara = new UInt16[16];

                    // 下发数据格式转换
                    int size1 = Marshal.SizeOf(typeof(USERCMD_PARA));
                    byte[] bytes1 = new byte[size1];
                    IntPtr pBuff1 = Marshal.AllocHGlobal(size1);
                    Marshal.StructureToPtr(cmd_down, pBuff1, true);
                    Marshal.Copy(pBuff1, bytes1, 0, size1);
                    Int64 p1 = pBuff1.ToInt64();

                    // 接收数据格式转换
                    int size2 = Marshal.SizeOf(typeof(USERCMD_PARA));
                    byte[] bytes2 = new byte[size2];
                    IntPtr pBuff2 = Marshal.AllocHGlobal(size2);
                    Marshal.StructureToPtr(cmd_ret, pBuff2, true);
                    Marshal.Copy(pBuff2, bytes2, 0, size1);
                    Int64 p2 = pBuff2.ToInt64();

                    // 发送
                    int ret = CSharpInterface.HS_SendCustomCmd(g_uCard, p1, p2);

                    // 数据回转
                    USERCMD_PARA r1 = (USERCMD_PARA)Marshal.PtrToStructure(pBuff1, typeof(USERCMD_PARA));
                    USERCMD_PARA r2 = (USERCMD_PARA)Marshal.PtrToStructure(pBuff2, typeof(USERCMD_PARA));
        */

        public static string GetError()
        {
            uint uCard = 0;
            int nEror = 0;
            StringBuilder szBuff = new StringBuilder(200);
            HS_GetLastError(uCard, ref nEror, szBuff, 200);
            return szBuff.ToString();
        }

    }

    //对外接口数据结构
    [StructLayout(LayoutKind.Sequential)]
    public struct CInterStroke
    {
        [MarshalAs(UnmanagedType.ByValArray)]
        public CInterDoc[] m_dotArray;

        [MarshalAs(UnmanagedType.U4)]
        public int m_nLayer;
    };

    //对外接口线条数据类
    [StructLayout(LayoutKind.Sequential)]
    public struct CInterDoc
    {
        [MarshalAs(UnmanagedType.R8)]
        public double x;
        [MarshalAs(UnmanagedType.R8)]
        public double y;
        [MarshalAs(UnmanagedType.R8)]
        public double z;
    };

    // 对外接口自定义命令结构
    [StructLayout(LayoutKind.Sequential)]
    public struct USERCMD_PARA
    {
        [MarshalAs(UnmanagedType.U2)]
        public ushort nVer;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public ushort[] wPara;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct tgDot
    {
        [MarshalAs(UnmanagedType.R8)]
        public double x;
        [MarshalAs(UnmanagedType.R8)]
        public double y;
        [MarshalAs(UnmanagedType.R8)]
        public double z;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct tgStroke
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint nCount;
        [MarshalAs(UnmanagedType.I4)]
        public int nLayer;
        [MarshalAs(UnmanagedType.ByValArray)]
        public tgDot[] pDot;
    };

    //层参数结构体定义
    [StructLayout(LayoutKind.Sequential)]
    public struct LAYERPARA
    {
        [MarshalAs(UnmanagedType.U4)]
        public int nCount;		    //打标次数
        [MarshalAs(UnmanagedType.R8)]
        public double dbMarkV;		//矢量打标速度(mm/s)
        [MarshalAs(UnmanagedType.R8)]
        public double dbJumpV;		//矢量空跳速度(mm/s)
        [MarshalAs(UnmanagedType.R8)]
        public double dbQFre;			//Q频(KHz)
        [MarshalAs(UnmanagedType.R8)]
        public double dbQRls;			//Q释放(us)
        [MarshalAs(UnmanagedType.R8)]
        public double dbCurrent;		//电流(A)
        [MarshalAs(UnmanagedType.U4)]
        public int nFpkTime;		//首脉冲抑制时间	
        [MarshalAs(UnmanagedType.R8)]
        public double dbFPKInitRate;	//首点比例(0.0~1.0)	
        [MarshalAs(UnmanagedType.R8)]
        public double dbFPKLenRate;	//抑制长度系数(0.0~0.999)
        [MarshalAs(UnmanagedType.R8)]
        public double dbFPKMaxPRate;	//峰值能量比例(0.0~1.0)
        [MarshalAs(UnmanagedType.R8)]
        public double dbFPKCurRate;	//首脉冲电流系数(0.0~1.0)
        [MarshalAs(UnmanagedType.U4)]
        public int nQuality;		//打标质量系数
        [MarshalAs(UnmanagedType.U4)]
        public int nLayerDelay;	//层延时
        [MarshalAs(UnmanagedType.U4)]
        public int nLaserOnDelay;	//激光开延时(us)
        [MarshalAs(UnmanagedType.U4)]
        public int nLaserOffDelay;	//激光关延时(us)
        [MarshalAs(UnmanagedType.U4)]
        public int nMoveLineDelay;	//走笔延时(us)
        [MarshalAs(UnmanagedType.U4)]
        public int nJumpDelay;		//跳转延时(us)
        [MarshalAs(UnmanagedType.U4)]
        public int nRoundDelay;	//拐弯延时(us)
        [MarshalAs(UnmanagedType.R8)]
        public double dbCurrentR;		//电流(%)
        [MarshalAs(UnmanagedType.R8)]
        public double dbSimmerCur;	//维持电流(%)
        [MarshalAs(UnmanagedType.U4)]
        public int nWaveForm;		//波形
        [MarshalAs(UnmanagedType.R8)]
        public double dbPowerR;		//功率(%)
        [MarshalAs(UnmanagedType.U4)]
        public int nLaserPulse;	///激光脉宽（ns）
    };
}
