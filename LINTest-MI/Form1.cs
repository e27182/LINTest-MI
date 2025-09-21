// Decompiled with JetBrains decompiler
// Type: LINTest.Form1
// Assembly: LINTest-MI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 31F20A11-E735-463D-98C4-C3643CDDF7B8
// Assembly location: C:\Users\xxxxx\Downloads\LIN Test MI\Files.fm_LINTest-MI\电脑软件\LINTest-MI V1.0.5\LINTest-MI.exe

using CH340BCFG;
using ControlExs;
using ControlLibrary;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DSControls;
using LINTest.Properties;
using MyControl.Controls;
using ProgressODoom;
using Sunny.UI;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.IO.Ports;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using 工程;

#nullable disable
namespace LINTest;

public class Form1 : FormEx
{
  public float X;
  public float Y;
  private Version currentVersion = Environment.OSVersion.Version;
  private Version compareToVersion = new Version("6.2");
  private UiProgressMethods prog12 = new UiProgressMethods();
  public Thread tp12 = (Thread) null;
  private UiProgressMethods prog13 = new UiProgressMethods();
  public Thread tp13 = (Thread) null;
  public Thread USB_Receive_Thread;
  public Thread Timing_Send_Thread;
  public Thread Timing_Receive_Thread;
  public Thread AUTO_Sync_Task;
  public Thread BOOT_Thread;
  public Thread Play_Thread;
  public Thread Save_listViewNF1_Thread;
  public Thread Save_listViewNF2_Thread;
  public Thread Save_listViewNF3_Thread;
  public Thread Save_listViewNF4_Thread;
  public Thread Save_listViewNF6_Thread;
  public static bool EN_ClearMemory_flag = false;
  public static int Clear_Memory = 0;
  public static bool Chang_Data_Error_flag = false;
  public static bool System_UART_RX_Rrror_flag = false;
  public static bool Device_switch_flag = false;
  public static string CheckSum_Type = "增强型校验和";
  public static int Port_Number = 0;
  public static string PortName = "";
  public static byte[] Send_Frame_Data = new byte[(int) byte.MaxValue];
  public static byte[] Receive_Frame_Data = new byte[(int) byte.MaxValue];
  public static int Rur_Mode = 0;
  public static int Baud_rate = 0;
  public static DateTime System_Time_R;
  public static DateTime System_Time_T;
  public static DateTime RTOS_Time;
  public static string RTOS_Save_FileName_str = "";
  public static bool mode4_Save_Task_flag = false;
  public static bool mode3_Save_Task_flag = false;
  public static bool mode2_Save_Task_flag = false;
  public static int mode3_Save_Task_i = 0;
  public static int mode4_Save_Task_i = 0;
  public static int mode2_Save_Task_i = 0;
  public static int USB_Receive_Length = 0;
  public static bool Exit_Receive_flag = false;
  public static bool Exit_Task_flag = false;
  public static Thread Off_line_Thread;
  public static byte[,] Off_line_Date = new byte[250, 16 /*0x10*/];
  public static int Volume_value = 0;
  public static int Line_time = 0;
  public static int Off_line_count = 0;
  public static bool mode4_flag = false;
  public static bool Exit_mode4_flag = false;
  public static int Off_line_task_Send_i = 0;
  public static string Off_line_Device_str = "";
  public static int RX_out_line_i = 0;
  public static object locker = new object();
  public static byte[,] Monitor_Data = new byte[65538 /*0x010002*/, 16 /*0x10*/];
  public static byte[,] Monitor_EN = new byte[(int) byte.MaxValue, 1];
  public static byte[,] Monitor_Static = new byte[256 /*0x0100*/, 1];
  public static string[,] Monitor_time = new string[65538 /*0x010002*/, 1];
  public static int Monitor_count = 0;
  public static int Monitor_Display_count = 0;
  public static bool Monitor_Mode = false;
  public static bool Monitor_Display_Mode = false;
  public static string M_ID = "";
  public static string M_Str = "";
  public static string M_State = "";
  public static string M_Check = "";
  public static int M_Length = 0;
  public static string[,] M_Static_Save = new string[65538 /*0x010002*/, 9];
  public static int M_Static_i = 0;
  public static string Save_FileName_str = "";
  public static int Save_ProgressBar_i = 0;
  public static bool Save_Finish_flag = false;
  public static bool Exit_Save_listViewNF4_flag = false;
  public static byte[,] Slave_Mode_Data = new byte[65538 /*0x010002*/, 16 /*0x10*/];
  public static byte[,] Slave_Send_Data = new byte[64 /*0x40*/, 16 /*0x10*/];
  public static byte[,] Slave_EN = new byte[(int) byte.MaxValue, 2];
  public static byte[,] Slave_Static = new byte[256 /*0x0100*/, 1];
  public static string[,] Slave_time = new string[65538 /*0x010002*/, 1];
  public static int Slave_Send_i = 0;
  public static int Slave_count = 0;
  public static int Slave_Display_count = 0;
  public static bool Slave_Display_Mode = false;
  public static string SM_ID = "";
  public static string SM_Dir = "";
  public static string SM_Ch = "";
  public static string SM_Str = "";
  public static string SM_State = "";
  public static string SM_Check = "";
  public static int SM_Length = 0;
  public static bool Exit_RTOS_Save_mode3_flag = false;
  public static string[,] S_Static_Save = new string[65538 /*0x010002*/, 9];
  public static int S_Static_i = 0;
  public static bool Exit_Save_listViewNF3_flag = false;
  public static bool Single_Frame_Send = true;
  public static bool Single_Frame_Receive = true;
  public static bool Send_Checked_flag = false;
  public static bool Receive_Checked_flag = false;
  public static bool Send_flag1 = true;
  public static bool Send_flag2 = false;
  public static bool Send_flag3 = false;
  public static bool Receive_flag1 = true;
  public static bool Receive_flag2 = false;
  public static bool Receive_flag3 = false;
  public static byte[,] Single_Mode_Data = new byte[65538 /*0x010002*/, 16 /*0x10*/];
  public static string[,] Single_time = new string[65538 /*0x010002*/, 1];
  public static byte[,] Single_Send_Data = new byte[64 /*0x40*/, 16 /*0x10*/];
  public static int Single_Send_i = 0;
  public static int Single_count = 0;
  public static int Single_Display_count = 0;
  public static string SI_ID = "";
  public static string SI_Dir = "";
  public static string SI_Ch = "";
  public static string SI_Str = "";
  public static string SI_State = "";
  public static string SI_Check = "";
  public static int SI_Length = 0;
  public static int Single_time_value = 0;
  public static bool Timing_Send_flag = false;
  public static bool Exit_Save_listViewNF1_flag = false;
  public static byte[,] List_Mode_Data = new byte[65538 /*0x010002*/, 16 /*0x10*/];
  public static byte[,] List_Send_Data = new byte[64 /*0x40*/, 16 /*0x10*/];
  public static byte[,] List_EN = new byte[(int) byte.MaxValue, 2];
  public static byte[,] List_Static = new byte[256 /*0x0100*/, 1];
  public static int[,] List_time_value = new int[(int) byte.MaxValue, 1];
  public static string[,] List_time = new string[65538 /*0x010002*/, 1];
  public static int List_Send_i = 0;
  public static int List_count = 0;
  public static int List_Display_count = 0;
  public static bool List_Display_Mode = false;
  public static string LI_ID = "";
  public static string LI_Dir = "";
  public static string LI_Ch = "";
  public static string LI_Str = "";
  public static string LI_State = "";
  public static string LI_Check = "";
  public static int LI_Length = 0;
  public static bool List_Send_flag = false;
  public static int List_send_fixed_number = 0;
  public static bool List_send_fixed_flag = false;
  public static int List_fixed_i = 0;
  public static string[,] LI_Static_Save = new string[65538 /*0x010002*/, 9];
  public static int LI_Static_i = 0;
  public static bool Exit_Save_listViewNF2_flag = false;
  public static int AUTO_Progress_value = 0;
  public static bool AUTO_flish_flag = false;
  public static bool Exit_AUTO_flag = false;
  public static byte[,] BOOT_DATA = new byte[16384 /*0x4000*/, 16 /*0x10*/];
  public uint BOOT_Data_i = 0;
  public static uint BOOT_Task_Data_i = 0;
  public static byte Erase_Start_Address0 = 0;
  public static byte Erase_Start_Address1 = 0;
  public static byte Erase_Start_Address2 = 0;
  public static byte Erase_End_Address0 = 0;
  public static byte Erase_End_Address1 = 0;
  public static byte Erase_End_Address2 = 0;
  public static int BOOT_time_value = 0;
  public static int[] BOOT_Delay = new int[20]
  {
    100,
    100,
    100,
    500,
    100,
    100,
    100,
    100,
    100,
    100,
    6500,
    100,
    100,
    100,
    100,
    100,
    100,
    100,
    100,
    100
  };
  public static bool ACK_Flag1 = false;
  public static bool ACK_Flag2 = false;
  public static bool ACK_Flag3 = false;
  public static bool ACK_Flag4 = false;
  public static bool ACK_Flag5 = false;
  public static bool ACK_Flag6 = false;
  public static bool NoACK_Flag1 = false;
  public static bool NoACK_Flag2 = false;
  public static bool NoACK_Flag3 = false;
  public static bool NoACK_Flag4 = false;
  public static bool NoACK_Flag5 = false;
  public static bool NoACK_Flag6 = false;
  public static int BOOT_Progress = 0;
  public static string Timespan = "";
  public static DateTime Start_dt;
  public static DateTime End_dt;
  public static TimeSpan Between_dt;
  public static int BOOT_Status = 0;
  public static bool WDT_Finish = false;
  public static bool WDT_Finish_break = false;
  public const uint CRC32INIT = 4294967295 /*0xFFFFFFFF*/;
  public static uint[] CrcTable = new uint[256 /*0x0100*/];
  public static uint CrcRemainder = 0;
  public static uint CRC32_Value = 0;
  public static bool BOOT_ON_flag = false;
  public static bool Program_Finish_flag = false;
  public static string Selecte_str = "";
  public static int Selected_Rows = (int) byte.MaxValue;
  public static byte[] Receive_USB_Data;
  public static byte[] RX_buffer_Data = new byte[1120000];
  public static int RX_count = 0;
  public static int RX_Save_count = 0;
  public static byte[,] Play_Back_Data = new byte[65540 /*0x010004*/, 16 /*0x10*/];
  public static uint Play_cnt = 0;
  public static uint Play_i = 0;
  public static byte Mask_ID1 = 0;
  public static byte Mask_ID2 = 0;
  public static byte Mask_ID3 = 0;
  public static bool Mask1_flag = false;
  public static bool Mask2_flag = false;
  public static bool Mask3_flag = false;
  public static uint Play_time = 0;
  public static bool Play_flag = false;
  public static uint Play_number = 0;
  public static uint Play_number_cnt = 0;
  public static bool Play_flash_flag = false;
  public static byte[,] Baud_Rate_Data = new byte[65538 /*0x010002*/, 16 /*0x10*/];
  public static int Baud_count = 0;
  public static int Baud_Display_count = 0;
  public static uint Baud_value = 0;
  public static uint Positive_Pulse = 0;
  public static uint Negative_Pulse = 0;
  public static uint Baud_static_value = 0;
  public static uint Positive_static_Pulse = 0;
  public static uint Negative_static_Pulse = 0;
  public static bool Exit_Save_listViewNF6_flag = false;
  public static int Save6_ProgressBar_i = 0;
  public static bool Save6_Finish_flag = false;
  public static string[,] LDF_str = new string[5000, 1];
  public static uint LDF_number = 0;
  public static int LIN_speed = 0;
  public static string[,] Master_Nodes = new string[100, 1];
  public static uint Master_Nodes_number = 0;
  public static string[,] Slaves_Nodes = new string[(int) byte.MaxValue, 1];
  public static uint Slaves_Nodes_number = 0;
  public static string[,] LDF_Frames = new string[4500, 10];
  public static uint Frames_number = 0;
  public static string[,] Signal_encoding_types = new string[5000, 8];
  public static uint ENC_types_number = 0;
  public static string[,] Signal_representation = new string[5000, 2];
  public static uint representation_number = 0;
  public static string[,] Schedule_tables = new string[2000, 3];
  public static uint Schedule_number = 0;
  public static int SlistView_cnt = 0;
  public static byte[,] Matrix_Color = new byte[64 /*0x40*/, 3]
  {
    {
      (byte) 80 /*0x50*/,
      (byte) 160 /*0xA0*/,
      byte.MaxValue
    },
    {
      (byte) 104,
      byte.MaxValue,
      (byte) 242
    },
    {
      (byte) 68,
      byte.MaxValue,
      (byte) 118
    },
    {
      (byte) 150,
      (byte) 128 /*0x80*/,
      byte.MaxValue
    },
    {
      (byte) 227,
      (byte) 148,
      byte.MaxValue
    },
    {
      (byte) 170,
      byte.MaxValue,
      (byte) 112 /*0x70*/
    },
    {
      byte.MaxValue,
      (byte) 247,
      (byte) 131
    },
    {
      byte.MaxValue,
      (byte) 158,
      (byte) 107
    },
    {
      byte.MaxValue,
      (byte) 254,
      (byte) 51
    },
    {
      byte.MaxValue,
      byte.MaxValue,
      byte.MaxValue
    },
    {
      (byte) 22,
      (byte) 165,
      byte.MaxValue
    },
    {
      byte.MaxValue,
      (byte) 118,
      (byte) 36
    },
    {
      (byte) 168,
      (byte) 206,
      byte.MaxValue
    },
    {
      (byte) 90,
      (byte) 115,
      byte.MaxValue
    },
    {
      byte.MaxValue,
      (byte) 79,
      (byte) 226
    },
    {
      (byte) 211,
      byte.MaxValue,
      (byte) 173
    },
    {
      (byte) 158,
      byte.MaxValue,
      (byte) 210
    },
    {
      byte.MaxValue,
      (byte) 153,
      (byte) 15
    },
    {
      (byte) 22,
      (byte) 215,
      byte.MaxValue
    },
    {
      byte.MaxValue,
      (byte) 189,
      (byte) 164
    },
    {
      (byte) 23,
      (byte) 122,
      byte.MaxValue
    },
    {
      (byte) 105,
      byte.MaxValue,
      (byte) 96 /*0x60*/
    },
    {
      (byte) 213,
      byte.MaxValue,
      (byte) 82
    },
    {
      byte.MaxValue,
      (byte) 236,
      (byte) 248
    },
    {
      byte.MaxValue,
      (byte) 133,
      (byte) 195
    },
    {
      (byte) 135,
      (byte) 68,
      byte.MaxValue
    },
    {
      (byte) 83,
      (byte) 62,
      byte.MaxValue
    },
    {
      byte.MaxValue,
      (byte) 15,
      (byte) 98
    },
    {
      byte.MaxValue,
      (byte) 217,
      (byte) 18
    },
    {
      (byte) 178,
      byte.MaxValue,
      (byte) 45
    },
    {
      (byte) 173,
      (byte) 178,
      (byte) 181
    },
    {
      (byte) 99,
      (byte) 182,
      byte.MaxValue
    },
    {
      (byte) 150,
      (byte) 128 /*0x80*/,
      byte.MaxValue
    },
    {
      (byte) 141,
      byte.MaxValue,
      (byte) 70
    },
    {
      byte.MaxValue,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      byte.MaxValue,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      byte.MaxValue
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    },
    {
      (byte) 0,
      (byte) 0,
      (byte) 0
    }
  };
  private IContainer components = (IContainer) null;
  private MyToolBar myToolBar1;
  private Label label3;
  private QQTextBox qqTextBox1;
  private Label label2;
  private QQTextBox qqTextBox2;
  private QQCheckBox qqCheckBox1;
  private QQCheckBox qqCheckBox3;
  private QQTextBox qqTextBox8;
  private QQTextBox qqTextBox7;
  private QQCheckBox qqCheckBox2;
  private QQTextBox qqTextBox5;
  private QQTextBox qqTextBox4;
  private QQTextBox qqTextBox10;
  private QQRadioButton qqRadioButton4;
  private QQRadioButton qqRadioButton3;
  private QQRadioButton qqRadioButton6;
  private QQRadioButton qqRadioButton5;
  private QQTextBox qqTextBox17;
  private QQCheckBox qqCheckBox6;
  private QQTextBox qqTextBox15;
  private QQCheckBox qqCheckBox5;
  private QQTextBox qqTextBox13;
  private QQCheckBox qqCheckBox4;
  private QQTextBox qqTextBox11;
  private OpenFileDialog openFileDialog1;
  private MyPanel.MyPanel myPanel7;
  private MyPanel.MyPanel myPanel8;
  private MyPanel.MyPanel myPanel11;
  private MyPanel.MyPanel myPanel3;
  private Label label1;
  private ComboBox comboBox1;
  private SaveFileDialog saveFileDialog1;
  private SaveFileDialog saveFileDialog2;
  private SaveFileDialog saveFileDialog3;
  private ProgressBarEx progressBarEx1;
  private GradientBackgroundPainter greenGradientBackgroundPainter1;
  private PlainBorderPainter greenPlainBorderPainter1;
  private GradientGlossPainter greenGradientGlossPainter1;
  private QQTextBox qqTextBox9;
  private QQTextBox qqTextBox6;
  private QQTextBox qqTextBox3;
  private OpenFileDialog openFileDialog2;
  private System.Windows.Forms.TabControl tabControl1;
  private TabPage tabPage1;
  private TabPage tabPage2;
  private TabPage tabPage4;
  private TabPage tabPage6;
  private TabPage tabPage7;
  private TabPage tabPage8;
  private DS标签 dS标签1;
  private DS标签 dS标签2;
  private PlainProgressPainter greenPlainProgressPainter1;
  private MyButton imageButton5;
  private MyButton imageButton6;
  private MyButton imageButton8;
  private MyButton imageButton7;
  private MyButton imageButton3;
  private MyButton imageButton4;
  private ImageButton imageButton2;
  private MyButton imageButton1;
  private QQRadioButton qqRadioButton2;
  private QQRadioButton qqRadioButton1;
  private ListViewNF listViewNF1;
  private ColumnHeader columnHeader1;
  private ColumnHeader columnHeader2;
  private ColumnHeader columnHeader3;
  private ColumnHeader columnHeader4;
  private ColumnHeader columnHeader5;
  private ColumnHeader columnHeader6;
  private ColumnHeader columnHeader7;
  private ColumnHeader columnHeader8;
  private ColumnHeader columnHeader26;
  private GroupBoxEx groupBoxEx4;
  private QQTextBox qqTextBox16;
  private QQTextBox qqTextBox14;
  private QQTextBox qqTextBox12;
  private DS数字输入框 dS数字输入框1;
  private TabPage tabPage3;
  private TabPage tabPage5;
  private ListViewNF listViewNF2;
  private ColumnHeader columnHeader9;
  private ColumnHeader columnHeader10;
  private ColumnHeader columnHeader11;
  private ColumnHeader columnHeader12;
  private ColumnHeader columnHeader13;
  private ColumnHeader columnHeader14;
  private ColumnHeader columnHeader15;
  private ColumnHeader columnHeader16;
  private ColumnHeader columnHeader17;
  private MyPanel.MyPanel myPanel19;
  private MyButton imageButton10;
  private MyButton imageButton9;
  private GroupBoxEx groupBoxEx3;
  private QQRadioButton qqRadioButton8;
  private QQRadioButton qqRadioButton7;
  private Bar bar2;
  private DataGridViewX dataGridViewX1;
  private Bar bar1;
  private Label label39;
  private DS按钮 dS按钮2;
  private DS按钮 dS按钮1;
  private DataGridViewCheckBoxColumn Column1;
  private DataGridViewTextBoxColumn Column6;
  private DataGridViewComboBoxColumn Column2;
  private DataGridViewTextBoxColumn Column3;
  private DataGridViewTextBoxColumn Column4;
  private DataGridViewTextBoxColumn Column7;
  private DataGridViewTextBoxColumn Column5;
  private ListViewNF listViewNF3;
  private ColumnHeader columnHeader18;
  private ColumnHeader columnHeader19;
  private ColumnHeader columnHeader20;
  private ColumnHeader columnHeader21;
  private ColumnHeader columnHeader22;
  private ColumnHeader columnHeader23;
  private ColumnHeader columnHeader24;
  private ColumnHeader columnHeader25;
  private ColumnHeader columnHeader27;
  private MyPanel.MyPanel myPanel1;
  private DS按钮 dS按钮4;
  private DS按钮 dS按钮3;
  private MyButton imageButton12;
  private MyButton imageButton11;
  private GroupBoxEx groupBoxEx1;
  private QQRadioButton qqRadioButton10;
  private QQRadioButton qqRadioButton9;
  private Bar bar3;
  private DataGridViewX dataGridViewX2;
  private Bar bar4;
  private Label label4;
  private MyPanel.MyPanel myPanel15;
  private GroupBoxEx groupBoxEx2;
  private QQRadioButton qqRadioButton14;
  private QQRadioButton qqRadioButton13;
  private GroupBoxEx groupBoxEx5;
  private QQRadioButton qqRadioButton12;
  private QQRadioButton qqRadioButton11;
  private Label label38;
  private MyPanel.MyPanel myPanel14;
  private MyButton imageButton14;
  private MyButton imageButton13;
  private QQTextBox qqTextBox29;
  private QQCheckBox qqCheckBox18;
  private QQTextBox qqTextBox28;
  private QQCheckBox qqCheckBox16;
  private QQTextBox qqTextBox26;
  private QQTextBox qqTextBox25;
  private QQCheckBox qqCheckBox15;
  private QQCheckBox qqCheckBox14;
  private QQCheckBox qqCheckBox13;
  private QQCheckBox qqCheckBox17;
  private QQTextBox qqTextBox27;
  private QQTextBox qqTextBox24;
  private QQTextBox qqTextBox23;
  private QQCheckBox qqCheckBox12;
  private QQTextBox qqTextBox22;
  private QQCheckBox qqCheckBox10;
  private QQCheckBox qqCheckBox11;
  private QQTextBox qqTextBox21;
  private QQTextBox qqTextBox20;
  private QQCheckBox qqCheckBox9;
  private Label label16;
  private QQTextBox qqTextBox19;
  private QQCheckBox qqCheckBox7;
  private QQCheckBox qqCheckBox8;
  private QQTextBox qqTextBox18;
  private ListViewNF listViewNF4;
  private ColumnHeader columnHeader28;
  private ColumnHeader columnHeader29;
  private ColumnHeader columnHeader30;
  private ColumnHeader columnHeader31;
  private ColumnHeader columnHeader32;
  private ColumnHeader columnHeader33;
  private ColumnHeader columnHeader34;
  private ColumnHeader columnHeader35;
  private ColumnHeader columnHeader36;
  private DS按钮 dS按钮6;
  private DS按钮 dS按钮5;
  private DS容器 dS容器1;
  private DataGridViewX dataGridViewX3;
  private DS数字输入框 dS数字输入框3;
  private DS数字输入框 dS数字输入框2;
  private DS标签 dS标签4;
  private DS按钮 dS按钮12;
  private DS按钮 dS按钮11;
  private DS按钮 dS按钮10;
  private DS标签 dS标签6;
  private DS按钮 dS按钮9;
  private ListViewNF listViewNF5;
  private ColumnHeader columnHeader37;
  private QQTextBox qqTextBox33;
  private QQTextBox qqTextBox30;
  private QQTextBox qqTextBox31;
  private QQTextBox qqTextBox32;
  private Label label17;
  private DS容器 dS容器4;
  private DS容器 dS容器3;
  private DS标签 dS标签7;
  private QQTextBox qqTextBox36;
  private QQTextBox qqTextBox38;
  private QQTextBox qqTextBox37;
  private QQTextBox qqTextBox35;
  private QQTextBox qqTextBox34;
  private MyButton imageButton16;
  private MyButton imageButton15;
  private DS标签 dS标签8;
  private MyButton imageButton17;
  private DS标签 dS标签9;
  private DS标签 dS标签12;
  private DS按钮 dS按钮13;
  private QQTextBox qqTextBox43;
  private QQTextBox qqTextBox40;
  private QQTextBox qqTextBox42;
  private QQTextBox qqTextBox39;
  private QQTextBox qqTextBox41;
  private DS标签 dS标签11;
  private MyButton imageButton19;
  private MyButton imageButton18;
  private DS标签 dS标签10;
  private DS容器 dS容器5;
  private Label label23;
  private Label label22;
  private DS容器 dS容器6;
  private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
  private DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
  private DataGridViewComboBoxColumn dataGridViewTextBoxColumn5;
  private SerialPort serialPort1;
  private SaveFileDialog saveFileDialog4;
  private DS按钮 dS按钮14;
  private DS按钮 dS按钮15;
  private MyButton myButton1;
  private DS标签 dS标签13;
  private QQTextBox qqTextBox47;
  private QQCheckBox qqCheckBox21;
  private QQTextBox qqTextBox46;
  private QQCheckBox qqCheckBox20;
  private QQTextBox qqTextBox45;
  private QQCheckBox qqCheckBox19;
  private DS标签 dS标签15;
  private QQTextBox qqTextBox44;
  private DS标签 dS标签14;
  private QQTextBox qqTextBox48;
  private QQTextBox qqTextBox49;
  private QQTextBox qqTextBox50;
  private DS标签 dS标签16;
  private TabPage tabPage9;
  private DS按钮 dS按钮16;
  private DS按钮 dS按钮17;
  private MyButton myButton2;
  private MyButton myButton3;
  private Bar bar6;
  private ListViewNF listViewNF7;
  private ColumnHeader columnHeader38;
  private ColumnHeader columnHeader39;
  private ColumnHeader columnHeader40;
  private ColumnHeader columnHeader41;
  private Bar bar7;
  private DS标签 dS标签17;
  private ControlContainerItem controlContainerItem1;
  private Bar bar5;
  private ListViewNF listViewNF6;
  private ColumnHeader columnHeader47;
  private ColumnHeader columnHeader48;
  private ColumnHeader columnHeader49;
  private ColumnHeader columnHeader50;
  private SaveFileDialog saveFileDialog5;
  private TabPage tabPage10;
  private UITitlePanel uiTitlePanel1;
  private UILabel uiLabel8;
  private UILabel uiLabel7;
  private UILabel uiLabel6;
  private UILabel uiLabel5;
  private UILabel uiLabel4;
  private UILabel uiLabel3;
  private UILabel uiLabel2;
  private UILabel uiLabel1;
  private UILine uiLine9;
  private UIButton uiButton63;
  private UIButton uiButton62;
  private UIButton uiButton61;
  private UIButton uiButton60;
  private UIButton uiButton59;
  private UIButton uiButton58;
  private UIButton uiButton57;
  private UIButton uiButton56;
  private UILine uiLine16;
  private UIButton uiButton55;
  private UIButton uiButton54;
  private UIButton uiButton53;
  private UIButton uiButton52;
  private UIButton uiButton51;
  private UIButton uiButton50;
  private UIButton uiButton49;
  private UIButton uiButton48;
  private UILine uiLine15;
  private UIButton uiButton47;
  private UIButton uiButton46;
  private UIButton uiButton45;
  private UIButton uiButton44;
  private UIButton uiButton43;
  private UIButton uiButton42;
  private UIButton uiButton41;
  private UIButton uiButton40;
  private UILine uiLine14;
  private UIButton uiButton39;
  private UIButton uiButton38;
  private UIButton uiButton37;
  private UIButton uiButton36;
  private UIButton uiButton35;
  private UIButton uiButton34;
  private UIButton uiButton33;
  private UIButton uiButton32;
  private UILine uiLine13;
  private UIButton uiButton31;
  private UIButton uiButton30;
  private UIButton uiButton29;
  private UIButton uiButton28;
  private UIButton uiButton27;
  private UIButton uiButton26;
  private UIButton uiButton25;
  private UIButton uiButton24;
  private UILine uiLine12;
  private UIButton uiButton23;
  private UIButton uiButton22;
  private UIButton uiButton21;
  private UIButton uiButton20;
  private UIButton uiButton19;
  private UIButton uiButton18;
  private UIButton uiButton17;
  private UILine uiLine11;
  private UIButton uiButton16;
  private UIButton uiButton15;
  private UIButton uiButton14;
  private UIButton uiButton13;
  private UIButton uiButton12;
  private UIButton uiButton11;
  private UIButton uiButton10;
  private UIButton uiButton9;
  private UIButton uiButton8;
  private UILine uiLine8;
  private UILine uiLine7;
  private UILine uiLine6;
  private UILine uiLine5;
  private UILine uiLine4;
  private UILine uiLine3;
  private UILine uiLine1;
  private UILine uiLine10;
  private UILine uiLine2;
  private UIButton uiButton7;
  private UIButton uiButton6;
  private UIButton uiButton5;
  private UIButton uiButton4;
  private UIButton uiButton3;
  private UIButton uiButton2;
  private UIButton uiButton1;
  private UIButton uiButton0;
  private UITitlePanel uiTitlePanel3;
  private UITreeView uiTreeView1;
  private UITitlePanel uiTitlePanel2;
  private ListView listView1;
  private ColumnHeader columnHeader42;
  private ColumnHeader columnHeader43;
  private UIRichTextBox uiRichTextBox1;
  private MyButton myButton4;
  private Label label5;
  private QQTextBox qqTextBox51;
  private MyTabControl myTabControl1;
  private TabPage tabPage11;
  private DataGridViewX dataGridViewX4;
  private DataGridViewX dataGridViewX5;
  private DataGridViewX dataGridViewX6;
  private DataGridViewX dataGridViewX7;
  private GroupBoxEx groupBoxEx6;
  private DS标签 dS标签18;
  private ComboBox comboBox2;
  private DS标签 dS标签3;
  private MyButton myButton5;
  private GroupBoxEx groupBoxEx7;
  private DS标签 dS标签22;
  private DS标签 dS标签21;
  private DS标签 dS标签20;
  private DS标签 dS标签19;
  private QQCheckBox qqCheckBox25;
  private QQCheckBox qqCheckBox24;
  private QQCheckBox qqCheckBox23;
  private QQCheckBox qqCheckBox22;
  private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
  private DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
  private DataGridViewComboBoxColumn dataGridViewTextBoxColumn10;
  private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
  private DataGridViewComboBoxColumn dataGridViewComboBoxColumn3;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
  private DataGridViewComboBoxColumn dataGridViewComboBoxColumn4;
  private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
  private DataGridViewComboBoxColumn dataGridViewComboBoxColumn5;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
  private DataGridViewComboBoxColumn dataGridViewComboBoxColumn6;
  private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn5;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
  private DataGridViewComboBoxColumn dataGridViewComboBoxColumn7;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
  private DataGridViewComboBoxColumn dataGridViewComboBoxColumn8;
  private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn6;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
  private DataGridViewComboBoxColumn dataGridViewComboBoxColumn9;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
  private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
  private DataGridViewComboBoxColumn dataGridViewComboBoxColumn10;
  private QQTextBox qqTextBox55;
  private QQTextBox qqTextBox54;
  private QQTextBox qqTextBox53;
  private QQTextBox qqTextBox52;

  [DllImport("User32")]
  public static extern void mouse_event(
    int dwFlags,
    int dx,
    int dy,
    int dwData,
    IntPtr dwExtraInfo);

  [DllImport("User32")]
  public static extern void SetCursorPos(int x, int y);

  [DllImport("User32")]
  public static extern bool GetCursorPos(out Form1.POINT p);

  public Form1()
  {
    this.InitializeComponent();
    this.prog12.InitializeProggress((Control) this.tabPage6, 11, new System.Drawing.Point(29, 520), 550, true, 3);
    this.prog13.InitializeProggress((Control) this.dS容器3, 8, new System.Drawing.Point(168, 66), 243, true, 3);
  }

  protected override CreateParams CreateParams
  {
    get
    {
      CreateParams createParams = base.CreateParams;
      if (!this.DesignMode && this.currentVersion.CompareTo(this.compareToVersion) >= 0)
        createParams.ExStyle |= 65536 /*0x010000*/;
      return createParams;
    }
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    base.OnPaint(e);
    Form1.DrawFromAlphaMainPart((Form) this, e.Graphics);
  }

  public static void DrawFromAlphaMainPart(Form form, Graphics g)
  {
    Color[] colorArray = new Color[6]
    {
      Color.FromArgb(5, Color.White),
      Color.FromArgb(30, Color.White),
      Color.FromArgb(145, Color.White),
      Color.FromArgb(150, Color.White),
      Color.FromArgb(30, Color.White),
      Color.FromArgb(5, Color.White)
    };
    float[] numArray = new float[6]
    {
      0.0f,
      0.04f,
      0.1f,
      0.9f,
      0.97f,
      1f
    };
    ColorBlend colorBlend = new ColorBlend(6)
    {
      Colors = colorArray,
      Positions = numArray
    };
    RectangleF rect = new RectangleF(0.0f, 0.0f, (float) form.Width, (float) form.Height);
    using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, colorArray[0], colorArray[5], LinearGradientMode.Vertical))
      g.FillRectangle((Brush) linearGradientBrush, rect);
  }

  private void SetStyles()
  {
    this.SetStyle(ControlStyles.UserPaint, true);
    this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    this.SetStyle(ControlStyles.ResizeRedraw, true);
    this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    this.UpdateStyles();
  }

  private void setTag(Control cons)
  {
    foreach (Control control in (ArrangedElementCollection) cons.Controls)
    {
      control.Tag = (object) $"{(object) control.Width}:{(object) control.Height}:{(object) control.Left}:{(object) control.Top}:{(object) control.Font.Size}";
      if (control.Controls.Count > 0)
        this.setTag(control);
    }
  }

  private void setControls(float newx, float newy, Control cons)
  {
    foreach (Control control in (ArrangedElementCollection) cons.Controls)
    {
      string[] strArray = control.Tag.ToString().Split(':');
      float num1 = Convert.ToSingle(strArray[0]) * newx;
      control.Width = (int) num1;
      float num2 = Convert.ToSingle(strArray[1]) * newy;
      control.Height = (int) num2;
      float num3 = Convert.ToSingle(strArray[2]) * newx;
      control.Left = (int) num3;
      float num4 = Convert.ToSingle(strArray[3]) * newy;
      control.Top = (int) num4;
      float emSize = Convert.ToSingle(strArray[4]) * newy;
      control.Font = new Font(control.Font.Name, emSize, control.Font.Style, control.Font.Unit);
      if (control.Controls.Count > 0)
        this.setControls(newx, newy, control);
    }
  }

  private void Form1_Resize(object sender, EventArgs e)
  {
  }

  public void Init_Form_configuration()
  {
    string[,] strArray1 = new string[250, 8];
    int index1 = 0;
    try
    {
      string path = Path.Combine(Application.StartupPath, "Config_Files.csv");
      if (File.Exists(path))
      {
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        StreamReader streamReader = new StreamReader((Stream) fileStream, Encoding.Default);
        string str;
        while ((str = streamReader.ReadLine()) != null)
        {
          string[] strArray2 = str.Split(',');
          int length = strArray2.Length;
          for (int index2 = 0; index2 < length; ++index2)
            strArray1[index1, index2] = strArray2[index2];
          ++index1;
        }
        streamReader.Close();
        fileStream.Close();
        if (index1 != 151)
        {
          init_Configuration.Output_Message = "读取配置文件失败！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      else
      {
        init_Configuration.Output_Message = "配置文件丢失！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      }
    }
    catch
    {
      init_Configuration.Output_Message = "读取配置文件失败！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    this.dS数字输入框1.Text = strArray1[0, 0];
    if (strArray1[1, 0] == "增强型校验和")
    {
      this.qqRadioButton1.Checked = true;
      this.qqRadioButton2.Checked = false;
      Form1.CheckSum_Type = "增强型校验和";
    }
    else
    {
      this.qqRadioButton1.Checked = false;
      this.qqRadioButton2.Checked = true;
      Form1.CheckSum_Type = "标准型校验和";
    }
    this.qqTextBox1.Text = strArray1[2, 0];
    this.qqTextBox2.Text = strArray1[2, 1];
    this.qqTextBox3.Text = strArray1[2, 2];
    this.qqTextBox4.Text = strArray1[3, 0];
    this.qqTextBox5.Text = strArray1[3, 1];
    this.qqTextBox6.Text = strArray1[3, 2];
    this.qqTextBox7.Text = strArray1[4, 0];
    this.qqTextBox8.Text = strArray1[4, 1];
    this.qqTextBox9.Text = strArray1[4, 2];
    this.qqTextBox10.Text = strArray1[5, 0];
    if (strArray1[5, 1] == "单帧发送")
    {
      this.qqRadioButton3.Checked = true;
      this.qqRadioButton4.Checked = false;
    }
    else
    {
      this.qqRadioButton3.Checked = false;
      this.qqRadioButton4.Checked = true;
    }
    this.qqTextBox11.Text = strArray1[6, 0];
    this.qqTextBox12.Text = strArray1[6, 1];
    this.qqTextBox13.Text = strArray1[7, 0];
    this.qqTextBox14.Text = strArray1[7, 1];
    this.qqTextBox15.Text = strArray1[8, 0];
    this.qqTextBox16.Text = strArray1[8, 1];
    this.qqTextBox17.Text = strArray1[9, 0];
    if (strArray1[9, 1] == "单帧接收")
    {
      this.qqRadioButton5.Checked = true;
      this.qqRadioButton6.Checked = false;
    }
    else
    {
      this.qqRadioButton5.Checked = false;
      this.qqRadioButton6.Checked = true;
    }
    this.qqTextBox18.Text = strArray1[48 /*0x30*/, 0];
    this.qqTextBox19.Text = strArray1[48 /*0x30*/, 1];
    this.qqTextBox20.Text = strArray1[48 /*0x30*/, 2];
    this.qqTextBox21.Text = strArray1[48 /*0x30*/, 3];
    this.qqTextBox22.Text = strArray1[48 /*0x30*/, 4];
    this.qqTextBox23.Text = strArray1[48 /*0x30*/, 5];
    this.qqTextBox24.Text = strArray1[49, 0];
    this.qqTextBox25.Text = strArray1[49, 1];
    this.qqTextBox26.Text = strArray1[49, 2];
    this.qqTextBox27.Text = strArray1[49, 3];
    this.qqTextBox28.Text = strArray1[49, 4];
    this.qqTextBox29.Text = strArray1[49, 5];
    if (strArray1[50, 0] == "总线监听")
    {
      this.qqRadioButton11.Checked = false;
      this.qqRadioButton12.Checked = true;
    }
    else
    {
      this.qqRadioButton11.Checked = true;
      this.qqRadioButton12.Checked = false;
    }
    if (strArray1[50, 1] == "动态显示")
    {
      this.qqRadioButton13.Checked = true;
      this.qqRadioButton14.Checked = false;
    }
    else
    {
      this.qqRadioButton13.Checked = false;
      this.qqRadioButton14.Checked = true;
    }
    this.qqTextBox31.Text = strArray1[144 /*0x90*/, 0];
    this.qqTextBox32.Text = strArray1[144 /*0x90*/, 1];
    this.qqTextBox33.Text = strArray1[144 /*0x90*/, 2];
    this.qqTextBox34.Text = strArray1[145, 0];
    this.qqTextBox35.Text = strArray1[145, 1];
    this.qqTextBox36.Text = strArray1[145, 2];
    this.qqTextBox37.Text = strArray1[145, 3];
    this.qqTextBox38.Text = strArray1[145, 4];
    this.qqTextBox39.Text = strArray1[146, 0];
    this.qqTextBox40.Text = strArray1[146, 1];
    this.qqTextBox41.Text = strArray1[146, 2];
    this.qqTextBox42.Text = strArray1[146, 3];
    this.qqTextBox43.Text = strArray1[146, 4];
    this.qqTextBox51.Text = strArray1[147, 0];
    Form1.Device_switch_flag = false;
    this.qqRadioButton3.Enabled = false;
    this.qqRadioButton4.Enabled = false;
    this.qqRadioButton5.Enabled = false;
    this.qqRadioButton6.Enabled = false;
    this.imageButton3.Enabled = true;
    this.imageButton4.Enabled = true;
    this.imageButton5.Enabled = false;
    this.imageButton6.Enabled = false;
    this.imageButton7.Enabled = false;
    this.imageButton8.Enabled = false;
    this.dS按钮1.Enabled = false;
    this.dS按钮2.Enabled = false;
    this.dS按钮1.贴图 = Resources.运行9;
    this.dS按钮2.贴图 = Resources.停止9;
    ((Control) this.dataGridViewX2).Enabled = false;
    this.dS按钮3.Enabled = false;
    this.dS按钮4.Enabled = false;
    this.dS按钮3.贴图 = Resources.运行9;
    this.dS按钮4.贴图 = Resources.停止9;
    this.dS按钮5.Enabled = false;
    this.dS按钮6.Enabled = false;
    this.dS按钮5.贴图 = Resources.运行9;
    this.dS按钮6.贴图 = Resources.停止9;
    this.myButton5.Enabled = false;
    this.myButton5.NormalImage = (Image) Resources.down;
    Form1.BOOT_ON_flag = false;
    this.dS按钮9.Enabled = false;
    this.dS按钮10.贴图 = Resources.按钮3;
    this.dS按钮11.贴图 = Resources.灯6;
    this.dS按钮10.Enabled = false;
    this.dS按钮11.Enabled = false;
    this.imageButton15.Enabled = false;
    this.imageButton16.Enabled = true;
    this.imageButton17.Enabled = false;
    this.dS按钮13.Enabled = false;
    this.dS按钮13.贴图 = Resources.运行9;
    this.dS按钮15.Enabled = false;
    this.dS按钮15.贴图 = Resources.运行9;
    this.dS按钮14.Enabled = false;
    this.dS按钮14.贴图 = Resources.停止9;
    this.myButton1.Enabled = false;
    this.dS按钮15.Enabled = false;
    this.dS按钮15.贴图 = Resources.运行9;
    this.dS按钮14.Enabled = false;
    this.dS按钮14.贴图 = Resources.停止9;
    this.myButton3.Enabled = false;
    this.myButton2.Enabled = false;
    this.dS按钮17.Enabled = false;
    this.dS按钮16.Enabled = false;
    this.dS按钮17.贴图 = Resources.运行9;
    this.dS按钮16.贴图 = Resources.停止9;
    this.myButton4.Enabled = false;
    ((DataGridView) this.dataGridViewX1).AllowUserToAddRows = false;
    ((DataGridView) this.dataGridViewX1).AllowUserToAddRows = false;
    ((DataGridView) this.dataGridViewX1).AllowUserToDeleteRows = false;
    ((DataGridView) this.dataGridViewX1).RowHeadersVisible = false;
    ((DataGridView) this.dataGridViewX1).EditMode = DataGridViewEditMode.EditOnEnter;
    ((DataGridView) this.dataGridViewX1).MultiSelect = false;
    ((DataGridView) this.dataGridViewX1).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    ((DataGridView) this.dataGridViewX1).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
    ((DataGridView) this.dataGridViewX1).Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX1).Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX1).Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX1).Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX1).Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX1).Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX1).AllowUserToResizeColumns = false;
    ((DataGridView) this.dataGridViewX1).AllowUserToResizeRows = false;
    for (int index3 = 0; index3 < 20; ++index3)
      ((DataGridView) this.dataGridViewX1).Rows.Add();
    ((DataGridView) this.dataGridViewX1).Rows[0].Cells[0].Value = (object) true;
    for (int index4 = 1; index4 < 20; ++index4)
      ((DataGridView) this.dataGridViewX1).Rows[index4].Cells[0].Value = (object) false;
    for (int index5 = 0; index5 < 20; ++index5)
      ((DataGridView) this.dataGridViewX1).Rows[index5].Cells[1].Value = (object) index5.ToString();
    ((DataGridView) this.dataGridViewX1).Columns[1].ReadOnly = true;
    for (int index6 = 0; index6 < 20; ++index6)
    {
      if (strArray1[index6 + 10, 0] == "发送")
        ((DataGridView) this.dataGridViewX1).Rows[index6].Cells[2].Value = (object) "发送";
      else
        ((DataGridView) this.dataGridViewX1).Rows[index6].Cells[2].Value = (object) "接收";
    }
    for (int index7 = 0; index7 < 20; ++index7)
      ((DataGridView) this.dataGridViewX1).Rows[index7].Cells[3].Value = (object) strArray1[index7 + 10, 1];
    for (int index8 = 0; index8 < 20; ++index8)
      ((DataGridView) this.dataGridViewX1).Rows[index8].Cells[4].Value = (object) strArray1[index8 + 10, 2];
    for (int index9 = 0; index9 < 20; ++index9)
      ((DataGridView) this.dataGridViewX1).Rows[index9].Cells[5].Value = (object) strArray1[index9 + 10, 3];
    for (int index10 = 0; index10 < 20; ++index10)
      ((DataGridView) this.dataGridViewX1).Rows[index10].Cells[6].Value = (object) strArray1[index10 + 10, 4];
    if (strArray1[30, 0] == "动态显示")
    {
      this.qqRadioButton7.Checked = true;
      this.qqRadioButton8.Checked = false;
    }
    else
    {
      this.qqRadioButton7.Checked = false;
      this.qqRadioButton8.Checked = true;
    }
    ((DataGridView) this.dataGridViewX2).AllowUserToAddRows = false;
    ((DataGridView) this.dataGridViewX2).AllowUserToAddRows = false;
    ((DataGridView) this.dataGridViewX2).AllowUserToDeleteRows = false;
    ((DataGridView) this.dataGridViewX2).RowHeadersVisible = false;
    ((DataGridView) this.dataGridViewX2).EditMode = DataGridViewEditMode.EditOnEnter;
    ((DataGridView) this.dataGridViewX2).MultiSelect = false;
    ((DataGridView) this.dataGridViewX2).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    ((DataGridView) this.dataGridViewX2).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
    ((DataGridView) this.dataGridViewX2).Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX2).Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX2).Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX2).Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX2).Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX2).Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX2).AllowUserToResizeColumns = false;
    ((DataGridView) this.dataGridViewX2).AllowUserToResizeRows = false;
    for (int index11 = 0; index11 < 16 /*0x10*/; ++index11)
      ((DataGridView) this.dataGridViewX2).Rows.Add();
    ((DataGridView) this.dataGridViewX2).Rows[0].Cells[0].Value = (object) true;
    for (int index12 = 1; index12 < 16 /*0x10*/; ++index12)
      ((DataGridView) this.dataGridViewX2).Rows[index12].Cells[0].Value = (object) false;
    for (int index13 = 0; index13 < 16 /*0x10*/; ++index13)
      ((DataGridView) this.dataGridViewX2).Rows[index13].Cells[1].Value = (object) index13.ToString();
    ((DataGridView) this.dataGridViewX2).Columns[1].ReadOnly = true;
    for (int index14 = 0; index14 < 16 /*0x10*/; ++index14)
    {
      if (strArray1[index14 + 31 /*0x1F*/, 0] == "发送")
        ((DataGridView) this.dataGridViewX2).Rows[index14].Cells[2].Value = (object) "发送";
      else
        ((DataGridView) this.dataGridViewX2).Rows[index14].Cells[2].Value = (object) "接收";
    }
    for (int index15 = 0; index15 < 16 /*0x10*/; ++index15)
      ((DataGridView) this.dataGridViewX2).Rows[index15].Cells[3].Value = (object) strArray1[index15 + 31 /*0x1F*/, 1];
    for (int index16 = 0; index16 < 16 /*0x10*/; ++index16)
      ((DataGridView) this.dataGridViewX2).Rows[index16].Cells[4].Value = (object) strArray1[index16 + 31 /*0x1F*/, 2];
    for (int index17 = 0; index17 < 16 /*0x10*/; ++index17)
      ((DataGridView) this.dataGridViewX2).Rows[index17].Cells[5].Value = (object) strArray1[index17 + 31 /*0x1F*/, 3];
    for (int index18 = 0; index18 < 16 /*0x10*/; ++index18)
    {
      if (strArray1[index18 + 31 /*0x1F*/, 4] == "增强型校验和")
        ((DataGridView) this.dataGridViewX2).Rows[index18].Cells[6].Value = (object) "增强型校验和";
      else
        ((DataGridView) this.dataGridViewX2).Rows[index18].Cells[6].Value = (object) "标准型校验和";
    }
    if (strArray1[47, 0] == "动态显示")
    {
      this.qqRadioButton9.Checked = true;
      this.qqRadioButton10.Checked = false;
    }
    else
    {
      this.qqRadioButton9.Checked = false;
      this.qqRadioButton10.Checked = true;
    }
    ((DataGridView) this.dataGridViewX3).AllowUserToAddRows = false;
    ((DataGridView) this.dataGridViewX3).AllowUserToAddRows = false;
    ((DataGridView) this.dataGridViewX3).AllowUserToDeleteRows = false;
    ((DataGridView) this.dataGridViewX3).RowHeadersVisible = false;
    ((DataGridView) this.dataGridViewX3).EditMode = DataGridViewEditMode.EditOnEnter;
    ((DataGridView) this.dataGridViewX3).MultiSelect = false;
    ((DataGridView) this.dataGridViewX3).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    ((DataGridView) this.dataGridViewX3).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
    ((DataGridView) this.dataGridViewX3).Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX3).Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX3).Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX3).Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX3).Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX3).Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX3).AllowUserToResizeColumns = false;
    ((DataGridView) this.dataGridViewX3).AllowUserToResizeRows = false;
    for (int index19 = 0; index19 < 16 /*0x10*/; ++index19)
      ((DataGridView) this.dataGridViewX3).Rows.Add();
    for (int index20 = 0; index20 < 16 /*0x10*/; ++index20)
    {
      if (strArray1[index20 + 51, 0].ToString() == "1")
        ((DataGridView) this.dataGridViewX3).Rows[index20].Cells[0].Value = (object) true;
      else
        ((DataGridView) this.dataGridViewX3).Rows[index20].Cells[0].Value = (object) false;
    }
    for (int index21 = 0; index21 < 16 /*0x10*/; ++index21)
      ((DataGridView) this.dataGridViewX3).Rows[index21].Cells[1].Value = (object) index21.ToString();
    ((DataGridView) this.dataGridViewX3).Columns[1].ReadOnly = true;
    ((DataGridView) this.dataGridViewX3).Columns[2].ReadOnly = false;
    for (int index22 = 0; index22 < 16 /*0x10*/; ++index22)
    {
      if (strArray1[index22 + 51, 1].ToString() == "发送")
        ((DataGridView) this.dataGridViewX3).Rows[index22].Cells[2].Value = (object) "发送";
      else
        ((DataGridView) this.dataGridViewX3).Rows[index22].Cells[2].Value = (object) "接收";
    }
    for (int index23 = 0; index23 < 16 /*0x10*/; ++index23)
      ((DataGridView) this.dataGridViewX3).Rows[index23].Cells[3].Value = (object) strArray1[index23 + 51, 2];
    for (int index24 = 0; index24 < 16 /*0x10*/; ++index24)
      ((DataGridView) this.dataGridViewX3).Rows[index24].Cells[4].Value = (object) strArray1[index24 + 51, 3];
    for (int index25 = 0; index25 < 16 /*0x10*/; ++index25)
      ((DataGridView) this.dataGridViewX3).Rows[index25].Cells[5].Value = (object) strArray1[index25 + 51, 4];
    for (int index26 = 0; index26 < 16 /*0x10*/; ++index26)
    {
      if (strArray1[index26 + 51, 5] == "增强型校验和")
        ((DataGridView) this.dataGridViewX3).Rows[index26].Cells[6].Value = (object) "增强型校验和";
      else
        ((DataGridView) this.dataGridViewX3).Rows[index26].Cells[6].Value = (object) "标准型校验和";
    }
    this.dS数字输入框2.Text = strArray1[141, 1];
    this.dS数字输入框3.Text = strArray1[141, 2];
    if (strArray1[141, 0].ToString() == "主机")
      this.comboBox2.Text = "主机";
    else
      this.comboBox2.Text = "从机";
    if (strArray1[142, 0].ToString() == "1")
      this.qqCheckBox22.Checked = true;
    else
      this.qqCheckBox22.Checked = false;
    if (strArray1[142, 1].ToString() == "1")
      this.qqCheckBox23.Checked = true;
    else
      this.qqCheckBox23.Checked = false;
    if (strArray1[142, 2].ToString() == "1")
      this.qqCheckBox24.Checked = true;
    else
      this.qqCheckBox24.Checked = false;
    if (strArray1[142, 3].ToString() == "1")
      this.qqCheckBox25.Checked = true;
    else
      this.qqCheckBox25.Checked = false;
    this.qqTextBox52.Text = strArray1[143, 0].ToString();
    this.qqTextBox53.Text = strArray1[143, 1].ToString();
    this.qqTextBox54.Text = strArray1[143, 2].ToString();
    this.qqTextBox55.Text = strArray1[143, 3].ToString();
    ((DataGridView) this.dataGridViewX4).AllowUserToAddRows = false;
    ((DataGridView) this.dataGridViewX4).AllowUserToAddRows = false;
    ((DataGridView) this.dataGridViewX4).AllowUserToDeleteRows = false;
    ((DataGridView) this.dataGridViewX4).RowHeadersVisible = false;
    ((DataGridView) this.dataGridViewX4).EditMode = DataGridViewEditMode.EditOnEnter;
    ((DataGridView) this.dataGridViewX4).MultiSelect = false;
    ((DataGridView) this.dataGridViewX4).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    ((DataGridView) this.dataGridViewX4).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
    ((DataGridView) this.dataGridViewX4).Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX4).Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX4).Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX4).Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX4).Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX4).Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX4).AllowUserToResizeColumns = false;
    ((DataGridView) this.dataGridViewX4).AllowUserToResizeRows = false;
    for (int index27 = 0; index27 < 18; ++index27)
      ((DataGridView) this.dataGridViewX4).Rows.Add();
    for (int index28 = 0; index28 < 18; ++index28)
    {
      if (strArray1[index28 + 69, 0].ToString() == "1")
        ((DataGridView) this.dataGridViewX4).Rows[index28].Cells[0].Value = (object) true;
      else
        ((DataGridView) this.dataGridViewX4).Rows[index28].Cells[0].Value = (object) false;
    }
    for (int index29 = 0; index29 < 18; ++index29)
      ((DataGridView) this.dataGridViewX4).Rows[index29].Cells[1].Value = (object) index29.ToString();
    ((DataGridView) this.dataGridViewX4).Columns[1].ReadOnly = true;
    ((DataGridView) this.dataGridViewX4).Columns[2].ReadOnly = false;
    for (int index30 = 0; index30 < 18; ++index30)
    {
      if (strArray1[index30 + 69, 1].ToString() == "发送")
        ((DataGridView) this.dataGridViewX4).Rows[index30].Cells[2].Value = (object) "发送";
      else
        ((DataGridView) this.dataGridViewX4).Rows[index30].Cells[2].Value = (object) "接收";
    }
    for (int index31 = 0; index31 < 18; ++index31)
      ((DataGridView) this.dataGridViewX4).Rows[index31].Cells[3].Value = (object) strArray1[index31 + 69, 2];
    for (int index32 = 0; index32 < 18; ++index32)
      ((DataGridView) this.dataGridViewX4).Rows[index32].Cells[4].Value = (object) strArray1[index32 + 69, 3];
    for (int index33 = 0; index33 < 18; ++index33)
      ((DataGridView) this.dataGridViewX4).Rows[index33].Cells[5].Value = (object) strArray1[index33 + 69, 4];
    for (int index34 = 0; index34 < 18; ++index34)
    {
      if (strArray1[index34 + 69, 5] == "增强型校验和")
        ((DataGridView) this.dataGridViewX4).Rows[index34].Cells[6].Value = (object) "增强型校验和";
      else
        ((DataGridView) this.dataGridViewX4).Rows[index34].Cells[6].Value = (object) "标准型校验和";
    }
    ((DataGridView) this.dataGridViewX5).AllowUserToAddRows = false;
    ((DataGridView) this.dataGridViewX5).AllowUserToAddRows = false;
    ((DataGridView) this.dataGridViewX5).AllowUserToDeleteRows = false;
    ((DataGridView) this.dataGridViewX5).RowHeadersVisible = false;
    ((DataGridView) this.dataGridViewX5).EditMode = DataGridViewEditMode.EditOnEnter;
    ((DataGridView) this.dataGridViewX5).MultiSelect = false;
    ((DataGridView) this.dataGridViewX5).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    ((DataGridView) this.dataGridViewX5).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
    ((DataGridView) this.dataGridViewX5).Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX5).Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX5).Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX5).Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX5).Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX5).Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX5).AllowUserToResizeColumns = false;
    ((DataGridView) this.dataGridViewX5).AllowUserToResizeRows = false;
    for (int index35 = 0; index35 < 18; ++index35)
      ((DataGridView) this.dataGridViewX5).Rows.Add();
    for (int index36 = 0; index36 < 18; ++index36)
    {
      if (strArray1[index36 + 87, 0].ToString() == "1")
        ((DataGridView) this.dataGridViewX5).Rows[index36].Cells[0].Value = (object) true;
      else
        ((DataGridView) this.dataGridViewX5).Rows[index36].Cells[0].Value = (object) false;
    }
    for (int index37 = 0; index37 < 18; ++index37)
      ((DataGridView) this.dataGridViewX5).Rows[index37].Cells[1].Value = (object) index37.ToString();
    ((DataGridView) this.dataGridViewX5).Columns[1].ReadOnly = true;
    ((DataGridView) this.dataGridViewX5).Columns[2].ReadOnly = false;
    for (int index38 = 0; index38 < 18; ++index38)
    {
      if (strArray1[index38 + 87, 1].ToString() == "发送")
        ((DataGridView) this.dataGridViewX5).Rows[index38].Cells[2].Value = (object) "发送";
      else
        ((DataGridView) this.dataGridViewX5).Rows[index38].Cells[2].Value = (object) "接收";
    }
    for (int index39 = 0; index39 < 18; ++index39)
      ((DataGridView) this.dataGridViewX5).Rows[index39].Cells[3].Value = (object) strArray1[index39 + 87, 2];
    for (int index40 = 0; index40 < 18; ++index40)
      ((DataGridView) this.dataGridViewX5).Rows[index40].Cells[4].Value = (object) strArray1[index40 + 87, 3];
    for (int index41 = 0; index41 < 18; ++index41)
      ((DataGridView) this.dataGridViewX5).Rows[index41].Cells[5].Value = (object) strArray1[index41 + 87, 4];
    for (int index42 = 0; index42 < 18; ++index42)
    {
      if (strArray1[index42 + 87, 5] == "增强型校验和")
        ((DataGridView) this.dataGridViewX5).Rows[index42].Cells[6].Value = (object) "增强型校验和";
      else
        ((DataGridView) this.dataGridViewX5).Rows[index42].Cells[6].Value = (object) "标准型校验和";
    }
    ((DataGridView) this.dataGridViewX6).AllowUserToAddRows = false;
    ((DataGridView) this.dataGridViewX6).AllowUserToAddRows = false;
    ((DataGridView) this.dataGridViewX6).AllowUserToDeleteRows = false;
    ((DataGridView) this.dataGridViewX6).RowHeadersVisible = false;
    ((DataGridView) this.dataGridViewX6).EditMode = DataGridViewEditMode.EditOnEnter;
    ((DataGridView) this.dataGridViewX6).MultiSelect = false;
    ((DataGridView) this.dataGridViewX6).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    ((DataGridView) this.dataGridViewX6).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
    ((DataGridView) this.dataGridViewX6).Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX6).Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX6).Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX6).Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX6).Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX6).Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX6).AllowUserToResizeColumns = false;
    ((DataGridView) this.dataGridViewX6).AllowUserToResizeRows = false;
    for (int index43 = 0; index43 < 18; ++index43)
      ((DataGridView) this.dataGridViewX6).Rows.Add();
    for (int index44 = 0; index44 < 18; ++index44)
    {
      if (strArray1[index44 + 105, 0].ToString() == "1")
        ((DataGridView) this.dataGridViewX6).Rows[index44].Cells[0].Value = (object) true;
      else
        ((DataGridView) this.dataGridViewX6).Rows[index44].Cells[0].Value = (object) false;
    }
    for (int index45 = 0; index45 < 18; ++index45)
      ((DataGridView) this.dataGridViewX6).Rows[index45].Cells[1].Value = (object) index45.ToString();
    ((DataGridView) this.dataGridViewX6).Columns[1].ReadOnly = true;
    ((DataGridView) this.dataGridViewX6).Columns[2].ReadOnly = false;
    for (int index46 = 0; index46 < 18; ++index46)
    {
      if (strArray1[index46 + 105, 1].ToString() == "发送")
        ((DataGridView) this.dataGridViewX6).Rows[index46].Cells[2].Value = (object) "发送";
      else
        ((DataGridView) this.dataGridViewX6).Rows[index46].Cells[2].Value = (object) "接收";
    }
    for (int index47 = 0; index47 < 18; ++index47)
      ((DataGridView) this.dataGridViewX6).Rows[index47].Cells[3].Value = (object) strArray1[index47 + 105, 2];
    for (int index48 = 0; index48 < 18; ++index48)
      ((DataGridView) this.dataGridViewX6).Rows[index48].Cells[4].Value = (object) strArray1[index48 + 105, 3];
    for (int index49 = 0; index49 < 18; ++index49)
      ((DataGridView) this.dataGridViewX6).Rows[index49].Cells[5].Value = (object) strArray1[index49 + 105, 4];
    for (int index50 = 0; index50 < 18; ++index50)
    {
      if (strArray1[index50 + 105, 5] == "增强型校验和")
        ((DataGridView) this.dataGridViewX6).Rows[index50].Cells[6].Value = (object) "增强型校验和";
      else
        ((DataGridView) this.dataGridViewX6).Rows[index50].Cells[6].Value = (object) "标准型校验和";
    }
    ((DataGridView) this.dataGridViewX7).AllowUserToAddRows = false;
    ((DataGridView) this.dataGridViewX7).AllowUserToAddRows = false;
    ((DataGridView) this.dataGridViewX7).AllowUserToDeleteRows = false;
    ((DataGridView) this.dataGridViewX7).RowHeadersVisible = false;
    ((DataGridView) this.dataGridViewX7).EditMode = DataGridViewEditMode.EditOnEnter;
    ((DataGridView) this.dataGridViewX7).MultiSelect = false;
    ((DataGridView) this.dataGridViewX7).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    ((DataGridView) this.dataGridViewX7).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
    ((DataGridView) this.dataGridViewX7).Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX7).Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX7).Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX7).Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX7).Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX7).Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
    ((DataGridView) this.dataGridViewX7).AllowUserToResizeColumns = false;
    ((DataGridView) this.dataGridViewX7).AllowUserToResizeRows = false;
    for (int index51 = 0; index51 < 18; ++index51)
      ((DataGridView) this.dataGridViewX7).Rows.Add();
    for (int index52 = 0; index52 < 18; ++index52)
    {
      if (strArray1[index52 + 123, 0].ToString() == "1")
        ((DataGridView) this.dataGridViewX7).Rows[index52].Cells[0].Value = (object) true;
      else
        ((DataGridView) this.dataGridViewX7).Rows[index52].Cells[0].Value = (object) false;
    }
    for (int index53 = 0; index53 < 18; ++index53)
      ((DataGridView) this.dataGridViewX7).Rows[index53].Cells[1].Value = (object) index53.ToString();
    ((DataGridView) this.dataGridViewX7).Columns[1].ReadOnly = true;
    ((DataGridView) this.dataGridViewX7).Columns[2].ReadOnly = false;
    for (int index54 = 0; index54 < 18; ++index54)
    {
      if (strArray1[index54 + 123, 1].ToString() == "发送")
        ((DataGridView) this.dataGridViewX7).Rows[index54].Cells[2].Value = (object) "发送";
      else
        ((DataGridView) this.dataGridViewX7).Rows[index54].Cells[2].Value = (object) "接收";
    }
    for (int index55 = 0; index55 < 18; ++index55)
      ((DataGridView) this.dataGridViewX7).Rows[index55].Cells[3].Value = (object) strArray1[index55 + 123, 2];
    for (int index56 = 0; index56 < 18; ++index56)
      ((DataGridView) this.dataGridViewX7).Rows[index56].Cells[4].Value = (object) strArray1[index56 + 123, 3];
    for (int index57 = 0; index57 < 18; ++index57)
      ((DataGridView) this.dataGridViewX7).Rows[index57].Cells[5].Value = (object) strArray1[index57 + 123, 4];
    for (int index58 = 0; index58 < 18; ++index58)
    {
      if (strArray1[index58 + 123, 5] == "增强型校验和")
        ((DataGridView) this.dataGridViewX7).Rows[index58].Cells[6].Value = (object) "增强型校验和";
      else
        ((DataGridView) this.dataGridViewX7).Rows[index58].Cells[6].Value = (object) "标准型校验和";
    }
    this.qqTextBox44.Text = strArray1[148, 0].ToString();
    this.qqTextBox48.Text = strArray1[148, 1].ToString();
    if (strArray1[149, 0].ToString() == "1")
      this.qqCheckBox19.Checked = true;
    else
      this.qqCheckBox19.Checked = false;
    if (strArray1[149, 1].ToString() == "1")
      this.qqCheckBox20.Checked = true;
    else
      this.qqCheckBox20.Checked = false;
    if (strArray1[149, 2].ToString() == "1")
      this.qqCheckBox21.Checked = true;
    else
      this.qqCheckBox21.Checked = false;
    this.qqTextBox45.Text = strArray1[150, 0].ToString();
    this.qqTextBox46.Text = strArray1[150, 1].ToString();
    this.qqTextBox47.Text = strArray1[150, 2].ToString();
    typeof (ListView).InvokeMember("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty, (Binder) null, (object) this.listViewNF1, new object[1]
    {
      (object) false
    });
    typeof (ListView).InvokeMember("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty, (Binder) null, (object) this.listViewNF2, new object[1]
    {
      (object) false
    });
    typeof (ListView).InvokeMember("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty, (Binder) null, (object) this.listViewNF3, new object[1]
    {
      (object) false
    });
    typeof (ListView).InvokeMember("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty, (Binder) null, (object) this.listViewNF4, new object[1]
    {
      (object) false
    });
    typeof (ListView).InvokeMember("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty, (Binder) null, (object) this.listViewNF6, new object[1]
    {
      (object) false
    });
    typeof (ListView).InvokeMember("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty, (Binder) null, (object) this.listViewNF7, new object[1]
    {
      (object) false
    });
  }

  public static void Crc32_InitTable()
  {
    for (uint index1 = 0; index1 < 256U /*0x0100*/; ++index1)
    {
      uint num = index1 << 24;
      for (byte index2 = 8; index2 > (byte) 0; --index2)
      {
        if ((num & 2147483648U /*0x80000000*/) > 0U)
          num = (uint) ((int) num << 1 ^ 79764919);
        else
          num <<= 1;
      }
      Form1.CrcTable[(int) index1] = num;
    }
  }

  public static void Crc32_RemainderInit() => Form1.CrcRemainder = uint.MaxValue;

  public static void Crc_Update(uint size, byte[] data)
  {
    uint num = Form1.CrcRemainder;
    for (uint index1 = 0; index1 < size; ++index1)
    {
      byte index2 = (byte) (num >> 24 ^ (uint) data[(int) index1]);
      num = num << 8 ^ Form1.CrcTable[(int) index2];
    }
    Form1.CrcRemainder = num;
  }

  public static uint GetCrcXORValue() => Form1.CrcRemainder ^ uint.MaxValue;

  private static void Delay(int Delay_value)
  {
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    TimeSpan timeSpan = TimeSpan.FromMilliseconds((double) Delay_value);
    do
      ;
    while (stopwatch.Elapsed < timeSpan);
    stopwatch.Stop();
  }

  public static string DECstr_to_HEXstr(string Dec)
  {
    string heXstr = Convert.ToUInt32(Dec, 10).ToString("X");
    if (heXstr.Length == 1)
      heXstr = "0" + heXstr;
    if (heXstr.Length % 2 != 0)
      heXstr = $"0{heXstr.Substring(0, 1)}{heXstr.Substring(1, heXstr.Length - 1)}";
    return heXstr;
  }

  public static uint HEXstr_to_DEC(string HEX) => Convert.ToUInt32(HEX, 16 /*0x10*/);

  public static byte BIT(byte A, byte B) => (byte) ((int) A >> (int) B & 1);

  public static byte LINCalcParity(byte id)
  {
    byte A = id;
    byte num1 = (byte) (((int) Form1.BIT(A, (byte) 0) ^ (int) Form1.BIT(A, (byte) 1) ^ (int) Form1.BIT(A, (byte) 2) ^ (int) Form1.BIT(A, (byte) 4)) << 6);
    byte num2 = (byte) (~((int) Form1.BIT(A, (byte) 1) ^ (int) Form1.BIT(A, (byte) 3) ^ (int) Form1.BIT(A, (byte) 4) ^ (int) Form1.BIT(A, (byte) 5)) << 7);
    return (byte) ((uint) A | (uint) (byte) ((uint) num1 | (uint) num2));
  }

  public static string LIN_PID_Parity(string HEX_id)
  {
    byte dec = (byte) Form1.HEXstr_to_DEC(HEX_id);
    byte num1 = (byte) (((int) Form1.BIT(dec, (byte) 0) ^ (int) Form1.BIT(dec, (byte) 1) ^ (int) Form1.BIT(dec, (byte) 2) ^ (int) Form1.BIT(dec, (byte) 4)) << 6);
    byte num2 = (byte) (~((int) Form1.BIT(dec, (byte) 1) ^ (int) Form1.BIT(dec, (byte) 3) ^ (int) Form1.BIT(dec, (byte) 4) ^ (int) Form1.BIT(dec, (byte) 5)) << 7);
    return Form1.DECstr_to_HEXstr(((byte) ((uint) dec | (uint) (byte) ((uint) num1 | (uint) num2))).ToString());
  }

  public static void Set_value(byte[,] buffer_Data, byte value, int Length)
  {
    for (int index = 0; index < Length; ++index)
      buffer_Data[index, 0] = value;
  }

  public static byte LINCalcChecksum(
    byte Check_ID,
    byte[] buffer_Data,
    byte LINCalcChecksum_length)
  {
    uint num = 0;
    for (byte index = 0; (int) index < (int) LINCalcChecksum_length; ++index)
    {
      num += (uint) buffer_Data[(int) index];
      if ((num & 65280U) > 0U)
        num = (uint) (((int) num & (int) byte.MaxValue) + 1);
    }
    if (Form1.CheckSum_Type == "增强型校验和")
    {
      num += (uint) Form1.LINCalcParity(Check_ID);
      if ((num & 65280U) > 0U)
        num = (uint) (((int) num & (int) byte.MaxValue) + 1);
    }
    return (byte) (num ^ (uint) byte.MaxValue);
  }

  public static byte Checksum_Control(byte Check_ID, string buffer_str, byte Checksum_length)
  {
    byte[] buffer_Data = new byte[8];
    int startIndex = 0;
    string str = buffer_str;
    for (byte index = 0; (int) index < (int) Checksum_length; ++index)
    {
      buffer_Data[(int) index] = (byte) Form1.HEXstr_to_DEC(str.Substring(startIndex, 2).ToString());
      startIndex += 3;
    }
    return Form1.LINCalcChecksum(Check_ID, buffer_Data, Checksum_length);
  }

  public static byte Check_Sum(byte[] Data, int length)
  {
    int num = 0;
    for (int index = 0; index < length; ++index)
      num += (int) Data[index];
    return (byte) ((~num & (int) byte.MaxValue) + 1);
  }

  public static void Send_Mode_Command(int mode, int Baud_value, int Volume, int off_line_time)
  {
    Form1.Send_Frame_Data[0] = (byte) 17;
    Form1.Send_Frame_Data[1] = (byte) mode;
    Form1.Send_Frame_Data[2] = (byte) ((Baud_value & 65280) >> 8);
    Form1.Send_Frame_Data[3] = (byte) (Baud_value & (int) byte.MaxValue);
    Form1.Send_Frame_Data[4] = (byte) ((Baud_value & 16711680 /*0xFF0000*/) >> 16 /*0x10*/);
    Form1.Send_Frame_Data[5] = (byte) ((off_line_time & 65280) >> 8);
    Form1.Send_Frame_Data[6] = (byte) (off_line_time & (int) byte.MaxValue);
    for (int index = 0; index < 8; ++index)
      Form1.Send_Frame_Data[index + 7] = (byte) 0;
    Form1.Send_Frame_Data[15] = Form1.Check_Sum(Form1.Send_Frame_Data, 15);
  }

  public static void Host_Send_Data(byte Send_ID, string Send_str, int Length, string check_type)
  {
    byte[] buffer_Data = new byte[8];
    Array.Clear((Array) Form1.Send_Frame_Data, 0, Form1.Send_Frame_Data.Length);
    Form1.Send_Frame_Data[0] = (byte) 34;
    Form1.Send_Frame_Data[1] = (byte) 0;
    Form1.Send_Frame_Data[2] = Send_ID;
    Form1.Send_Frame_Data[3] = (byte) 0;
    Form1.Send_Frame_Data[4] = !(check_type == "V1") ? (byte) 2 : (byte) 1;
    Form1.Send_Frame_Data[5] = (byte) Length;
    int startIndex = 0;
    for (int index = 0; index < Length; ++index)
    {
      Form1.Send_Frame_Data[index + 6] = (byte) Form1.HEXstr_to_DEC(Send_str.Substring(startIndex, 2).ToString());
      buffer_Data[index] = Form1.Send_Frame_Data[index + 6];
      startIndex += 3;
    }
    Form1.Send_Frame_Data[14] = Form1.LINCalcChecksum(Send_ID, buffer_Data, (byte) Length);
    Form1.Send_Frame_Data[15] = Form1.Check_Sum(Form1.Send_Frame_Data, 15);
  }

  public static void Read_Slave_Data(byte Read_ID, int Length, string check_type)
  {
    Array.Clear((Array) Form1.Send_Frame_Data, 0, Form1.Send_Frame_Data.Length);
    Form1.Send_Frame_Data[0] = (byte) 51;
    Form1.Send_Frame_Data[1] = (byte) 1;
    Form1.Send_Frame_Data[2] = Read_ID;
    Form1.Send_Frame_Data[3] = (byte) 1;
    Form1.Send_Frame_Data[4] = !(check_type == "V1") ? (byte) 2 : (byte) 1;
    Form1.Send_Frame_Data[5] = (byte) Length;
    Form1.Send_Frame_Data[15] = Form1.Check_Sum(Form1.Send_Frame_Data, 15);
  }

  public static void Slave_Update_Data(
    byte Send_ID,
    int channel,
    string Send_str,
    int Length,
    string check_type)
  {
    byte[] buffer_Data = new byte[8];
    Array.Clear((Array) Form1.Send_Frame_Data, 0, Form1.Send_Frame_Data.Length);
    Form1.Send_Frame_Data[0] = (byte) 85;
    Form1.Send_Frame_Data[1] = (byte) channel;
    Form1.Send_Frame_Data[2] = Send_ID;
    Form1.Send_Frame_Data[3] = (byte) 0;
    Form1.Send_Frame_Data[4] = !(check_type == "V1") ? (byte) 2 : (byte) 1;
    Form1.Send_Frame_Data[5] = (byte) Length;
    int startIndex = 0;
    for (int index = 0; index < Length; ++index)
    {
      Form1.Send_Frame_Data[index + 6] = (byte) Form1.HEXstr_to_DEC(Send_str.Substring(startIndex, 2).ToString());
      buffer_Data[index] = Form1.Send_Frame_Data[index + 6];
      startIndex += 3;
    }
    Form1.Send_Frame_Data[14] = Form1.LINCalcChecksum(Send_ID, buffer_Data, (byte) Length);
    Form1.Send_Frame_Data[15] = Form1.Check_Sum(Form1.Send_Frame_Data, 15);
  }

  public static void Single_Set_Send_Data(
    int number,
    byte Send_ID,
    string Send_str,
    int Length,
    string check_type)
  {
    byte[] buffer_Data = new byte[8];
    byte[] Data = new byte[16 /*0x10*/];
    Form1.Single_Send_Data[number, 0] = (byte) 34;
    Form1.Single_Send_Data[number, 1] = (byte) 0;
    Form1.Single_Send_Data[number, 2] = Send_ID;
    Form1.Single_Send_Data[number, 3] = (byte) 0;
    Form1.Single_Send_Data[number, 4] = !(check_type == "V1") ? (byte) 2 : (byte) 1;
    Form1.Single_Send_Data[number, 5] = (byte) Length;
    int startIndex = 0;
    for (int index = 0; index < Length; ++index)
    {
      Form1.Single_Send_Data[number, index + 6] = (byte) Form1.HEXstr_to_DEC(Send_str.Substring(startIndex, 2).ToString());
      buffer_Data[index] = Form1.Single_Send_Data[number, index + 6];
      startIndex += 3;
    }
    Form1.Single_Send_Data[number, 14] = Form1.LINCalcChecksum(Send_ID, buffer_Data, (byte) Length);
    for (int index = 0; index < 15; ++index)
      Data[index] = Form1.Single_Send_Data[number, index];
    Form1.Single_Send_Data[number, 15] = Form1.Check_Sum(Data, 15);
  }

  public static void Single_Set_Read_Data(int number, byte Send_ID, int Length, string check_type)
  {
    byte[] Data = new byte[16 /*0x10*/];
    Form1.Single_Send_Data[number, 0] = (byte) 51;
    Form1.Single_Send_Data[number, 1] = (byte) 1;
    Form1.Single_Send_Data[number, 2] = Send_ID;
    Form1.Single_Send_Data[number, 3] = (byte) 1;
    Form1.Single_Send_Data[number, 4] = !(check_type == "V1") ? (byte) 2 : (byte) 1;
    Form1.Single_Send_Data[number, 5] = (byte) Length;
    for (int index = 0; index < 15; ++index)
      Data[index] = Form1.Single_Send_Data[number, index];
    Form1.Single_Send_Data[number, 15] = Form1.Check_Sum(Data, 15);
  }

  private void Form1_Load(object sender, EventArgs e)
  {
    this.X = (float) this.Width;
    this.Y = (float) this.Height;
    this.setTag((Control) this);
    this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
    this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
    this.Init_Form_configuration();
    Form1.EN_ClearMemory_flag = true;
    this.ClearMemory_Thread();
  }

  private void Form1_FormClosing(object sender, FormClosingEventArgs e)
  {
    string str1 = "";
    string[] strArray = new string[(int) byte.MaxValue];
    int index1 = 0;
    int num1 = (int) init_Configuration.Close_Interface.ShowDialog();
    while (true)
    {
      if (!init_Configuration.CloseForm_Main_flag && init_Configuration.CloseForm_Main_flag)
        Application.DoEvents();
      else
        break;
    }
    if (init_Configuration.CloseForm_Main_flag)
    {
      if (this.USB_Receive_Thread != null && this.USB_Receive_Thread.ThreadState != System.Threading.ThreadState.Stopped && this.USB_Receive_Thread.ThreadState != System.Threading.ThreadState.Aborted)
        this.USB_Receive_Thread.Abort();
      if (this.Timing_Send_Thread != null && this.Timing_Send_Thread.ThreadState != System.Threading.ThreadState.Stopped && this.Timing_Send_Thread.ThreadState != System.Threading.ThreadState.Aborted)
        this.Timing_Send_Thread.Abort();
      if (this.Timing_Receive_Thread != null && this.Timing_Receive_Thread.ThreadState != System.Threading.ThreadState.Stopped && this.Timing_Receive_Thread.ThreadState != System.Threading.ThreadState.Aborted)
        this.Timing_Receive_Thread.Abort();
      if (this.BOOT_Thread != null && this.BOOT_Thread.ThreadState != System.Threading.ThreadState.Stopped && this.BOOT_Thread.ThreadState != System.Threading.ThreadState.Aborted)
        this.BOOT_Thread.Abort();
      if (Form1.Off_line_Thread != null && Form1.Off_line_Thread.ThreadState != System.Threading.ThreadState.Stopped && Form1.Off_line_Thread.ThreadState != System.Threading.ThreadState.Aborted)
        Form1.Off_line_Thread.Abort();
      string path = Path.Combine(Application.StartupPath, "Config_Files.csv");
      if (File.Exists(path))
      {
        StreamWriter streamWriter = new StreamWriter((Stream) new FileStream(path, FileMode.Create, FileAccess.Write), Encoding.UTF8);
        try
        {
          str1 = "";
          string text1 = this.dS数字输入框1.Text;
          strArray[index1] = text1;
          int index2 = index1 + 1;
          str1 = "";
          string str2 = !this.qqRadioButton1.Checked ? "标准型校验和" : "增强型校验和";
          strArray[index2] = str2;
          int index3 = index2 + 1;
          str1 = "";
          string str3 = $"{this.qqTextBox1.Text},{this.qqTextBox2.Text},{this.qqTextBox3.Text}";
          strArray[index3] = str3;
          int index4 = index3 + 1;
          str1 = "";
          string str4 = $"{this.qqTextBox4.Text},{this.qqTextBox5.Text},{this.qqTextBox6.Text}";
          strArray[index4] = str4;
          int index5 = index4 + 1;
          str1 = "";
          string str5 = $"{this.qqTextBox7.Text},{this.qqTextBox8.Text},{this.qqTextBox9.Text}";
          strArray[index5] = str5;
          int index6 = index5 + 1;
          int index7;
          if (this.qqRadioButton3.Checked)
          {
            str1 = "";
            string str6 = this.qqTextBox10.Text + ",单帧发送";
            strArray[index6] = str6;
            index7 = index6 + 1;
          }
          else
          {
            str1 = "";
            string str7 = this.qqTextBox10.Text + ",多帧发送";
            strArray[index6] = str7;
            index7 = index6 + 1;
          }
          str1 = "";
          string str8 = $"{this.qqTextBox11.Text},{this.qqTextBox12.Text}";
          strArray[index7] = str8;
          int index8 = index7 + 1;
          str1 = "";
          string str9 = $"{this.qqTextBox13.Text},{this.qqTextBox14.Text}";
          strArray[index8] = str9;
          int index9 = index8 + 1;
          str1 = "";
          string str10 = $"{this.qqTextBox15.Text},{this.qqTextBox16.Text}";
          strArray[index9] = str10;
          int index10 = index9 + 1;
          int index11;
          if (this.qqRadioButton5.Checked)
          {
            str1 = "";
            string str11 = this.qqTextBox17.Text + ",单帧接收";
            strArray[index10] = str11;
            index11 = index10 + 1;
          }
          else
          {
            str1 = "";
            string str12 = this.qqTextBox17.Text + ",多帧接收";
            strArray[index10] = str12;
            index11 = index10 + 1;
          }
          for (int index12 = 0; index12 < 20; ++index12)
          {
            if (((DataGridView) this.dataGridViewX1).Rows[index12].Cells[2].Value == null)
              ((DataGridView) this.dataGridViewX1).Rows[index12].Cells[2].Value = (object) "";
            if (((DataGridView) this.dataGridViewX1).Rows[index12].Cells[3].Value == null)
              ((DataGridView) this.dataGridViewX1).Rows[index12].Cells[3].Value = (object) "";
            if (((DataGridView) this.dataGridViewX1).Rows[index12].Cells[4].Value == null)
              ((DataGridView) this.dataGridViewX1).Rows[index12].Cells[4].Value = (object) "";
            if (((DataGridView) this.dataGridViewX1).Rows[index12].Cells[5].Value == null)
              ((DataGridView) this.dataGridViewX1).Rows[index12].Cells[5].Value = (object) "";
            if (((DataGridView) this.dataGridViewX1).Rows[index12].Cells[6].Value == null)
              ((DataGridView) this.dataGridViewX1).Rows[index12].Cells[6].Value = (object) "";
          }
          for (int index13 = 0; index13 < 20; ++index13)
          {
            str1 = "";
            string str13 = $"{((DataGridView) this.dataGridViewX1).Rows[index13].Cells[2].Value.ToString()},{((DataGridView) this.dataGridViewX1).Rows[index13].Cells[3].Value.ToString()},{((DataGridView) this.dataGridViewX1).Rows[index13].Cells[4].Value.ToString()},{((DataGridView) this.dataGridViewX1).Rows[index13].Cells[5].Value.ToString()},{((DataGridView) this.dataGridViewX1).Rows[index13].Cells[6].Value.ToString()}";
            strArray[index11] = str13;
            ++index11;
          }
          int index14;
          if (this.qqRadioButton7.Checked)
          {
            str1 = "";
            string str14 = "动态显示";
            strArray[index11] = str14;
            index14 = index11 + 1;
          }
          else
          {
            str1 = "";
            string str15 = "静态显示";
            strArray[index11] = str15;
            index14 = index11 + 1;
          }
          for (int index15 = 0; index15 < 16 /*0x10*/; ++index15)
          {
            if (((DataGridView) this.dataGridViewX2).Rows[index15].Cells[2].Value == null)
              ((DataGridView) this.dataGridViewX2).Rows[index15].Cells[2].Value = (object) "";
            if (((DataGridView) this.dataGridViewX2).Rows[index15].Cells[3].Value == null)
              ((DataGridView) this.dataGridViewX2).Rows[index15].Cells[3].Value = (object) "";
            if (((DataGridView) this.dataGridViewX2).Rows[index15].Cells[4].Value == null)
              ((DataGridView) this.dataGridViewX2).Rows[index15].Cells[4].Value = (object) "";
            if (((DataGridView) this.dataGridViewX2).Rows[index15].Cells[5].Value == null)
              ((DataGridView) this.dataGridViewX2).Rows[index15].Cells[5].Value = (object) "";
            if (((DataGridView) this.dataGridViewX2).Rows[index15].Cells[6].Value == null)
              ((DataGridView) this.dataGridViewX2).Rows[index15].Cells[6].Value = (object) "";
          }
          for (int index16 = 0; index16 < 16 /*0x10*/; ++index16)
          {
            str1 = "";
            string str16 = $"{((DataGridView) this.dataGridViewX2).Rows[index16].Cells[2].Value.ToString()},{((DataGridView) this.dataGridViewX2).Rows[index16].Cells[3].Value.ToString()},{((DataGridView) this.dataGridViewX2).Rows[index16].Cells[4].Value.ToString()},{((DataGridView) this.dataGridViewX2).Rows[index16].Cells[5].Value.ToString()},{((DataGridView) this.dataGridViewX2).Rows[index16].Cells[6].Value.ToString()}";
            strArray[index14] = str16;
            ++index14;
          }
          int index17;
          if (this.qqRadioButton9.Checked)
          {
            str1 = "";
            string str17 = "动态显示";
            strArray[index14] = str17;
            index17 = index14 + 1;
          }
          else
          {
            str1 = "";
            string str18 = "静态显示";
            strArray[index14] = str18;
            index17 = index14 + 1;
          }
          str1 = "";
          string str19 = $"{this.qqTextBox18.Text},{this.qqTextBox19.Text},{this.qqTextBox20.Text},{this.qqTextBox21.Text},{this.qqTextBox22.Text},{this.qqTextBox23.Text}";
          strArray[index17] = str19;
          int index18 = index17 + 1;
          str1 = "";
          string str20 = $"{this.qqTextBox24.Text},{this.qqTextBox25.Text},{this.qqTextBox26.Text},{this.qqTextBox27.Text},{this.qqTextBox28.Text},{this.qqTextBox29.Text}";
          strArray[index18] = str20;
          int index19 = index18 + 1;
          string str21;
          if (this.qqRadioButton11.Checked)
          {
            str1 = "";
            str21 = "固定ID,";
          }
          else
          {
            str1 = "";
            str21 = "总线监听,";
          }
          string str22 = !this.qqRadioButton13.Checked ? str21 + "静态显示" : str21 + "动态显示";
          strArray[index19] = str22;
          int index20 = index19 + 1;
          for (int index21 = 0; index21 < 16 /*0x10*/; ++index21)
          {
            if (((DataGridView) this.dataGridViewX3).Rows[index21].Cells[2].Value == null)
              ((DataGridView) this.dataGridViewX3).Rows[index21].Cells[2].Value = (object) "";
            if (((DataGridView) this.dataGridViewX3).Rows[index21].Cells[3].Value == null)
              ((DataGridView) this.dataGridViewX3).Rows[index21].Cells[3].Value = (object) "";
            if (((DataGridView) this.dataGridViewX3).Rows[index21].Cells[4].Value == null)
              ((DataGridView) this.dataGridViewX3).Rows[index21].Cells[4].Value = (object) "";
            if (((DataGridView) this.dataGridViewX3).Rows[index21].Cells[5].Value == null)
              ((DataGridView) this.dataGridViewX3).Rows[index21].Cells[5].Value = (object) "";
            if (((DataGridView) this.dataGridViewX3).Rows[index21].Cells[6].Value == null)
              ((DataGridView) this.dataGridViewX3).Rows[index21].Cells[6].Value = (object) "";
          }
          for (int index22 = 0; index22 < 16 /*0x10*/; ++index22)
          {
            str1 = "";
            string str23;
            if (((DataGridView) this.dataGridViewX3).Rows[index22].Cells[0].Value.ToString() == "True")
              str23 = $"1,{((DataGridView) this.dataGridViewX3).Rows[index22].Cells[2].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[index22].Cells[3].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[index22].Cells[4].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[index22].Cells[5].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[index22].Cells[6].Value.ToString()}";
            else
              str23 = $"0,{((DataGridView) this.dataGridViewX3).Rows[index22].Cells[2].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[index22].Cells[3].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[index22].Cells[4].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[index22].Cells[5].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[index22].Cells[6].Value.ToString()}";
            strArray[index20] = str23;
            ++index20;
          }
          str1 = "";
          string str24;
          if (((DataGridView) this.dataGridViewX3).Rows[15].Cells[0].Value.ToString() == "True")
            str24 = $"1,{((DataGridView) this.dataGridViewX3).Rows[15].Cells[2].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[15].Cells[3].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[15].Cells[4].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[15].Cells[5].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[15].Cells[6].Value.ToString()}";
          else
            str24 = $"0,{((DataGridView) this.dataGridViewX3).Rows[15].Cells[2].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[15].Cells[3].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[15].Cells[4].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[15].Cells[5].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[15].Cells[6].Value.ToString()}";
          strArray[index20] = str24;
          int index23 = index20 + 1;
          str1 = "";
          string str25;
          if (((DataGridView) this.dataGridViewX3).Rows[15].Cells[0].Value.ToString() == "True")
            str25 = $"1,{((DataGridView) this.dataGridViewX3).Rows[15].Cells[2].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[15].Cells[3].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[15].Cells[4].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[15].Cells[5].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[15].Cells[6].Value.ToString()}";
          else
            str25 = $"0,{((DataGridView) this.dataGridViewX3).Rows[15].Cells[2].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[15].Cells[3].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[15].Cells[4].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[15].Cells[5].Value.ToString()},{((DataGridView) this.dataGridViewX3).Rows[15].Cells[6].Value.ToString()}";
          strArray[index23] = str25;
          int index24 = index23 + 1;
          for (int index25 = 0; index25 < 18; ++index25)
          {
            if (((DataGridView) this.dataGridViewX4).Rows[index25].Cells[2].Value == null)
              ((DataGridView) this.dataGridViewX4).Rows[index25].Cells[2].Value = (object) "";
            if (((DataGridView) this.dataGridViewX4).Rows[index25].Cells[3].Value == null)
              ((DataGridView) this.dataGridViewX4).Rows[index25].Cells[3].Value = (object) "";
            if (((DataGridView) this.dataGridViewX4).Rows[index25].Cells[4].Value == null)
              ((DataGridView) this.dataGridViewX4).Rows[index25].Cells[4].Value = (object) "";
            if (((DataGridView) this.dataGridViewX4).Rows[index25].Cells[5].Value == null)
              ((DataGridView) this.dataGridViewX4).Rows[index25].Cells[5].Value = (object) "";
            if (((DataGridView) this.dataGridViewX4).Rows[index25].Cells[6].Value == null)
              ((DataGridView) this.dataGridViewX4).Rows[index25].Cells[6].Value = (object) "";
          }
          for (int index26 = 0; index26 < 18; ++index26)
          {
            str1 = "";
            string str26;
            if (((DataGridView) this.dataGridViewX4).Rows[index26].Cells[0].Value.ToString() == "True")
              str26 = $"1,{((DataGridView) this.dataGridViewX4).Rows[index26].Cells[2].Value.ToString()},{((DataGridView) this.dataGridViewX4).Rows[index26].Cells[3].Value.ToString()},{((DataGridView) this.dataGridViewX4).Rows[index26].Cells[4].Value.ToString()},{((DataGridView) this.dataGridViewX4).Rows[index26].Cells[5].Value.ToString()},{((DataGridView) this.dataGridViewX4).Rows[index26].Cells[6].Value.ToString()}";
            else
              str26 = $"0,{((DataGridView) this.dataGridViewX4).Rows[index26].Cells[2].Value.ToString()},{((DataGridView) this.dataGridViewX4).Rows[index26].Cells[3].Value.ToString()},{((DataGridView) this.dataGridViewX4).Rows[index26].Cells[4].Value.ToString()},{((DataGridView) this.dataGridViewX4).Rows[index26].Cells[5].Value.ToString()},{((DataGridView) this.dataGridViewX4).Rows[index26].Cells[6].Value.ToString()}";
            strArray[index24] = str26;
            ++index24;
          }
          for (int index27 = 0; index27 < 18; ++index27)
          {
            if (((DataGridView) this.dataGridViewX5).Rows[index27].Cells[2].Value == null)
              ((DataGridView) this.dataGridViewX5).Rows[index27].Cells[2].Value = (object) "";
            if (((DataGridView) this.dataGridViewX5).Rows[index27].Cells[3].Value == null)
              ((DataGridView) this.dataGridViewX5).Rows[index27].Cells[3].Value = (object) "";
            if (((DataGridView) this.dataGridViewX5).Rows[index27].Cells[4].Value == null)
              ((DataGridView) this.dataGridViewX5).Rows[index27].Cells[4].Value = (object) "";
            if (((DataGridView) this.dataGridViewX5).Rows[index27].Cells[5].Value == null)
              ((DataGridView) this.dataGridViewX5).Rows[index27].Cells[5].Value = (object) "";
            if (((DataGridView) this.dataGridViewX5).Rows[index27].Cells[6].Value == null)
              ((DataGridView) this.dataGridViewX5).Rows[index27].Cells[6].Value = (object) "";
          }
          for (int index28 = 0; index28 < 18; ++index28)
          {
            str1 = "";
            string str27;
            if (((DataGridView) this.dataGridViewX5).Rows[index28].Cells[0].Value.ToString() == "True")
              str27 = $"1,{((DataGridView) this.dataGridViewX5).Rows[index28].Cells[2].Value.ToString()},{((DataGridView) this.dataGridViewX5).Rows[index28].Cells[3].Value.ToString()},{((DataGridView) this.dataGridViewX5).Rows[index28].Cells[4].Value.ToString()},{((DataGridView) this.dataGridViewX5).Rows[index28].Cells[5].Value.ToString()},{((DataGridView) this.dataGridViewX5).Rows[index28].Cells[6].Value.ToString()}";
            else
              str27 = $"0,{((DataGridView) this.dataGridViewX5).Rows[index28].Cells[2].Value.ToString()},{((DataGridView) this.dataGridViewX5).Rows[index28].Cells[3].Value.ToString()},{((DataGridView) this.dataGridViewX5).Rows[index28].Cells[4].Value.ToString()},{((DataGridView) this.dataGridViewX5).Rows[index28].Cells[5].Value.ToString()},{((DataGridView) this.dataGridViewX5).Rows[index28].Cells[6].Value.ToString()}";
            strArray[index24] = str27;
            ++index24;
          }
          for (int index29 = 0; index29 < 18; ++index29)
          {
            if (((DataGridView) this.dataGridViewX6).Rows[index29].Cells[2].Value == null)
              ((DataGridView) this.dataGridViewX6).Rows[index29].Cells[2].Value = (object) "";
            if (((DataGridView) this.dataGridViewX6).Rows[index29].Cells[3].Value == null)
              ((DataGridView) this.dataGridViewX6).Rows[index29].Cells[3].Value = (object) "";
            if (((DataGridView) this.dataGridViewX6).Rows[index29].Cells[4].Value == null)
              ((DataGridView) this.dataGridViewX6).Rows[index29].Cells[4].Value = (object) "";
            if (((DataGridView) this.dataGridViewX6).Rows[index29].Cells[5].Value == null)
              ((DataGridView) this.dataGridViewX6).Rows[index29].Cells[5].Value = (object) "";
            if (((DataGridView) this.dataGridViewX6).Rows[index29].Cells[6].Value == null)
              ((DataGridView) this.dataGridViewX6).Rows[index29].Cells[6].Value = (object) "";
          }
          for (int index30 = 0; index30 < 18; ++index30)
          {
            str1 = "";
            string str28;
            if (((DataGridView) this.dataGridViewX6).Rows[index30].Cells[0].Value.ToString() == "True")
              str28 = $"1,{((DataGridView) this.dataGridViewX6).Rows[index30].Cells[2].Value.ToString()},{((DataGridView) this.dataGridViewX6).Rows[index30].Cells[3].Value.ToString()},{((DataGridView) this.dataGridViewX6).Rows[index30].Cells[4].Value.ToString()},{((DataGridView) this.dataGridViewX6).Rows[index30].Cells[5].Value.ToString()},{((DataGridView) this.dataGridViewX6).Rows[index30].Cells[6].Value.ToString()}";
            else
              str28 = $"0,{((DataGridView) this.dataGridViewX6).Rows[index30].Cells[2].Value.ToString()},{((DataGridView) this.dataGridViewX6).Rows[index30].Cells[3].Value.ToString()},{((DataGridView) this.dataGridViewX6).Rows[index30].Cells[4].Value.ToString()},{((DataGridView) this.dataGridViewX6).Rows[index30].Cells[5].Value.ToString()},{((DataGridView) this.dataGridViewX6).Rows[index30].Cells[6].Value.ToString()}";
            strArray[index24] = str28;
            ++index24;
          }
          for (int index31 = 0; index31 < 18; ++index31)
          {
            if (((DataGridView) this.dataGridViewX7).Rows[index31].Cells[2].Value == null)
              ((DataGridView) this.dataGridViewX7).Rows[index31].Cells[2].Value = (object) "";
            if (((DataGridView) this.dataGridViewX7).Rows[index31].Cells[3].Value == null)
              ((DataGridView) this.dataGridViewX7).Rows[index31].Cells[3].Value = (object) "";
            if (((DataGridView) this.dataGridViewX7).Rows[index31].Cells[4].Value == null)
              ((DataGridView) this.dataGridViewX7).Rows[index31].Cells[4].Value = (object) "";
            if (((DataGridView) this.dataGridViewX7).Rows[index31].Cells[5].Value == null)
              ((DataGridView) this.dataGridViewX7).Rows[index31].Cells[5].Value = (object) "";
            if (((DataGridView) this.dataGridViewX7).Rows[index31].Cells[6].Value == null)
              ((DataGridView) this.dataGridViewX7).Rows[index31].Cells[6].Value = (object) "";
          }
          for (int index32 = 0; index32 < 18; ++index32)
          {
            str1 = "";
            string str29;
            if (((DataGridView) this.dataGridViewX7).Rows[index32].Cells[0].Value.ToString() == "True")
              str29 = $"1,{((DataGridView) this.dataGridViewX7).Rows[index32].Cells[2].Value.ToString()},{((DataGridView) this.dataGridViewX7).Rows[index32].Cells[3].Value.ToString()},{((DataGridView) this.dataGridViewX7).Rows[index32].Cells[4].Value.ToString()},{((DataGridView) this.dataGridViewX7).Rows[index32].Cells[5].Value.ToString()},{((DataGridView) this.dataGridViewX7).Rows[index32].Cells[6].Value.ToString()}";
            else
              str29 = $"0,{((DataGridView) this.dataGridViewX7).Rows[index32].Cells[2].Value.ToString()},{((DataGridView) this.dataGridViewX7).Rows[index32].Cells[3].Value.ToString()},{((DataGridView) this.dataGridViewX7).Rows[index32].Cells[4].Value.ToString()},{((DataGridView) this.dataGridViewX7).Rows[index32].Cells[5].Value.ToString()},{((DataGridView) this.dataGridViewX7).Rows[index32].Cells[6].Value.ToString()}";
            strArray[index24] = str29;
            ++index24;
          }
          str1 = "";
          string str30 = $"{this.comboBox2.Text},{this.dS数字输入框2.Text},{this.dS数字输入框3.Text}";
          strArray[index24] = str30;
          int index33 = index24 + 1;
          string str31 = "";
          string str32 = !this.qqCheckBox22.Checked ? str31 + "0," : str31 + "1,";
          string str33 = !this.qqCheckBox23.Checked ? str32 + "0," : str32 + "1,";
          string str34 = !this.qqCheckBox24.Checked ? str33 + "0," : str33 + "1,";
          string str35 = !this.qqCheckBox25.Checked ? str34 + "0" : str34 + "1";
          strArray[index33] = str35;
          int index34 = index33 + 1;
          str1 = "";
          string str36 = $"{this.qqTextBox52.Text},{this.qqTextBox53.Text},{this.qqTextBox54.Text},{this.qqTextBox55.Text}";
          strArray[index34] = str36;
          int index35 = index34 + 1;
          str1 = "";
          string str37 = $"{this.qqTextBox31.Text},{this.qqTextBox32.Text},{this.qqTextBox33.Text}";
          strArray[index35] = str37;
          int index36 = index35 + 1;
          str1 = "";
          string str38 = $"{this.qqTextBox34.Text},{this.qqTextBox35.Text},{this.qqTextBox36.Text},{this.qqTextBox37.Text},{this.qqTextBox38.Text}";
          strArray[index36] = str38;
          int index37 = index36 + 1;
          str1 = "";
          string str39 = $"{this.qqTextBox39.Text},{this.qqTextBox40.Text},{this.qqTextBox41.Text},{this.qqTextBox42.Text},{this.qqTextBox43.Text}";
          strArray[index37] = str39;
          int index38 = index37 + 1;
          str1 = "";
          string text2 = this.qqTextBox51.Text;
          strArray[index38] = text2;
          int index39 = index38 + 1;
          str1 = "";
          string str40 = $"{this.qqTextBox44.Text},{this.qqTextBox48.Text}";
          strArray[index39] = str40;
          int index40 = index39 + 1;
          string str41 = "";
          string str42 = !this.qqCheckBox19.Checked ? str41 + "0," : str41 + "1,";
          string str43 = !this.qqCheckBox20.Checked ? str42 + "0," : str42 + "1,";
          string str44 = !this.qqCheckBox21.Checked ? str43 + "0" : str43 + "1";
          strArray[index40] = str44;
          int index41 = index40 + 1;
          str1 = "";
          string str45 = $"{this.qqTextBox45.Text},{this.qqTextBox46.Text},{this.qqTextBox47.Text}";
          strArray[index41] = str45;
          int num2 = index41 + 1;
          for (int index42 = 0; index42 < num2; ++index42)
            streamWriter.WriteLine(strArray[index42]);
        }
        catch
        {
          init_Configuration.Output_Message = "保存配置文件失败！";
          int num3 = (int) init_Configuration.PDF_Interface.ShowDialog();
        }
        streamWriter.Close();
      }
      else
      {
        init_Configuration.Output_Message = "配置文件丢失！";
        int num4 = (int) init_Configuration.PDF_Interface.ShowDialog();
      }
      init_Configuration.CloseForm_Main_flag = false;
      e.Cancel = false;
    }
    else
    {
      if (init_Configuration.CloseForm_Main_flag)
        return;
      e.Cancel = true;
    }
  }

  private void myToolBar1_SelectedItemChanged(object sender, EventArgs e)
  {
    string text = this.myToolBar1.SelectedItem.Text;
    // ISSUE: reference to a compiler-generated method
    switch (text)
    {
      case "开发者选项":
        this.tabControl1.SelectedTab = this.tabPage7;
        break;
      case "单机模式":
        this.tabControl1.SelectedTab = this.tabPage1;
        break;
      case "从机模式":
        this.tabControl1.SelectedTab = this.tabPage3;
        break;
      case "LDF解析":
        this.tabControl1.SelectedTab = this.tabPage10;
        break;
      case "监听模式":
        this.tabControl1.SelectedTab = this.tabPage4;
        break;
      case "关于":
        this.tabControl1.SelectedTab = this.tabPage8;
        break;
      case "Boot升级":
        this.tabControl1.SelectedTab = this.tabPage6;
        break;
      case "离线模式":
        this.tabControl1.SelectedTab = this.tabPage5;
        break;
      case "波特率识别":
        this.tabControl1.SelectedTab = this.tabPage9;
        break;
      case "列表模式":
        this.tabControl1.SelectedTab = this.tabPage2;
        break;
    }
  }

  private void imageButton1_Click(object sender, EventArgs e)
  {
    string[] strArray = new string[(int) byte.MaxValue];
    int index1 = 0;
    this.imageButton1.Text = "正在搜索";
    ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * From Win32_PnPEntity");
    try
    {
      foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
      {
        object propertyValue1 = managementBaseObject.GetPropertyValue("DeviceID");
        object propertyValue2 = managementBaseObject.GetPropertyValue("Description");
        if (propertyValue2 != null && (propertyValue2.ToString().Equals("LINTest-MI") || propertyValue2.ToString().Equals("USB Serial Device") || propertyValue2.ToString().Equals("USB 串行设备") || propertyValue2.ToString().Equals("USB 序列装置")))
        {
          managementBaseObject.GetPropertyValue("Manufacturer");
          if (propertyValue1.ToString().Substring(4, 17) == "VID_1A86&PID_FE0C")
          {
            object propertyValue3 = managementBaseObject.GetPropertyValue("Name");
            if (propertyValue2.ToString().Equals("USB 串行设备"))
            {
              strArray[index1] = propertyValue3.ToString().Substring(10, propertyValue3.ToString().Length - 11);
              ++index1;
            }
            else if (propertyValue2.ToString().Equals("LINTest-MI"))
            {
              strArray[index1] = propertyValue3.ToString().Substring(12, propertyValue3.ToString().Length - 13);
              ++index1;
            }
            else if (propertyValue2.ToString().Equals("USB 序列装置"))
            {
              strArray[index1] = propertyValue3.ToString().Substring(10, propertyValue3.ToString().Length - 11);
              ++index1;
            }
            else
            {
              strArray[index1] = propertyValue3.ToString().Substring(19, propertyValue3.ToString().Length - 20);
              ++index1;
            }
          }
        }
      }
    }
    catch
    {
      init_Configuration.Output_Message = "搜索失败，请安装驱动！！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    Form1.Port_Number = 0;
    string[] portNames = SerialPort.GetPortNames();
    int num1 = 0;
    for (byte index2 = 0; (int) index2 < portNames.Length; ++index2)
      ++num1;
    if (num1 != Form1.Port_Number)
    {
      Application.DoEvents();
      this.comboBox1.Items.Clear();
      Form1.Port_Number = 0;
      for (byte index3 = 0; (int) index3 < portNames.Length; ++index3)
      {
        for (int index4 = 0; index4 < index1; ++index4)
        {
          if (strArray[index4] == portNames[(int) index3])
          {
            this.comboBox1.Items.Add((object) portNames[(int) index3]);
            ++Form1.Port_Number;
            this.comboBox1.SelectedIndex = Form1.Port_Number - 1;
          }
        }
      }
      Form1.PortName = this.comboBox1.Text.ToString();
    }
    this.imageButton1.Text = "搜索完成";
  }

  private void qqRadioButton1_CheckedChanged(object sender, EventArgs e)
  {
    if (this.qqRadioButton1.Checked)
      Form1.CheckSum_Type = "增强型校验和";
    else
      Form1.CheckSum_Type = "标准型校验和";
  }

  private async void ClearMemory_Thread() => await Form1.ClearMemory_Task();

  private static async Task ClearMemory_Task()
  {
    await Task.Run((Action) (() =>
    {
      do
      {
        Thread.Sleep(1000);
        if (Form1.Clear_Memory >= 60)
        {
          Form1.Clear_Memory = 0;
          Form1.ClearMemory();
        }
        else
          ++Form1.Clear_Memory;
      }
      while (Form1.EN_ClearMemory_flag);
    }));
  }

  [DllImport("kernel32.dll")]
  public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);

  public static void ClearMemory()
  {
    GC.Collect();
    GC.WaitForPendingFinalizers();
    if (Environment.OSVersion.Platform != PlatformID.Win32NT)
      return;
    Form1.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
  }

  private void imageButton18_Click(object sender, EventArgs e)
  {
    Process.Start("https://pan.baidu.com/s/1iFgqTA2NluoxE8mNDfy3Ag");
    init_Configuration.Output_Message = "提取码:yxkg";
    int num = (int) init_Configuration.PDF_Interface.ShowDialog();
  }

  private void imageButton19_Click(object sender, EventArgs e)
  {
    string path = Path.Combine(Application.StartupPath, "CH340\\CH341SER.EXE");
    if (File.Exists(path))
    {
      new Process()
      {
        StartInfo = {
          UseShellExecute = true,
          WorkingDirectory = Environment.CurrentDirectory,
          FileName = path,
          CreateNoWindow = false,
          Verb = "runas",
          WindowStyle = ProcessWindowStyle.Normal
        }
      }.Start();
    }
    else
    {
      init_Configuration.Output_Message = "驱动文件丢失";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
    }
  }

  private void imageButton16_Click(object sender, EventArgs e)
  {
    byte[] buffer_Data = new byte[8];
    byte Check_ID;
    try
    {
      byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox34.Text);
      if (dec < (byte) 63 /*0x3F*/)
      {
        Check_ID = Form1.LINCalcParity(dec);
        this.qqTextBox37.Text = Form1.DECstr_to_HEXstr(Check_ID.ToString());
      }
      else
      {
        init_Configuration.Output_Message = "ID超出范围(0x00--0x3F)";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      }
    }
    catch
    {
      init_Configuration.Output_Message = "ID格式不正确！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    byte LINCalcChecksum_length;
    try
    {
      if (Convert.ToByte(this.qqTextBox36.Text) <= (byte) 8 && Convert.ToByte(this.qqTextBox36.Text) >= (byte) 1)
      {
        LINCalcChecksum_length = Convert.ToByte(this.qqTextBox36.Text);
      }
      else
      {
        init_Configuration.Output_Message = "数据长度超出范围(1--8字节)";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        return;
      }
    }
    catch
    {
      init_Configuration.Output_Message = "数据长度格式不正确！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    int startIndex = 0;
    Check_ID = (byte) Form1.HEXstr_to_DEC(this.qqTextBox34.Text);
    string text = this.qqTextBox35.Text;
    try
    {
      for (byte index = 0; (int) index < (int) LINCalcChecksum_length; ++index)
      {
        buffer_Data[(int) index] = (byte) Form1.HEXstr_to_DEC(text.Substring(startIndex, 2).ToString());
        startIndex += 3;
      }
    }
    catch
    {
      init_Configuration.Output_Message = "数据格式不正确！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    this.qqTextBox38.Text = Form1.DECstr_to_HEXstr(Form1.LINCalcChecksum(Check_ID, buffer_Data, LINCalcChecksum_length).ToString());
  }

  private void imageButton2_Click(object sender, EventArgs e)
  {
    byte[] numArray = new byte[16 /*0x10*/];
    EEPROM_INFORMATION eepromInformation = new EEPROM_INFORMATION();
    if (!Form1.Device_switch_flag)
    {
      if (this.comboBox1.Text.ToString() == "")
      {
        init_Configuration.Output_Message = "请连接LINTest-M设备";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      }
      else
      {
        try
        {
          Form1.Baud_rate = Convert.ToInt32(this.dS数字输入框1.Text);
          if (Form1.Baud_rate < 4800 || Form1.Baud_rate > 115200)
          {
            init_Configuration.Output_Message = "波特率超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "波特率格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        Form1.CheckSum_Type = !this.qqRadioButton1.Checked ? "标准型校验和" : "增强型校验和";
        Form1.PortName = this.comboBox1.Text;
        this.serialPort1.PortName = Form1.PortName;
        this.serialPort1.BaudRate = 460800 /*0x070800*/;
        this.serialPort1.DataBits = 8;
        this.serialPort1.Parity = Parity.None;
        this.serialPort1.StopBits = StopBits.One;
        this.serialPort1.Encoding = Encoding.Default;
        this.serialPort1.DtrEnable = true;
        this.serialPort1.ReadTimeout = 500;
        this.serialPort1.ReceivedBytesThreshold = 16 /*0x10*/;
        try
        {
          this.serialPort1.Open();
          Thread.Sleep(50);
          this.serialPort1.Close();
        }
        catch
        {
          this.comboBox1.Items.Clear();
          Form1.Port_Number = 0;
          init_Configuration.Output_Message = "请连接LINTest-MI设备！！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        this.serialPort1.PortName = Form1.PortName;
        this.serialPort1.BaudRate = 460800 /*0x070800*/;
        this.serialPort1.DataBits = 8;
        this.serialPort1.Parity = Parity.None;
        this.serialPort1.StopBits = StopBits.One;
        this.serialPort1.Encoding = Encoding.Default;
        this.serialPort1.DtrEnable = true;
        this.serialPort1.ReadTimeout = 500;
        this.serialPort1.ReceivedBytesThreshold = 16 /*0x10*/;
        this.serialPort1.Open();
        if (this.serialPort1.IsOpen)
        {
          Form1.System_UART_RX_Rrror_flag = false;
          Form1.Device_switch_flag = true;
          this.serialPort1.DiscardInBuffer();
          init_Configuration.PDFForm_OK_flag = false;
          Form1.Rur_Mode = 0;
          Form1.Send_Mode_Command(Form1.Rur_Mode, Form1.Baud_rate, 28, 100);
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.imageButton1.Enabled = false;
          this.comboBox1.Enabled = false;
          this.dS数字输入框1.Enabled = false;
          this.qqRadioButton1.Enabled = false;
          this.qqRadioButton2.Enabled = false;
          this.qqRadioButton3.Enabled = true;
          this.qqRadioButton4.Enabled = true;
          this.qqRadioButton5.Enabled = true;
          this.qqRadioButton6.Enabled = true;
          this.qqTextBox10.Enabled = true;
          this.qqTextBox17.Enabled = true;
          this.imageButton2.NormalImage = (Image) Resources.开启;
          this.imageButton5.Enabled = true;
          this.imageButton6.Enabled = false;
          this.imageButton7.Enabled = true;
          this.imageButton8.Enabled = false;
          this.dS按钮1.Enabled = true;
          this.dS按钮2.Enabled = false;
          this.dS按钮1.贴图 = Resources.运行8;
          this.dS按钮2.贴图 = Resources.停止8;
          ((Control) this.dataGridViewX2).Enabled = true;
          this.dS按钮3.Enabled = true;
          this.dS按钮4.Enabled = false;
          this.dS按钮3.贴图 = Resources.运行8;
          this.dS按钮4.贴图 = Resources.停止8;
          Form1.Exit_Task_flag = false;
          Form1.Exit_Receive_flag = false;
          this.dS按钮5.Enabled = true;
          this.dS按钮6.Enabled = false;
          this.dS按钮5.贴图 = Resources.运行8;
          this.dS按钮6.贴图 = Resources.停止8;
          this.myButton5.Enabled = true;
          this.myButton5.NormalImage = (Image) Resources.btn_green_normal;
          Form1.BOOT_ON_flag = false;
          this.dS按钮9.Enabled = true;
          this.dS按钮10.贴图 = Resources.按钮3;
          this.dS按钮11.贴图 = Resources.灯6;
          this.dS按钮10.Enabled = true;
          this.dS按钮11.Enabled = true;
          this.imageButton15.Enabled = true;
          this.imageButton16.Enabled = true;
          this.imageButton17.Enabled = true;
          this.dS按钮13.Enabled = false;
          this.dS按钮13.贴图 = Resources.运行9;
          this.myButton1.Enabled = true;
          this.dS按钮15.Enabled = true;
          this.dS按钮15.贴图 = Resources.运行8;
          this.dS按钮14.Enabled = false;
          this.dS按钮14.贴图 = Resources.停止9;
          this.myButton3.Enabled = true;
          this.myButton2.Enabled = true;
          this.dS按钮17.Enabled = true;
          this.dS按钮16.Enabled = false;
          this.dS按钮17.贴图 = Resources.运行8;
          this.dS按钮16.贴图 = Resources.停止9;
          this.myButton4.Enabled = true;
          this.USB_Receive_Thread = new Thread(new ThreadStart(this.USB_Receive_Task));
          this.USB_Receive_Thread.IsBackground = true;
          this.USB_Receive_Thread.Start();
          this.Timing_Receive_USB();
        }
        else
        {
          init_Configuration.Output_Message = "打开设备失败或设备正在使用！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        }
      }
    }
    else
    {
      try
      {
        Form1.Exit_Receive_flag = true;
        do
          ;
        while (Form1.Exit_Receive_flag);
        if (this.USB_Receive_Thread != null && this.USB_Receive_Thread.ThreadState != System.Threading.ThreadState.Stopped && this.USB_Receive_Thread.ThreadState != System.Threading.ThreadState.Aborted)
          this.USB_Receive_Thread.Abort();
        if (this.Timing_Send_Thread != null && this.Timing_Send_Thread.ThreadState != System.Threading.ThreadState.Stopped && this.Timing_Send_Thread.ThreadState != System.Threading.ThreadState.Aborted)
          this.Timing_Send_Thread.Abort();
        if (this.BOOT_Thread != null && this.BOOT_Thread.ThreadState != System.Threading.ThreadState.Stopped && this.BOOT_Thread.ThreadState != System.Threading.ThreadState.Aborted)
          this.BOOT_Thread.Abort();
        if (this.Play_Thread != null && this.Play_Thread.ThreadState != System.Threading.ThreadState.Stopped && this.Play_Thread.ThreadState != System.Threading.ThreadState.Aborted)
          this.Play_Thread.Abort();
      }
      catch
      {
        init_Configuration.Output_Message = "关闭设备过程中出现异常！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      }
      try
      {
        this.serialPort1.Close();
        if (!this.serialPort1.IsOpen)
        {
          Form1.Device_switch_flag = false;
          this.imageButton2.NormalImage = (Image) Resources.关闭;
          this.imageButton2.Enabled = true;
          this.imageButton1.Enabled = true;
          this.comboBox1.Enabled = true;
          this.dS数字输入框1.Enabled = true;
          this.qqRadioButton1.Enabled = true;
          this.qqRadioButton2.Enabled = true;
          this.qqRadioButton3.Enabled = false;
          this.qqRadioButton4.Enabled = false;
          this.qqRadioButton5.Enabled = false;
          this.qqRadioButton6.Enabled = false;
          this.qqTextBox10.Enabled = false;
          this.qqTextBox17.Enabled = false;
          this.imageButton5.Enabled = false;
          this.imageButton6.Enabled = false;
          this.imageButton7.Enabled = false;
          this.imageButton8.Enabled = false;
          this.dS按钮1.Enabled = false;
          this.dS按钮2.Enabled = false;
          this.dS按钮1.贴图 = Resources.运行8;
          this.dS按钮2.贴图 = Resources.停止8;
          ((Control) this.dataGridViewX2).Enabled = false;
          this.dS按钮3.Enabled = false;
          this.dS按钮4.Enabled = false;
          this.dS按钮3.贴图 = Resources.运行8;
          this.dS按钮4.贴图 = Resources.停止8;
          this.dS按钮5.Enabled = false;
          this.dS按钮6.Enabled = false;
          this.dS按钮5.贴图 = Resources.运行8;
          this.dS按钮6.贴图 = Resources.停止8;
          this.myButton5.Enabled = false;
          this.myButton5.NormalImage = (Image) Resources.down;
          Form1.BOOT_ON_flag = false;
          this.dS按钮9.Enabled = false;
          this.dS按钮10.贴图 = Resources.按钮3;
          this.dS按钮11.贴图 = Resources.灯6;
          this.dS按钮10.Enabled = false;
          this.dS按钮11.Enabled = false;
          this.imageButton15.Enabled = false;
          this.imageButton16.Enabled = true;
          this.imageButton17.Enabled = false;
          this.dS按钮13.Enabled = false;
          this.dS按钮13.贴图 = Resources.运行9;
          this.myButton1.Enabled = false;
          this.dS按钮15.Enabled = false;
          this.dS按钮15.贴图 = Resources.运行9;
          this.dS按钮14.Enabled = false;
          this.dS按钮14.贴图 = Resources.停止9;
          this.myButton3.Enabled = false;
          this.myButton2.Enabled = false;
          this.dS按钮17.Enabled = false;
          this.dS按钮16.Enabled = false;
          this.dS按钮17.贴图 = Resources.运行9;
          this.dS按钮16.贴图 = Resources.停止9;
          this.myButton4.Enabled = false;
        }
        else
        {
          init_Configuration.Output_Message = "关闭设备失败！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        }
      }
      catch
      {
        this.imageButton1.Text = "搜索设备";
        Form1.Device_switch_flag = false;
        this.imageButton2.NormalImage = (Image) Resources.关闭;
        this.imageButton2.Enabled = true;
        this.imageButton1.Enabled = true;
        this.comboBox1.Enabled = true;
        this.dS数字输入框1.Enabled = true;
        this.qqRadioButton1.Enabled = true;
        this.qqRadioButton2.Enabled = true;
        this.qqRadioButton3.Enabled = false;
        this.qqRadioButton4.Enabled = false;
        this.qqRadioButton5.Enabled = false;
        this.qqRadioButton6.Enabled = false;
        this.qqTextBox10.Enabled = false;
        this.qqTextBox17.Enabled = false;
        this.imageButton5.Enabled = false;
        this.imageButton6.Enabled = false;
        this.imageButton7.Enabled = false;
        this.imageButton8.Enabled = false;
        this.dS按钮1.Enabled = false;
        this.dS按钮2.Enabled = false;
        this.dS按钮1.贴图 = Resources.运行8;
        this.dS按钮2.贴图 = Resources.停止8;
        ((Control) this.dataGridViewX2).Enabled = false;
        this.dS按钮3.Enabled = false;
        this.dS按钮4.Enabled = false;
        this.dS按钮3.贴图 = Resources.运行8;
        this.dS按钮4.贴图 = Resources.停止8;
        this.dS按钮5.Enabled = false;
        this.dS按钮6.Enabled = false;
        this.dS按钮5.贴图 = Resources.运行8;
        this.dS按钮6.贴图 = Resources.停止8;
        this.myButton5.Enabled = false;
        this.myButton5.NormalImage = (Image) Resources.down;
        Form1.BOOT_ON_flag = false;
        this.dS按钮9.Enabled = false;
        this.dS按钮10.贴图 = Resources.按钮3;
        this.dS按钮11.贴图 = Resources.灯6;
        this.dS按钮10.Enabled = false;
        this.dS按钮11.Enabled = false;
        this.imageButton15.Enabled = false;
        this.imageButton16.Enabled = true;
        this.imageButton17.Enabled = false;
        this.dS按钮13.Enabled = false;
        this.dS按钮13.贴图 = Resources.运行9;
        this.myButton1.Enabled = false;
        this.dS按钮15.Enabled = false;
        this.dS按钮15.贴图 = Resources.运行9;
        this.dS按钮14.Enabled = false;
        this.dS按钮14.贴图 = Resources.停止9;
        this.myButton3.Enabled = false;
        this.myButton2.Enabled = false;
        this.dS按钮17.Enabled = false;
        this.dS按钮16.Enabled = false;
        this.dS按钮17.贴图 = Resources.运行9;
        this.dS按钮16.贴图 = Resources.停止9;
        this.myButton4.Enabled = false;
      }
    }
  }

  private void imageButton3_Click(object sender, EventArgs e)
  {
    lock (Form1.locker)
    {
      this.listViewNF1.Items.Clear();
      Array.Clear((Array) Form1.Single_Mode_Data, 0, Form1.Single_Mode_Data.Length);
      Array.Clear((Array) Form1.Single_time, 0, Form1.Single_time.Length);
      Form1.RX_count = 0;
      Form1.RX_Save_count = 0;
      Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
      Form1.Single_count = 0;
      Form1.Single_Display_count = 0;
    }
  }

  private void imageButton4_Click(object sender, EventArgs e)
  {
    if (this.listViewNF1.Items.Count == 0)
    {
      init_Configuration.Output_Message = "无数据可保存！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
    }
    else
    {
      this.progressBarEx1.Value = 0;
      this.progressBarEx1.Maximum = Form1.Single_count;
      this.progressBarEx1.Text = "0%";
      this.saveFileDialog1.Title = "另存为";
      this.saveFileDialog1.FileName = "Data for 1";
      this.saveFileDialog1.Filter = "CSV File(*.csv)|*.csv";
      this.saveFileDialog1.ShowHelp = false;
      this.saveFileDialog1.OverwritePrompt = true;
      this.saveFileDialog1.SupportMultiDottedExtensions = false;
      if (this.saveFileDialog1.ShowDialog() != DialogResult.OK)
        return;
      Form1.Save_FileName_str = this.saveFileDialog1.FileName;
      this.imageButton2.Enabled = false;
      this.qqCheckBox1.Enabled = false;
      this.qqCheckBox2.Enabled = false;
      this.qqCheckBox3.Enabled = false;
      this.qqTextBox1.Enabled = false;
      this.qqTextBox4.Enabled = false;
      this.qqTextBox7.Enabled = false;
      this.qqTextBox3.Enabled = false;
      this.qqTextBox6.Enabled = false;
      this.qqTextBox9.Enabled = false;
      this.qqCheckBox4.Enabled = false;
      this.qqCheckBox5.Enabled = false;
      this.qqCheckBox6.Enabled = false;
      this.qqTextBox11.Enabled = false;
      this.qqTextBox13.Enabled = false;
      this.qqTextBox15.Enabled = false;
      this.qqTextBox12.Enabled = false;
      this.qqTextBox14.Enabled = false;
      this.qqTextBox16.Enabled = false;
      this.imageButton3.Enabled = false;
      this.imageButton4.Enabled = false;
      this.qqRadioButton3.Enabled = false;
      this.qqRadioButton4.Enabled = false;
      this.qqRadioButton5.Enabled = false;
      this.qqRadioButton6.Enabled = false;
      this.qqTextBox10.Enabled = false;
      this.qqTextBox17.Enabled = false;
      this.imageButton5.Enabled = false;
      this.imageButton6.Enabled = false;
      this.imageButton7.Enabled = false;
      this.imageButton8.Enabled = false;
      this.dS按钮1.Enabled = false;
      this.dS按钮2.Enabled = false;
      this.imageButton10.Enabled = false;
      this.dS按钮1.贴图 = Resources.运行8;
      this.dS按钮2.贴图 = Resources.停止8;
      ((Control) this.dataGridViewX2).Enabled = false;
      this.dS按钮3.Enabled = false;
      this.dS按钮4.Enabled = false;
      this.imageButton11.Enabled = false;
      this.imageButton12.Enabled = false;
      this.dS按钮3.贴图 = Resources.运行8;
      this.dS按钮4.贴图 = Resources.停止8;
      this.qqCheckBox7.Enabled = false;
      this.qqCheckBox8.Enabled = false;
      this.qqCheckBox9.Enabled = false;
      this.qqCheckBox10.Enabled = false;
      this.qqCheckBox11.Enabled = false;
      this.qqCheckBox12.Enabled = false;
      this.qqCheckBox13.Enabled = false;
      this.qqCheckBox14.Enabled = false;
      this.qqCheckBox15.Enabled = false;
      this.qqCheckBox16.Enabled = false;
      this.qqCheckBox17.Enabled = false;
      this.qqCheckBox18.Enabled = false;
      this.qqTextBox18.Enabled = false;
      this.qqTextBox19.Enabled = false;
      this.qqTextBox20.Enabled = false;
      this.qqTextBox21.Enabled = false;
      this.qqTextBox22.Enabled = false;
      this.qqTextBox23.Enabled = false;
      this.qqTextBox24.Enabled = false;
      this.qqTextBox25.Enabled = false;
      this.qqTextBox26.Enabled = false;
      this.qqTextBox27.Enabled = false;
      this.qqTextBox28.Enabled = false;
      this.qqTextBox29.Enabled = false;
      this.qqRadioButton13.Enabled = false;
      this.qqRadioButton14.Enabled = false;
      this.imageButton14.Enabled = false;
      this.qqRadioButton11.Enabled = false;
      this.qqRadioButton12.Enabled = false;
      this.imageButton13.Enabled = false;
      this.dS按钮5.贴图 = Resources.运行8;
      this.dS按钮5.Enabled = false;
      this.dS按钮6.Enabled = false;
      this.dS按钮6.贴图 = Resources.停止8;
      this.myButton5.Enabled = false;
      this.myButton5.NormalImage = (Image) Resources.down;
      Form1.BOOT_ON_flag = false;
      this.dS按钮9.Enabled = false;
      this.dS按钮10.贴图 = Resources.按钮3;
      this.dS按钮11.贴图 = Resources.灯6;
      this.dS按钮10.Enabled = false;
      this.dS按钮11.Enabled = false;
      this.imageButton15.Enabled = false;
      this.imageButton16.Enabled = true;
      this.imageButton17.Enabled = false;
      this.dS按钮13.Enabled = false;
      this.dS按钮13.贴图 = Resources.运行9;
      this.myButton1.Enabled = false;
      this.dS按钮15.Enabled = false;
      this.dS按钮15.贴图 = Resources.运行9;
      this.dS按钮14.Enabled = false;
      this.dS按钮14.贴图 = Resources.停止9;
      this.myButton3.Enabled = false;
      this.myButton2.Enabled = false;
      this.dS按钮17.Enabled = false;
      this.dS按钮16.Enabled = false;
      this.dS按钮17.贴图 = Resources.运行9;
      this.dS按钮16.贴图 = Resources.停止9;
      Form1.Save_ProgressBar_i = 0;
      Form1.Save_Finish_flag = false;
      Form1.Exit_Save_listViewNF1_flag = false;
      this.Save_listViewNF1_Thread = new Thread(new ThreadStart(this.Save_listViewNF1_Data));
      this.Save_listViewNF1_Thread.IsBackground = true;
      this.Save_listViewNF1_Thread.Start();
      this.Save_listViewNF1_Asynchronous();
    }
  }

  private void qqRadioButton3_CheckedChanged(object sender, EventArgs e)
  {
    if (!this.qqRadioButton3.Checked)
    {
      this.qqTextBox10.Enabled = true;
      Form1.Single_Frame_Send = false;
    }
    else
    {
      Form1.Single_Frame_Send = true;
      Form1.Send_Checked_flag = true;
      this.qqCheckBox1.Checked = false;
      Form1.Send_Checked_flag = true;
      this.qqCheckBox2.Checked = false;
      Form1.Send_Checked_flag = true;
      this.qqCheckBox3.Checked = false;
      Form1.Send_flag1 = false;
      Form1.Send_flag2 = false;
      Form1.Send_flag3 = false;
      this.qqTextBox10.Enabled = false;
    }
  }

  private void qqCheckBox1_CheckedChanged(object sender, EventArgs e)
  {
    if (Form1.Single_Frame_Send && !Form1.Send_Checked_flag)
    {
      Form1.Send_flag1 = true;
      Form1.Send_flag2 = false;
      Form1.Send_flag3 = false;
      Form1.Send_Checked_flag = true;
      this.qqCheckBox2.Checked = false;
      this.qqCheckBox3.Checked = false;
      this.qqCheckBox1.Checked = true;
    }
    else
      Form1.Send_flag1 = this.qqCheckBox1.Checked;
    Form1.Send_Checked_flag = false;
  }

  private void qqCheckBox2_CheckedChanged(object sender, EventArgs e)
  {
    if (Form1.Single_Frame_Send && !Form1.Send_Checked_flag)
    {
      Form1.Send_flag1 = false;
      Form1.Send_flag2 = true;
      Form1.Send_flag3 = false;
      Form1.Send_Checked_flag = true;
      this.qqCheckBox1.Checked = false;
      this.qqCheckBox3.Checked = false;
      this.qqCheckBox2.Checked = true;
    }
    else
      Form1.Send_flag2 = this.qqCheckBox2.Checked;
    Form1.Send_Checked_flag = false;
  }

  private void qqCheckBox3_CheckedChanged(object sender, EventArgs e)
  {
    if (Form1.Single_Frame_Send && !Form1.Send_Checked_flag)
    {
      Form1.Send_flag1 = false;
      Form1.Send_flag2 = false;
      Form1.Send_flag3 = true;
      Form1.Send_Checked_flag = true;
      this.qqCheckBox1.Checked = false;
      this.qqCheckBox2.Checked = false;
      this.qqCheckBox3.Checked = true;
    }
    else
      Form1.Send_flag3 = this.qqCheckBox3.Checked;
    Form1.Send_Checked_flag = false;
  }

  private void qqRadioButton5_CheckedChanged(object sender, EventArgs e)
  {
    if (!this.qqRadioButton5.Checked)
    {
      this.qqTextBox17.Enabled = true;
      Form1.Single_Frame_Receive = false;
    }
    else
    {
      Form1.Single_Frame_Receive = true;
      Form1.Receive_Checked_flag = true;
      this.qqCheckBox4.Checked = false;
      Form1.Receive_Checked_flag = true;
      this.qqCheckBox5.Checked = false;
      Form1.Receive_Checked_flag = true;
      this.qqCheckBox6.Checked = false;
      Form1.Receive_flag1 = false;
      Form1.Receive_flag2 = false;
      Form1.Receive_flag3 = false;
      this.qqTextBox17.Enabled = false;
    }
  }

  private void qqCheckBox4_CheckedChanged(object sender, EventArgs e)
  {
    if (Form1.Single_Frame_Receive && !Form1.Receive_Checked_flag)
    {
      Form1.Receive_flag1 = true;
      Form1.Receive_flag2 = false;
      Form1.Receive_flag3 = false;
      Form1.Receive_Checked_flag = true;
      this.qqCheckBox6.Checked = false;
      this.qqCheckBox5.Checked = false;
      this.qqCheckBox4.Checked = true;
    }
    else
      Form1.Receive_flag1 = this.qqCheckBox4.Checked;
    Form1.Receive_Checked_flag = false;
  }

  private void qqCheckBox5_CheckedChanged(object sender, EventArgs e)
  {
    if (Form1.Single_Frame_Receive && !Form1.Receive_Checked_flag)
    {
      Form1.Receive_flag1 = false;
      Form1.Receive_flag2 = true;
      Form1.Receive_flag3 = false;
      Form1.Receive_Checked_flag = true;
      this.qqCheckBox4.Checked = false;
      this.qqCheckBox6.Checked = false;
      this.qqCheckBox5.Checked = true;
    }
    else
      Form1.Receive_flag2 = this.qqCheckBox5.Checked;
    Form1.Receive_Checked_flag = false;
  }

  private void qqCheckBox6_CheckedChanged(object sender, EventArgs e)
  {
    if (Form1.Single_Frame_Receive && !Form1.Receive_Checked_flag)
    {
      Form1.Receive_flag1 = false;
      Form1.Receive_flag2 = false;
      Form1.Receive_flag3 = true;
      Form1.Receive_Checked_flag = true;
      this.qqCheckBox4.Checked = false;
      this.qqCheckBox5.Checked = false;
      this.qqCheckBox6.Checked = true;
    }
    else
      Form1.Receive_flag3 = this.qqCheckBox6.Checked;
    Form1.Receive_Checked_flag = false;
  }

  private void imageButton5_Click(object sender, EventArgs e)
  {
    if (Form1.Rur_Mode != 1)
    {
      if (Form1.Rur_Mode != 0)
      {
        Form1.Rur_Mode = 0;
        Form1.Send_Mode_Command(0, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
        this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
        Thread.Sleep(200);
      }
      Form1.Rur_Mode = 1;
      Form1.Send_Mode_Command(1, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
      this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
      Thread.Sleep(1000);
    }
    if (Form1.Single_Frame_Send)
    {
      if (Form1.Send_flag1)
      {
        byte dec;
        try
        {
          dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox1.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "发送1-ID超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "发送1-ID格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        byte Length;
        try
        {
          Length = Convert.ToByte(this.qqTextBox3.Text);
          if (Length == (byte) 0 || Length > (byte) 8)
          {
            init_Configuration.Output_Message = "发送1-数据长度超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "发送1-数据长度格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        string text;
        try
        {
          text = this.qqTextBox2.Text;
          if (text.Length < (int) Length * 3 - 1)
          {
            init_Configuration.Output_Message = "发送1-数据格式不正确！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "发送1-数据格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        if (Form1.CheckSum_Type == "增强型校验和")
        {
          try
          {
            Form1.Host_Send_Data(dec, text, (int) Length, "V2");
          }
          catch
          {
            init_Configuration.Output_Message = "发送1-数据格式不正确！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          Form1.System_Time_T = DateTime.Now;
          Buffer.BlockCopy((Array) Form1.Send_Frame_Data, 0, (Array) Form1.Single_Mode_Data, Form1.Single_count * 16 /*0x10*/, 16 /*0x10*/);
          Form1.Single_time[Form1.Single_count, 0] = Form1.System_Time_T.ToString("yyyy-MM-dd HH:mm:ss:fff");
          ++Form1.Single_count;
          if (Form1.Single_count >= (int) ushort.MaxValue)
            Form1.Single_count = 0;
        }
        else
        {
          try
          {
            Form1.Host_Send_Data(dec, text, (int) Length, "V1");
          }
          catch
          {
            init_Configuration.Output_Message = "发送1-数据格式不正确！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          Form1.System_Time_T = DateTime.Now;
          Buffer.BlockCopy((Array) Form1.Send_Frame_Data, 0, (Array) Form1.Single_Mode_Data, Form1.Single_count * 16 /*0x10*/, 16 /*0x10*/);
          Form1.Single_time[Form1.Single_count, 0] = Form1.System_Time_T.ToString("yyyy-MM-dd HH:mm:ss:fff");
          ++Form1.Single_count;
          if (Form1.Single_count >= (int) ushort.MaxValue)
            Form1.Single_count = 0;
        }
      }
      if (Form1.Send_flag2)
      {
        byte dec;
        try
        {
          dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox4.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "发送2-ID超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "发送2-ID格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        byte Length;
        try
        {
          Length = Convert.ToByte(this.qqTextBox6.Text);
          if (Length == (byte) 0 || Length > (byte) 8)
          {
            init_Configuration.Output_Message = "发送2-数据长度超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "发送2-数据长度格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        string text;
        try
        {
          text = this.qqTextBox5.Text;
          if (text.Length < (int) Length * 3 - 1)
          {
            init_Configuration.Output_Message = "发送2-数据格式不正确！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "发送2-数据格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        if (Form1.CheckSum_Type == "增强型校验和")
        {
          try
          {
            Form1.Host_Send_Data(dec, text, (int) Length, "V2");
          }
          catch
          {
            init_Configuration.Output_Message = "发送2-数据格式不正确！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          Form1.System_Time_T = DateTime.Now;
          Buffer.BlockCopy((Array) Form1.Send_Frame_Data, 0, (Array) Form1.Single_Mode_Data, Form1.Single_count * 16 /*0x10*/, 16 /*0x10*/);
          Form1.Single_time[Form1.Single_count, 0] = Form1.System_Time_T.ToString("yyyy-MM-dd HH:mm:ss:fff");
          ++Form1.Single_count;
          if (Form1.Single_count >= (int) ushort.MaxValue)
            Form1.Single_count = 0;
        }
        else
        {
          try
          {
            Form1.Host_Send_Data(dec, text, (int) Length, "V1");
          }
          catch
          {
            init_Configuration.Output_Message = "发送2-数据格式不正确！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          Form1.System_Time_T = DateTime.Now;
          Buffer.BlockCopy((Array) Form1.Send_Frame_Data, 0, (Array) Form1.Single_Mode_Data, Form1.Single_count * 16 /*0x10*/, 16 /*0x10*/);
          Form1.Single_time[Form1.Single_count, 0] = Form1.System_Time_T.ToString("yyyy-MM-dd HH:mm:ss:fff");
          ++Form1.Single_count;
          if (Form1.Single_count >= (int) ushort.MaxValue)
            Form1.Single_count = 0;
        }
      }
      if (!Form1.Send_flag3)
        return;
      byte dec1;
      try
      {
        dec1 = (byte) Form1.HEXstr_to_DEC(this.qqTextBox7.Text);
        if (dec1 > (byte) 63 /*0x3F*/)
        {
          init_Configuration.Output_Message = "发送3-ID超出范围！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      catch
      {
        init_Configuration.Output_Message = "发送3-ID格式不正确！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        return;
      }
      byte Length1;
      try
      {
        Length1 = Convert.ToByte(this.qqTextBox9.Text);
        if (Length1 == (byte) 0 || Length1 > (byte) 8)
        {
          init_Configuration.Output_Message = "发送3-数据长度超出范围！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      catch
      {
        init_Configuration.Output_Message = "发送3-数据长度格式不正确！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        return;
      }
      string text1;
      try
      {
        text1 = this.qqTextBox8.Text;
        if (text1.Length < (int) Length1 * 3 - 1)
        {
          init_Configuration.Output_Message = "发送3-数据格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      catch
      {
        init_Configuration.Output_Message = "发送3-数据格式不正确！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        return;
      }
      if (Form1.CheckSum_Type == "增强型校验和")
      {
        try
        {
          Form1.Host_Send_Data(dec1, text1, (int) Length1, "V2");
        }
        catch
        {
          init_Configuration.Output_Message = "发送3-数据格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
        Form1.System_Time_T = DateTime.Now;
        Buffer.BlockCopy((Array) Form1.Send_Frame_Data, 0, (Array) Form1.Single_Mode_Data, Form1.Single_count * 16 /*0x10*/, 16 /*0x10*/);
        Form1.Single_time[Form1.Single_count, 0] = Form1.System_Time_T.ToString("yyyy-MM-dd HH:mm:ss:fff");
        ++Form1.Single_count;
        if (Form1.Single_count >= (int) ushort.MaxValue)
          Form1.Single_count = 0;
      }
      else
      {
        try
        {
          Form1.Host_Send_Data(dec1, text1, (int) Length1, "V1");
        }
        catch
        {
          init_Configuration.Output_Message = "发送3-数据格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
        Form1.System_Time_T = DateTime.Now;
        Buffer.BlockCopy((Array) Form1.Send_Frame_Data, 0, (Array) Form1.Single_Mode_Data, Form1.Single_count * 16 /*0x10*/, 16 /*0x10*/);
        Form1.Single_time[Form1.Single_count, 0] = Form1.System_Time_T.ToString("yyyy-MM-dd HH:mm:ss:fff");
        ++Form1.Single_count;
        if (Form1.Single_count >= (int) ushort.MaxValue)
          Form1.Single_count = 0;
      }
    }
    else
    {
      Array.Clear((Array) Form1.Single_Send_Data, 0, Form1.Single_Send_Data.Length);
      Form1.Single_Send_i = 0;
      Form1.RX_count = 0;
      Form1.RX_Save_count = 0;
      Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
      try
      {
        Form1.Single_time_value = (int) Convert.ToInt16(this.qqTextBox10.Text);
        if (Form1.Baud_rate >= 19000)
        {
          if (Form1.Single_time_value < 10 || Form1.Single_time_value > 5000)
          {
            init_Configuration.Output_Message = "定时时间超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        else if (Form1.Baud_rate >= 9600)
        {
          if (Form1.Single_time_value < 20 || Form1.Single_time_value > 5000)
          {
            init_Configuration.Output_Message = "定时时间超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        else if (Form1.Single_time_value < 30 || Form1.Single_time_value > 5000)
        {
          init_Configuration.Output_Message = "定时时间超出范围！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      catch
      {
        init_Configuration.Output_Message = "定时时间格式不正确！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        return;
      }
      if (Form1.Send_flag1)
      {
        byte dec;
        try
        {
          dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox1.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "发送1-ID超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "发送1-ID格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        byte Length;
        try
        {
          Length = Convert.ToByte(this.qqTextBox3.Text);
          if (Length == (byte) 0 || Length > (byte) 8)
          {
            init_Configuration.Output_Message = "发送1-数据长度超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "发送1-数据长度格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        try
        {
          string text = this.qqTextBox2.Text;
          if (text.Length < (int) Length * 3 - 1)
          {
            init_Configuration.Output_Message = "发送1-数据格式不正确！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          if (Form1.CheckSum_Type == "增强型校验和")
          {
            Form1.Single_Set_Send_Data(Form1.Single_Send_i, dec, text, (int) Length, "V2");
            ++Form1.Single_Send_i;
          }
          else
          {
            Form1.Single_Set_Send_Data(Form1.Single_Send_i, dec, text, (int) Length, "V1");
            ++Form1.Single_Send_i;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "发送1-数据格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      if (Form1.Send_flag2)
      {
        byte dec;
        try
        {
          dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox4.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "发送2-ID超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "发送2-ID格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        byte Length;
        try
        {
          Length = Convert.ToByte(this.qqTextBox6.Text);
          if (Length == (byte) 0 || Length > (byte) 8)
          {
            init_Configuration.Output_Message = "发送2-数据长度超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "发送2-数据长度格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        try
        {
          string text = this.qqTextBox5.Text;
          if (text.Length < (int) Length * 3 - 1)
          {
            init_Configuration.Output_Message = "发送2-数据格式不正确！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          if (Form1.CheckSum_Type == "增强型校验和")
          {
            Form1.Single_Set_Send_Data(Form1.Single_Send_i, dec, text, (int) Length, "V2");
            ++Form1.Single_Send_i;
          }
          else
          {
            Form1.Single_Set_Send_Data(Form1.Single_Send_i, dec, text, (int) Length, "V1");
            ++Form1.Single_Send_i;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "发送2-数据格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      if (Form1.Send_flag3)
      {
        byte dec;
        try
        {
          dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox7.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "发送3-ID超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "发送3-ID格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        byte Length;
        try
        {
          Length = Convert.ToByte(this.qqTextBox9.Text);
          if (Length == (byte) 0 || Length > (byte) 8)
          {
            init_Configuration.Output_Message = "发送3-数据长度超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "发送3-数据长度格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        try
        {
          string text = this.qqTextBox8.Text;
          if (text.Length < (int) Length * 3 - 1)
          {
            init_Configuration.Output_Message = "发送3-数据格式不正确！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          if (Form1.CheckSum_Type == "增强型校验和")
          {
            Form1.Single_Set_Send_Data(Form1.Single_Send_i, dec, text, (int) Length, "V2");
            ++Form1.Single_Send_i;
          }
          else
          {
            Form1.Single_Set_Send_Data(Form1.Single_Send_i, dec, text, (int) Length, "V1");
            ++Form1.Single_Send_i;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "发送3-数据格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      this.imageButton2.Enabled = false;
      this.qqCheckBox1.Enabled = false;
      this.qqCheckBox2.Enabled = false;
      this.qqCheckBox3.Enabled = false;
      this.qqTextBox1.Enabled = false;
      this.qqTextBox4.Enabled = false;
      this.qqTextBox7.Enabled = false;
      this.qqTextBox3.Enabled = false;
      this.qqTextBox6.Enabled = false;
      this.qqTextBox9.Enabled = false;
      this.qqCheckBox4.Enabled = false;
      this.qqCheckBox5.Enabled = false;
      this.qqCheckBox6.Enabled = false;
      this.qqTextBox11.Enabled = false;
      this.qqTextBox13.Enabled = false;
      this.qqTextBox15.Enabled = false;
      this.qqTextBox12.Enabled = false;
      this.qqTextBox14.Enabled = false;
      this.qqTextBox16.Enabled = false;
      this.imageButton4.Enabled = false;
      this.qqRadioButton3.Enabled = false;
      this.qqRadioButton4.Enabled = false;
      this.qqRadioButton5.Enabled = false;
      this.qqRadioButton6.Enabled = false;
      this.qqTextBox10.Enabled = false;
      this.qqTextBox17.Enabled = false;
      this.imageButton5.Enabled = false;
      this.imageButton6.Enabled = true;
      this.imageButton7.Enabled = false;
      this.imageButton8.Enabled = false;
      this.dS按钮1.Enabled = false;
      this.dS按钮2.Enabled = false;
      this.imageButton10.Enabled = false;
      this.dS按钮1.贴图 = Resources.运行8;
      this.dS按钮2.贴图 = Resources.停止8;
      ((Control) this.dataGridViewX2).Enabled = false;
      this.dS按钮3.Enabled = false;
      this.dS按钮4.Enabled = false;
      this.imageButton12.Enabled = false;
      this.dS按钮3.贴图 = Resources.运行9;
      this.dS按钮4.贴图 = Resources.停止8;
      this.qqCheckBox7.Enabled = false;
      this.qqCheckBox8.Enabled = false;
      this.qqCheckBox9.Enabled = false;
      this.qqCheckBox10.Enabled = false;
      this.qqCheckBox11.Enabled = false;
      this.qqCheckBox12.Enabled = false;
      this.qqCheckBox13.Enabled = false;
      this.qqCheckBox14.Enabled = false;
      this.qqCheckBox15.Enabled = false;
      this.qqCheckBox16.Enabled = false;
      this.qqCheckBox17.Enabled = false;
      this.qqCheckBox18.Enabled = false;
      this.qqTextBox18.Enabled = false;
      this.qqTextBox19.Enabled = false;
      this.qqTextBox20.Enabled = false;
      this.qqTextBox21.Enabled = false;
      this.qqTextBox22.Enabled = false;
      this.qqTextBox23.Enabled = false;
      this.qqTextBox24.Enabled = false;
      this.qqTextBox25.Enabled = false;
      this.qqTextBox26.Enabled = false;
      this.qqTextBox27.Enabled = false;
      this.qqTextBox28.Enabled = false;
      this.qqTextBox29.Enabled = false;
      this.imageButton14.Enabled = false;
      this.qqRadioButton11.Enabled = false;
      this.qqRadioButton12.Enabled = false;
      this.dS按钮5.贴图 = Resources.运行9;
      this.dS按钮5.Enabled = false;
      this.dS按钮6.Enabled = false;
      this.dS按钮6.贴图 = Resources.停止8;
      this.myButton5.Enabled = false;
      this.myButton5.NormalImage = (Image) Resources.down;
      Form1.BOOT_ON_flag = false;
      this.dS按钮9.Enabled = false;
      this.dS按钮10.贴图 = Resources.按钮3;
      this.dS按钮11.贴图 = Resources.灯6;
      this.dS按钮10.Enabled = false;
      this.dS按钮11.Enabled = false;
      this.imageButton15.Enabled = false;
      this.imageButton16.Enabled = true;
      this.imageButton17.Enabled = false;
      this.dS按钮13.Enabled = false;
      this.dS按钮13.贴图 = Resources.运行9;
      this.myButton1.Enabled = false;
      this.dS按钮15.Enabled = false;
      this.dS按钮15.贴图 = Resources.运行9;
      this.dS按钮14.Enabled = false;
      this.dS按钮14.贴图 = Resources.停止9;
      this.myButton3.Enabled = false;
      this.myButton2.Enabled = false;
      this.dS按钮17.Enabled = false;
      this.dS按钮16.Enabled = false;
      this.dS按钮17.贴图 = Resources.运行9;
      this.dS按钮16.贴图 = Resources.停止9;
      Form1.Timing_Send_flag = true;
      this.Timing_Send_TX();
    }
  }

  private void imageButton6_Click(object sender, EventArgs e)
  {
    Form1.Timing_Send_flag = false;
    this.imageButton2.Enabled = true;
    this.qqCheckBox1.Enabled = true;
    this.qqCheckBox2.Enabled = true;
    this.qqCheckBox3.Enabled = true;
    this.qqTextBox1.Enabled = true;
    this.qqTextBox4.Enabled = true;
    this.qqTextBox7.Enabled = true;
    this.qqTextBox3.Enabled = true;
    this.qqTextBox6.Enabled = true;
    this.qqTextBox9.Enabled = true;
    this.qqCheckBox4.Enabled = true;
    this.qqCheckBox5.Enabled = true;
    this.qqCheckBox6.Enabled = true;
    this.qqTextBox11.Enabled = true;
    this.qqTextBox13.Enabled = true;
    this.qqTextBox15.Enabled = true;
    this.qqTextBox12.Enabled = true;
    this.qqTextBox14.Enabled = true;
    this.qqTextBox16.Enabled = true;
    this.imageButton4.Enabled = true;
    this.qqRadioButton3.Enabled = true;
    this.qqRadioButton4.Enabled = true;
    this.qqRadioButton5.Enabled = true;
    this.qqRadioButton6.Enabled = true;
    this.qqTextBox10.Enabled = true;
    this.qqTextBox17.Enabled = true;
    this.imageButton5.Enabled = true;
    this.imageButton6.Enabled = false;
    this.imageButton7.Enabled = true;
    this.imageButton8.Enabled = false;
    this.dS按钮1.Enabled = true;
    this.dS按钮2.Enabled = false;
    this.imageButton10.Enabled = true;
    this.dS按钮1.贴图 = Resources.运行8;
    this.dS按钮2.贴图 = Resources.停止8;
    ((Control) this.dataGridViewX2).Enabled = true;
    this.dS按钮3.Enabled = true;
    this.dS按钮4.Enabled = false;
    this.imageButton12.Enabled = true;
    this.dS按钮3.贴图 = Resources.运行8;
    this.dS按钮4.贴图 = Resources.停止8;
    this.dS按钮6.贴图 = Resources.停止8;
    this.qqCheckBox7.Enabled = true;
    this.qqCheckBox8.Enabled = true;
    this.qqCheckBox9.Enabled = true;
    this.qqCheckBox10.Enabled = true;
    this.qqCheckBox11.Enabled = true;
    this.qqCheckBox12.Enabled = true;
    this.qqCheckBox13.Enabled = true;
    this.qqCheckBox14.Enabled = true;
    this.qqCheckBox15.Enabled = true;
    this.qqCheckBox16.Enabled = true;
    this.qqCheckBox17.Enabled = true;
    this.qqCheckBox18.Enabled = true;
    this.qqTextBox18.Enabled = true;
    this.qqTextBox19.Enabled = true;
    this.qqTextBox20.Enabled = true;
    this.qqTextBox21.Enabled = true;
    this.qqTextBox22.Enabled = true;
    this.qqTextBox23.Enabled = true;
    this.qqTextBox24.Enabled = true;
    this.qqTextBox25.Enabled = true;
    this.qqTextBox26.Enabled = true;
    this.qqTextBox27.Enabled = true;
    this.qqTextBox28.Enabled = true;
    this.qqTextBox29.Enabled = true;
    this.imageButton14.Enabled = true;
    this.qqRadioButton11.Enabled = true;
    this.qqRadioButton12.Enabled = true;
    this.dS按钮5.Enabled = true;
    this.dS按钮6.Enabled = false;
    this.dS按钮5.贴图 = Resources.运行8;
    this.myButton5.Enabled = true;
    this.myButton5.NormalImage = (Image) Resources.btn_green_normal;
    Form1.BOOT_ON_flag = false;
    this.dS按钮9.Enabled = true;
    this.dS按钮10.贴图 = Resources.按钮3;
    this.dS按钮11.贴图 = Resources.灯6;
    this.dS按钮10.Enabled = true;
    this.dS按钮11.Enabled = true;
    this.imageButton15.Enabled = true;
    this.imageButton16.Enabled = true;
    this.imageButton17.Enabled = true;
    this.dS按钮13.Enabled = false;
    this.dS按钮13.贴图 = Resources.运行9;
    this.myButton1.Enabled = true;
    this.dS按钮15.Enabled = true;
    this.dS按钮15.贴图 = Resources.运行8;
    this.dS按钮14.Enabled = false;
    this.dS按钮14.贴图 = Resources.停止9;
    this.myButton3.Enabled = true;
    this.myButton2.Enabled = true;
    this.dS按钮17.Enabled = true;
    this.dS按钮16.Enabled = false;
    this.dS按钮17.贴图 = Resources.运行8;
    this.dS按钮16.贴图 = Resources.停止9;
  }

  private void imageButton7_Click(object sender, EventArgs e)
  {
    if (Form1.Rur_Mode != 1)
    {
      if (Form1.Rur_Mode != 0)
      {
        Form1.Rur_Mode = 0;
        Form1.Send_Mode_Command(0, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
        this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
        Thread.Sleep(200);
      }
      Form1.Rur_Mode = 1;
      Form1.Send_Mode_Command(1, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
      this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
      Thread.Sleep(50);
    }
    if (Form1.Single_Frame_Receive)
    {
      if (Form1.Receive_flag1)
      {
        byte dec;
        try
        {
          dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox11.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "接收1-ID超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "接收1-ID格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        byte Length;
        try
        {
          Length = Convert.ToByte(this.qqTextBox12.Text);
          if (Length == (byte) 0 || Length > (byte) 8)
          {
            init_Configuration.Output_Message = "接收1-数据长度超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "接收1数据长度格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        if (Form1.CheckSum_Type == "增强型校验和")
        {
          Form1.Read_Slave_Data(dec, (int) Length, "V2");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
        }
        else
        {
          Form1.Read_Slave_Data(dec, (int) Length, "V1");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
        }
      }
      if (Form1.Receive_flag2)
      {
        byte dec;
        try
        {
          dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox13.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "接收2-ID超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "接收2-ID格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        byte Length;
        try
        {
          Length = Convert.ToByte(this.qqTextBox14.Text);
          if (Length == (byte) 0 || Length > (byte) 8)
          {
            init_Configuration.Output_Message = "接收2-数据长度超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "接收2数据长度格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        if (Form1.CheckSum_Type == "增强型校验和")
        {
          Form1.Read_Slave_Data(dec, (int) Length, "V2");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
        }
        else
        {
          Form1.Read_Slave_Data(dec, (int) Length, "V1");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
        }
      }
      if (!Form1.Receive_flag3)
        return;
      byte dec1;
      try
      {
        dec1 = (byte) Form1.HEXstr_to_DEC(this.qqTextBox15.Text);
        if (dec1 > (byte) 63 /*0x3F*/)
        {
          init_Configuration.Output_Message = "接收3-ID超出范围！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      catch
      {
        init_Configuration.Output_Message = "接收3-ID格式不正确！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        return;
      }
      byte Length1;
      try
      {
        Length1 = Convert.ToByte(this.qqTextBox16.Text);
        if (Length1 == (byte) 0 || Length1 > (byte) 8)
        {
          init_Configuration.Output_Message = "接收3-数据长度超出范围！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      catch
      {
        init_Configuration.Output_Message = "接收3数据长度格式不正确！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        return;
      }
      if (Form1.CheckSum_Type == "增强型校验和")
      {
        Form1.Read_Slave_Data(dec1, (int) Length1, "V2");
        this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
      }
      else
      {
        Form1.Read_Slave_Data(dec1, (int) Length1, "V1");
        this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
      }
    }
    else
    {
      Array.Clear((Array) Form1.Single_Send_Data, 0, Form1.Single_Send_Data.Length);
      Form1.Single_Send_i = 0;
      Form1.RX_count = 0;
      Form1.RX_Save_count = 0;
      Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
      try
      {
        Form1.Single_time_value = (int) Convert.ToInt16(this.qqTextBox17.Text);
        if (Form1.Baud_rate >= 19000)
        {
          if (Form1.Single_time_value < 10 || Form1.Single_time_value > 5000)
          {
            init_Configuration.Output_Message = "定时时间超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        else if (Form1.Baud_rate >= 9600)
        {
          if (Form1.Single_time_value < 20 || Form1.Single_time_value > 5000)
          {
            init_Configuration.Output_Message = "定时时间超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        else if (Form1.Single_time_value < 30 || Form1.Single_time_value > 5000)
        {
          init_Configuration.Output_Message = "定时时间超出范围！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      catch
      {
        init_Configuration.Output_Message = "定时时间格式不正确！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        return;
      }
      if (Form1.Receive_flag1)
      {
        byte dec;
        try
        {
          dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox11.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "接收1-ID超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "接收1-ID格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        byte Length;
        try
        {
          Length = Convert.ToByte(this.qqTextBox12.Text);
          if (Length == (byte) 0 || Length > (byte) 8)
          {
            init_Configuration.Output_Message = "接收1-数据长度超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "接收1-数据长度格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        if (Form1.CheckSum_Type == "增强型校验和")
        {
          Form1.Single_Set_Read_Data(Form1.Single_Send_i, dec, (int) Length, "V2");
          ++Form1.Single_Send_i;
        }
        else
        {
          Form1.Single_Set_Read_Data(Form1.Single_Send_i, dec, (int) Length, "V1");
          ++Form1.Single_Send_i;
        }
      }
      if (Form1.Receive_flag2)
      {
        byte dec;
        try
        {
          dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox13.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "接收2-ID超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "接收2-ID格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        byte Length;
        try
        {
          Length = Convert.ToByte(this.qqTextBox14.Text);
          if (Length == (byte) 0 || Length > (byte) 8)
          {
            init_Configuration.Output_Message = "接收2-数据长度超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "接收2-数据长度格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        if (Form1.CheckSum_Type == "增强型校验和")
        {
          Form1.Single_Set_Read_Data(Form1.Single_Send_i, dec, (int) Length, "V2");
          ++Form1.Single_Send_i;
        }
        else
        {
          Form1.Single_Set_Read_Data(Form1.Single_Send_i, dec, (int) Length, "V1");
          ++Form1.Single_Send_i;
        }
      }
      if (Form1.Receive_flag3)
      {
        byte dec;
        try
        {
          dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox15.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "接收3-ID超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "接收3-ID格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        byte Length;
        try
        {
          Length = Convert.ToByte(this.qqTextBox16.Text);
          if (Length == (byte) 0 || Length > (byte) 8)
          {
            init_Configuration.Output_Message = "接收3-数据长度超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = "接收3-数据长度格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        if (Form1.CheckSum_Type == "增强型校验和")
        {
          Form1.Single_Set_Read_Data(Form1.Single_Send_i, dec, (int) Length, "V2");
          ++Form1.Single_Send_i;
        }
        else
        {
          Form1.Single_Set_Read_Data(Form1.Single_Send_i, dec, (int) Length, "V1");
          ++Form1.Single_Send_i;
        }
      }
      this.imageButton2.Enabled = false;
      this.qqCheckBox1.Enabled = false;
      this.qqCheckBox2.Enabled = false;
      this.qqCheckBox3.Enabled = false;
      this.qqTextBox1.Enabled = false;
      this.qqTextBox4.Enabled = false;
      this.qqTextBox7.Enabled = false;
      this.qqTextBox2.Enabled = false;
      this.qqTextBox5.Enabled = false;
      this.qqTextBox8.Enabled = false;
      this.qqTextBox3.Enabled = false;
      this.qqTextBox6.Enabled = false;
      this.qqTextBox9.Enabled = false;
      this.qqCheckBox4.Enabled = false;
      this.qqCheckBox5.Enabled = false;
      this.qqCheckBox6.Enabled = false;
      this.qqTextBox11.Enabled = false;
      this.qqTextBox13.Enabled = false;
      this.qqTextBox15.Enabled = false;
      this.qqTextBox12.Enabled = false;
      this.qqTextBox14.Enabled = false;
      this.qqTextBox16.Enabled = false;
      this.imageButton4.Enabled = false;
      this.qqRadioButton3.Enabled = false;
      this.qqRadioButton4.Enabled = false;
      this.qqRadioButton5.Enabled = false;
      this.qqRadioButton6.Enabled = false;
      this.qqTextBox10.Enabled = false;
      this.qqTextBox17.Enabled = false;
      this.imageButton5.Enabled = false;
      this.imageButton6.Enabled = false;
      this.imageButton7.Enabled = false;
      this.imageButton8.Enabled = true;
      this.dS按钮1.Enabled = false;
      this.dS按钮2.Enabled = false;
      this.imageButton10.Enabled = false;
      this.dS按钮1.贴图 = Resources.运行8;
      this.dS按钮2.贴图 = Resources.停止8;
      ((Control) this.dataGridViewX2).Enabled = false;
      this.dS按钮3.Enabled = false;
      this.dS按钮4.Enabled = false;
      this.imageButton12.Enabled = false;
      this.dS按钮3.贴图 = Resources.运行9;
      this.dS按钮4.贴图 = Resources.停止8;
      this.qqCheckBox7.Enabled = false;
      this.qqCheckBox8.Enabled = false;
      this.qqCheckBox9.Enabled = false;
      this.qqCheckBox10.Enabled = false;
      this.qqCheckBox11.Enabled = false;
      this.qqCheckBox12.Enabled = false;
      this.qqCheckBox13.Enabled = false;
      this.qqCheckBox14.Enabled = false;
      this.qqCheckBox15.Enabled = false;
      this.qqCheckBox16.Enabled = false;
      this.qqCheckBox17.Enabled = false;
      this.qqCheckBox18.Enabled = false;
      this.qqTextBox18.Enabled = false;
      this.qqTextBox19.Enabled = false;
      this.qqTextBox20.Enabled = false;
      this.qqTextBox21.Enabled = false;
      this.qqTextBox22.Enabled = false;
      this.qqTextBox23.Enabled = false;
      this.qqTextBox24.Enabled = false;
      this.qqTextBox25.Enabled = false;
      this.qqTextBox26.Enabled = false;
      this.qqTextBox27.Enabled = false;
      this.qqTextBox28.Enabled = false;
      this.qqTextBox29.Enabled = false;
      this.imageButton14.Enabled = false;
      this.qqRadioButton11.Enabled = false;
      this.qqRadioButton12.Enabled = false;
      this.dS按钮5.贴图 = Resources.运行9;
      this.dS按钮5.Enabled = false;
      this.dS按钮6.Enabled = false;
      this.dS按钮6.贴图 = Resources.停止8;
      this.myButton5.Enabled = false;
      this.myButton5.NormalImage = (Image) Resources.down;
      Form1.BOOT_ON_flag = false;
      this.dS按钮9.Enabled = false;
      this.dS按钮10.贴图 = Resources.按钮3;
      this.dS按钮11.贴图 = Resources.灯6;
      this.dS按钮10.Enabled = false;
      this.dS按钮11.Enabled = false;
      this.imageButton15.Enabled = false;
      this.imageButton16.Enabled = true;
      this.imageButton17.Enabled = false;
      this.dS按钮13.Enabled = false;
      this.dS按钮13.贴图 = Resources.运行9;
      this.myButton1.Enabled = false;
      this.dS按钮15.Enabled = false;
      this.dS按钮15.贴图 = Resources.运行9;
      this.dS按钮14.Enabled = false;
      this.dS按钮14.贴图 = Resources.停止9;
      this.myButton3.Enabled = false;
      this.myButton2.Enabled = false;
      this.dS按钮17.Enabled = false;
      this.dS按钮16.Enabled = false;
      this.dS按钮17.贴图 = Resources.运行9;
      this.dS按钮16.贴图 = Resources.停止9;
      Form1.Timing_Send_flag = true;
      this.Timing_Send_RX();
    }
  }

  private void imageButton8_Click(object sender, EventArgs e)
  {
    Form1.Timing_Send_flag = false;
    this.imageButton2.Enabled = true;
    this.qqCheckBox1.Enabled = true;
    this.qqCheckBox2.Enabled = true;
    this.qqCheckBox3.Enabled = true;
    this.qqTextBox1.Enabled = true;
    this.qqTextBox4.Enabled = true;
    this.qqTextBox7.Enabled = true;
    this.qqTextBox2.Enabled = true;
    this.qqTextBox5.Enabled = true;
    this.qqTextBox8.Enabled = true;
    this.qqTextBox3.Enabled = true;
    this.qqTextBox6.Enabled = true;
    this.qqTextBox9.Enabled = true;
    this.qqCheckBox4.Enabled = true;
    this.qqCheckBox5.Enabled = true;
    this.qqCheckBox6.Enabled = true;
    this.qqTextBox11.Enabled = true;
    this.qqTextBox13.Enabled = true;
    this.qqTextBox15.Enabled = true;
    this.qqTextBox12.Enabled = true;
    this.qqTextBox14.Enabled = true;
    this.qqTextBox16.Enabled = true;
    this.imageButton4.Enabled = true;
    this.qqRadioButton3.Enabled = true;
    this.qqRadioButton4.Enabled = true;
    this.qqRadioButton5.Enabled = true;
    this.qqRadioButton6.Enabled = true;
    this.qqTextBox10.Enabled = true;
    this.qqTextBox17.Enabled = true;
    this.imageButton5.Enabled = true;
    this.imageButton6.Enabled = false;
    this.imageButton7.Enabled = true;
    this.imageButton8.Enabled = false;
    this.dS按钮1.Enabled = true;
    this.dS按钮2.Enabled = false;
    this.imageButton10.Enabled = true;
    this.dS按钮1.贴图 = Resources.运行8;
    this.dS按钮2.贴图 = Resources.停止8;
    ((Control) this.dataGridViewX2).Enabled = true;
    this.dS按钮3.Enabled = true;
    this.dS按钮4.Enabled = false;
    this.imageButton12.Enabled = true;
    this.dS按钮3.贴图 = Resources.运行8;
    this.dS按钮4.贴图 = Resources.停止8;
    this.dS按钮6.贴图 = Resources.停止8;
    this.qqCheckBox7.Enabled = true;
    this.qqCheckBox8.Enabled = true;
    this.qqCheckBox9.Enabled = true;
    this.qqCheckBox10.Enabled = true;
    this.qqCheckBox11.Enabled = true;
    this.qqCheckBox12.Enabled = true;
    this.qqCheckBox13.Enabled = true;
    this.qqCheckBox14.Enabled = true;
    this.qqCheckBox15.Enabled = true;
    this.qqCheckBox16.Enabled = true;
    this.qqCheckBox17.Enabled = true;
    this.qqCheckBox18.Enabled = true;
    this.qqTextBox18.Enabled = true;
    this.qqTextBox19.Enabled = true;
    this.qqTextBox20.Enabled = true;
    this.qqTextBox21.Enabled = true;
    this.qqTextBox22.Enabled = true;
    this.qqTextBox23.Enabled = true;
    this.qqTextBox24.Enabled = true;
    this.qqTextBox25.Enabled = true;
    this.qqTextBox26.Enabled = true;
    this.qqTextBox27.Enabled = true;
    this.qqTextBox28.Enabled = true;
    this.qqTextBox29.Enabled = true;
    this.imageButton14.Enabled = true;
    this.qqRadioButton11.Enabled = true;
    this.qqRadioButton12.Enabled = true;
    this.dS按钮5.Enabled = true;
    this.dS按钮6.Enabled = false;
    this.dS按钮5.贴图 = Resources.运行8;
    this.myButton5.Enabled = true;
    this.myButton5.NormalImage = (Image) Resources.btn_green_normal;
    Form1.BOOT_ON_flag = false;
    this.dS按钮9.Enabled = true;
    this.dS按钮10.贴图 = Resources.按钮3;
    this.dS按钮11.贴图 = Resources.灯6;
    this.dS按钮10.Enabled = true;
    this.dS按钮11.Enabled = true;
    this.imageButton15.Enabled = true;
    this.imageButton16.Enabled = true;
    this.imageButton17.Enabled = true;
    this.dS按钮13.Enabled = false;
    this.dS按钮13.贴图 = Resources.运行9;
    this.myButton1.Enabled = true;
    this.dS按钮15.Enabled = true;
    this.dS按钮15.贴图 = Resources.运行8;
    this.dS按钮14.Enabled = false;
    this.dS按钮14.贴图 = Resources.停止9;
    this.myButton3.Enabled = true;
    this.myButton2.Enabled = true;
    this.dS按钮17.Enabled = true;
    this.dS按钮16.Enabled = false;
    this.dS按钮17.贴图 = Resources.运行8;
    this.dS按钮16.贴图 = Resources.停止9;
  }

  private void imageButton9_Click(object sender, EventArgs e)
  {
    lock (Form1.locker)
    {
      this.listViewNF2.Items.Clear();
      Array.Clear((Array) Form1.List_Mode_Data, 0, Form1.List_Mode_Data.Length);
      Form1.Set_value(Form1.List_Static, byte.MaxValue, Form1.List_Static.Length);
      Array.Clear((Array) Form1.List_time, 0, Form1.List_time.Length);
      Form1.RX_count = 0;
      Form1.RX_Save_count = 0;
      Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
      Form1.List_count = 0;
      Form1.List_Display_count = 0;
      Form1.mode2_Save_Task_i = 0;
    }
  }

  private void imageButton10_Click(object sender, EventArgs e)
  {
    Array.Clear((Array) Form1.LI_Static_Save, 0, Form1.LI_Static_Save.Length);
    Form1.LI_Static_i = 0;
    if (this.listViewNF2.Items.Count == 0)
    {
      init_Configuration.Output_Message = "无数据可保存！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
    }
    else
    {
      if (Form1.List_Display_Mode)
      {
        for (int index = 0; index < this.listViewNF2.Items.Count; ++index)
        {
          Form1.LI_Static_Save[index, 0] = this.listViewNF2.Items[index].SubItems[0].Text;
          Form1.LI_Static_Save[index, 1] = this.listViewNF2.Items[index].SubItems[1].Text;
          Form1.LI_Static_Save[index, 2] = this.listViewNF2.Items[index].SubItems[2].Text;
          Form1.LI_Static_Save[index, 3] = this.listViewNF2.Items[index].SubItems[3].Text;
          Form1.LI_Static_Save[index, 4] = this.listViewNF2.Items[index].SubItems[4].Text;
          Form1.LI_Static_Save[index, 5] = this.listViewNF2.Items[index].SubItems[5].Text;
          Form1.LI_Static_Save[index, 6] = this.listViewNF2.Items[index].SubItems[6].Text;
          Form1.LI_Static_Save[index, 7] = this.listViewNF2.Items[index].SubItems[7].Text;
          Form1.LI_Static_Save[index, 8] = this.listViewNF2.Items[index].SubItems[8].Text;
          ++Form1.LI_Static_i;
        }
        this.progressBarEx1.Value = 0;
        this.progressBarEx1.Maximum = Form1.LI_Static_i;
        this.progressBarEx1.Text = "0%";
      }
      else
      {
        this.progressBarEx1.Value = 0;
        this.progressBarEx1.Maximum = Form1.List_count;
        this.progressBarEx1.Text = "0%";
      }
      this.saveFileDialog2.Title = "另存为";
      this.saveFileDialog2.FileName = "Data for 1";
      this.saveFileDialog2.Filter = "CSV File(*.csv)|*.csv";
      this.saveFileDialog2.ShowHelp = false;
      this.saveFileDialog2.OverwritePrompt = true;
      this.saveFileDialog2.SupportMultiDottedExtensions = false;
      if (this.saveFileDialog2.ShowDialog() != DialogResult.OK)
        return;
      Form1.Save_FileName_str = this.saveFileDialog2.FileName;
      this.imageButton2.Enabled = false;
      this.imageButton4.Enabled = false;
      this.qqRadioButton3.Enabled = false;
      this.qqRadioButton4.Enabled = false;
      this.qqRadioButton5.Enabled = false;
      this.qqRadioButton6.Enabled = false;
      this.qqTextBox10.Enabled = false;
      this.qqTextBox17.Enabled = false;
      this.imageButton5.Enabled = false;
      this.imageButton6.Enabled = false;
      this.imageButton7.Enabled = false;
      this.imageButton8.Enabled = false;
      this.dS按钮1.Enabled = false;
      this.dS按钮2.Enabled = false;
      this.qqRadioButton7.Enabled = false;
      this.qqRadioButton8.Enabled = false;
      this.imageButton9.Enabled = false;
      this.imageButton10.Enabled = false;
      this.dS按钮1.贴图 = Resources.运行8;
      this.dS按钮2.贴图 = Resources.停止8;
      ((Control) this.dataGridViewX2).Enabled = false;
      this.dS按钮3.Enabled = false;
      this.dS按钮4.Enabled = false;
      this.imageButton11.Enabled = false;
      this.imageButton12.Enabled = false;
      this.dS按钮3.贴图 = Resources.运行8;
      this.dS按钮4.贴图 = Resources.停止8;
      this.qqCheckBox7.Enabled = false;
      this.qqCheckBox8.Enabled = false;
      this.qqCheckBox9.Enabled = false;
      this.qqCheckBox10.Enabled = false;
      this.qqCheckBox11.Enabled = false;
      this.qqCheckBox12.Enabled = false;
      this.qqCheckBox13.Enabled = false;
      this.qqCheckBox14.Enabled = false;
      this.qqCheckBox15.Enabled = false;
      this.qqCheckBox16.Enabled = false;
      this.qqCheckBox17.Enabled = false;
      this.qqCheckBox18.Enabled = false;
      this.qqTextBox18.Enabled = false;
      this.qqTextBox19.Enabled = false;
      this.qqTextBox20.Enabled = false;
      this.qqTextBox21.Enabled = false;
      this.qqTextBox22.Enabled = false;
      this.qqTextBox23.Enabled = false;
      this.qqTextBox24.Enabled = false;
      this.qqTextBox25.Enabled = false;
      this.qqTextBox26.Enabled = false;
      this.qqTextBox27.Enabled = false;
      this.qqTextBox28.Enabled = false;
      this.qqTextBox29.Enabled = false;
      this.qqRadioButton13.Enabled = false;
      this.qqRadioButton14.Enabled = false;
      this.imageButton14.Enabled = false;
      this.qqRadioButton11.Enabled = false;
      this.qqRadioButton12.Enabled = false;
      this.imageButton13.Enabled = false;
      this.dS按钮5.贴图 = Resources.运行8;
      this.dS按钮5.Enabled = false;
      this.dS按钮6.Enabled = false;
      this.dS按钮6.贴图 = Resources.停止8;
      this.myButton5.Enabled = false;
      this.myButton5.NormalImage = (Image) Resources.down;
      Form1.BOOT_ON_flag = false;
      this.dS按钮9.Enabled = false;
      this.dS按钮10.贴图 = Resources.按钮3;
      this.dS按钮11.贴图 = Resources.灯6;
      this.dS按钮10.Enabled = false;
      this.dS按钮11.Enabled = false;
      this.imageButton15.Enabled = false;
      this.imageButton16.Enabled = true;
      this.imageButton17.Enabled = false;
      this.dS按钮13.Enabled = false;
      this.dS按钮13.贴图 = Resources.运行9;
      this.myButton1.Enabled = false;
      this.dS按钮15.Enabled = false;
      this.dS按钮15.贴图 = Resources.运行9;
      this.dS按钮14.Enabled = false;
      this.dS按钮14.贴图 = Resources.停止9;
      this.myButton3.Enabled = false;
      this.myButton2.Enabled = false;
      this.dS按钮17.Enabled = false;
      this.dS按钮16.Enabled = false;
      this.dS按钮17.贴图 = Resources.运行9;
      this.dS按钮16.贴图 = Resources.停止9;
      Form1.Save_ProgressBar_i = 0;
      Form1.Save_Finish_flag = false;
      Form1.Exit_Save_listViewNF2_flag = false;
      this.Save_listViewNF2_Thread = new Thread(new ThreadStart(this.Save_listViewNF2_Data));
      this.Save_listViewNF2_Thread.IsBackground = true;
      this.Save_listViewNF2_Thread.Start();
      this.Save_listViewNF2_Asynchronous();
    }
  }

  private void qqRadioButton7_CheckedChanged(object sender, EventArgs e)
  {
    if (this.qqRadioButton7.Checked)
    {
      lock (Form1.locker)
      {
        this.listViewNF2.Items.Clear();
        Array.Clear((Array) Form1.List_Mode_Data, 0, Form1.List_Mode_Data.Length);
        Form1.Set_value(Form1.List_Static, byte.MaxValue, Form1.List_Static.Length);
        Array.Clear((Array) Form1.List_time, 0, Form1.List_time.Length);
        Form1.RX_count = 0;
        Form1.RX_Save_count = 0;
        Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
        Form1.List_count = 0;
        Form1.List_Display_count = 0;
        Form1.List_Display_Mode = false;
        Form1.mode2_Save_Task_i = 0;
      }
    }
    else
    {
      lock (Form1.locker)
      {
        this.listViewNF2.Items.Clear();
        Array.Clear((Array) Form1.List_Mode_Data, 0, Form1.List_Mode_Data.Length);
        Array.Clear((Array) Form1.List_time, 0, Form1.List_time.Length);
        Form1.RX_count = 0;
        Form1.RX_Save_count = 0;
        Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
        Form1.List_count = 0;
        Form1.List_Display_count = 0;
        Form1.List_Display_Mode = true;
        Form1.mode2_Save_Task_i = 0;
      }
    }
  }

  private void dS按钮1_ButtonClick(object Sender)
  {
    string str1 = "";
    byte[] buffer_Data = new byte[8];
    Form1.RX_count = 0;
    Form1.RX_Save_count = 0;
    Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
    for (int index = 0; index < 20; ++index)
    {
      if (((DataGridView) this.dataGridViewX1).Rows[index].Cells[0].Value.ToString() == "True")
      {
        try
        {
          if ((byte) Form1.HEXstr_to_DEC(((DataGridView) this.dataGridViewX1).Rows[index].Cells[3].Value.ToString()) > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = $"第{index.ToString()}行ID超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = $"第{index.ToString()}行的ID格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        int int16_1;
        try
        {
          int16_1 = (int) (byte) Convert.ToInt16(((DataGridView) this.dataGridViewX1).Rows[index].Cells[5].Value.ToString());
          if (int16_1 > 8 || int16_1 == 0)
          {
            init_Configuration.Output_Message = $"第{index.ToString()}行数据长度超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = $"第{index.ToString()}行的ID数据长度不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        try
        {
          if (((DataGridView) this.dataGridViewX1).Rows[index].Cells[4].Value.ToString().Length < int16_1 * 3 - 1)
          {
            init_Configuration.Output_Message = $"第{index.ToString()}行数据格式不正确！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = $"第{index.ToString()}行数据格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        try
        {
          int int16_2 = (int) Convert.ToInt16(((DataGridView) this.dataGridViewX1).Rows[index].Cells[6].Value.ToString());
          if (Form1.Baud_rate >= 19000)
          {
            if (int16_2 < 10 || int16_2 > 5000)
            {
              init_Configuration.Output_Message = $"第{index.ToString()}行定时时间超出范围！";
              int num = (int) init_Configuration.PDF_Interface.ShowDialog();
              return;
            }
          }
          else if (Form1.Baud_rate >= 9600)
          {
            if (int16_2 < 20 || int16_2 > 5000)
            {
              init_Configuration.Output_Message = $"第{index.ToString()}行定时时间超出范围！";
              int num = (int) init_Configuration.PDF_Interface.ShowDialog();
              return;
            }
          }
          else if (int16_2 < 30 || int16_2 > 5000)
          {
            init_Configuration.Output_Message = $"第{index.ToString()}行定时时间超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = $"第{index.ToString()}行定时时间格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
    }
    if (this.qqRadioButton7.Checked)
    {
      lock (Form1.locker)
      {
        this.listViewNF2.Items.Clear();
        Array.Clear((Array) Form1.List_Mode_Data, 0, Form1.List_Mode_Data.Length);
        Array.Clear((Array) Form1.List_EN, 0, Form1.List_EN.Length);
        Array.Clear((Array) Form1.List_time_value, 0, Form1.List_time_value.Length);
        Form1.Set_value(Form1.List_Static, byte.MaxValue, Form1.List_Static.Length);
        Array.Clear((Array) Form1.List_time, 0, Form1.List_time.Length);
        Form1.List_count = 0;
        Form1.List_Display_count = 0;
        Form1.List_Display_Mode = false;
      }
    }
    else
    {
      lock (Form1.locker)
      {
        this.listViewNF2.Items.Clear();
        Array.Clear((Array) Form1.List_Mode_Data, 0, Form1.List_Mode_Data.Length);
        Array.Clear((Array) Form1.List_EN, 0, Form1.List_EN.Length);
        Array.Clear((Array) Form1.List_time_value, 0, Form1.List_time_value.Length);
        Form1.Set_value(Form1.List_Static, byte.MaxValue, Form1.List_Static.Length);
        Array.Clear((Array) Form1.List_time, 0, Form1.List_time.Length);
        Form1.List_count = 0;
        Form1.List_Display_count = 0;
        Form1.List_Display_Mode = true;
      }
    }
    Form1.List_Send_i = 0;
    int num1 = 0;
    Array.Clear((Array) Form1.List_Send_Data, 0, Form1.List_Send_Data.Length);
    if (Form1.Rur_Mode != 2)
    {
      if (Form1.Rur_Mode != 0)
      {
        Form1.Rur_Mode = 0;
        Form1.Send_Mode_Command(0, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
        this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
        Thread.Sleep(200);
      }
      Form1.Rur_Mode = 2;
      Form1.Send_Mode_Command(1, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
      this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
      Thread.Sleep(50);
    }
    for (int index = 0; index < 20; ++index)
    {
      if (((DataGridView) this.dataGridViewX1).Rows[index].Cells[0].Value.ToString() == "True")
      {
        if (((DataGridView) this.dataGridViewX1).Rows[index].Cells[2].Value.ToString() == "发送")
        {
          Form1.List_Send_Data[Form1.List_Send_i, 0] = (byte) 34;
          Form1.List_Send_Data[Form1.List_Send_i, 1] = (byte) 0;
          Form1.List_Send_Data[Form1.List_Send_i, 2] = (byte) Form1.HEXstr_to_DEC(((DataGridView) this.dataGridViewX1).Rows[index].Cells[3].Value.ToString());
          Form1.List_Send_Data[Form1.List_Send_i, 3] = (byte) 0;
          Form1.List_EN[index, 0] = (byte) 1;
          Form1.List_EN[index, 1] = (byte) 0;
          Form1.List_Send_Data[Form1.List_Send_i, 4] = !(Form1.CheckSum_Type == "增强型校验和") ? (byte) 1 : (byte) 2;
          Form1.List_Send_Data[Form1.List_Send_i, 5] = (byte) Convert.ToInt16(((DataGridView) this.dataGridViewX1).Rows[index].Cells[5].Value.ToString());
          str1 = "";
          string str2 = ((DataGridView) this.dataGridViewX1).Rows[index].Cells[4].Value.ToString();
          try
          {
            if (Form1.List_Send_Data[Form1.List_Send_i, 5] == (byte) 1)
            {
              buffer_Data[0] = Form1.List_Send_Data[Form1.List_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.List_Send_Data[Form1.List_Send_i, 7] = (byte) 0;
              buffer_Data[2] = Form1.List_Send_Data[Form1.List_Send_i, 8] = (byte) 0;
              buffer_Data[3] = Form1.List_Send_Data[Form1.List_Send_i, 9] = (byte) 0;
              buffer_Data[4] = Form1.List_Send_Data[Form1.List_Send_i, 10] = (byte) 0;
              buffer_Data[5] = Form1.List_Send_Data[Form1.List_Send_i, 11] = (byte) 0;
              buffer_Data[6] = Form1.List_Send_Data[Form1.List_Send_i, 12] = (byte) 0;
              buffer_Data[7] = Form1.List_Send_Data[Form1.List_Send_i, 13] = (byte) 0;
            }
            else if (Form1.List_Send_Data[Form1.List_Send_i, 5] == (byte) 2)
            {
              buffer_Data[0] = Form1.List_Send_Data[Form1.List_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.List_Send_Data[Form1.List_Send_i, 7] = (byte) Form1.HEXstr_to_DEC(str2.Substring(3, 2).ToString());
              buffer_Data[2] = Form1.List_Send_Data[Form1.List_Send_i, 8] = (byte) 0;
              buffer_Data[3] = Form1.List_Send_Data[Form1.List_Send_i, 9] = (byte) 0;
              buffer_Data[4] = Form1.List_Send_Data[Form1.List_Send_i, 10] = (byte) 0;
              buffer_Data[5] = Form1.List_Send_Data[Form1.List_Send_i, 11] = (byte) 0;
              buffer_Data[6] = Form1.List_Send_Data[Form1.List_Send_i, 12] = (byte) 0;
              buffer_Data[7] = Form1.List_Send_Data[Form1.List_Send_i, 13] = (byte) 0;
            }
            else if (Form1.List_Send_Data[Form1.List_Send_i, 5] == (byte) 3)
            {
              buffer_Data[0] = Form1.List_Send_Data[Form1.List_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.List_Send_Data[Form1.List_Send_i, 7] = (byte) Form1.HEXstr_to_DEC(str2.Substring(3, 2).ToString());
              buffer_Data[2] = Form1.List_Send_Data[Form1.List_Send_i, 8] = (byte) Form1.HEXstr_to_DEC(str2.Substring(6, 2).ToString());
              buffer_Data[3] = Form1.List_Send_Data[Form1.List_Send_i, 9] = (byte) 0;
              buffer_Data[4] = Form1.List_Send_Data[Form1.List_Send_i, 10] = (byte) 0;
              buffer_Data[5] = Form1.List_Send_Data[Form1.List_Send_i, 11] = (byte) 0;
              buffer_Data[6] = Form1.List_Send_Data[Form1.List_Send_i, 12] = (byte) 0;
              buffer_Data[7] = Form1.List_Send_Data[Form1.List_Send_i, 13] = (byte) 0;
            }
            else if (Form1.List_Send_Data[Form1.List_Send_i, 5] == (byte) 4)
            {
              buffer_Data[0] = Form1.List_Send_Data[Form1.List_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.List_Send_Data[Form1.List_Send_i, 7] = (byte) Form1.HEXstr_to_DEC(str2.Substring(3, 2).ToString());
              buffer_Data[2] = Form1.List_Send_Data[Form1.List_Send_i, 8] = (byte) Form1.HEXstr_to_DEC(str2.Substring(6, 2).ToString());
              buffer_Data[3] = Form1.List_Send_Data[Form1.List_Send_i, 9] = (byte) Form1.HEXstr_to_DEC(str2.Substring(9, 2).ToString());
              buffer_Data[4] = Form1.List_Send_Data[Form1.List_Send_i, 10] = (byte) 0;
              buffer_Data[5] = Form1.List_Send_Data[Form1.List_Send_i, 11] = (byte) 0;
              buffer_Data[6] = Form1.List_Send_Data[Form1.List_Send_i, 12] = (byte) 0;
              buffer_Data[7] = Form1.List_Send_Data[Form1.List_Send_i, 13] = (byte) 0;
            }
            else if (Form1.List_Send_Data[Form1.List_Send_i, 5] == (byte) 5)
            {
              buffer_Data[0] = Form1.List_Send_Data[Form1.List_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.List_Send_Data[Form1.List_Send_i, 7] = (byte) Form1.HEXstr_to_DEC(str2.Substring(3, 2).ToString());
              buffer_Data[2] = Form1.List_Send_Data[Form1.List_Send_i, 8] = (byte) Form1.HEXstr_to_DEC(str2.Substring(6, 2).ToString());
              buffer_Data[3] = Form1.List_Send_Data[Form1.List_Send_i, 9] = (byte) Form1.HEXstr_to_DEC(str2.Substring(9, 2).ToString());
              buffer_Data[4] = Form1.List_Send_Data[Form1.List_Send_i, 10] = (byte) Form1.HEXstr_to_DEC(str2.Substring(12, 2).ToString());
              buffer_Data[5] = Form1.List_Send_Data[Form1.List_Send_i, 11] = (byte) 0;
              buffer_Data[6] = Form1.List_Send_Data[Form1.List_Send_i, 12] = (byte) 0;
              buffer_Data[7] = Form1.List_Send_Data[Form1.List_Send_i, 13] = (byte) 0;
            }
            else if (Form1.List_Send_Data[Form1.List_Send_i, 5] == (byte) 6)
            {
              buffer_Data[0] = Form1.List_Send_Data[Form1.List_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.List_Send_Data[Form1.List_Send_i, 7] = (byte) Form1.HEXstr_to_DEC(str2.Substring(3, 2).ToString());
              buffer_Data[2] = Form1.List_Send_Data[Form1.List_Send_i, 8] = (byte) Form1.HEXstr_to_DEC(str2.Substring(6, 2).ToString());
              buffer_Data[3] = Form1.List_Send_Data[Form1.List_Send_i, 9] = (byte) Form1.HEXstr_to_DEC(str2.Substring(9, 2).ToString());
              buffer_Data[4] = Form1.List_Send_Data[Form1.List_Send_i, 10] = (byte) Form1.HEXstr_to_DEC(str2.Substring(12, 2).ToString());
              buffer_Data[5] = Form1.List_Send_Data[Form1.List_Send_i, 11] = (byte) Form1.HEXstr_to_DEC(str2.Substring(15, 2).ToString());
              buffer_Data[6] = Form1.List_Send_Data[Form1.List_Send_i, 12] = (byte) 0;
              buffer_Data[7] = Form1.List_Send_Data[Form1.List_Send_i, 13] = (byte) 0;
            }
            else if (Form1.List_Send_Data[Form1.List_Send_i, 5] == (byte) 7)
            {
              buffer_Data[0] = Form1.List_Send_Data[Form1.List_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.List_Send_Data[Form1.List_Send_i, 7] = (byte) Form1.HEXstr_to_DEC(str2.Substring(3, 2).ToString());
              buffer_Data[2] = Form1.List_Send_Data[Form1.List_Send_i, 8] = (byte) Form1.HEXstr_to_DEC(str2.Substring(6, 2).ToString());
              buffer_Data[3] = Form1.List_Send_Data[Form1.List_Send_i, 9] = (byte) Form1.HEXstr_to_DEC(str2.Substring(9, 2).ToString());
              buffer_Data[4] = Form1.List_Send_Data[Form1.List_Send_i, 10] = (byte) Form1.HEXstr_to_DEC(str2.Substring(12, 2).ToString());
              buffer_Data[5] = Form1.List_Send_Data[Form1.List_Send_i, 11] = (byte) Form1.HEXstr_to_DEC(str2.Substring(15, 2).ToString());
              buffer_Data[6] = Form1.List_Send_Data[Form1.List_Send_i, 12] = (byte) Form1.HEXstr_to_DEC(str2.Substring(18, 2).ToString());
              buffer_Data[7] = Form1.List_Send_Data[Form1.List_Send_i, 13] = (byte) 0;
            }
            else if (Form1.List_Send_Data[Form1.List_Send_i, 5] == (byte) 8)
            {
              buffer_Data[0] = Form1.List_Send_Data[Form1.List_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.List_Send_Data[Form1.List_Send_i, 7] = (byte) Form1.HEXstr_to_DEC(str2.Substring(3, 2).ToString());
              buffer_Data[2] = Form1.List_Send_Data[Form1.List_Send_i, 8] = (byte) Form1.HEXstr_to_DEC(str2.Substring(6, 2).ToString());
              buffer_Data[3] = Form1.List_Send_Data[Form1.List_Send_i, 9] = (byte) Form1.HEXstr_to_DEC(str2.Substring(9, 2).ToString());
              buffer_Data[4] = Form1.List_Send_Data[Form1.List_Send_i, 10] = (byte) Form1.HEXstr_to_DEC(str2.Substring(12, 2).ToString());
              buffer_Data[5] = Form1.List_Send_Data[Form1.List_Send_i, 11] = (byte) Form1.HEXstr_to_DEC(str2.Substring(15, 2).ToString());
              buffer_Data[6] = Form1.List_Send_Data[Form1.List_Send_i, 12] = (byte) Form1.HEXstr_to_DEC(str2.Substring(18, 2).ToString());
              buffer_Data[7] = Form1.List_Send_Data[Form1.List_Send_i, 13] = (byte) Form1.HEXstr_to_DEC(str2.Substring(21, 2).ToString());
            }
            else
            {
              buffer_Data[0] = Form1.List_Send_Data[Form1.List_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.List_Send_Data[Form1.List_Send_i, 7] = (byte) Form1.HEXstr_to_DEC(str2.Substring(3, 2).ToString());
              buffer_Data[2] = Form1.List_Send_Data[Form1.List_Send_i, 8] = (byte) Form1.HEXstr_to_DEC(str2.Substring(6, 2).ToString());
              buffer_Data[3] = Form1.List_Send_Data[Form1.List_Send_i, 9] = (byte) Form1.HEXstr_to_DEC(str2.Substring(9, 2).ToString());
              buffer_Data[4] = Form1.List_Send_Data[Form1.List_Send_i, 10] = (byte) Form1.HEXstr_to_DEC(str2.Substring(12, 2).ToString());
              buffer_Data[5] = Form1.List_Send_Data[Form1.List_Send_i, 11] = (byte) Form1.HEXstr_to_DEC(str2.Substring(15, 2).ToString());
              buffer_Data[6] = Form1.List_Send_Data[Form1.List_Send_i, 12] = (byte) Form1.HEXstr_to_DEC(str2.Substring(18, 2).ToString());
              buffer_Data[7] = Form1.List_Send_Data[Form1.List_Send_i, 13] = (byte) Form1.HEXstr_to_DEC(str2.Substring(21, 2).ToString());
            }
          }
          catch
          {
            init_Configuration.Output_Message = $"第{index.ToString()}行数据内容不正确！";
            int num2 = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          Form1.List_Send_Data[Form1.List_Send_i, 14] = Form1.LINCalcChecksum(Form1.List_Send_Data[Form1.List_Send_i, 2], buffer_Data, Form1.List_Send_Data[Form1.List_Send_i, 5]);
          Form1.List_time_value[Form1.List_Send_i, 0] = (int) Convert.ToInt16(((DataGridView) this.dataGridViewX1).Rows[index].Cells[6].Value.ToString());
          ++Form1.List_Send_i;
        }
        else
        {
          Form1.List_Send_Data[Form1.List_Send_i, 0] = (byte) 51;
          Form1.List_Send_Data[Form1.List_Send_i, 1] = (byte) 1;
          Form1.List_Send_Data[Form1.List_Send_i, 2] = (byte) Form1.HEXstr_to_DEC(((DataGridView) this.dataGridViewX1).Rows[index].Cells[3].Value.ToString());
          Form1.List_Send_Data[Form1.List_Send_i, 3] = (byte) 1;
          Form1.List_EN[index, 0] = (byte) 1;
          Form1.List_EN[index, 1] = (byte) 1;
          Form1.List_Send_Data[Form1.List_Send_i, 4] = !(Form1.CheckSum_Type == "增强型校验和") ? (byte) 1 : (byte) 2;
          Form1.List_Send_Data[Form1.List_Send_i, 5] = (byte) Convert.ToInt16(((DataGridView) this.dataGridViewX1).Rows[index].Cells[5].Value.ToString());
          Form1.List_time_value[Form1.List_Send_i, 0] = (int) Convert.ToInt16(((DataGridView) this.dataGridViewX1).Rows[index].Cells[6].Value.ToString());
          ++Form1.List_Send_i;
        }
        ++num1;
      }
    }
    Form1.List_fixed_i = 0;
    try
    {
      if (Convert.ToInt32(this.qqTextBox51.Text) == 0)
      {
        Form1.List_send_fixed_number = 0;
        Form1.List_send_fixed_flag = false;
      }
      else
      {
        if (Convert.ToInt32(this.qqTextBox51.Text) > (int) ushort.MaxValue)
        {
          init_Configuration.Output_Message = "最大65535帧！";
          int num3 = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        Form1.List_send_fixed_number = Convert.ToInt32(this.qqTextBox51.Text);
        Form1.List_send_fixed_flag = true;
      }
    }
    catch
    {
      init_Configuration.Output_Message = "输入帧数格式不正确！";
      int num4 = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    if (num1 == 0)
    {
      init_Configuration.Output_Message = "请使能任意一个通道！";
      int num5 = (int) init_Configuration.PDF_Interface.ShowDialog();
    }
    else
    {
      this.imageButton2.Enabled = false;
      this.imageButton4.Enabled = false;
      this.qqRadioButton3.Enabled = false;
      this.qqRadioButton4.Enabled = false;
      this.qqRadioButton5.Enabled = false;
      this.qqRadioButton6.Enabled = false;
      this.qqTextBox10.Enabled = false;
      this.qqTextBox17.Enabled = false;
      this.imageButton5.Enabled = false;
      this.imageButton6.Enabled = false;
      this.imageButton7.Enabled = false;
      this.imageButton8.Enabled = false;
      ((DataGridView) this.dataGridViewX1).Columns[0].ReadOnly = true;
      ((DataGridView) this.dataGridViewX1).Columns[1].ReadOnly = true;
      ((DataGridView) this.dataGridViewX1).Columns[2].ReadOnly = true;
      ((DataGridView) this.dataGridViewX1).Columns[3].ReadOnly = true;
      ((DataGridView) this.dataGridViewX1).Columns[5].ReadOnly = true;
      ((DataGridView) this.dataGridViewX1).Columns[6].ReadOnly = true;
      ((DataGridView) this.dataGridViewX1).Columns[0].DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
      ((DataGridView) this.dataGridViewX1).Columns[1].DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
      ((DataGridView) this.dataGridViewX1).Columns[2].DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
      ((DataGridView) this.dataGridViewX1).Columns[3].DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
      ((DataGridView) this.dataGridViewX1).Columns[5].DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
      ((DataGridView) this.dataGridViewX1).Columns[6].DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
      this.dS按钮1.Enabled = false;
      this.dS按钮2.Enabled = true;
      this.imageButton10.Enabled = false;
      this.dS按钮1.贴图 = Resources.运行9;
      this.dS按钮2.贴图 = Resources.停止8;
      this.qqTextBox51.Enabled = false;
      ((Control) this.dataGridViewX2).Enabled = false;
      this.dS按钮3.Enabled = false;
      this.dS按钮4.Enabled = false;
      this.imageButton12.Enabled = false;
      this.dS按钮3.贴图 = Resources.运行9;
      this.dS按钮4.贴图 = Resources.停止8;
      this.qqCheckBox7.Enabled = false;
      this.qqCheckBox8.Enabled = false;
      this.qqCheckBox9.Enabled = false;
      this.qqCheckBox10.Enabled = false;
      this.qqCheckBox11.Enabled = false;
      this.qqCheckBox12.Enabled = false;
      this.qqCheckBox13.Enabled = false;
      this.qqCheckBox14.Enabled = false;
      this.qqCheckBox15.Enabled = false;
      this.qqCheckBox16.Enabled = false;
      this.qqCheckBox17.Enabled = false;
      this.qqCheckBox18.Enabled = false;
      this.qqTextBox18.Enabled = false;
      this.qqTextBox19.Enabled = false;
      this.qqTextBox20.Enabled = false;
      this.qqTextBox21.Enabled = false;
      this.qqTextBox22.Enabled = false;
      this.qqTextBox23.Enabled = false;
      this.qqTextBox24.Enabled = false;
      this.qqTextBox25.Enabled = false;
      this.qqTextBox26.Enabled = false;
      this.qqTextBox27.Enabled = false;
      this.qqTextBox28.Enabled = false;
      this.qqTextBox29.Enabled = false;
      this.imageButton14.Enabled = false;
      this.qqRadioButton11.Enabled = false;
      this.qqRadioButton12.Enabled = false;
      this.dS按钮5.贴图 = Resources.运行9;
      this.dS按钮5.Enabled = false;
      this.dS按钮6.Enabled = false;
      this.dS按钮6.贴图 = Resources.停止8;
      this.myButton5.Enabled = false;
      this.myButton5.NormalImage = (Image) Resources.down;
      Form1.BOOT_ON_flag = false;
      this.dS按钮9.Enabled = false;
      this.dS按钮10.贴图 = Resources.按钮3;
      this.dS按钮11.贴图 = Resources.灯6;
      this.dS按钮10.Enabled = false;
      this.dS按钮11.Enabled = false;
      this.imageButton15.Enabled = false;
      this.imageButton16.Enabled = true;
      this.imageButton17.Enabled = false;
      this.dS按钮13.Enabled = false;
      this.dS按钮13.贴图 = Resources.运行9;
      this.myButton1.Enabled = false;
      this.dS按钮15.Enabled = false;
      this.dS按钮15.贴图 = Resources.运行9;
      this.dS按钮14.Enabled = false;
      this.dS按钮14.贴图 = Resources.停止9;
      this.myButton3.Enabled = false;
      this.myButton2.Enabled = false;
      this.dS按钮17.Enabled = false;
      this.dS按钮16.Enabled = false;
      this.dS按钮17.贴图 = Resources.运行9;
      this.dS按钮16.贴图 = Resources.停止9;
      Array.Clear((Array) Form1.LI_Static_Save, 0, Form1.LI_Static_Save.Length);
      Form1.LI_Static_i = 0;
      Form1.mode2_Save_Task_flag = false;
      Form1.List_Send_flag = true;
      this.List_Send_Task();
      this.RTOS_Save_mode2_Asynchronous();
    }
  }

  private void dS按钮2_ButtonClick(object Sender)
  {
    Form1.List_Send_flag = false;
    if (Form1.List_send_fixed_flag)
      return;
    this.qqTextBox51.Enabled = true;
    this.imageButton2.Enabled = true;
    this.imageButton4.Enabled = true;
    this.qqRadioButton3.Enabled = true;
    this.qqRadioButton4.Enabled = true;
    this.qqRadioButton5.Enabled = true;
    this.qqRadioButton6.Enabled = true;
    this.qqTextBox10.Enabled = true;
    this.qqTextBox17.Enabled = true;
    this.imageButton5.Enabled = true;
    this.imageButton6.Enabled = false;
    this.imageButton7.Enabled = true;
    this.imageButton8.Enabled = false;
    ((DataGridView) this.dataGridViewX1).Columns[0].ReadOnly = false;
    ((DataGridView) this.dataGridViewX1).Columns[1].ReadOnly = false;
    ((DataGridView) this.dataGridViewX1).Columns[2].ReadOnly = false;
    ((DataGridView) this.dataGridViewX1).Columns[3].ReadOnly = false;
    ((DataGridView) this.dataGridViewX1).Columns[5].ReadOnly = false;
    ((DataGridView) this.dataGridViewX1).Columns[6].ReadOnly = false;
    ((DataGridView) this.dataGridViewX1).Columns[0].DefaultCellStyle.BackColor = SystemColors.Window;
    ((DataGridView) this.dataGridViewX1).Columns[1].DefaultCellStyle.BackColor = SystemColors.Window;
    ((DataGridView) this.dataGridViewX1).Columns[2].DefaultCellStyle.BackColor = SystemColors.Window;
    ((DataGridView) this.dataGridViewX1).Columns[3].DefaultCellStyle.BackColor = SystemColors.Window;
    ((DataGridView) this.dataGridViewX1).Columns[5].DefaultCellStyle.BackColor = SystemColors.Window;
    ((DataGridView) this.dataGridViewX1).Columns[6].DefaultCellStyle.BackColor = SystemColors.Window;
    this.dS按钮1.Enabled = true;
    this.dS按钮2.Enabled = false;
    this.imageButton10.Enabled = true;
    this.dS按钮1.贴图 = Resources.运行8;
    this.dS按钮2.贴图 = Resources.停止9;
    ((Control) this.dataGridViewX2).Enabled = true;
    this.dS按钮3.Enabled = true;
    this.dS按钮4.Enabled = false;
    this.imageButton12.Enabled = true;
    this.dS按钮3.贴图 = Resources.运行8;
    this.dS按钮4.贴图 = Resources.停止8;
    this.dS按钮6.贴图 = Resources.停止8;
    this.qqCheckBox7.Enabled = true;
    this.qqCheckBox8.Enabled = true;
    this.qqCheckBox9.Enabled = true;
    this.qqCheckBox10.Enabled = true;
    this.qqCheckBox11.Enabled = true;
    this.qqCheckBox12.Enabled = true;
    this.qqCheckBox13.Enabled = true;
    this.qqCheckBox14.Enabled = true;
    this.qqCheckBox15.Enabled = true;
    this.qqCheckBox16.Enabled = true;
    this.qqCheckBox17.Enabled = true;
    this.qqCheckBox18.Enabled = true;
    this.qqTextBox18.Enabled = true;
    this.qqTextBox19.Enabled = true;
    this.qqTextBox20.Enabled = true;
    this.qqTextBox21.Enabled = true;
    this.qqTextBox22.Enabled = true;
    this.qqTextBox23.Enabled = true;
    this.qqTextBox24.Enabled = true;
    this.qqTextBox25.Enabled = true;
    this.qqTextBox26.Enabled = true;
    this.qqTextBox27.Enabled = true;
    this.qqTextBox28.Enabled = true;
    this.qqTextBox29.Enabled = true;
    this.imageButton14.Enabled = true;
    this.qqRadioButton11.Enabled = true;
    this.qqRadioButton12.Enabled = true;
    this.dS按钮5.Enabled = true;
    this.dS按钮6.Enabled = false;
    this.dS按钮5.贴图 = Resources.运行8;
    this.myButton5.Enabled = true;
    this.myButton5.NormalImage = (Image) Resources.btn_green_normal;
    Form1.BOOT_ON_flag = false;
    this.dS按钮9.Enabled = true;
    this.dS按钮10.贴图 = Resources.按钮3;
    this.dS按钮11.贴图 = Resources.灯6;
    this.dS按钮10.Enabled = true;
    this.dS按钮11.Enabled = true;
    this.imageButton15.Enabled = true;
    this.imageButton16.Enabled = true;
    this.imageButton17.Enabled = true;
    this.dS按钮13.Enabled = false;
    this.dS按钮13.贴图 = Resources.运行9;
    this.myButton1.Enabled = true;
    this.dS按钮15.Enabled = true;
    this.dS按钮15.贴图 = Resources.运行8;
    this.dS按钮14.Enabled = false;
    this.dS按钮14.贴图 = Resources.停止9;
    this.myButton3.Enabled = true;
    this.myButton2.Enabled = true;
    this.dS按钮17.Enabled = true;
    this.dS按钮16.Enabled = false;
    this.dS按钮17.贴图 = Resources.运行8;
    this.dS按钮16.贴图 = Resources.停止9;
  }

  private void imageButton11_Click(object sender, EventArgs e)
  {
    lock (Form1.locker)
    {
      this.listViewNF3.Items.Clear();
      Array.Clear((Array) Form1.Slave_Mode_Data, 0, Form1.Slave_Mode_Data.Length);
      Form1.Set_value(Form1.Slave_Static, byte.MaxValue, Form1.Slave_Static.Length);
      Array.Clear((Array) Form1.Slave_time, 0, Form1.Slave_time.Length);
      Form1.RX_count = 0;
      Form1.RX_Save_count = 0;
      Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
      Form1.Slave_count = 0;
      Form1.Slave_Display_count = 0;
      Form1.mode3_Save_Task_i = 0;
    }
  }

  private void imageButton12_Click(object sender, EventArgs e)
  {
    Array.Clear((Array) Form1.S_Static_Save, 0, Form1.S_Static_Save.Length);
    Form1.S_Static_i = 0;
    if (this.listViewNF3.Items.Count == 0)
    {
      init_Configuration.Output_Message = "无数据可保存！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
    }
    else
    {
      if (Form1.Slave_Display_Mode)
      {
        for (int index = 0; index < this.listViewNF3.Items.Count; ++index)
        {
          Form1.S_Static_Save[index, 0] = this.listViewNF3.Items[index].SubItems[0].Text;
          Form1.S_Static_Save[index, 1] = this.listViewNF3.Items[index].SubItems[1].Text;
          Form1.S_Static_Save[index, 2] = this.listViewNF3.Items[index].SubItems[2].Text;
          Form1.S_Static_Save[index, 3] = this.listViewNF3.Items[index].SubItems[3].Text;
          Form1.S_Static_Save[index, 4] = this.listViewNF3.Items[index].SubItems[4].Text;
          Form1.S_Static_Save[index, 5] = this.listViewNF3.Items[index].SubItems[5].Text;
          Form1.S_Static_Save[index, 6] = this.listViewNF3.Items[index].SubItems[6].Text;
          Form1.S_Static_Save[index, 7] = this.listViewNF3.Items[index].SubItems[7].Text;
          Form1.S_Static_Save[index, 8] = this.listViewNF3.Items[index].SubItems[8].Text;
          ++Form1.S_Static_i;
        }
        this.progressBarEx1.Value = 0;
        this.progressBarEx1.Maximum = Form1.S_Static_i;
        this.progressBarEx1.Text = "0%";
      }
      else
      {
        this.progressBarEx1.Value = 0;
        this.progressBarEx1.Maximum = Form1.Slave_count;
        this.progressBarEx1.Text = "0%";
      }
      this.saveFileDialog3.Title = "另存为";
      this.saveFileDialog3.FileName = "Data for 1";
      this.saveFileDialog3.Filter = "CSV File(*.csv)|*.csv";
      this.saveFileDialog3.ShowHelp = false;
      this.saveFileDialog3.OverwritePrompt = true;
      this.saveFileDialog3.SupportMultiDottedExtensions = false;
      if (this.saveFileDialog3.ShowDialog() != DialogResult.OK)
        return;
      Form1.Save_FileName_str = this.saveFileDialog3.FileName;
      this.imageButton2.Enabled = false;
      this.imageButton4.Enabled = false;
      this.qqRadioButton3.Enabled = false;
      this.qqRadioButton4.Enabled = false;
      this.qqRadioButton5.Enabled = false;
      this.qqRadioButton6.Enabled = false;
      this.qqTextBox10.Enabled = false;
      this.qqTextBox17.Enabled = false;
      this.imageButton5.Enabled = false;
      this.imageButton6.Enabled = false;
      this.imageButton7.Enabled = false;
      this.imageButton8.Enabled = false;
      this.dS按钮1.Enabled = false;
      this.dS按钮2.Enabled = false;
      this.imageButton10.Enabled = false;
      this.dS按钮1.贴图 = Resources.运行8;
      this.dS按钮2.贴图 = Resources.停止8;
      ((Control) this.dataGridViewX2).Enabled = false;
      this.dS按钮3.Enabled = false;
      this.dS按钮4.Enabled = false;
      this.imageButton11.Enabled = false;
      this.imageButton12.Enabled = false;
      this.dS按钮3.贴图 = Resources.运行8;
      this.dS按钮4.贴图 = Resources.停止8;
      this.qqCheckBox7.Enabled = false;
      this.qqCheckBox8.Enabled = false;
      this.qqCheckBox9.Enabled = false;
      this.qqCheckBox10.Enabled = false;
      this.qqCheckBox11.Enabled = false;
      this.qqCheckBox12.Enabled = false;
      this.qqCheckBox13.Enabled = false;
      this.qqCheckBox14.Enabled = false;
      this.qqCheckBox15.Enabled = false;
      this.qqCheckBox16.Enabled = false;
      this.qqCheckBox17.Enabled = false;
      this.qqCheckBox18.Enabled = false;
      this.qqTextBox18.Enabled = false;
      this.qqTextBox19.Enabled = false;
      this.qqTextBox20.Enabled = false;
      this.qqTextBox21.Enabled = false;
      this.qqTextBox22.Enabled = false;
      this.qqTextBox23.Enabled = false;
      this.qqTextBox24.Enabled = false;
      this.qqTextBox25.Enabled = false;
      this.qqTextBox26.Enabled = false;
      this.qqTextBox27.Enabled = false;
      this.qqTextBox28.Enabled = false;
      this.qqTextBox29.Enabled = false;
      this.qqRadioButton13.Enabled = false;
      this.qqRadioButton14.Enabled = false;
      this.imageButton14.Enabled = false;
      this.qqRadioButton11.Enabled = false;
      this.qqRadioButton12.Enabled = false;
      this.imageButton13.Enabled = false;
      this.dS按钮5.贴图 = Resources.运行8;
      this.dS按钮5.Enabled = false;
      this.dS按钮6.Enabled = false;
      this.dS按钮6.贴图 = Resources.停止8;
      this.myButton5.Enabled = false;
      this.myButton5.NormalImage = (Image) Resources.down;
      Form1.BOOT_ON_flag = false;
      this.dS按钮9.Enabled = false;
      this.dS按钮10.贴图 = Resources.按钮3;
      this.dS按钮11.贴图 = Resources.灯6;
      this.dS按钮10.Enabled = false;
      this.dS按钮11.Enabled = false;
      this.imageButton15.Enabled = false;
      this.imageButton16.Enabled = true;
      this.imageButton17.Enabled = false;
      this.dS按钮13.Enabled = false;
      this.dS按钮13.贴图 = Resources.运行9;
      this.myButton1.Enabled = false;
      this.dS按钮15.Enabled = false;
      this.dS按钮15.贴图 = Resources.运行9;
      this.dS按钮14.Enabled = false;
      this.dS按钮14.贴图 = Resources.停止9;
      this.myButton3.Enabled = false;
      this.myButton2.Enabled = false;
      this.dS按钮17.Enabled = false;
      this.dS按钮16.Enabled = false;
      this.dS按钮17.贴图 = Resources.运行9;
      this.dS按钮16.贴图 = Resources.停止9;
      Form1.Save_ProgressBar_i = 0;
      Form1.Save_Finish_flag = false;
      Form1.Exit_Save_listViewNF3_flag = false;
      this.Save_listViewNF3_Thread = new Thread(new ThreadStart(this.Save_listViewNF3_Data));
      this.Save_listViewNF3_Thread.IsBackground = true;
      this.Save_listViewNF3_Thread.Start();
      this.Save_listViewNF3_Asynchronous();
    }
  }

  private void qqRadioButton9_CheckedChanged(object sender, EventArgs e)
  {
    if (this.qqRadioButton9.Checked)
    {
      lock (Form1.locker)
      {
        this.listViewNF3.Items.Clear();
        Array.Clear((Array) Form1.Slave_Mode_Data, 0, Form1.Slave_Mode_Data.Length);
        Form1.Set_value(Form1.Slave_Static, byte.MaxValue, Form1.Slave_Static.Length);
        Array.Clear((Array) Form1.Slave_time, 0, Form1.Slave_time.Length);
        Form1.RX_count = 0;
        Form1.RX_Save_count = 0;
        Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
        Form1.Slave_count = 0;
        Form1.Slave_Display_count = 0;
        Form1.Slave_Display_Mode = false;
        Form1.mode3_Save_Task_i = 0;
      }
    }
    else
    {
      lock (Form1.locker)
      {
        this.listViewNF3.Items.Clear();
        Array.Clear((Array) Form1.Slave_Mode_Data, 0, Form1.Slave_Mode_Data.Length);
        Array.Clear((Array) Form1.Slave_time, 0, Form1.Slave_time.Length);
        Form1.RX_count = 0;
        Form1.RX_Save_count = 0;
        Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
        Form1.Slave_count = 0;
        Form1.Slave_Display_count = 0;
        Form1.Slave_Display_Mode = true;
        Form1.mode3_Save_Task_i = 0;
      }
    }
  }

  private void dS按钮3_ButtonClick(object Sender)
  {
    string str1 = "";
    byte[] buffer_Data = new byte[8];
    Form1.Exit_RTOS_Save_mode3_flag = false;
    Form1.RX_count = 0;
    Form1.RX_Save_count = 0;
    Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
    for (int index = 0; index < 16 /*0x10*/; ++index)
    {
      if (((DataGridView) this.dataGridViewX2).Rows[index].Cells[0].Value.ToString() == "True")
      {
        try
        {
          if ((byte) Form1.HEXstr_to_DEC(((DataGridView) this.dataGridViewX2).Rows[index].Cells[3].Value.ToString()) > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = $"第{index.ToString()}行ID超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = $"第{index.ToString()}行ID格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        int int16;
        try
        {
          int16 = (int) (byte) Convert.ToInt16(((DataGridView) this.dataGridViewX2).Rows[index].Cells[5].Value.ToString());
          if (int16 > 8 || int16 == 0)
          {
            init_Configuration.Output_Message = $"第{index.ToString()}行数据长度超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        catch
        {
          init_Configuration.Output_Message = $"第{index.ToString()}行数据长度格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        try
        {
          if (((DataGridView) this.dataGridViewX2).Rows[index].Cells[2].Value.ToString() == "发送")
          {
            if (((DataGridView) this.dataGridViewX2).Rows[index].Cells[4].Value.ToString().Length < int16 * 3 - 1)
            {
              init_Configuration.Output_Message = $"第{index.ToString()}行数据格式不正确！";
              int num = (int) init_Configuration.PDF_Interface.ShowDialog();
              return;
            }
          }
        }
        catch
        {
          init_Configuration.Output_Message = $"第{index.ToString()}行数据格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
    }
    if (this.qqRadioButton9.Checked)
    {
      lock (Form1.locker)
      {
        this.listViewNF3.Items.Clear();
        Array.Clear((Array) Form1.Slave_Mode_Data, 0, Form1.Slave_Mode_Data.Length);
        Array.Clear((Array) Form1.Slave_EN, 0, Form1.Slave_EN.Length);
        Form1.Set_value(Form1.Slave_Static, byte.MaxValue, Form1.Slave_Static.Length);
        Array.Clear((Array) Form1.Slave_time, 0, Form1.Slave_time.Length);
        Form1.Slave_count = 0;
        Form1.Slave_Display_count = 0;
        Form1.Slave_Display_Mode = false;
      }
    }
    else
    {
      lock (Form1.locker)
      {
        this.listViewNF3.Items.Clear();
        Array.Clear((Array) Form1.Slave_Mode_Data, 0, Form1.Slave_Mode_Data.Length);
        Array.Clear((Array) Form1.Slave_EN, 0, Form1.Slave_EN.Length);
        Form1.Set_value(Form1.Slave_Static, byte.MaxValue, Form1.Slave_Static.Length);
        Array.Clear((Array) Form1.Slave_time, 0, Form1.Slave_time.Length);
        Form1.Slave_count = 0;
        Form1.Slave_Display_count = 0;
        Form1.Slave_Display_Mode = true;
      }
    }
    Form1.Slave_Send_i = 0;
    int num1 = 0;
    Array.Clear((Array) Form1.Slave_Send_Data, 0, Form1.Slave_Send_Data.Length);
    Form1.Slave_Send_Data[Form1.Slave_Send_i, 0] = (byte) 17;
    Form1.Slave_Send_Data[Form1.Slave_Send_i, 1] = (byte) 0;
    Form1.Slave_Send_Data[Form1.Slave_Send_i, 2] = (byte) ((Form1.Baud_rate & 65280) >> 8);
    Form1.Slave_Send_Data[Form1.Slave_Send_i, 3] = (byte) (Form1.Baud_rate & (int) byte.MaxValue);
    Form1.Slave_Send_Data[Form1.Slave_Send_i, 4] = (byte) Form1.Volume_value;
    Form1.Slave_Send_Data[Form1.Slave_Send_i, 5] = (byte) ((Form1.Line_time & 65280) >> 8);
    Form1.Slave_Send_Data[Form1.Slave_Send_i, 6] = (byte) (Form1.Line_time & (int) byte.MaxValue);
    for (int index = 0; index < 8; ++index)
      Form1.Slave_Send_Data[Form1.Slave_Send_i, index + 7] = (byte) 0;
    ++Form1.Slave_Send_i;
    Form1.Slave_Send_Data[Form1.Slave_Send_i, 0] = (byte) 17;
    Form1.Slave_Send_Data[Form1.Slave_Send_i, 1] = (byte) 2;
    Form1.Slave_Send_Data[Form1.Slave_Send_i, 2] = (byte) ((Form1.Baud_rate & 65280) >> 8);
    Form1.Slave_Send_Data[Form1.Slave_Send_i, 3] = (byte) (Form1.Baud_rate & (int) byte.MaxValue);
    Form1.Slave_Send_Data[Form1.Slave_Send_i, 4] = (byte) Form1.Volume_value;
    Form1.Slave_Send_Data[Form1.Slave_Send_i, 5] = (byte) ((Form1.Line_time & 65280) >> 8);
    Form1.Slave_Send_Data[Form1.Slave_Send_i, 6] = (byte) (Form1.Line_time & (int) byte.MaxValue);
    for (int index = 0; index < 8; ++index)
      Form1.Slave_Send_Data[Form1.Slave_Send_i, index + 7] = (byte) 0;
    ++Form1.Slave_Send_i;
    for (int index = 0; index < 16 /*0x10*/; ++index)
    {
      if (((DataGridView) this.dataGridViewX2).Rows[index].Cells[0].Value.ToString() == "True")
      {
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 0] = (byte) 85;
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 1] = (byte) Convert.ToInt16(((DataGridView) this.dataGridViewX2).Rows[index].Cells[1].Value.ToString());
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 2] = (byte) Form1.HEXstr_to_DEC(((DataGridView) this.dataGridViewX2).Rows[index].Cells[3].Value.ToString());
        if (((DataGridView) this.dataGridViewX2).Rows[index].Cells[2].Value.ToString() == "发送")
        {
          Form1.Slave_Send_Data[Form1.Slave_Send_i, 3] = (byte) 0;
          Form1.Slave_EN[index, 0] = (byte) 1;
          Form1.Slave_EN[index, 1] = (byte) 0;
        }
        else
        {
          Form1.Slave_Send_Data[Form1.Slave_Send_i, 3] = (byte) 1;
          Form1.Slave_EN[index, 0] = (byte) 1;
          Form1.Slave_EN[index, 1] = (byte) 1;
        }
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 4] = !(((DataGridView) this.dataGridViewX2).Rows[index].Cells[6].Value.ToString() == "增强型校验和") ? (byte) 1 : (byte) 2;
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 5] = (byte) Convert.ToInt16(((DataGridView) this.dataGridViewX2).Rows[index].Cells[5].Value.ToString());
        try
        {
          if (((DataGridView) this.dataGridViewX2).Rows[index].Cells[2].Value.ToString() == "发送")
          {
            str1 = "";
            string str2 = ((DataGridView) this.dataGridViewX2).Rows[index].Cells[4].Value.ToString();
            if (Form1.Slave_Send_Data[Form1.Slave_Send_i, 5] == (byte) 1)
            {
              buffer_Data[0] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 7] = (byte) 0;
              buffer_Data[2] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 8] = (byte) 0;
              buffer_Data[3] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 9] = (byte) 0;
              buffer_Data[4] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 10] = (byte) 0;
              buffer_Data[5] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 11] = (byte) 0;
              buffer_Data[6] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 12] = (byte) 0;
              buffer_Data[7] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 13] = (byte) 0;
            }
            else if (Form1.Slave_Send_Data[Form1.Slave_Send_i, 5] == (byte) 2)
            {
              buffer_Data[0] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 7] = (byte) Form1.HEXstr_to_DEC(str2.Substring(3, 2).ToString());
              buffer_Data[2] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 8] = (byte) 0;
              buffer_Data[3] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 9] = (byte) 0;
              buffer_Data[4] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 10] = (byte) 0;
              buffer_Data[5] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 11] = (byte) 0;
              buffer_Data[6] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 12] = (byte) 0;
              buffer_Data[7] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 13] = (byte) 0;
            }
            else if (Form1.Slave_Send_Data[Form1.Slave_Send_i, 5] == (byte) 3)
            {
              buffer_Data[0] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 7] = (byte) Form1.HEXstr_to_DEC(str2.Substring(3, 2).ToString());
              buffer_Data[2] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 8] = (byte) Form1.HEXstr_to_DEC(str2.Substring(6, 2).ToString());
              buffer_Data[3] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 9] = (byte) 0;
              buffer_Data[4] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 10] = (byte) 0;
              buffer_Data[5] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 11] = (byte) 0;
              buffer_Data[6] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 12] = (byte) 0;
              buffer_Data[7] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 13] = (byte) 0;
            }
            else if (Form1.Slave_Send_Data[Form1.Slave_Send_i, 5] == (byte) 4)
            {
              buffer_Data[0] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 7] = (byte) Form1.HEXstr_to_DEC(str2.Substring(3, 2).ToString());
              buffer_Data[2] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 8] = (byte) Form1.HEXstr_to_DEC(str2.Substring(6, 2).ToString());
              buffer_Data[3] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 9] = (byte) Form1.HEXstr_to_DEC(str2.Substring(9, 2).ToString());
              buffer_Data[4] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 10] = (byte) 0;
              buffer_Data[5] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 11] = (byte) 0;
              buffer_Data[6] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 12] = (byte) 0;
              buffer_Data[7] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 13] = (byte) 0;
            }
            else if (Form1.Slave_Send_Data[Form1.Slave_Send_i, 5] == (byte) 5)
            {
              buffer_Data[0] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 7] = (byte) Form1.HEXstr_to_DEC(str2.Substring(3, 2).ToString());
              buffer_Data[2] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 8] = (byte) Form1.HEXstr_to_DEC(str2.Substring(6, 2).ToString());
              buffer_Data[3] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 9] = (byte) Form1.HEXstr_to_DEC(str2.Substring(9, 2).ToString());
              buffer_Data[4] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 10] = (byte) Form1.HEXstr_to_DEC(str2.Substring(12, 2).ToString());
              buffer_Data[5] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 11] = (byte) 0;
              buffer_Data[6] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 12] = (byte) 0;
              buffer_Data[7] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 13] = (byte) 0;
            }
            else if (Form1.Slave_Send_Data[Form1.Slave_Send_i, 5] == (byte) 6)
            {
              buffer_Data[0] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 7] = (byte) Form1.HEXstr_to_DEC(str2.Substring(3, 2).ToString());
              buffer_Data[2] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 8] = (byte) Form1.HEXstr_to_DEC(str2.Substring(6, 2).ToString());
              buffer_Data[3] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 9] = (byte) Form1.HEXstr_to_DEC(str2.Substring(9, 2).ToString());
              buffer_Data[4] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 10] = (byte) Form1.HEXstr_to_DEC(str2.Substring(12, 2).ToString());
              buffer_Data[5] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 11] = (byte) Form1.HEXstr_to_DEC(str2.Substring(15, 2).ToString());
              buffer_Data[6] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 12] = (byte) 0;
              buffer_Data[7] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 13] = (byte) 0;
            }
            else if (Form1.Slave_Send_Data[Form1.Slave_Send_i, 5] == (byte) 7)
            {
              buffer_Data[0] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 7] = (byte) Form1.HEXstr_to_DEC(str2.Substring(3, 2).ToString());
              buffer_Data[2] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 8] = (byte) Form1.HEXstr_to_DEC(str2.Substring(6, 2).ToString());
              buffer_Data[3] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 9] = (byte) Form1.HEXstr_to_DEC(str2.Substring(9, 2).ToString());
              buffer_Data[4] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 10] = (byte) Form1.HEXstr_to_DEC(str2.Substring(12, 2).ToString());
              buffer_Data[5] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 11] = (byte) Form1.HEXstr_to_DEC(str2.Substring(15, 2).ToString());
              buffer_Data[6] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 12] = (byte) Form1.HEXstr_to_DEC(str2.Substring(18, 2).ToString());
              buffer_Data[7] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 13] = (byte) 0;
            }
            else
            {
              buffer_Data[0] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(0, 2).ToString());
              buffer_Data[1] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 7] = (byte) Form1.HEXstr_to_DEC(str2.Substring(3, 2).ToString());
              buffer_Data[2] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 8] = (byte) Form1.HEXstr_to_DEC(str2.Substring(6, 2).ToString());
              buffer_Data[3] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 9] = (byte) Form1.HEXstr_to_DEC(str2.Substring(9, 2).ToString());
              buffer_Data[4] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 10] = (byte) Form1.HEXstr_to_DEC(str2.Substring(12, 2).ToString());
              buffer_Data[5] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 11] = (byte) Form1.HEXstr_to_DEC(str2.Substring(15, 2).ToString());
              buffer_Data[6] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 12] = (byte) Form1.HEXstr_to_DEC(str2.Substring(18, 2).ToString());
              buffer_Data[7] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 13] = (byte) Form1.HEXstr_to_DEC(str2.Substring(21, 2).ToString());
            }
          }
          else
          {
            buffer_Data[0] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 6] = (byte) 0;
            buffer_Data[1] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 7] = (byte) 0;
            buffer_Data[2] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 8] = (byte) 0;
            buffer_Data[3] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 9] = (byte) 0;
            buffer_Data[4] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 10] = (byte) 0;
            buffer_Data[5] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 11] = (byte) 0;
            buffer_Data[6] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 12] = (byte) 0;
            buffer_Data[7] = Form1.Slave_Send_Data[Form1.Slave_Send_i, 13] = (byte) 0;
          }
        }
        catch
        {
          init_Configuration.Output_Message = $"第{index.ToString()}行数据格式不正确！";
          int num2 = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 14] = Form1.LINCalcChecksum(Form1.Slave_Send_Data[Form1.Slave_Send_i, 2], buffer_Data, Form1.Slave_Send_Data[Form1.Slave_Send_i, 5]);
        ++Form1.Slave_Send_i;
      }
    }
    for (int index = 0; index < 16 /*0x10*/; ++index)
    {
      if (((DataGridView) this.dataGridViewX2).Rows[index].Cells[0].Value.ToString() == "True")
      {
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 0] = (byte) 102;
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 1] = (byte) Convert.ToInt16(((DataGridView) this.dataGridViewX2).Rows[index].Cells[1].Value.ToString());
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 2] = (byte) 1;
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 3] = (byte) 0;
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 4] = (byte) 0;
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 5] = (byte) 0;
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 6] = (byte) 0;
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 7] = (byte) 0;
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 8] = (byte) 0;
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 9] = (byte) 0;
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 10] = (byte) 0;
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 11] = (byte) 0;
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 12] = (byte) 0;
        Form1.Slave_Send_Data[Form1.Slave_Send_i, 13] = (byte) 0;
        ++Form1.Slave_Send_i;
        ++num1;
      }
    }
    if (num1 == 0)
    {
      init_Configuration.Output_Message = "请使能任意一个通道！";
      int num3 = (int) init_Configuration.PDF_Interface.ShowDialog();
    }
    else
    {
      this.imageButton2.Enabled = false;
      this.imageButton4.Enabled = false;
      this.qqRadioButton3.Enabled = false;
      this.qqRadioButton4.Enabled = false;
      this.qqRadioButton5.Enabled = false;
      this.qqRadioButton6.Enabled = false;
      this.qqTextBox10.Enabled = false;
      this.qqTextBox17.Enabled = false;
      this.imageButton5.Enabled = false;
      this.imageButton6.Enabled = false;
      this.imageButton7.Enabled = false;
      this.imageButton8.Enabled = false;
      this.dS按钮1.Enabled = false;
      this.dS按钮2.Enabled = false;
      this.imageButton10.Enabled = false;
      this.dS按钮1.贴图 = Resources.运行8;
      this.dS按钮2.贴图 = Resources.停止8;
      ((DataGridView) this.dataGridViewX2).Columns[0].ReadOnly = true;
      ((DataGridView) this.dataGridViewX2).Columns[1].ReadOnly = true;
      ((DataGridView) this.dataGridViewX2).Columns[2].ReadOnly = true;
      ((DataGridView) this.dataGridViewX2).Columns[3].ReadOnly = true;
      ((DataGridView) this.dataGridViewX2).Columns[5].ReadOnly = true;
      ((DataGridView) this.dataGridViewX2).Columns[6].ReadOnly = true;
      ((DataGridView) this.dataGridViewX2).Columns[0].DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
      ((DataGridView) this.dataGridViewX2).Columns[1].DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
      ((DataGridView) this.dataGridViewX2).Columns[2].DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
      ((DataGridView) this.dataGridViewX2).Columns[3].DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
      ((DataGridView) this.dataGridViewX2).Columns[5].DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
      ((DataGridView) this.dataGridViewX2).Columns[6].DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
      ((Control) this.dataGridViewX2).Enabled = true;
      this.dS按钮3.Enabled = false;
      this.dS按钮4.Enabled = true;
      this.imageButton12.Enabled = false;
      this.dS按钮3.贴图 = Resources.运行9;
      this.dS按钮4.贴图 = Resources.停止8;
      this.qqCheckBox7.Enabled = false;
      this.qqCheckBox8.Enabled = false;
      this.qqCheckBox9.Enabled = false;
      this.qqCheckBox10.Enabled = false;
      this.qqCheckBox11.Enabled = false;
      this.qqCheckBox12.Enabled = false;
      this.qqCheckBox13.Enabled = false;
      this.qqCheckBox14.Enabled = false;
      this.qqCheckBox15.Enabled = false;
      this.qqCheckBox16.Enabled = false;
      this.qqCheckBox17.Enabled = false;
      this.qqCheckBox18.Enabled = false;
      this.qqTextBox18.Enabled = false;
      this.qqTextBox19.Enabled = false;
      this.qqTextBox20.Enabled = false;
      this.qqTextBox21.Enabled = false;
      this.qqTextBox22.Enabled = false;
      this.qqTextBox23.Enabled = false;
      this.qqTextBox24.Enabled = false;
      this.qqTextBox25.Enabled = false;
      this.qqTextBox26.Enabled = false;
      this.qqTextBox27.Enabled = false;
      this.qqTextBox28.Enabled = false;
      this.qqTextBox29.Enabled = false;
      this.imageButton14.Enabled = false;
      this.qqRadioButton11.Enabled = false;
      this.qqRadioButton12.Enabled = false;
      this.dS按钮5.贴图 = Resources.运行9;
      this.dS按钮5.Enabled = false;
      this.dS按钮6.Enabled = false;
      this.dS按钮6.贴图 = Resources.停止8;
      this.myButton5.Enabled = false;
      this.myButton5.NormalImage = (Image) Resources.down;
      Form1.BOOT_ON_flag = false;
      this.dS按钮9.Enabled = false;
      this.dS按钮10.贴图 = Resources.按钮3;
      this.dS按钮11.贴图 = Resources.灯6;
      this.dS按钮10.Enabled = false;
      this.dS按钮11.Enabled = false;
      this.imageButton15.Enabled = false;
      this.imageButton16.Enabled = true;
      this.imageButton17.Enabled = false;
      this.dS按钮13.Enabled = false;
      this.dS按钮13.贴图 = Resources.运行9;
      this.myButton1.Enabled = false;
      this.dS按钮15.Enabled = false;
      this.dS按钮15.贴图 = Resources.运行9;
      this.dS按钮14.Enabled = false;
      this.dS按钮14.贴图 = Resources.停止9;
      this.myButton3.Enabled = false;
      this.myButton2.Enabled = false;
      this.dS按钮17.Enabled = false;
      this.dS按钮16.Enabled = false;
      this.dS按钮17.贴图 = Resources.运行9;
      this.dS按钮16.贴图 = Resources.停止9;
      Array.Clear((Array) Form1.S_Static_Save, 0, Form1.S_Static_Save.Length);
      Form1.S_Static_i = 0;
      Form1.mode3_Save_Task_flag = false;
      this.Slave_Send_Task();
    }
  }

  private void dS按钮4_ButtonClick(object Sender)
  {
    Form1.Rur_Mode = 3;
    Form1.Send_Mode_Command(0, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
    if (this.serialPort1.IsOpen)
      this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
    Form1.Exit_RTOS_Save_mode3_flag = true;
    this.imageButton2.Enabled = true;
    this.imageButton4.Enabled = true;
    this.qqRadioButton3.Enabled = true;
    this.qqRadioButton4.Enabled = true;
    this.qqRadioButton5.Enabled = true;
    this.qqRadioButton6.Enabled = true;
    this.qqTextBox10.Enabled = true;
    this.qqTextBox17.Enabled = true;
    this.imageButton5.Enabled = true;
    this.imageButton6.Enabled = false;
    this.imageButton7.Enabled = true;
    this.imageButton8.Enabled = false;
    this.dS按钮1.Enabled = true;
    this.dS按钮2.Enabled = false;
    this.imageButton10.Enabled = true;
    this.dS按钮1.贴图 = Resources.运行8;
    this.dS按钮2.贴图 = Resources.停止8;
    ((DataGridView) this.dataGridViewX2).Columns[0].ReadOnly = false;
    ((DataGridView) this.dataGridViewX2).Columns[1].ReadOnly = false;
    ((DataGridView) this.dataGridViewX2).Columns[2].ReadOnly = false;
    ((DataGridView) this.dataGridViewX2).Columns[3].ReadOnly = false;
    ((DataGridView) this.dataGridViewX2).Columns[5].ReadOnly = false;
    ((DataGridView) this.dataGridViewX2).Columns[6].ReadOnly = false;
    ((DataGridView) this.dataGridViewX2).Columns[0].DefaultCellStyle.BackColor = SystemColors.Window;
    ((DataGridView) this.dataGridViewX2).Columns[1].DefaultCellStyle.BackColor = SystemColors.Window;
    ((DataGridView) this.dataGridViewX2).Columns[2].DefaultCellStyle.BackColor = SystemColors.Window;
    ((DataGridView) this.dataGridViewX2).Columns[3].DefaultCellStyle.BackColor = SystemColors.Window;
    ((DataGridView) this.dataGridViewX2).Columns[5].DefaultCellStyle.BackColor = SystemColors.Window;
    ((DataGridView) this.dataGridViewX2).Columns[6].DefaultCellStyle.BackColor = SystemColors.Window;
    ((Control) this.dataGridViewX2).Enabled = true;
    this.dS按钮3.Enabled = true;
    this.dS按钮4.Enabled = false;
    this.imageButton12.Enabled = true;
    this.dS按钮3.贴图 = Resources.运行8;
    this.dS按钮4.贴图 = Resources.停止8;
    this.dS按钮6.贴图 = Resources.停止8;
    this.qqCheckBox7.Enabled = true;
    this.qqCheckBox8.Enabled = true;
    this.qqCheckBox9.Enabled = true;
    this.qqCheckBox10.Enabled = true;
    this.qqCheckBox11.Enabled = true;
    this.qqCheckBox12.Enabled = true;
    this.qqCheckBox13.Enabled = true;
    this.qqCheckBox14.Enabled = true;
    this.qqCheckBox15.Enabled = true;
    this.qqCheckBox16.Enabled = true;
    this.qqCheckBox17.Enabled = true;
    this.qqCheckBox18.Enabled = true;
    this.qqTextBox18.Enabled = true;
    this.qqTextBox19.Enabled = true;
    this.qqTextBox20.Enabled = true;
    this.qqTextBox21.Enabled = true;
    this.qqTextBox22.Enabled = true;
    this.qqTextBox23.Enabled = true;
    this.qqTextBox24.Enabled = true;
    this.qqTextBox25.Enabled = true;
    this.qqTextBox26.Enabled = true;
    this.qqTextBox27.Enabled = true;
    this.qqTextBox28.Enabled = true;
    this.qqTextBox29.Enabled = true;
    this.imageButton14.Enabled = true;
    this.qqRadioButton11.Enabled = true;
    this.qqRadioButton12.Enabled = true;
    this.dS按钮5.Enabled = true;
    this.dS按钮6.Enabled = false;
    this.dS按钮5.贴图 = Resources.运行8;
    this.myButton5.Enabled = true;
    this.myButton5.NormalImage = (Image) Resources.btn_green_normal;
    Form1.BOOT_ON_flag = false;
    this.dS按钮9.Enabled = true;
    this.dS按钮10.贴图 = Resources.按钮3;
    this.dS按钮11.贴图 = Resources.灯6;
    this.dS按钮10.Enabled = true;
    this.dS按钮11.Enabled = true;
    this.imageButton15.Enabled = true;
    this.imageButton16.Enabled = true;
    this.imageButton17.Enabled = true;
    this.dS按钮13.Enabled = false;
    this.dS按钮13.贴图 = Resources.运行9;
    this.myButton1.Enabled = true;
    this.dS按钮15.Enabled = true;
    this.dS按钮15.贴图 = Resources.运行8;
    this.dS按钮14.Enabled = false;
    this.dS按钮14.贴图 = Resources.停止9;
    this.myButton3.Enabled = true;
    this.myButton2.Enabled = true;
    this.dS按钮17.Enabled = true;
    this.dS按钮16.Enabled = false;
    this.dS按钮17.贴图 = Resources.运行8;
    this.dS按钮16.贴图 = Resources.停止9;
  }

  protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
  {
    int number = 0;
    byte[] buffer_Data = new byte[8];
    switch (Form1.Rur_Mode)
    {
      case 1:
        if (keyData == Keys.Return && Form1.Timing_Send_flag)
        {
          switch (Form1.Single_Send_i)
          {
            case 1:
              try
              {
                if (Form1.Send_flag1)
                {
                  byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox1.Text);
                  string text = this.qqTextBox2.Text;
                  int Length = (int) Convert.ToByte(this.qqTextBox3.Text);
                  if (Form1.CheckSum_Type == "增强型校验和")
                    Form1.Single_Set_Send_Data(0, dec, text, Length, "V2");
                  else
                    Form1.Single_Set_Send_Data(0, dec, text, Length, "V1");
                }
                if (Form1.Send_flag2)
                {
                  byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox4.Text);
                  string text = this.qqTextBox5.Text;
                  int Length = (int) Convert.ToByte(this.qqTextBox6.Text);
                  if (Form1.CheckSum_Type == "增强型校验和")
                    Form1.Single_Set_Send_Data(0, dec, text, Length, "V2");
                  else
                    Form1.Single_Set_Send_Data(0, dec, text, Length, "V1");
                }
                if (Form1.Send_flag3)
                {
                  byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox7.Text);
                  string text = this.qqTextBox8.Text;
                  int Length = (int) Convert.ToByte(this.qqTextBox9.Text);
                  if (Form1.CheckSum_Type == "增强型校验和")
                    Form1.Single_Set_Send_Data(0, dec, text, Length, "V2");
                  else
                    Form1.Single_Set_Send_Data(0, dec, text, Length, "V1");
                  break;
                }
                break;
              }
              catch
              {
                init_Configuration.Output_Message = "更改数据失败！";
                int num = (int) init_Configuration.PDF_Interface.ShowDialog();
                break;
              }
            case 2:
              try
              {
                if (Form1.Send_flag1)
                {
                  byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox1.Text);
                  string text = this.qqTextBox2.Text;
                  int Length = (int) Convert.ToByte(this.qqTextBox3.Text);
                  if (Form1.CheckSum_Type == "增强型校验和")
                    Form1.Single_Set_Send_Data(number, dec, text, Length, "V2");
                  else
                    Form1.Single_Set_Send_Data(number, dec, text, Length, "V1");
                  ++number;
                }
                if (Form1.Send_flag2)
                {
                  byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox4.Text);
                  string text = this.qqTextBox5.Text;
                  int Length = (int) Convert.ToByte(this.qqTextBox6.Text);
                  if (Form1.CheckSum_Type == "增强型校验和")
                    Form1.Single_Set_Send_Data(number, dec, text, Length, "V2");
                  else
                    Form1.Single_Set_Send_Data(number, dec, text, Length, "V1");
                  ++number;
                }
                if (Form1.Send_flag3)
                {
                  byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox7.Text);
                  string text = this.qqTextBox8.Text;
                  int Length = (int) Convert.ToByte(this.qqTextBox9.Text);
                  if (Form1.CheckSum_Type == "增强型校验和")
                    Form1.Single_Set_Send_Data(number, dec, text, Length, "V2");
                  else
                    Form1.Single_Set_Send_Data(number, dec, text, Length, "V1");
                  int num = number + 1;
                  break;
                }
                break;
              }
              catch
              {
                init_Configuration.Output_Message = "更改数据失败！";
                int num = (int) init_Configuration.PDF_Interface.ShowDialog();
                break;
              }
            case 3:
              try
              {
                if (Form1.Send_flag1)
                {
                  byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox1.Text);
                  string text = this.qqTextBox2.Text;
                  int Length = (int) Convert.ToByte(this.qqTextBox3.Text);
                  if (Form1.CheckSum_Type == "增强型校验和")
                    Form1.Single_Set_Send_Data(0, dec, text, Length, "V2");
                  else
                    Form1.Single_Set_Send_Data(0, dec, text, Length, "V1");
                }
                if (Form1.Send_flag2)
                {
                  byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox4.Text);
                  string text = this.qqTextBox5.Text;
                  int Length = (int) Convert.ToByte(this.qqTextBox6.Text);
                  if (Form1.CheckSum_Type == "增强型校验和")
                    Form1.Single_Set_Send_Data(1, dec, text, Length, "V2");
                  else
                    Form1.Single_Set_Send_Data(1, dec, text, Length, "V1");
                }
                if (Form1.Send_flag3)
                {
                  byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox7.Text);
                  string text = this.qqTextBox8.Text;
                  int Length = (int) Convert.ToByte(this.qqTextBox9.Text);
                  if (Form1.CheckSum_Type == "增强型校验和")
                    Form1.Single_Set_Send_Data(2, dec, text, Length, "V2");
                  else
                    Form1.Single_Set_Send_Data(2, dec, text, Length, "V1");
                  break;
                }
                break;
              }
              catch
              {
                init_Configuration.Output_Message = "更改数据失败！";
                int num = (int) init_Configuration.PDF_Interface.ShowDialog();
                break;
              }
          }
          break;
        }
        break;
      case 2:
        if (keyData == Keys.Return && ((DataGridView) this.dataGridViewX1).Rows[((DataGridView) this.dataGridViewX1).SelectedRows[0].Index].Cells[0].Value.ToString() == "True")
        {
          int index1 = ((DataGridView) this.dataGridViewX1).SelectedRows[0].Index;
          if (Form1.List_EN[index1, 1] == (byte) 0)
          {
            if (!((DataGridView) this.dataGridViewX1).Rows[((DataGridView) this.dataGridViewX1).SelectedRows[0].Index].ReadOnly)
              ((DataGridView) this.dataGridViewX1).Rows[((DataGridView) this.dataGridViewX1).SelectedRows[0].Index].ReadOnly = false;
            else
              ((DataGridView) this.dataGridViewX1).Rows[((DataGridView) this.dataGridViewX1).SelectedRows[0].Index].ReadOnly = true;
            try
            {
              string str = ((DataGridView) this.dataGridViewX1).Rows[index1].Cells[4].Value.ToString();
              byte dec = (byte) Form1.HEXstr_to_DEC(((DataGridView) this.dataGridViewX1).Rows[index1].Cells[3].Value.ToString());
              int int16 = (int) (byte) Convert.ToInt16(((DataGridView) this.dataGridViewX1).Rows[index1].Cells[5].Value.ToString());
              if (str.Length >= int16 * 3 - 1)
              {
                int index2 = 0;
                while (index2 < Form1.List_Send_i && (int) dec != (int) Form1.List_Send_Data[index2, 2])
                  ++index2;
                if (index2 != Form1.List_Send_i)
                {
                  lock (Form1.locker)
                  {
                    switch (int16)
                    {
                      case 1:
                        buffer_Data[0] = Form1.List_Send_Data[index2, 6] = (byte) Form1.HEXstr_to_DEC(str.Substring(0, 2).ToString());
                        buffer_Data[1] = Form1.List_Send_Data[index2, 7] = (byte) 0;
                        buffer_Data[2] = Form1.List_Send_Data[index2, 8] = (byte) 0;
                        buffer_Data[3] = Form1.List_Send_Data[index2, 9] = (byte) 0;
                        buffer_Data[4] = Form1.List_Send_Data[index2, 10] = (byte) 0;
                        buffer_Data[5] = Form1.List_Send_Data[index2, 11] = (byte) 0;
                        buffer_Data[6] = Form1.List_Send_Data[index2, 12] = (byte) 0;
                        buffer_Data[7] = Form1.List_Send_Data[index2, 13] = (byte) 0;
                        break;
                      case 2:
                        buffer_Data[0] = Form1.List_Send_Data[index2, 6] = (byte) Form1.HEXstr_to_DEC(str.Substring(0, 2).ToString());
                        buffer_Data[1] = Form1.List_Send_Data[index2, 7] = (byte) Form1.HEXstr_to_DEC(str.Substring(3, 2).ToString());
                        buffer_Data[2] = Form1.List_Send_Data[index2, 8] = (byte) 0;
                        buffer_Data[3] = Form1.List_Send_Data[index2, 9] = (byte) 0;
                        buffer_Data[4] = Form1.List_Send_Data[index2, 10] = (byte) 0;
                        buffer_Data[5] = Form1.List_Send_Data[index2, 11] = (byte) 0;
                        buffer_Data[6] = Form1.List_Send_Data[index2, 12] = (byte) 0;
                        buffer_Data[7] = Form1.List_Send_Data[index2, 13] = (byte) 0;
                        break;
                      case 3:
                        buffer_Data[0] = Form1.List_Send_Data[index2, 6] = (byte) Form1.HEXstr_to_DEC(str.Substring(0, 2).ToString());
                        buffer_Data[1] = Form1.List_Send_Data[index2, 7] = (byte) Form1.HEXstr_to_DEC(str.Substring(3, 2).ToString());
                        buffer_Data[2] = Form1.List_Send_Data[index2, 8] = (byte) Form1.HEXstr_to_DEC(str.Substring(6, 2).ToString());
                        buffer_Data[3] = Form1.List_Send_Data[index2, 9] = (byte) 0;
                        buffer_Data[4] = Form1.List_Send_Data[index2, 10] = (byte) 0;
                        buffer_Data[5] = Form1.List_Send_Data[index2, 11] = (byte) 0;
                        buffer_Data[6] = Form1.List_Send_Data[index2, 12] = (byte) 0;
                        buffer_Data[7] = Form1.List_Send_Data[index2, 13] = (byte) 0;
                        break;
                      case 4:
                        buffer_Data[0] = Form1.List_Send_Data[index2, 6] = (byte) Form1.HEXstr_to_DEC(str.Substring(0, 2).ToString());
                        buffer_Data[1] = Form1.List_Send_Data[index2, 7] = (byte) Form1.HEXstr_to_DEC(str.Substring(3, 2).ToString());
                        buffer_Data[2] = Form1.List_Send_Data[index2, 8] = (byte) Form1.HEXstr_to_DEC(str.Substring(6, 2).ToString());
                        buffer_Data[3] = Form1.List_Send_Data[index2, 9] = (byte) Form1.HEXstr_to_DEC(str.Substring(9, 2).ToString());
                        buffer_Data[4] = Form1.List_Send_Data[index2, 10] = (byte) 0;
                        buffer_Data[5] = Form1.List_Send_Data[index2, 11] = (byte) 0;
                        buffer_Data[6] = Form1.List_Send_Data[index2, 12] = (byte) 0;
                        buffer_Data[7] = Form1.List_Send_Data[index2, 13] = (byte) 0;
                        break;
                      case 5:
                        buffer_Data[0] = Form1.List_Send_Data[index2, 6] = (byte) Form1.HEXstr_to_DEC(str.Substring(0, 2).ToString());
                        buffer_Data[1] = Form1.List_Send_Data[index2, 7] = (byte) Form1.HEXstr_to_DEC(str.Substring(3, 2).ToString());
                        buffer_Data[2] = Form1.List_Send_Data[index2, 8] = (byte) Form1.HEXstr_to_DEC(str.Substring(6, 2).ToString());
                        buffer_Data[3] = Form1.List_Send_Data[index2, 9] = (byte) Form1.HEXstr_to_DEC(str.Substring(9, 2).ToString());
                        buffer_Data[4] = Form1.List_Send_Data[index2, 10] = (byte) Form1.HEXstr_to_DEC(str.Substring(12, 2).ToString());
                        buffer_Data[5] = Form1.List_Send_Data[index2, 11] = (byte) 0;
                        buffer_Data[6] = Form1.List_Send_Data[index2, 12] = (byte) 0;
                        buffer_Data[7] = Form1.List_Send_Data[index2, 13] = (byte) 0;
                        break;
                      case 6:
                        buffer_Data[0] = Form1.List_Send_Data[index2, 6] = (byte) Form1.HEXstr_to_DEC(str.Substring(0, 2).ToString());
                        buffer_Data[1] = Form1.List_Send_Data[index2, 7] = (byte) Form1.HEXstr_to_DEC(str.Substring(3, 2).ToString());
                        buffer_Data[2] = Form1.List_Send_Data[index2, 8] = (byte) Form1.HEXstr_to_DEC(str.Substring(6, 2).ToString());
                        buffer_Data[3] = Form1.List_Send_Data[index2, 9] = (byte) Form1.HEXstr_to_DEC(str.Substring(9, 2).ToString());
                        buffer_Data[4] = Form1.List_Send_Data[index2, 10] = (byte) Form1.HEXstr_to_DEC(str.Substring(12, 2).ToString());
                        buffer_Data[5] = Form1.List_Send_Data[index2, 11] = (byte) Form1.HEXstr_to_DEC(str.Substring(15, 2).ToString());
                        buffer_Data[6] = Form1.List_Send_Data[index2, 12] = (byte) 0;
                        buffer_Data[7] = Form1.List_Send_Data[index2, 13] = (byte) 0;
                        break;
                      case 7:
                        buffer_Data[0] = Form1.List_Send_Data[index2, 6] = (byte) Form1.HEXstr_to_DEC(str.Substring(0, 2).ToString());
                        buffer_Data[1] = Form1.List_Send_Data[index2, 7] = (byte) Form1.HEXstr_to_DEC(str.Substring(3, 2).ToString());
                        buffer_Data[2] = Form1.List_Send_Data[index2, 8] = (byte) Form1.HEXstr_to_DEC(str.Substring(6, 2).ToString());
                        buffer_Data[3] = Form1.List_Send_Data[index2, 9] = (byte) Form1.HEXstr_to_DEC(str.Substring(9, 2).ToString());
                        buffer_Data[4] = Form1.List_Send_Data[index2, 10] = (byte) Form1.HEXstr_to_DEC(str.Substring(12, 2).ToString());
                        buffer_Data[5] = Form1.List_Send_Data[index2, 11] = (byte) Form1.HEXstr_to_DEC(str.Substring(15, 2).ToString());
                        buffer_Data[6] = Form1.List_Send_Data[index2, 12] = (byte) Form1.HEXstr_to_DEC(str.Substring(18, 2).ToString());
                        buffer_Data[7] = Form1.List_Send_Data[index2, 13] = (byte) 0;
                        break;
                      default:
                        buffer_Data[0] = Form1.List_Send_Data[index2, 6] = (byte) Form1.HEXstr_to_DEC(str.Substring(0, 2).ToString());
                        buffer_Data[1] = Form1.List_Send_Data[index2, 7] = (byte) Form1.HEXstr_to_DEC(str.Substring(3, 2).ToString());
                        buffer_Data[2] = Form1.List_Send_Data[index2, 8] = (byte) Form1.HEXstr_to_DEC(str.Substring(6, 2).ToString());
                        buffer_Data[3] = Form1.List_Send_Data[index2, 9] = (byte) Form1.HEXstr_to_DEC(str.Substring(9, 2).ToString());
                        buffer_Data[4] = Form1.List_Send_Data[index2, 10] = (byte) Form1.HEXstr_to_DEC(str.Substring(12, 2).ToString());
                        buffer_Data[5] = Form1.List_Send_Data[index2, 11] = (byte) Form1.HEXstr_to_DEC(str.Substring(15, 2).ToString());
                        buffer_Data[6] = Form1.List_Send_Data[index2, 12] = (byte) Form1.HEXstr_to_DEC(str.Substring(18, 2).ToString());
                        buffer_Data[7] = Form1.List_Send_Data[index2, 13] = (byte) Form1.HEXstr_to_DEC(str.Substring(21, 2).ToString());
                        break;
                    }
                    Form1.List_Send_Data[index2, 14] = Form1.LINCalcChecksum(dec, buffer_Data, (byte) int16);
                    this.label39.Text = $"参数设置：成功更改第{index1.ToString()}行数据:{str.Substring(0, int16 * 3 - 1)}";
                    this.label39.ForeColor = Color.Black;
                  }
                }
              }
              else
              {
                this.label39.Text = $"参数设置：更改第{index1.ToString()}行数据失败!!";
                this.label39.ForeColor = Color.Red;
                init_Configuration.Output_Message = "更改数据失败，请检查数据内容！";
                int num = (int) init_Configuration.PDF_Interface.ShowDialog();
              }
            }
            catch
            {
              this.label39.Text = $"参数设置：更改第{index1.ToString()}行数据失败!!";
              this.label39.ForeColor = Color.Red;
              init_Configuration.Output_Message = "更改数据失败，请检查数据内容！";
              int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            }
          }
          break;
        }
        break;
      case 3:
        if (keyData == Keys.Return && ((DataGridView) this.dataGridViewX2).Rows[((DataGridView) this.dataGridViewX2).SelectedRows[0].Index].Cells[0].Value.ToString() == "True")
        {
          int index = ((DataGridView) this.dataGridViewX2).SelectedRows[0].Index;
          if (Form1.Slave_EN[index, 1] == (byte) 0)
          {
            if (!((DataGridView) this.dataGridViewX2).Rows[((DataGridView) this.dataGridViewX2).SelectedRows[0].Index].ReadOnly)
              ((DataGridView) this.dataGridViewX2).Rows[((DataGridView) this.dataGridViewX2).SelectedRows[0].Index].ReadOnly = false;
            else
              ((DataGridView) this.dataGridViewX2).Rows[((DataGridView) this.dataGridViewX2).SelectedRows[0].Index].ReadOnly = true;
            try
            {
              string Send_str = ((DataGridView) this.dataGridViewX2).Rows[index].Cells[4].Value.ToString();
              byte dec = (byte) Form1.HEXstr_to_DEC(((DataGridView) this.dataGridViewX2).Rows[index].Cells[3].Value.ToString());
              int int16 = (int) (byte) Convert.ToInt16(((DataGridView) this.dataGridViewX2).Rows[index].Cells[5].Value.ToString());
              if (Send_str.Length >= int16 * 3 - 1)
              {
                string check_type = !(((DataGridView) this.dataGridViewX2).Rows[index].Cells[6].Value.ToString() == "增强型校验和") ? "V1" : "V2";
                Form1.Slave_Update_Data(dec, index, Send_str, int16, check_type);
                this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
                this.label4.Text = $"参数设置：成功更改第{index.ToString()}行数据:{Send_str.Substring(0, int16 * 3 - 1)}";
                this.label4.ForeColor = Color.Black;
              }
              else
              {
                this.label4.Text = $"参数设置：更改第{index.ToString()}行数据失败!!";
                this.label4.ForeColor = Color.Red;
                init_Configuration.Output_Message = "更改数据失败，请检查数据内容！";
                int num = (int) init_Configuration.PDF_Interface.ShowDialog();
              }
            }
            catch
            {
              this.label4.Text = $"参数设置：更改第{index.ToString()}行数据失败!!";
              this.label4.ForeColor = Color.Red;
              init_Configuration.Output_Message = "更改数据失败，请检查数据内容！";
              int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            }
          }
          break;
        }
        break;
    }
    return base.ProcessCmdKey(ref msg, keyData);
  }

  private void qqRadioButton11_CheckedChanged_1(object sender, EventArgs e)
  {
    if (this.qqRadioButton11.Checked)
      Form1.Monitor_Mode = false;
    else
      Form1.Monitor_Mode = true;
  }

  private void qqRadioButton13_CheckedChanged(object sender, EventArgs e)
  {
    if (this.qqRadioButton13.Checked)
    {
      lock (Form1.locker)
      {
        this.listViewNF4.Items.Clear();
        Array.Clear((Array) Form1.Monitor_Data, 0, Form1.Monitor_Data.Length);
        Form1.Set_value(Form1.Monitor_Static, byte.MaxValue, Form1.Monitor_Static.Length);
        Array.Clear((Array) Form1.Monitor_time, 0, Form1.Monitor_time.Length);
        Form1.RX_count = 0;
        Form1.RX_Save_count = 0;
        Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
        Form1.Monitor_count = 0;
        Form1.Monitor_Display_count = 0;
        Form1.Monitor_Display_Mode = false;
        Form1.mode4_Save_Task_i = 0;
      }
    }
    else
    {
      lock (Form1.locker)
      {
        this.listViewNF4.Items.Clear();
        Array.Clear((Array) Form1.Monitor_Data, 0, Form1.Monitor_Data.Length);
        Array.Clear((Array) Form1.Monitor_time, 0, Form1.Monitor_time.Length);
        Form1.RX_count = 0;
        Form1.RX_Save_count = 0;
        Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
        Form1.Monitor_count = 0;
        Form1.Monitor_Display_count = 0;
        Form1.Monitor_Display_Mode = true;
        Form1.mode4_Save_Task_i = 0;
      }
    }
  }

  private void imageButton13_Click(object sender, EventArgs e)
  {
    lock (Form1.locker)
    {
      this.listViewNF4.Items.Clear();
      Array.Clear((Array) Form1.Monitor_Data, 0, Form1.Monitor_Data.Length);
      Form1.Set_value(Form1.Monitor_Static, byte.MaxValue, Form1.Monitor_Static.Length);
      Array.Clear((Array) Form1.Monitor_time, 0, Form1.Monitor_time.Length);
      Form1.RX_count = 0;
      Form1.RX_Save_count = 0;
      Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
      Form1.Monitor_count = 0;
      Form1.Monitor_Display_count = 0;
      Form1.mode4_Save_Task_i = 0;
    }
  }

  private void imageButton14_Click(object sender, EventArgs e)
  {
    Array.Clear((Array) Form1.M_Static_Save, 0, Form1.M_Static_Save.Length);
    Form1.M_Static_i = 0;
    if (this.listViewNF4.Items.Count == 0)
    {
      init_Configuration.Output_Message = "无数据可保存！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
    }
    else
    {
      if (Form1.Monitor_Display_Mode)
      {
        for (int index = 0; index < this.listViewNF4.Items.Count; ++index)
        {
          Form1.M_Static_Save[index, 0] = this.listViewNF4.Items[index].SubItems[0].Text;
          Form1.M_Static_Save[index, 1] = this.listViewNF4.Items[index].SubItems[1].Text;
          Form1.M_Static_Save[index, 2] = this.listViewNF4.Items[index].SubItems[2].Text;
          Form1.M_Static_Save[index, 3] = this.listViewNF4.Items[index].SubItems[3].Text;
          Form1.M_Static_Save[index, 4] = this.listViewNF4.Items[index].SubItems[4].Text;
          Form1.M_Static_Save[index, 5] = this.listViewNF4.Items[index].SubItems[5].Text;
          Form1.M_Static_Save[index, 6] = this.listViewNF4.Items[index].SubItems[6].Text;
          Form1.M_Static_Save[index, 7] = this.listViewNF4.Items[index].SubItems[7].Text;
          Form1.M_Static_Save[index, 8] = this.listViewNF4.Items[index].SubItems[8].Text;
          ++Form1.M_Static_i;
        }
        this.progressBarEx1.Value = 0;
        this.progressBarEx1.Maximum = Form1.M_Static_i;
        this.progressBarEx1.Text = "0%";
      }
      else
      {
        this.progressBarEx1.Value = 0;
        this.progressBarEx1.Maximum = Form1.Monitor_count;
        this.progressBarEx1.Text = "0%";
      }
      this.saveFileDialog4.Title = "另存为";
      this.saveFileDialog4.FileName = "Data for 1";
      this.saveFileDialog4.Filter = "CSV File(*.csv)|*.csv";
      this.saveFileDialog4.ShowHelp = false;
      this.saveFileDialog4.OverwritePrompt = true;
      this.saveFileDialog4.SupportMultiDottedExtensions = false;
      if (this.saveFileDialog4.ShowDialog() != DialogResult.OK)
        return;
      Form1.Save_FileName_str = this.saveFileDialog4.FileName;
      this.imageButton2.Enabled = false;
      this.imageButton4.Enabled = false;
      this.qqRadioButton3.Enabled = false;
      this.qqRadioButton4.Enabled = false;
      this.qqRadioButton5.Enabled = false;
      this.qqRadioButton6.Enabled = false;
      this.qqTextBox10.Enabled = false;
      this.qqTextBox17.Enabled = false;
      this.imageButton5.Enabled = false;
      this.imageButton6.Enabled = false;
      this.imageButton7.Enabled = false;
      this.imageButton8.Enabled = false;
      this.dS按钮1.Enabled = false;
      this.dS按钮2.Enabled = false;
      this.imageButton10.Enabled = false;
      this.dS按钮1.贴图 = Resources.运行8;
      this.dS按钮2.贴图 = Resources.停止8;
      ((Control) this.dataGridViewX2).Enabled = false;
      this.dS按钮3.Enabled = false;
      this.dS按钮4.Enabled = false;
      this.imageButton12.Enabled = false;
      this.dS按钮3.贴图 = Resources.运行8;
      this.dS按钮4.贴图 = Resources.停止8;
      this.qqCheckBox7.Enabled = false;
      this.qqCheckBox8.Enabled = false;
      this.qqCheckBox9.Enabled = false;
      this.qqCheckBox10.Enabled = false;
      this.qqCheckBox11.Enabled = false;
      this.qqCheckBox12.Enabled = false;
      this.qqCheckBox13.Enabled = false;
      this.qqCheckBox14.Enabled = false;
      this.qqCheckBox15.Enabled = false;
      this.qqCheckBox16.Enabled = false;
      this.qqCheckBox17.Enabled = false;
      this.qqCheckBox18.Enabled = false;
      this.qqTextBox18.Enabled = false;
      this.qqTextBox19.Enabled = false;
      this.qqTextBox20.Enabled = false;
      this.qqTextBox21.Enabled = false;
      this.qqTextBox22.Enabled = false;
      this.qqTextBox23.Enabled = false;
      this.qqTextBox24.Enabled = false;
      this.qqTextBox25.Enabled = false;
      this.qqTextBox26.Enabled = false;
      this.qqTextBox27.Enabled = false;
      this.qqTextBox28.Enabled = false;
      this.qqTextBox29.Enabled = false;
      this.qqRadioButton13.Enabled = false;
      this.qqRadioButton14.Enabled = false;
      this.imageButton14.Enabled = false;
      this.qqRadioButton11.Enabled = false;
      this.qqRadioButton12.Enabled = false;
      this.imageButton13.Enabled = false;
      this.dS按钮5.贴图 = Resources.运行8;
      this.dS按钮5.Enabled = false;
      this.dS按钮6.Enabled = false;
      this.dS按钮6.贴图 = Resources.停止8;
      this.myButton5.Enabled = false;
      this.myButton5.NormalImage = (Image) Resources.down;
      Form1.BOOT_ON_flag = false;
      this.dS按钮9.Enabled = false;
      this.dS按钮10.贴图 = Resources.按钮3;
      this.dS按钮11.贴图 = Resources.灯6;
      this.dS按钮10.Enabled = false;
      this.dS按钮11.Enabled = false;
      this.imageButton15.Enabled = false;
      this.imageButton16.Enabled = true;
      this.imageButton17.Enabled = false;
      this.dS按钮13.Enabled = false;
      this.dS按钮13.贴图 = Resources.运行9;
      this.myButton1.Enabled = false;
      this.dS按钮15.Enabled = false;
      this.dS按钮15.贴图 = Resources.运行9;
      this.dS按钮14.Enabled = false;
      this.dS按钮14.贴图 = Resources.停止9;
      this.myButton3.Enabled = false;
      this.myButton2.Enabled = false;
      this.dS按钮17.Enabled = false;
      this.dS按钮16.Enabled = false;
      this.dS按钮17.贴图 = Resources.运行9;
      this.dS按钮16.贴图 = Resources.停止9;
      Form1.Save_ProgressBar_i = 0;
      Form1.Save_Finish_flag = false;
      Form1.Exit_Save_listViewNF4_flag = false;
      this.Save_listViewNF4_Thread = new Thread(new ThreadStart(this.Save_listViewNF4_Data));
      this.Save_listViewNF4_Thread.IsBackground = true;
      this.Save_listViewNF4_Thread.Start();
      this.Save_listViewNF4_Asynchronous();
    }
  }

  private void dS按钮5_ButtonClick(object Sender)
  {
    byte num1 = 0;
    Array.Clear((Array) Form1.Monitor_EN, 0, Form1.Monitor_EN.Length);
    Form1.RX_count = 0;
    Form1.RX_Save_count = 0;
    Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
    Form1.Monitor_Mode = !this.qqRadioButton11.Checked;
    if (this.qqRadioButton13.Checked)
    {
      lock (Form1.locker)
      {
        this.listViewNF4.Items.Clear();
        Array.Clear((Array) Form1.Monitor_Data, 0, Form1.Monitor_Data.Length);
        Form1.Set_value(Form1.Monitor_Static, byte.MaxValue, Form1.Monitor_Static.Length);
        Array.Clear((Array) Form1.Monitor_time, 0, Form1.Monitor_time.Length);
        Form1.Monitor_count = 0;
        Form1.Monitor_Display_count = 0;
        Form1.Monitor_Display_Mode = false;
      }
    }
    else
    {
      lock (Form1.locker)
      {
        this.listViewNF4.Items.Clear();
        Array.Clear((Array) Form1.Monitor_Data, 0, Form1.Monitor_Data.Length);
        Form1.Set_value(Form1.Monitor_Static, byte.MaxValue, Form1.Monitor_Static.Length);
        Array.Clear((Array) Form1.Monitor_time, 0, Form1.Monitor_time.Length);
        Form1.Monitor_count = 0;
        Form1.Monitor_Display_count = 0;
        Form1.Monitor_Display_Mode = true;
      }
    }
    if (!Form1.Monitor_Mode)
    {
      if (this.qqCheckBox7.Checked)
      {
        try
        {
          num1 = (byte) 0;
          byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox18.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "监听ID超出范围！";
            int num2 = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          Form1.Monitor_EN[(int) dec, 0] = (byte) 1;
        }
        catch
        {
          init_Configuration.Output_Message = "监听固定ID格式不正确！";
          int num3 = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      if (this.qqCheckBox8.Checked)
      {
        try
        {
          num1 = (byte) 0;
          byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox19.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "监听ID超出范围！";
            int num4 = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          Form1.Monitor_EN[(int) dec, 0] = (byte) 1;
        }
        catch
        {
          init_Configuration.Output_Message = "监听固定ID格式不正确！";
          int num5 = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      if (this.qqCheckBox9.Checked)
      {
        try
        {
          num1 = (byte) 0;
          byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox20.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "监听ID超出范围！";
            int num6 = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          Form1.Monitor_EN[(int) dec, 0] = (byte) 1;
        }
        catch
        {
          init_Configuration.Output_Message = "监听固定ID格式不正确！";
          int num7 = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      if (this.qqCheckBox10.Checked)
      {
        try
        {
          num1 = (byte) 0;
          byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox21.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "监听ID超出范围！";
            int num8 = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          Form1.Monitor_EN[(int) dec, 0] = (byte) 1;
        }
        catch
        {
          init_Configuration.Output_Message = "监听固定ID格式不正确！";
          int num9 = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      if (this.qqCheckBox11.Checked)
      {
        try
        {
          num1 = (byte) 0;
          byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox22.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "监听ID超出范围！";
            int num10 = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          Form1.Monitor_EN[(int) dec, 0] = (byte) 1;
        }
        catch
        {
          init_Configuration.Output_Message = "监听固定ID格式不正确！";
          int num11 = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      if (this.qqCheckBox12.Checked)
      {
        try
        {
          num1 = (byte) 0;
          byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox23.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "监听ID超出范围！";
            int num12 = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          Form1.Monitor_EN[(int) dec, 0] = (byte) 1;
        }
        catch
        {
          init_Configuration.Output_Message = "监听固定ID格式不正确！";
          int num13 = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      if (this.qqCheckBox13.Checked)
      {
        try
        {
          num1 = (byte) 0;
          byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox24.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "监听ID超出范围！";
            int num14 = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          Form1.Monitor_EN[(int) dec, 0] = (byte) 1;
        }
        catch
        {
          init_Configuration.Output_Message = "监听固定ID格式不正确！";
          int num15 = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      if (this.qqCheckBox14.Checked)
      {
        try
        {
          num1 = (byte) 0;
          byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox25.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "监听ID超出范围！";
            int num16 = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          Form1.Monitor_EN[(int) dec, 0] = (byte) 1;
        }
        catch
        {
          init_Configuration.Output_Message = "监听固定ID格式不正确！";
          int num17 = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      if (this.qqCheckBox15.Checked)
      {
        try
        {
          num1 = (byte) 0;
          byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox26.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "监听ID超出范围！";
            int num18 = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          Form1.Monitor_EN[(int) dec, 0] = (byte) 1;
        }
        catch
        {
          init_Configuration.Output_Message = "监听固定ID格式不正确！";
          int num19 = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      if (this.qqCheckBox16.Checked)
      {
        try
        {
          num1 = (byte) 0;
          byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox27.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "监听ID超出范围！";
            int num20 = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          Form1.Monitor_EN[(int) dec, 0] = (byte) 1;
        }
        catch
        {
          init_Configuration.Output_Message = "监听固定ID格式不正确！";
          int num21 = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      if (this.qqCheckBox17.Checked)
      {
        try
        {
          num1 = (byte) 0;
          byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox28.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "监听ID超出范围！";
            int num22 = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          Form1.Monitor_EN[(int) dec, 0] = (byte) 1;
        }
        catch
        {
          init_Configuration.Output_Message = "监听固定ID格式不正确！";
          int num23 = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      if (this.qqCheckBox18.Checked)
      {
        try
        {
          num1 = (byte) 0;
          byte dec = (byte) Form1.HEXstr_to_DEC(this.qqTextBox29.Text);
          if (dec > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "监听ID超出范围！";
            int num24 = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          Form1.Monitor_EN[(int) dec, 0] = (byte) 1;
        }
        catch
        {
          init_Configuration.Output_Message = "监听固定ID格式不正确！";
          int num25 = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
    }
    this.imageButton2.Enabled = false;
    this.imageButton4.Enabled = false;
    this.qqRadioButton3.Enabled = false;
    this.qqRadioButton4.Enabled = false;
    this.qqRadioButton5.Enabled = false;
    this.qqRadioButton6.Enabled = false;
    this.qqTextBox10.Enabled = false;
    this.qqTextBox17.Enabled = false;
    this.imageButton5.Enabled = false;
    this.imageButton6.Enabled = false;
    this.imageButton7.Enabled = false;
    this.imageButton8.Enabled = false;
    this.dS按钮1.Enabled = false;
    this.dS按钮2.Enabled = false;
    this.imageButton10.Enabled = false;
    this.dS按钮1.贴图 = Resources.运行8;
    this.dS按钮2.贴图 = Resources.停止8;
    ((Control) this.dataGridViewX2).Enabled = false;
    this.dS按钮3.Enabled = false;
    this.dS按钮4.Enabled = false;
    this.imageButton12.Enabled = false;
    this.dS按钮3.贴图 = Resources.运行8;
    this.dS按钮4.贴图 = Resources.停止8;
    this.qqCheckBox7.Enabled = false;
    this.qqCheckBox8.Enabled = false;
    this.qqCheckBox9.Enabled = false;
    this.qqCheckBox10.Enabled = false;
    this.qqCheckBox11.Enabled = false;
    this.qqCheckBox12.Enabled = false;
    this.qqCheckBox13.Enabled = false;
    this.qqCheckBox14.Enabled = false;
    this.qqCheckBox15.Enabled = false;
    this.qqCheckBox16.Enabled = false;
    this.qqCheckBox17.Enabled = false;
    this.qqCheckBox18.Enabled = false;
    this.qqTextBox18.Enabled = false;
    this.qqTextBox19.Enabled = false;
    this.qqTextBox20.Enabled = false;
    this.qqTextBox21.Enabled = false;
    this.qqTextBox22.Enabled = false;
    this.qqTextBox23.Enabled = false;
    this.qqTextBox24.Enabled = false;
    this.qqTextBox25.Enabled = false;
    this.qqTextBox26.Enabled = false;
    this.qqTextBox27.Enabled = false;
    this.qqTextBox28.Enabled = false;
    this.qqTextBox29.Enabled = false;
    this.imageButton14.Enabled = false;
    this.qqRadioButton11.Enabled = false;
    this.qqRadioButton12.Enabled = false;
    this.dS按钮5.贴图 = Resources.运行9;
    this.dS按钮5.Enabled = false;
    this.dS按钮6.Enabled = true;
    this.dS按钮6.贴图 = Resources.停止8;
    this.myButton5.Enabled = false;
    this.myButton5.NormalImage = (Image) Resources.down;
    Form1.BOOT_ON_flag = false;
    this.dS按钮9.Enabled = false;
    this.dS按钮10.贴图 = Resources.按钮3;
    this.dS按钮11.贴图 = Resources.灯6;
    this.dS按钮10.Enabled = false;
    this.dS按钮11.Enabled = false;
    this.imageButton15.Enabled = false;
    this.imageButton16.Enabled = true;
    this.imageButton17.Enabled = false;
    this.dS按钮13.Enabled = false;
    this.dS按钮13.贴图 = Resources.运行9;
    this.myButton1.Enabled = false;
    this.dS按钮15.Enabled = false;
    this.dS按钮15.贴图 = Resources.运行9;
    this.dS按钮14.Enabled = false;
    this.dS按钮14.贴图 = Resources.停止9;
    this.myButton3.Enabled = false;
    this.myButton2.Enabled = false;
    this.dS按钮17.Enabled = false;
    this.dS按钮16.Enabled = false;
    this.dS按钮17.贴图 = Resources.运行9;
    this.dS按钮16.贴图 = Resources.停止9;
    Array.Clear((Array) Form1.M_Static_Save, 0, Form1.M_Static_Save.Length);
    Form1.M_Static_i = 0;
    Form1.mode4_Save_Task_flag = false;
    if (Form1.Rur_Mode != 0)
    {
      Form1.Rur_Mode = 0;
      Form1.Send_Mode_Command(Form1.Rur_Mode, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
      if (this.serialPort1.IsOpen)
        this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
      Thread.Sleep(200);
    }
    Form1.Rur_Mode = 4;
    Form1.Send_Mode_Command(3, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
    if (this.serialPort1.IsOpen)
      this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
    this.RTOS_Save_mode4_Asynchronous();
  }

  private void dS按钮6_ButtonClick(object Sender)
  {
    Form1.Rur_Mode = 0;
    Form1.Send_Mode_Command(0, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
    if (this.serialPort1.IsOpen)
      this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
    this.imageButton2.Enabled = true;
    this.imageButton4.Enabled = true;
    this.qqRadioButton3.Enabled = true;
    this.qqRadioButton4.Enabled = true;
    this.qqRadioButton5.Enabled = true;
    this.qqRadioButton6.Enabled = true;
    this.qqTextBox10.Enabled = true;
    this.qqTextBox17.Enabled = true;
    this.imageButton5.Enabled = true;
    this.imageButton6.Enabled = false;
    this.imageButton7.Enabled = true;
    this.imageButton8.Enabled = false;
    this.dS按钮1.Enabled = true;
    this.dS按钮2.Enabled = false;
    this.imageButton10.Enabled = true;
    this.dS按钮1.贴图 = Resources.运行8;
    this.dS按钮2.贴图 = Resources.停止8;
    ((Control) this.dataGridViewX2).Enabled = true;
    this.dS按钮3.Enabled = true;
    this.dS按钮4.Enabled = false;
    this.imageButton12.Enabled = true;
    this.dS按钮3.贴图 = Resources.运行8;
    this.dS按钮4.贴图 = Resources.停止8;
    this.dS按钮6.贴图 = Resources.停止8;
    this.qqCheckBox7.Enabled = true;
    this.qqCheckBox8.Enabled = true;
    this.qqCheckBox9.Enabled = true;
    this.qqCheckBox10.Enabled = true;
    this.qqCheckBox11.Enabled = true;
    this.qqCheckBox12.Enabled = true;
    this.qqCheckBox13.Enabled = true;
    this.qqCheckBox14.Enabled = true;
    this.qqCheckBox15.Enabled = true;
    this.qqCheckBox16.Enabled = true;
    this.qqCheckBox17.Enabled = true;
    this.qqCheckBox18.Enabled = true;
    this.qqTextBox18.Enabled = true;
    this.qqTextBox19.Enabled = true;
    this.qqTextBox20.Enabled = true;
    this.qqTextBox21.Enabled = true;
    this.qqTextBox22.Enabled = true;
    this.qqTextBox23.Enabled = true;
    this.qqTextBox24.Enabled = true;
    this.qqTextBox25.Enabled = true;
    this.qqTextBox26.Enabled = true;
    this.qqTextBox27.Enabled = true;
    this.qqTextBox28.Enabled = true;
    this.qqTextBox29.Enabled = true;
    this.imageButton14.Enabled = true;
    this.qqRadioButton11.Enabled = true;
    this.qqRadioButton12.Enabled = true;
    this.dS按钮5.Enabled = true;
    this.dS按钮6.Enabled = false;
    this.dS按钮5.贴图 = Resources.运行8;
    this.myButton5.Enabled = true;
    this.myButton5.NormalImage = (Image) Resources.btn_green_normal;
    Form1.BOOT_ON_flag = false;
    this.dS按钮9.Enabled = true;
    this.dS按钮10.贴图 = Resources.按钮3;
    this.dS按钮11.贴图 = Resources.灯6;
    this.dS按钮10.Enabled = true;
    this.dS按钮11.Enabled = true;
    this.imageButton15.Enabled = true;
    this.imageButton16.Enabled = true;
    this.imageButton17.Enabled = true;
    this.dS按钮13.Enabled = false;
    this.dS按钮13.贴图 = Resources.运行9;
    this.myButton1.Enabled = true;
    this.dS按钮15.Enabled = true;
    this.dS按钮15.贴图 = Resources.运行8;
    this.dS按钮14.Enabled = false;
    this.dS按钮14.贴图 = Resources.停止9;
    this.myButton3.Enabled = true;
    this.myButton2.Enabled = true;
    this.dS按钮17.Enabled = true;
    this.dS按钮16.Enabled = false;
    this.dS按钮17.贴图 = Resources.运行8;
    this.dS按钮16.贴图 = Resources.停止9;
    Form1.ClearMemory();
  }

  private void myButton5_Click(object sender, EventArgs e)
  {
    int index1 = 0;
    try
    {
      Form1.Volume_value = (int) Convert.ToInt16(this.dS数字输入框2.Text);
      if (Form1.Volume_value > 30)
      {
        init_Configuration.Output_Message = "语音音量最大30！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        return;
      }
    }
    catch
    {
      init_Configuration.Output_Message = "语音音量格式不正确！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    try
    {
      Form1.Line_time = (int) Convert.ToInt16(this.dS数字输入框3.Text);
      if (Form1.Baud_rate >= 19000)
      {
        if (Form1.Line_time < 10 || Form1.Line_time > 30000)
        {
          init_Configuration.Output_Message = "定时时间超出范围！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      else if (Form1.Baud_rate >= 10400)
      {
        if (Form1.Line_time < 20 || Form1.Line_time > 30000)
        {
          init_Configuration.Output_Message = "定时时间超出范围！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      else if (Form1.Line_time < 30 || Form1.Line_time > 30000)
      {
        init_Configuration.Output_Message = "定时时间超出范围！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        return;
      }
    }
    catch
    {
      init_Configuration.Output_Message = "定时时间格式不正确！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    try
    {
      for (index1 = 0; index1 < 16 /*0x10*/; ++index1)
      {
        if (((DataGridView) this.dataGridViewX3).Rows[index1].Cells[0].Value.ToString() == "True" && (byte) Form1.HEXstr_to_DEC(((DataGridView) this.dataGridViewX3).Rows[index1].Cells[3].Value.ToString()) > (byte) 63 /*0x3F*/)
        {
          init_Configuration.Output_Message = $"通道{index1.ToString()}的ID超出范围！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
    }
    catch
    {
      init_Configuration.Output_Message = $"通道{index1.ToString()}的ID格式不正确！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    try
    {
      for (index1 = 0; index1 < 16 /*0x10*/; ++index1)
      {
        if (((DataGridView) this.dataGridViewX3).Rows[index1].Cells[0].Value.ToString() == "True")
        {
          byte int16 = (byte) Convert.ToInt16(((DataGridView) this.dataGridViewX3).Rows[index1].Cells[5].Value.ToString());
          if (int16 > (byte) 8 || int16 == (byte) 0)
          {
            init_Configuration.Output_Message = $"通道{index1.ToString()}的数据长度超出范围！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
      }
    }
    catch
    {
      init_Configuration.Output_Message = $"通道{index1.ToString()}的数据长度格式不正确！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    try
    {
      for (index1 = 0; index1 < 16 /*0x10*/; ++index1)
      {
        if (((DataGridView) this.dataGridViewX3).Rows[index1].Cells[0].Value.ToString() == "True" && ((DataGridView) this.dataGridViewX3).Rows[index1].Cells[2].Value.ToString() == "发送")
        {
          int int16 = (int) (byte) Convert.ToInt16(((DataGridView) this.dataGridViewX3).Rows[index1].Cells[5].Value.ToString());
          if (((DataGridView) this.dataGridViewX3).Rows[index1].Cells[4].Value.ToString().Length < int16 * 3 - 1)
          {
            init_Configuration.Output_Message = $"通道{index1.ToString()}的数据格式不正确！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
      }
    }
    catch
    {
      init_Configuration.Output_Message = $"通道{index1.ToString()}的数据格式不正确！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    int num1 = 0;
    Form1.Off_line_count = 0;
    int num2 = 0;
    Form1.mode4_flag = false;
    Form1.Exit_mode4_flag = false;
    Array.Clear((Array) Form1.Off_line_Date, 0, Form1.Off_line_Date.Length);
    Form1.Off_line_Date[Form1.Off_line_count, 0] = (byte) 17;
    Form1.Off_line_Date[Form1.Off_line_count, 1] = (byte) 0;
    Form1.Off_line_Date[Form1.Off_line_count, 2] = (byte) ((Form1.Baud_rate & 65280) >> 8);
    Form1.Off_line_Date[Form1.Off_line_count, 3] = (byte) (Form1.Baud_rate & (int) byte.MaxValue);
    Form1.Off_line_Date[Form1.Off_line_count, 4] = (byte) ((Form1.Baud_value & 16711680U /*0xFF0000*/) >> 16 /*0x10*/);
    Form1.Off_line_Date[Form1.Off_line_count, 5] = (byte) ((Form1.Line_time & 65280) >> 8);
    Form1.Off_line_Date[Form1.Off_line_count, 6] = (byte) (Form1.Line_time & (int) byte.MaxValue);
    Form1.Off_line_Date[Form1.Off_line_count, 7] = (byte) Form1.Volume_value;
    Form1.Off_line_Date[Form1.Off_line_count, 8] = (byte) 0;
    for (int index2 = 9; index2 < 16 /*0x10*/; ++index2)
      Form1.Off_line_Date[Form1.Off_line_count, index2] = (byte) 0;
    ++Form1.Off_line_count;
    for (int index3 = 0; index3 < 16 /*0x10*/; ++index3)
    {
      try
      {
        if (((DataGridView) this.dataGridViewX3).Rows[index3].Cells[0].Value.ToString() == "True")
        {
          Form1.Off_line_Date[Form1.Off_line_count, 0] = (byte) 119;
          Form1.Off_line_Date[Form1.Off_line_count, 1] = (byte) num1;
          Form1.Off_line_Date[Form1.Off_line_count, 2] = (byte) Form1.HEXstr_to_DEC(((DataGridView) this.dataGridViewX3).Rows[index3].Cells[3].Value.ToString());
          Form1.Off_line_Date[Form1.Off_line_count, 3] = !(((DataGridView) this.dataGridViewX3).Rows[index3].Cells[2].Value.ToString() == "发送") ? (byte) 1 : (byte) 0;
          Form1.Off_line_Date[Form1.Off_line_count, 4] = !(((DataGridView) this.dataGridViewX3).Rows[index3].Cells[6].Value.ToString() == "增强型校验和") ? (byte) 1 : (byte) 2;
          Form1.Off_line_Date[Form1.Off_line_count, 5] = (byte) Convert.ToInt16(((DataGridView) this.dataGridViewX3).Rows[index3].Cells[5].Value.ToString());
          if (((DataGridView) this.dataGridViewX3).Rows[index3].Cells[2].Value.ToString() == "发送")
          {
            string str = ((DataGridView) this.dataGridViewX3).Rows[index3].Cells[4].Value.ToString();
            for (int index4 = 0; index4 < (int) Form1.Off_line_Date[Form1.Off_line_count, 5]; ++index4)
              Form1.Off_line_Date[Form1.Off_line_count, index4 + 6] = (byte) Form1.HEXstr_to_DEC(str.Substring((index4 + 1) * 3 - 3, 2).ToString());
          }
          else
          {
            Form1.Off_line_Date[Form1.Off_line_count, 6] = (byte) 0;
            Form1.Off_line_Date[Form1.Off_line_count, 7] = (byte) 0;
            Form1.Off_line_Date[Form1.Off_line_count, 8] = (byte) 0;
            Form1.Off_line_Date[Form1.Off_line_count, 9] = (byte) 0;
            Form1.Off_line_Date[Form1.Off_line_count, 10] = (byte) 0;
            Form1.Off_line_Date[Form1.Off_line_count, 11] = (byte) 0;
            Form1.Off_line_Date[Form1.Off_line_count, 12] = (byte) 0;
            Form1.Off_line_Date[Form1.Off_line_count, 13] = (byte) 0;
          }
          ++Form1.Off_line_count;
          ++num1;
          ++num2;
        }
      }
      catch
      {
        init_Configuration.Output_Message = $"通道{index3.ToString()}的数据格式不正确！";
        int num3 = (int) init_Configuration.PDF_Interface.ShowDialog();
        return;
      }
    }
    Form1.Off_line_Date[Form1.Off_line_count, 0] = (byte) 17;
    Form1.Off_line_Date[Form1.Off_line_count, 1] = (byte) 4;
    Form1.Off_line_Date[Form1.Off_line_count, 2] = (byte) ((Form1.Baud_rate & 65280) >> 8);
    Form1.Off_line_Date[Form1.Off_line_count, 3] = (byte) (Form1.Baud_rate & (int) byte.MaxValue);
    Form1.Off_line_Date[Form1.Off_line_count, 4] = (byte) ((Form1.Baud_value & 16711680U /*0xFF0000*/) >> 16 /*0x10*/);
    Form1.Off_line_Date[Form1.Off_line_count, 5] = (byte) ((Form1.Line_time & 65280) >> 8);
    Form1.Off_line_Date[Form1.Off_line_count, 6] = (byte) (Form1.Line_time & (int) byte.MaxValue);
    Form1.Off_line_Date[Form1.Off_line_count, 7] = (byte) Form1.Volume_value;
    Form1.Off_line_Date[Form1.Off_line_count, 8] = (byte) num1;
    for (int index5 = 9; index5 < 16 /*0x10*/; ++index5)
      Form1.Off_line_Date[Form1.Off_line_count, index5] = (byte) 0;
    ++Form1.Off_line_count;
    if (num2 == 0)
    {
      init_Configuration.Output_Message = "请使能任意一个通道！";
      int num4 = (int) init_Configuration.PDF_Interface.ShowDialog();
    }
    else
    {
      this.progressBarEx1.Maximum = Form1.Off_line_count;
      this.progressBarEx1.Value = 0;
      Form1.RX_out_line_i = 0;
      ((Control) this.dataGridViewX3).Enabled = false;
      ((Control) this.dataGridViewX4).Enabled = false;
      ((Control) this.dataGridViewX5).Enabled = false;
      ((Control) this.dataGridViewX6).Enabled = false;
      ((Control) this.dataGridViewX7).Enabled = false;
      this.dS数字输入框2.Enabled = false;
      this.dS数字输入框3.Enabled = false;
      this.comboBox2.Enabled = false;
      this.qqCheckBox22.Enabled = false;
      this.qqCheckBox23.Enabled = false;
      this.qqCheckBox24.Enabled = false;
      this.qqCheckBox25.Enabled = false;
      this.qqTextBox52.Enabled = false;
      this.qqTextBox53.Enabled = false;
      this.qqTextBox54.Enabled = false;
      this.qqTextBox55.Enabled = false;
      this.imageButton2.Enabled = false;
      this.myToolBar1.Enabled = false;
      this.myButton5.Enabled = false;
      this.myButton5.NormalImage = (Image) Resources.down;
      init_Configuration.PDFForm_OK_flag = false;
      Form1.Rur_Mode = 7;
      this.Off_line_Task();
    }
  }

  private void dS按钮8_ButtonClick(object Sender)
  {
    Form1.Rur_Mode = 0;
    Form1.Send_Mode_Command(0, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
    if (!this.serialPort1.IsOpen)
      return;
    this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
    init_Configuration.Output_Message = "已退出离线模式！";
    int num = (int) init_Configuration.PDF_Interface.ShowDialog();
  }

  private void qqTextBox52_TextChanged(object sender, EventArgs e)
  {
    if (((DataGridView) this.dataGridViewX4).Rows.Count != 18)
      return;
    for (int index = 0; index < 18; ++index)
      ((DataGridView) this.dataGridViewX4).Rows[index].Cells[3].Value = (object) this.qqTextBox52.Text;
  }

  private void qqTextBox53_TextChanged(object sender, EventArgs e)
  {
    if (((DataGridView) this.dataGridViewX5).Rows.Count != 18)
      return;
    for (int index = 0; index < 18; ++index)
      ((DataGridView) this.dataGridViewX5).Rows[index].Cells[3].Value = (object) this.qqTextBox53.Text;
  }

  private void qqTextBox54_TextChanged(object sender, EventArgs e)
  {
    if (((DataGridView) this.dataGridViewX6).Rows.Count != 18)
      return;
    for (int index = 0; index < 18; ++index)
      ((DataGridView) this.dataGridViewX6).Rows[index].Cells[3].Value = (object) this.qqTextBox54.Text;
  }

  private void qqTextBox55_TextChanged(object sender, EventArgs e)
  {
    if (((DataGridView) this.dataGridViewX7).Rows.Count != 18)
      return;
    for (int index = 0; index < 18; ++index)
      ((DataGridView) this.dataGridViewX7).Rows[index].Cells[3].Value = (object) this.qqTextBox55.Text;
  }

  private void imageButton17_Click(object sender, EventArgs e)
  {
    if (!this.imageButton6.Enabled && !this.imageButton8.Enabled && !this.dS按钮2.Enabled && !this.dS按钮4.Enabled && !this.dS按钮6.Enabled && this.dS按钮9.Enabled)
    {
      if (Form1.Rur_Mode != 1)
      {
        Form1.Rur_Mode = 0;
        Form1.Send_Mode_Command(Form1.Rur_Mode, Form1.Baud_rate, 28, 100);
        this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
        Thread.Sleep(200);
        Form1.Rur_Mode = 1;
        Form1.Send_Mode_Command(Form1.Rur_Mode, Form1.Baud_rate, 28, 100);
        this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
        Thread.Sleep(20);
      }
      Form1.Host_Send_Data((byte) 60, "00 FF FF FF FF FF FF FF", 8, "V2");
      this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
    }
    else
    {
      init_Configuration.Output_Message = "请先关闭当前工作模式！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
    }
  }

  private void imageButton15_Click(object sender, EventArgs e)
  {
    if (Form1.Rur_Mode != 1)
    {
      if (Form1.Rur_Mode != 0)
      {
        Form1.Rur_Mode = 0;
        Form1.Send_Mode_Command(0, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
        this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
        Thread.Sleep(200);
      }
      Form1.Rur_Mode = 1;
      Form1.Send_Mode_Command(1, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
      this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
      Thread.Sleep(50);
    }
    lock (Form1.locker)
    {
      this.listViewNF1.Items.Clear();
      Array.Clear((Array) Form1.Single_Mode_Data, 0, Form1.Single_Mode_Data.Length);
      Array.Clear((Array) Form1.Single_time, 0, Form1.Single_time.Length);
      Form1.Single_count = 0;
      Form1.Single_Display_count = 0;
    }
    this.imageButton2.Enabled = false;
    this.myToolBar1.Enabled = false;
    this.imageButton15.Enabled = false;
    this.imageButton16.Enabled = true;
    this.imageButton17.Enabled = false;
    this.dS按钮13.Enabled = false;
    this.dS按钮13.贴图 = Resources.运行9;
    Form1.AUTO_flish_flag = false;
    Form1.Exit_AUTO_flag = false;
    Form1.AUTO_Progress_value = 0;
    this.prog13._setProgress(0);
    this.prog13._maxNum = 504;
    this.AUTO_Sync_Task = new Thread(new ThreadStart(this.AUTO_Sync_Thread));
    this.AUTO_Sync_Task.IsBackground = true;
    this.AUTO_Sync_Task.Start();
    this.AUTO_Task();
  }

  private void qqCheckBox19_CheckedChanged(object sender, EventArgs e)
  {
    if (this.qqCheckBox19.Checked)
    {
      try
      {
        Form1.Mask_ID1 = (byte) Form1.HEXstr_to_DEC(this.qqTextBox45.Text);
        if (Form1.Mask_ID1 > (byte) 63 /*0x3F*/)
        {
          init_Configuration.Output_Message = "ID超出范围(00-3F)！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        }
        else
          Form1.Mask1_flag = true;
      }
      catch
      {
        init_Configuration.Output_Message = "屏蔽ID1格式不正确！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      }
    }
    else
      Form1.Mask1_flag = false;
  }

  private void qqCheckBox20_CheckedChanged(object sender, EventArgs e)
  {
    if (this.qqCheckBox20.Checked)
    {
      try
      {
        Form1.Mask_ID2 = (byte) Form1.HEXstr_to_DEC(this.qqTextBox46.Text);
        if (Form1.Mask_ID2 > (byte) 63 /*0x3F*/)
        {
          init_Configuration.Output_Message = "ID超出范围(00-3F)！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        }
        else
          Form1.Mask2_flag = true;
      }
      catch
      {
        init_Configuration.Output_Message = "屏蔽ID2格式不正确！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      }
    }
    else
      Form1.Mask2_flag = false;
  }

  private void qqCheckBox21_CheckedChanged(object sender, EventArgs e)
  {
    if (this.qqCheckBox21.Checked)
    {
      try
      {
        Form1.Mask_ID3 = (byte) Form1.HEXstr_to_DEC(this.qqTextBox47.Text);
        if (Form1.Mask_ID3 > (byte) 63 /*0x3F*/)
        {
          init_Configuration.Output_Message = "ID超出范围(00-3F)！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        }
        else
          Form1.Mask3_flag = true;
      }
      catch
      {
        init_Configuration.Output_Message = "屏蔽ID3格式不正确！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      }
    }
    else
      Form1.Mask3_flag = false;
  }

  private void myButton1_Click(object sender, EventArgs e)
  {
    this.openFileDialog1.Title = "打开文件";
    this.openFileDialog1.Filter = "CSV File(*.csv)|*.csv";
    this.openFileDialog1.FileName = "";
    if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
      return;
    if (File.Exists(this.openFileDialog1.FileName))
    {
      FileStream fileStream = new FileStream(this.openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
      StreamReader streamReader = new StreamReader((Stream) fileStream, Encoding.Default);
      Array.Clear((Array) Form1.Play_Back_Data, 0, Form1.Play_Back_Data.Length);
      Form1.Play_cnt = 0U;
      Form1.Play_i = 0U;
      try
      {
        string str1;
        while ((str1 = streamReader.ReadLine()) != null)
        {
          string[] strArray = str1.Split(',');
          int length = strArray.Length;
          if (length == 9 && strArray[2] == "接收" && (strArray[8] == "V2" || strArray[8] == "V1"))
          {
            Form1.Play_Back_Data[(int) Form1.Play_cnt, 0] = (byte) 34;
            Form1.Play_Back_Data[(int) Form1.Play_cnt, 1] = (byte) 0;
            Form1.Play_Back_Data[(int) Form1.Play_cnt, 2] = (byte) Form1.HEXstr_to_DEC(strArray[4].Substring(0, 2));
            Form1.Play_Back_Data[(int) Form1.Play_cnt, 3] = (byte) 0;
            Form1.Play_Back_Data[(int) Form1.Play_cnt, 4] = !(strArray[8] == "V2") ? (byte) 1 : (byte) 2;
            Form1.Play_Back_Data[(int) Form1.Play_cnt, 5] = Convert.ToByte(strArray[5]);
            int startIndex = 0;
            string str2 = strArray[6];
            for (int index = 0; index < (int) Form1.Play_Back_Data[(int) Form1.Play_cnt, 5]; ++index)
            {
              Form1.Play_Back_Data[(int) Form1.Play_cnt, index + 6] = (byte) Form1.HEXstr_to_DEC(str2.Substring(startIndex, 2));
              startIndex += 3;
            }
            Form1.Play_Back_Data[(int) Form1.Play_cnt, 14] = (byte) 0;
            int num1 = 0;
            for (int index = 0; index < 15; ++index)
              num1 += (int) Form1.Play_Back_Data[(int) Form1.Play_cnt, index];
            int num2 = (~num1 & (int) byte.MaxValue) + 1;
            Form1.Play_Back_Data[(int) Form1.Play_cnt, 15] = (byte) num2;
            ++Form1.Play_cnt;
            if (Form1.Play_cnt >= (uint) ushort.MaxValue)
              break;
          }
          else if (length == 9 && strArray[8] == "帧头")
          {
            Form1.Play_Back_Data[(int) Form1.Play_cnt, 0] = (byte) 51;
            Form1.Play_Back_Data[(int) Form1.Play_cnt, 1] = (byte) 1;
            Form1.Play_Back_Data[(int) Form1.Play_cnt, 2] = (byte) Form1.HEXstr_to_DEC(strArray[4].Substring(0, 2));
            Form1.Play_Back_Data[(int) Form1.Play_cnt, 3] = (byte) 1;
            Form1.Play_Back_Data[(int) Form1.Play_cnt, 4] = (byte) 2;
            if (strArray[5] == "" || strArray[5] == null)
            {
              Form1.Play_Back_Data[(int) Form1.Play_cnt, 5] = (byte) 8;
            }
            else
            {
              Form1.Play_Back_Data[(int) Form1.Play_cnt, 5] = Convert.ToByte(strArray[5]);
              if (Form1.Play_Back_Data[(int) Form1.Play_cnt, 5] == (byte) 0 || Form1.Play_Back_Data[(int) Form1.Play_cnt, 5] >= (byte) 8)
                Form1.Play_Back_Data[(int) Form1.Play_cnt, 5] = (byte) 8;
            }
            int startIndex = 0;
            string str3 = strArray[6];
            if (str3 == "" || str3 == null)
              str3 = "00 00 00 00 00 00 00 00";
            for (int index = 0; index < (int) Form1.Play_Back_Data[(int) Form1.Play_cnt, 5]; ++index)
            {
              Form1.Play_Back_Data[(int) Form1.Play_cnt, index + 6] = (byte) Form1.HEXstr_to_DEC(str3.Substring(startIndex, 2));
              startIndex += 3;
            }
            Form1.Play_Back_Data[(int) Form1.Play_cnt, 14] = (byte) 0;
            int num3 = 0;
            for (int index = 0; index < 15; ++index)
              num3 += (int) Form1.Play_Back_Data[(int) Form1.Play_cnt, index];
            int num4 = (~num3 & (int) byte.MaxValue) + 1;
            Form1.Play_Back_Data[(int) Form1.Play_cnt, 15] = (byte) num4;
            ++Form1.Play_cnt;
            if (Form1.Play_cnt >= (uint) ushort.MaxValue)
              break;
          }
        }
      }
      catch
      {
        streamReader.Close();
        fileStream.Close();
        init_Configuration.Output_Message = "导入数据失败！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        return;
      }
      streamReader.Close();
      fileStream.Close();
      if (Form1.Play_cnt == 0U)
      {
        init_Configuration.Output_Message = "导入数据失败！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      }
      else
        this.dS标签15.Text = "发送状态:  0/" + Form1.Play_cnt.ToString();
    }
    else
    {
      init_Configuration.Output_Message = "数据文件丢失！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
    }
  }

  private void dS按钮15_ButtonClick(object Sender)
  {
    if (Form1.Play_cnt == 0U)
    {
      init_Configuration.Output_Message = "请导入数据！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
    }
    else
    {
      if (this.qqCheckBox19.Checked)
      {
        try
        {
          Form1.Mask_ID1 = (byte) Form1.HEXstr_to_DEC(this.qqTextBox45.Text);
          if (Form1.Mask_ID1 > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "ID超出范围(00-3F)！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          Form1.Mask1_flag = true;
        }
        catch
        {
          init_Configuration.Output_Message = "屏蔽ID1格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      else
        Form1.Mask1_flag = false;
      if (this.qqCheckBox20.Checked)
      {
        try
        {
          Form1.Mask_ID2 = (byte) Form1.HEXstr_to_DEC(this.qqTextBox46.Text);
          if (Form1.Mask_ID2 > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "ID超出范围(00-3F)！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          Form1.Mask2_flag = true;
        }
        catch
        {
          init_Configuration.Output_Message = "屏蔽ID2格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      else
        Form1.Mask2_flag = false;
      if (this.qqCheckBox21.Checked)
      {
        try
        {
          Form1.Mask_ID3 = (byte) Form1.HEXstr_to_DEC(this.qqTextBox47.Text);
          if (Form1.Mask_ID3 > (byte) 63 /*0x3F*/)
          {
            init_Configuration.Output_Message = "ID超出范围(00-3F)！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
          Form1.Mask3_flag = true;
        }
        catch
        {
          init_Configuration.Output_Message = "屏蔽ID3格式不正确！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      else
        Form1.Mask3_flag = false;
      try
      {
        Form1.Play_time = Convert.ToUInt32(this.qqTextBox44.Text);
        if (Convert.ToInt16(this.dS数字输入框1.Text) >= (short) 19000)
        {
          if (Form1.Play_time < 10U)
          {
            init_Configuration.Output_Message = "发送间隔超出范围(10-1000ms)！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        else if (Convert.ToInt16(this.dS数字输入框1.Text) >= (short) 9600)
        {
          if (Form1.Play_time < 20U)
          {
            init_Configuration.Output_Message = "发送间隔超出范围(20-1000ms)！";
            int num = (int) init_Configuration.PDF_Interface.ShowDialog();
            return;
          }
        }
        else if (Form1.Play_time < 30U)
        {
          init_Configuration.Output_Message = "发送间隔超出范围(30-1000ms)！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      catch
      {
        init_Configuration.Output_Message = "发送间隔格式不正确！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        return;
      }
      try
      {
        Form1.Play_number = Convert.ToUInt32(this.qqTextBox48.Text);
        if (Form1.Play_number > (uint) ushort.MaxValue)
        {
          init_Configuration.Output_Message = "回放次数超出范围(0-65535)！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      catch
      {
        init_Configuration.Output_Message = "回放次数格式不正确！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        return;
      }
      if (this.imageButton6.Enabled || this.imageButton8.Enabled || this.dS按钮2.Enabled || this.dS按钮4.Enabled || this.dS按钮6.Enabled || !this.imageButton15.Enabled)
      {
        init_Configuration.Output_Message = "软件正在工作中，暂无法启动！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
      }
      else
      {
        this.myToolBar1.Enabled = false;
        this.imageButton15.Enabled = false;
        this.myButton1.Enabled = false;
        this.qqTextBox44.Enabled = false;
        this.qqTextBox48.Enabled = false;
        this.qqCheckBox19.Enabled = false;
        this.qqCheckBox20.Enabled = false;
        this.qqCheckBox21.Enabled = false;
        this.qqTextBox45.Enabled = false;
        this.qqTextBox46.Enabled = false;
        this.qqTextBox47.Enabled = false;
        this.dS按钮15.Enabled = false;
        this.dS按钮15.贴图 = Resources.运行9;
        this.dS按钮14.Enabled = true;
        this.dS按钮14.贴图 = Resources.停止8;
        Form1.Rur_Mode = 0;
        Form1.Send_Mode_Command(0, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
        this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
        Thread.Sleep(100);
        Form1.Send_Mode_Command(1, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
        this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
        Thread.Sleep(50);
        Form1.Play_i = 0U;
        Form1.Play_number_cnt = 0U;
        Form1.Play_flag = true;
        Form1.Play_flash_flag = false;
        this.Play_Thread = new Thread(new ThreadStart(this.Play_Data_Task));
        this.Play_Thread.IsBackground = true;
        this.Play_Thread.Start();
        this.Play_Task();
      }
    }
  }

  private void dS按钮14_ButtonClick(object Sender)
  {
    Form1.Play_flag = false;
    Thread.Sleep(20);
  }

  private async void Play_Task() => await this.Play_TX_Task();

  private async Task Play_TX_Task()
  {
    byte[] Play_TX_Data = new byte[16 /*0x10*/];
    await Task.Run((Action) (() =>
    {
      try
      {
        do
        {
          Buffer.BlockCopy((Array) Form1.Play_Back_Data, (int) Form1.Play_i * 16 /*0x10*/, (Array) Play_TX_Data, 0, 16 /*0x10*/);
          while ((int) Play_TX_Data[2] == (int) Form1.Mask_ID1 && Form1.Mask1_flag || (int) Play_TX_Data[2] == (int) Form1.Mask_ID2 && Form1.Mask2_flag || (int) Play_TX_Data[2] == (int) Form1.Mask_ID3 && Form1.Mask3_flag)
          {
            Play_TX_Data[0] = (byte) 51;
            Play_TX_Data[1] = (byte) 1;
            Play_TX_Data[3] = (byte) 1;
            Play_TX_Data[15] = Form1.Check_Sum(Play_TX_Data, 15);
            this.serialPort1.Write(Play_TX_Data, 0, 16 /*0x10*/);
            Form1.Delay((int) Form1.Play_time);
            ++Form1.Play_i;
            if (Form1.Play_i < Form1.Play_cnt)
              Buffer.BlockCopy((Array) Form1.Play_Back_Data, (int) Form1.Play_i * 16 /*0x10*/, (Array) Play_TX_Data, 0, 16 /*0x10*/);
            else
              break;
          }
          if (Form1.Play_i < Form1.Play_cnt)
          {
            this.serialPort1.Write(Play_TX_Data, 0, 16 /*0x10*/);
            Form1.Delay((int) Form1.Play_time);
            ++Form1.Play_i;
          }
          if (Form1.Play_i >= Form1.Play_cnt)
          {
            if (Form1.Play_number == 0U)
            {
              Form1.Play_i = 0U;
              ++Form1.Play_number_cnt;
              if (Form1.Play_number_cnt >= (uint) ushort.MaxValue)
                Form1.Play_number_cnt = 0U;
            }
            else
            {
              Form1.Play_i = 0U;
              ++Form1.Play_number_cnt;
              if (Form1.Play_number_cnt >= Form1.Play_number)
                goto label_13;
            }
          }
        }
        while (Form1.Play_flag);
        goto label_11;
label_13:
        Form1.Play_flag = false;
        Form1.Play_flash_flag = true;
        return;
label_11:;
      }
      catch
      {
        Form1.System_UART_RX_Rrror_flag = true;
      }
    }));
  }

  public void Play_Data_Task()
  {
    do
    {
      Thread.Sleep(50);
      this.Play_Sync_Task();
    }
    while (Form1.Play_flag || Form1.Play_flash_flag);
    this.myToolBar1.Enabled = true;
    this.imageButton15.Enabled = true;
    this.myButton1.Enabled = true;
    this.qqTextBox44.Enabled = true;
    this.qqTextBox48.Enabled = true;
    this.qqCheckBox19.Enabled = true;
    this.qqCheckBox20.Enabled = true;
    this.qqCheckBox21.Enabled = true;
    this.qqTextBox45.Enabled = true;
    this.qqTextBox46.Enabled = true;
    this.qqTextBox47.Enabled = true;
    this.dS按钮15.Enabled = true;
    this.dS按钮15.贴图 = Resources.运行8;
    this.dS按钮14.Enabled = false;
    this.dS按钮14.贴图 = Resources.停止9;
    Form1.Rur_Mode = 0;
    Form1.Send_Mode_Command(0, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
    this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
    Thread.Sleep(20);
    this.Play_Thread.Abort();
  }

  public void Play_Sync_Task()
  {
    if (this.InvokeRequired)
    {
      this.Invoke((Delegate) new Form1.Play_Sync(this.Play_Sync_Task), new object[0]);
    }
    else
    {
      this.dS标签15.Text = $"发送状态:  {Form1.Play_i.ToString()}/{Form1.Play_cnt.ToString()}   {Form1.Play_number_cnt.ToString()}次循环";
      if (Form1.Play_flash_flag)
      {
        init_Configuration.Output_Message = "数据回放执行完成！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        Form1.Play_flash_flag = false;
      }
    }
  }

  private async void Off_line_Task() => await this.Off_line_TX_Task();

  private async Task Off_line_TX_Task()
  {
    Form1.Off_line_task_Send_i = 0;
    byte[] Send_Data = new byte[16 /*0x10*/];
    await Task.Run((Action) (() =>
    {
      Buffer.BlockCopy((Array) Form1.Off_line_Date, Form1.Off_line_task_Send_i * 16 /*0x10*/, (Array) Send_Data, 0, 16 /*0x10*/);
      this.serialPort1.Write(Send_Data, 0, 16 /*0x10*/);
      Thread.Sleep(300);
      ++Form1.Off_line_task_Send_i;
      while (Form1.Off_line_task_Send_i < Form1.Off_line_count)
      {
        Buffer.BlockCopy((Array) Form1.Off_line_Date, Form1.Off_line_task_Send_i * 16 /*0x10*/, (Array) Send_Data, 0, 16 /*0x10*/);
        this.serialPort1.Write(Send_Data, 0, 16 /*0x10*/);
        Thread.Sleep(100);
        ++Form1.Off_line_task_Send_i;
        if (Form1.Off_line_task_Send_i >= Form1.Off_line_count)
        {
          Thread.Sleep(300);
          Form1.mode4_flag = true;
        }
      }
    }));
  }

  public void Mode4_Task()
  {
    do
    {
      this.Exit_mode4_Task();
      Thread.Sleep(200);
    }
    while (!Form1.Exit_mode4_flag);
    Form1.Exit_mode4_flag = false;
    Form1.Off_line_Thread.Abort();
  }

  public void Exit_mode4_Task()
  {
    if (this.InvokeRequired)
    {
      this.Invoke((Delegate) new Form1.Exit_mode4(this.Exit_mode4_Task), new object[0]);
    }
    else
    {
      this.progressBarEx1.Value = Form1.Off_line_task_Send_i;
      this.progressBarEx1.Text = (Form1.Off_line_task_Send_i * 100 / this.progressBarEx1.Maximum).ToString() + "%";
      if (Form1.mode4_flag)
      {
        this.progressBarEx1.Value = this.progressBarEx1.Maximum;
        this.progressBarEx1.Text = "100%";
        this.myButton5.Enabled = true;
        this.myButton5.NormalImage = (Image) Resources.btn_green_normal;
        ((Control) this.dataGridViewX3).Enabled = true;
        ((Control) this.dataGridViewX4).Enabled = true;
        ((Control) this.dataGridViewX5).Enabled = true;
        ((Control) this.dataGridViewX6).Enabled = true;
        ((Control) this.dataGridViewX7).Enabled = true;
        this.dS数字输入框2.Enabled = true;
        this.dS数字输入框3.Enabled = true;
        this.imageButton2.Enabled = true;
        this.myToolBar1.Enabled = true;
        this.comboBox2.Enabled = true;
        this.qqCheckBox22.Enabled = true;
        this.qqCheckBox23.Enabled = true;
        this.qqCheckBox24.Enabled = true;
        this.qqCheckBox25.Enabled = true;
        this.qqTextBox52.Enabled = true;
        this.qqTextBox53.Enabled = true;
        this.qqTextBox54.Enabled = true;
        this.qqTextBox55.Enabled = true;
        init_Configuration.Output_Message = "离线模式设置成功！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        Form1.mode4_flag = false;
      }
      if (init_Configuration.PDFForm_OK_flag)
      {
        init_Configuration.PDFForm_OK_flag = false;
        Form1.Exit_mode4_flag = true;
      }
    }
  }

  public void Exit_mode4_Task_mode7()
  {
    if (Form1.Exit_mode4_flag)
      return;
    this.progressBarEx1.Value = Form1.Off_line_task_Send_i;
    this.progressBarEx1.Text = (Form1.Off_line_task_Send_i * 100 / this.progressBarEx1.Maximum).ToString() + "%";
    if (Form1.mode4_flag)
    {
      if (Form1.RX_out_line_i >= Form1.Off_line_count)
      {
        this.progressBarEx1.Value = this.progressBarEx1.Maximum;
        this.progressBarEx1.Text = "100%";
        this.myButton5.Enabled = true;
        this.myButton5.NormalImage = (Image) Resources.btn_green_normal;
        ((Control) this.dataGridViewX3).Enabled = true;
        ((Control) this.dataGridViewX4).Enabled = true;
        ((Control) this.dataGridViewX5).Enabled = true;
        ((Control) this.dataGridViewX6).Enabled = true;
        ((Control) this.dataGridViewX7).Enabled = true;
        this.dS数字输入框2.Enabled = true;
        this.dS数字输入框3.Enabled = true;
        this.imageButton2.Enabled = true;
        this.myToolBar1.Enabled = true;
        this.comboBox2.Enabled = true;
        this.qqCheckBox22.Enabled = true;
        this.qqCheckBox23.Enabled = true;
        this.qqCheckBox24.Enabled = true;
        this.qqCheckBox25.Enabled = true;
        this.qqTextBox52.Enabled = true;
        this.qqTextBox53.Enabled = true;
        this.qqTextBox54.Enabled = true;
        this.qqTextBox55.Enabled = true;
        init_Configuration.Output_Message = "离线模式设置成功！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        Form1.mode4_flag = false;
      }
      else
      {
        this.progressBarEx1.Value = 0;
        this.progressBarEx1.Text = "0%";
        this.myButton5.Enabled = true;
        this.myButton5.NormalImage = (Image) Resources.btn_green_normal;
        ((Control) this.dataGridViewX3).Enabled = true;
        ((Control) this.dataGridViewX4).Enabled = true;
        ((Control) this.dataGridViewX5).Enabled = true;
        ((Control) this.dataGridViewX6).Enabled = true;
        ((Control) this.dataGridViewX7).Enabled = true;
        this.dS数字输入框2.Enabled = true;
        this.dS数字输入框3.Enabled = true;
        this.imageButton2.Enabled = true;
        this.myToolBar1.Enabled = true;
        this.comboBox2.Enabled = true;
        this.qqCheckBox22.Enabled = true;
        this.qqCheckBox23.Enabled = true;
        this.qqCheckBox24.Enabled = true;
        this.qqCheckBox25.Enabled = true;
        this.qqTextBox52.Enabled = true;
        this.qqTextBox53.Enabled = true;
        this.qqTextBox54.Enabled = true;
        this.qqTextBox55.Enabled = true;
        init_Configuration.Output_Message = "设置失败，请检查芯片是否损坏！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        Form1.mode4_flag = false;
      }
    }
    if (init_Configuration.PDFForm_OK_flag)
    {
      init_Configuration.PDFForm_OK_flag = false;
      Form1.Exit_mode4_flag = true;
    }
  }

  private async void Timing_Receive_USB() => await this.Timing_Receive_USB_Task();

  private async Task Timing_Receive_USB_Task()
  {
    int sp_i = 0;
    await Task.Run((Action) (() =>
    {
      Form1.RX_count = 0;
      Form1.RX_Save_count = 0;
      try
      {
        do
        {
          if (this.serialPort1.IsOpen)
          {
            Form1.USB_Receive_Length = this.serialPort1.BytesToRead;
            if (Form1.USB_Receive_Length > 0)
            {
              Form1.Receive_USB_Data = new byte[Form1.USB_Receive_Length];
              this.serialPort1.Read(Form1.Receive_USB_Data, 0, Form1.USB_Receive_Length);
              Form1.System_Time_R = DateTime.Now;
              Buffer.BlockCopy((Array) Form1.Receive_USB_Data, 0, (Array) Form1.RX_buffer_Data, Form1.RX_count, Form1.USB_Receive_Length);
              Form1.RX_count += Form1.USB_Receive_Length;
              for (sp_i = 0; sp_i < (Form1.RX_count - Form1.RX_Save_count) / 16 /*0x10*/; ++sp_i)
              {
                Buffer.BlockCopy((Array) Form1.RX_buffer_Data, sp_i * 16 /*0x10*/ + Form1.RX_Save_count, (Array) Form1.Receive_Frame_Data, 0, 16 /*0x10*/);
                if (Form1.Rur_Mode == 1 || Form1.Rur_Mode == 2 || Form1.Rur_Mode == 3 || Form1.Rur_Mode == 4 || Form1.Rur_Mode == 5 || Form1.Rur_Mode == 7)
                {
                  if ((int) Form1.Receive_Frame_Data[15] == (int) Form1.Check_Sum(Form1.Receive_Frame_Data, 15) && (Form1.Receive_Frame_Data[0] == (byte) 51 || Form1.Receive_Frame_Data[0] == (byte) 68 || Form1.Receive_Frame_Data[0] == (byte) 85 || Form1.Receive_Frame_Data[0] == (byte) 221))
                  {
                    switch (Form1.Rur_Mode)
                    {
                      case 1:
                        Form1.Single_Async_Task();
                        break;
                      case 2:
                        Form1.List_Async_Task();
                        break;
                      case 3:
                        Form1.Slave_Async_Task();
                        break;
                      case 4:
                        Form1.Monitor_Async_Task();
                        break;
                      case 5:
                        Form1.Baud_Async_Task();
                        break;
                      case 7:
                        if (Form1.Receive_Frame_Data[1] == (byte) 83 && Form1.Receive_Frame_Data[2] == (byte) 69 && Form1.Receive_Frame_Data[3] == (byte) 78 && Form1.Receive_Frame_Data[4] == (byte) 84 && Form1.Receive_Frame_Data[5] == (byte) 79 && Form1.Receive_Frame_Data[6] == (byte) 75 && Form1.Receive_Frame_Data[15] == (byte) 79)
                        {
                          ++Form1.RX_out_line_i;
                          break;
                        }
                        break;
                    }
                    Array.Clear((Array) Form1.Receive_Frame_Data, 0, Form1.Receive_Frame_Data.Length);
                  }
                }
                else if (Form1.Rur_Mode == 6)
                {
                  for (sp_i = 0; sp_i < (Form1.RX_count - Form1.RX_Save_count) / 16 /*0x10*/; ++sp_i)
                  {
                    Buffer.BlockCopy((Array) Form1.RX_buffer_Data, sp_i * 16 /*0x10*/ + Form1.RX_Save_count, (Array) Form1.Receive_Frame_Data, 0, 16 /*0x10*/);
                    if (Form1.Receive_Frame_Data[0] == (byte) 51 && Form1.Receive_Frame_Data[2] == (byte) 63 /*0x3F*/)
                    {
                      if (Form1.Receive_Frame_Data[4] == (byte) 2 && Form1.Receive_Frame_Data[6] == (byte) 1 && Form1.Receive_Frame_Data[7] == (byte) 1)
                        Form1.ACK_Flag1 = true;
                      else
                        Form1.NoACK_Flag1 = true;
                    }
                    if (Form1.Receive_Frame_Data[0] == (byte) 51 && Form1.Receive_Frame_Data[2] == (byte) 63 /*0x3F*/)
                    {
                      if (Form1.Receive_Frame_Data[4] == (byte) 2 && Form1.Receive_Frame_Data[6] == (byte) 2 && Form1.Receive_Frame_Data[7] == (byte) 1)
                        Form1.ACK_Flag2 = true;
                      else
                        Form1.NoACK_Flag2 = true;
                    }
                    if (Form1.Receive_Frame_Data[0] == (byte) 51 && Form1.Receive_Frame_Data[2] == (byte) 63 /*0x3F*/)
                    {
                      if (Form1.Receive_Frame_Data[4] == (byte) 2 && Form1.Receive_Frame_Data[6] == (byte) 3 && Form1.Receive_Frame_Data[7] == (byte) 1)
                        Form1.ACK_Flag3 = true;
                      else
                        Form1.NoACK_Flag3 = true;
                    }
                    if (Form1.Receive_Frame_Data[0] == (byte) 51 && Form1.Receive_Frame_Data[2] == (byte) 63 /*0x3F*/)
                    {
                      if (Form1.Receive_Frame_Data[4] == (byte) 2 && Form1.Receive_Frame_Data[6] == (byte) 4 && Form1.Receive_Frame_Data[7] == (byte) 1)
                        Form1.ACK_Flag5 = true;
                      else
                        Form1.NoACK_Flag5 = true;
                    }
                    if (Form1.Receive_Frame_Data[0] == (byte) 51 && Form1.Receive_Frame_Data[2] == (byte) 61)
                    {
                      if (Form1.Receive_Frame_Data[4] == (byte) 1 && Form1.Receive_Frame_Data[6] == (byte) 5 && Form1.Receive_Frame_Data[7] == (byte) 1)
                        Form1.ACK_Flag6 = true;
                      else
                        Form1.NoACK_Flag6 = true;
                    }
                    Array.Clear((Array) Form1.Receive_Frame_Data, 0, Form1.Receive_Frame_Data.Length);
                  }
                }
              }
              Form1.RX_Save_count = Form1.RX_count / 16 /*0x10*/ * 16 /*0x10*/;
              if (Form1.RX_count >= 1048560 && Form1.RX_count == Form1.RX_Save_count)
              {
                Form1.RX_count = 0;
                Form1.RX_Save_count = 0;
                Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
              }
            }
          }
          else
            Form1.USB_Receive_Length = 0;
        }
        while (!Form1.Exit_Receive_flag);
        Form1.Exit_Receive_flag = false;
        Form1.Exit_Task_flag = true;
      }
      catch
      {
        Form1.System_UART_RX_Rrror_flag = true;
      }
    }));
  }

  public void USB_Receive_Task()
  {
    do
    {
      this.USB_Receive_DATA();
      Thread.Sleep(1);
    }
    while (!Form1.Exit_Task_flag);
    Form1.Exit_Task_flag = false;
    this.USB_Receive_Thread.Abort();
  }

  public void USB_Receive_DATA()
  {
    if (this.InvokeRequired)
    {
      this.Invoke((Delegate) new Form1.USB_Receive(this.USB_Receive_DATA), new object[0]);
    }
    else
    {
      if (Form1.Rur_Mode == 1 || Form1.Rur_Mode == 2 || Form1.Rur_Mode == 3 || Form1.Rur_Mode == 4 || Form1.Rur_Mode == 5 || Form1.Rur_Mode == 7)
      {
        switch (Form1.Rur_Mode)
        {
          case 1:
            this.Single_Sync_Task();
            break;
          case 2:
            this.List_Sync_Task();
            break;
          case 3:
            this.Slave_Sync_Task();
            break;
          case 4:
            this.Monitor_Sync_Task();
            break;
          case 5:
            this.Baud_Sync_Task();
            break;
          case 7:
            this.Exit_mode4_Task_mode7();
            break;
        }
      }
      if (Form1.System_UART_RX_Rrror_flag)
      {
        Form1.System_UART_RX_Rrror_flag = false;
        init_Configuration.Output_Message = "设备被强行拔出USB，请重新启动软件！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        this.comboBox1.Items.Clear();
        Form1.Port_Number = 0;
        this.imageButton1.Text = "搜索设备";
        Form1.Exit_Task_flag = true;
        this.myToolBar1.Enabled = true;
        Form1.Device_switch_flag = false;
        this.imageButton2.NormalImage = (Image) Resources.关闭;
        this.imageButton2.Enabled = true;
        this.imageButton1.Enabled = true;
        this.comboBox1.Enabled = true;
        this.dS数字输入框1.Enabled = true;
        this.qqRadioButton1.Enabled = true;
        this.qqRadioButton2.Enabled = true;
        this.qqRadioButton3.Enabled = false;
        this.qqRadioButton4.Enabled = false;
        this.qqRadioButton5.Enabled = false;
        this.qqRadioButton6.Enabled = false;
        this.qqTextBox10.Enabled = false;
        this.qqTextBox17.Enabled = false;
        this.imageButton5.Enabled = false;
        this.imageButton6.Enabled = false;
        this.imageButton7.Enabled = false;
        this.imageButton8.Enabled = false;
        this.qqCheckBox1.Enabled = true;
        this.qqCheckBox2.Enabled = true;
        this.qqCheckBox3.Enabled = true;
        this.qqTextBox1.Enabled = true;
        this.qqTextBox4.Enabled = true;
        this.qqTextBox7.Enabled = true;
        this.qqTextBox2.Enabled = true;
        this.qqTextBox5.Enabled = true;
        this.qqTextBox8.Enabled = true;
        this.qqTextBox3.Enabled = true;
        this.qqTextBox6.Enabled = true;
        this.qqTextBox9.Enabled = true;
        this.qqCheckBox4.Enabled = true;
        this.qqCheckBox5.Enabled = true;
        this.qqCheckBox6.Enabled = true;
        this.qqTextBox11.Enabled = true;
        this.qqTextBox13.Enabled = true;
        this.qqTextBox15.Enabled = true;
        this.qqTextBox12.Enabled = true;
        this.qqTextBox14.Enabled = true;
        this.qqTextBox16.Enabled = true;
        this.imageButton4.Enabled = true;
        this.qqRadioButton3.Enabled = true;
        this.qqRadioButton4.Enabled = true;
        this.qqRadioButton5.Enabled = true;
        this.qqRadioButton6.Enabled = true;
        this.qqTextBox10.Enabled = true;
        this.qqTextBox17.Enabled = true;
        this.imageButton5.Enabled = true;
        this.imageButton6.Enabled = false;
        this.imageButton7.Enabled = true;
        this.imageButton8.Enabled = false;
        ((DataGridView) this.dataGridViewX1).Columns[0].ReadOnly = false;
        ((DataGridView) this.dataGridViewX1).Columns[1].ReadOnly = false;
        ((DataGridView) this.dataGridViewX1).Columns[2].ReadOnly = false;
        ((DataGridView) this.dataGridViewX1).Columns[3].ReadOnly = false;
        ((DataGridView) this.dataGridViewX1).Columns[5].ReadOnly = false;
        ((DataGridView) this.dataGridViewX1).Columns[6].ReadOnly = false;
        ((DataGridView) this.dataGridViewX1).Columns[0].DefaultCellStyle.BackColor = SystemColors.Window;
        ((DataGridView) this.dataGridViewX1).Columns[1].DefaultCellStyle.BackColor = SystemColors.Window;
        ((DataGridView) this.dataGridViewX1).Columns[2].DefaultCellStyle.BackColor = SystemColors.Window;
        ((DataGridView) this.dataGridViewX1).Columns[3].DefaultCellStyle.BackColor = SystemColors.Window;
        ((DataGridView) this.dataGridViewX1).Columns[5].DefaultCellStyle.BackColor = SystemColors.Window;
        ((DataGridView) this.dataGridViewX1).Columns[6].DefaultCellStyle.BackColor = SystemColors.Window;
        this.dS按钮1.Enabled = false;
        this.dS按钮2.Enabled = false;
        this.dS按钮1.贴图 = Resources.运行8;
        this.dS按钮2.贴图 = Resources.停止8;
        ((DataGridView) this.dataGridViewX2).Columns[0].ReadOnly = false;
        ((DataGridView) this.dataGridViewX2).Columns[1].ReadOnly = false;
        ((DataGridView) this.dataGridViewX2).Columns[2].ReadOnly = false;
        ((DataGridView) this.dataGridViewX2).Columns[3].ReadOnly = false;
        ((DataGridView) this.dataGridViewX2).Columns[5].ReadOnly = false;
        ((DataGridView) this.dataGridViewX2).Columns[6].ReadOnly = false;
        ((DataGridView) this.dataGridViewX2).Columns[0].DefaultCellStyle.BackColor = SystemColors.Window;
        ((DataGridView) this.dataGridViewX2).Columns[1].DefaultCellStyle.BackColor = SystemColors.Window;
        ((DataGridView) this.dataGridViewX2).Columns[2].DefaultCellStyle.BackColor = SystemColors.Window;
        ((DataGridView) this.dataGridViewX2).Columns[3].DefaultCellStyle.BackColor = SystemColors.Window;
        ((DataGridView) this.dataGridViewX2).Columns[5].DefaultCellStyle.BackColor = SystemColors.Window;
        ((DataGridView) this.dataGridViewX2).Columns[6].DefaultCellStyle.BackColor = SystemColors.Window;
        ((Control) this.dataGridViewX2).Enabled = false;
        this.dS按钮3.Enabled = false;
        this.dS按钮4.Enabled = false;
        this.dS按钮3.贴图 = Resources.运行8;
        this.dS按钮4.贴图 = Resources.停止8;
        this.qqCheckBox7.Enabled = true;
        this.qqCheckBox8.Enabled = true;
        this.qqCheckBox9.Enabled = true;
        this.qqCheckBox10.Enabled = true;
        this.qqCheckBox11.Enabled = true;
        this.qqCheckBox12.Enabled = true;
        this.qqCheckBox13.Enabled = true;
        this.qqCheckBox14.Enabled = true;
        this.qqCheckBox15.Enabled = true;
        this.qqCheckBox16.Enabled = true;
        this.qqCheckBox17.Enabled = true;
        this.qqCheckBox18.Enabled = true;
        this.qqTextBox18.Enabled = true;
        this.qqTextBox19.Enabled = true;
        this.qqTextBox20.Enabled = true;
        this.qqTextBox21.Enabled = true;
        this.qqTextBox22.Enabled = true;
        this.qqTextBox23.Enabled = true;
        this.qqTextBox24.Enabled = true;
        this.qqTextBox25.Enabled = true;
        this.qqTextBox26.Enabled = true;
        this.qqTextBox27.Enabled = true;
        this.qqTextBox28.Enabled = true;
        this.qqTextBox29.Enabled = true;
        this.imageButton14.Enabled = true;
        this.qqRadioButton11.Enabled = true;
        this.qqRadioButton12.Enabled = true;
        this.dS按钮5.Enabled = false;
        this.dS按钮6.Enabled = false;
        this.dS按钮5.贴图 = Resources.运行8;
        this.dS按钮6.贴图 = Resources.停止8;
        this.myButton5.Enabled = false;
        this.myButton5.NormalImage = (Image) Resources.down;
        Form1.BOOT_ON_flag = false;
        this.dS按钮9.Enabled = false;
        this.dS按钮10.贴图 = Resources.按钮3;
        this.dS按钮11.贴图 = Resources.灯6;
        this.dS按钮10.Enabled = false;
        this.dS按钮11.Enabled = false;
        this.imageButton15.Enabled = false;
        this.imageButton16.Enabled = true;
        this.imageButton17.Enabled = false;
        this.dS按钮13.Enabled = false;
        this.dS按钮13.贴图 = Resources.运行9;
        this.myButton1.Enabled = false;
        this.dS按钮15.Enabled = false;
        this.dS按钮15.贴图 = Resources.运行9;
        this.dS按钮14.Enabled = false;
        this.dS按钮14.贴图 = Resources.停止9;
        this.myButton3.Enabled = false;
        this.myButton2.Enabled = false;
        this.dS按钮17.Enabled = false;
        this.dS按钮16.Enabled = false;
        this.dS按钮17.贴图 = Resources.运行9;
        this.dS按钮16.贴图 = Resources.停止9;
        this.myButton4.Enabled = false;
      }
    }
  }

  public static void Monitor_Async_Task()
  {
    if (Form1.Receive_Frame_Data[0] != (byte) 68)
      return;
    if (!Form1.Monitor_Mode)
    {
      if (Form1.Monitor_EN[(int) Form1.Receive_Frame_Data[2], 0] == (byte) 1)
      {
        Buffer.BlockCopy((Array) Form1.Receive_Frame_Data, 0, (Array) Form1.Monitor_Data, Form1.Monitor_count * 16 /*0x10*/, 16 /*0x10*/);
        Form1.Monitor_time[Form1.Monitor_count, 0] = Form1.System_Time_R.ToString("yyyy-MM-dd HH:mm:ss:fff");
        ++Form1.Monitor_count;
        if (Form1.Monitor_count >= (int) ushort.MaxValue)
          Form1.Monitor_count = 0;
      }
    }
    else
    {
      Buffer.BlockCopy((Array) Form1.Receive_Frame_Data, 0, (Array) Form1.Monitor_Data, Form1.Monitor_count * 16 /*0x10*/, 16 /*0x10*/);
      Form1.Monitor_time[Form1.Monitor_count, 0] = Form1.System_Time_R.ToString("yyyy-MM-dd HH:mm:ss:fff");
      ++Form1.Monitor_count;
      if (Form1.Monitor_count >= (int) ushort.MaxValue)
        Form1.Monitor_count = 0;
    }
  }

  public void Monitor_Sync_Task()
  {
    int num = 0;
    if (!Form1.Monitor_Display_Mode)
    {
      if (Form1.Monitor_Display_count == Form1.Monitor_count)
        return;
      Form1.M_ID = "";
      Form1.M_Str = "";
      Form1.M_State = "";
      Form1.M_Check = "";
      Form1.M_Length = 0;
      Form1.M_ID = Form1.DECstr_to_HEXstr(Form1.Monitor_Data[Form1.Monitor_Display_count, 2].ToString());
      Form1.M_ID = $"{Form1.M_ID}[{Form1.LIN_PID_Parity(Form1.M_ID)}]";
      Form1.M_State = Form1.Monitor_Data[Form1.Monitor_Display_count, 4] != (byte) 0 ? (Form1.Monitor_Data[Form1.Monitor_Display_count, 4] != (byte) 1 ? (Form1.Monitor_Data[Form1.Monitor_Display_count, 4] != (byte) 2 ? "帧头" : "V2") : "V1") : "校验和错误";
      Form1.M_Length = (int) Form1.Monitor_Data[Form1.Monitor_Display_count, 5];
      for (int index = 6; index < Form1.M_Length + 6; ++index)
        Form1.M_Str = $"{Form1.M_Str}{Form1.DECstr_to_HEXstr(Form1.Monitor_Data[Form1.Monitor_Display_count, index].ToString())} ";
      Form1.M_Check = Form1.DECstr_to_HEXstr(Form1.Monitor_Data[Form1.Monitor_Display_count, 14].ToString());
      Form1.M_Static_Save[Form1.Monitor_Display_count, 0] = Form1.Monitor_Display_count.ToString();
      Form1.M_Static_Save[Form1.Monitor_Display_count, 1] = "2";
      Form1.M_Static_Save[Form1.Monitor_Display_count, 2] = "接收";
      Form1.M_Static_Save[Form1.Monitor_Display_count, 3] = Form1.Monitor_time[Form1.Monitor_Display_count, 0];
      Form1.M_Static_Save[Form1.Monitor_Display_count, 4] = Form1.M_ID;
      Form1.M_Static_Save[Form1.Monitor_Display_count, 5] = Form1.M_Length.ToString();
      Form1.M_Static_Save[Form1.Monitor_Display_count, 6] = Form1.M_Str;
      Form1.M_Static_Save[Form1.Monitor_Display_count, 7] = Form1.M_Check;
      Form1.M_Static_Save[Form1.Monitor_Display_count, 8] = Form1.M_State;
      this.listViewNF4.Items.Add(Form1.Monitor_Display_count.ToString());
      this.listViewNF4.Items[Form1.Monitor_Display_count].SubItems.Add("2");
      this.listViewNF4.Items[Form1.Monitor_Display_count].SubItems.Add("接收");
      this.listViewNF4.Items[Form1.Monitor_Display_count].SubItems.Add(Form1.Monitor_time[Form1.Monitor_Display_count, 0]);
      this.listViewNF4.Items[Form1.Monitor_Display_count].SubItems.Add(Form1.M_ID);
      this.listViewNF4.Items[Form1.Monitor_Display_count].SubItems.Add(Form1.M_Length.ToString());
      this.listViewNF4.Items[Form1.Monitor_Display_count].SubItems.Add(Form1.M_Str);
      this.listViewNF4.Items[Form1.Monitor_Display_count].SubItems.Add(Form1.M_Check);
      this.listViewNF4.Items[Form1.Monitor_Display_count].SubItems.Add(Form1.M_State);
      this.listViewNF4.Items[Form1.Monitor_Display_count].Selected = true;
      this.listViewNF4.Items[Form1.Monitor_Display_count].EnsureVisible();
      ++Form1.Monitor_Display_count;
      if (Form1.Monitor_Display_count >= (int) ushort.MaxValue)
      {
        lock (Form1.locker)
        {
          this.listViewNF4.Items.Clear();
          Form1.Monitor_Display_count = 0;
          Form1.mode4_Save_Task_flag = true;
        }
      }
    }
    else if (Form1.Monitor_Display_count != Form1.Monitor_count)
    {
      if (Form1.Monitor_Static[(int) Form1.Monitor_Data[Form1.Monitor_Display_count, 2], 0] == byte.MaxValue)
      {
        Form1.M_ID = "";
        Form1.M_Str = "";
        Form1.M_State = "";
        Form1.M_Check = "";
        Form1.M_Length = 0;
        Form1.M_ID = Form1.DECstr_to_HEXstr(Form1.Monitor_Data[Form1.Monitor_Display_count, 2].ToString());
        Form1.M_ID = $"{Form1.M_ID}[{Form1.LIN_PID_Parity(Form1.M_ID)}]";
        Form1.M_State = Form1.Monitor_Data[Form1.Monitor_Display_count, 4] != (byte) 0 ? (Form1.Monitor_Data[Form1.Monitor_Display_count, 4] != (byte) 1 ? (Form1.Monitor_Data[Form1.Monitor_Display_count, 4] != (byte) 2 ? "帧头" : "V2") : "V1") : "校验和错误";
        Form1.M_Length = (int) Form1.Monitor_Data[Form1.Monitor_Display_count, 5];
        for (int index = 6; index < Form1.M_Length + 6; ++index)
          Form1.M_Str = $"{Form1.M_Str}{Form1.DECstr_to_HEXstr(Form1.Monitor_Data[Form1.Monitor_Display_count, index].ToString())} ";
        Form1.M_Check = Form1.DECstr_to_HEXstr(Form1.Monitor_Data[Form1.Monitor_Display_count, 14].ToString());
        num = 0;
        int count = this.listViewNF4.Items.Count;
        Form1.M_Static_Save[Form1.Monitor_Display_count, 0] = Form1.Monitor_Display_count.ToString();
        Form1.M_Static_Save[Form1.Monitor_Display_count, 1] = "2";
        Form1.M_Static_Save[Form1.Monitor_Display_count, 2] = "接收";
        Form1.M_Static_Save[Form1.Monitor_Display_count, 3] = Form1.Monitor_time[Form1.Monitor_Display_count, 0];
        Form1.M_Static_Save[Form1.Monitor_Display_count, 4] = Form1.M_ID;
        Form1.M_Static_Save[Form1.Monitor_Display_count, 5] = Form1.M_Length.ToString();
        Form1.M_Static_Save[Form1.Monitor_Display_count, 6] = Form1.M_Str;
        Form1.M_Static_Save[Form1.Monitor_Display_count, 7] = Form1.M_Check;
        Form1.M_Static_Save[Form1.Monitor_Display_count, 8] = Form1.M_State;
        this.listViewNF4.Items.Add(count.ToString());
        this.listViewNF4.Items[count].SubItems.Add("2");
        this.listViewNF4.Items[count].SubItems.Add("接收");
        this.listViewNF4.Items[count].SubItems.Add(Form1.Monitor_time[Form1.Monitor_Display_count, 0]);
        this.listViewNF4.Items[count].SubItems.Add(Form1.M_ID);
        this.listViewNF4.Items[count].SubItems.Add(Form1.M_Length.ToString());
        this.listViewNF4.Items[count].SubItems.Add(Form1.M_Str);
        this.listViewNF4.Items[count].SubItems.Add(Form1.M_Check);
        this.listViewNF4.Items[count].SubItems.Add(Form1.M_State);
        this.listViewNF4.Items[count].Selected = true;
        this.listViewNF4.Items[count].EnsureVisible();
        Form1.Monitor_Static[(int) Form1.Monitor_Data[Form1.Monitor_Display_count, 2], 0] = (byte) count;
      }
      else
      {
        int index1 = (int) Form1.Monitor_Static[(int) Form1.Monitor_Data[Form1.Monitor_Display_count, 2], 0];
        Form1.M_ID = "";
        Form1.M_Str = "";
        Form1.M_State = "";
        Form1.M_Check = "";
        Form1.M_Length = 0;
        Form1.M_ID = Form1.DECstr_to_HEXstr(Form1.Monitor_Data[Form1.Monitor_Display_count, 2].ToString());
        Form1.M_ID = $"{Form1.M_ID}[{Form1.LIN_PID_Parity(Form1.M_ID)}]";
        Form1.M_State = Form1.Monitor_Data[Form1.Monitor_Display_count, 4] != (byte) 0 ? (Form1.Monitor_Data[Form1.Monitor_Display_count, 4] != (byte) 1 ? (Form1.Monitor_Data[Form1.Monitor_Display_count, 4] != (byte) 2 ? "帧头" : "V2") : "V1") : "校验和错误";
        Form1.M_Length = (int) Form1.Monitor_Data[Form1.Monitor_Display_count, 5];
        for (int index2 = 6; index2 < Form1.M_Length + 6; ++index2)
          Form1.M_Str = $"{Form1.M_Str}{Form1.DECstr_to_HEXstr(Form1.Monitor_Data[Form1.Monitor_Display_count, index2].ToString())} ";
        Form1.M_Check = Form1.DECstr_to_HEXstr(Form1.Monitor_Data[Form1.Monitor_Display_count, 14].ToString());
        Form1.M_Static_Save[Form1.Monitor_Display_count, 0] = Form1.Monitor_Display_count.ToString();
        Form1.M_Static_Save[Form1.Monitor_Display_count, 1] = "2";
        Form1.M_Static_Save[Form1.Monitor_Display_count, 2] = "接收";
        Form1.M_Static_Save[Form1.Monitor_Display_count, 3] = Form1.Monitor_time[Form1.Monitor_Display_count, 0];
        Form1.M_Static_Save[Form1.Monitor_Display_count, 4] = Form1.M_ID;
        Form1.M_Static_Save[Form1.Monitor_Display_count, 5] = Form1.M_Length.ToString();
        Form1.M_Static_Save[Form1.Monitor_Display_count, 6] = Form1.M_Str;
        Form1.M_Static_Save[Form1.Monitor_Display_count, 7] = Form1.M_Check;
        Form1.M_Static_Save[Form1.Monitor_Display_count, 8] = Form1.M_State;
        this.listViewNF4.Items[index1].SubItems[3].Text = Form1.Monitor_time[Form1.Monitor_Display_count, 0];
        this.listViewNF4.Items[index1].SubItems[4].Text = Form1.M_ID;
        this.listViewNF4.Items[index1].SubItems[5].Text = Form1.M_Length.ToString();
        this.listViewNF4.Items[index1].SubItems[6].Text = Form1.M_Str;
        this.listViewNF4.Items[index1].SubItems[7].Text = Form1.M_Check;
        this.listViewNF4.Items[index1].SubItems[8].Text = Form1.M_State;
      }
      ++Form1.Monitor_Display_count;
      if (Form1.Monitor_Display_count >= (int) ushort.MaxValue)
      {
        lock (Form1.locker)
        {
          Form1.Monitor_Display_count = 0;
          Form1.mode4_Save_Task_flag = true;
        }
      }
    }
  }

  private async void Save_listViewNF4_Asynchronous()
  {
    await Form1.Save_listViewNF4_Asynchronous_Task();
  }

  private static async Task Save_listViewNF4_Asynchronous_Task()
  {
    int Save_Task_i = 0;
    int Save_i = 0;
    string Save_Task_str = "";
    string Save_ID = "";
    string Save_State = "";
    string Save_str = "";
    string Save_Check = "";
    int Save_Length = 0;
    await Task.Run((Action) (() =>
    {
      if (Form1.Monitor_Display_Mode)
      {
        FileInfo fileInfo = new FileInfo(Form1.Save_FileName_str);
        FileStream fileStream = new FileStream(Form1.Save_FileName_str, FileMode.Create, FileAccess.Write);
        StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.UTF8);
        Save_Task_str = "";
        Save_Task_str = "序号,通道,方向,时间,ID,长度,数据,校验和,状态";
        streamWriter.WriteLine(Save_Task_str);
        do
        {
          Save_Task_str = "";
          Save_Task_str = $"{Form1.M_Static_Save[Save_Task_i, 0]},{Form1.M_Static_Save[Save_Task_i, 1]},{Form1.M_Static_Save[Save_Task_i, 2]},{Form1.M_Static_Save[Save_Task_i, 3]},{Form1.M_Static_Save[Save_Task_i, 4]},{Form1.M_Static_Save[Save_Task_i, 5]},{Form1.M_Static_Save[Save_Task_i, 6]},{Form1.M_Static_Save[Save_Task_i, 7]},{Form1.M_Static_Save[Save_Task_i, 8]}";
          streamWriter.WriteLine(Save_Task_str);
          ++Save_Task_i;
          Form1.Save_ProgressBar_i = Save_Task_i;
          Thread.Sleep(1);
        }
        while (Save_Task_i < Form1.M_Static_i);
        streamWriter.Close();
        fileStream.Close();
        Form1.Save_Finish_flag = true;
      }
      else
      {
        FileInfo fileInfo = new FileInfo(Form1.Save_FileName_str);
        FileStream fileStream = new FileStream(Form1.Save_FileName_str, FileMode.Create, FileAccess.Write);
        StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.UTF8);
        Save_Task_str = "";
        Save_Task_str = "序号,通道,方向,时间,ID,长度,数据,校验和,状态";
        streamWriter.WriteLine(Save_Task_str);
        do
        {
          Save_ID = "";
          Save_ID = Form1.DECstr_to_HEXstr(Form1.Monitor_Data[Save_Task_i, 2].ToString());
          Save_ID = $"{Save_ID}[{Form1.LIN_PID_Parity(Save_ID)}]";
          Save_State = "";
          Save_State = Form1.Monitor_Data[Save_Task_i, 4] != (byte) 0 ? (Form1.Monitor_Data[Save_Task_i, 4] != (byte) 1 ? (Form1.Monitor_Data[Save_Task_i, 4] != (byte) 2 ? "帧头" : "V2") : "V1") : "校验和错误";
          Save_Length = 0;
          Save_Length = (int) Form1.Monitor_Data[Save_Task_i, 5];
          Save_str = "";
          for (Save_i = 6; Save_i < Save_Length + 6; ++Save_i)
            Save_str = $"{Save_str}{Form1.DECstr_to_HEXstr(Form1.Monitor_Data[Save_Task_i, Save_i].ToString())} ";
          Save_Check = "";
          Save_Check = Form1.DECstr_to_HEXstr(Form1.Monitor_Data[Save_Task_i, 14].ToString());
          Save_Task_str = "";
          Save_Task_str = $"{Save_Task_i.ToString()},2,接收,{Form1.Monitor_time[Save_Task_i, 0]},{Save_ID},{Save_Length.ToString()},{Save_str},{Save_Check},{Save_State}";
          streamWriter.WriteLine(Save_Task_str);
          ++Save_Task_i;
          Form1.Save_ProgressBar_i = Save_Task_i;
          Thread.Sleep(1);
        }
        while (Save_Task_i < Form1.Monitor_count);
        streamWriter.Close();
        fileStream.Close();
        Form1.Save_Finish_flag = true;
      }
    }));
  }

  private async void RTOS_Save_mode4_Asynchronous()
  {
    await Form1.RTOS_Save_mode4_Asynchronous_Task();
  }

  private static async Task RTOS_Save_mode4_Asynchronous_Task()
  {
    string Save_Task_str = "";
    await Task.Run((Action) (() =>
    {
      Form1.mode4_Save_Task_i = 0;
      string str1 = Path.Combine(Application.StartupPath, "Data\\");
      Form1.RTOS_Time = DateTime.Now;
      Form1.RTOS_Save_FileName_str = $"{str1}监听模式 Data for {Form1.RTOS_Time.ToString("yyyy-MM-dd HH-mm-ss-fff")}.csv";
      FileInfo fileInfo = new FileInfo(Form1.RTOS_Save_FileName_str);
      FileStream fileStream = new FileStream(Form1.RTOS_Save_FileName_str, FileMode.Create, FileAccess.Write);
      StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.UTF8);
      Save_Task_str = "";
      Save_Task_str = "序号,通道,方向,时间,ID,长度,数据,校验和,状态";
      streamWriter.WriteLine(Save_Task_str);
      while (true)
      {
        if (Form1.mode4_Save_Task_i != Form1.Monitor_Display_count && Form1.mode4_Save_Task_i < (int) ushort.MaxValue)
        {
          Save_Task_str = "";
          Save_Task_str = $"{Form1.M_Static_Save[Form1.mode4_Save_Task_i, 0]},{Form1.M_Static_Save[Form1.mode4_Save_Task_i, 1]},{Form1.M_Static_Save[Form1.mode4_Save_Task_i, 2]},{Form1.M_Static_Save[Form1.mode4_Save_Task_i, 3]},{Form1.M_Static_Save[Form1.mode4_Save_Task_i, 4]},{Form1.M_Static_Save[Form1.mode4_Save_Task_i, 5]},{Form1.M_Static_Save[Form1.mode4_Save_Task_i, 6]},{Form1.M_Static_Save[Form1.mode4_Save_Task_i, 7]},{Form1.M_Static_Save[Form1.mode4_Save_Task_i, 8]}";
          streamWriter.WriteLine(Save_Task_str);
          ++Form1.mode4_Save_Task_i;
        }
        Thread.Sleep(1);
        if (Form1.mode4_Save_Task_i >= (int) ushort.MaxValue && Form1.mode4_Save_Task_flag)
        {
          Form1.mode4_Save_Task_flag = false;
          Form1.mode4_Save_Task_i = 0;
          streamWriter.Close();
          fileStream.Close();
          if (Form1.mode4_Save_Task_i != Form1.Monitor_Display_count || Form1.Rur_Mode != 0 || Form1.Monitor_Display_count != Form1.Monitor_count)
          {
            string str2 = Path.Combine(Application.StartupPath, "Data\\");
            Form1.RTOS_Time = DateTime.Now;
            Form1.RTOS_Save_FileName_str = $"{str2}监听模式 Data for {Form1.RTOS_Time.ToString("yyyy-MM-dd HH-mm-ss-fff")}.csv";
            fileInfo = new FileInfo(Form1.RTOS_Save_FileName_str);
            fileStream = new FileStream(Form1.RTOS_Save_FileName_str, FileMode.Create, FileAccess.Write);
            streamWriter = new StreamWriter((Stream) fileStream, Encoding.UTF8);
            Save_Task_str = "";
            Save_Task_str = "序号,通道,方向,时间,ID,长度,数据,校验和,状态";
            streamWriter.WriteLine(Save_Task_str);
          }
          else
            break;
        }
        else if (Form1.mode4_Save_Task_i != Form1.Monitor_Display_count || Form1.Rur_Mode != 0 || Form1.Monitor_Display_count != Form1.Monitor_count)
        {
          if (!Form1.Device_switch_flag)
            goto label_8;
        }
        else
          goto label_6;
      }
      return;
label_6:
      Form1.mode4_Save_Task_i = 0;
      streamWriter.Close();
      fileStream.Close();
      return;
label_8:
      Form1.mode4_Save_Task_i = 0;
      streamWriter.Close();
      fileStream.Close();
    }));
  }

  public void Save_listViewNF4_Data()
  {
    do
    {
      this.Save_listViewNF4_Data_Task();
      Thread.Sleep(100);
    }
    while (!Form1.Exit_Save_listViewNF4_flag);
    Form1.Exit_Save_listViewNF4_flag = false;
    this.Save_listViewNF4_Thread.Abort();
  }

  public void Save_listViewNF4_Data_Task()
  {
    if (this.InvokeRequired)
    {
      this.Invoke((Delegate) new Form1.Save_listViewNF4_Agency(this.Save_listViewNF4_Data_Task), new object[0]);
    }
    else
    {
      if (this.progressBarEx1.Value <= this.progressBarEx1.Maximum)
      {
        this.progressBarEx1.Value = Form1.Save_ProgressBar_i;
        this.progressBarEx1.Text = (Form1.Save_ProgressBar_i * 100 / this.progressBarEx1.Maximum).ToString() + "%";
      }
      if (Form1.Save_Finish_flag)
      {
        Form1.Save_Finish_flag = false;
        Form1.Exit_Save_listViewNF4_flag = true;
        this.imageButton2.Enabled = true;
        this.imageButton4.Enabled = true;
        this.qqRadioButton3.Enabled = true;
        this.qqRadioButton4.Enabled = true;
        this.qqRadioButton5.Enabled = true;
        this.qqRadioButton6.Enabled = true;
        this.qqTextBox10.Enabled = true;
        this.qqTextBox17.Enabled = true;
        this.imageButton5.Enabled = true;
        this.imageButton6.Enabled = false;
        this.imageButton7.Enabled = true;
        this.imageButton8.Enabled = false;
        this.dS按钮1.Enabled = true;
        this.dS按钮2.Enabled = false;
        this.imageButton10.Enabled = true;
        this.dS按钮1.贴图 = Resources.运行8;
        this.dS按钮2.贴图 = Resources.停止8;
        ((Control) this.dataGridViewX2).Enabled = true;
        this.dS按钮3.Enabled = true;
        this.dS按钮4.Enabled = false;
        this.imageButton12.Enabled = true;
        this.dS按钮3.贴图 = Resources.运行8;
        this.dS按钮4.贴图 = Resources.停止8;
        this.qqCheckBox7.Enabled = true;
        this.qqCheckBox8.Enabled = true;
        this.qqCheckBox9.Enabled = true;
        this.qqCheckBox10.Enabled = true;
        this.qqCheckBox11.Enabled = true;
        this.qqCheckBox12.Enabled = true;
        this.qqCheckBox13.Enabled = true;
        this.qqCheckBox14.Enabled = true;
        this.qqCheckBox15.Enabled = true;
        this.qqCheckBox16.Enabled = true;
        this.qqCheckBox17.Enabled = true;
        this.qqCheckBox18.Enabled = true;
        this.qqTextBox18.Enabled = true;
        this.qqTextBox19.Enabled = true;
        this.qqTextBox20.Enabled = true;
        this.qqTextBox21.Enabled = true;
        this.qqTextBox22.Enabled = true;
        this.qqTextBox23.Enabled = true;
        this.qqTextBox24.Enabled = true;
        this.qqTextBox25.Enabled = true;
        this.qqTextBox26.Enabled = true;
        this.qqTextBox27.Enabled = true;
        this.qqTextBox28.Enabled = true;
        this.qqTextBox29.Enabled = true;
        this.qqRadioButton13.Enabled = true;
        this.qqRadioButton14.Enabled = true;
        this.imageButton13.Enabled = true;
        this.imageButton14.Enabled = true;
        this.qqRadioButton11.Enabled = true;
        this.qqRadioButton12.Enabled = true;
        this.dS按钮5.Enabled = true;
        this.dS按钮6.贴图 = Resources.停止8;
        this.dS按钮6.Enabled = false;
        this.dS按钮5.贴图 = Resources.运行8;
        this.myButton5.Enabled = true;
        this.myButton5.NormalImage = (Image) Resources.btn_green_normal;
        Form1.BOOT_ON_flag = false;
        this.dS按钮9.Enabled = true;
        this.dS按钮10.贴图 = Resources.按钮3;
        this.dS按钮11.贴图 = Resources.灯6;
        this.dS按钮10.Enabled = true;
        this.dS按钮11.Enabled = true;
        this.imageButton15.Enabled = true;
        this.imageButton16.Enabled = true;
        this.imageButton17.Enabled = true;
        this.dS按钮13.Enabled = false;
        this.dS按钮13.贴图 = Resources.运行9;
        this.myButton1.Enabled = true;
        this.dS按钮15.Enabled = true;
        this.dS按钮15.贴图 = Resources.运行8;
        this.dS按钮14.Enabled = false;
        this.dS按钮14.贴图 = Resources.停止9;
        this.myButton3.Enabled = true;
        this.myButton2.Enabled = true;
        this.dS按钮17.Enabled = true;
        this.dS按钮16.Enabled = true;
        this.dS按钮17.贴图 = Resources.运行8;
        this.dS按钮16.贴图 = Resources.停止9;
      }
    }
  }

  private async void Slave_Send_Task() => await this.Slave_Send_Data_Task();

  private async Task Slave_Send_Data_Task()
  {
    int task_Send_i = 0;
    byte[] Send_Data = new byte[16 /*0x10*/];
    await Task.Run((Action) (() =>
    {
      Buffer.BlockCopy((Array) Form1.Slave_Send_Data, task_Send_i * 16 /*0x10*/, (Array) Send_Data, 0, 16 /*0x10*/);
      this.serialPort1.Write(Send_Data, 0, 16 /*0x10*/);
      Thread.Sleep(300);
      ++task_Send_i;
      Buffer.BlockCopy((Array) Form1.Slave_Send_Data, task_Send_i * 16 /*0x10*/, (Array) Send_Data, 0, 16 /*0x10*/);
      this.serialPort1.Write(Send_Data, 0, 16 /*0x10*/);
      Thread.Sleep(50);
      for (++task_Send_i; task_Send_i < Form1.Slave_Send_i; ++task_Send_i)
      {
        Buffer.BlockCopy((Array) Form1.Slave_Send_Data, task_Send_i * 16 /*0x10*/, (Array) Send_Data, 0, 16 /*0x10*/);
        this.serialPort1.Write(Send_Data, 0, 16 /*0x10*/);
        Thread.Sleep(30);
      }
      Form1.Rur_Mode = 3;
      this.RTOS_Save_mode3_Asynchronous();
    }));
  }

  public static void Slave_Async_Task()
  {
    if (Form1.Receive_Frame_Data[0] != (byte) 85)
      return;
    Buffer.BlockCopy((Array) Form1.Receive_Frame_Data, 0, (Array) Form1.Slave_Mode_Data, Form1.Slave_count * 16 /*0x10*/, 16 /*0x10*/);
    Form1.Slave_time[Form1.Slave_count, 0] = Form1.System_Time_R.ToString("yyyy-MM-dd HH:mm:ss:fff");
    ++Form1.Slave_count;
    if (Form1.Slave_count >= (int) ushort.MaxValue)
      Form1.Slave_count = 0;
  }

  public void Slave_Sync_Task()
  {
    int num = 0;
    if (!Form1.Slave_Display_Mode)
    {
      if (Form1.Slave_Display_count == Form1.Slave_count)
        return;
      Form1.SM_ID = "";
      Form1.SM_Dir = "";
      Form1.SM_Ch = "";
      Form1.SM_Str = "";
      Form1.SM_State = "";
      Form1.SM_Check = "";
      Form1.SM_Length = 0;
      Form1.SM_Ch = Form1.Slave_Mode_Data[Form1.Slave_Display_count, 1].ToString();
      Form1.SM_ID = Form1.DECstr_to_HEXstr(Form1.Slave_Mode_Data[Form1.Slave_Display_count, 2].ToString());
      Form1.SM_ID = $"{Form1.SM_ID}[{Form1.LIN_PID_Parity(Form1.SM_ID)}]";
      Form1.SM_Dir = Form1.Slave_Mode_Data[Form1.Slave_Display_count, 3] != (byte) 0 ? "接收" : "发送";
      Form1.SM_State = Form1.Slave_Mode_Data[Form1.Slave_Display_count, 4] != (byte) 0 ? (Form1.Slave_Mode_Data[Form1.Slave_Display_count, 4] != (byte) 1 ? (Form1.Slave_Mode_Data[Form1.Slave_Display_count, 4] != (byte) 2 ? "帧头" : "V2") : "V1") : "校验和错误";
      Form1.SM_Length = (int) Form1.Slave_Mode_Data[Form1.Slave_Display_count, 5];
      for (int index = 6; index < Form1.SM_Length + 6; ++index)
        Form1.SM_Str = $"{Form1.SM_Str}{Form1.DECstr_to_HEXstr(Form1.Slave_Mode_Data[Form1.Slave_Display_count, index].ToString())} ";
      Form1.SM_Check = Form1.DECstr_to_HEXstr(Form1.Slave_Mode_Data[Form1.Slave_Display_count, 14].ToString());
      Form1.S_Static_Save[Form1.Slave_Display_count, 0] = Form1.Slave_Display_count.ToString();
      Form1.S_Static_Save[Form1.Slave_Display_count, 1] = Form1.SM_Ch;
      Form1.S_Static_Save[Form1.Slave_Display_count, 2] = Form1.SM_Dir;
      Form1.S_Static_Save[Form1.Slave_Display_count, 3] = Form1.Slave_time[Form1.Slave_Display_count, 0];
      Form1.S_Static_Save[Form1.Slave_Display_count, 4] = Form1.SM_ID;
      Form1.S_Static_Save[Form1.Slave_Display_count, 5] = Form1.SM_Length.ToString();
      Form1.S_Static_Save[Form1.Slave_Display_count, 6] = Form1.SM_Str;
      Form1.S_Static_Save[Form1.Slave_Display_count, 7] = Form1.SM_Check;
      Form1.S_Static_Save[Form1.Slave_Display_count, 8] = Form1.SM_State;
      this.listViewNF3.Items.Add(Form1.Slave_Display_count.ToString());
      this.listViewNF3.Items[Form1.Slave_Display_count].SubItems.Add(Form1.SM_Ch);
      this.listViewNF3.Items[Form1.Slave_Display_count].SubItems.Add(Form1.SM_Dir);
      this.listViewNF3.Items[Form1.Slave_Display_count].SubItems.Add(Form1.Slave_time[Form1.Slave_Display_count, 0]);
      this.listViewNF3.Items[Form1.Slave_Display_count].SubItems.Add(Form1.SM_ID);
      this.listViewNF3.Items[Form1.Slave_Display_count].SubItems.Add(Form1.SM_Length.ToString());
      this.listViewNF3.Items[Form1.Slave_Display_count].SubItems.Add(Form1.SM_Str);
      this.listViewNF3.Items[Form1.Slave_Display_count].SubItems.Add(Form1.SM_Check);
      this.listViewNF3.Items[Form1.Slave_Display_count].SubItems.Add(Form1.SM_State);
      this.listViewNF3.Items[Form1.Slave_Display_count].Selected = true;
      this.listViewNF3.Items[Form1.Slave_Display_count].EnsureVisible();
      ++Form1.Slave_Display_count;
      if (Form1.Slave_Display_count >= (int) ushort.MaxValue)
      {
        lock (Form1.locker)
        {
          this.listViewNF3.Items.Clear();
          Form1.Slave_Display_count = 0;
          Form1.mode3_Save_Task_flag = true;
        }
      }
    }
    else if (Form1.Slave_Display_count != Form1.Slave_count)
    {
      if (Form1.Slave_Static[(int) Form1.Slave_Mode_Data[Form1.Slave_Display_count, 2], 0] == byte.MaxValue)
      {
        Form1.SM_ID = "";
        Form1.SM_Dir = "";
        Form1.SM_Ch = "";
        Form1.SM_Str = "";
        Form1.SM_State = "";
        Form1.SM_Check = "";
        Form1.SM_Length = 0;
        Form1.SM_Ch = Form1.Slave_Mode_Data[Form1.Slave_Display_count, 1].ToString();
        Form1.SM_ID = Form1.DECstr_to_HEXstr(Form1.Slave_Mode_Data[Form1.Slave_Display_count, 2].ToString());
        Form1.SM_ID = $"{Form1.SM_ID}[{Form1.LIN_PID_Parity(Form1.SM_ID)}]";
        Form1.SM_Dir = Form1.Slave_Mode_Data[Form1.Slave_Display_count, 3] != (byte) 0 ? "接收" : "发送";
        Form1.SM_State = Form1.Slave_Mode_Data[Form1.Slave_Display_count, 4] != (byte) 0 ? (Form1.Slave_Mode_Data[Form1.Slave_Display_count, 4] != (byte) 1 ? (Form1.Slave_Mode_Data[Form1.Slave_Display_count, 4] != (byte) 2 ? "帧头" : "V2") : "V1") : "校验和错误";
        Form1.SM_Length = (int) Form1.Slave_Mode_Data[Form1.Slave_Display_count, 5];
        for (int index = 6; index < Form1.SM_Length + 6; ++index)
          Form1.SM_Str = $"{Form1.SM_Str}{Form1.DECstr_to_HEXstr(Form1.Slave_Mode_Data[Form1.Slave_Display_count, index].ToString())} ";
        Form1.SM_Check = Form1.DECstr_to_HEXstr(Form1.Slave_Mode_Data[Form1.Slave_Display_count, 14].ToString());
        num = 0;
        int count = this.listViewNF3.Items.Count;
        Form1.S_Static_Save[Form1.Slave_Display_count, 0] = Form1.Slave_Display_count.ToString();
        Form1.S_Static_Save[Form1.Slave_Display_count, 1] = Form1.SM_Ch;
        Form1.S_Static_Save[Form1.Slave_Display_count, 2] = Form1.SM_Dir;
        Form1.S_Static_Save[Form1.Slave_Display_count, 3] = Form1.Slave_time[Form1.Slave_Display_count, 0];
        Form1.S_Static_Save[Form1.Slave_Display_count, 4] = Form1.SM_ID;
        Form1.S_Static_Save[Form1.Slave_Display_count, 5] = Form1.SM_Length.ToString();
        Form1.S_Static_Save[Form1.Slave_Display_count, 6] = Form1.SM_Str;
        Form1.S_Static_Save[Form1.Slave_Display_count, 7] = Form1.SM_Check;
        Form1.S_Static_Save[Form1.Slave_Display_count, 8] = Form1.SM_State;
        this.listViewNF3.Items.Add(count.ToString());
        this.listViewNF3.Items[count].SubItems.Add(Form1.SM_Ch);
        this.listViewNF3.Items[count].SubItems.Add(Form1.SM_Dir);
        this.listViewNF3.Items[count].SubItems.Add(Form1.Slave_time[Form1.Slave_Display_count, 0]);
        this.listViewNF3.Items[count].SubItems.Add(Form1.SM_ID);
        this.listViewNF3.Items[count].SubItems.Add(Form1.SM_Length.ToString());
        this.listViewNF3.Items[count].SubItems.Add(Form1.SM_Str);
        this.listViewNF3.Items[count].SubItems.Add(Form1.SM_Check);
        this.listViewNF3.Items[count].SubItems.Add(Form1.SM_State);
        this.listViewNF3.Items[count].Selected = true;
        this.listViewNF3.Items[count].EnsureVisible();
        Form1.Slave_Static[(int) Form1.Slave_Mode_Data[Form1.Slave_Display_count, 2], 0] = (byte) count;
      }
      else
      {
        int index1 = (int) Form1.Slave_Static[(int) Form1.Slave_Mode_Data[Form1.Slave_Display_count, 2], 0];
        Form1.SM_Dir = "";
        Form1.SM_Ch = "";
        Form1.SM_ID = "";
        Form1.SM_Str = "";
        Form1.SM_State = "";
        Form1.SM_Check = "";
        Form1.SM_Length = 0;
        Form1.SM_Ch = Form1.Slave_Mode_Data[Form1.Slave_Display_count, 1].ToString();
        Form1.SM_ID = Form1.DECstr_to_HEXstr(Form1.Slave_Mode_Data[Form1.Slave_Display_count, 2].ToString());
        Form1.SM_ID = $"{Form1.SM_ID}[{Form1.LIN_PID_Parity(Form1.SM_ID)}]";
        Form1.SM_Dir = Form1.Slave_Mode_Data[Form1.Slave_Display_count, 3] != (byte) 0 ? "接收" : "发送";
        Form1.SM_State = Form1.Slave_Mode_Data[Form1.Slave_Display_count, 4] != (byte) 0 ? (Form1.Slave_Mode_Data[Form1.Slave_Display_count, 4] != (byte) 1 ? (Form1.Slave_Mode_Data[Form1.Slave_Display_count, 4] != (byte) 2 ? "帧头" : "V2") : "V1") : "校验和错误";
        Form1.SM_Length = (int) Form1.Slave_Mode_Data[Form1.Slave_Display_count, 5];
        for (int index2 = 6; index2 < Form1.SM_Length + 6; ++index2)
          Form1.SM_Str = $"{Form1.SM_Str}{Form1.DECstr_to_HEXstr(Form1.Slave_Mode_Data[Form1.Slave_Display_count, index2].ToString())} ";
        Form1.SM_Check = Form1.DECstr_to_HEXstr(Form1.Slave_Mode_Data[Form1.Slave_Display_count, 14].ToString());
        Form1.S_Static_Save[Form1.Slave_Display_count, 0] = Form1.Slave_Display_count.ToString();
        Form1.S_Static_Save[Form1.Slave_Display_count, 1] = Form1.SM_Ch;
        Form1.S_Static_Save[Form1.Slave_Display_count, 2] = Form1.SM_Dir;
        Form1.S_Static_Save[Form1.Slave_Display_count, 3] = Form1.Slave_time[Form1.Slave_Display_count, 0];
        Form1.S_Static_Save[Form1.Slave_Display_count, 4] = Form1.SM_ID;
        Form1.S_Static_Save[Form1.Slave_Display_count, 5] = Form1.SM_Length.ToString();
        Form1.S_Static_Save[Form1.Slave_Display_count, 6] = Form1.SM_Str;
        Form1.S_Static_Save[Form1.Slave_Display_count, 7] = Form1.SM_Check;
        Form1.S_Static_Save[Form1.Slave_Display_count, 8] = Form1.SM_State;
        this.listViewNF3.Items[index1].SubItems[3].Text = Form1.Slave_time[Form1.Slave_Display_count, 0];
        this.listViewNF3.Items[index1].SubItems[4].Text = Form1.SM_ID;
        this.listViewNF3.Items[index1].SubItems[5].Text = Form1.SM_Length.ToString();
        this.listViewNF3.Items[index1].SubItems[6].Text = Form1.SM_Str;
        this.listViewNF3.Items[index1].SubItems[7].Text = Form1.SM_Check;
        this.listViewNF3.Items[index1].SubItems[8].Text = Form1.SM_State;
      }
      ++Form1.Slave_Display_count;
      if (Form1.Slave_Display_count >= (int) ushort.MaxValue)
      {
        lock (Form1.locker)
        {
          Form1.Slave_Display_count = 0;
          Form1.mode3_Save_Task_flag = true;
        }
      }
    }
  }

  private async void Save_listViewNF3_Asynchronous()
  {
    await Form1.Save_listViewNF3_Asynchronous_Task();
  }

  private static async Task Save_listViewNF3_Asynchronous_Task()
  {
    int Save_Task_i = 0;
    int Save_i = 0;
    string Save_Task_str = "";
    string Save_ID = "";
    string Save_Ch = "";
    string Save_Dri = "";
    string Save_State = "";
    string Save_str = "";
    string Save_Check = "";
    int Save_Length = 0;
    await Task.Run((Action) (() =>
    {
      if (Form1.Slave_Display_Mode)
      {
        FileInfo fileInfo = new FileInfo(Form1.Save_FileName_str);
        FileStream fileStream = new FileStream(Form1.Save_FileName_str, FileMode.Create, FileAccess.Write);
        StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.UTF8);
        Save_Task_str = "";
        Save_Task_str = "序号,通道,方向,时间,ID,长度,数据,校验和,状态";
        streamWriter.WriteLine(Save_Task_str);
        do
        {
          Save_Task_str = "";
          Save_Task_str = $"{Form1.S_Static_Save[Save_Task_i, 0]},{Form1.S_Static_Save[Save_Task_i, 1]},{Form1.S_Static_Save[Save_Task_i, 2]},{Form1.S_Static_Save[Save_Task_i, 3]},{Form1.S_Static_Save[Save_Task_i, 4]},{Form1.S_Static_Save[Save_Task_i, 5]},{Form1.S_Static_Save[Save_Task_i, 6]},{Form1.S_Static_Save[Save_Task_i, 7]},{Form1.S_Static_Save[Save_Task_i, 8]}";
          streamWriter.WriteLine(Save_Task_str);
          ++Save_Task_i;
          Form1.Save_ProgressBar_i = Save_Task_i;
          Thread.Sleep(1);
        }
        while (Save_Task_i < Form1.S_Static_i);
        streamWriter.Close();
        fileStream.Close();
        Form1.Save_Finish_flag = true;
      }
      else
      {
        FileInfo fileInfo = new FileInfo(Form1.Save_FileName_str);
        FileStream fileStream = new FileStream(Form1.Save_FileName_str, FileMode.Create, FileAccess.Write);
        StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.UTF8);
        Save_Task_str = "";
        Save_Task_str = "序号,通道,方向,时间,ID,长度,数据,校验和,状态";
        streamWriter.WriteLine(Save_Task_str);
        do
        {
          Save_Ch = "";
          Save_Ch = Form1.Slave_Mode_Data[Save_Task_i, 1].ToString();
          Save_ID = "";
          Save_ID = Form1.DECstr_to_HEXstr(Form1.Slave_Mode_Data[Save_Task_i, 2].ToString());
          Save_ID = $"{Save_ID}[{Form1.LIN_PID_Parity(Save_ID)}]";
          Save_Dri = "";
          Save_Dri = Form1.Slave_Mode_Data[Save_Task_i, 3] != (byte) 0 ? "接收" : "发送";
          Save_State = "";
          Save_State = Form1.Slave_Mode_Data[Save_Task_i, 4] != (byte) 0 ? (Form1.Slave_Mode_Data[Save_Task_i, 4] != (byte) 1 ? (Form1.Slave_Mode_Data[Save_Task_i, 4] != (byte) 2 ? "帧头" : "V2") : "V1") : "校验和错误";
          Save_Length = 0;
          Save_Length = (int) Form1.Slave_Mode_Data[Save_Task_i, 5];
          Save_str = "";
          for (Save_i = 6; Save_i < Save_Length + 6; ++Save_i)
            Save_str = $"{Save_str}{Form1.DECstr_to_HEXstr(Form1.Slave_Mode_Data[Save_Task_i, Save_i].ToString())} ";
          Save_Check = "";
          Save_Check = Form1.DECstr_to_HEXstr(Form1.Slave_Mode_Data[Save_Task_i, 14].ToString());
          Save_Task_str = "";
          Save_Task_str = $"{Save_Task_i.ToString()},{Save_Ch},{Save_Dri},{Form1.Slave_time[Save_Task_i, 0]},{Save_ID},{Save_Length.ToString()},{Save_str},{Save_Check},{Save_State}";
          streamWriter.WriteLine(Save_Task_str);
          ++Save_Task_i;
          Form1.Save_ProgressBar_i = Save_Task_i;
          Thread.Sleep(1);
        }
        while (Save_Task_i < Form1.Slave_count);
        streamWriter.Close();
        fileStream.Close();
        Form1.Save_Finish_flag = true;
      }
    }));
  }

  public void Save_listViewNF3_Data()
  {
    do
    {
      this.Save_listViewNF3_Data_Task();
      Thread.Sleep(100);
    }
    while (!Form1.Exit_Save_listViewNF3_flag);
    Form1.Exit_Save_listViewNF3_flag = false;
    this.Save_listViewNF3_Thread.Abort();
  }

  public void Save_listViewNF3_Data_Task()
  {
    if (this.InvokeRequired)
    {
      this.Invoke((Delegate) new Form1.Save_listViewNF3_Agency(this.Save_listViewNF3_Data_Task), new object[0]);
    }
    else
    {
      if (this.progressBarEx1.Value <= this.progressBarEx1.Maximum)
      {
        this.progressBarEx1.Value = Form1.Save_ProgressBar_i;
        this.progressBarEx1.Text = (Form1.Save_ProgressBar_i * 100 / this.progressBarEx1.Maximum).ToString() + "%";
      }
      if (Form1.Save_Finish_flag)
      {
        Form1.Save_Finish_flag = false;
        Form1.Exit_Save_listViewNF3_flag = true;
        this.imageButton2.Enabled = true;
        this.imageButton4.Enabled = true;
        this.qqRadioButton3.Enabled = true;
        this.qqRadioButton4.Enabled = true;
        this.qqRadioButton5.Enabled = true;
        this.qqRadioButton6.Enabled = true;
        this.qqTextBox10.Enabled = true;
        this.qqTextBox17.Enabled = true;
        this.imageButton5.Enabled = true;
        this.imageButton6.Enabled = false;
        this.imageButton7.Enabled = true;
        this.imageButton8.Enabled = false;
        this.dS按钮1.Enabled = true;
        this.dS按钮2.Enabled = false;
        this.imageButton10.Enabled = true;
        this.dS按钮1.贴图 = Resources.运行8;
        this.dS按钮2.贴图 = Resources.停止8;
        ((Control) this.dataGridViewX2).Enabled = true;
        this.dS按钮3.Enabled = true;
        this.dS按钮4.Enabled = false;
        this.imageButton11.Enabled = true;
        this.imageButton12.Enabled = true;
        this.dS按钮3.贴图 = Resources.运行8;
        this.dS按钮4.贴图 = Resources.停止8;
        this.qqCheckBox7.Enabled = true;
        this.qqCheckBox8.Enabled = true;
        this.qqCheckBox9.Enabled = true;
        this.qqCheckBox10.Enabled = true;
        this.qqCheckBox11.Enabled = true;
        this.qqCheckBox12.Enabled = true;
        this.qqCheckBox13.Enabled = true;
        this.qqCheckBox14.Enabled = true;
        this.qqCheckBox15.Enabled = true;
        this.qqCheckBox16.Enabled = true;
        this.qqCheckBox17.Enabled = true;
        this.qqCheckBox18.Enabled = true;
        this.qqTextBox18.Enabled = true;
        this.qqTextBox19.Enabled = true;
        this.qqTextBox20.Enabled = true;
        this.qqTextBox21.Enabled = true;
        this.qqTextBox22.Enabled = true;
        this.qqTextBox23.Enabled = true;
        this.qqTextBox24.Enabled = true;
        this.qqTextBox25.Enabled = true;
        this.qqTextBox26.Enabled = true;
        this.qqTextBox27.Enabled = true;
        this.qqTextBox28.Enabled = true;
        this.qqTextBox29.Enabled = true;
        this.qqRadioButton13.Enabled = true;
        this.qqRadioButton14.Enabled = true;
        this.imageButton13.Enabled = true;
        this.imageButton14.Enabled = true;
        this.qqRadioButton11.Enabled = true;
        this.qqRadioButton12.Enabled = true;
        this.dS按钮5.Enabled = true;
        this.dS按钮6.贴图 = Resources.停止8;
        this.dS按钮6.Enabled = false;
        this.dS按钮5.贴图 = Resources.运行8;
        this.myButton5.Enabled = true;
        this.myButton5.NormalImage = (Image) Resources.btn_green_normal;
        Form1.BOOT_ON_flag = false;
        this.dS按钮9.Enabled = true;
        this.dS按钮10.贴图 = Resources.按钮3;
        this.dS按钮11.贴图 = Resources.灯6;
        this.dS按钮10.Enabled = true;
        this.dS按钮11.Enabled = true;
        this.imageButton15.Enabled = true;
        this.imageButton16.Enabled = true;
        this.imageButton17.Enabled = true;
        this.dS按钮13.Enabled = false;
        this.dS按钮13.贴图 = Resources.运行9;
      }
    }
  }

  private async void RTOS_Save_mode3_Asynchronous()
  {
    await Form1.RTOS_Save_mode3_Asynchronous_Task();
  }

  private static async Task RTOS_Save_mode3_Asynchronous_Task()
  {
    string Save_Task_str = "";
    await Task.Run((Action) (() =>
    {
      Form1.mode3_Save_Task_i = 0;
      string str1 = Path.Combine(Application.StartupPath, "Data\\");
      Form1.RTOS_Time = DateTime.Now;
      Form1.RTOS_Save_FileName_str = $"{str1}从机模式 Data for {Form1.RTOS_Time.ToString("yyyy-MM-dd HH-mm-ss-fff")}.csv";
      FileInfo fileInfo = new FileInfo(Form1.RTOS_Save_FileName_str);
      FileStream fileStream = new FileStream(Form1.RTOS_Save_FileName_str, FileMode.Create, FileAccess.Write);
      StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.UTF8);
      Save_Task_str = "";
      Save_Task_str = "序号,通道,方向,时间,ID,长度,数据,校验和,状态";
      streamWriter.WriteLine(Save_Task_str);
      while (true)
      {
        if (Form1.mode3_Save_Task_i != Form1.Slave_Display_count && Form1.mode3_Save_Task_i < (int) ushort.MaxValue)
        {
          Save_Task_str = "";
          Save_Task_str = $"{Form1.S_Static_Save[Form1.mode3_Save_Task_i, 0]},{Form1.S_Static_Save[Form1.mode3_Save_Task_i, 1]},{Form1.S_Static_Save[Form1.mode3_Save_Task_i, 2]},{Form1.S_Static_Save[Form1.mode3_Save_Task_i, 3]},{Form1.S_Static_Save[Form1.mode3_Save_Task_i, 4]},{Form1.S_Static_Save[Form1.mode3_Save_Task_i, 5]},{Form1.S_Static_Save[Form1.mode3_Save_Task_i, 6]},{Form1.S_Static_Save[Form1.mode3_Save_Task_i, 7]},{Form1.S_Static_Save[Form1.mode3_Save_Task_i, 8]}";
          streamWriter.WriteLine(Save_Task_str);
          ++Form1.mode3_Save_Task_i;
        }
        Thread.Sleep(1);
        if (Form1.mode3_Save_Task_i >= (int) ushort.MaxValue && Form1.mode3_Save_Task_flag)
        {
          Form1.mode3_Save_Task_flag = false;
          Form1.mode3_Save_Task_i = 0;
          streamWriter.Close();
          fileStream.Close();
          if (!Form1.Exit_RTOS_Save_mode3_flag || Form1.mode3_Save_Task_i != Form1.Slave_Display_count || Form1.Slave_Display_count != Form1.Slave_count)
          {
            string str2 = Path.Combine(Application.StartupPath, "Data\\");
            Form1.RTOS_Time = DateTime.Now;
            Form1.RTOS_Save_FileName_str = $"{str2}从机模式 Data for {Form1.RTOS_Time.ToString("yyyy-MM-dd HH-mm-ss-fff")}.csv";
            fileInfo = new FileInfo(Form1.RTOS_Save_FileName_str);
            fileStream = new FileStream(Form1.RTOS_Save_FileName_str, FileMode.Create, FileAccess.Write);
            streamWriter = new StreamWriter((Stream) fileStream, Encoding.UTF8);
            Save_Task_str = "";
            Save_Task_str = "序号,通道,方向,时间,ID,长度,数据,校验和,状态";
            streamWriter.WriteLine(Save_Task_str);
          }
          else
            break;
        }
        else if (Form1.Slave_Display_count != Form1.Slave_count || Form1.mode3_Save_Task_i != Form1.Slave_Display_count || !Form1.Exit_RTOS_Save_mode3_flag)
        {
          if (!Form1.Device_switch_flag)
            goto label_9;
        }
        else
          goto label_7;
      }
      Form1.Exit_RTOS_Save_mode3_flag = false;
      return;
label_7:
      Form1.Exit_RTOS_Save_mode3_flag = false;
      Form1.mode3_Save_Task_i = 0;
      streamWriter.Close();
      fileStream.Close();
      return;
label_9:
      Form1.mode3_Save_Task_i = 0;
      streamWriter.Close();
      fileStream.Close();
    }));
  }

  private async void Timing_Send_TX() => await this.Timing_Send_TX_Task();

  private async Task Timing_Send_TX_Task()
  {
    int task_Send_i = 0;
    await Task.Run((Action) (() =>
    {
      try
      {
        do
        {
          Buffer.BlockCopy((Array) Form1.Single_Send_Data, task_Send_i * 16 /*0x10*/, (Array) Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          Form1.System_Time_T = DateTime.Now;
          Buffer.BlockCopy((Array) Form1.Send_Frame_Data, 0, (Array) Form1.Single_Mode_Data, Form1.Single_count * 16 /*0x10*/, 16 /*0x10*/);
          Form1.Single_time[Form1.Single_count, 0] = Form1.System_Time_T.ToString("yyyy-MM-dd HH:mm:ss:fff");
          ++Form1.Single_count;
          if (Form1.Single_count >= (int) ushort.MaxValue)
            Form1.Single_count = 0;
          ++task_Send_i;
          if (task_Send_i >= Form1.Single_Send_i)
            task_Send_i = 0;
          Thread.Sleep(Form1.Single_time_value);
        }
        while (Form1.Timing_Send_flag);
      }
      catch
      {
        Form1.System_UART_RX_Rrror_flag = true;
      }
    }));
  }

  public static void Single_Async_Task()
  {
    if (Form1.Receive_Frame_Data[0] != (byte) 51)
      return;
    Buffer.BlockCopy((Array) Form1.Receive_Frame_Data, 0, (Array) Form1.Single_Mode_Data, Form1.Single_count * 16 /*0x10*/, 16 /*0x10*/);
    Form1.Single_time[Form1.Single_count, 0] = Form1.System_Time_R.ToString("yyyy-MM-dd HH:mm:ss:fff");
    ++Form1.Single_count;
    if (Form1.Single_count >= (int) ushort.MaxValue)
      Form1.Single_count = 0;
  }

  public void Single_Sync_Task()
  {
    if (Form1.Single_Display_count == Form1.Single_count)
      return;
    Form1.SI_ID = "";
    Form1.SI_Dir = "";
    Form1.SI_Ch = "";
    Form1.SI_Str = "";
    Form1.SI_State = "";
    Form1.SI_Check = "";
    Form1.SI_Length = 0;
    Form1.SI_Ch = Form1.Single_Mode_Data[Form1.Single_Display_count, 1].ToString();
    Form1.SI_ID = Form1.DECstr_to_HEXstr(Form1.Single_Mode_Data[Form1.Single_Display_count, 2].ToString());
    Form1.SI_ID = $"{Form1.SI_ID}[{Form1.LIN_PID_Parity(Form1.SI_ID)}]";
    Form1.SI_Dir = Form1.Single_Mode_Data[Form1.Single_Display_count, 3] != (byte) 0 ? "接收" : "发送";
    Form1.SI_State = Form1.Single_Mode_Data[Form1.Single_Display_count, 4] != (byte) 0 ? (Form1.Single_Mode_Data[Form1.Single_Display_count, 4] != (byte) 1 ? (Form1.Single_Mode_Data[Form1.Single_Display_count, 4] != (byte) 2 ? "帧头" : "V2") : "V1") : "校验和错误";
    Form1.SI_Length = (int) Form1.Single_Mode_Data[Form1.Single_Display_count, 5];
    for (int index = 6; index < Form1.SI_Length + 6; ++index)
      Form1.SI_Str = $"{Form1.SI_Str}{Form1.DECstr_to_HEXstr(Form1.Single_Mode_Data[Form1.Single_Display_count, index].ToString())} ";
    Form1.SI_Check = Form1.DECstr_to_HEXstr(Form1.Single_Mode_Data[Form1.Single_Display_count, 14].ToString());
    this.listViewNF1.Items.Add(Form1.Single_Display_count.ToString());
    this.listViewNF1.Items[Form1.Single_Display_count].SubItems.Add(Form1.SI_Ch);
    this.listViewNF1.Items[Form1.Single_Display_count].SubItems.Add(Form1.SI_Dir);
    this.listViewNF1.Items[Form1.Single_Display_count].SubItems.Add(Form1.Single_time[Form1.Single_Display_count, 0]);
    this.listViewNF1.Items[Form1.Single_Display_count].SubItems.Add(Form1.SI_ID);
    this.listViewNF1.Items[Form1.Single_Display_count].SubItems.Add(Form1.SI_Length.ToString());
    this.listViewNF1.Items[Form1.Single_Display_count].SubItems.Add(Form1.SI_Str);
    this.listViewNF1.Items[Form1.Single_Display_count].SubItems.Add(Form1.SI_Check);
    this.listViewNF1.Items[Form1.Single_Display_count].SubItems.Add(Form1.SI_State);
    this.listViewNF1.Items[Form1.Single_Display_count].Selected = true;
    this.listViewNF1.Items[Form1.Single_Display_count].EnsureVisible();
    ++Form1.Single_Display_count;
    if (Form1.Single_Display_count >= (int) ushort.MaxValue)
    {
      lock (Form1.locker)
      {
        this.listViewNF1.Items.Clear();
        Form1.Single_Display_count = 0;
      }
    }
  }

  private async void Timing_Send_RX() => await this.Timing_Send_RX_Task();

  private async Task Timing_Send_RX_Task()
  {
    int task_Send_i = 0;
    await Task.Run((Action) (() =>
    {
      try
      {
        do
        {
          Buffer.BlockCopy((Array) Form1.Single_Send_Data, task_Send_i * 16 /*0x10*/, (Array) Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          ++task_Send_i;
          if (task_Send_i >= Form1.Single_Send_i)
            task_Send_i = 0;
          Thread.Sleep(Form1.Single_time_value);
        }
        while (Form1.Timing_Send_flag);
      }
      catch
      {
        Form1.System_UART_RX_Rrror_flag = true;
      }
    }));
  }

  private async void Save_listViewNF1_Asynchronous()
  {
    await Form1.Save_listViewNF1_Asynchronous_Task();
  }

  private static async Task Save_listViewNF1_Asynchronous_Task()
  {
    int Save_Task_i = 0;
    int Save_i = 0;
    string Save_Task_str = "";
    string Save_ID = "";
    string Save_Ch = "";
    string Save_Dri = "";
    string Save_State = "";
    string Save_str = "";
    string Save_Check = "";
    int Save_Length = 0;
    await Task.Run((Action) (() =>
    {
      FileInfo fileInfo = new FileInfo(Form1.Save_FileName_str);
      FileStream fileStream = new FileStream(Form1.Save_FileName_str, FileMode.Create, FileAccess.Write);
      StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.UTF8);
      Save_Task_str = "";
      Save_Task_str = "序号,通道,方向,时间,ID,长度,数据,校验和,状态";
      streamWriter.WriteLine(Save_Task_str);
      do
      {
        Save_Ch = "";
        Save_Ch = Form1.Single_Mode_Data[Save_Task_i, 1].ToString();
        Save_ID = "";
        Save_ID = Form1.DECstr_to_HEXstr(Form1.Single_Mode_Data[Save_Task_i, 2].ToString());
        Save_ID = $"{Save_ID}[{Form1.LIN_PID_Parity(Save_ID)}]";
        Save_Dri = "";
        Save_Dri = Form1.Single_Mode_Data[Save_Task_i, 3] != (byte) 0 ? "接收" : "发送";
        Save_State = "";
        Save_State = Form1.Single_Mode_Data[Save_Task_i, 4] != (byte) 0 ? (Form1.Single_Mode_Data[Save_Task_i, 4] != (byte) 1 ? (Form1.Single_Mode_Data[Save_Task_i, 4] != (byte) 2 ? "帧头" : "V2") : "V1") : "校验和错误";
        Save_Length = 0;
        Save_Length = (int) Form1.Single_Mode_Data[Save_Task_i, 5];
        Save_str = "";
        for (Save_i = 6; Save_i < Save_Length + 6; ++Save_i)
          Save_str = $"{Save_str}{Form1.DECstr_to_HEXstr(Form1.Single_Mode_Data[Save_Task_i, Save_i].ToString())} ";
        Save_Check = "";
        Save_Check = Form1.DECstr_to_HEXstr(Form1.Single_Mode_Data[Save_Task_i, 14].ToString());
        Save_Task_str = "";
        Save_Task_str = $"{Save_Task_i.ToString()},{Save_Ch},{Save_Dri},{Form1.Single_time[Save_Task_i, 0]},{Save_ID},{Save_Length.ToString()},{Save_str},{Save_Check},{Save_State}";
        streamWriter.WriteLine(Save_Task_str);
        ++Save_Task_i;
        Form1.Save_ProgressBar_i = Save_Task_i;
        Thread.Sleep(1);
      }
      while (Save_Task_i < Form1.Single_count);
      streamWriter.Close();
      fileStream.Close();
      Form1.Save_Finish_flag = true;
    }));
  }

  public void Save_listViewNF1_Data()
  {
    do
    {
      this.Save_listViewNF1_Data_Task();
      Thread.Sleep(100);
    }
    while (!Form1.Exit_Save_listViewNF1_flag);
    Form1.Exit_Save_listViewNF1_flag = false;
    this.Save_listViewNF1_Thread.Abort();
  }

  public void Save_listViewNF1_Data_Task()
  {
    if (this.InvokeRequired)
    {
      this.Invoke((Delegate) new Form1.Save_listViewNF1_Agency(this.Save_listViewNF1_Data_Task), new object[0]);
    }
    else
    {
      if (this.progressBarEx1.Value <= this.progressBarEx1.Maximum)
      {
        this.progressBarEx1.Value = Form1.Save_ProgressBar_i;
        this.progressBarEx1.Text = (Form1.Save_ProgressBar_i * 100 / this.progressBarEx1.Maximum).ToString() + "%";
      }
      if (Form1.Save_Finish_flag)
      {
        Form1.Save_Finish_flag = false;
        Form1.Exit_Save_listViewNF1_flag = true;
        this.imageButton2.Enabled = true;
        this.qqCheckBox1.Enabled = true;
        this.qqCheckBox2.Enabled = true;
        this.qqCheckBox3.Enabled = true;
        this.qqTextBox1.Enabled = true;
        this.qqTextBox4.Enabled = true;
        this.qqTextBox7.Enabled = true;
        this.qqTextBox3.Enabled = true;
        this.qqTextBox6.Enabled = true;
        this.qqTextBox9.Enabled = true;
        this.qqCheckBox4.Enabled = true;
        this.qqCheckBox5.Enabled = true;
        this.qqCheckBox6.Enabled = true;
        this.qqTextBox11.Enabled = true;
        this.qqTextBox13.Enabled = true;
        this.qqTextBox15.Enabled = true;
        this.qqTextBox12.Enabled = true;
        this.qqTextBox14.Enabled = true;
        this.qqTextBox16.Enabled = true;
        this.imageButton3.Enabled = true;
        this.imageButton4.Enabled = true;
        this.qqRadioButton3.Enabled = true;
        this.qqRadioButton4.Enabled = true;
        this.qqRadioButton5.Enabled = true;
        this.qqRadioButton6.Enabled = true;
        this.qqTextBox10.Enabled = true;
        this.qqTextBox17.Enabled = true;
        this.imageButton5.Enabled = true;
        this.imageButton6.Enabled = false;
        this.imageButton7.Enabled = true;
        this.imageButton8.Enabled = false;
        this.dS按钮1.Enabled = true;
        this.dS按钮2.Enabled = false;
        this.imageButton10.Enabled = true;
        this.dS按钮1.贴图 = Resources.运行8;
        this.dS按钮2.贴图 = Resources.停止8;
        ((Control) this.dataGridViewX2).Enabled = true;
        this.dS按钮3.Enabled = true;
        this.dS按钮4.Enabled = false;
        this.imageButton11.Enabled = true;
        this.imageButton12.Enabled = true;
        this.dS按钮3.贴图 = Resources.运行8;
        this.dS按钮4.贴图 = Resources.停止8;
        this.qqCheckBox7.Enabled = true;
        this.qqCheckBox8.Enabled = true;
        this.qqCheckBox9.Enabled = true;
        this.qqCheckBox10.Enabled = true;
        this.qqCheckBox11.Enabled = true;
        this.qqCheckBox12.Enabled = true;
        this.qqCheckBox13.Enabled = true;
        this.qqCheckBox14.Enabled = true;
        this.qqCheckBox15.Enabled = true;
        this.qqCheckBox16.Enabled = true;
        this.qqCheckBox17.Enabled = true;
        this.qqCheckBox18.Enabled = true;
        this.qqTextBox18.Enabled = true;
        this.qqTextBox19.Enabled = true;
        this.qqTextBox20.Enabled = true;
        this.qqTextBox21.Enabled = true;
        this.qqTextBox22.Enabled = true;
        this.qqTextBox23.Enabled = true;
        this.qqTextBox24.Enabled = true;
        this.qqTextBox25.Enabled = true;
        this.qqTextBox26.Enabled = true;
        this.qqTextBox27.Enabled = true;
        this.qqTextBox28.Enabled = true;
        this.qqTextBox29.Enabled = true;
        this.qqRadioButton13.Enabled = true;
        this.qqRadioButton14.Enabled = true;
        this.imageButton13.Enabled = true;
        this.imageButton14.Enabled = true;
        this.qqRadioButton11.Enabled = true;
        this.qqRadioButton12.Enabled = true;
        this.dS按钮5.Enabled = true;
        this.dS按钮6.贴图 = Resources.停止8;
        this.dS按钮6.Enabled = false;
        this.dS按钮5.贴图 = Resources.运行8;
        this.myButton5.Enabled = true;
        this.myButton5.NormalImage = (Image) Resources.btn_green_normal;
        Form1.BOOT_ON_flag = false;
        this.dS按钮9.Enabled = true;
        this.dS按钮10.贴图 = Resources.按钮3;
        this.dS按钮11.贴图 = Resources.灯6;
        this.dS按钮10.Enabled = true;
        this.dS按钮11.Enabled = true;
        this.imageButton15.Enabled = true;
        this.imageButton16.Enabled = true;
        this.imageButton17.Enabled = true;
        this.dS按钮13.Enabled = false;
        this.dS按钮13.贴图 = Resources.运行9;
        this.myButton1.Enabled = true;
        this.dS按钮15.Enabled = true;
        this.dS按钮15.贴图 = Resources.运行8;
        this.dS按钮14.Enabled = false;
        this.dS按钮14.贴图 = Resources.停止9;
        this.myButton3.Enabled = true;
        this.myButton2.Enabled = true;
        this.dS按钮17.Enabled = true;
        this.dS按钮16.Enabled = false;
        this.dS按钮17.贴图 = Resources.运行8;
        this.dS按钮16.贴图 = Resources.停止9;
      }
    }
  }

  private async void List_Send_Task() => await this.List_Send_Data_Task();

  private async Task List_Send_Data_Task()
  {
    int task_Send_i = 0;
    byte[] Send_Data = new byte[16 /*0x10*/];
    await Task.Run((Action) (() =>
    {
      try
      {
        while (true)
        {
          Buffer.BlockCopy((Array) Form1.List_Send_Data, task_Send_i * 16 /*0x10*/, (Array) Send_Data, 0, 16 /*0x10*/);
          if (Send_Data[0] == (byte) 34)
          {
            lock (Form1.locker)
            {
              this.serialPort1.Write(Send_Data, 0, 16 /*0x10*/);
              Form1.System_Time_T = DateTime.Now;
              Buffer.BlockCopy((Array) Send_Data, 0, (Array) Form1.List_Mode_Data, Form1.List_count * 16 /*0x10*/, 16 /*0x10*/);
              Form1.List_time[Form1.List_count, 0] = Form1.System_Time_T.ToString("yyyy-MM-dd HH:mm:ss:fff");
              ++Form1.List_count;
              if (Form1.List_count >= (int) ushort.MaxValue)
                Form1.List_count = 0;
            }
          }
          else
            this.serialPort1.Write(Send_Data, 0, 16 /*0x10*/);
          Thread.Sleep(Form1.List_time_value[task_Send_i, 0]);
          ++task_Send_i;
          if (task_Send_i >= Form1.List_Send_i)
            task_Send_i = 0;
          if (Form1.List_Send_flag)
          {
            if (Form1.List_send_fixed_flag)
            {
              ++Form1.List_fixed_i;
              if (Form1.List_fixed_i >= Form1.List_send_fixed_number)
                goto label_15;
            }
          }
          else
            break;
        }
        return;
label_15:
        Form1.List_Send_flag = false;
      }
      catch
      {
        Form1.System_UART_RX_Rrror_flag = true;
      }
    }));
  }

  public static void List_Async_Task()
  {
    if (Form1.Receive_Frame_Data[0] != (byte) 51)
      return;
    lock (Form1.locker)
    {
      Buffer.BlockCopy((Array) Form1.Receive_Frame_Data, 0, (Array) Form1.List_Mode_Data, Form1.List_count * 16 /*0x10*/, 16 /*0x10*/);
      Form1.List_time[Form1.List_count, 0] = Form1.System_Time_R.ToString("yyyy-MM-dd HH:mm:ss:fff");
      ++Form1.List_count;
      if (Form1.List_count >= (int) ushort.MaxValue)
        Form1.List_count = 0;
    }
  }

  public void List_Sync_Task()
  {
    int num1 = 0;
    if (!Form1.List_Display_Mode)
    {
      if (Form1.List_Display_count != Form1.List_count)
      {
        Form1.LI_ID = "";
        Form1.LI_Dir = "";
        Form1.LI_Ch = "";
        Form1.LI_Str = "";
        Form1.LI_State = "";
        Form1.LI_Check = "";
        Form1.LI_Length = 0;
        Form1.LI_Ch = Form1.List_Mode_Data[Form1.List_Display_count, 1].ToString();
        Form1.LI_ID = Form1.DECstr_to_HEXstr(Form1.List_Mode_Data[Form1.List_Display_count, 2].ToString());
        Form1.LI_ID = $"{Form1.LI_ID}[{Form1.LIN_PID_Parity(Form1.LI_ID)}]";
        Form1.LI_Dir = Form1.List_Mode_Data[Form1.List_Display_count, 3] != (byte) 0 ? "接收" : "发送";
        Form1.LI_State = Form1.List_Mode_Data[Form1.List_Display_count, 4] != (byte) 0 ? (Form1.List_Mode_Data[Form1.List_Display_count, 4] != (byte) 1 ? (Form1.List_Mode_Data[Form1.List_Display_count, 4] != (byte) 2 ? "帧头" : "V2") : "V1") : "校验和错误";
        Form1.LI_Length = (int) Form1.List_Mode_Data[Form1.List_Display_count, 5];
        for (int index = 6; index < Form1.LI_Length + 6; ++index)
          Form1.LI_Str = $"{Form1.LI_Str}{Form1.DECstr_to_HEXstr(Form1.List_Mode_Data[Form1.List_Display_count, index].ToString())} ";
        Form1.LI_Check = Form1.DECstr_to_HEXstr(Form1.List_Mode_Data[Form1.List_Display_count, 14].ToString());
        Form1.LI_Static_Save[Form1.List_Display_count, 0] = Form1.List_Display_count.ToString();
        Form1.LI_Static_Save[Form1.List_Display_count, 1] = Form1.LI_Ch;
        Form1.LI_Static_Save[Form1.List_Display_count, 2] = Form1.LI_Dir;
        Form1.LI_Static_Save[Form1.List_Display_count, 3] = Form1.List_time[Form1.List_Display_count, 0];
        Form1.LI_Static_Save[Form1.List_Display_count, 4] = Form1.LI_ID;
        Form1.LI_Static_Save[Form1.List_Display_count, 5] = Form1.LI_Length.ToString();
        Form1.LI_Static_Save[Form1.List_Display_count, 6] = Form1.LI_Str;
        Form1.LI_Static_Save[Form1.List_Display_count, 7] = Form1.LI_Check;
        Form1.LI_Static_Save[Form1.List_Display_count, 8] = Form1.LI_State;
        this.listViewNF2.Items.Add(Form1.List_Display_count.ToString());
        this.listViewNF2.Items[Form1.List_Display_count].SubItems.Add(Form1.LI_Ch);
        this.listViewNF2.Items[Form1.List_Display_count].SubItems.Add(Form1.LI_Dir);
        this.listViewNF2.Items[Form1.List_Display_count].SubItems.Add(Form1.List_time[Form1.List_Display_count, 0]);
        this.listViewNF2.Items[Form1.List_Display_count].SubItems.Add(Form1.LI_ID);
        this.listViewNF2.Items[Form1.List_Display_count].SubItems.Add(Form1.LI_Length.ToString());
        this.listViewNF2.Items[Form1.List_Display_count].SubItems.Add(Form1.LI_Str);
        this.listViewNF2.Items[Form1.List_Display_count].SubItems.Add(Form1.LI_Check);
        this.listViewNF2.Items[Form1.List_Display_count].SubItems.Add(Form1.LI_State);
        this.listViewNF2.Items[Form1.List_Display_count].Selected = true;
        this.listViewNF2.Items[Form1.List_Display_count].EnsureVisible();
        ++Form1.List_Display_count;
        if (Form1.List_Display_count >= (int) ushort.MaxValue)
        {
          lock (Form1.locker)
          {
            this.listViewNF2.Items.Clear();
            Form1.List_Display_count = 0;
            Form1.mode2_Save_Task_flag = true;
          }
        }
      }
    }
    else if (Form1.List_Display_count != Form1.List_count)
    {
      if (Form1.List_Static[(int) Form1.List_Mode_Data[Form1.List_Display_count, 2], 0] == byte.MaxValue)
      {
        Form1.LI_ID = "";
        Form1.LI_Dir = "";
        Form1.LI_Ch = "";
        Form1.LI_Str = "";
        Form1.LI_State = "";
        Form1.LI_Check = "";
        Form1.LI_Length = 0;
        Form1.LI_Ch = Form1.List_Mode_Data[Form1.List_Display_count, 1].ToString();
        Form1.LI_ID = Form1.DECstr_to_HEXstr(Form1.List_Mode_Data[Form1.List_Display_count, 2].ToString());
        Form1.LI_ID = $"{Form1.LI_ID}[{Form1.LIN_PID_Parity(Form1.LI_ID)}]";
        Form1.LI_Dir = Form1.List_Mode_Data[Form1.List_Display_count, 3] != (byte) 0 ? "接收" : "发送";
        Form1.LI_State = Form1.List_Mode_Data[Form1.List_Display_count, 4] != (byte) 0 ? (Form1.List_Mode_Data[Form1.List_Display_count, 4] != (byte) 1 ? (Form1.List_Mode_Data[Form1.List_Display_count, 4] != (byte) 2 ? "帧头" : "V2") : "V1") : "校验和错误";
        Form1.LI_Length = (int) Form1.List_Mode_Data[Form1.List_Display_count, 5];
        for (int index = 6; index < Form1.LI_Length + 6; ++index)
          Form1.LI_Str = $"{Form1.LI_Str}{Form1.DECstr_to_HEXstr(Form1.List_Mode_Data[Form1.List_Display_count, index].ToString())} ";
        Form1.LI_Check = Form1.DECstr_to_HEXstr(Form1.List_Mode_Data[Form1.List_Display_count, 14].ToString());
        num1 = 0;
        int count = this.listViewNF2.Items.Count;
        Form1.LI_Static_Save[Form1.List_Display_count, 0] = Form1.List_Display_count.ToString();
        Form1.LI_Static_Save[Form1.List_Display_count, 1] = Form1.LI_Ch;
        Form1.LI_Static_Save[Form1.List_Display_count, 2] = Form1.LI_Dir;
        Form1.LI_Static_Save[Form1.List_Display_count, 3] = Form1.List_time[Form1.List_Display_count, 0];
        Form1.LI_Static_Save[Form1.List_Display_count, 4] = Form1.LI_ID;
        Form1.LI_Static_Save[Form1.List_Display_count, 5] = Form1.LI_Length.ToString();
        Form1.LI_Static_Save[Form1.List_Display_count, 6] = Form1.LI_Str;
        Form1.LI_Static_Save[Form1.List_Display_count, 7] = Form1.LI_Check;
        Form1.LI_Static_Save[Form1.List_Display_count, 8] = Form1.LI_State;
        this.listViewNF2.Items.Add(count.ToString());
        this.listViewNF2.Items[count].SubItems.Add(Form1.LI_Ch);
        this.listViewNF2.Items[count].SubItems.Add(Form1.LI_Dir);
        this.listViewNF2.Items[count].SubItems.Add(Form1.List_time[Form1.List_Display_count, 0]);
        this.listViewNF2.Items[count].SubItems.Add(Form1.LI_ID);
        this.listViewNF2.Items[count].SubItems.Add(Form1.LI_Length.ToString());
        this.listViewNF2.Items[count].SubItems.Add(Form1.LI_Str);
        this.listViewNF2.Items[count].SubItems.Add(Form1.LI_Check);
        this.listViewNF2.Items[count].SubItems.Add(Form1.LI_State);
        this.listViewNF2.Items[count].Selected = true;
        this.listViewNF2.Items[count].EnsureVisible();
        Form1.List_Static[(int) Form1.List_Mode_Data[Form1.List_Display_count, 2], 0] = (byte) count;
      }
      else
      {
        int index1 = (int) Form1.List_Static[(int) Form1.List_Mode_Data[Form1.List_Display_count, 2], 0];
        Form1.LI_Dir = "";
        Form1.LI_Ch = "";
        Form1.LI_ID = "";
        Form1.LI_Str = "";
        Form1.LI_State = "";
        Form1.LI_Check = "";
        Form1.LI_Length = 0;
        Form1.LI_Ch = Form1.List_Mode_Data[Form1.List_Display_count, 1].ToString();
        Form1.LI_ID = Form1.DECstr_to_HEXstr(Form1.List_Mode_Data[Form1.List_Display_count, 2].ToString());
        Form1.LI_ID = $"{Form1.LI_ID}[{Form1.LIN_PID_Parity(Form1.LI_ID)}]";
        Form1.LI_Dir = Form1.List_Mode_Data[Form1.List_Display_count, 3] != (byte) 0 ? "接收" : "发送";
        Form1.LI_State = Form1.List_Mode_Data[Form1.List_Display_count, 4] != (byte) 0 ? (Form1.List_Mode_Data[Form1.List_Display_count, 4] != (byte) 1 ? (Form1.List_Mode_Data[Form1.List_Display_count, 4] != (byte) 2 ? "帧头" : "V2") : "V1") : "校验和错误";
        Form1.LI_Length = (int) Form1.List_Mode_Data[Form1.List_Display_count, 5];
        for (int index2 = 6; index2 < Form1.LI_Length + 6; ++index2)
          Form1.LI_Str = $"{Form1.LI_Str}{Form1.DECstr_to_HEXstr(Form1.List_Mode_Data[Form1.List_Display_count, index2].ToString())} ";
        Form1.LI_Check = Form1.DECstr_to_HEXstr(Form1.List_Mode_Data[Form1.List_Display_count, 14].ToString());
        Form1.LI_Static_Save[Form1.List_Display_count, 0] = Form1.List_Display_count.ToString();
        Form1.LI_Static_Save[Form1.List_Display_count, 1] = Form1.LI_Ch;
        Form1.LI_Static_Save[Form1.List_Display_count, 2] = Form1.LI_Dir;
        Form1.LI_Static_Save[Form1.List_Display_count, 3] = Form1.List_time[Form1.List_Display_count, 0];
        Form1.LI_Static_Save[Form1.List_Display_count, 4] = Form1.LI_ID;
        Form1.LI_Static_Save[Form1.List_Display_count, 5] = Form1.LI_Length.ToString();
        Form1.LI_Static_Save[Form1.List_Display_count, 6] = Form1.LI_Str;
        Form1.LI_Static_Save[Form1.List_Display_count, 7] = Form1.LI_Check;
        Form1.LI_Static_Save[Form1.List_Display_count, 8] = Form1.LI_State;
        this.listViewNF2.Items[index1].SubItems[3].Text = Form1.List_time[Form1.List_Display_count, 0];
        this.listViewNF2.Items[index1].SubItems[4].Text = Form1.LI_ID;
        this.listViewNF2.Items[index1].SubItems[5].Text = Form1.LI_Length.ToString();
        this.listViewNF2.Items[index1].SubItems[6].Text = Form1.LI_Str;
        this.listViewNF2.Items[index1].SubItems[7].Text = Form1.LI_Check;
        this.listViewNF2.Items[index1].SubItems[8].Text = Form1.LI_State;
      }
      ++Form1.List_Display_count;
      if (Form1.List_Display_count >= (int) ushort.MaxValue)
      {
        lock (Form1.locker)
        {
          Form1.List_Display_count = 0;
          Form1.mode2_Save_Task_flag = true;
        }
      }
    }
    if (!Form1.List_send_fixed_flag || Form1.List_Send_flag || Form1.List_Display_count != Form1.List_count)
      return;
    this.qqTextBox51.Enabled = true;
    this.imageButton2.Enabled = true;
    this.imageButton4.Enabled = true;
    this.qqRadioButton3.Enabled = true;
    this.qqRadioButton4.Enabled = true;
    this.qqRadioButton5.Enabled = true;
    this.qqRadioButton6.Enabled = true;
    this.qqTextBox10.Enabled = true;
    this.qqTextBox17.Enabled = true;
    this.imageButton5.Enabled = true;
    this.imageButton6.Enabled = false;
    this.imageButton7.Enabled = true;
    this.imageButton8.Enabled = false;
    ((DataGridView) this.dataGridViewX1).Columns[0].ReadOnly = false;
    ((DataGridView) this.dataGridViewX1).Columns[1].ReadOnly = false;
    ((DataGridView) this.dataGridViewX1).Columns[2].ReadOnly = false;
    ((DataGridView) this.dataGridViewX1).Columns[3].ReadOnly = false;
    ((DataGridView) this.dataGridViewX1).Columns[5].ReadOnly = false;
    ((DataGridView) this.dataGridViewX1).Columns[6].ReadOnly = false;
    ((DataGridView) this.dataGridViewX1).Columns[0].DefaultCellStyle.BackColor = SystemColors.Window;
    ((DataGridView) this.dataGridViewX1).Columns[1].DefaultCellStyle.BackColor = SystemColors.Window;
    ((DataGridView) this.dataGridViewX1).Columns[2].DefaultCellStyle.BackColor = SystemColors.Window;
    ((DataGridView) this.dataGridViewX1).Columns[3].DefaultCellStyle.BackColor = SystemColors.Window;
    ((DataGridView) this.dataGridViewX1).Columns[5].DefaultCellStyle.BackColor = SystemColors.Window;
    ((DataGridView) this.dataGridViewX1).Columns[6].DefaultCellStyle.BackColor = SystemColors.Window;
    this.dS按钮1.Enabled = true;
    this.dS按钮2.Enabled = false;
    this.imageButton10.Enabled = true;
    this.dS按钮1.贴图 = Resources.运行8;
    this.dS按钮2.贴图 = Resources.停止9;
    ((Control) this.dataGridViewX2).Enabled = true;
    this.dS按钮3.Enabled = true;
    this.dS按钮4.Enabled = false;
    this.imageButton12.Enabled = true;
    this.dS按钮3.贴图 = Resources.运行8;
    this.dS按钮4.贴图 = Resources.停止8;
    this.dS按钮6.贴图 = Resources.停止8;
    this.qqCheckBox7.Enabled = true;
    this.qqCheckBox8.Enabled = true;
    this.qqCheckBox9.Enabled = true;
    this.qqCheckBox10.Enabled = true;
    this.qqCheckBox11.Enabled = true;
    this.qqCheckBox12.Enabled = true;
    this.qqCheckBox13.Enabled = true;
    this.qqCheckBox14.Enabled = true;
    this.qqCheckBox15.Enabled = true;
    this.qqCheckBox16.Enabled = true;
    this.qqCheckBox17.Enabled = true;
    this.qqCheckBox18.Enabled = true;
    this.qqTextBox18.Enabled = true;
    this.qqTextBox19.Enabled = true;
    this.qqTextBox20.Enabled = true;
    this.qqTextBox21.Enabled = true;
    this.qqTextBox22.Enabled = true;
    this.qqTextBox23.Enabled = true;
    this.qqTextBox24.Enabled = true;
    this.qqTextBox25.Enabled = true;
    this.qqTextBox26.Enabled = true;
    this.qqTextBox27.Enabled = true;
    this.qqTextBox28.Enabled = true;
    this.qqTextBox29.Enabled = true;
    this.imageButton14.Enabled = true;
    this.qqRadioButton11.Enabled = true;
    this.qqRadioButton12.Enabled = true;
    this.dS按钮5.Enabled = true;
    this.dS按钮6.Enabled = false;
    this.dS按钮5.贴图 = Resources.运行8;
    this.myButton5.Enabled = true;
    this.myButton5.NormalImage = (Image) Resources.btn_green_normal;
    Form1.BOOT_ON_flag = false;
    this.dS按钮9.Enabled = true;
    this.dS按钮10.贴图 = Resources.按钮3;
    this.dS按钮11.贴图 = Resources.灯6;
    this.dS按钮10.Enabled = true;
    this.dS按钮11.Enabled = true;
    this.imageButton15.Enabled = true;
    this.imageButton16.Enabled = true;
    this.imageButton17.Enabled = true;
    this.dS按钮13.Enabled = false;
    this.dS按钮13.贴图 = Resources.运行9;
    this.myButton1.Enabled = true;
    this.dS按钮15.Enabled = true;
    this.dS按钮15.贴图 = Resources.运行8;
    this.dS按钮14.Enabled = false;
    this.dS按钮14.贴图 = Resources.停止9;
    this.myButton3.Enabled = true;
    this.myButton2.Enabled = true;
    this.dS按钮17.Enabled = true;
    this.dS按钮16.Enabled = false;
    this.dS按钮17.贴图 = Resources.运行8;
    this.dS按钮16.贴图 = Resources.停止9;
    if (Form1.List_fixed_i == Form1.List_send_fixed_number)
    {
      init_Configuration.Output_Message = "已完成固定收发帧数！";
      int num2 = (int) init_Configuration.PDF_Interface.ShowDialog();
    }
    Form1.List_send_fixed_flag = false;
  }

  private async void Save_listViewNF2_Asynchronous()
  {
    await Form1.Save_listViewNF2_Asynchronous_Task();
  }

  private static async Task Save_listViewNF2_Asynchronous_Task()
  {
    int Save_Task_i = 0;
    int Save_i = 0;
    string Save_Task_str = "";
    string Save_ID = "";
    string Save_Ch = "";
    string Save_Dri = "";
    string Save_State = "";
    string Save_str = "";
    string Save_Check = "";
    int Save_Length = 0;
    await Task.Run((Action) (() =>
    {
      if (Form1.List_Display_Mode)
      {
        FileInfo fileInfo = new FileInfo(Form1.Save_FileName_str);
        FileStream fileStream = new FileStream(Form1.Save_FileName_str, FileMode.Create, FileAccess.Write);
        StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.UTF8);
        Save_Task_str = "";
        Save_Task_str = "序号,通道,方向,时间,ID,长度,数据,校验和,状态";
        streamWriter.WriteLine(Save_Task_str);
        do
        {
          Save_Task_str = "";
          Save_Task_str = $"{Form1.LI_Static_Save[Save_Task_i, 0]},{Form1.LI_Static_Save[Save_Task_i, 1]},{Form1.LI_Static_Save[Save_Task_i, 2]},{Form1.LI_Static_Save[Save_Task_i, 3]},{Form1.LI_Static_Save[Save_Task_i, 4]},{Form1.LI_Static_Save[Save_Task_i, 5]},{Form1.LI_Static_Save[Save_Task_i, 6]},{Form1.LI_Static_Save[Save_Task_i, 7]},{Form1.LI_Static_Save[Save_Task_i, 8]}";
          streamWriter.WriteLine(Save_Task_str);
          ++Save_Task_i;
          Form1.Save_ProgressBar_i = Save_Task_i;
          Thread.Sleep(1);
        }
        while (Save_Task_i < Form1.LI_Static_i);
        streamWriter.Close();
        fileStream.Close();
        Form1.Save_Finish_flag = true;
      }
      else
      {
        FileInfo fileInfo = new FileInfo(Form1.Save_FileName_str);
        FileStream fileStream = new FileStream(Form1.Save_FileName_str, FileMode.Create, FileAccess.Write);
        StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.UTF8);
        Save_Task_str = "";
        Save_Task_str = "序号,通道,方向,时间,ID,长度,数据,校验和,状态";
        streamWriter.WriteLine(Save_Task_str);
        do
        {
          Save_Ch = "";
          Save_Ch = Form1.List_Mode_Data[Save_Task_i, 1].ToString();
          Save_ID = "";
          Save_ID = Form1.DECstr_to_HEXstr(Form1.List_Mode_Data[Save_Task_i, 2].ToString());
          Save_ID = $"{Save_ID}[{Form1.LIN_PID_Parity(Save_ID)}]";
          Save_Dri = "";
          Save_Dri = Form1.List_Mode_Data[Save_Task_i, 3] != (byte) 0 ? "接收" : "发送";
          Save_State = "";
          Save_State = Form1.List_Mode_Data[Save_Task_i, 4] != (byte) 0 ? (Form1.List_Mode_Data[Save_Task_i, 4] != (byte) 1 ? (Form1.List_Mode_Data[Save_Task_i, 4] != (byte) 2 ? "帧头" : "V2") : "V1") : "校验和错误";
          Save_Length = 0;
          Save_Length = (int) Form1.List_Mode_Data[Save_Task_i, 5];
          Save_str = "";
          for (Save_i = 6; Save_i < Save_Length + 6; ++Save_i)
            Save_str = $"{Save_str}{Form1.DECstr_to_HEXstr(Form1.List_Mode_Data[Save_Task_i, Save_i].ToString())} ";
          Save_Check = "";
          Save_Check = Form1.DECstr_to_HEXstr(Form1.List_Mode_Data[Save_Task_i, 14].ToString());
          Save_Task_str = "";
          Save_Task_str = $"{Save_Task_i.ToString()},{Save_Ch},{Save_Dri},{Form1.List_time[Save_Task_i, 0]},{Save_ID},{Save_Length.ToString()},{Save_str},{Save_Check},{Save_State}";
          streamWriter.WriteLine(Save_Task_str);
          ++Save_Task_i;
          Form1.Save_ProgressBar_i = Save_Task_i;
          Thread.Sleep(1);
        }
        while (Save_Task_i < Form1.List_count);
        streamWriter.Close();
        fileStream.Close();
        Form1.Save_Finish_flag = true;
      }
    }));
  }

  public void Save_listViewNF2_Data()
  {
    do
    {
      this.Save_listViewNF2_Data_Task();
      Thread.Sleep(100);
    }
    while (!Form1.Exit_Save_listViewNF2_flag);
    Form1.Exit_Save_listViewNF2_flag = false;
    this.Save_listViewNF2_Thread.Abort();
  }

  public void Save_listViewNF2_Data_Task()
  {
    if (this.InvokeRequired)
    {
      this.Invoke((Delegate) new Form1.Save_listViewNF2_Agency(this.Save_listViewNF2_Data_Task), new object[0]);
    }
    else
    {
      if (this.progressBarEx1.Value <= this.progressBarEx1.Maximum)
      {
        this.progressBarEx1.Value = Form1.Save_ProgressBar_i;
        this.progressBarEx1.Text = (Form1.Save_ProgressBar_i * 100 / this.progressBarEx1.Maximum).ToString() + "%";
      }
      if (Form1.Save_Finish_flag)
      {
        Form1.Save_Finish_flag = false;
        Form1.Exit_Save_listViewNF2_flag = true;
        this.imageButton2.Enabled = true;
        this.imageButton4.Enabled = true;
        this.qqRadioButton3.Enabled = true;
        this.qqRadioButton4.Enabled = true;
        this.qqRadioButton5.Enabled = true;
        this.qqRadioButton6.Enabled = true;
        this.qqTextBox10.Enabled = true;
        this.qqTextBox17.Enabled = true;
        this.imageButton5.Enabled = true;
        this.imageButton6.Enabled = false;
        this.imageButton7.Enabled = true;
        this.imageButton8.Enabled = false;
        this.dS按钮1.Enabled = true;
        this.dS按钮2.Enabled = false;
        this.qqRadioButton7.Enabled = true;
        this.qqRadioButton8.Enabled = true;
        this.imageButton9.Enabled = true;
        this.imageButton10.Enabled = true;
        this.dS按钮1.贴图 = Resources.运行8;
        this.dS按钮2.贴图 = Resources.停止8;
        ((Control) this.dataGridViewX2).Enabled = true;
        this.dS按钮3.Enabled = true;
        this.dS按钮4.Enabled = false;
        this.imageButton11.Enabled = true;
        this.imageButton12.Enabled = true;
        this.dS按钮3.贴图 = Resources.运行8;
        this.dS按钮4.贴图 = Resources.停止8;
        this.qqCheckBox7.Enabled = true;
        this.qqCheckBox8.Enabled = true;
        this.qqCheckBox9.Enabled = true;
        this.qqCheckBox10.Enabled = true;
        this.qqCheckBox11.Enabled = true;
        this.qqCheckBox12.Enabled = true;
        this.qqCheckBox13.Enabled = true;
        this.qqCheckBox14.Enabled = true;
        this.qqCheckBox15.Enabled = true;
        this.qqCheckBox16.Enabled = true;
        this.qqCheckBox17.Enabled = true;
        this.qqCheckBox18.Enabled = true;
        this.qqTextBox18.Enabled = true;
        this.qqTextBox19.Enabled = true;
        this.qqTextBox20.Enabled = true;
        this.qqTextBox21.Enabled = true;
        this.qqTextBox22.Enabled = true;
        this.qqTextBox23.Enabled = true;
        this.qqTextBox24.Enabled = true;
        this.qqTextBox25.Enabled = true;
        this.qqTextBox26.Enabled = true;
        this.qqTextBox27.Enabled = true;
        this.qqTextBox28.Enabled = true;
        this.qqTextBox29.Enabled = true;
        this.qqRadioButton13.Enabled = true;
        this.qqRadioButton14.Enabled = true;
        this.imageButton13.Enabled = true;
        this.imageButton14.Enabled = true;
        this.qqRadioButton11.Enabled = true;
        this.qqRadioButton12.Enabled = true;
        this.dS按钮5.Enabled = true;
        this.dS按钮6.贴图 = Resources.停止8;
        this.dS按钮6.Enabled = false;
        this.dS按钮5.贴图 = Resources.运行8;
        this.myButton5.Enabled = true;
        this.myButton5.NormalImage = (Image) Resources.btn_green_normal;
        Form1.BOOT_ON_flag = false;
        this.dS按钮9.Enabled = true;
        this.dS按钮10.贴图 = Resources.按钮3;
        this.dS按钮11.贴图 = Resources.灯6;
        this.dS按钮10.Enabled = true;
        this.dS按钮11.Enabled = true;
        this.imageButton15.Enabled = true;
        this.imageButton16.Enabled = true;
        this.imageButton17.Enabled = true;
        this.dS按钮13.Enabled = false;
        this.dS按钮13.贴图 = Resources.运行9;
        this.myButton1.Enabled = true;
        this.dS按钮15.Enabled = true;
        this.dS按钮15.贴图 = Resources.运行8;
        this.dS按钮14.Enabled = false;
        this.dS按钮14.贴图 = Resources.停止9;
        this.myButton3.Enabled = true;
        this.myButton2.Enabled = true;
        this.dS按钮17.Enabled = true;
        this.dS按钮16.Enabled = false;
        this.dS按钮17.贴图 = Resources.运行8;
        this.dS按钮16.贴图 = Resources.停止9;
      }
    }
  }

  private async void RTOS_Save_mode2_Asynchronous()
  {
    await Form1.RTOS_Save_mode2_Asynchronous_Task();
  }

  private static async Task RTOS_Save_mode2_Asynchronous_Task()
  {
    string Save_Task_str = "";
    await Task.Run((Action) (() =>
    {
      Form1.mode2_Save_Task_i = 0;
      string str1 = Path.Combine(Application.StartupPath, "Data\\");
      Form1.RTOS_Time = DateTime.Now;
      Form1.RTOS_Save_FileName_str = $"{str1}列表模式 Data for {Form1.RTOS_Time.ToString("yyyy-MM-dd HH-mm-ss-fff")}.csv";
      FileInfo fileInfo = new FileInfo(Form1.RTOS_Save_FileName_str);
      FileStream fileStream = new FileStream(Form1.RTOS_Save_FileName_str, FileMode.Create, FileAccess.Write);
      StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.UTF8);
      Save_Task_str = "";
      Save_Task_str = "序号,通道,方向,时间,ID,长度,数据,校验和,状态";
      streamWriter.WriteLine(Save_Task_str);
      while (true)
      {
        if (Form1.mode2_Save_Task_i != Form1.List_Display_count && Form1.mode2_Save_Task_i < (int) ushort.MaxValue)
        {
          Save_Task_str = "";
          Save_Task_str = $"{Form1.LI_Static_Save[Form1.mode2_Save_Task_i, 0]},{Form1.LI_Static_Save[Form1.mode2_Save_Task_i, 1]},{Form1.LI_Static_Save[Form1.mode2_Save_Task_i, 2]},{Form1.LI_Static_Save[Form1.mode2_Save_Task_i, 3]},{Form1.LI_Static_Save[Form1.mode2_Save_Task_i, 4]},{Form1.LI_Static_Save[Form1.mode2_Save_Task_i, 5]},{Form1.LI_Static_Save[Form1.mode2_Save_Task_i, 6]},{Form1.LI_Static_Save[Form1.mode2_Save_Task_i, 7]},{Form1.LI_Static_Save[Form1.mode2_Save_Task_i, 8]}";
          streamWriter.WriteLine(Save_Task_str);
          ++Form1.mode2_Save_Task_i;
        }
        Thread.Sleep(1);
        if (Form1.mode2_Save_Task_i >= (int) ushort.MaxValue && Form1.mode2_Save_Task_flag)
        {
          Form1.mode2_Save_Task_flag = false;
          Form1.mode2_Save_Task_i = 0;
          streamWriter.Close();
          fileStream.Close();
          if (Form1.List_Send_flag || Form1.mode2_Save_Task_i != Form1.List_Display_count || Form1.List_count != Form1.List_Display_count)
          {
            string str2 = Path.Combine(Application.StartupPath, "Data\\");
            Form1.RTOS_Time = DateTime.Now;
            Form1.RTOS_Save_FileName_str = $"{str2}列表模式 Data for {Form1.RTOS_Time.ToString("yyyy-MM-dd HH-mm-ss-fff")}.csv";
            fileInfo = new FileInfo(Form1.RTOS_Save_FileName_str);
            fileStream = new FileStream(Form1.RTOS_Save_FileName_str, FileMode.Create, FileAccess.Write);
            streamWriter = new StreamWriter((Stream) fileStream, Encoding.UTF8);
            Save_Task_str = "";
            Save_Task_str = "序号,通道,方向,时间,ID,长度,数据,校验和,状态";
            streamWriter.WriteLine(Save_Task_str);
          }
          else
            break;
        }
        else if (Form1.List_count != Form1.List_Display_count || Form1.mode2_Save_Task_i != Form1.List_Display_count || Form1.List_Send_flag)
        {
          if (!Form1.Device_switch_flag)
            goto label_8;
        }
        else
          goto label_6;
      }
      return;
label_6:
      Form1.mode2_Save_Task_i = 0;
      streamWriter.Close();
      fileStream.Close();
      return;
label_8:
      Form1.mode2_Save_Task_i = 0;
      streamWriter.Close();
      fileStream.Close();
    }));
  }

  private async void AUTO_Task() => await this.AUTO_TX_Task();

  private async Task AUTO_TX_Task()
  {
    int task_Send_i = 0;
    byte AUTO_ID = 0;
    int AUTO_Length = 8;
    await Task.Run((Action) (() =>
    {
      try
      {
        while (task_Send_i < 504)
        {
          if (Form1.CheckSum_Type == "增强型校验和")
          {
            Form1.Read_Slave_Data(AUTO_ID, AUTO_Length, "V2");
            this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          }
          else
          {
            Form1.Read_Slave_Data(AUTO_ID, AUTO_Length, "V1");
            this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          }
          if (AUTO_ID < (byte) 63 /*0x3F*/ && AUTO_Length == 1)
            ++AUTO_ID;
          if (AUTO_Length == 1)
            AUTO_Length = 8;
          else
            --AUTO_Length;
          Thread.Sleep(50);
          ++task_Send_i;
          Form1.AUTO_Progress_value = task_Send_i;
        }
        Form1.AUTO_flish_flag = true;
      }
      catch
      {
        Form1.System_UART_RX_Rrror_flag = true;
      }
    }));
  }

  public void AUTO_Sync_Thread()
  {
    do
    {
      this.AUTO_Discern_Task();
      Thread.Sleep(100);
    }
    while (!Form1.Exit_AUTO_flag);
    Form1.AUTO_flish_flag = false;
    Form1.Exit_AUTO_flag = false;
    Form1.Rur_Mode = 0;
    Form1.Send_Mode_Command(0, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
    if (this.serialPort1.IsOpen)
      this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
    this.AUTO_Sync_Task.Abort();
  }

  public void AUTO_Discern_Task()
  {
    if (this.InvokeRequired)
    {
      this.Invoke((Delegate) new Form1.Recognition_Slave_Agency(this.AUTO_Discern_Task), new object[0]);
    }
    else
    {
      this.prog13._setProgress(Form1.AUTO_Progress_value);
      if (Form1.AUTO_Progress_value >= this.prog13._maxNum)
      {
        Form1.Exit_AUTO_flag = true;
        this.imageButton2.Enabled = true;
        this.myToolBar1.Enabled = true;
        this.imageButton15.Enabled = true;
        this.imageButton16.Enabled = true;
        this.imageButton17.Enabled = true;
        this.dS按钮13.Enabled = false;
        this.dS按钮13.贴图 = Resources.运行9;
        this.tabControl1.SelectedTab = this.tabPage1;
      }
    }
  }

  private void myButton2_Click(object sender, EventArgs e)
  {
  }

  private void dS按钮9_ButtonClick(object Sender)
  {
    byte[] numArray = new byte[17];
    byte num1 = 0;
    uint num2 = 0;
    this.openFileDialog1.Title = "打开文件";
    this.openFileDialog1.Filter = "Hex文件|*.hex";
    this.openFileDialog1.FileName = "";
    if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
      return;
    this.qqTextBox30.Text = this.openFileDialog1.FileName;
    if (this.openFileDialog1.FilterIndex == 1)
    {
      StreamReader streamReader = new StreamReader(this.openFileDialog1.FileName, Encoding.Default);
      this.listViewNF5.Items.Add("开始读取Hex文件中的数据.......");
      this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
      this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
      Array.Clear((Array) Form1.BOOT_DATA, 0, Form1.BOOT_DATA.Length);
      this.BOOT_Data_i = 0U;
      try
      {
        string str1;
        while ((str1 = streamReader.ReadLine()) != null)
        {
          if (str1.ToString() != "")
          {
            if (str1.ToString().Substring(7, 2) == "00")
            {
              string str2 = str1.ToString();
              byte dec1 = (byte) Form1.HEXstr_to_DEC(str2.Substring(3, 2));
              byte dec2 = (byte) Form1.HEXstr_to_DEC(str2.Substring(5, 2));
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 0] = (byte) 34;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 1] = (byte) 0;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 2] = (byte) 62;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 3] = (byte) 0;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 4] = (byte) 2;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 5] = (byte) 8;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 6] = (byte) 0;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 7] = num1;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 8] = dec1;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 9] = dec2;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 10] = (byte) 0;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 11] = (byte) 0;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 12] = (byte) 0;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 13] = (byte) 0;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 14] = (byte) 0;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 15] = (byte) 0;
              ++this.BOOT_Data_i;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 0] = (byte) 34;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 1] = (byte) 0;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 2] = (byte) 62;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 3] = (byte) 0;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 4] = (byte) 2;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 5] = (byte) 8;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 14] = (byte) 0;
              Form1.BOOT_DATA[(int) this.BOOT_Data_i, 15] = (byte) 0;
              byte dec3 = (byte) Form1.HEXstr_to_DEC(str2.Substring(1, 2));
              if (dec3 == (byte) 16 /*0x10*/)
              {
                int startIndex = 9;
                for (byte index = 0; index < (byte) 8; ++index)
                {
                  Form1.BOOT_DATA[(int) this.BOOT_Data_i, 6 + (int) index] = (byte) Form1.HEXstr_to_DEC(str2.Substring(startIndex, 2));
                  startIndex += 2;
                }
                ++this.BOOT_Data_i;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 0] = (byte) 34;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 1] = (byte) 0;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 2] = (byte) 62;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 3] = (byte) 0;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 4] = (byte) 2;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 5] = (byte) 8;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 14] = (byte) 0;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 15] = (byte) 0;
                for (byte index = 0; index < (byte) 8; ++index)
                {
                  Form1.BOOT_DATA[(int) this.BOOT_Data_i, 6 + (int) index] = (byte) Form1.HEXstr_to_DEC(str2.Substring(startIndex, 2));
                  startIndex += 2;
                }
                Form1.BOOT_DATA[(int) this.BOOT_Data_i - 2, 10] = (byte) Form1.HEXstr_to_DEC(str2.Substring(startIndex, 2));
              }
              else if (dec3 < (byte) 16 /*0x10*/)
              {
                int startIndex = 9;
                for (byte index = 0; (int) index < (int) dec3; ++index)
                {
                  numArray[(int) index] = (byte) Form1.HEXstr_to_DEC(str2.Substring(startIndex, 2));
                  startIndex += 2;
                }
                num2 = 0U;
                uint num3 = (uint) ((~((int) (byte) Form1.HEXstr_to_DEC(str2.Substring(startIndex, 2)) - 1) & (int) byte.MaxValue) - (int) dec3 + 16 /*0x10*/);
                for (byte index = 0; (int) index < 16 /*0x10*/ - (int) dec3; ++index)
                {
                  numArray[(int) dec3 + (int) index] = (byte) Form1.HEXstr_to_DEC("FF");
                  num3 += (uint) byte.MaxValue;
                }
                uint num4 = (uint) (~(int) num3 + 1 & (int) byte.MaxValue);
                numArray[16 /*0x10*/] = (byte) num4;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 6] = numArray[0];
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 7] = numArray[1];
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 8] = numArray[2];
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 9] = numArray[3];
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 10] = numArray[4];
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 11] = numArray[5];
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 12] = numArray[6];
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 13] = numArray[7];
                ++this.BOOT_Data_i;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 0] = (byte) 34;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 1] = (byte) 0;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 2] = (byte) 62;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 3] = (byte) 0;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 4] = (byte) 2;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 5] = (byte) 8;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 14] = (byte) 0;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 15] = (byte) 0;
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 6] = numArray[8];
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 7] = numArray[9];
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 8] = numArray[10];
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 9] = numArray[11];
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 10] = numArray[12];
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 11] = numArray[13];
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 12] = numArray[14];
                Form1.BOOT_DATA[(int) this.BOOT_Data_i, 13] = numArray[15];
                Form1.BOOT_DATA[(int) this.BOOT_Data_i - 2, 10] = numArray[16 /*0x10*/];
              }
              ++this.BOOT_Data_i;
            }
            else if (str1.ToString().Substring(7, 2) == "04")
              num1 = (byte) Form1.HEXstr_to_DEC(str1.Substring(11, 2));
          }
        }
      }
      catch
      {
        streamReader.Close();
        init_Configuration.Output_Message = "读取数据失败！";
        int num5 = (int) init_Configuration.PDF_Interface.ShowDialog();
        return;
      }
      streamReader.Close();
      this.listViewNF5.Items.Add($"读取完毕！  共:{this.BOOT_Data_i.ToString()}行---- 共:{(this.BOOT_Data_i * 2U / 3U * 8U).ToString()}个字节，即{((float) (this.BOOT_Data_i * 2U / 3U * 8U) / 1024f).ToString()}KB");
      this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
      this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
      this.listViewNF5.Items.Add("----------------------------------------------------------------");
      this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
      this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
      this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
    }
  }

  private void dS按钮12_ButtonClick(object Sender)
  {
    string str = Path.Combine(Application.StartupPath, "通信协议\\通信协议.pdf");
    if (File.Exists(str))
    {
      Process.Start(str);
    }
    else
    {
      init_Configuration.Output_Message = "通信协议文件丢失";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
    }
  }

  private void dS按钮10_ButtonClick(object Sender)
  {
    if (this.qqTextBox30.Text != "")
    {
      try
      {
        Form1.BOOT_time_value = (int) Convert.ToInt16(this.qqTextBox33.Text);
        if (Form1.BOOT_time_value < 20)
        {
          init_Configuration.Output_Message = "定时时间超出范围！";
          int num = (int) init_Configuration.PDF_Interface.ShowDialog();
          return;
        }
      }
      catch
      {
        init_Configuration.Output_Message = "定时时间格式不正确！";
        int num = (int) init_Configuration.PDF_Interface.ShowDialog();
        return;
      }
      this.myToolBar1.Enabled = false;
      this.dS按钮9.Enabled = false;
      this.qqTextBox30.Enabled = false;
      this.dS按钮11.贴图 = Resources.灯6;
      this.dS按钮11.Enabled = false;
      this.dS按钮10.贴图 = Resources.按钮7;
      this.dS按钮10.Enabled = false;
      this.qqTextBox31.Enabled = false;
      this.qqTextBox32.Enabled = false;
      this.qqTextBox33.Enabled = false;
      this.qqTextBox49.Enabled = false;
      this.qqTextBox50.Enabled = false;
      this.listViewNF5.Items.Clear();
      this.prog12._setProgress(0);
      Form1.BOOT_Task_Data_i = 0U;
      Form1.ACK_Flag1 = false;
      Form1.ACK_Flag2 = false;
      Form1.ACK_Flag3 = false;
      Form1.ACK_Flag4 = false;
      Form1.ACK_Flag5 = false;
      Form1.ACK_Flag6 = false;
      Form1.NoACK_Flag1 = false;
      Form1.NoACK_Flag2 = false;
      Form1.NoACK_Flag3 = false;
      Form1.NoACK_Flag4 = false;
      Form1.NoACK_Flag5 = false;
      Form1.NoACK_Flag6 = false;
      Form1.Erase_Start_Address2 = (byte) 0;
      Form1.Erase_Start_Address1 = (byte) 0;
      Form1.Erase_Start_Address0 = (byte) 0;
      Form1.Erase_End_Address2 = (byte) 0;
      Form1.Erase_End_Address1 = (byte) 0;
      Form1.Erase_End_Address0 = (byte) 0;
      Form1.Erase_Start_Address2 = (byte) Form1.HEXstr_to_DEC(this.qqTextBox49.Text.Substring(2, 2));
      Form1.Erase_Start_Address1 = (byte) Form1.HEXstr_to_DEC(this.qqTextBox49.Text.Substring(4, 2));
      Form1.Erase_Start_Address0 = (byte) Form1.HEXstr_to_DEC(this.qqTextBox49.Text.Substring(6, 2));
      Form1.Erase_End_Address2 = (byte) Form1.HEXstr_to_DEC(this.qqTextBox50.Text.Substring(2, 2));
      Form1.Erase_End_Address1 = (byte) Form1.HEXstr_to_DEC(this.qqTextBox50.Text.Substring(4, 2));
      Form1.Erase_End_Address0 = (byte) Form1.HEXstr_to_DEC(this.qqTextBox50.Text.Substring(6, 2));
      Form1.Rur_Mode = 0;
      Form1.Send_Mode_Command(0, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
      this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
      Thread.Sleep(200);
      Form1.Rur_Mode = 1;
      Form1.Send_Mode_Command(1, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
      this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
      Thread.Sleep(100);
      Form1.Rur_Mode = 6;
      this.BOOT_Thread = new Thread(new ThreadStart(this.BOOT_Upgrade));
      this.BOOT_Thread.IsBackground = false;
      this.BOOT_Thread.Start();
    }
    else
    {
      init_Configuration.Output_Message = "请打开Hex文件！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
    }
  }

  public void BOOT_Upgrade()
  {
    Form1.BOOT_Status = 0;
    Form1.Start_dt = DateTime.Now;
    do
    {
      this.BOOT_Task();
      Thread.Sleep(Form1.BOOT_Delay[Form1.BOOT_Status - 1]);
    }
    while (!Form1.WDT_Finish_break);
    Form1.WDT_Finish_break = false;
    Form1.WDT_Finish = false;
    Form1.BOOT_ON_flag = false;
    this.BOOT_Thread.Abort();
  }

  public void BOOT_Task()
  {
    if (this.InvokeRequired)
    {
      this.Invoke((Delegate) new Form1.BOOT_Agency(this.BOOT_Task), new object[0]);
    }
    else
    {
      switch (Form1.BOOT_Status)
      {
        case 0:
          this.prog12._setProgress(0);
          Form1.BOOT_Progress = (int) this.BOOT_Data_i;
          this.prog12._maxNum = Form1.BOOT_Progress;
          Form1.ACK_Flag1 = false;
          Form1.NoACK_Flag1 = false;
          Form1.WDT_Finish = false;
          Form1.Host_Send_Data((byte) 0, "00 00 00 00 00 00 00 00", 8, "V2");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.listViewNF5.Items.Add("已发送 唤醒指令!");
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
          ++Form1.BOOT_Status;
          break;
        case 1:
          Form1.Host_Send_Data((byte) 62, "67 6F 72 65 73 65 74 00", 8, "V2");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.listViewNF5.Items.Add("已发送 第1次复位指令!");
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
          ++Form1.BOOT_Status;
          break;
        case 2:
          Form1.Host_Send_Data((byte) 62, "67 6F 72 65 73 65 74 00", 8, "V2");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.listViewNF5.Items.Add("已发送 第2次复位指令!");
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
          ++Form1.BOOT_Status;
          break;
        case 3:
          Form1.Host_Send_Data((byte) 62, "67 6F 72 65 73 65 74 00", 8, "V2");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.listViewNF5.Items.Add("已发送 第3次复位指令!");
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
          ++Form1.BOOT_Status;
          break;
        case 4:
          Form1.Host_Send_Data((byte) 62, "AA 55 AA 55 AA 55 AA 55", 8, "V2");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.listViewNF5.Items.Add("已发送 进入刷写模式指令!");
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
          this.listViewNF5.Items.Add("等待下位机应答......");
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
          ++Form1.BOOT_Status;
          break;
        case 5:
          Form1.Read_Slave_Data((byte) 63 /*0x3F*/, 8, "V2");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.WDT_Thread();
          ++Form1.BOOT_Status;
          break;
        case 6:
          if (!Form1.ACK_Flag1 && !Form1.NoACK_Flag1 && Form1.WDT_Finish)
          {
            this.listViewNF5.Items.Add("下位机应答超时!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.listViewNF5.Items.Add("BOOT升级失败!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.myToolBar1.Enabled = true;
            this.qqTextBox31.Enabled = true;
            this.qqTextBox32.Enabled = true;
            this.qqTextBox33.Enabled = true;
            this.qqTextBox49.Enabled = true;
            this.qqTextBox50.Enabled = true;
            this.dS按钮9.Enabled = true;
            this.qqTextBox30.Enabled = true;
            this.dS按钮11.贴图 = Resources.灯8;
            this.dS按钮11.Enabled = true;
            this.dS按钮10.贴图 = Resources.按钮3;
            this.dS按钮10.Enabled = true;
            Form1.WDT_Finish_break = true;
          }
          if (Form1.ACK_Flag1)
          {
            Form1.WDT_Finish = true;
            ++Form1.BOOT_Task_Data_i;
            this.prog12._setProgress((int) Form1.BOOT_Task_Data_i);
            this.listViewNF5.Items.Add("接收到ACK应答!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.listViewNF5.Items.Add("----------------------------------------------------------------");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            Form1.ACK_Flag1 = false;
            ++Form1.BOOT_Status;
          }
          if (Form1.NoACK_Flag1)
          {
            Form1.WDT_Finish = true;
            this.listViewNF5.Items.Add("接收到NO ACK应答!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.listViewNF5.Items.Add("BOOT升级失败!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.myToolBar1.Enabled = true;
            this.qqTextBox31.Enabled = true;
            this.qqTextBox32.Enabled = true;
            this.qqTextBox33.Enabled = true;
            this.qqTextBox49.Enabled = true;
            this.qqTextBox50.Enabled = true;
            this.dS按钮9.Enabled = true;
            this.qqTextBox30.Enabled = true;
            this.dS按钮11.贴图 = Resources.灯8;
            this.dS按钮11.Enabled = true;
            this.dS按钮10.贴图 = Resources.按钮3;
            this.dS按钮10.Enabled = true;
            Form1.NoACK_Flag1 = false;
            Form1.WDT_Finish_break = true;
            break;
          }
          break;
        case 7:
          Form1.Host_Send_Data((byte) 62, $"{$"{$"{$"{$"{$"{$"{Form1.DECstr_to_HEXstr("00")} {Form1.DECstr_to_HEXstr(Form1.Erase_Start_Address2.ToString())}"} {Form1.DECstr_to_HEXstr(Form1.Erase_Start_Address1.ToString())}"} {Form1.DECstr_to_HEXstr(Form1.Erase_Start_Address0.ToString())}"} {Form1.DECstr_to_HEXstr("00")}"} {Form1.DECstr_to_HEXstr(Form1.Erase_End_Address2.ToString())}"} {Form1.DECstr_to_HEXstr(Form1.Erase_End_Address1.ToString())}"} {Form1.DECstr_to_HEXstr(Form1.Erase_End_Address0.ToString())}", 8, "V2");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.listViewNF5.Items.Add("已发送 擦除的地址!");
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
          this.listViewNF5.Items.Add("等待下位机应答......");
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
          ++Form1.BOOT_Status;
          break;
        case 8:
          Form1.ACK_Flag2 = false;
          Form1.NoACK_Flag2 = false;
          Form1.WDT_Finish = false;
          Form1.Read_Slave_Data((byte) 63 /*0x3F*/, 8, "V2");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.WDT_Thread();
          ++Form1.BOOT_Status;
          break;
        case 9:
          if (!Form1.ACK_Flag2 && !Form1.NoACK_Flag2 && Form1.WDT_Finish)
          {
            this.listViewNF5.Items.Add("下位机应答超时!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.listViewNF5.Items.Add("BOOT升级失败!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.myToolBar1.Enabled = true;
            this.qqTextBox31.Enabled = true;
            this.qqTextBox32.Enabled = true;
            this.qqTextBox33.Enabled = true;
            this.qqTextBox49.Enabled = true;
            this.qqTextBox50.Enabled = true;
            this.dS按钮9.Enabled = true;
            this.qqTextBox30.Enabled = true;
            this.dS按钮11.贴图 = Resources.灯8;
            this.dS按钮11.Enabled = true;
            this.dS按钮10.贴图 = Resources.按钮3;
            this.dS按钮10.Enabled = true;
            Form1.WDT_Finish_break = true;
          }
          if (Form1.ACK_Flag2)
          {
            Form1.WDT_Finish = true;
            ++Form1.BOOT_Task_Data_i;
            this.prog12._setProgress((int) Form1.BOOT_Task_Data_i);
            this.listViewNF5.Items.Add("接收到ACK应答!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.listViewNF5.Items.Add("----------------------------------------------------------------");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            Form1.ACK_Flag2 = false;
            ++Form1.BOOT_Status;
          }
          if (Form1.NoACK_Flag2)
          {
            Form1.WDT_Finish = true;
            this.listViewNF5.Items.Add("接收到NO ACK应答!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.listViewNF5.Items.Add("BOOT升级失败!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.myToolBar1.Enabled = true;
            this.qqTextBox31.Enabled = true;
            this.qqTextBox32.Enabled = true;
            this.qqTextBox33.Enabled = true;
            this.qqTextBox49.Enabled = true;
            this.qqTextBox50.Enabled = true;
            this.dS按钮9.Enabled = true;
            this.qqTextBox30.Enabled = true;
            this.dS按钮11.贴图 = Resources.灯8;
            this.dS按钮11.Enabled = true;
            this.dS按钮10.贴图 = Resources.按钮3;
            this.dS按钮10.Enabled = true;
            Form1.NoACK_Flag2 = false;
            Form1.WDT_Finish_break = true;
            break;
          }
          break;
        case 10:
          Form1.Host_Send_Data((byte) 62, "67 6F 66 6C 61 73 68 00", 8, "V2");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.listViewNF5.Items.Add("已发送 擦除Flash指令!");
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
          this.listViewNF5.Items.Add("等待下位机应答......");
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
          ++Form1.BOOT_Status;
          break;
        case 11:
          Form1.ACK_Flag3 = false;
          Form1.NoACK_Flag3 = false;
          Form1.WDT_Finish = false;
          Form1.Read_Slave_Data((byte) 63 /*0x3F*/, 8, "V2");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.WDT_Thread();
          ++Form1.BOOT_Status;
          break;
        case 12:
          if (!Form1.ACK_Flag3 && !Form1.NoACK_Flag3 && Form1.WDT_Finish)
          {
            this.listViewNF5.Items.Add("下位机应答超时!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.listViewNF5.Items.Add("BOOT升级失败!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.myToolBar1.Enabled = true;
            this.qqTextBox31.Enabled = true;
            this.qqTextBox32.Enabled = true;
            this.qqTextBox33.Enabled = true;
            this.qqTextBox49.Enabled = true;
            this.qqTextBox50.Enabled = true;
            this.dS按钮9.Enabled = true;
            this.qqTextBox30.Enabled = true;
            this.dS按钮11.贴图 = Resources.灯8;
            this.dS按钮11.Enabled = true;
            this.dS按钮10.贴图 = Resources.按钮3;
            this.dS按钮10.Enabled = true;
            Form1.WDT_Finish_break = true;
          }
          if (Form1.ACK_Flag3)
          {
            Form1.WDT_Finish = true;
            ++Form1.BOOT_Task_Data_i;
            this.prog12._setProgress((int) Form1.BOOT_Task_Data_i);
            this.listViewNF5.Items.Add("接收到ACK应答!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.listViewNF5.Items.Add("----------------------------------------------------------------");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            Form1.ACK_Flag3 = false;
            ++Form1.BOOT_Status;
          }
          if (Form1.NoACK_Flag3)
          {
            Form1.WDT_Finish = true;
            this.listViewNF5.Items.Add("接收到NO ACK应答!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.listViewNF5.Items.Add("BOOT升级失败!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.myToolBar1.Enabled = true;
            this.qqTextBox31.Enabled = true;
            this.qqTextBox32.Enabled = true;
            this.qqTextBox33.Enabled = true;
            this.qqTextBox49.Enabled = true;
            this.qqTextBox50.Enabled = true;
            this.dS按钮9.Enabled = true;
            this.qqTextBox30.Enabled = true;
            this.dS按钮11.贴图 = Resources.灯8;
            this.dS按钮11.Enabled = true;
            this.dS按钮10.贴图 = Resources.按钮3;
            this.dS按钮10.Enabled = true;
            Form1.NoACK_Flag3 = false;
            Form1.WDT_Finish_break = true;
            break;
          }
          break;
        case 13:
          this.listViewNF5.Items.Add("开始发送数据.......");
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
          Form1.ACK_Flag5 = false;
          Form1.NoACK_Flag5 = false;
          Form1.WDT_Finish = false;
          Form1.Program_Finish_flag = false;
          this.Program_Thread();
          ++Form1.BOOT_Status;
          break;
        case 14:
          if (Form1.Program_Finish_flag)
          {
            ++Form1.BOOT_Status;
            Form1.ACK_Flag5 = false;
            Form1.NoACK_Flag5 = false;
            Form1.WDT_Finish = false;
          }
          this.prog12._setProgress((int) Form1.BOOT_Task_Data_i);
          if (!Form1.ACK_Flag5 && !Form1.NoACK_Flag5 && Form1.WDT_Finish)
          {
            this.listViewNF5.Items.Add("下位机应答超时!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.listViewNF5.Items.Add("BOOT升级失败!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.myToolBar1.Enabled = true;
            this.qqTextBox31.Enabled = true;
            this.qqTextBox32.Enabled = true;
            this.qqTextBox33.Enabled = true;
            this.qqTextBox49.Enabled = true;
            this.qqTextBox50.Enabled = true;
            this.dS按钮9.Enabled = true;
            this.qqTextBox30.Enabled = true;
            this.dS按钮11.贴图 = Resources.灯8;
            this.dS按钮11.Enabled = true;
            this.dS按钮10.贴图 = Resources.按钮3;
            this.dS按钮10.Enabled = true;
            Form1.WDT_Finish_break = true;
          }
          if (Form1.NoACK_Flag5)
          {
            Form1.WDT_Finish = true;
            this.listViewNF5.Items.Add("接收到NO ACK应答!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.listViewNF5.Items.Add("BOOT升级失败!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.myToolBar1.Enabled = true;
            this.qqTextBox31.Enabled = true;
            this.qqTextBox32.Enabled = true;
            this.qqTextBox33.Enabled = true;
            this.qqTextBox49.Enabled = true;
            this.qqTextBox50.Enabled = true;
            this.dS按钮9.Enabled = true;
            this.qqTextBox30.Enabled = true;
            this.dS按钮11.贴图 = Resources.灯8;
            this.dS按钮11.Enabled = true;
            this.dS按钮10.贴图 = Resources.按钮3;
            this.dS按钮10.Enabled = true;
            Form1.WDT_Finish_break = true;
            break;
          }
          break;
        case 15:
          Form1.Host_Send_Data((byte) 60, "FF 00 FF 00 FF 00 FF 00", 8, "V1");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.listViewNF5.Items.Add("已发送 退出刷写模式指令!");
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
          this.listViewNF5.Items.Add("等待下位机应答......");
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
          ++Form1.BOOT_Status;
          break;
        case 16 /*0x10*/:
          Form1.ACK_Flag6 = false;
          Form1.NoACK_Flag6 = false;
          Form1.WDT_Finish = false;
          Form1.Read_Slave_Data((byte) 61, 8, "V1");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.WDT_Thread();
          ++Form1.BOOT_Status;
          break;
        case 17:
          if (!Form1.ACK_Flag6 && !Form1.NoACK_Flag6 && Form1.WDT_Finish)
          {
            this.listViewNF5.Items.Add("下位机应答超时!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.listViewNF5.Items.Add("BOOT升级失败!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.myToolBar1.Enabled = true;
            this.qqTextBox31.Enabled = true;
            this.qqTextBox32.Enabled = true;
            this.qqTextBox33.Enabled = true;
            this.qqTextBox49.Enabled = true;
            this.qqTextBox50.Enabled = true;
            this.dS按钮9.Enabled = true;
            this.qqTextBox30.Enabled = true;
            this.dS按钮11.贴图 = Resources.灯8;
            this.dS按钮11.Enabled = true;
            this.dS按钮10.贴图 = Resources.按钮3;
            this.dS按钮10.Enabled = true;
            Form1.WDT_Finish_break = true;
          }
          if (Form1.ACK_Flag6)
          {
            Form1.WDT_Finish = true;
            ++Form1.BOOT_Task_Data_i;
            this.prog12._setProgress((int) Form1.BOOT_Task_Data_i);
            this.listViewNF5.Items.Add("接收到ACK应答!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.listViewNF5.Items.Add("----------------------------------------------------------------");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            Form1.ACK_Flag6 = false;
            ++Form1.BOOT_Status;
          }
          if (Form1.NoACK_Flag6)
          {
            Form1.WDT_Finish = true;
            this.listViewNF5.Items.Add("接收到NO ACK应答!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.listViewNF5.Items.Add("BOOT升级失败!");
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Red;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
            this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
            this.myToolBar1.Enabled = true;
            this.qqTextBox31.Enabled = true;
            this.qqTextBox32.Enabled = true;
            this.qqTextBox33.Enabled = true;
            this.qqTextBox49.Enabled = true;
            this.qqTextBox50.Enabled = true;
            this.dS按钮9.Enabled = true;
            this.qqTextBox30.Enabled = true;
            this.dS按钮11.贴图 = Resources.灯8;
            this.dS按钮11.Enabled = true;
            this.dS按钮10.贴图 = Resources.按钮3;
            this.dS按钮10.Enabled = true;
            Form1.NoACK_Flag6 = false;
            Form1.WDT_Finish_break = true;
            break;
          }
          break;
        case 18:
          Form1.WDT_Finish_break = true;
          Form1.Rur_Mode = 0;
          this.myToolBar1.Enabled = true;
          this.qqTextBox31.Enabled = true;
          this.qqTextBox32.Enabled = true;
          this.qqTextBox33.Enabled = true;
          this.qqTextBox49.Enabled = true;
          this.qqTextBox50.Enabled = true;
          this.dS按钮9.Enabled = true;
          this.qqTextBox30.Enabled = true;
          this.dS按钮10.Enabled = true;
          this.dS按钮10.贴图 = Resources.按钮3;
          this.dS按钮11.Enabled = true;
          this.dS按钮11.贴图 = Resources.灯7;
          this.listViewNF5.Items.Add("BOOT升级成功！");
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Green;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
          Form1.End_dt = DateTime.Now;
          Form1.Between_dt = Form1.End_dt - Form1.Start_dt;
          Form1.Timespan = "本次BOOT升级耗时：";
          Form1.Timespan = $"{Form1.Timespan}{Form1.Between_dt.Minutes.ToString()}分钟 : ";
          Form1.Timespan = $"{Form1.Timespan}{Form1.Between_dt.Seconds.ToString()}秒 : ";
          Form1.Timespan = $"{Form1.Timespan}{Form1.Between_dt.Milliseconds.ToString()}毫秒";
          this.listViewNF5.Items.Add(Form1.Timespan);
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].ForeColor = Color.Green;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = true;
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].EnsureVisible();
          this.listViewNF5.Items[this.listViewNF5.Items.Count - 1].Selected = false;
          ++Form1.BOOT_Status;
          break;
      }
    }
  }

  private async void WDT_Thread() => await this.WDT_Thread_Task();

  private async Task WDT_Thread_Task()
  {
    int WDT_Thread_i = 0;
    await Task.Run((Action) (() =>
    {
      try
      {
        do
        {
          Thread.Sleep(100);
          if (WDT_Thread_i >= 80 /*0x50*/)
          {
            WDT_Thread_i = 0;
            Form1.WDT_Finish = true;
          }
          else
            ++WDT_Thread_i;
        }
        while (!Form1.WDT_Finish);
      }
      catch
      {
        Form1.System_UART_RX_Rrror_flag = true;
      }
    }));
  }

  private async void Program_Thread() => await this.Program_Task();

  private async Task Program_Task()
  {
    int P_i = 0;
    await Task.Run((Action) (() =>
    {
      Form1.BOOT_Task_Data_i = 0U;
      Form1.ACK_Flag5 = false;
      Form1.NoACK_Flag5 = false;
      try
      {
        while (Form1.BOOT_Task_Data_i < this.BOOT_Data_i)
        {
          Buffer.BlockCopy((Array) Form1.BOOT_DATA, (int) Form1.BOOT_Task_Data_i * 16 /*0x10*/, (Array) Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          Thread.Sleep(Form1.BOOT_time_value);
          ++Form1.BOOT_Task_Data_i;
          Buffer.BlockCopy((Array) Form1.BOOT_DATA, (int) Form1.BOOT_Task_Data_i * 16 /*0x10*/, (Array) Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          Thread.Sleep(Form1.BOOT_time_value);
          ++Form1.BOOT_Task_Data_i;
          Buffer.BlockCopy((Array) Form1.BOOT_DATA, (int) Form1.BOOT_Task_Data_i * 16 /*0x10*/, (Array) Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          Thread.Sleep(Form1.BOOT_time_value);
          ++Form1.BOOT_Task_Data_i;
          Form1.Read_Slave_Data((byte) 63 /*0x3F*/, 8, "V2");
          this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
          P_i = 0;
          while (true)
          {
            if (!Form1.ACK_Flag5)
            {
              if (!Form1.NoACK_Flag5)
              {
                if (P_i < 8000)
                {
                  Thread.Sleep(1);
                  ++P_i;
                }
                else
                  goto label_6;
              }
              else
                goto label_9;
            }
            else
              break;
          }
          Form1.ACK_Flag5 = false;
          goto label_9;
label_6:
          P_i = 0;
          Form1.WDT_Finish = true;
label_9:
          if (Form1.NoACK_Flag5 || Form1.WDT_Finish)
            break;
        }
        if ((int) Form1.BOOT_Task_Data_i != (int) this.BOOT_Data_i)
          return;
        Form1.Program_Finish_flag = true;
      }
      catch
      {
        Form1.System_UART_RX_Rrror_flag = true;
      }
    }));
  }

  private void myButton3_Click(object sender, EventArgs e)
  {
    lock (Form1.locker)
    {
      this.listViewNF6.Items.Clear();
      this.listViewNF7.Items.Clear();
      Array.Clear((Array) Form1.Baud_Rate_Data, 0, Form1.Baud_Rate_Data.Length);
      Form1.RX_count = 0;
      Form1.RX_Save_count = 0;
      Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
      Form1.Baud_count = 0;
      Form1.Baud_Display_count = 0;
    }
  }

  private void myButton2_Click_1(object sender, EventArgs e)
  {
    if (this.listViewNF6.Items.Count == 0)
    {
      init_Configuration.Output_Message = "无数据可保存！";
      int num = (int) init_Configuration.PDF_Interface.ShowDialog();
    }
    else
    {
      this.progressBarEx1.Value = 0;
      this.progressBarEx1.Maximum = this.listViewNF6.Items.Count;
      this.progressBarEx1.Text = "0%";
      this.saveFileDialog5.Title = "另存为";
      this.saveFileDialog5.FileName = "Data for 1";
      this.saveFileDialog5.Filter = "CSV File(*.csv)|*.csv";
      this.saveFileDialog5.ShowHelp = false;
      this.saveFileDialog5.OverwritePrompt = true;
      this.saveFileDialog5.SupportMultiDottedExtensions = false;
      if (this.saveFileDialog5.ShowDialog() != DialogResult.OK)
        return;
      Form1.Save_FileName_str = this.saveFileDialog5.FileName;
      this.imageButton2.Enabled = false;
      this.imageButton4.Enabled = false;
      this.qqRadioButton3.Enabled = false;
      this.qqRadioButton4.Enabled = false;
      this.qqRadioButton5.Enabled = false;
      this.qqRadioButton6.Enabled = false;
      this.qqTextBox10.Enabled = false;
      this.qqTextBox17.Enabled = false;
      this.imageButton5.Enabled = false;
      this.imageButton6.Enabled = false;
      this.imageButton7.Enabled = false;
      this.imageButton8.Enabled = false;
      this.dS按钮1.Enabled = false;
      this.dS按钮2.Enabled = false;
      this.imageButton10.Enabled = false;
      this.dS按钮1.贴图 = Resources.运行8;
      this.dS按钮2.贴图 = Resources.停止8;
      ((Control) this.dataGridViewX2).Enabled = false;
      this.dS按钮3.Enabled = false;
      this.dS按钮4.Enabled = false;
      this.imageButton12.Enabled = false;
      this.dS按钮3.贴图 = Resources.运行8;
      this.dS按钮4.贴图 = Resources.停止8;
      this.qqCheckBox7.Enabled = false;
      this.qqCheckBox8.Enabled = false;
      this.qqCheckBox9.Enabled = false;
      this.qqCheckBox10.Enabled = false;
      this.qqCheckBox11.Enabled = false;
      this.qqCheckBox12.Enabled = false;
      this.qqCheckBox13.Enabled = false;
      this.qqCheckBox14.Enabled = false;
      this.qqCheckBox15.Enabled = false;
      this.qqCheckBox16.Enabled = false;
      this.qqCheckBox17.Enabled = false;
      this.qqCheckBox18.Enabled = false;
      this.qqTextBox18.Enabled = false;
      this.qqTextBox19.Enabled = false;
      this.qqTextBox20.Enabled = false;
      this.qqTextBox21.Enabled = false;
      this.qqTextBox22.Enabled = false;
      this.qqTextBox23.Enabled = false;
      this.qqTextBox24.Enabled = false;
      this.qqTextBox25.Enabled = false;
      this.qqTextBox26.Enabled = false;
      this.qqTextBox27.Enabled = false;
      this.qqTextBox28.Enabled = false;
      this.qqTextBox29.Enabled = false;
      this.qqRadioButton13.Enabled = false;
      this.qqRadioButton14.Enabled = false;
      this.imageButton14.Enabled = false;
      this.qqRadioButton11.Enabled = false;
      this.qqRadioButton12.Enabled = false;
      this.imageButton13.Enabled = false;
      this.dS按钮5.贴图 = Resources.运行8;
      this.dS按钮5.Enabled = false;
      this.dS按钮6.Enabled = false;
      this.dS按钮6.贴图 = Resources.停止8;
      this.myButton5.Enabled = false;
      this.myButton5.NormalImage = (Image) Resources.down;
      Form1.BOOT_ON_flag = false;
      this.dS按钮9.Enabled = false;
      this.dS按钮10.贴图 = Resources.按钮3;
      this.dS按钮11.贴图 = Resources.灯6;
      this.dS按钮10.Enabled = false;
      this.dS按钮11.Enabled = false;
      this.imageButton15.Enabled = false;
      this.imageButton16.Enabled = true;
      this.imageButton17.Enabled = false;
      this.dS按钮13.Enabled = false;
      this.dS按钮13.贴图 = Resources.运行9;
      this.myButton1.Enabled = false;
      this.dS按钮15.Enabled = false;
      this.dS按钮15.贴图 = Resources.运行9;
      this.dS按钮14.Enabled = false;
      this.dS按钮14.贴图 = Resources.停止8;
      this.myButton3.Enabled = false;
      this.myButton2.Enabled = false;
      this.dS按钮17.Enabled = false;
      this.dS按钮16.Enabled = false;
      this.dS按钮17.贴图 = Resources.运行9;
      this.dS按钮16.贴图 = Resources.停止9;
      Form1.Save6_ProgressBar_i = 0;
      Form1.Save6_Finish_flag = false;
      Form1.Exit_Save_listViewNF6_flag = false;
      this.Save_listViewNF6_Thread = new Thread(new ThreadStart(this.Save_listViewNF6_Data));
      this.Save_listViewNF6_Thread.IsBackground = true;
      this.Save_listViewNF6_Thread.Start();
      this.Save_listViewNF6_Asynchronous();
    }
  }

  private void dS按钮17_ButtonClick(object Sender)
  {
    lock (Form1.locker)
    {
      this.listViewNF6.Items.Clear();
      this.listViewNF7.Items.Clear();
      Array.Clear((Array) Form1.Baud_Rate_Data, 0, Form1.Baud_Rate_Data.Length);
      Form1.RX_count = 0;
      Form1.RX_Save_count = 0;
      Array.Clear((Array) Form1.RX_buffer_Data, 0, Form1.RX_buffer_Data.Length);
      Form1.Baud_count = 0;
      Form1.Baud_Display_count = 0;
    }
    this.imageButton2.Enabled = false;
    this.imageButton4.Enabled = false;
    this.qqRadioButton3.Enabled = false;
    this.qqRadioButton4.Enabled = false;
    this.qqRadioButton5.Enabled = false;
    this.qqRadioButton6.Enabled = false;
    this.qqTextBox10.Enabled = false;
    this.qqTextBox17.Enabled = false;
    this.imageButton5.Enabled = false;
    this.imageButton6.Enabled = false;
    this.imageButton7.Enabled = false;
    this.imageButton8.Enabled = false;
    this.dS按钮1.Enabled = false;
    this.dS按钮2.Enabled = false;
    this.imageButton10.Enabled = false;
    this.dS按钮1.贴图 = Resources.运行8;
    this.dS按钮2.贴图 = Resources.停止8;
    ((Control) this.dataGridViewX2).Enabled = false;
    this.dS按钮3.Enabled = false;
    this.dS按钮4.Enabled = false;
    this.imageButton12.Enabled = false;
    this.dS按钮3.贴图 = Resources.运行8;
    this.dS按钮4.贴图 = Resources.停止8;
    this.qqCheckBox7.Enabled = false;
    this.qqCheckBox8.Enabled = false;
    this.qqCheckBox9.Enabled = false;
    this.qqCheckBox10.Enabled = false;
    this.qqCheckBox11.Enabled = false;
    this.qqCheckBox12.Enabled = false;
    this.qqCheckBox13.Enabled = false;
    this.qqCheckBox14.Enabled = false;
    this.qqCheckBox15.Enabled = false;
    this.qqCheckBox16.Enabled = false;
    this.qqCheckBox17.Enabled = false;
    this.qqCheckBox18.Enabled = false;
    this.qqTextBox18.Enabled = false;
    this.qqTextBox19.Enabled = false;
    this.qqTextBox20.Enabled = false;
    this.qqTextBox21.Enabled = false;
    this.qqTextBox22.Enabled = false;
    this.qqTextBox23.Enabled = false;
    this.qqTextBox24.Enabled = false;
    this.qqTextBox25.Enabled = false;
    this.qqTextBox26.Enabled = false;
    this.qqTextBox27.Enabled = false;
    this.qqTextBox28.Enabled = false;
    this.qqTextBox29.Enabled = false;
    this.imageButton14.Enabled = false;
    this.qqRadioButton11.Enabled = false;
    this.qqRadioButton12.Enabled = false;
    this.qqRadioButton13.Enabled = false;
    this.qqRadioButton14.Enabled = false;
    this.dS按钮5.Enabled = false;
    this.dS按钮6.Enabled = false;
    this.myButton5.Enabled = false;
    this.myButton5.NormalImage = (Image) Resources.down;
    Form1.BOOT_ON_flag = false;
    this.dS按钮9.Enabled = false;
    this.dS按钮10.贴图 = Resources.按钮3;
    this.dS按钮11.贴图 = Resources.灯6;
    this.dS按钮10.Enabled = false;
    this.dS按钮11.Enabled = false;
    this.imageButton15.Enabled = false;
    this.imageButton16.Enabled = true;
    this.imageButton17.Enabled = false;
    this.dS按钮13.Enabled = false;
    this.dS按钮13.贴图 = Resources.运行9;
    this.myButton1.Enabled = false;
    this.dS按钮15.Enabled = false;
    this.dS按钮15.贴图 = Resources.运行9;
    this.dS按钮14.Enabled = false;
    this.dS按钮14.贴图 = Resources.停止8;
    this.myButton3.Enabled = true;
    this.myButton2.Enabled = false;
    this.dS按钮17.Enabled = false;
    this.dS按钮16.Enabled = true;
    this.dS按钮17.贴图 = Resources.运行9;
    this.dS按钮16.贴图 = Resources.停止8;
    if (Form1.Rur_Mode != 0)
    {
      Form1.Rur_Mode = 0;
      Form1.Send_Mode_Command(Form1.Rur_Mode, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
      if (this.serialPort1.IsOpen)
        this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
      Thread.Sleep(200);
    }
    Form1.Rur_Mode = 5;
    Form1.Send_Mode_Command(5, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
    if (!this.serialPort1.IsOpen)
      return;
    this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
  }

  private void dS按钮16_ButtonClick(object Sender)
  {
    Form1.Rur_Mode = 0;
    Form1.Send_Mode_Command(0, Form1.Baud_rate, Form1.Volume_value, Form1.Line_time);
    if (this.serialPort1.IsOpen)
      this.serialPort1.Write(Form1.Send_Frame_Data, 0, 16 /*0x10*/);
    this.imageButton2.Enabled = true;
    this.imageButton4.Enabled = true;
    this.qqRadioButton3.Enabled = true;
    this.qqRadioButton4.Enabled = true;
    this.qqRadioButton5.Enabled = true;
    this.qqRadioButton6.Enabled = true;
    this.qqTextBox10.Enabled = true;
    this.qqTextBox17.Enabled = true;
    this.imageButton5.Enabled = true;
    this.imageButton6.Enabled = false;
    this.imageButton7.Enabled = true;
    this.imageButton8.Enabled = false;
    this.dS按钮1.Enabled = true;
    this.dS按钮2.Enabled = false;
    this.imageButton10.Enabled = true;
    this.dS按钮1.贴图 = Resources.运行8;
    this.dS按钮2.贴图 = Resources.停止8;
    ((Control) this.dataGridViewX2).Enabled = true;
    this.dS按钮3.Enabled = true;
    this.dS按钮4.Enabled = false;
    this.imageButton12.Enabled = true;
    this.dS按钮3.贴图 = Resources.运行8;
    this.dS按钮4.贴图 = Resources.停止8;
    this.dS按钮6.贴图 = Resources.停止8;
    this.qqCheckBox7.Enabled = true;
    this.qqCheckBox8.Enabled = true;
    this.qqCheckBox9.Enabled = true;
    this.qqCheckBox10.Enabled = true;
    this.qqCheckBox11.Enabled = true;
    this.qqCheckBox12.Enabled = true;
    this.qqCheckBox13.Enabled = true;
    this.qqCheckBox14.Enabled = true;
    this.qqCheckBox15.Enabled = true;
    this.qqCheckBox16.Enabled = true;
    this.qqCheckBox17.Enabled = true;
    this.qqCheckBox18.Enabled = true;
    this.qqTextBox18.Enabled = true;
    this.qqTextBox19.Enabled = true;
    this.qqTextBox20.Enabled = true;
    this.qqTextBox21.Enabled = true;
    this.qqTextBox22.Enabled = true;
    this.qqTextBox23.Enabled = true;
    this.qqTextBox24.Enabled = true;
    this.qqTextBox25.Enabled = true;
    this.qqTextBox26.Enabled = true;
    this.qqTextBox27.Enabled = true;
    this.qqTextBox28.Enabled = true;
    this.qqTextBox29.Enabled = true;
    this.imageButton14.Enabled = true;
    this.qqRadioButton11.Enabled = true;
    this.qqRadioButton12.Enabled = true;
    this.qqRadioButton13.Enabled = true;
    this.qqRadioButton14.Enabled = true;
    this.dS按钮5.Enabled = true;
    this.dS按钮6.Enabled = false;
    this.dS按钮5.贴图 = Resources.运行8;
    this.myButton5.Enabled = true;
    this.myButton5.NormalImage = (Image) Resources.btn_green_normal;
    Form1.BOOT_ON_flag = false;
    this.dS按钮9.Enabled = true;
    this.dS按钮10.贴图 = Resources.按钮3;
    this.dS按钮11.贴图 = Resources.灯6;
    this.dS按钮10.Enabled = true;
    this.dS按钮11.Enabled = true;
    this.imageButton15.Enabled = true;
    this.imageButton16.Enabled = true;
    this.imageButton17.Enabled = true;
    this.dS按钮13.Enabled = false;
    this.dS按钮13.贴图 = Resources.运行9;
    this.myButton1.Enabled = true;
    this.dS按钮15.Enabled = true;
    this.dS按钮15.贴图 = Resources.运行8;
    this.dS按钮14.Enabled = false;
    this.dS按钮14.贴图 = Resources.停止9;
    this.myButton3.Enabled = true;
    this.myButton2.Enabled = true;
    this.dS按钮17.Enabled = true;
    this.dS按钮16.Enabled = false;
    this.dS按钮17.贴图 = Resources.运行8;
    this.dS按钮16.贴图 = Resources.停止9;
  }

  public static void Baud_Async_Task()
  {
    if (Form1.Receive_Frame_Data[0] != (byte) 221)
      return;
    lock (Form1.locker)
    {
      Buffer.BlockCopy((Array) Form1.Receive_Frame_Data, 0, (Array) Form1.Baud_Rate_Data, Form1.Baud_count * 16 /*0x10*/, 16 /*0x10*/);
      Form1.Baud_static_value = 0U;
      Form1.Baud_static_value = (uint) Form1.Baud_Rate_Data[Form1.Baud_Display_count, 2];
      Form1.Baud_static_value = Form1.Baud_static_value << 8 | (uint) Form1.Baud_Rate_Data[Form1.Baud_Display_count, 3];
      Form1.Positive_static_Pulse = 0U;
      Form1.Positive_static_Pulse = (uint) Form1.Baud_Rate_Data[Form1.Baud_Display_count, 4];
      Form1.Positive_static_Pulse = Form1.Positive_static_Pulse << 8 | (uint) Form1.Baud_Rate_Data[Form1.Baud_Display_count, 5];
      Form1.Negative_static_Pulse = 0U;
      Form1.Negative_static_Pulse = (uint) Form1.Baud_Rate_Data[Form1.Baud_Display_count, 6];
      Form1.Negative_static_Pulse = Form1.Negative_static_Pulse << 8 | (uint) Form1.Baud_Rate_Data[Form1.Baud_Display_count, 7];
      ++Form1.Baud_count;
      if (Form1.Baud_count >= (int) ushort.MaxValue)
        Form1.Baud_count = 0;
    }
  }

  public void Baud_Sync_Task()
  {
    lock (Form1.locker)
    {
      if (Form1.Baud_Display_count == Form1.Baud_count)
        return;
      Form1.Baud_value = 0U;
      Form1.Baud_value = (uint) Form1.Baud_Rate_Data[Form1.Baud_Display_count, 2];
      Form1.Baud_value = Form1.Baud_value << 8 | (uint) Form1.Baud_Rate_Data[Form1.Baud_Display_count, 3];
      Form1.Positive_Pulse = 0U;
      Form1.Positive_Pulse = (uint) Form1.Baud_Rate_Data[Form1.Baud_Display_count, 4];
      Form1.Positive_Pulse = Form1.Positive_Pulse << 8 | (uint) Form1.Baud_Rate_Data[Form1.Baud_Display_count, 5];
      Form1.Negative_Pulse = 0U;
      Form1.Negative_Pulse = (uint) Form1.Baud_Rate_Data[Form1.Baud_Display_count, 6];
      Form1.Negative_Pulse = Form1.Negative_Pulse << 8 | (uint) Form1.Baud_Rate_Data[Form1.Baud_Display_count, 7];
      this.listViewNF6.Items.Add(Form1.Baud_Display_count.ToString());
      this.listViewNF6.Items[Form1.Baud_Display_count].SubItems.Add(Form1.Baud_value.ToString());
      this.listViewNF6.Items[Form1.Baud_Display_count].SubItems.Add(Form1.Positive_Pulse.ToString());
      this.listViewNF6.Items[Form1.Baud_Display_count].SubItems.Add(Form1.Negative_Pulse.ToString());
      this.listViewNF6.Items[Form1.Baud_Display_count].Selected = true;
      this.listViewNF6.Items[Form1.Baud_Display_count].EnsureVisible();
      if (this.listViewNF7.Items.Count == 0)
      {
        this.listViewNF7.Items.Add("0");
        this.listViewNF7.Items[0].SubItems.Add(Form1.Baud_static_value.ToString());
        this.listViewNF7.Items[0].SubItems.Add(Form1.Positive_static_Pulse.ToString());
        this.listViewNF7.Items[0].SubItems.Add(Form1.Negative_static_Pulse.ToString());
      }
      else
      {
        this.listViewNF7.Items[0].SubItems[0].Text = "0";
        this.listViewNF7.Items[0].SubItems[1].Text = Form1.Baud_static_value.ToString();
        this.listViewNF7.Items[0].SubItems[2].Text = Form1.Positive_static_Pulse.ToString();
        this.listViewNF7.Items[0].SubItems[3].Text = Form1.Negative_static_Pulse.ToString();
      }
      ++Form1.Baud_Display_count;
      if (Form1.Baud_Display_count >= (int) ushort.MaxValue)
      {
        lock (Form1.locker)
        {
          this.listViewNF6.Items.Clear();
          Form1.Baud_Display_count = 0;
        }
      }
    }
  }

  private async void Save_listViewNF6_Asynchronous()
  {
    await Form1.Save_listViewNF6_Asynchronous_Task();
  }

  private static async Task Save_listViewNF6_Asynchronous_Task()
  {
    int Save6_Task_i = 0;
    string Save_Task_str = "";
    await Task.Run((Action) (() =>
    {
      FileInfo fileInfo = new FileInfo(Form1.Save_FileName_str);
      FileStream fileStream = new FileStream(Form1.Save_FileName_str, FileMode.Create, FileAccess.Write);
      StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.UTF8);
      Save_Task_str = "";
      Save_Task_str = "序号,波特率(bps),正脉冲宽度,负脉冲宽度";
      streamWriter.WriteLine(Save_Task_str);
      do
      {
        Form1.Baud_value = 0U;
        Form1.Baud_value = (uint) Form1.Baud_Rate_Data[Save6_Task_i, 2];
        Form1.Baud_value = Form1.Baud_value << 8 | (uint) Form1.Baud_Rate_Data[Save6_Task_i, 3];
        Form1.Positive_Pulse = 0U;
        Form1.Positive_Pulse = (uint) Form1.Baud_Rate_Data[Save6_Task_i, 4];
        Form1.Positive_Pulse = Form1.Positive_Pulse << 8 | (uint) Form1.Baud_Rate_Data[Save6_Task_i, 5];
        Form1.Negative_Pulse = 0U;
        Form1.Negative_Pulse = (uint) Form1.Baud_Rate_Data[Save6_Task_i, 6];
        Form1.Negative_Pulse = Form1.Negative_Pulse << 8 | (uint) Form1.Baud_Rate_Data[Save6_Task_i, 7];
        Save_Task_str = "";
        Save_Task_str = $"{Save6_Task_i.ToString()},{Form1.Baud_value.ToString()},{Form1.Positive_Pulse.ToString()},{Form1.Negative_Pulse.ToString()}";
        streamWriter.WriteLine(Save_Task_str);
        ++Save6_Task_i;
        Form1.Save6_ProgressBar_i = Save6_Task_i;
        Thread.Sleep(1);
      }
      while (Save6_Task_i < Form1.Baud_count);
      streamWriter.Close();
      fileStream.Close();
      Form1.Save6_Finish_flag = true;
    }));
  }

  public void Save_listViewNF6_Data()
  {
    do
    {
      this.Save_listViewNF6_Data_Task();
      Thread.Sleep(100);
    }
    while (!Form1.Exit_Save_listViewNF6_flag);
    Form1.Exit_Save_listViewNF6_flag = false;
    this.Save_listViewNF6_Thread.Abort();
  }

  public void Save_listViewNF6_Data_Task()
  {
    if (this.InvokeRequired)
    {
      this.Invoke((Delegate) new Form1.Save_listViewNF6_Agency(this.Save_listViewNF6_Data_Task), new object[0]);
    }
    else
    {
      if (this.progressBarEx1.Value <= this.progressBarEx1.Maximum)
      {
        this.progressBarEx1.Value = Form1.Save6_ProgressBar_i;
        this.progressBarEx1.Text = (Form1.Save6_ProgressBar_i * 100 / this.progressBarEx1.Maximum).ToString() + "%";
      }
      if (Form1.Save6_Finish_flag)
      {
        Form1.Save6_Finish_flag = false;
        Form1.Exit_Save_listViewNF6_flag = true;
        this.imageButton2.Enabled = true;
        this.imageButton4.Enabled = true;
        this.qqRadioButton3.Enabled = true;
        this.qqRadioButton4.Enabled = true;
        this.qqRadioButton5.Enabled = true;
        this.qqRadioButton6.Enabled = true;
        this.qqTextBox10.Enabled = true;
        this.qqTextBox17.Enabled = true;
        this.imageButton5.Enabled = true;
        this.imageButton6.Enabled = false;
        this.imageButton7.Enabled = true;
        this.imageButton8.Enabled = false;
        this.dS按钮1.Enabled = true;
        this.dS按钮2.Enabled = false;
        this.imageButton10.Enabled = true;
        this.dS按钮1.贴图 = Resources.运行8;
        this.dS按钮2.贴图 = Resources.停止8;
        ((Control) this.dataGridViewX2).Enabled = true;
        this.dS按钮3.Enabled = true;
        this.dS按钮4.Enabled = false;
        this.imageButton12.Enabled = true;
        this.dS按钮3.贴图 = Resources.运行8;
        this.dS按钮4.贴图 = Resources.停止8;
        this.qqCheckBox7.Enabled = true;
        this.qqCheckBox8.Enabled = true;
        this.qqCheckBox9.Enabled = true;
        this.qqCheckBox10.Enabled = true;
        this.qqCheckBox11.Enabled = true;
        this.qqCheckBox12.Enabled = true;
        this.qqCheckBox13.Enabled = true;
        this.qqCheckBox14.Enabled = true;
        this.qqCheckBox15.Enabled = true;
        this.qqCheckBox16.Enabled = true;
        this.qqCheckBox17.Enabled = true;
        this.qqCheckBox18.Enabled = true;
        this.qqTextBox18.Enabled = true;
        this.qqTextBox19.Enabled = true;
        this.qqTextBox20.Enabled = true;
        this.qqTextBox21.Enabled = true;
        this.qqTextBox22.Enabled = true;
        this.qqTextBox23.Enabled = true;
        this.qqTextBox24.Enabled = true;
        this.qqTextBox25.Enabled = true;
        this.qqTextBox26.Enabled = true;
        this.qqTextBox27.Enabled = true;
        this.qqTextBox28.Enabled = true;
        this.qqTextBox29.Enabled = true;
        this.qqRadioButton13.Enabled = true;
        this.qqRadioButton14.Enabled = true;
        this.imageButton13.Enabled = true;
        this.imageButton14.Enabled = true;
        this.qqRadioButton11.Enabled = true;
        this.qqRadioButton12.Enabled = true;
        this.dS按钮5.Enabled = true;
        this.dS按钮6.贴图 = Resources.停止8;
        this.dS按钮6.Enabled = false;
        this.dS按钮5.贴图 = Resources.运行8;
        this.myButton5.Enabled = true;
        this.myButton5.NormalImage = (Image) Resources.btn_green_normal;
        Form1.BOOT_ON_flag = false;
        this.dS按钮9.Enabled = true;
        this.dS按钮10.贴图 = Resources.按钮3;
        this.dS按钮11.贴图 = Resources.灯6;
        this.dS按钮10.Enabled = true;
        this.dS按钮11.Enabled = true;
        this.imageButton15.Enabled = true;
        this.imageButton16.Enabled = true;
        this.imageButton17.Enabled = true;
        this.dS按钮13.Enabled = false;
        this.dS按钮13.贴图 = Resources.运行9;
        this.myButton1.Enabled = true;
        this.dS按钮15.Enabled = true;
        this.dS按钮15.贴图 = Resources.运行8;
        this.dS按钮14.Enabled = false;
        this.dS按钮14.贴图 = Resources.停止9;
        if (this.serialPort1.IsOpen)
        {
          this.myButton3.Enabled = true;
          this.myButton2.Enabled = true;
          this.dS按钮17.Enabled = true;
          this.dS按钮16.Enabled = false;
          this.dS按钮17.贴图 = Resources.运行8;
          this.dS按钮16.贴图 = Resources.停止9;
        }
        else
        {
          this.myButton3.Enabled = true;
          this.myButton2.Enabled = true;
          this.dS按钮17.Enabled = false;
          this.dS按钮16.Enabled = false;
          this.dS按钮17.贴图 = Resources.运行9;
          this.dS按钮16.贴图 = Resources.停止9;
        }
      }
    }
  }

  private string Read_LIN_version()
  {
    string str1 = "";
    for (uint index = 0; index < Form1.LDF_number; ++index)
    {
      str1 = Form1.LDF_str[(int) index, 0];
      if (str1 != "")
      {
        string str2 = str1.Substring(0, 1);
        if (str2 != "/" && str2 != "*" && str2 != " " && str1.Substring(0, 20) == "LIN_protocol_version")
        {
          str1 = str1.Substring(24, 3);
          break;
        }
      }
    }
    return str1;
  }

  private int Read_LIN_speed()
  {
    string str1 = "";
    for (int index = 0; (long) index < (long) Form1.LDF_number; ++index)
    {
      str1 = Form1.LDF_str[index, 0];
      if (str1 != "")
      {
        string str2 = str1.Substring(0, 1);
        if (str2 != "/" && str2 != "*" && str2 != " " && str1.Substring(0, 9) == "LIN_speed")
        {
          string str3 = str1;
          str1 = "";
          for (int startIndex = 11; startIndex < str3.Length - 1; ++startIndex)
          {
            string str4 = str3.Substring(startIndex, 1);
            if (!(str4 == "k"))
            {
              if (str4 != " ")
                str1 += str4;
            }
            else
              break;
          }
          break;
        }
      }
    }
    return (int) (Convert.ToDouble(str1) * 1000.0);
  }

  private void Read_Master_Nodes()
  {
    string str1 = "";
    Array.Clear((Array) Form1.Master_Nodes, 0, Form1.Master_Nodes.Length);
    Form1.Master_Nodes_number = 0U;
    for (uint index = 0; index < Form1.LDF_number; ++index)
    {
      string str2 = Form1.LDF_str[(int) index, 0];
      if (str2 != "")
      {
        string str3 = str2.Substring(0, 1);
        if (str3 != "/" && str3 != "*" && str3 != " " && str2.Substring(0, 5) == "Nodes")
        {
          string str4 = Form1.LDF_str[(int) index + 1, 0];
          for (int startIndex1 = 0; startIndex1 < str4.Length; ++startIndex1)
          {
            if (str4.Substring(startIndex1, 6) == "Master")
            {
              for (int startIndex2 = startIndex1 + 6; startIndex2 < str4.Length; ++startIndex2)
              {
                string str5 = str4.Substring(startIndex2, 1);
                if (str5 == ",")
                {
                  Form1.Master_Nodes[(int) Form1.Master_Nodes_number, 0] = str1;
                  ++Form1.Master_Nodes_number;
                  break;
                }
                if (str5 != " " && str5 != ":")
                  str1 += str5;
              }
              break;
            }
          }
          break;
        }
      }
    }
  }

  private void Read_Slaves_Nodes()
  {
    string str1 = "";
    Array.Clear((Array) Form1.Slaves_Nodes, 0, Form1.Slaves_Nodes.Length);
    Form1.Slaves_Nodes_number = 0U;
    for (uint index = 0; index < Form1.LDF_number; ++index)
    {
      string str2 = Form1.LDF_str[(int) index, 0];
      if (str2 != "")
      {
        string str3 = str2.Substring(0, 1);
        if (str3 != "/" && str3 != "*" && str3 != " " && str2.Substring(0, 5) == "Nodes")
        {
          string str4 = Form1.LDF_str[(int) index + 2, 0];
          for (int startIndex1 = 0; startIndex1 < str4.Length; ++startIndex1)
          {
            if (str4.Substring(startIndex1, 6) == "Slaves")
            {
              for (int startIndex2 = startIndex1 + 6; startIndex2 < str4.Length; ++startIndex2)
              {
                string str5 = str4.Substring(startIndex2, 1);
                if (str5 == ",")
                {
                  Form1.Slaves_Nodes[(int) Form1.Slaves_Nodes_number, 0] = str1;
                  ++Form1.Slaves_Nodes_number;
                  str1 = "";
                }
                if (str5 == ";")
                {
                  Form1.Slaves_Nodes[(int) Form1.Slaves_Nodes_number, 0] = str1;
                  ++Form1.Slaves_Nodes_number;
                  break;
                }
                if (str5 != " " && str5 != ":" && str5 != ",")
                  str1 += str5;
              }
              break;
            }
          }
          break;
        }
      }
    }
  }

  private void Read_Frames()
  {
    string str1 = "";
    string str2 = "";
    string Dec = "";
    string str3 = "";
    int num = 0;
    Array.Clear((Array) Form1.LDF_Frames, 0, Form1.LDF_Frames.Length);
    Form1.Frames_number = 0U;
    for (uint index = 0; index < Form1.LDF_number; ++index)
    {
      string str4 = Form1.LDF_str[(int) index, 0];
      if (str4 != "")
      {
        string str5 = str4.Substring(0, 1);
        if (str5 != "/" && str5 != "*" && str5 != " " && str5 != "}" && str5 != "\t" && str4.Substring(0, 6) == "Frames")
        {
          ++index;
          string str6 = Form1.LDF_str[(int) index, 0];
          while (true)
          {
            for (int startIndex1 = 0; startIndex1 < str6.Length; ++startIndex1)
            {
              string str7 = str6.Substring(startIndex1, 1);
              if (str7 == ":")
              {
                Form1.LDF_Frames[(int) Form1.Frames_number, 0] = Dec;
                Dec = "";
              }
              if (num == 0 && str7 == "," && str7 != Form1.Master_Nodes[0, 0])
              {
                if (Dec.Length == 4)
                {
                  Form1.LDF_Frames[(int) Form1.Frames_number, 1] = Dec;
                }
                else
                {
                  string str8 = "0x" + Form1.DECstr_to_HEXstr(Dec);
                  Form1.LDF_Frames[(int) Form1.Frames_number, 1] = str8;
                }
                num = 1;
                Dec = "";
                str7 = "";
              }
              if (num == 1 && str7 == "," && str7 == Form1.Master_Nodes[0, 0])
              {
                Form1.LDF_Frames[(int) Form1.Frames_number, 2] = Dec;
                num = 0;
                Dec = "";
              }
              else if (num == 1 && str7 == "," && str7 != Form1.Master_Nodes[0, 0])
              {
                Form1.LDF_Frames[(int) Form1.Frames_number, 2] = Dec;
                num = 0;
                Dec = "";
              }
              if (str7 == "{")
              {
                Form1.LDF_Frames[(int) Form1.Frames_number, 3] = Dec;
                ++index;
                string str9 = Form1.LDF_str[(int) index, 0];
                while (true)
                {
                  for (int startIndex2 = 0; startIndex2 < str9.Length; ++startIndex2)
                  {
                    str2 = str9.Substring(startIndex2, 1);
                    if (str2 == ",")
                    {
                      Form1.LDF_Frames[(int) Form1.Frames_number, 4] = str3;
                      str3 = "";
                    }
                    if (str2 == ";")
                    {
                      Form1.LDF_Frames[(int) Form1.Frames_number, 5] = str3;
                      Form1.LDF_Frames[(int) Form1.Frames_number + 1, 0] = Form1.LDF_Frames[(int) Form1.Frames_number, 0];
                      Form1.LDF_Frames[(int) Form1.Frames_number + 1, 1] = Form1.LDF_Frames[(int) Form1.Frames_number, 1];
                      Form1.LDF_Frames[(int) Form1.Frames_number + 1, 2] = Form1.LDF_Frames[(int) Form1.Frames_number, 2];
                      Form1.LDF_Frames[(int) Form1.Frames_number + 1, 3] = Form1.LDF_Frames[(int) Form1.Frames_number, 3];
                      str3 = "";
                      startIndex2 = -1;
                      ++Form1.Frames_number;
                      ++index;
                      str9 = Form1.LDF_str[(int) index, 0];
                    }
                    if (str2 != " " && str2 != ":" && str2 != "," && str2 != "{" && str2 != "}" && str2 != ";")
                    {
                      if (str2 == "\t")
                        str2 = "";
                      else
                        str3 += str2;
                    }
                    if (str2 == "}")
                    {
                      str3 = "";
                      break;
                    }
                  }
                  if (!(str2 == "}"))
                  {
                    ++index;
                    str9 = Form1.LDF_str[(int) index, 0];
                  }
                  else
                    break;
                }
                Form1.LDF_Frames[(int) Form1.Frames_number, 0] = "";
                Form1.LDF_Frames[(int) Form1.Frames_number, 1] = "";
                Form1.LDF_Frames[(int) Form1.Frames_number, 2] = "";
                Form1.LDF_Frames[(int) Form1.Frames_number, 3] = "";
                Dec = "";
                str6 = "";
                str2 = "";
                break;
              }
              if (str7 != " " && str7 != ":" && str7 != "," && str7 != "{" && str7 != "}")
              {
                if (str7 == "\t")
                  str1 = "";
                else
                  Dec += str7;
              }
            }
            if (!(str6 != "") || !(str6.Substring(0, 1) == "}"))
            {
              ++index;
              str6 = Form1.LDF_str[(int) index, 0];
            }
            else
              break;
          }
        }
      }
    }
  }

  private void Read_Signals()
  {
    string str1 = "";
    string HEX = "";
    string str2 = "";
    int num1 = 0;
    for (uint index1 = 0; index1 < Form1.LDF_number; ++index1)
    {
      string str3 = Form1.LDF_str[(int) index1, 0];
      if (str3 != "")
      {
        string str4 = str3.Substring(0, 1);
        if (str4 != "/" && str4 != "*" && str4 != " " && str4 != "}" && str4 != "\t" && str3.Substring(0, 7) == "Signals")
        {
          ++index1;
          string str5 = Form1.LDF_str[(int) index1, 0];
          while (true)
          {
            for (int startIndex = 0; startIndex < str5.Length; ++startIndex)
            {
              string str6 = str5.Substring(startIndex, 1);
              if (str6 == ":")
              {
                str2 = HEX;
                HEX = "";
              }
              if (num1 == 0 && str6 == ",")
              {
                for (int index2 = 0; (long) index2 < (long) Form1.Frames_number; ++index2)
                {
                  if (Form1.LDF_Frames[index2, 4] == str2)
                    Form1.LDF_Frames[index2, 6] = HEX;
                }
                num1 = 1;
                HEX = "";
                str6 = "";
              }
              if (num1 == 1 && str6 == ",")
              {
                for (int index3 = 0; (long) index3 < (long) Form1.Frames_number; ++index3)
                {
                  if (Form1.LDF_Frames[index3, 4] == str2)
                  {
                    int num2 = HEX.Length < 3 ? 0 : (HEX.Substring(0, 2) == "0x" | HEX.Substring(0, 2) == "0X" ? 1 : 0);
                    Form1.LDF_Frames[index3, 7] = num2 == 0 ? HEX : Form1.HEXstr_to_DEC(HEX).ToString();
                  }
                }
                num1 = 0;
                HEX = "";
                break;
              }
              if (str6 != " " && str6 != ":" && str6 != "," && str6 != "{" && str6 != "}")
              {
                if (str6 == "\t")
                  str1 = "";
                else
                  HEX += str6;
              }
            }
            if (!(str5 != "") || !(str5.Substring(0, 1) == "}"))
            {
              ++index1;
              str5 = Form1.LDF_str[(int) index1, 0];
            }
            else
              break;
          }
        }
      }
    }
  }

  private void Read_Signals_representation()
  {
    string str1 = "";
    string str2 = "";
    int num = 0;
    Array.Clear((Array) Form1.Signal_representation, 0, Form1.Signal_representation.Length);
    Form1.representation_number = 0U;
    for (uint index = 0; index < Form1.LDF_number; ++index)
    {
      string str3 = Form1.LDF_str[(int) index, 0];
      if (str3 != "")
      {
        string str4 = str3.Substring(0, 1);
        if (str4 != "/" && str4 != "*" && str4 != " " && str4 != "}" && str4 != "\t")
        {
          if (str3.Length >= 21)
            str4 = str3.Substring(0, 21);
          if (str4 == "Signal_representation")
          {
            ++index;
            string str5 = Form1.LDF_str[(int) index, 0];
            while (true)
            {
              for (int startIndex = 0; startIndex < str5.Length; ++startIndex)
              {
                string str6 = str5.Substring(startIndex, 1);
                if (str6 == ":")
                {
                  Form1.Signal_representation[(int) Form1.representation_number, 0] = str2;
                  str2 = "";
                }
                if (num == 0 && str6 == ",")
                {
                  Form1.Signal_representation[(int) Form1.representation_number, 1] = str2;
                  ++Form1.representation_number;
                  num = 1;
                  str2 = "";
                  str6 = "";
                }
                if (num == 1 && str6 == ",")
                {
                  Form1.Signal_representation[(int) Form1.representation_number, 0] = Form1.Signal_representation[(int) Form1.representation_number - 1, 0];
                  Form1.Signal_representation[(int) Form1.representation_number, 1] = str2;
                  ++Form1.representation_number;
                  str2 = "";
                }
                if (str6 == ";")
                {
                  if (num == 0)
                  {
                    Form1.Signal_representation[(int) Form1.representation_number, 1] = str2;
                    ++Form1.representation_number;
                  }
                  else
                  {
                    Form1.Signal_representation[(int) Form1.representation_number, 0] = Form1.Signal_representation[(int) Form1.representation_number - 1, 0];
                    Form1.Signal_representation[(int) Form1.representation_number, 1] = str2;
                    ++Form1.representation_number;
                  }
                  num = 0;
                  str2 = "";
                  break;
                }
                if (str6 != " " && str6 != ":" && str6 != "," && str6 != "{" && str6 != "}")
                {
                  if (str6 == "\t")
                    str1 = "";
                  else
                    str2 += str6;
                }
              }
              if (!(str5 != "") || !(str5.Substring(0, 1) == "}"))
              {
                ++index;
                str5 = Form1.LDF_str[(int) index, 0];
              }
              else
                break;
            }
          }
        }
      }
    }
  }

  private void Read_Signals_sencoding_types()
  {
    string str1 = "";
    string str2 = "";
    string str3 = "";
    string HEX = "";
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    Array.Clear((Array) Form1.Signal_encoding_types, 0, Form1.Signal_encoding_types.Length);
    Form1.ENC_types_number = 0U;
    for (uint index = 0; index < Form1.LDF_number; ++index)
    {
      string str4 = Form1.LDF_str[(int) index, 0];
      if (str4 != "")
      {
        string str5 = str4.Substring(0, 1);
        if (str5 != "/" && str5 != "*" && str5 != " " && str5 != "}" && str5 != "\t")
        {
          if (str4.Length >= 21)
            str5 = str4.Substring(0, 21);
          if (str5 == "Signal_encoding_types")
          {
            ++index;
            string str6 = Form1.LDF_str[(int) index, 0];
            while (true)
            {
              for (int startIndex1 = 0; startIndex1 < str6.Length; ++startIndex1)
              {
                string str7 = str6.Substring(startIndex1, 1);
                if (str7 == "{")
                {
                  Form1.Signal_encoding_types[(int) Form1.ENC_types_number, 0] = str3;
                  str3 = "";
                  ++index;
                  str6 = Form1.LDF_str[(int) index, 0];
                  while (true)
                  {
                    for (int startIndex2 = 0; startIndex2 < str6.Length; ++startIndex2)
                    {
                      str2 = str6.Substring(startIndex2, 1);
                      if (num1 == 0 && str2 == ",")
                      {
                        if (Form1.Signal_encoding_types[(int) Form1.ENC_types_number, 0] == null)
                          Form1.Signal_encoding_types[(int) Form1.ENC_types_number, 0] = Form1.Signal_encoding_types[(int) Form1.ENC_types_number - 1, 0];
                        Form1.Signal_encoding_types[(int) Form1.ENC_types_number, 1] = HEX;
                        switch (HEX)
                        {
                          case "physical_value":
                            num1 = 1;
                            break;
                          case "logical_value":
                            num1 = 2;
                            break;
                        }
                        num2 = 0;
                        HEX = "";
                      }
                      else if (num2 == 0 && num1 == 1 && str2 == ",")
                      {
                        Form1.Signal_encoding_types[(int) Form1.ENC_types_number, 2] = HEX;
                        num2 = 1;
                        HEX = "";
                      }
                      else if (num2 == 1 && num1 == 1 && str2 == ",")
                      {
                        Form1.Signal_encoding_types[(int) Form1.ENC_types_number, 3] = HEX;
                        num2 = 2;
                        HEX = "";
                      }
                      else if (num2 == 2 && num1 == 1 && str2 == ",")
                      {
                        Form1.Signal_encoding_types[(int) Form1.ENC_types_number, 4] = HEX;
                        num2 = 3;
                        HEX = "";
                      }
                      else if (num2 == 3 && num1 == 1 && str2 == ",")
                      {
                        Form1.Signal_encoding_types[(int) Form1.ENC_types_number, 5] = HEX;
                        num2 = 4;
                        HEX = "";
                      }
                      else
                      {
                        if (num2 == 4 && num1 == 1 && str2 == ";")
                        {
                          if (HEX.Length >= 3)
                            HEX = HEX.Substring(1, HEX.Length - 2);
                          Form1.Signal_encoding_types[(int) Form1.ENC_types_number, 6] = HEX;
                          ++Form1.ENC_types_number;
                          num2 = 0;
                          num1 = 0;
                          HEX = "";
                          num3 = 0;
                          break;
                        }
                        if (num2 == 0 && num1 == 2 && str2 == ",")
                        {
                          int num4 = HEX.Length < 3 ? 0 : (HEX.Substring(0, 2) == "0x" ? 1 : (HEX.Substring(0, 2) == "0X" ? 1 : 0));
                          Form1.Signal_encoding_types[(int) Form1.ENC_types_number, 2] = num4 == 0 ? HEX : Form1.HEXstr_to_DEC(HEX).ToString();
                          num2 = 1;
                          HEX = "";
                        }
                        else
                        {
                          if (num2 == 1 && num1 == 2 && str2 == ";")
                          {
                            if (HEX.Length >= 3)
                              HEX = HEX.Substring(1, HEX.Length - 2);
                            Form1.Signal_encoding_types[(int) Form1.ENC_types_number, 3] = HEX;
                            ++Form1.ENC_types_number;
                            num2 = 0;
                            num1 = 0;
                            num3 = 0;
                            HEX = "";
                            break;
                          }
                          if (num2 == 3 && num1 == 1 && str2 == ";")
                          {
                            Form1.Signal_encoding_types[(int) Form1.ENC_types_number, 5] = HEX;
                            Form1.Signal_encoding_types[(int) Form1.ENC_types_number, 6] = "";
                            ++Form1.ENC_types_number;
                            num2 = 0;
                            num1 = 0;
                            num3 = 0;
                            HEX = "";
                            break;
                          }
                          if (num2 == 0 && num1 == 2 && str2 == ";")
                          {
                            int num5 = HEX.Length < 3 ? 0 : (HEX.Substring(0, 2) == "0x" ? 1 : (HEX.Substring(0, 2) == "0X" ? 1 : 0));
                            Form1.Signal_encoding_types[(int) Form1.ENC_types_number, 2] = num5 == 0 ? HEX : Form1.HEXstr_to_DEC(HEX).ToString();
                            Form1.Signal_encoding_types[(int) Form1.ENC_types_number, 3] = "";
                            ++Form1.ENC_types_number;
                            num2 = 0;
                            num1 = 0;
                            num3 = 0;
                            HEX = "";
                            break;
                          }
                        }
                      }
                      if (str2 != " " && str2 != ":" && str2 != "," && str2 != "{" && str2 != "}" && str2 != ";")
                      {
                        if (str2 == "\t")
                        {
                          str2 = "";
                        }
                        else
                        {
                          HEX += str2;
                          if (str2 == "\"" && (num2 == 1 && num1 == 2 && HEX.Length != 1 || num2 == 4 && num1 == 1 && HEX.Length != 1))
                            num3 = 1;
                        }
                      }
                      else if (num3 == 0 && str2 != ":" && str2 != "," && str2 != "{" && str2 != "}" && str2 != ";")
                      {
                        if (str2 == "\t")
                          str2 = "";
                        else if (num2 == 1 && num1 == 2 && HEX.Length > 0)
                          HEX += str2;
                        else if (num2 == 4 && num1 == 1 && HEX.Length > 0)
                          HEX += str2;
                      }
                    }
                    if (!(str2 == "}"))
                    {
                      ++index;
                      str6 = Form1.LDF_str[(int) index, 0];
                    }
                    else
                      break;
                  }
                  HEX = "";
                  str2 = "";
                  break;
                }
                if (str7 != " " && str7 != ":" && str7 != "," && str7 != "{" && str7 != "}")
                {
                  if (str7 == "\t")
                    str1 = "";
                  else
                    str3 += str7;
                }
              }
              if (!(str6 != "") || !(str6.Substring(0, 1) == "}"))
              {
                ++index;
                str6 = Form1.LDF_str[(int) index, 0];
              }
              else
                break;
            }
          }
        }
      }
    }
  }

  private void Read_Schedule_tables()
  {
    string str1 = "";
    string str2 = "";
    string str3 = "";
    string str4 = "";
    int num1 = 0;
    int num2 = 0;
    Array.Clear((Array) Form1.Schedule_tables, 0, Form1.Schedule_tables.Length);
    Form1.Schedule_number = 0U;
    for (uint index1 = 0; index1 < Form1.LDF_number; ++index1)
    {
      string str5 = Form1.LDF_str[(int) index1, 0];
      if (str5 != "")
      {
        string str6 = str5.Substring(0, 1);
        if (str6 != "/" && str6 != "*" && str6 != " " && str6 != "}" && str6 != "\t")
        {
          if (str5.Length >= 15)
            str6 = str5.Substring(0, 15);
          if (str6 == "Schedule_tables")
          {
            ++index1;
            string str7 = Form1.LDF_str[(int) index1, 0];
            while (true)
            {
              for (int startIndex1 = 0; startIndex1 < str7.Length; ++startIndex1)
              {
                string str8 = str7.Substring(startIndex1, 1);
                if (str8 == "{")
                {
                  uint index2 = index1 + 1U;
                  string str9 = Form1.LDF_str[(int) index2, 0];
                  while (true)
                  {
                    for (int startIndex2 = 0; startIndex2 < str9.Length; ++startIndex2)
                    {
                      str2 = str9.Substring(startIndex2, 1);
                      if (num1 == 1 && str2 == " ")
                      {
                        Form1.Schedule_tables[(int) Form1.Schedule_number, 0] = str4;
                        num1 = 2;
                        str4 = "";
                      }
                      else if (num1 == 2 && str2 == " " && str4.Length > 0)
                      {
                        num1 = 3;
                        str4 = "";
                      }
                      else if (num1 == 3 && str2 == "." && str4.Length > 0)
                      {
                        Form1.Schedule_tables[(int) Form1.Schedule_number, 1] = str4;
                        Form1.Schedule_tables[(int) Form1.Schedule_number, 2] = "ms";
                        ++Form1.Schedule_number;
                        num1 = 0;
                        str4 = "";
                        break;
                      }
                      if (str2 != " " && str2 != ":" && str2 != "," && str2 != "{" && str2 != "}" && str2 != ";")
                      {
                        if (str2 == "\t")
                        {
                          str2 = "";
                        }
                        else
                        {
                          str4 += str2;
                          if (num1 == 0)
                            num1 = 1;
                        }
                      }
                    }
                    if (!(str2 == "}"))
                    {
                      ++index2;
                      str9 = Form1.LDF_str[(int) index2, 0];
                    }
                    else
                      break;
                  }
                  return;
                }
                if (str8 != " " && str8 != ":" && str8 != "," && str8 != "{" && str8 != "}")
                {
                  if (str8 == "\t")
                    str1 = "";
                  else
                    str3 += str8;
                }
              }
              if (!(str7 != "") || !(str7.Substring(0, 1) == "}"))
              {
                ++index1;
                str7 = Form1.LDF_str[(int) index1, 0];
              }
              else
                break;
            }
            num2 = 1;
          }
          if (num2 == 1)
            break;
        }
      }
    }
  }

  public void Matrix_Set(int sait, bool EN, string name, int Color_site)
  {
    if (sait >= 0 && sait <= 7)
    {
      switch (sait)
      {
        case 0:
          if (EN)
            this.uiButton0.Enabled = true;
          else
            this.uiButton0.Enabled = false;
          this.uiButton0.Text = name;
          this.uiButton0.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton0.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton0.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 1:
          if (EN)
            this.uiButton1.Enabled = true;
          else
            this.uiButton1.Enabled = false;
          this.uiButton1.Text = name;
          this.uiButton1.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton1.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton1.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 2:
          if (EN)
            this.uiButton2.Enabled = true;
          else
            this.uiButton2.Enabled = false;
          this.uiButton2.Text = name;
          this.uiButton2.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton2.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton2.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 3:
          if (EN)
            this.uiButton3.Enabled = true;
          else
            this.uiButton3.Enabled = false;
          this.uiButton3.Text = name;
          this.uiButton3.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton3.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton3.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 4:
          if (EN)
            this.uiButton4.Enabled = true;
          else
            this.uiButton4.Enabled = false;
          this.uiButton4.Text = name;
          this.uiButton4.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton4.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton4.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 5:
          if (EN)
            this.uiButton5.Enabled = true;
          else
            this.uiButton5.Enabled = false;
          this.uiButton5.Text = name;
          this.uiButton5.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton5.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton5.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 6:
          if (EN)
            this.uiButton6.Enabled = true;
          else
            this.uiButton6.Enabled = false;
          this.uiButton6.Text = name;
          this.uiButton6.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton6.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton6.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 7:
          if (EN)
            this.uiButton7.Enabled = true;
          else
            this.uiButton7.Enabled = false;
          this.uiButton7.Text = name;
          this.uiButton7.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton7.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton7.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
      }
    }
    else if (sait >= 8 && sait <= 15)
    {
      switch (sait)
      {
        case 8:
          if (EN)
            this.uiButton8.Enabled = true;
          else
            this.uiButton8.Enabled = false;
          this.uiButton8.Text = name;
          this.uiButton8.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton8.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton8.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 9:
          if (EN)
            this.uiButton9.Enabled = true;
          else
            this.uiButton9.Enabled = false;
          this.uiButton9.Text = name;
          this.uiButton9.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton9.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton9.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 10:
          if (EN)
            this.uiButton10.Enabled = true;
          else
            this.uiButton10.Enabled = false;
          this.uiButton10.Text = name;
          this.uiButton10.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton10.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton10.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 11:
          if (EN)
            this.uiButton11.Enabled = true;
          else
            this.uiButton11.Enabled = false;
          this.uiButton11.Text = name;
          this.uiButton11.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton11.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton11.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 12:
          if (EN)
            this.uiButton12.Enabled = true;
          else
            this.uiButton12.Enabled = false;
          this.uiButton12.Text = name;
          this.uiButton12.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton12.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton12.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 13:
          if (EN)
            this.uiButton13.Enabled = true;
          else
            this.uiButton13.Enabled = false;
          this.uiButton13.Text = name;
          this.uiButton13.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton13.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton13.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 14:
          if (EN)
            this.uiButton14.Enabled = true;
          else
            this.uiButton14.Enabled = false;
          this.uiButton14.Text = name;
          this.uiButton14.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton14.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton14.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 15:
          if (EN)
            this.uiButton15.Enabled = true;
          else
            this.uiButton15.Enabled = false;
          this.uiButton15.Text = name;
          this.uiButton15.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton15.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton15.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
      }
    }
    else if (sait >= 16 /*0x10*/ && sait <= 23)
    {
      switch (sait)
      {
        case 16 /*0x10*/:
          if (EN)
            this.uiButton16.Enabled = true;
          else
            this.uiButton16.Enabled = false;
          this.uiButton16.Text = name;
          this.uiButton16.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton16.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton16.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 17:
          if (EN)
            this.uiButton17.Enabled = true;
          else
            this.uiButton17.Enabled = false;
          this.uiButton17.Text = name;
          this.uiButton17.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton17.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton17.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 18:
          if (EN)
            this.uiButton18.Enabled = true;
          else
            this.uiButton18.Enabled = false;
          this.uiButton18.Text = name;
          this.uiButton18.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton18.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton18.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 19:
          if (EN)
            this.uiButton19.Enabled = true;
          else
            this.uiButton19.Enabled = false;
          this.uiButton19.Text = name;
          this.uiButton19.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton19.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton19.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 20:
          if (EN)
            this.uiButton20.Enabled = true;
          else
            this.uiButton20.Enabled = false;
          this.uiButton20.Text = name;
          this.uiButton20.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton20.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton20.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 21:
          if (EN)
            this.uiButton21.Enabled = true;
          else
            this.uiButton21.Enabled = false;
          this.uiButton21.Text = name;
          this.uiButton21.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton21.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton21.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 22:
          if (EN)
            this.uiButton22.Enabled = true;
          else
            this.uiButton22.Enabled = false;
          this.uiButton22.Text = name;
          this.uiButton22.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton22.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton22.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 23:
          if (EN)
            this.uiButton23.Enabled = true;
          else
            this.uiButton23.Enabled = false;
          this.uiButton23.Text = name;
          this.uiButton23.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton23.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton23.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
      }
    }
    else if (sait >= 24 && sait <= 31 /*0x1F*/)
    {
      switch (sait)
      {
        case 24:
          if (EN)
            this.uiButton24.Enabled = true;
          else
            this.uiButton24.Enabled = false;
          this.uiButton24.Text = name;
          this.uiButton24.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton24.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton24.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 25:
          if (EN)
            this.uiButton25.Enabled = true;
          else
            this.uiButton25.Enabled = false;
          this.uiButton25.Text = name;
          this.uiButton25.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton25.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton25.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 26:
          if (EN)
            this.uiButton26.Enabled = true;
          else
            this.uiButton26.Enabled = false;
          this.uiButton26.Text = name;
          this.uiButton26.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton26.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton26.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 27:
          if (EN)
            this.uiButton27.Enabled = true;
          else
            this.uiButton27.Enabled = false;
          this.uiButton27.Text = name;
          this.uiButton27.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton27.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton27.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 28:
          if (EN)
            this.uiButton28.Enabled = true;
          else
            this.uiButton28.Enabled = false;
          this.uiButton28.Text = name;
          this.uiButton28.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton28.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton28.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 29:
          if (EN)
            this.uiButton29.Enabled = true;
          else
            this.uiButton29.Enabled = false;
          this.uiButton29.Text = name;
          this.uiButton29.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton29.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton29.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 30:
          if (EN)
            this.uiButton30.Enabled = true;
          else
            this.uiButton30.Enabled = false;
          this.uiButton30.Text = name;
          this.uiButton30.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton30.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton30.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 31 /*0x1F*/:
          if (EN)
            this.uiButton31.Enabled = true;
          else
            this.uiButton31.Enabled = false;
          this.uiButton31.Text = name;
          this.uiButton31.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton31.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton31.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
      }
    }
    else if (sait >= 32 /*0x20*/ && sait <= 39)
    {
      switch (sait)
      {
        case 32 /*0x20*/:
          if (EN)
            this.uiButton32.Enabled = true;
          else
            this.uiButton32.Enabled = false;
          this.uiButton32.Text = name;
          this.uiButton32.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton32.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton32.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 33:
          if (EN)
            this.uiButton33.Enabled = true;
          else
            this.uiButton33.Enabled = false;
          this.uiButton33.Text = name;
          this.uiButton33.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton33.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton33.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 34:
          if (EN)
            this.uiButton34.Enabled = true;
          else
            this.uiButton34.Enabled = false;
          this.uiButton34.Text = name;
          this.uiButton34.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton34.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton34.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 35:
          if (EN)
            this.uiButton35.Enabled = true;
          else
            this.uiButton35.Enabled = false;
          this.uiButton35.Text = name;
          this.uiButton35.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton35.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton35.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 36:
          if (EN)
            this.uiButton36.Enabled = true;
          else
            this.uiButton36.Enabled = false;
          this.uiButton36.Text = name;
          this.uiButton36.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton36.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton36.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 37:
          if (EN)
            this.uiButton37.Enabled = true;
          else
            this.uiButton37.Enabled = false;
          this.uiButton37.Text = name;
          this.uiButton37.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton37.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton37.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 38:
          if (EN)
            this.uiButton38.Enabled = true;
          else
            this.uiButton38.Enabled = false;
          this.uiButton38.Text = name;
          this.uiButton38.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton38.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton38.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 39:
          if (EN)
            this.uiButton39.Enabled = true;
          else
            this.uiButton39.Enabled = false;
          this.uiButton39.Text = name;
          this.uiButton39.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton39.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton39.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
      }
    }
    else if (sait >= 40 && sait <= 47)
    {
      switch (sait)
      {
        case 40:
          if (EN)
            this.uiButton40.Enabled = true;
          else
            this.uiButton40.Enabled = false;
          this.uiButton40.Text = name;
          this.uiButton40.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton40.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton40.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 41:
          if (EN)
            this.uiButton41.Enabled = true;
          else
            this.uiButton41.Enabled = false;
          this.uiButton41.Text = name;
          this.uiButton41.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton41.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton41.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 42:
          if (EN)
            this.uiButton42.Enabled = true;
          else
            this.uiButton42.Enabled = false;
          this.uiButton42.Text = name;
          this.uiButton42.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton42.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton42.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 43:
          if (EN)
            this.uiButton43.Enabled = true;
          else
            this.uiButton43.Enabled = false;
          this.uiButton43.Text = name;
          this.uiButton43.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton43.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton43.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 44:
          if (EN)
            this.uiButton44.Enabled = true;
          else
            this.uiButton44.Enabled = false;
          this.uiButton44.Text = name;
          this.uiButton44.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton44.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton44.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 45:
          if (EN)
            this.uiButton45.Enabled = true;
          else
            this.uiButton45.Enabled = false;
          this.uiButton45.Text = name;
          this.uiButton45.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton45.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton45.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 46:
          if (EN)
            this.uiButton46.Enabled = true;
          else
            this.uiButton46.Enabled = false;
          this.uiButton46.Text = name;
          this.uiButton46.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton46.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton46.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 47:
          if (EN)
            this.uiButton47.Enabled = true;
          else
            this.uiButton47.Enabled = false;
          this.uiButton47.Text = name;
          this.uiButton47.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton47.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton47.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
      }
    }
    else if (sait >= 48 /*0x30*/ && sait <= 55)
    {
      switch (sait)
      {
        case 48 /*0x30*/:
          if (EN)
            this.uiButton48.Enabled = true;
          else
            this.uiButton48.Enabled = false;
          this.uiButton48.Text = name;
          this.uiButton48.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton48.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton48.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 49:
          if (EN)
            this.uiButton49.Enabled = true;
          else
            this.uiButton49.Enabled = false;
          this.uiButton49.Text = name;
          this.uiButton49.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton49.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton49.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 50:
          if (EN)
            this.uiButton50.Enabled = true;
          else
            this.uiButton50.Enabled = false;
          this.uiButton50.Text = name;
          this.uiButton50.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton50.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton50.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 51:
          if (EN)
            this.uiButton51.Enabled = true;
          else
            this.uiButton51.Enabled = false;
          this.uiButton51.Text = name;
          this.uiButton51.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton51.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton51.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 52:
          if (EN)
            this.uiButton52.Enabled = true;
          else
            this.uiButton52.Enabled = false;
          this.uiButton52.Text = name;
          this.uiButton52.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton52.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton52.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 53:
          if (EN)
            this.uiButton53.Enabled = true;
          else
            this.uiButton53.Enabled = false;
          this.uiButton53.Text = name;
          this.uiButton53.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton53.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton53.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 54:
          if (EN)
            this.uiButton54.Enabled = true;
          else
            this.uiButton54.Enabled = false;
          this.uiButton54.Text = name;
          this.uiButton54.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton54.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton54.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 55:
          if (EN)
            this.uiButton55.Enabled = true;
          else
            this.uiButton55.Enabled = false;
          this.uiButton55.Text = name;
          this.uiButton55.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton55.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton55.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
      }
    }
    else
    {
      if (sait < 56 || sait > 63 /*0x3F*/)
        return;
      switch (sait)
      {
        case 56:
          if (EN)
            this.uiButton56.Enabled = true;
          else
            this.uiButton56.Enabled = false;
          this.uiButton56.Text = name;
          this.uiButton56.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton56.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton56.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 57:
          if (EN)
            this.uiButton57.Enabled = true;
          else
            this.uiButton57.Enabled = false;
          this.uiButton57.Text = name;
          this.uiButton57.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton57.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton57.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 58:
          if (EN)
            this.uiButton58.Enabled = true;
          else
            this.uiButton58.Enabled = false;
          this.uiButton58.Text = name;
          this.uiButton58.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton58.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton58.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 59:
          if (EN)
            this.uiButton59.Enabled = true;
          else
            this.uiButton59.Enabled = false;
          this.uiButton59.Text = name;
          this.uiButton59.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton59.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton59.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 60:
          if (EN)
            this.uiButton60.Enabled = true;
          else
            this.uiButton60.Enabled = false;
          this.uiButton60.Text = name;
          this.uiButton60.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton60.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton60.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 61:
          if (EN)
            this.uiButton61.Enabled = true;
          else
            this.uiButton61.Enabled = false;
          this.uiButton61.Text = name;
          this.uiButton61.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton61.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton61.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 62:
          if (EN)
            this.uiButton62.Enabled = true;
          else
            this.uiButton62.Enabled = false;
          this.uiButton62.Text = name;
          this.uiButton62.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton62.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton62.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
        case 63 /*0x3F*/:
          if (EN)
            this.uiButton63.Enabled = true;
          else
            this.uiButton63.Enabled = false;
          this.uiButton63.Text = name;
          this.uiButton63.FillColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton63.FillHoverColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          this.uiButton63.FillPressColor = Color.FromArgb((int) Form1.Matrix_Color[Color_site, 0], (int) Form1.Matrix_Color[Color_site, 1], (int) Form1.Matrix_Color[Color_site, 2]);
          break;
      }
    }
  }

  public void Matrix_Clear()
  {
    for (int sait = 0; sait < 64 /*0x40*/; ++sait)
      this.Matrix_Set(sait, false, sait.ToString(), 0);
  }

  public void Matrix_Buffer_Set(int star, int end, bool EN, string name, int Color_site)
  {
    for (int sait = star; sait < end; ++sait)
      this.Matrix_Set(sait, true, name, Color_site);
  }

  private void myButton4_Click(object sender, EventArgs e)
  {
    int num1 = 0;
    this.uiTreeView1.Nodes.Clear();
    Array.Clear((Array) Form1.LDF_str, 0, Form1.LDF_str.Length);
    Form1.LDF_number = 0U;
    this.openFileDialog1.Filter = "LDF文件(*.ldf)|*.ldf";
    if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
      return;
    this.uiRichTextBox1.Text = "";
    StreamReader streamReader = new StreamReader(this.openFileDialog1.FileName, Encoding.Default);
    string str1;
    while ((str1 = streamReader.ReadLine()) != null)
    {
      Form1.LDF_str[(int) Form1.LDF_number, 0] = str1.ToString();
      ++Form1.LDF_number;
    }
    streamReader.Close();
    try
    {
      this.Read_Master_Nodes();
    }
    catch
    {
      init_Configuration.Output_Message = "读取主机名称失败！";
      int num2 = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    try
    {
      this.Read_Slaves_Nodes();
    }
    catch
    {
      init_Configuration.Output_Message = "读取从机名称失败！";
      int num3 = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    try
    {
      this.Read_Frames();
    }
    catch
    {
      init_Configuration.Output_Message = "读帧结构失败！";
      int num4 = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    try
    {
      this.Read_Signals();
    }
    catch
    {
      init_Configuration.Output_Message = "读变量的长度及初始值失败！";
      int num5 = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    try
    {
      this.Read_Schedule_tables();
    }
    catch
    {
      init_Configuration.Output_Message = "读取调度表失败！";
      int num6 = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    try
    {
      this.Read_Signals_representation();
    }
    catch
    {
      init_Configuration.Output_Message = "读取信号代表失败！";
      int num7 = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    try
    {
      this.Read_Signals_sencoding_types();
    }
    catch
    {
      init_Configuration.Output_Message = "读取信号编码类型失败！";
      int num8 = (int) init_Configuration.PDF_Interface.ShowDialog();
      return;
    }
    this.uiTreeView1.Nodes.Add("基本信息");
    this.uiTreeView1.Nodes.Add("节点名称");
    this.uiTreeView1.Nodes.Add("主机");
    this.uiTreeView1.Nodes.Add("从机");
    this.uiTreeView1.Nodes.Add("调度表");
    this.uiTreeView1.Nodes[0].Nodes.Add("LIN版本：" + this.Read_LIN_version());
    this.uiTreeView1.Nodes[0].Nodes.Add($"波特率：{this.Read_LIN_speed().ToString()} kbps");
    string str2 = "";
    for (int index = 0; (long) index < (long) Form1.Master_Nodes_number; ++index)
      this.uiTreeView1.Nodes[1].Nodes.Add(Form1.Master_Nodes[index, 0]);
    for (int index = 0; (long) index < (long) Form1.Slaves_Nodes_number; ++index)
      this.uiTreeView1.Nodes[1].Nodes.Add(Form1.Slaves_Nodes[index, 0]);
    for (int index1 = 0; (long) index1 < (long) Form1.Frames_number; ++index1)
    {
      for (int index2 = 0; (long) index2 < (long) Form1.Master_Nodes_number; ++index2)
      {
        if (Form1.LDF_Frames[index1, 2] == Form1.Master_Nodes[index2, 0])
        {
          string text = $"{Form1.LDF_Frames[index1, 0]} [{Form1.LDF_Frames[index1, 1]}]";
          if (num1 != 0)
          {
            if (this.uiTreeView1.Nodes[2].Nodes[num1 - 1].Text != text)
            {
              this.uiTreeView1.Nodes[2].Nodes.Add(text);
              ++num1;
            }
          }
          else
          {
            this.uiTreeView1.Nodes[2].Nodes.Add(text);
            ++num1;
          }
          str2 = "";
        }
      }
    }
    int num9 = 0;
    for (int index3 = 0; (long) index3 < (long) Form1.Frames_number; ++index3)
    {
      for (int index4 = 0; (long) index4 < (long) Form1.Slaves_Nodes_number; ++index4)
      {
        if (Form1.LDF_Frames[index3, 2] == Form1.Slaves_Nodes[index4, 0])
        {
          string text = $"{Form1.LDF_Frames[index3, 0]} [{Form1.LDF_Frames[index3, 1]}]";
          if (num9 != 0)
          {
            if (this.uiTreeView1.Nodes[3].Nodes[num9 - 1].Text != text)
            {
              this.uiTreeView1.Nodes[3].Nodes.Add(text);
              ++num9;
            }
          }
          else
          {
            this.uiTreeView1.Nodes[3].Nodes.Add(text);
            ++num9;
          }
          str2 = "";
        }
      }
    }
    for (int index = 0; (long) index < (long) Form1.Schedule_number; ++index)
    {
      this.uiTreeView1.Nodes[4].Nodes.Add($"{$"{str2}{Form1.Schedule_tables[index, 0]} "}{Form1.Schedule_tables[index, 1]} " + Form1.Schedule_tables[index, 2]);
      str2 = "";
    }
    this.Matrix_Clear();
    this.uiRichTextBox1.Text = "";
    this.listView1.Items.Clear();
  }

  private void uiTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
  {
    string str1 = "";
    if (e.Node.Text.Length <= 7)
      return;
    string text = e.Node.Text;
    string str2 = text.Substring(0, text.Length - 7);
    this.listView1.Items.Clear();
    Form1.SlistView_cnt = 0;
    this.Matrix_Clear();
    for (int index = 0; (long) index < (long) Form1.Frames_number; ++index)
    {
      if (Form1.SlistView_cnt == 0)
      {
        if (str2 == Form1.LDF_Frames[index, 0])
        {
          this.listView1.Items.Add("S" + Form1.SlistView_cnt.ToString());
          this.listView1.Items[Form1.SlistView_cnt].SubItems.Add(Form1.LDF_Frames[index, 4]);
          this.Matrix_Buffer_Set((int) Convert.ToByte(Form1.LDF_Frames[index, 5]), (int) Convert.ToByte(Form1.LDF_Frames[index, 5]) + (int) Convert.ToByte(Form1.LDF_Frames[index, 6]), true, "S" + Form1.SlistView_cnt.ToString(), Form1.SlistView_cnt);
          str1 = $"{str1}数据长度:{Form1.LDF_Frames[index, 3]}字节    ";
          ++Form1.SlistView_cnt;
        }
      }
      else if (str2 == Form1.LDF_Frames[index, 0] && Form1.LDF_Frames[index, 4] != this.listView1.Items[Form1.SlistView_cnt - 1].SubItems[1].Text)
      {
        this.listView1.Items.Add("S" + Form1.SlistView_cnt.ToString());
        this.listView1.Items[Form1.SlistView_cnt].SubItems.Add(Form1.LDF_Frames[index, 4]);
        this.Matrix_Buffer_Set((int) Convert.ToByte(Form1.LDF_Frames[index, 5]), (int) Convert.ToByte(Form1.LDF_Frames[index, 5]) + (int) Convert.ToByte(Form1.LDF_Frames[index, 6]), true, "S" + Form1.SlistView_cnt.ToString(), Form1.SlistView_cnt);
        ++Form1.SlistView_cnt;
      }
    }
    this.uiRichTextBox1.Text = $"{str1}信号长度：{Form1.SlistView_cnt.ToString()}";
  }

  private void listView1_MouseClick(object sender, MouseEventArgs e)
  {
    string str1 = "";
    string text = this.listView1.Items[this.listView1.SelectedItems[0].Index].SubItems[1].Text;
    string str2 = $"{str1}信号名：{text}\n";
    for (int index = 0; (long) index < (long) Form1.representation_number; ++index)
    {
      if (Form1.Signal_representation[index, 1] == text)
        text = Form1.Signal_representation[index, 0];
    }
    for (int index = 0; (long) index < (long) Form1.ENC_types_number; ++index)
    {
      if (Form1.Signal_encoding_types[index, 0] == text)
      {
        if (Form1.Signal_encoding_types[index, 1] == "physical_value")
          str2 = $"{str2}物理范围：{Form1.Signal_encoding_types[index, 2]}至{Form1.Signal_encoding_types[index, 3]}，精度：{Form1.Signal_encoding_types[index, 4]}，偏移量：{Form1.Signal_encoding_types[index, 5]}，单位：{Form1.Signal_encoding_types[index, 6]}\n";
        else if (Form1.Signal_encoding_types[index, 1] == "logical_value")
          str2 = $"{str2}逻辑值：{Form1.Signal_encoding_types[index, 2]}，逻辑名称：{Form1.Signal_encoding_types[index, 3]}\n";
      }
    }
    this.uiRichTextBox1.Text = "";
    this.uiRichTextBox1.Text = str2;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.components = (IContainer) new System.ComponentModel.Container();
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
    DS按钮.进度条 进度条1 = new DS按钮.进度条();
    DS按钮.进度条 进度条2 = new DS按钮.进度条();
    DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
    DS按钮.进度条 进度条3 = new DS按钮.进度条();
    DS按钮.进度条 进度条4 = new DS按钮.进度条();
    DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle10 = new DataGridViewCellStyle();
    DS按钮.进度条 进度条5 = new DS按钮.进度条();
    DS按钮.进度条 进度条6 = new DS按钮.进度条();
    DataGridViewCellStyle gridViewCellStyle11 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle12 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle13 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle14 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle15 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle16 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle17 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle18 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle19 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle20 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle21 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle22 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle23 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle24 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle25 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle26 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle27 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle28 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle29 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle30 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle31 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle32 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle33 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle34 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle35 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle36 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle37 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle38 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle39 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle40 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle41 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle42 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle43 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle44 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle45 = new DataGridViewCellStyle();
    DS按钮.进度条 进度条7 = new DS按钮.进度条();
    DS按钮.进度条 进度条8 = new DS按钮.进度条();
    DS按钮.进度条 进度条9 = new DS按钮.进度条();
    DS按钮.进度条 进度条10 = new DS按钮.进度条();
    DS按钮.进度条 进度条11 = new DS按钮.进度条();
    DS按钮.进度条 进度条12 = new DS按钮.进度条();
    DS按钮.进度条 进度条13 = new DS按钮.进度条();
    DS按钮.进度条 进度条14 = new DS按钮.进度条();
    DS按钮.进度条 进度条15 = new DS按钮.进度条();
    MyToolItem myToolItem1 = new MyToolItem();
    MyToolItem myToolItem2 = new MyToolItem();
    MyToolItem myToolItem3 = new MyToolItem();
    MyToolItem myToolItem4 = new MyToolItem();
    MyToolItem myToolItem5 = new MyToolItem();
    MyToolItem myToolItem6 = new MyToolItem();
    MyToolItem myToolItem7 = new MyToolItem();
    this.openFileDialog1 = new OpenFileDialog();
    this.myPanel11 = new MyPanel.MyPanel();
    this.tabControl1 = new System.Windows.Forms.TabControl();
    this.tabPage1 = new TabPage();
    this.listViewNF1 = new ListViewNF();
    this.columnHeader1 = new ColumnHeader();
    this.columnHeader26 = new ColumnHeader();
    this.columnHeader2 = new ColumnHeader();
    this.columnHeader3 = new ColumnHeader();
    this.columnHeader4 = new ColumnHeader();
    this.columnHeader5 = new ColumnHeader();
    this.columnHeader6 = new ColumnHeader();
    this.columnHeader7 = new ColumnHeader();
    this.columnHeader8 = new ColumnHeader();
    this.myPanel8 = new MyPanel.MyPanel();
    this.imageButton4 = new MyButton();
    this.imageButton3 = new MyButton();
    this.imageButton6 = new MyButton();
    this.imageButton5 = new MyButton();
    this.qqTextBox9 = new QQTextBox();
    this.qqTextBox6 = new QQTextBox();
    this.qqTextBox3 = new QQTextBox();
    this.label2 = new Label();
    this.qqRadioButton4 = new QQRadioButton();
    this.qqRadioButton3 = new QQRadioButton();
    this.qqTextBox10 = new QQTextBox();
    this.qqCheckBox3 = new QQCheckBox();
    this.qqTextBox1 = new QQTextBox();
    this.qqTextBox8 = new QQTextBox();
    this.qqTextBox2 = new QQTextBox();
    this.qqCheckBox1 = new QQCheckBox();
    this.qqTextBox7 = new QQTextBox();
    this.qqTextBox4 = new QQTextBox();
    this.qqCheckBox2 = new QQCheckBox();
    this.qqTextBox5 = new QQTextBox();
    this.dS标签1 = new DS标签();
    this.myPanel7 = new MyPanel.MyPanel();
    this.groupBoxEx4 = new GroupBoxEx(this.components);
    this.qqRadioButton5 = new QQRadioButton();
    this.qqRadioButton6 = new QQRadioButton();
    this.qqTextBox16 = new QQTextBox();
    this.qqTextBox14 = new QQTextBox();
    this.qqTextBox12 = new QQTextBox();
    this.imageButton8 = new MyButton();
    this.imageButton7 = new MyButton();
    this.label3 = new Label();
    this.qqTextBox11 = new QQTextBox();
    this.qqTextBox17 = new QQTextBox();
    this.qqCheckBox4 = new QQCheckBox();
    this.qqCheckBox6 = new QQCheckBox();
    this.qqTextBox15 = new QQTextBox();
    this.qqTextBox13 = new QQTextBox();
    this.qqCheckBox5 = new QQCheckBox();
    this.dS标签2 = new DS标签();
    this.tabPage2 = new TabPage();
    this.listViewNF2 = new ListViewNF();
    this.columnHeader9 = new ColumnHeader();
    this.columnHeader10 = new ColumnHeader();
    this.columnHeader11 = new ColumnHeader();
    this.columnHeader12 = new ColumnHeader();
    this.columnHeader13 = new ColumnHeader();
    this.columnHeader14 = new ColumnHeader();
    this.columnHeader15 = new ColumnHeader();
    this.columnHeader16 = new ColumnHeader();
    this.columnHeader17 = new ColumnHeader();
    this.myPanel19 = new MyPanel.MyPanel();
    this.label5 = new Label();
    this.qqTextBox51 = new QQTextBox();
    this.dS按钮2 = new DS按钮();
    this.dS按钮1 = new DS按钮();
    this.imageButton10 = new MyButton();
    this.imageButton9 = new MyButton();
    this.groupBoxEx3 = new GroupBoxEx(this.components);
    this.qqRadioButton8 = new QQRadioButton();
    this.qqRadioButton7 = new QQRadioButton();
    this.bar2 = new Bar();
    this.dataGridViewX1 = new DataGridViewX();
    this.Column1 = new DataGridViewCheckBoxColumn();
    this.Column6 = new DataGridViewTextBoxColumn();
    this.Column2 = new DataGridViewComboBoxColumn();
    this.Column3 = new DataGridViewTextBoxColumn();
    this.Column4 = new DataGridViewTextBoxColumn();
    this.Column7 = new DataGridViewTextBoxColumn();
    this.Column5 = new DataGridViewTextBoxColumn();
    this.bar1 = new Bar();
    this.label39 = new Label();
    this.tabPage3 = new TabPage();
    this.listViewNF3 = new ListViewNF();
    this.columnHeader18 = new ColumnHeader();
    this.columnHeader19 = new ColumnHeader();
    this.columnHeader20 = new ColumnHeader();
    this.columnHeader21 = new ColumnHeader();
    this.columnHeader22 = new ColumnHeader();
    this.columnHeader23 = new ColumnHeader();
    this.columnHeader24 = new ColumnHeader();
    this.columnHeader25 = new ColumnHeader();
    this.columnHeader27 = new ColumnHeader();
    this.myPanel1 = new MyPanel.MyPanel();
    this.dS按钮4 = new DS按钮();
    this.dS按钮3 = new DS按钮();
    this.imageButton12 = new MyButton();
    this.imageButton11 = new MyButton();
    this.groupBoxEx1 = new GroupBoxEx(this.components);
    this.qqRadioButton10 = new QQRadioButton();
    this.qqRadioButton9 = new QQRadioButton();
    this.bar3 = new Bar();
    this.dataGridViewX2 = new DataGridViewX();
    this.dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
    this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
    this.dataGridViewComboBoxColumn1 = new DataGridViewComboBoxColumn();
    this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
    this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
    this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
    this.dataGridViewTextBoxColumn5 = new DataGridViewComboBoxColumn();
    this.bar4 = new Bar();
    this.label4 = new Label();
    this.tabPage4 = new TabPage();
    this.myPanel15 = new MyPanel.MyPanel();
    this.dS按钮6 = new DS按钮();
    this.dS按钮5 = new DS按钮();
    this.groupBoxEx2 = new GroupBoxEx(this.components);
    this.qqRadioButton14 = new QQRadioButton();
    this.qqRadioButton13 = new QQRadioButton();
    this.groupBoxEx5 = new GroupBoxEx(this.components);
    this.qqRadioButton12 = new QQRadioButton();
    this.qqRadioButton11 = new QQRadioButton();
    this.label38 = new Label();
    this.myPanel14 = new MyPanel.MyPanel();
    this.imageButton14 = new MyButton();
    this.imageButton13 = new MyButton();
    this.qqTextBox29 = new QQTextBox();
    this.qqCheckBox18 = new QQCheckBox();
    this.qqTextBox28 = new QQTextBox();
    this.qqCheckBox16 = new QQCheckBox();
    this.qqTextBox26 = new QQTextBox();
    this.qqTextBox25 = new QQTextBox();
    this.qqCheckBox15 = new QQCheckBox();
    this.qqCheckBox14 = new QQCheckBox();
    this.qqCheckBox13 = new QQCheckBox();
    this.qqCheckBox17 = new QQCheckBox();
    this.qqTextBox27 = new QQTextBox();
    this.qqTextBox24 = new QQTextBox();
    this.qqTextBox23 = new QQTextBox();
    this.qqCheckBox12 = new QQCheckBox();
    this.qqTextBox22 = new QQTextBox();
    this.qqCheckBox10 = new QQCheckBox();
    this.qqCheckBox11 = new QQCheckBox();
    this.qqTextBox21 = new QQTextBox();
    this.qqTextBox20 = new QQTextBox();
    this.qqCheckBox9 = new QQCheckBox();
    this.label16 = new Label();
    this.qqTextBox19 = new QQTextBox();
    this.qqCheckBox7 = new QQCheckBox();
    this.qqCheckBox8 = new QQCheckBox();
    this.qqTextBox18 = new QQTextBox();
    this.listViewNF4 = new ListViewNF();
    this.columnHeader28 = new ColumnHeader();
    this.columnHeader29 = new ColumnHeader();
    this.columnHeader30 = new ColumnHeader();
    this.columnHeader31 = new ColumnHeader();
    this.columnHeader32 = new ColumnHeader();
    this.columnHeader33 = new ColumnHeader();
    this.columnHeader34 = new ColumnHeader();
    this.columnHeader35 = new ColumnHeader();
    this.columnHeader36 = new ColumnHeader();
    this.tabPage5 = new TabPage();
    this.dataGridViewX7 = new DataGridViewX();
    this.dataGridViewCheckBoxColumn6 = new DataGridViewCheckBoxColumn();
    this.dataGridViewTextBoxColumn23 = new DataGridViewTextBoxColumn();
    this.dataGridViewComboBoxColumn9 = new DataGridViewComboBoxColumn();
    this.dataGridViewTextBoxColumn24 = new DataGridViewTextBoxColumn();
    this.dataGridViewTextBoxColumn25 = new DataGridViewTextBoxColumn();
    this.dataGridViewTextBoxColumn26 = new DataGridViewTextBoxColumn();
    this.dataGridViewComboBoxColumn10 = new DataGridViewComboBoxColumn();
    this.dataGridViewX6 = new DataGridViewX();
    this.dataGridViewCheckBoxColumn5 = new DataGridViewCheckBoxColumn();
    this.dataGridViewTextBoxColumn19 = new DataGridViewTextBoxColumn();
    this.dataGridViewComboBoxColumn7 = new DataGridViewComboBoxColumn();
    this.dataGridViewTextBoxColumn20 = new DataGridViewTextBoxColumn();
    this.dataGridViewTextBoxColumn21 = new DataGridViewTextBoxColumn();
    this.dataGridViewTextBoxColumn22 = new DataGridViewTextBoxColumn();
    this.dataGridViewComboBoxColumn8 = new DataGridViewComboBoxColumn();
    this.dataGridViewX5 = new DataGridViewX();
    this.dataGridViewCheckBoxColumn4 = new DataGridViewCheckBoxColumn();
    this.dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
    this.dataGridViewComboBoxColumn5 = new DataGridViewComboBoxColumn();
    this.dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
    this.dataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn();
    this.dataGridViewTextBoxColumn18 = new DataGridViewTextBoxColumn();
    this.dataGridViewComboBoxColumn6 = new DataGridViewComboBoxColumn();
    this.dataGridViewX4 = new DataGridViewX();
    this.dataGridViewCheckBoxColumn3 = new DataGridViewCheckBoxColumn();
    this.dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
    this.dataGridViewComboBoxColumn3 = new DataGridViewComboBoxColumn();
    this.dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
    this.dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
    this.dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
    this.dataGridViewComboBoxColumn4 = new DataGridViewComboBoxColumn();
    this.myButton5 = new MyButton();
    this.groupBoxEx7 = new GroupBoxEx(this.components);
    this.qqTextBox55 = new QQTextBox();
    this.qqTextBox54 = new QQTextBox();
    this.qqTextBox53 = new QQTextBox();
    this.qqTextBox52 = new QQTextBox();
    this.dS标签22 = new DS标签();
    this.dS标签21 = new DS标签();
    this.dS标签20 = new DS标签();
    this.dS标签19 = new DS标签();
    this.dS标签18 = new DS标签();
    this.comboBox2 = new ComboBox();
    this.groupBoxEx6 = new GroupBoxEx(this.components);
    this.qqCheckBox25 = new QQCheckBox();
    this.qqCheckBox24 = new QQCheckBox();
    this.qqCheckBox23 = new QQCheckBox();
    this.qqCheckBox22 = new QQCheckBox();
    this.dS标签3 = new DS标签();
    this.dS数字输入框3 = new DS数字输入框();
    this.dS数字输入框2 = new DS数字输入框();
    this.dS标签4 = new DS标签();
    this.dS容器1 = new DS容器();
    this.myTabControl1 = new MyTabControl();
    this.tabPage11 = new TabPage();
    this.dataGridViewX3 = new DataGridViewX();
    this.dataGridViewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
    this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
    this.dataGridViewComboBoxColumn2 = new DataGridViewComboBoxColumn();
    this.dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
    this.dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
    this.dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
    this.dataGridViewTextBoxColumn10 = new DataGridViewComboBoxColumn();
    this.tabPage6 = new TabPage();
    this.qqTextBox49 = new QQTextBox();
    this.qqTextBox50 = new QQTextBox();
    this.dS标签16 = new DS标签();
    this.dS按钮12 = new DS按钮();
    this.dS按钮11 = new DS按钮();
    this.dS按钮10 = new DS按钮();
    this.dS标签6 = new DS标签();
    this.dS按钮9 = new DS按钮();
    this.listViewNF5 = new ListViewNF();
    this.columnHeader37 = new ColumnHeader();
    this.qqTextBox33 = new QQTextBox();
    this.qqTextBox30 = new QQTextBox();
    this.qqTextBox31 = new QQTextBox();
    this.qqTextBox32 = new QQTextBox();
    this.label17 = new Label();
    this.tabPage7 = new TabPage();
    this.qqTextBox48 = new QQTextBox();
    this.qqTextBox47 = new QQTextBox();
    this.qqCheckBox21 = new QQCheckBox();
    this.qqTextBox46 = new QQTextBox();
    this.qqCheckBox20 = new QQCheckBox();
    this.qqTextBox45 = new QQTextBox();
    this.qqCheckBox19 = new QQCheckBox();
    this.dS标签15 = new DS标签();
    this.qqTextBox44 = new QQTextBox();
    this.dS标签14 = new DS标签();
    this.dS按钮14 = new DS按钮();
    this.dS按钮15 = new DS按钮();
    this.myButton1 = new MyButton();
    this.dS标签13 = new DS标签();
    this.dS容器4 = new DS容器();
    this.dS标签12 = new DS标签();
    this.dS按钮13 = new DS按钮();
    this.qqTextBox43 = new QQTextBox();
    this.qqTextBox40 = new QQTextBox();
    this.qqTextBox42 = new QQTextBox();
    this.qqTextBox39 = new QQTextBox();
    this.qqTextBox41 = new QQTextBox();
    this.dS标签11 = new DS标签();
    this.imageButton17 = new MyButton();
    this.dS标签9 = new DS标签();
    this.dS容器3 = new DS容器();
    this.qqTextBox38 = new QQTextBox();
    this.qqTextBox35 = new QQTextBox();
    this.qqTextBox37 = new QQTextBox();
    this.qqTextBox34 = new QQTextBox();
    this.qqTextBox36 = new QQTextBox();
    this.dS标签8 = new DS标签();
    this.imageButton16 = new MyButton();
    this.imageButton15 = new MyButton();
    this.dS标签7 = new DS标签();
    this.tabPage8 = new TabPage();
    this.imageButton19 = new MyButton();
    this.imageButton18 = new MyButton();
    this.dS标签10 = new DS标签();
    this.dS容器5 = new DS容器();
    this.label23 = new Label();
    this.label22 = new Label();
    this.dS容器6 = new DS容器();
    this.tabPage9 = new TabPage();
    this.dS按钮16 = new DS按钮();
    this.dS按钮17 = new DS按钮();
    this.myButton2 = new MyButton();
    this.myButton3 = new MyButton();
    this.bar6 = new Bar();
    this.listViewNF7 = new ListViewNF();
    this.columnHeader38 = new ColumnHeader();
    this.columnHeader39 = new ColumnHeader();
    this.columnHeader40 = new ColumnHeader();
    this.columnHeader41 = new ColumnHeader();
    this.bar7 = new Bar();
    this.dS标签17 = new DS标签();
    this.controlContainerItem1 = new ControlContainerItem();
    this.bar5 = new Bar();
    this.listViewNF6 = new ListViewNF();
    this.columnHeader47 = new ColumnHeader();
    this.columnHeader48 = new ColumnHeader();
    this.columnHeader49 = new ColumnHeader();
    this.columnHeader50 = new ColumnHeader();
    this.tabPage10 = new TabPage();
    this.uiTitlePanel3 = new UITitlePanel();
    this.uiTreeView1 = new UITreeView();
    this.uiTitlePanel2 = new UITitlePanel();
    this.listView1 = new ListView();
    this.columnHeader42 = new ColumnHeader();
    this.columnHeader43 = new ColumnHeader();
    this.uiTitlePanel1 = new UITitlePanel();
    this.uiRichTextBox1 = new UIRichTextBox();
    this.uiLabel8 = new UILabel();
    this.myButton4 = new MyButton();
    this.uiLabel7 = new UILabel();
    this.uiLabel6 = new UILabel();
    this.uiLabel5 = new UILabel();
    this.uiLabel4 = new UILabel();
    this.uiLabel3 = new UILabel();
    this.uiLabel2 = new UILabel();
    this.uiLabel1 = new UILabel();
    this.uiLine9 = new UILine();
    this.uiButton63 = new UIButton();
    this.uiButton62 = new UIButton();
    this.uiButton61 = new UIButton();
    this.uiButton60 = new UIButton();
    this.uiButton59 = new UIButton();
    this.uiButton58 = new UIButton();
    this.uiButton57 = new UIButton();
    this.uiButton56 = new UIButton();
    this.uiLine16 = new UILine();
    this.uiButton55 = new UIButton();
    this.uiButton54 = new UIButton();
    this.uiButton53 = new UIButton();
    this.uiButton52 = new UIButton();
    this.uiButton51 = new UIButton();
    this.uiButton50 = new UIButton();
    this.uiButton49 = new UIButton();
    this.uiButton48 = new UIButton();
    this.uiLine15 = new UILine();
    this.uiButton47 = new UIButton();
    this.uiButton46 = new UIButton();
    this.uiButton45 = new UIButton();
    this.uiButton44 = new UIButton();
    this.uiButton43 = new UIButton();
    this.uiButton42 = new UIButton();
    this.uiButton41 = new UIButton();
    this.uiButton40 = new UIButton();
    this.uiLine14 = new UILine();
    this.uiButton39 = new UIButton();
    this.uiButton38 = new UIButton();
    this.uiButton37 = new UIButton();
    this.uiButton36 = new UIButton();
    this.uiButton35 = new UIButton();
    this.uiButton34 = new UIButton();
    this.uiButton33 = new UIButton();
    this.uiButton32 = new UIButton();
    this.uiLine13 = new UILine();
    this.uiButton31 = new UIButton();
    this.uiButton30 = new UIButton();
    this.uiButton29 = new UIButton();
    this.uiButton28 = new UIButton();
    this.uiButton27 = new UIButton();
    this.uiButton26 = new UIButton();
    this.uiButton25 = new UIButton();
    this.uiButton24 = new UIButton();
    this.uiLine12 = new UILine();
    this.uiButton23 = new UIButton();
    this.uiButton22 = new UIButton();
    this.uiButton21 = new UIButton();
    this.uiButton20 = new UIButton();
    this.uiButton19 = new UIButton();
    this.uiButton18 = new UIButton();
    this.uiButton17 = new UIButton();
    this.uiLine11 = new UILine();
    this.uiButton16 = new UIButton();
    this.uiButton15 = new UIButton();
    this.uiButton14 = new UIButton();
    this.uiButton13 = new UIButton();
    this.uiButton12 = new UIButton();
    this.uiButton11 = new UIButton();
    this.uiButton10 = new UIButton();
    this.uiButton9 = new UIButton();
    this.uiButton8 = new UIButton();
    this.uiLine8 = new UILine();
    this.uiLine7 = new UILine();
    this.uiLine6 = new UILine();
    this.uiLine5 = new UILine();
    this.uiLine4 = new UILine();
    this.uiLine3 = new UILine();
    this.uiLine1 = new UILine();
    this.uiLine10 = new UILine();
    this.uiLine2 = new UILine();
    this.uiButton7 = new UIButton();
    this.uiButton6 = new UIButton();
    this.uiButton5 = new UIButton();
    this.uiButton4 = new UIButton();
    this.uiButton3 = new UIButton();
    this.uiButton2 = new UIButton();
    this.uiButton1 = new UIButton();
    this.uiButton0 = new UIButton();
    this.myPanel3 = new MyPanel.MyPanel();
    this.dS数字输入框1 = new DS数字输入框();
    this.qqRadioButton2 = new QQRadioButton();
    this.qqRadioButton1 = new QQRadioButton();
    this.imageButton1 = new MyButton();
    this.progressBarEx1 = new ProgressBarEx();
    this.greenGradientBackgroundPainter1 = new GradientBackgroundPainter();
    this.greenPlainBorderPainter1 = new PlainBorderPainter();
    this.greenPlainProgressPainter1 = new PlainProgressPainter();
    this.greenGradientGlossPainter1 = new GradientGlossPainter();
    this.label1 = new Label();
    this.comboBox1 = new ComboBox();
    this.imageButton2 = new ImageButton();
    this.myToolBar1 = new MyToolBar();
    this.saveFileDialog1 = new SaveFileDialog();
    this.saveFileDialog2 = new SaveFileDialog();
    this.saveFileDialog3 = new SaveFileDialog();
    this.openFileDialog2 = new OpenFileDialog();
    this.serialPort1 = new SerialPort(this.components);
    this.saveFileDialog4 = new SaveFileDialog();
    this.saveFileDialog5 = new SaveFileDialog();
    ((Control) this.myPanel11).SuspendLayout();
    this.tabControl1.SuspendLayout();
    this.tabPage1.SuspendLayout();
    ((Control) this.myPanel8).SuspendLayout();
    ((Control) this.myPanel7).SuspendLayout();
    this.groupBoxEx4.SuspendLayout();
    this.tabPage2.SuspendLayout();
    ((Control) this.myPanel19).SuspendLayout();
    this.groupBoxEx3.SuspendLayout();
    ((ISupportInitialize) this.bar2).BeginInit();
    ((ISupportInitialize) this.dataGridViewX1).BeginInit();
    ((ISupportInitialize) this.bar1).BeginInit();
    this.bar1.SuspendLayout();
    this.tabPage3.SuspendLayout();
    ((Control) this.myPanel1).SuspendLayout();
    this.groupBoxEx1.SuspendLayout();
    ((ISupportInitialize) this.bar3).BeginInit();
    ((ISupportInitialize) this.dataGridViewX2).BeginInit();
    ((ISupportInitialize) this.bar4).BeginInit();
    this.bar4.SuspendLayout();
    this.tabPage4.SuspendLayout();
    ((Control) this.myPanel15).SuspendLayout();
    this.groupBoxEx2.SuspendLayout();
    this.groupBoxEx5.SuspendLayout();
    ((Control) this.myPanel14).SuspendLayout();
    this.tabPage5.SuspendLayout();
    ((ISupportInitialize) this.dataGridViewX7).BeginInit();
    ((ISupportInitialize) this.dataGridViewX6).BeginInit();
    ((ISupportInitialize) this.dataGridViewX5).BeginInit();
    ((ISupportInitialize) this.dataGridViewX4).BeginInit();
    this.groupBoxEx7.SuspendLayout();
    this.groupBoxEx6.SuspendLayout();
    this.dS容器1.SuspendLayout();
    this.myTabControl1.SuspendLayout();
    this.tabPage11.SuspendLayout();
    ((ISupportInitialize) this.dataGridViewX3).BeginInit();
    this.tabPage6.SuspendLayout();
    this.tabPage7.SuspendLayout();
    this.dS容器4.SuspendLayout();
    this.dS容器3.SuspendLayout();
    this.tabPage8.SuspendLayout();
    this.dS容器5.SuspendLayout();
    this.tabPage9.SuspendLayout();
    ((ISupportInitialize) this.bar6).BeginInit();
    ((ISupportInitialize) this.bar7).BeginInit();
    this.bar7.SuspendLayout();
    ((ISupportInitialize) this.bar5).BeginInit();
    this.tabPage10.SuspendLayout();
    this.uiTitlePanel3.SuspendLayout();
    this.uiTitlePanel2.SuspendLayout();
    this.uiTitlePanel1.SuspendLayout();
    ((Control) this.myPanel3).SuspendLayout();
    ((ISupportInitialize) this.imageButton2).BeginInit();
    this.SuspendLayout();
    this.openFileDialog1.FileName = "openFileDialog1";
    ((Control) this.myPanel11).BackColor = SystemColors.ControlLight;
    ((Control) this.myPanel11).Controls.Add((Control) this.tabControl1);
    ((Control) this.myPanel11).Location = new System.Drawing.Point(0, 115);
    ((Control) this.myPanel11).Margin = new System.Windows.Forms.Padding(0);
    ((Control) this.myPanel11).Name = "myPanel11";
    ((Control) this.myPanel11).Size = new System.Drawing.Size(900, 580);
    ((Control) this.myPanel11).TabIndex = 11;
    this.tabControl1.Controls.Add((Control) this.tabPage1);
    this.tabControl1.Controls.Add((Control) this.tabPage2);
    this.tabControl1.Controls.Add((Control) this.tabPage3);
    this.tabControl1.Controls.Add((Control) this.tabPage4);
    this.tabControl1.Controls.Add((Control) this.tabPage5);
    this.tabControl1.Controls.Add((Control) this.tabPage6);
    this.tabControl1.Controls.Add((Control) this.tabPage7);
    this.tabControl1.Controls.Add((Control) this.tabPage8);
    this.tabControl1.Controls.Add((Control) this.tabPage9);
    this.tabControl1.Controls.Add((Control) this.tabPage10);
    this.tabControl1.Location = new System.Drawing.Point(0, 0);
    this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
    this.tabControl1.Name = "tabControl1";
    this.tabControl1.SelectedIndex = 0;
    this.tabControl1.Size = new System.Drawing.Size(900, 580);
    this.tabControl1.TabIndex = 0;
    this.tabPage1.BackColor = SystemColors.ActiveCaption;
    this.tabPage1.Controls.Add((Control) this.listViewNF1);
    this.tabPage1.Controls.Add((Control) this.myPanel8);
    this.tabPage1.Controls.Add((Control) this.myPanel7);
    this.tabPage1.Location = new System.Drawing.Point(4, 22);
    this.tabPage1.Name = "tabPage1";
    this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
    this.tabPage1.Size = new System.Drawing.Size(892, 554);
    this.tabPage1.TabIndex = 0;
    this.tabPage1.Text = "单机模式";
    this.listViewNF1.BackColor = Color.RoyalBlue;
    this.listViewNF1.BorderStyle = BorderStyle.None;
    this.listViewNF1.Columns.AddRange(new ColumnHeader[9]
    {
      this.columnHeader1,
      this.columnHeader26,
      this.columnHeader2,
      this.columnHeader3,
      this.columnHeader4,
      this.columnHeader5,
      this.columnHeader6,
      this.columnHeader7,
      this.columnHeader8
    });
    this.listViewNF1.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.listViewNF1.ForeColor = Color.White;
    this.listViewNF1.FullRowSelect = true;
    this.listViewNF1.HideSelection = false;
    this.listViewNF1.Location = new System.Drawing.Point(0, 8);
    this.listViewNF1.Margin = new System.Windows.Forms.Padding(0);
    this.listViewNF1.MultiSelect = false;
    this.listViewNF1.Name = "listViewNF1";
    this.listViewNF1.Size = new System.Drawing.Size(892, 258);
    this.listViewNF1.TabIndex = 12;
    this.listViewNF1.UseCompatibleStateImageBehavior = false;
    this.listViewNF1.View = View.Details;
    this.columnHeader1.Text = "序号";
    this.columnHeader26.Text = "通道";
    this.columnHeader26.TextAlign = HorizontalAlignment.Center;
    this.columnHeader26.Width = 50;
    this.columnHeader2.Text = "方向";
    this.columnHeader2.TextAlign = HorizontalAlignment.Center;
    this.columnHeader2.Width = 70;
    this.columnHeader3.Text = "时间";
    this.columnHeader3.Width = 160 /*0xA0*/;
    this.columnHeader4.Text = "ID[PID]";
    this.columnHeader4.TextAlign = HorizontalAlignment.Center;
    this.columnHeader4.Width = 80 /*0x50*/;
    this.columnHeader5.Text = "数据长度";
    this.columnHeader5.TextAlign = HorizontalAlignment.Center;
    this.columnHeader5.Width = 70;
    this.columnHeader6.Text = "数据(Hex)";
    this.columnHeader6.Width = 210;
    this.columnHeader7.Text = "校验(Hex)";
    this.columnHeader7.TextAlign = HorizontalAlignment.Center;
    this.columnHeader7.Width = 80 /*0x50*/;
    this.columnHeader8.Text = "状态";
    this.columnHeader8.TextAlign = HorizontalAlignment.Center;
    this.columnHeader8.Width = 80 /*0x50*/;
    ((Control) this.myPanel8).BackgroundImage = (Image) componentResourceManager.GetObject("myPanel8.BackgroundImage");
    ((Control) this.myPanel8).BackgroundImageLayout = ImageLayout.Stretch;
    ((Control) this.myPanel8).Controls.Add((Control) this.imageButton4);
    ((Control) this.myPanel8).Controls.Add((Control) this.imageButton3);
    ((Control) this.myPanel8).Controls.Add((Control) this.imageButton6);
    ((Control) this.myPanel8).Controls.Add((Control) this.imageButton5);
    ((Control) this.myPanel8).Controls.Add((Control) this.qqTextBox9);
    ((Control) this.myPanel8).Controls.Add((Control) this.qqTextBox6);
    ((Control) this.myPanel8).Controls.Add((Control) this.qqTextBox3);
    ((Control) this.myPanel8).Controls.Add((Control) this.label2);
    ((Control) this.myPanel8).Controls.Add((Control) this.qqRadioButton4);
    ((Control) this.myPanel8).Controls.Add((Control) this.qqRadioButton3);
    ((Control) this.myPanel8).Controls.Add((Control) this.qqTextBox10);
    ((Control) this.myPanel8).Controls.Add((Control) this.qqCheckBox3);
    ((Control) this.myPanel8).Controls.Add((Control) this.qqTextBox1);
    ((Control) this.myPanel8).Controls.Add((Control) this.qqTextBox8);
    ((Control) this.myPanel8).Controls.Add((Control) this.qqTextBox2);
    ((Control) this.myPanel8).Controls.Add((Control) this.qqCheckBox1);
    ((Control) this.myPanel8).Controls.Add((Control) this.qqTextBox7);
    ((Control) this.myPanel8).Controls.Add((Control) this.qqTextBox4);
    ((Control) this.myPanel8).Controls.Add((Control) this.qqCheckBox2);
    ((Control) this.myPanel8).Controls.Add((Control) this.qqTextBox5);
    ((Control) this.myPanel8).Controls.Add((Control) this.dS标签1);
    ((Control) this.myPanel8).Location = new System.Drawing.Point(0, 266);
    ((Control) this.myPanel8).Margin = new System.Windows.Forms.Padding(0);
    ((Control) this.myPanel8).Name = "myPanel8";
    ((Control) this.myPanel8).Size = new System.Drawing.Size(892, 152);
    ((Control) this.myPanel8).TabIndex = 11;
    this.imageButton4.BackColor = Color.Transparent;
    this.imageButton4.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton4.DownImage = (Image) componentResourceManager.GetObject("imageButton4.DownImage");
    this.imageButton4.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton4.ForeColor = SystemColors.InfoText;
    this.imageButton4.Image = (Image) componentResourceManager.GetObject("imageButton4.Image");
    this.imageButton4.IsShowBorder = false;
    this.imageButton4.Location = new System.Drawing.Point(785, 10);
    this.imageButton4.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton4.MoveImage = (Image) componentResourceManager.GetObject("imageButton4.MoveImage");
    this.imageButton4.Name = "imageButton4";
    this.imageButton4.NormalImage = (Image) componentResourceManager.GetObject("imageButton4.NormalImage");
    this.imageButton4.Size = new System.Drawing.Size(69, 32 /*0x20*/);
    this.imageButton4.TabIndex = 49;
    this.imageButton4.Text = "保存数据";
    this.imageButton4.UseVisualStyleBackColor = false;
    this.imageButton4.Click += new EventHandler(this.imageButton4_Click);
    this.imageButton3.BackColor = Color.Transparent;
    this.imageButton3.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton3.DownImage = (Image) componentResourceManager.GetObject("imageButton3.DownImage");
    this.imageButton3.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton3.ForeColor = SystemColors.InfoText;
    this.imageButton3.Image = (Image) componentResourceManager.GetObject("imageButton3.Image");
    this.imageButton3.IsShowBorder = false;
    this.imageButton3.Location = new System.Drawing.Point(675, 10);
    this.imageButton3.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton3.MoveImage = (Image) componentResourceManager.GetObject("imageButton3.MoveImage");
    this.imageButton3.Name = "imageButton3";
    this.imageButton3.NormalImage = (Image) componentResourceManager.GetObject("imageButton3.NormalImage");
    this.imageButton3.Size = new System.Drawing.Size(69, 32 /*0x20*/);
    this.imageButton3.TabIndex = 47;
    this.imageButton3.Text = "清除显示";
    this.imageButton3.UseVisualStyleBackColor = false;
    this.imageButton3.Click += new EventHandler(this.imageButton3_Click);
    this.imageButton6.BackColor = Color.Transparent;
    this.imageButton6.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton6.DownImage = (Image) componentResourceManager.GetObject("imageButton6.DownImage");
    this.imageButton6.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton6.ForeColor = SystemColors.InfoText;
    this.imageButton6.Image = (Image) componentResourceManager.GetObject("imageButton6.Image");
    this.imageButton6.IsShowBorder = false;
    this.imageButton6.Location = new System.Drawing.Point(784, 107);
    this.imageButton6.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton6.MoveImage = (Image) componentResourceManager.GetObject("imageButton6.MoveImage");
    this.imageButton6.Name = "imageButton6";
    this.imageButton6.NormalImage = (Image) componentResourceManager.GetObject("imageButton6.NormalImage");
    this.imageButton6.Size = new System.Drawing.Size(69, 32 /*0x20*/);
    this.imageButton6.TabIndex = 46;
    this.imageButton6.Text = "停止";
    this.imageButton6.UseVisualStyleBackColor = false;
    this.imageButton6.Click += new EventHandler(this.imageButton6_Click);
    this.imageButton5.BackColor = Color.Transparent;
    this.imageButton5.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton5.DownImage = (Image) componentResourceManager.GetObject("imageButton5.DownImage");
    this.imageButton5.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton5.ForeColor = SystemColors.InfoText;
    this.imageButton5.Image = (Image) componentResourceManager.GetObject("imageButton5.Image");
    this.imageButton5.IsShowBorder = false;
    this.imageButton5.Location = new System.Drawing.Point(675, 107);
    this.imageButton5.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton5.MoveImage = (Image) componentResourceManager.GetObject("imageButton5.MoveImage");
    this.imageButton5.Name = "imageButton5";
    this.imageButton5.NormalImage = (Image) componentResourceManager.GetObject("imageButton5.NormalImage");
    this.imageButton5.Size = new System.Drawing.Size(69, 32 /*0x20*/);
    this.imageButton5.TabIndex = 36;
    this.imageButton5.Text = "发送";
    this.imageButton5.UseVisualStyleBackColor = false;
    this.imageButton5.Click += new EventHandler(this.imageButton5_Click);
    this.qqTextBox9.BackColor = Color.White;
    this.qqTextBox9.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox9.EmptyTextTip = (string) null;
    this.qqTextBox9.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox9.Font = new Font("宋体", 9f);
    this.qqTextBox9.Location = new System.Drawing.Point(574, 108);
    this.qqTextBox9.MaxLength = 1;
    this.qqTextBox9.Name = "qqTextBox9";
    this.qqTextBox9.Size = new System.Drawing.Size(61, 21);
    this.qqTextBox9.TabIndex = 34;
    this.qqTextBox9.Text = "8";
    this.qqTextBox9.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox6.BackColor = Color.White;
    this.qqTextBox6.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox6.EmptyTextTip = (string) null;
    this.qqTextBox6.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox6.Font = new Font("宋体", 9f);
    this.qqTextBox6.Location = new System.Drawing.Point(574, 79);
    this.qqTextBox6.MaxLength = 1;
    this.qqTextBox6.Name = "qqTextBox6";
    this.qqTextBox6.Size = new System.Drawing.Size(61, 21);
    this.qqTextBox6.TabIndex = 33;
    this.qqTextBox6.Text = "8";
    this.qqTextBox6.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox3.BackColor = Color.White;
    this.qqTextBox3.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox3.EmptyTextTip = (string) null;
    this.qqTextBox3.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox3.Font = new Font("宋体", 9f);
    this.qqTextBox3.Location = new System.Drawing.Point(574, 50);
    this.qqTextBox3.MaxLength = 1;
    this.qqTextBox3.Name = "qqTextBox3";
    this.qqTextBox3.Size = new System.Drawing.Size(61, 21);
    this.qqTextBox3.TabIndex = 32 /*0x20*/;
    this.qqTextBox3.Text = "8";
    this.qqTextBox3.TextAlign = HorizontalAlignment.Center;
    this.label2.AutoSize = true;
    this.label2.BackColor = Color.Transparent;
    this.label2.Font = new Font("微软雅黑", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    this.label2.ForeColor = Color.Black;
    this.label2.Location = new System.Drawing.Point(22, 9);
    this.label2.Margin = new System.Windows.Forms.Padding(0);
    this.label2.Name = "label2";
    this.label2.Size = new System.Drawing.Size(118, 25);
    this.label2.TabIndex = 7;
    this.label2.Text = "发送数据区:";
    this.qqRadioButton4.AutoSize = true;
    this.qqRadioButton4.BackColor = Color.Transparent;
    this.qqRadioButton4.Font = new Font("宋体", 9f);
    this.qqRadioButton4.Location = new System.Drawing.Point(782, 54);
    this.qqRadioButton4.Name = "qqRadioButton4";
    this.qqRadioButton4.Size = new System.Drawing.Size(71, 16 /*0x10*/);
    this.qqRadioButton4.TabIndex = 28;
    this.qqRadioButton4.Text = "多帧发送";
    this.qqRadioButton4.UseVisualStyleBackColor = false;
    this.qqRadioButton3.AutoSize = true;
    this.qqRadioButton3.BackColor = Color.Transparent;
    this.qqRadioButton3.Checked = true;
    this.qqRadioButton3.Font = new Font("宋体", 9f);
    this.qqRadioButton3.Location = new System.Drawing.Point(676, 54);
    this.qqRadioButton3.Name = "qqRadioButton3";
    this.qqRadioButton3.Size = new System.Drawing.Size(71, 16 /*0x10*/);
    this.qqRadioButton3.TabIndex = 27;
    this.qqRadioButton3.TabStop = true;
    this.qqRadioButton3.Text = "单帧发送";
    this.qqRadioButton3.UseVisualStyleBackColor = false;
    this.qqRadioButton3.CheckedChanged += new EventHandler(this.qqRadioButton3_CheckedChanged);
    this.qqTextBox10.BackColor = Color.White;
    this.qqTextBox10.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox10.EmptyTextTip = (string) null;
    this.qqTextBox10.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox10.Enabled = false;
    this.qqTextBox10.Font = new Font("宋体", 9f);
    this.qqTextBox10.Location = new System.Drawing.Point(785, 76);
    this.qqTextBox10.MaxLength = 4;
    this.qqTextBox10.Name = "qqTextBox10";
    this.qqTextBox10.Size = new System.Drawing.Size(68, 21);
    this.qqTextBox10.TabIndex = 25;
    this.qqTextBox10.Text = "10";
    this.qqTextBox10.TextAlign = HorizontalAlignment.Center;
    this.qqCheckBox3.AutoSize = true;
    this.qqCheckBox3.BackColor = Color.Transparent;
    this.qqCheckBox3.Font = new Font("宋体", 9f);
    this.qqCheckBox3.Location = new System.Drawing.Point(27, 110);
    this.qqCheckBox3.Name = "qqCheckBox3";
    this.qqCheckBox3.Size = new System.Drawing.Size(54, 16 /*0x10*/);
    this.qqCheckBox3.TabIndex = 23;
    this.qqCheckBox3.Text = "发送3";
    this.qqCheckBox3.UseVisualStyleBackColor = false;
    this.qqCheckBox3.CheckedChanged += new EventHandler(this.qqCheckBox3_CheckedChanged);
    this.qqTextBox1.BackColor = Color.White;
    this.qqTextBox1.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox1.EmptyTextTip = (string) null;
    this.qqTextBox1.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox1.Font = new Font("宋体", 9f);
    this.qqTextBox1.Location = new System.Drawing.Point(178, 50);
    this.qqTextBox1.MaxLength = 2;
    this.qqTextBox1.Name = "qqTextBox1";
    this.qqTextBox1.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox1.TabIndex = 9;
    this.qqTextBox1.Text = "00";
    this.qqTextBox1.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox8.BackColor = Color.White;
    this.qqTextBox8.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox8.EmptyTextTip = (string) null;
    this.qqTextBox8.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox8.Font = new Font("宋体", 9f);
    this.qqTextBox8.Location = new System.Drawing.Point(339, 107);
    this.qqTextBox8.MaxLength = 23;
    this.qqTextBox8.Name = "qqTextBox8";
    this.qqTextBox8.Size = new System.Drawing.Size(186, 21);
    this.qqTextBox8.TabIndex = 22;
    this.qqTextBox8.Text = "00 00 00 00 00 00 00 00";
    this.qqTextBox8.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox2.BackColor = Color.White;
    this.qqTextBox2.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox2.EmptyTextTip = (string) null;
    this.qqTextBox2.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox2.Font = new Font("宋体", 9f);
    this.qqTextBox2.Location = new System.Drawing.Point(339, 50);
    this.qqTextBox2.MaxLength = 23;
    this.qqTextBox2.Name = "qqTextBox2";
    this.qqTextBox2.Size = new System.Drawing.Size(186, 21);
    this.qqTextBox2.TabIndex = 11;
    this.qqTextBox2.Text = "00 00 00 00 00 00 00 00";
    this.qqTextBox2.TextAlign = HorizontalAlignment.Center;
    this.qqCheckBox1.AutoSize = true;
    this.qqCheckBox1.BackColor = Color.Transparent;
    this.qqCheckBox1.Checked = true;
    this.qqCheckBox1.CheckState = CheckState.Checked;
    this.qqCheckBox1.Font = new Font("宋体", 9f);
    this.qqCheckBox1.Location = new System.Drawing.Point(27, 53);
    this.qqCheckBox1.Name = "qqCheckBox1";
    this.qqCheckBox1.Size = new System.Drawing.Size(54, 16 /*0x10*/);
    this.qqCheckBox1.TabIndex = 13;
    this.qqCheckBox1.Text = "发送1";
    this.qqCheckBox1.UseVisualStyleBackColor = false;
    this.qqCheckBox1.CheckedChanged += new EventHandler(this.qqCheckBox1_CheckedChanged);
    this.qqTextBox7.BackColor = Color.White;
    this.qqTextBox7.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox7.EmptyTextTip = (string) null;
    this.qqTextBox7.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox7.Font = new Font("宋体", 9f);
    this.qqTextBox7.Location = new System.Drawing.Point(178, 107);
    this.qqTextBox7.MaxLength = 2;
    this.qqTextBox7.Name = "qqTextBox7";
    this.qqTextBox7.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox7.TabIndex = 20;
    this.qqTextBox7.Text = "00";
    this.qqTextBox7.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox4.BackColor = Color.White;
    this.qqTextBox4.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox4.EmptyTextTip = (string) null;
    this.qqTextBox4.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox4.Font = new Font("宋体", 9f);
    this.qqTextBox4.Location = new System.Drawing.Point(178, 79);
    this.qqTextBox4.MaxLength = 2;
    this.qqTextBox4.Name = "qqTextBox4";
    this.qqTextBox4.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox4.TabIndex = 15;
    this.qqTextBox4.Text = "00";
    this.qqTextBox4.TextAlign = HorizontalAlignment.Center;
    this.qqCheckBox2.AutoSize = true;
    this.qqCheckBox2.BackColor = Color.Transparent;
    this.qqCheckBox2.Font = new Font("宋体", 9f);
    this.qqCheckBox2.Location = new System.Drawing.Point(27, 82);
    this.qqCheckBox2.Name = "qqCheckBox2";
    this.qqCheckBox2.Size = new System.Drawing.Size(54, 16 /*0x10*/);
    this.qqCheckBox2.TabIndex = 18;
    this.qqCheckBox2.Text = "发送2";
    this.qqCheckBox2.UseVisualStyleBackColor = false;
    this.qqCheckBox2.CheckedChanged += new EventHandler(this.qqCheckBox2_CheckedChanged);
    this.qqTextBox5.BackColor = Color.White;
    this.qqTextBox5.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox5.EmptyTextTip = (string) null;
    this.qqTextBox5.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox5.Font = new Font("宋体", 9f);
    this.qqTextBox5.Location = new System.Drawing.Point(339, 79);
    this.qqTextBox5.MaxLength = 23;
    this.qqTextBox5.Name = "qqTextBox5";
    this.qqTextBox5.Size = new System.Drawing.Size(186, 21);
    this.qqTextBox5.TabIndex = 17;
    this.qqTextBox5.Text = "00 00 00 00 00 00 00 00";
    this.qqTextBox5.TextAlign = HorizontalAlignment.Center;
    this.dS标签1.BackColor = Color.Transparent;
    this.dS标签1.Dock = DockStyle.Fill;
    this.dS标签1.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS标签1.Location = new System.Drawing.Point(0, 0);
    this.dS标签1.Name = "dS标签1";
    this.dS标签1.Size = new System.Drawing.Size(892, 152);
    this.dS标签1.TabIndex = 35;
    this.dS标签1.Text = componentResourceManager.GetString("dS标签1.Text");
    this.dS标签1.偏移 = new System.Drawing.Point(110, 25);
    this.dS标签1.字体渲染模式 = TextRenderingHint.AntiAliasGridFit;
    this.dS标签1.行间距 = 16 /*0x10*/;
    ((Control) this.myPanel7).BackColor = SystemColors.ActiveCaption;
    ((Control) this.myPanel7).Controls.Add((Control) this.groupBoxEx4);
    ((Control) this.myPanel7).Controls.Add((Control) this.qqTextBox16);
    ((Control) this.myPanel7).Controls.Add((Control) this.qqTextBox14);
    ((Control) this.myPanel7).Controls.Add((Control) this.qqTextBox12);
    ((Control) this.myPanel7).Controls.Add((Control) this.imageButton8);
    ((Control) this.myPanel7).Controls.Add((Control) this.imageButton7);
    ((Control) this.myPanel7).Controls.Add((Control) this.label3);
    ((Control) this.myPanel7).Controls.Add((Control) this.qqTextBox11);
    ((Control) this.myPanel7).Controls.Add((Control) this.qqTextBox17);
    ((Control) this.myPanel7).Controls.Add((Control) this.qqCheckBox4);
    ((Control) this.myPanel7).Controls.Add((Control) this.qqCheckBox6);
    ((Control) this.myPanel7).Controls.Add((Control) this.qqTextBox15);
    ((Control) this.myPanel7).Controls.Add((Control) this.qqTextBox13);
    ((Control) this.myPanel7).Controls.Add((Control) this.qqCheckBox5);
    ((Control) this.myPanel7).Controls.Add((Control) this.dS标签2);
    ((Control) this.myPanel7).Location = new System.Drawing.Point(0, 418);
    ((Control) this.myPanel7).Margin = new System.Windows.Forms.Padding(0);
    ((Control) this.myPanel7).Name = "myPanel7";
    ((Control) this.myPanel7).Size = new System.Drawing.Size(892, 140);
    ((Control) this.myPanel7).TabIndex = 11;
    this.groupBoxEx4.BackgroundImage = (Image) componentResourceManager.GetObject("groupBoxEx4.BackgroundImage");
    this.groupBoxEx4.BackgroundImageLayout = ImageLayout.Stretch;
    this.groupBoxEx4.BorderColor = Color.Green;
    this.groupBoxEx4.Controls.Add((Control) this.qqRadioButton5);
    this.groupBoxEx4.Controls.Add((Control) this.qqRadioButton6);
    this.groupBoxEx4.Location = new System.Drawing.Point(442, 36);
    this.groupBoxEx4.Name = "groupBoxEx4";
    this.groupBoxEx4.Size = new System.Drawing.Size(193, 86);
    this.groupBoxEx4.TabIndex = 52;
    this.groupBoxEx4.TabStop = false;
    this.groupBoxEx4.Text = "读取模式选择：";
    this.qqRadioButton5.AutoSize = true;
    this.qqRadioButton5.BackColor = Color.Transparent;
    this.qqRadioButton5.Checked = true;
    this.qqRadioButton5.Font = new Font("宋体", 9f);
    this.qqRadioButton5.Location = new System.Drawing.Point(12, 40);
    this.qqRadioButton5.Name = "qqRadioButton5";
    this.qqRadioButton5.Size = new System.Drawing.Size(71, 16 /*0x10*/);
    this.qqRadioButton5.TabIndex = 41;
    this.qqRadioButton5.TabStop = true;
    this.qqRadioButton5.Text = "单帧接收";
    this.qqRadioButton5.UseVisualStyleBackColor = false;
    this.qqRadioButton5.CheckedChanged += new EventHandler(this.qqRadioButton5_CheckedChanged);
    this.qqRadioButton6.AutoSize = true;
    this.qqRadioButton6.BackColor = Color.Transparent;
    this.qqRadioButton6.Font = new Font("宋体", 9f);
    this.qqRadioButton6.Location = new System.Drawing.Point(109, 40);
    this.qqRadioButton6.Name = "qqRadioButton6";
    this.qqRadioButton6.Size = new System.Drawing.Size(71, 16 /*0x10*/);
    this.qqRadioButton6.TabIndex = 42;
    this.qqRadioButton6.Text = "多帧接收";
    this.qqRadioButton6.UseVisualStyleBackColor = false;
    this.qqTextBox16.BackColor = Color.White;
    this.qqTextBox16.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox16.EmptyTextTip = (string) null;
    this.qqTextBox16.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox16.Font = new Font("宋体", 9f);
    this.qqTextBox16.Location = new System.Drawing.Point(339, 99);
    this.qqTextBox16.MaxLength = 1;
    this.qqTextBox16.Name = "qqTextBox16";
    this.qqTextBox16.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox16.TabIndex = 51;
    this.qqTextBox16.Text = "8";
    this.qqTextBox16.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox14.BackColor = Color.White;
    this.qqTextBox14.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox14.EmptyTextTip = (string) null;
    this.qqTextBox14.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox14.Font = new Font("宋体", 9f);
    this.qqTextBox14.Location = new System.Drawing.Point(339, 71);
    this.qqTextBox14.MaxLength = 1;
    this.qqTextBox14.Name = "qqTextBox14";
    this.qqTextBox14.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox14.TabIndex = 50;
    this.qqTextBox14.Text = "8";
    this.qqTextBox14.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox12.BackColor = Color.White;
    this.qqTextBox12.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox12.EmptyTextTip = (string) null;
    this.qqTextBox12.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox12.Font = new Font("宋体", 9f);
    this.qqTextBox12.Location = new System.Drawing.Point(339, 42);
    this.qqTextBox12.MaxLength = 1;
    this.qqTextBox12.Name = "qqTextBox12";
    this.qqTextBox12.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox12.TabIndex = 49;
    this.qqTextBox12.Text = "8";
    this.qqTextBox12.TextAlign = HorizontalAlignment.Center;
    this.imageButton8.BackColor = Color.Transparent;
    this.imageButton8.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton8.DownImage = (Image) componentResourceManager.GetObject("imageButton8.DownImage");
    this.imageButton8.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton8.ForeColor = SystemColors.InfoText;
    this.imageButton8.Image = (Image) componentResourceManager.GetObject("imageButton8.Image");
    this.imageButton8.IsShowBorder = false;
    this.imageButton8.Location = new System.Drawing.Point(785, 88);
    this.imageButton8.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton8.MoveImage = (Image) componentResourceManager.GetObject("imageButton8.MoveImage");
    this.imageButton8.Name = "imageButton8";
    this.imageButton8.NormalImage = (Image) componentResourceManager.GetObject("imageButton8.NormalImage");
    this.imageButton8.Size = new System.Drawing.Size(69, 32 /*0x20*/);
    this.imageButton8.TabIndex = 48 /*0x30*/;
    this.imageButton8.Text = "停止";
    this.imageButton8.UseVisualStyleBackColor = false;
    this.imageButton8.Click += new EventHandler(this.imageButton8_Click);
    this.imageButton7.BackColor = Color.Transparent;
    this.imageButton7.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton7.DownImage = (Image) componentResourceManager.GetObject("imageButton7.DownImage");
    this.imageButton7.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton7.ForeColor = SystemColors.InfoText;
    this.imageButton7.Image = (Image) componentResourceManager.GetObject("imageButton7.Image");
    this.imageButton7.IsShowBorder = false;
    this.imageButton7.Location = new System.Drawing.Point(676, 90);
    this.imageButton7.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton7.MoveImage = (Image) componentResourceManager.GetObject("imageButton7.MoveImage");
    this.imageButton7.Name = "imageButton7";
    this.imageButton7.NormalImage = (Image) componentResourceManager.GetObject("imageButton7.NormalImage");
    this.imageButton7.Size = new System.Drawing.Size(69, 32 /*0x20*/);
    this.imageButton7.TabIndex = 47;
    this.imageButton7.Text = "接收";
    this.imageButton7.UseVisualStyleBackColor = false;
    this.imageButton7.Click += new EventHandler(this.imageButton7_Click);
    this.label3.AutoSize = true;
    this.label3.BackColor = Color.Transparent;
    this.label3.Font = new Font("微软雅黑", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    this.label3.ForeColor = Color.Black;
    this.label3.Location = new System.Drawing.Point(23, 7);
    this.label3.Margin = new System.Windows.Forms.Padding(0);
    this.label3.Name = "label3";
    this.label3.Size = new System.Drawing.Size(118, 25);
    this.label3.TabIndex = 8;
    this.label3.Text = "接收数据区:";
    this.qqTextBox11.BackColor = Color.White;
    this.qqTextBox11.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox11.EmptyTextTip = (string) null;
    this.qqTextBox11.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox11.Font = new Font("宋体", 9f);
    this.qqTextBox11.Location = new System.Drawing.Point(178, 42);
    this.qqTextBox11.MaxLength = 2;
    this.qqTextBox11.Name = "qqTextBox11";
    this.qqTextBox11.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox11.TabIndex = 30;
    this.qqTextBox11.Text = "00";
    this.qqTextBox11.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox17.BackColor = Color.White;
    this.qqTextBox17.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox17.EmptyTextTip = (string) null;
    this.qqTextBox17.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox17.Enabled = false;
    this.qqTextBox17.Font = new Font("宋体", 9f);
    this.qqTextBox17.Location = new System.Drawing.Point(760, 42);
    this.qqTextBox17.MaxLength = 4;
    this.qqTextBox17.Name = "qqTextBox17";
    this.qqTextBox17.Size = new System.Drawing.Size(96 /*0x60*/, 21);
    this.qqTextBox17.TabIndex = 39;
    this.qqTextBox17.Text = "10";
    this.qqTextBox17.TextAlign = HorizontalAlignment.Center;
    this.qqCheckBox4.AutoSize = true;
    this.qqCheckBox4.BackColor = Color.Transparent;
    this.qqCheckBox4.Checked = true;
    this.qqCheckBox4.CheckState = CheckState.Checked;
    this.qqCheckBox4.Font = new Font("宋体", 9f);
    this.qqCheckBox4.Location = new System.Drawing.Point(27, 43);
    this.qqCheckBox4.Name = "qqCheckBox4";
    this.qqCheckBox4.Size = new System.Drawing.Size(54, 16 /*0x10*/);
    this.qqCheckBox4.TabIndex = 31 /*0x1F*/;
    this.qqCheckBox4.Text = "接收1";
    this.qqCheckBox4.UseVisualStyleBackColor = false;
    this.qqCheckBox4.CheckedChanged += new EventHandler(this.qqCheckBox4_CheckedChanged);
    this.qqCheckBox6.AutoSize = true;
    this.qqCheckBox6.BackColor = Color.Transparent;
    this.qqCheckBox6.Font = new Font("宋体", 9f);
    this.qqCheckBox6.Location = new System.Drawing.Point(27, 100);
    this.qqCheckBox6.Name = "qqCheckBox6";
    this.qqCheckBox6.Size = new System.Drawing.Size(54, 16 /*0x10*/);
    this.qqCheckBox6.TabIndex = 37;
    this.qqCheckBox6.Text = "接收3";
    this.qqCheckBox6.UseVisualStyleBackColor = false;
    this.qqCheckBox6.CheckedChanged += new EventHandler(this.qqCheckBox6_CheckedChanged);
    this.qqTextBox15.BackColor = Color.White;
    this.qqTextBox15.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox15.EmptyTextTip = (string) null;
    this.qqTextBox15.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox15.Font = new Font("宋体", 9f);
    this.qqTextBox15.Location = new System.Drawing.Point(178, 99);
    this.qqTextBox15.MaxLength = 2;
    this.qqTextBox15.Name = "qqTextBox15";
    this.qqTextBox15.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox15.TabIndex = 36;
    this.qqTextBox15.Text = "00";
    this.qqTextBox15.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox13.BackColor = Color.White;
    this.qqTextBox13.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox13.EmptyTextTip = (string) null;
    this.qqTextBox13.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox13.Font = new Font("宋体", 9f);
    this.qqTextBox13.Location = new System.Drawing.Point(178, 71);
    this.qqTextBox13.MaxLength = 2;
    this.qqTextBox13.Name = "qqTextBox13";
    this.qqTextBox13.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox13.TabIndex = 33;
    this.qqTextBox13.Text = "00";
    this.qqTextBox13.TextAlign = HorizontalAlignment.Center;
    this.qqCheckBox5.AutoSize = true;
    this.qqCheckBox5.BackColor = Color.Transparent;
    this.qqCheckBox5.Font = new Font("宋体", 9f);
    this.qqCheckBox5.Location = new System.Drawing.Point(27, 72);
    this.qqCheckBox5.Name = "qqCheckBox5";
    this.qqCheckBox5.Size = new System.Drawing.Size(54, 16 /*0x10*/);
    this.qqCheckBox5.TabIndex = 34;
    this.qqCheckBox5.Text = "接收2";
    this.qqCheckBox5.UseVisualStyleBackColor = false;
    this.qqCheckBox5.CheckedChanged += new EventHandler(this.qqCheckBox5_CheckedChanged);
    this.dS标签2.BackColor = SystemColors.ActiveCaption;
    this.dS标签2.Dock = DockStyle.Fill;
    this.dS标签2.Location = new System.Drawing.Point(0, 0);
    this.dS标签2.Margin = new System.Windows.Forms.Padding(0);
    this.dS标签2.Name = "dS标签2";
    this.dS标签2.Size = new System.Drawing.Size(892, 140);
    this.dS标签2.TabIndex = 45;
    this.dS标签2.Text = "帧ID(Hex):                 数据长度:                                                          接收间隔(ms):\r\n帧ID(Hex):                 数据长度:                    \r\n帧ID(Hex):                 数据长度:";
    this.dS标签2.偏移 = new System.Drawing.Point(110, 47);
    this.dS标签2.字体渲染模式 = TextRenderingHint.AntiAliasGridFit;
    this.dS标签2.行间距 = 16 /*0x10*/;
    this.tabPage2.BackColor = SystemColors.ActiveCaption;
    this.tabPage2.Controls.Add((Control) this.listViewNF2);
    this.tabPage2.Controls.Add((Control) this.myPanel19);
    this.tabPage2.Controls.Add((Control) this.bar2);
    this.tabPage2.Controls.Add((Control) this.dataGridViewX1);
    this.tabPage2.Controls.Add((Control) this.bar1);
    this.tabPage2.Location = new System.Drawing.Point(4, 22);
    this.tabPage2.Name = "tabPage2";
    this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
    this.tabPage2.Size = new System.Drawing.Size(892, 554);
    this.tabPage2.TabIndex = 1;
    this.tabPage2.Text = "列表模式";
    this.listViewNF2.BackColor = Color.RoyalBlue;
    this.listViewNF2.BorderStyle = BorderStyle.None;
    this.listViewNF2.Columns.AddRange(new ColumnHeader[9]
    {
      this.columnHeader9,
      this.columnHeader10,
      this.columnHeader11,
      this.columnHeader12,
      this.columnHeader13,
      this.columnHeader14,
      this.columnHeader15,
      this.columnHeader16,
      this.columnHeader17
    });
    this.listViewNF2.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.listViewNF2.ForeColor = Color.White;
    this.listViewNF2.FullRowSelect = true;
    this.listViewNF2.HideSelection = false;
    this.listViewNF2.Location = new System.Drawing.Point(0, 8);
    this.listViewNF2.Margin = new System.Windows.Forms.Padding(0);
    this.listViewNF2.MultiSelect = false;
    this.listViewNF2.Name = "listViewNF2";
    this.listViewNF2.Size = new System.Drawing.Size(892, 258);
    this.listViewNF2.TabIndex = 48 /*0x30*/;
    this.listViewNF2.UseCompatibleStateImageBehavior = false;
    this.listViewNF2.View = View.Details;
    this.columnHeader9.Text = "序号";
    this.columnHeader10.Text = "通道";
    this.columnHeader10.TextAlign = HorizontalAlignment.Center;
    this.columnHeader10.Width = 50;
    this.columnHeader11.Text = "方向";
    this.columnHeader11.TextAlign = HorizontalAlignment.Center;
    this.columnHeader11.Width = 70;
    this.columnHeader12.Text = "时间";
    this.columnHeader12.Width = 160 /*0xA0*/;
    this.columnHeader13.Text = "ID[PID]";
    this.columnHeader13.TextAlign = HorizontalAlignment.Center;
    this.columnHeader13.Width = 80 /*0x50*/;
    this.columnHeader14.Text = "数据长度";
    this.columnHeader14.TextAlign = HorizontalAlignment.Center;
    this.columnHeader14.Width = 70;
    this.columnHeader15.Text = "数据(Hex)";
    this.columnHeader15.Width = 210;
    this.columnHeader16.Text = "校验(Hex)";
    this.columnHeader16.TextAlign = HorizontalAlignment.Center;
    this.columnHeader16.Width = 80 /*0x50*/;
    this.columnHeader17.Text = "状态";
    this.columnHeader17.TextAlign = HorizontalAlignment.Center;
    this.columnHeader17.Width = 80 /*0x50*/;
    ((Control) this.myPanel19).BackColor = SystemColors.GradientInactiveCaption;
    ((Control) this.myPanel19).Controls.Add((Control) this.label5);
    ((Control) this.myPanel19).Controls.Add((Control) this.qqTextBox51);
    ((Control) this.myPanel19).Controls.Add((Control) this.dS按钮2);
    ((Control) this.myPanel19).Controls.Add((Control) this.dS按钮1);
    ((Control) this.myPanel19).Controls.Add((Control) this.imageButton10);
    ((Control) this.myPanel19).Controls.Add((Control) this.imageButton9);
    ((Control) this.myPanel19).Controls.Add((Control) this.groupBoxEx3);
    ((Control) this.myPanel19).Location = new System.Drawing.Point(618, 291);
    ((Control) this.myPanel19).Margin = new System.Windows.Forms.Padding(0);
    ((Control) this.myPanel19).Name = "myPanel19";
    ((Control) this.myPanel19).Size = new System.Drawing.Size(274, 238);
    ((Control) this.myPanel19).TabIndex = 47;
    this.label5.AutoSize = true;
    this.label5.BackColor = Color.Transparent;
    this.label5.Font = new Font("微软雅黑", 10.5f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    this.label5.ForeColor = Color.Black;
    this.label5.Location = new System.Drawing.Point(34, 57);
    this.label5.Name = "label5";
    this.label5.Size = new System.Drawing.Size(69, 20);
    this.label5.TabIndex = 55;
    this.label5.Text = "帧次数：";
    this.qqTextBox51.BackColor = Color.White;
    this.qqTextBox51.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox51.EmptyTextTip = "输入0，表示无限循环";
    this.qqTextBox51.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox51.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox51.Location = new System.Drawing.Point(105, 56);
    this.qqTextBox51.MaxLength = 5;
    this.qqTextBox51.Name = "qqTextBox51";
    this.qqTextBox51.Size = new System.Drawing.Size(143, 23);
    this.qqTextBox51.TabIndex = 54;
    this.qqTextBox51.Text = "1";
    this.qqTextBox51.TextAlign = HorizontalAlignment.Center;
    this.dS按钮2.BackColor = Color.Transparent;
    this.dS按钮2.BackgroundImage = (Image) componentResourceManager.GetObject("dS按钮2.BackgroundImage");
    this.dS按钮2.Cursor = Cursors.Default;
    this.dS按钮2.DialogResult = DialogResult.None;
    this.dS按钮2.ForeColor = Color.White;
    this.dS按钮2.Location = new System.Drawing.Point(173, 162);
    this.dS按钮2.Margin = new System.Windows.Forms.Padding(1);
    this.dS按钮2.Name = "dS按钮2";
    this.dS按钮2.Size = new System.Drawing.Size(75, 75);
    this.dS按钮2.TabIndex = 53;
    this.dS按钮2.图像 = (Bitmap) null;
    this.dS按钮2.异形透明度采样百分比 = 0.1f;
    进度条1.指示进度 = 0.0f;
    进度条1.进度条颜色 = Color.DodgerBlue;
    this.dS按钮2.指示进度条 = 进度条1;
    this.dS按钮2.文本 = "";
    this.dS按钮2.禁用时透明度 = 0.3f;
    this.dS按钮2.自动尺寸扩展 = new System.Drawing.Size(20, 20);
    this.dS按钮2.自定义图像.按下 = (Bitmap) null;
    this.dS按钮2.自定义图像.禁用 = (Bitmap) null;
    this.dS按钮2.自定义图像.高亮 = (Bitmap) null;
    this.dS按钮2.自定义图像.默认 = (Bitmap) null;
    this.dS按钮2.贴图 = (Bitmap) componentResourceManager.GetObject("dS按钮2.贴图");
    this.dS按钮2.贴图切割边距.上 = 0;
    this.dS按钮2.贴图切割边距.下 = 0;
    this.dS按钮2.贴图切割边距.右 = 0;
    this.dS按钮2.贴图切割边距.左 = 0;
    this.dS按钮2.贴图模式 = DS按钮._贴图模式.贴图;
    this.dS按钮2.透明度 = 1f;
    this.dS按钮2.附加内容字体 = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS按钮2.ButtonClick += new DS按钮.ButtonClickEventHandler(this.dS按钮2_ButtonClick);
    this.dS按钮1.BackColor = Color.Transparent;
    this.dS按钮1.BackgroundImage = (Image) componentResourceManager.GetObject("dS按钮1.BackgroundImage");
    this.dS按钮1.Cursor = Cursors.Default;
    this.dS按钮1.DialogResult = DialogResult.None;
    this.dS按钮1.ForeColor = Color.White;
    this.dS按钮1.Location = new System.Drawing.Point(32 /*0x20*/, 162);
    this.dS按钮1.Margin = new System.Windows.Forms.Padding(1);
    this.dS按钮1.Name = "dS按钮1";
    this.dS按钮1.Size = new System.Drawing.Size(75, 75);
    this.dS按钮1.TabIndex = 52;
    this.dS按钮1.TabStop = false;
    this.dS按钮1.图像 = (Bitmap) null;
    this.dS按钮1.异形透明度采样百分比 = 0.1f;
    进度条2.指示进度 = 0.0f;
    进度条2.进度条颜色 = Color.DodgerBlue;
    this.dS按钮1.指示进度条 = 进度条2;
    this.dS按钮1.文本 = "";
    this.dS按钮1.禁用时透明度 = 0.3f;
    this.dS按钮1.自动尺寸扩展 = new System.Drawing.Size(20, 20);
    this.dS按钮1.自定义图像.按下 = (Bitmap) null;
    this.dS按钮1.自定义图像.禁用 = (Bitmap) null;
    this.dS按钮1.自定义图像.高亮 = (Bitmap) null;
    this.dS按钮1.自定义图像.默认 = (Bitmap) null;
    this.dS按钮1.贴图 = (Bitmap) componentResourceManager.GetObject("dS按钮1.贴图");
    this.dS按钮1.贴图切割边距.上 = 0;
    this.dS按钮1.贴图切割边距.下 = 0;
    this.dS按钮1.贴图切割边距.右 = 0;
    this.dS按钮1.贴图切割边距.左 = 0;
    this.dS按钮1.贴图模式 = DS按钮._贴图模式.贴图;
    this.dS按钮1.透明度 = 1f;
    this.dS按钮1.附加内容字体 = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS按钮1.ButtonClick += new DS按钮.ButtonClickEventHandler(this.dS按钮1_ButtonClick);
    this.imageButton10.BackColor = Color.Transparent;
    this.imageButton10.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton10.DownImage = (Image) componentResourceManager.GetObject("imageButton10.DownImage");
    this.imageButton10.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton10.ForeColor = SystemColors.InfoText;
    this.imageButton10.Image = (Image) componentResourceManager.GetObject("imageButton10.Image");
    this.imageButton10.IsShowBorder = false;
    this.imageButton10.Location = new System.Drawing.Point(179, 9);
    this.imageButton10.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton10.MoveImage = (Image) componentResourceManager.GetObject("imageButton10.MoveImage");
    this.imageButton10.Name = "imageButton10";
    this.imageButton10.NormalImage = (Image) componentResourceManager.GetObject("imageButton10.NormalImage");
    this.imageButton10.Size = new System.Drawing.Size(69, 32 /*0x20*/);
    this.imageButton10.TabIndex = 51;
    this.imageButton10.Text = "保存数据";
    this.imageButton10.UseVisualStyleBackColor = false;
    this.imageButton10.Click += new EventHandler(this.imageButton10_Click);
    this.imageButton9.BackColor = Color.Transparent;
    this.imageButton9.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton9.DownImage = (Image) componentResourceManager.GetObject("imageButton9.DownImage");
    this.imageButton9.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton9.ForeColor = SystemColors.InfoText;
    this.imageButton9.Image = (Image) componentResourceManager.GetObject("imageButton9.Image");
    this.imageButton9.IsShowBorder = false;
    this.imageButton9.Location = new System.Drawing.Point(38, 9);
    this.imageButton9.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton9.MoveImage = (Image) componentResourceManager.GetObject("imageButton9.MoveImage");
    this.imageButton9.Name = "imageButton9";
    this.imageButton9.NormalImage = (Image) componentResourceManager.GetObject("imageButton9.NormalImage");
    this.imageButton9.Size = new System.Drawing.Size(69, 32 /*0x20*/);
    this.imageButton9.TabIndex = 50;
    this.imageButton9.Text = "清除显示";
    this.imageButton9.UseVisualStyleBackColor = false;
    this.imageButton9.Click += new EventHandler(this.imageButton9_Click);
    this.groupBoxEx3.BackgroundImage = (Image) componentResourceManager.GetObject("groupBoxEx3.BackgroundImage");
    this.groupBoxEx3.BackgroundImageLayout = ImageLayout.Stretch;
    this.groupBoxEx3.BorderColor = Color.Green;
    this.groupBoxEx3.Controls.Add((Control) this.qqRadioButton8);
    this.groupBoxEx3.Controls.Add((Control) this.qqRadioButton7);
    this.groupBoxEx3.Location = new System.Drawing.Point(35, 90);
    this.groupBoxEx3.Name = "groupBoxEx3";
    this.groupBoxEx3.Size = new System.Drawing.Size(213, 68);
    this.groupBoxEx3.TabIndex = 41;
    this.groupBoxEx3.TabStop = false;
    this.groupBoxEx3.Text = "显示模式选择：";
    this.qqRadioButton8.AutoSize = true;
    this.qqRadioButton8.BackColor = Color.Transparent;
    this.qqRadioButton8.Font = new Font("宋体", 9f);
    this.qqRadioButton8.Location = new System.Drawing.Point(121, 30);
    this.qqRadioButton8.Name = "qqRadioButton8";
    this.qqRadioButton8.Size = new System.Drawing.Size(71, 16 /*0x10*/);
    this.qqRadioButton8.TabIndex = 32 /*0x20*/;
    this.qqRadioButton8.Text = "静态显示";
    this.qqRadioButton8.UseVisualStyleBackColor = false;
    this.qqRadioButton7.AutoSize = true;
    this.qqRadioButton7.BackColor = Color.Transparent;
    this.qqRadioButton7.Checked = true;
    this.qqRadioButton7.Font = new Font("宋体", 9f);
    this.qqRadioButton7.Location = new System.Drawing.Point(15, 30);
    this.qqRadioButton7.Name = "qqRadioButton7";
    this.qqRadioButton7.Size = new System.Drawing.Size(71, 16 /*0x10*/);
    this.qqRadioButton7.TabIndex = 31 /*0x1F*/;
    this.qqRadioButton7.TabStop = true;
    this.qqRadioButton7.Text = "动态显示";
    this.qqRadioButton7.UseVisualStyleBackColor = false;
    this.qqRadioButton7.CheckedChanged += new EventHandler(this.qqRadioButton7_CheckedChanged);
    this.bar2.Location = new System.Drawing.Point(0, 529);
    ((Control) this.bar2).Margin = new System.Windows.Forms.Padding(0);
    this.bar2.Name = "bar2";
    this.bar2.Size = new System.Drawing.Size(892, 25);
    this.bar2.Stretch = true;
    this.bar2.Style = eDotNetBarStyle.Office2003;
    this.bar2.TabIndex = 46;
    this.bar2.TabStop = false;
    ((Control) this.bar2).Text = "bar2";
    ((DataGridView) this.dataGridViewX1).AllowUserToDeleteRows = false;
    ((DataGridView) this.dataGridViewX1).BackgroundColor = SystemColors.ActiveCaption;
    ((DataGridView) this.dataGridViewX1).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
    ((DataGridView) this.dataGridViewX1).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
    ((DataGridView) this.dataGridViewX1).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    ((DataGridView) this.dataGridViewX1).Columns.AddRange((DataGridViewColumn) this.Column1, (DataGridViewColumn) this.Column6, (DataGridViewColumn) this.Column2, (DataGridViewColumn) this.Column3, (DataGridViewColumn) this.Column4, (DataGridViewColumn) this.Column7, (DataGridViewColumn) this.Column5);
    gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle1.BackColor = SystemColors.Window;
    gridViewCellStyle1.Font = new Font("宋体", 9f);
    gridViewCellStyle1.ForeColor = SystemColors.ControlText;
    gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
    gridViewCellStyle1.WrapMode = DataGridViewTriState.False;
    ((DataGridView) this.dataGridViewX1).DefaultCellStyle = gridViewCellStyle1;
    ((DataGridView) this.dataGridViewX1).EditMode = DataGridViewEditMode.EditOnEnter;
    ((DataGridView) this.dataGridViewX1).GridColor = Color.FromArgb(208 /*0xD0*/, 215, 229);
    ((Control) this.dataGridViewX1).Location = new System.Drawing.Point(-3, 291);
    ((Control) this.dataGridViewX1).Margin = new System.Windows.Forms.Padding(0);
    ((DataGridView) this.dataGridViewX1).MultiSelect = false;
    ((Control) this.dataGridViewX1).Name = "dataGridViewX1";
    ((DataGridView) this.dataGridViewX1).RowHeadersVisible = false;
    ((DataGridView) this.dataGridViewX1).RowTemplate.Height = 23;
    ((DataGridView) this.dataGridViewX1).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    ((DataGridView) this.dataGridViewX1).ShowCellToolTips = false;
    ((Control) this.dataGridViewX1).Size = new System.Drawing.Size(621, 239);
    ((Control) this.dataGridViewX1).TabIndex = 45;
    this.Column1.HeaderText = "    ";
    this.Column1.Name = "Column1";
    this.Column1.Width = 30;
    gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
    this.Column6.DefaultCellStyle = gridViewCellStyle2;
    this.Column6.HeaderText = "通道";
    this.Column6.Name = "Column6";
    this.Column6.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.Column6.Width = 45;
    this.Column2.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    this.Column2.DisplayStyleForCurrentCellOnly = true;
    this.Column2.FlatStyle = FlatStyle.Flat;
    this.Column2.HeaderText = "方向";
    this.Column2.Items.AddRange((object) "发送", (object) "接收");
    this.Column2.Name = "Column2";
    this.Column2.Width = 85;
    gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.Column3.DefaultCellStyle = gridViewCellStyle3;
    this.Column3.HeaderText = "ID";
    this.Column3.Name = "Column3";
    this.Column3.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.Column3.Width = 60;
    this.Column4.HeaderText = "数据(Hex)";
    this.Column4.Name = "Column4";
    this.Column4.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.Column4.Width = 225;
    gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
    this.Column7.DefaultCellStyle = gridViewCellStyle4;
    this.Column7.HeaderText = "长度";
    this.Column7.Name = "Column7";
    this.Column7.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.Column7.Width = 65;
    gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
    this.Column5.DefaultCellStyle = gridViewCellStyle5;
    this.Column5.HeaderText = "帧间隔(ms)";
    this.Column5.Name = "Column5";
    this.Column5.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.Column5.Width = 88;
    ((Control) this.bar1).Controls.Add((Control) this.label39);
    this.bar1.Location = new System.Drawing.Point(0, 266);
    ((Control) this.bar1).Margin = new System.Windows.Forms.Padding(0);
    this.bar1.Name = "bar1";
    this.bar1.Size = new System.Drawing.Size(892, 25);
    this.bar1.Stretch = true;
    this.bar1.Style = eDotNetBarStyle.Office2003;
    this.bar1.TabIndex = 44;
    this.bar1.TabStop = false;
    ((Control) this.bar1).Text = "bar1";
    this.label39.AutoSize = true;
    this.label39.BackColor = Color.Transparent;
    this.label39.Font = new Font("微软雅黑", 10.5f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    this.label39.ForeColor = Color.Black;
    this.label39.Location = new System.Drawing.Point(2, 2);
    this.label39.Name = "label39";
    this.label39.Size = new System.Drawing.Size(84, 20);
    this.label39.TabIndex = 9;
    this.label39.Text = "参数设置：";
    this.tabPage3.BackColor = SystemColors.ActiveCaption;
    this.tabPage3.Controls.Add((Control) this.listViewNF3);
    this.tabPage3.Controls.Add((Control) this.myPanel1);
    this.tabPage3.Controls.Add((Control) this.bar3);
    this.tabPage3.Controls.Add((Control) this.dataGridViewX2);
    this.tabPage3.Controls.Add((Control) this.bar4);
    this.tabPage3.Location = new System.Drawing.Point(4, 22);
    this.tabPage3.Name = "tabPage3";
    this.tabPage3.Size = new System.Drawing.Size(892, 554);
    this.tabPage3.TabIndex = 6;
    this.tabPage3.Text = "从机模式";
    this.listViewNF3.BackColor = Color.RoyalBlue;
    this.listViewNF3.BorderStyle = BorderStyle.None;
    this.listViewNF3.Columns.AddRange(new ColumnHeader[9]
    {
      this.columnHeader18,
      this.columnHeader19,
      this.columnHeader20,
      this.columnHeader21,
      this.columnHeader22,
      this.columnHeader23,
      this.columnHeader24,
      this.columnHeader25,
      this.columnHeader27
    });
    this.listViewNF3.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.listViewNF3.ForeColor = Color.White;
    this.listViewNF3.FullRowSelect = true;
    this.listViewNF3.HideSelection = false;
    this.listViewNF3.Location = new System.Drawing.Point(0, 8);
    this.listViewNF3.Margin = new System.Windows.Forms.Padding(0);
    this.listViewNF3.MultiSelect = false;
    this.listViewNF3.Name = "listViewNF3";
    this.listViewNF3.Size = new System.Drawing.Size(892, 258);
    this.listViewNF3.TabIndex = 53;
    this.listViewNF3.UseCompatibleStateImageBehavior = false;
    this.listViewNF3.View = View.Details;
    this.columnHeader18.Text = "序号";
    this.columnHeader19.Text = "通道";
    this.columnHeader19.TextAlign = HorizontalAlignment.Center;
    this.columnHeader19.Width = 50;
    this.columnHeader20.Text = "方向";
    this.columnHeader20.TextAlign = HorizontalAlignment.Center;
    this.columnHeader20.Width = 70;
    this.columnHeader21.Text = "时间";
    this.columnHeader21.Width = 160 /*0xA0*/;
    this.columnHeader22.Text = "ID[PID]";
    this.columnHeader22.TextAlign = HorizontalAlignment.Center;
    this.columnHeader22.Width = 80 /*0x50*/;
    this.columnHeader23.Text = "数据长度";
    this.columnHeader23.TextAlign = HorizontalAlignment.Center;
    this.columnHeader23.Width = 70;
    this.columnHeader24.Text = "数据(Hex)";
    this.columnHeader24.Width = 210;
    this.columnHeader25.Text = "校验(Hex)";
    this.columnHeader25.TextAlign = HorizontalAlignment.Center;
    this.columnHeader25.Width = 80 /*0x50*/;
    this.columnHeader27.Text = "状态";
    this.columnHeader27.TextAlign = HorizontalAlignment.Center;
    this.columnHeader27.Width = 80 /*0x50*/;
    ((Control) this.myPanel1).BackColor = SystemColors.GradientInactiveCaption;
    ((Control) this.myPanel1).Controls.Add((Control) this.dS按钮4);
    ((Control) this.myPanel1).Controls.Add((Control) this.dS按钮3);
    ((Control) this.myPanel1).Controls.Add((Control) this.imageButton12);
    ((Control) this.myPanel1).Controls.Add((Control) this.imageButton11);
    ((Control) this.myPanel1).Controls.Add((Control) this.groupBoxEx1);
    ((Control) this.myPanel1).Location = new System.Drawing.Point(618, 291);
    ((Control) this.myPanel1).Margin = new System.Windows.Forms.Padding(0);
    ((Control) this.myPanel1).Name = "myPanel1";
    ((Control) this.myPanel1).Size = new System.Drawing.Size(274, 238);
    ((Control) this.myPanel1).TabIndex = 52;
    this.dS按钮4.BackColor = Color.Transparent;
    this.dS按钮4.BackgroundImage = (Image) componentResourceManager.GetObject("dS按钮4.BackgroundImage");
    this.dS按钮4.Cursor = Cursors.Default;
    this.dS按钮4.DialogResult = DialogResult.None;
    this.dS按钮4.ForeColor = Color.White;
    this.dS按钮4.Location = new System.Drawing.Point(173, 143);
    this.dS按钮4.Margin = new System.Windows.Forms.Padding(1);
    this.dS按钮4.Name = "dS按钮4";
    this.dS按钮4.Size = new System.Drawing.Size(75, 75);
    this.dS按钮4.TabIndex = 53;
    this.dS按钮4.图像 = (Bitmap) null;
    this.dS按钮4.异形透明度采样百分比 = 0.1f;
    进度条3.指示进度 = 0.0f;
    进度条3.进度条颜色 = Color.DodgerBlue;
    this.dS按钮4.指示进度条 = 进度条3;
    this.dS按钮4.文本 = "";
    this.dS按钮4.禁用时透明度 = 0.3f;
    this.dS按钮4.自动尺寸扩展 = new System.Drawing.Size(20, 20);
    this.dS按钮4.自定义图像.按下 = (Bitmap) null;
    this.dS按钮4.自定义图像.禁用 = (Bitmap) null;
    this.dS按钮4.自定义图像.高亮 = (Bitmap) null;
    this.dS按钮4.自定义图像.默认 = (Bitmap) null;
    this.dS按钮4.贴图 = (Bitmap) componentResourceManager.GetObject("dS按钮4.贴图");
    this.dS按钮4.贴图切割边距.上 = 0;
    this.dS按钮4.贴图切割边距.下 = 0;
    this.dS按钮4.贴图切割边距.右 = 0;
    this.dS按钮4.贴图切割边距.左 = 0;
    this.dS按钮4.贴图模式 = DS按钮._贴图模式.贴图;
    this.dS按钮4.透明度 = 1f;
    this.dS按钮4.附加内容字体 = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS按钮4.ButtonClick += new DS按钮.ButtonClickEventHandler(this.dS按钮4_ButtonClick);
    this.dS按钮3.BackColor = Color.Transparent;
    this.dS按钮3.BackgroundImage = (Image) componentResourceManager.GetObject("dS按钮3.BackgroundImage");
    this.dS按钮3.Cursor = Cursors.Default;
    this.dS按钮3.DialogResult = DialogResult.None;
    this.dS按钮3.ForeColor = Color.White;
    this.dS按钮3.Location = new System.Drawing.Point(32 /*0x20*/, 143);
    this.dS按钮3.Margin = new System.Windows.Forms.Padding(1);
    this.dS按钮3.Name = "dS按钮3";
    this.dS按钮3.Size = new System.Drawing.Size(75, 75);
    this.dS按钮3.TabIndex = 52;
    this.dS按钮3.TabStop = false;
    this.dS按钮3.图像 = (Bitmap) null;
    this.dS按钮3.异形透明度采样百分比 = 0.1f;
    进度条4.指示进度 = 0.0f;
    进度条4.进度条颜色 = Color.DodgerBlue;
    this.dS按钮3.指示进度条 = 进度条4;
    this.dS按钮3.文本 = "";
    this.dS按钮3.禁用时透明度 = 0.3f;
    this.dS按钮3.自动尺寸扩展 = new System.Drawing.Size(20, 20);
    this.dS按钮3.自定义图像.按下 = (Bitmap) null;
    this.dS按钮3.自定义图像.禁用 = (Bitmap) null;
    this.dS按钮3.自定义图像.高亮 = (Bitmap) null;
    this.dS按钮3.自定义图像.默认 = (Bitmap) null;
    this.dS按钮3.贴图 = (Bitmap) componentResourceManager.GetObject("dS按钮3.贴图");
    this.dS按钮3.贴图切割边距.上 = 0;
    this.dS按钮3.贴图切割边距.下 = 0;
    this.dS按钮3.贴图切割边距.右 = 0;
    this.dS按钮3.贴图切割边距.左 = 0;
    this.dS按钮3.贴图模式 = DS按钮._贴图模式.贴图;
    this.dS按钮3.透明度 = 1f;
    this.dS按钮3.附加内容字体 = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS按钮3.ButtonClick += new DS按钮.ButtonClickEventHandler(this.dS按钮3_ButtonClick);
    this.imageButton12.BackColor = Color.Transparent;
    this.imageButton12.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton12.DownImage = (Image) componentResourceManager.GetObject("imageButton12.DownImage");
    this.imageButton12.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton12.ForeColor = SystemColors.InfoText;
    this.imageButton12.Image = (Image) componentResourceManager.GetObject("imageButton12.Image");
    this.imageButton12.IsShowBorder = false;
    this.imageButton12.Location = new System.Drawing.Point(179, 9);
    this.imageButton12.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton12.MoveImage = (Image) componentResourceManager.GetObject("imageButton12.MoveImage");
    this.imageButton12.Name = "imageButton12";
    this.imageButton12.NormalImage = (Image) componentResourceManager.GetObject("imageButton12.NormalImage");
    this.imageButton12.Size = new System.Drawing.Size(69, 32 /*0x20*/);
    this.imageButton12.TabIndex = 51;
    this.imageButton12.Text = "保存数据";
    this.imageButton12.UseVisualStyleBackColor = false;
    this.imageButton12.Click += new EventHandler(this.imageButton12_Click);
    this.imageButton11.BackColor = Color.Transparent;
    this.imageButton11.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton11.DownImage = (Image) componentResourceManager.GetObject("imageButton11.DownImage");
    this.imageButton11.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton11.ForeColor = SystemColors.InfoText;
    this.imageButton11.Image = (Image) componentResourceManager.GetObject("imageButton11.Image");
    this.imageButton11.IsShowBorder = false;
    this.imageButton11.Location = new System.Drawing.Point(32 /*0x20*/, 9);
    this.imageButton11.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton11.MoveImage = (Image) componentResourceManager.GetObject("imageButton11.MoveImage");
    this.imageButton11.Name = "imageButton11";
    this.imageButton11.NormalImage = (Image) componentResourceManager.GetObject("imageButton11.NormalImage");
    this.imageButton11.Size = new System.Drawing.Size(69, 32 /*0x20*/);
    this.imageButton11.TabIndex = 50;
    this.imageButton11.Text = "清除显示";
    this.imageButton11.UseVisualStyleBackColor = false;
    this.imageButton11.Click += new EventHandler(this.imageButton11_Click);
    this.groupBoxEx1.BackgroundImage = (Image) componentResourceManager.GetObject("groupBoxEx1.BackgroundImage");
    this.groupBoxEx1.BackgroundImageLayout = ImageLayout.Stretch;
    this.groupBoxEx1.BorderColor = Color.Green;
    this.groupBoxEx1.Controls.Add((Control) this.qqRadioButton10);
    this.groupBoxEx1.Controls.Add((Control) this.qqRadioButton9);
    this.groupBoxEx1.Location = new System.Drawing.Point(35, 57);
    this.groupBoxEx1.Name = "groupBoxEx1";
    this.groupBoxEx1.Size = new System.Drawing.Size(213, 68);
    this.groupBoxEx1.TabIndex = 41;
    this.groupBoxEx1.TabStop = false;
    this.groupBoxEx1.Text = "显示模式选择：";
    this.qqRadioButton10.AutoSize = true;
    this.qqRadioButton10.BackColor = Color.Transparent;
    this.qqRadioButton10.Font = new Font("宋体", 9f);
    this.qqRadioButton10.Location = new System.Drawing.Point(121, 30);
    this.qqRadioButton10.Name = "qqRadioButton10";
    this.qqRadioButton10.Size = new System.Drawing.Size(71, 16 /*0x10*/);
    this.qqRadioButton10.TabIndex = 32 /*0x20*/;
    this.qqRadioButton10.Text = "静态显示";
    this.qqRadioButton10.UseVisualStyleBackColor = false;
    this.qqRadioButton9.AutoSize = true;
    this.qqRadioButton9.BackColor = Color.Transparent;
    this.qqRadioButton9.Checked = true;
    this.qqRadioButton9.Font = new Font("宋体", 9f);
    this.qqRadioButton9.Location = new System.Drawing.Point(15, 30);
    this.qqRadioButton9.Name = "qqRadioButton9";
    this.qqRadioButton9.Size = new System.Drawing.Size(71, 16 /*0x10*/);
    this.qqRadioButton9.TabIndex = 31 /*0x1F*/;
    this.qqRadioButton9.TabStop = true;
    this.qqRadioButton9.Text = "动态显示";
    this.qqRadioButton9.UseVisualStyleBackColor = false;
    this.qqRadioButton9.CheckedChanged += new EventHandler(this.qqRadioButton9_CheckedChanged);
    this.bar3.Location = new System.Drawing.Point(0, 529);
    ((Control) this.bar3).Margin = new System.Windows.Forms.Padding(0);
    this.bar3.Name = "bar3";
    this.bar3.Size = new System.Drawing.Size(892, 25);
    this.bar3.Stretch = true;
    this.bar3.Style = eDotNetBarStyle.Office2003;
    this.bar3.TabIndex = 51;
    this.bar3.TabStop = false;
    ((Control) this.bar3).Text = "bar3";
    ((DataGridView) this.dataGridViewX2).AllowUserToDeleteRows = false;
    ((DataGridView) this.dataGridViewX2).BackgroundColor = SystemColors.ActiveCaption;
    ((DataGridView) this.dataGridViewX2).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
    ((DataGridView) this.dataGridViewX2).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
    ((DataGridView) this.dataGridViewX2).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    ((DataGridView) this.dataGridViewX2).Columns.AddRange((DataGridViewColumn) this.dataGridViewCheckBoxColumn1, (DataGridViewColumn) this.dataGridViewTextBoxColumn1, (DataGridViewColumn) this.dataGridViewComboBoxColumn1, (DataGridViewColumn) this.dataGridViewTextBoxColumn2, (DataGridViewColumn) this.dataGridViewTextBoxColumn3, (DataGridViewColumn) this.dataGridViewTextBoxColumn4, (DataGridViewColumn) this.dataGridViewTextBoxColumn5);
    gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle6.BackColor = SystemColors.Window;
    gridViewCellStyle6.Font = new Font("宋体", 9f);
    gridViewCellStyle6.ForeColor = SystemColors.ControlText;
    gridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle6.SelectionForeColor = SystemColors.ControlText;
    gridViewCellStyle6.WrapMode = DataGridViewTriState.False;
    ((DataGridView) this.dataGridViewX2).DefaultCellStyle = gridViewCellStyle6;
    ((DataGridView) this.dataGridViewX2).EditMode = DataGridViewEditMode.EditOnEnter;
    ((DataGridView) this.dataGridViewX2).GridColor = Color.FromArgb(208 /*0xD0*/, 215, 229);
    ((Control) this.dataGridViewX2).Location = new System.Drawing.Point(-3, 291);
    ((Control) this.dataGridViewX2).Margin = new System.Windows.Forms.Padding(0);
    ((DataGridView) this.dataGridViewX2).MultiSelect = false;
    ((Control) this.dataGridViewX2).Name = "dataGridViewX2";
    ((DataGridView) this.dataGridViewX2).RowHeadersVisible = false;
    ((DataGridView) this.dataGridViewX2).RowTemplate.Height = 23;
    ((DataGridView) this.dataGridViewX2).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    ((DataGridView) this.dataGridViewX2).ShowCellToolTips = false;
    ((Control) this.dataGridViewX2).Size = new System.Drawing.Size(621, 239);
    ((Control) this.dataGridViewX2).TabIndex = 50;
    this.dataGridViewCheckBoxColumn1.HeaderText = "    ";
    this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
    this.dataGridViewCheckBoxColumn1.Width = 30;
    gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
    this.dataGridViewTextBoxColumn1.DefaultCellStyle = gridViewCellStyle7;
    this.dataGridViewTextBoxColumn1.HeaderText = "通道";
    this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
    this.dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn1.Width = 45;
    this.dataGridViewComboBoxColumn1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    this.dataGridViewComboBoxColumn1.DisplayStyleForCurrentCellOnly = true;
    this.dataGridViewComboBoxColumn1.FlatStyle = FlatStyle.Flat;
    this.dataGridViewComboBoxColumn1.HeaderText = "方向";
    this.dataGridViewComboBoxColumn1.Items.AddRange((object) "发送", (object) "接收");
    this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
    this.dataGridViewComboBoxColumn1.Width = 85;
    gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewTextBoxColumn2.DefaultCellStyle = gridViewCellStyle8;
    this.dataGridViewTextBoxColumn2.HeaderText = "ID";
    this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
    this.dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn2.Width = 60;
    this.dataGridViewTextBoxColumn3.HeaderText = "数据(Hex)";
    this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
    this.dataGridViewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn3.Width = 225;
    gridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewTextBoxColumn4.DefaultCellStyle = gridViewCellStyle9;
    this.dataGridViewTextBoxColumn4.HeaderText = "长度";
    this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
    this.dataGridViewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn4.Width = 65;
    gridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
    this.dataGridViewTextBoxColumn5.DefaultCellStyle = gridViewCellStyle10;
    this.dataGridViewTextBoxColumn5.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    this.dataGridViewTextBoxColumn5.DisplayStyleForCurrentCellOnly = true;
    this.dataGridViewTextBoxColumn5.FlatStyle = FlatStyle.Flat;
    this.dataGridViewTextBoxColumn5.HeaderText = "校验和类型";
    this.dataGridViewTextBoxColumn5.Items.AddRange((object) "增强型校验和", (object) "标准型校验和");
    this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
    this.dataGridViewTextBoxColumn5.Resizable = DataGridViewTriState.True;
    this.dataGridViewTextBoxColumn5.Width = 88;
    ((Control) this.bar4).Controls.Add((Control) this.label4);
    this.bar4.Location = new System.Drawing.Point(0, 266);
    ((Control) this.bar4).Margin = new System.Windows.Forms.Padding(0);
    this.bar4.Name = "bar4";
    this.bar4.Size = new System.Drawing.Size(892, 25);
    this.bar4.Stretch = true;
    this.bar4.Style = eDotNetBarStyle.Office2003;
    this.bar4.TabIndex = 49;
    this.bar4.TabStop = false;
    ((Control) this.bar4).Text = "bar4";
    this.label4.AutoSize = true;
    this.label4.BackColor = Color.Transparent;
    this.label4.Font = new Font("微软雅黑", 10.5f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    this.label4.ForeColor = Color.Black;
    this.label4.Location = new System.Drawing.Point(2, 2);
    this.label4.Name = "label4";
    this.label4.Size = new System.Drawing.Size(84, 20);
    this.label4.TabIndex = 9;
    this.label4.Text = "参数设置：";
    this.tabPage4.BackColor = SystemColors.ActiveCaption;
    this.tabPage4.Controls.Add((Control) this.myPanel15);
    this.tabPage4.Controls.Add((Control) this.myPanel14);
    this.tabPage4.Controls.Add((Control) this.listViewNF4);
    this.tabPage4.Location = new System.Drawing.Point(4, 22);
    this.tabPage4.Name = "tabPage4";
    this.tabPage4.Size = new System.Drawing.Size(892, 554);
    this.tabPage4.TabIndex = 2;
    this.tabPage4.Text = "监听模式";
    ((Control) this.myPanel15).BackColor = SystemColors.ActiveCaption;
    ((Control) this.myPanel15).BackgroundImageLayout = ImageLayout.Stretch;
    ((Control) this.myPanel15).Controls.Add((Control) this.dS按钮6);
    ((Control) this.myPanel15).Controls.Add((Control) this.dS按钮5);
    ((Control) this.myPanel15).Controls.Add((Control) this.groupBoxEx2);
    ((Control) this.myPanel15).Controls.Add((Control) this.groupBoxEx5);
    ((Control) this.myPanel15).Controls.Add((Control) this.label38);
    ((Control) this.myPanel15).Location = new System.Drawing.Point(0, 406);
    ((Control) this.myPanel15).Margin = new System.Windows.Forms.Padding(0);
    ((Control) this.myPanel15).Name = "myPanel15";
    ((Control) this.myPanel15).Size = new System.Drawing.Size(892, 148);
    ((Control) this.myPanel15).TabIndex = 51;
    this.dS按钮6.BackColor = Color.Transparent;
    this.dS按钮6.BackgroundImage = (Image) componentResourceManager.GetObject("dS按钮6.BackgroundImage");
    this.dS按钮6.Cursor = Cursors.Default;
    this.dS按钮6.DialogResult = DialogResult.None;
    this.dS按钮6.ForeColor = Color.White;
    this.dS按钮6.Location = new System.Drawing.Point(767 /*0x02FF*/, 52);
    this.dS按钮6.Margin = new System.Windows.Forms.Padding(1);
    this.dS按钮6.Name = "dS按钮6";
    this.dS按钮6.Size = new System.Drawing.Size(75, 75);
    this.dS按钮6.TabIndex = 55;
    this.dS按钮6.图像 = (Bitmap) null;
    this.dS按钮6.异形透明度采样百分比 = 0.1f;
    进度条5.指示进度 = 0.0f;
    进度条5.进度条颜色 = Color.DodgerBlue;
    this.dS按钮6.指示进度条 = 进度条5;
    this.dS按钮6.文本 = "";
    this.dS按钮6.禁用时透明度 = 0.3f;
    this.dS按钮6.自动尺寸扩展 = new System.Drawing.Size(20, 20);
    this.dS按钮6.自定义图像.按下 = (Bitmap) null;
    this.dS按钮6.自定义图像.禁用 = (Bitmap) null;
    this.dS按钮6.自定义图像.高亮 = (Bitmap) null;
    this.dS按钮6.自定义图像.默认 = (Bitmap) null;
    this.dS按钮6.贴图 = (Bitmap) componentResourceManager.GetObject("dS按钮6.贴图");
    this.dS按钮6.贴图切割边距.上 = 0;
    this.dS按钮6.贴图切割边距.下 = 0;
    this.dS按钮6.贴图切割边距.右 = 0;
    this.dS按钮6.贴图切割边距.左 = 0;
    this.dS按钮6.贴图模式 = DS按钮._贴图模式.贴图;
    this.dS按钮6.透明度 = 1f;
    this.dS按钮6.附加内容字体 = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS按钮6.ButtonClick += new DS按钮.ButtonClickEventHandler(this.dS按钮6_ButtonClick);
    this.dS按钮5.BackColor = Color.Transparent;
    this.dS按钮5.BackgroundImage = (Image) componentResourceManager.GetObject("dS按钮5.BackgroundImage");
    this.dS按钮5.Cursor = Cursors.Default;
    this.dS按钮5.DialogResult = DialogResult.None;
    this.dS按钮5.ForeColor = Color.White;
    this.dS按钮5.Location = new System.Drawing.Point(626, 52);
    this.dS按钮5.Margin = new System.Windows.Forms.Padding(1);
    this.dS按钮5.Name = "dS按钮5";
    this.dS按钮5.Size = new System.Drawing.Size(75, 75);
    this.dS按钮5.TabIndex = 54;
    this.dS按钮5.TabStop = false;
    this.dS按钮5.图像 = (Bitmap) null;
    this.dS按钮5.异形透明度采样百分比 = 0.1f;
    进度条6.指示进度 = 0.0f;
    进度条6.进度条颜色 = Color.DodgerBlue;
    this.dS按钮5.指示进度条 = 进度条6;
    this.dS按钮5.文本 = "";
    this.dS按钮5.禁用时透明度 = 0.3f;
    this.dS按钮5.自动尺寸扩展 = new System.Drawing.Size(20, 20);
    this.dS按钮5.自定义图像.按下 = (Bitmap) null;
    this.dS按钮5.自定义图像.禁用 = (Bitmap) null;
    this.dS按钮5.自定义图像.高亮 = (Bitmap) null;
    this.dS按钮5.自定义图像.默认 = (Bitmap) null;
    this.dS按钮5.贴图 = (Bitmap) componentResourceManager.GetObject("dS按钮5.贴图");
    this.dS按钮5.贴图切割边距.上 = 0;
    this.dS按钮5.贴图切割边距.下 = 0;
    this.dS按钮5.贴图切割边距.右 = 0;
    this.dS按钮5.贴图切割边距.左 = 0;
    this.dS按钮5.贴图模式 = DS按钮._贴图模式.贴图;
    this.dS按钮5.透明度 = 1f;
    this.dS按钮5.附加内容字体 = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS按钮5.ButtonClick += new DS按钮.ButtonClickEventHandler(this.dS按钮5_ButtonClick);
    this.groupBoxEx2.BorderColor = Color.Green;
    this.groupBoxEx2.Controls.Add((Control) this.qqRadioButton14);
    this.groupBoxEx2.Controls.Add((Control) this.qqRadioButton13);
    this.groupBoxEx2.Location = new System.Drawing.Point(306, 59);
    this.groupBoxEx2.Name = "groupBoxEx2";
    this.groupBoxEx2.Size = new System.Drawing.Size(213, 68);
    this.groupBoxEx2.TabIndex = 40;
    this.groupBoxEx2.TabStop = false;
    this.groupBoxEx2.Text = "显示模式选择：";
    this.qqRadioButton14.AutoSize = true;
    this.qqRadioButton14.BackColor = Color.Transparent;
    this.qqRadioButton14.Font = new Font("宋体", 9f);
    this.qqRadioButton14.Location = new System.Drawing.Point(125, 30);
    this.qqRadioButton14.Name = "qqRadioButton14";
    this.qqRadioButton14.Size = new System.Drawing.Size(71, 16 /*0x10*/);
    this.qqRadioButton14.TabIndex = 32 /*0x20*/;
    this.qqRadioButton14.Text = "静态显示";
    this.qqRadioButton14.UseVisualStyleBackColor = false;
    this.qqRadioButton13.AutoSize = true;
    this.qqRadioButton13.BackColor = Color.Transparent;
    this.qqRadioButton13.Checked = true;
    this.qqRadioButton13.Font = new Font("宋体", 9f);
    this.qqRadioButton13.Location = new System.Drawing.Point(15, 30);
    this.qqRadioButton13.Name = "qqRadioButton13";
    this.qqRadioButton13.Size = new System.Drawing.Size(71, 16 /*0x10*/);
    this.qqRadioButton13.TabIndex = 31 /*0x1F*/;
    this.qqRadioButton13.TabStop = true;
    this.qqRadioButton13.Text = "动态显示";
    this.qqRadioButton13.UseVisualStyleBackColor = false;
    this.qqRadioButton13.CheckedChanged += new EventHandler(this.qqRadioButton13_CheckedChanged);
    this.groupBoxEx5.BorderColor = Color.Maroon;
    this.groupBoxEx5.Controls.Add((Control) this.qqRadioButton12);
    this.groupBoxEx5.Controls.Add((Control) this.qqRadioButton11);
    this.groupBoxEx5.Location = new System.Drawing.Point(27, 59);
    this.groupBoxEx5.Name = "groupBoxEx5";
    this.groupBoxEx5.Size = new System.Drawing.Size(213, 68);
    this.groupBoxEx5.TabIndex = 39;
    this.groupBoxEx5.TabStop = false;
    this.groupBoxEx5.Text = "监听模式选择：";
    this.qqRadioButton12.AutoSize = true;
    this.qqRadioButton12.BackColor = Color.Transparent;
    this.qqRadioButton12.Font = new Font("宋体", 9f);
    this.qqRadioButton12.Location = new System.Drawing.Point(124, 30);
    this.qqRadioButton12.Name = "qqRadioButton12";
    this.qqRadioButton12.Size = new System.Drawing.Size(71, 16 /*0x10*/);
    this.qqRadioButton12.TabIndex = 34;
    this.qqRadioButton12.Text = "总线监听";
    this.qqRadioButton12.UseVisualStyleBackColor = false;
    this.qqRadioButton11.AutoSize = true;
    this.qqRadioButton11.BackColor = Color.Transparent;
    this.qqRadioButton11.Checked = true;
    this.qqRadioButton11.Font = new Font("宋体", 9f);
    this.qqRadioButton11.Location = new System.Drawing.Point(15, 30);
    this.qqRadioButton11.Name = "qqRadioButton11";
    this.qqRadioButton11.Size = new System.Drawing.Size(59, 16 /*0x10*/);
    this.qqRadioButton11.TabIndex = 33;
    this.qqRadioButton11.TabStop = true;
    this.qqRadioButton11.Text = "固定ID";
    this.qqRadioButton11.UseVisualStyleBackColor = false;
    this.qqRadioButton11.CheckedChanged += new EventHandler(this.qqRadioButton11_CheckedChanged_1);
    this.label38.AutoSize = true;
    this.label38.BackColor = Color.Transparent;
    this.label38.Font = new Font("微软雅黑", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    this.label38.ForeColor = Color.Black;
    this.label38.Location = new System.Drawing.Point(20, 13);
    this.label38.Margin = new System.Windows.Forms.Padding(0);
    this.label38.Name = "label38";
    this.label38.Size = new System.Drawing.Size(172, 25);
    this.label38.TabIndex = 8;
    this.label38.Text = "监听参数设置区：";
    ((Control) this.myPanel14).BackColor = SystemColors.ActiveCaption;
    ((Control) this.myPanel14).BackgroundImage = (Image) componentResourceManager.GetObject("myPanel14.BackgroundImage");
    ((Control) this.myPanel14).BackgroundImageLayout = ImageLayout.Stretch;
    ((Control) this.myPanel14).Controls.Add((Control) this.imageButton14);
    ((Control) this.myPanel14).Controls.Add((Control) this.imageButton13);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqTextBox29);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqCheckBox18);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqTextBox28);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqCheckBox16);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqTextBox26);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqTextBox25);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqCheckBox15);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqCheckBox14);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqCheckBox13);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqCheckBox17);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqTextBox27);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqTextBox24);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqTextBox23);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqCheckBox12);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqTextBox22);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqCheckBox10);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqCheckBox11);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqTextBox21);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqTextBox20);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqCheckBox9);
    ((Control) this.myPanel14).Controls.Add((Control) this.label16);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqTextBox19);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqCheckBox7);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqCheckBox8);
    ((Control) this.myPanel14).Controls.Add((Control) this.qqTextBox18);
    ((Control) this.myPanel14).Location = new System.Drawing.Point(0, 266);
    ((Control) this.myPanel14).Margin = new System.Windows.Forms.Padding(0);
    ((Control) this.myPanel14).Name = "myPanel14";
    ((Control) this.myPanel14).Size = new System.Drawing.Size(892, 140);
    ((Control) this.myPanel14).TabIndex = 50;
    this.imageButton14.BackColor = Color.Transparent;
    this.imageButton14.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton14.DownImage = (Image) componentResourceManager.GetObject("imageButton14.DownImage");
    this.imageButton14.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton14.ForeColor = SystemColors.InfoText;
    this.imageButton14.Image = (Image) componentResourceManager.GetObject("imageButton14.Image");
    this.imageButton14.IsShowBorder = false;
    this.imageButton14.Location = new System.Drawing.Point(777, 13);
    this.imageButton14.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton14.MoveImage = (Image) componentResourceManager.GetObject("imageButton14.MoveImage");
    this.imageButton14.Name = "imageButton14";
    this.imageButton14.NormalImage = (Image) componentResourceManager.GetObject("imageButton14.NormalImage");
    this.imageButton14.Size = new System.Drawing.Size(69, 32 /*0x20*/);
    this.imageButton14.TabIndex = 53;
    this.imageButton14.Text = "保存数据";
    this.imageButton14.UseVisualStyleBackColor = false;
    this.imageButton14.Click += new EventHandler(this.imageButton14_Click);
    this.imageButton13.BackColor = Color.Transparent;
    this.imageButton13.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton13.DownImage = (Image) componentResourceManager.GetObject("imageButton13.DownImage");
    this.imageButton13.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton13.ForeColor = SystemColors.InfoText;
    this.imageButton13.Image = (Image) componentResourceManager.GetObject("imageButton13.Image");
    this.imageButton13.IsShowBorder = false;
    this.imageButton13.Location = new System.Drawing.Point(644, 13);
    this.imageButton13.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton13.MoveImage = (Image) componentResourceManager.GetObject("imageButton13.MoveImage");
    this.imageButton13.Name = "imageButton13";
    this.imageButton13.NormalImage = (Image) componentResourceManager.GetObject("imageButton13.NormalImage");
    this.imageButton13.Size = new System.Drawing.Size(69, 32 /*0x20*/);
    this.imageButton13.TabIndex = 52;
    this.imageButton13.Text = "清除显示";
    this.imageButton13.UseVisualStyleBackColor = false;
    this.imageButton13.Click += new EventHandler(this.imageButton13_Click);
    this.qqTextBox29.BackColor = Color.White;
    this.qqTextBox29.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox29.EmptyTextTip = (string) null;
    this.qqTextBox29.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox29.Font = new Font("宋体", 9f);
    this.qqTextBox29.Location = new System.Drawing.Point(787, 102);
    this.qqTextBox29.MaxLength = 2;
    this.qqTextBox29.Name = "qqTextBox29";
    this.qqTextBox29.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox29.TabIndex = 42;
    this.qqTextBox29.Text = "00";
    this.qqTextBox29.TextAlign = HorizontalAlignment.Center;
    this.qqCheckBox18.AutoSize = true;
    this.qqCheckBox18.BackColor = Color.Transparent;
    this.qqCheckBox18.Font = new Font("宋体", 9f);
    this.qqCheckBox18.Location = new System.Drawing.Point(742, 104);
    this.qqCheckBox18.Name = "qqCheckBox18";
    this.qqCheckBox18.Size = new System.Drawing.Size(42, 16 /*0x10*/);
    this.qqCheckBox18.TabIndex = 43;
    this.qqCheckBox18.Text = "ID:";
    this.qqCheckBox18.UseVisualStyleBackColor = false;
    this.qqTextBox28.BackColor = Color.White;
    this.qqTextBox28.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox28.EmptyTextTip = (string) null;
    this.qqTextBox28.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox28.Font = new Font("宋体", 9f);
    this.qqTextBox28.Location = new System.Drawing.Point(644, 102);
    this.qqTextBox28.MaxLength = 2;
    this.qqTextBox28.Name = "qqTextBox28";
    this.qqTextBox28.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox28.TabIndex = 40;
    this.qqTextBox28.Text = "00";
    this.qqTextBox28.TextAlign = HorizontalAlignment.Center;
    this.qqCheckBox16.AutoSize = true;
    this.qqCheckBox16.BackColor = Color.Transparent;
    this.qqCheckBox16.Font = new Font("宋体", 9f);
    this.qqCheckBox16.Location = new System.Drawing.Point(456, 104);
    this.qqCheckBox16.Name = "qqCheckBox16";
    this.qqCheckBox16.Size = new System.Drawing.Size(42, 16 /*0x10*/);
    this.qqCheckBox16.TabIndex = 39;
    this.qqCheckBox16.Text = "ID:";
    this.qqCheckBox16.UseVisualStyleBackColor = false;
    this.qqTextBox26.BackColor = Color.White;
    this.qqTextBox26.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox26.EmptyTextTip = (string) null;
    this.qqTextBox26.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox26.Font = new Font("宋体", 9f);
    this.qqTextBox26.Location = new System.Drawing.Point(358, 102);
    this.qqTextBox26.MaxLength = 2;
    this.qqTextBox26.Name = "qqTextBox26";
    this.qqTextBox26.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox26.TabIndex = 36;
    this.qqTextBox26.Text = "00";
    this.qqTextBox26.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox25.BackColor = Color.White;
    this.qqTextBox25.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox25.EmptyTextTip = (string) null;
    this.qqTextBox25.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox25.Font = new Font("宋体", 9f);
    this.qqTextBox25.Location = new System.Drawing.Point(215, 102);
    this.qqTextBox25.MaxLength = 2;
    this.qqTextBox25.Name = "qqTextBox25";
    this.qqTextBox25.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox25.TabIndex = 34;
    this.qqTextBox25.Text = "00";
    this.qqTextBox25.TextAlign = HorizontalAlignment.Center;
    this.qqCheckBox15.AutoSize = true;
    this.qqCheckBox15.BackColor = Color.Transparent;
    this.qqCheckBox15.Font = new Font("宋体", 9f);
    this.qqCheckBox15.Location = new System.Drawing.Point(313, 104);
    this.qqCheckBox15.Name = "qqCheckBox15";
    this.qqCheckBox15.Size = new System.Drawing.Size(42, 16 /*0x10*/);
    this.qqCheckBox15.TabIndex = 37;
    this.qqCheckBox15.Text = "ID:";
    this.qqCheckBox15.UseVisualStyleBackColor = false;
    this.qqCheckBox14.AutoSize = true;
    this.qqCheckBox14.BackColor = Color.Transparent;
    this.qqCheckBox14.Font = new Font("宋体", 9f);
    this.qqCheckBox14.Location = new System.Drawing.Point(170, 104);
    this.qqCheckBox14.Name = "qqCheckBox14";
    this.qqCheckBox14.Size = new System.Drawing.Size(42, 16 /*0x10*/);
    this.qqCheckBox14.TabIndex = 35;
    this.qqCheckBox14.Text = "ID:";
    this.qqCheckBox14.UseVisualStyleBackColor = false;
    this.qqCheckBox13.AutoSize = true;
    this.qqCheckBox13.BackColor = Color.Transparent;
    this.qqCheckBox13.Font = new Font("宋体", 9f);
    this.qqCheckBox13.Location = new System.Drawing.Point(27, 104);
    this.qqCheckBox13.Name = "qqCheckBox13";
    this.qqCheckBox13.Size = new System.Drawing.Size(42, 16 /*0x10*/);
    this.qqCheckBox13.TabIndex = 33;
    this.qqCheckBox13.Text = "ID:";
    this.qqCheckBox13.UseVisualStyleBackColor = false;
    this.qqCheckBox17.AutoSize = true;
    this.qqCheckBox17.BackColor = Color.Transparent;
    this.qqCheckBox17.Font = new Font("宋体", 9f);
    this.qqCheckBox17.Location = new System.Drawing.Point(599, 105);
    this.qqCheckBox17.Name = "qqCheckBox17";
    this.qqCheckBox17.Size = new System.Drawing.Size(42, 16 /*0x10*/);
    this.qqCheckBox17.TabIndex = 41;
    this.qqCheckBox17.Text = "ID:";
    this.qqCheckBox17.UseVisualStyleBackColor = false;
    this.qqTextBox27.BackColor = Color.White;
    this.qqTextBox27.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox27.EmptyTextTip = (string) null;
    this.qqTextBox27.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox27.Font = new Font("宋体", 9f);
    this.qqTextBox27.Location = new System.Drawing.Point(501, 102);
    this.qqTextBox27.MaxLength = 2;
    this.qqTextBox27.Name = "qqTextBox27";
    this.qqTextBox27.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox27.TabIndex = 38;
    this.qqTextBox27.Text = "00";
    this.qqTextBox27.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox24.BackColor = Color.White;
    this.qqTextBox24.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox24.EmptyTextTip = (string) null;
    this.qqTextBox24.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox24.Font = new Font("宋体", 9f);
    this.qqTextBox24.Location = new System.Drawing.Point(72, 102);
    this.qqTextBox24.MaxLength = 2;
    this.qqTextBox24.Name = "qqTextBox24";
    this.qqTextBox24.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox24.TabIndex = 32 /*0x20*/;
    this.qqTextBox24.Text = "00";
    this.qqTextBox24.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox23.BackColor = Color.White;
    this.qqTextBox23.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox23.EmptyTextTip = (string) null;
    this.qqTextBox23.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox23.Font = new Font("宋体", 9f);
    this.qqTextBox23.Location = new System.Drawing.Point(787, 53);
    this.qqTextBox23.MaxLength = 2;
    this.qqTextBox23.Name = "qqTextBox23";
    this.qqTextBox23.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox23.TabIndex = 30;
    this.qqTextBox23.Text = "00";
    this.qqTextBox23.TextAlign = HorizontalAlignment.Center;
    this.qqCheckBox12.AutoSize = true;
    this.qqCheckBox12.BackColor = Color.Transparent;
    this.qqCheckBox12.Font = new Font("宋体", 9f);
    this.qqCheckBox12.Location = new System.Drawing.Point(742, 55);
    this.qqCheckBox12.Name = "qqCheckBox12";
    this.qqCheckBox12.Size = new System.Drawing.Size(42, 16 /*0x10*/);
    this.qqCheckBox12.TabIndex = 31 /*0x1F*/;
    this.qqCheckBox12.Text = "ID:";
    this.qqCheckBox12.UseVisualStyleBackColor = false;
    this.qqTextBox22.BackColor = Color.White;
    this.qqTextBox22.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox22.EmptyTextTip = (string) null;
    this.qqTextBox22.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox22.Font = new Font("宋体", 9f);
    this.qqTextBox22.Location = new System.Drawing.Point(644, 53);
    this.qqTextBox22.MaxLength = 2;
    this.qqTextBox22.Name = "qqTextBox22";
    this.qqTextBox22.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox22.TabIndex = 28;
    this.qqTextBox22.Text = "00";
    this.qqTextBox22.TextAlign = HorizontalAlignment.Center;
    this.qqCheckBox10.AutoSize = true;
    this.qqCheckBox10.BackColor = Color.Transparent;
    this.qqCheckBox10.Font = new Font("宋体", 9f);
    this.qqCheckBox10.Location = new System.Drawing.Point(456, 55);
    this.qqCheckBox10.Name = "qqCheckBox10";
    this.qqCheckBox10.Size = new System.Drawing.Size(42, 16 /*0x10*/);
    this.qqCheckBox10.TabIndex = 27;
    this.qqCheckBox10.Text = "ID:";
    this.qqCheckBox10.UseVisualStyleBackColor = false;
    this.qqCheckBox11.AutoSize = true;
    this.qqCheckBox11.BackColor = Color.Transparent;
    this.qqCheckBox11.Font = new Font("宋体", 9f);
    this.qqCheckBox11.Location = new System.Drawing.Point(599, 56);
    this.qqCheckBox11.Name = "qqCheckBox11";
    this.qqCheckBox11.Size = new System.Drawing.Size(42, 16 /*0x10*/);
    this.qqCheckBox11.TabIndex = 29;
    this.qqCheckBox11.Text = "ID:";
    this.qqCheckBox11.UseVisualStyleBackColor = false;
    this.qqTextBox21.BackColor = Color.White;
    this.qqTextBox21.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox21.EmptyTextTip = (string) null;
    this.qqTextBox21.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox21.Font = new Font("宋体", 9f);
    this.qqTextBox21.Location = new System.Drawing.Point(501, 53);
    this.qqTextBox21.MaxLength = 2;
    this.qqTextBox21.Name = "qqTextBox21";
    this.qqTextBox21.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox21.TabIndex = 26;
    this.qqTextBox21.Text = "00";
    this.qqTextBox21.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox20.BackColor = Color.White;
    this.qqTextBox20.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox20.EmptyTextTip = (string) null;
    this.qqTextBox20.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox20.Font = new Font("宋体", 9f);
    this.qqTextBox20.Location = new System.Drawing.Point(358, 53);
    this.qqTextBox20.MaxLength = 2;
    this.qqTextBox20.Name = "qqTextBox20";
    this.qqTextBox20.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox20.TabIndex = 24;
    this.qqTextBox20.Text = "00";
    this.qqTextBox20.TextAlign = HorizontalAlignment.Center;
    this.qqCheckBox9.AutoSize = true;
    this.qqCheckBox9.BackColor = Color.Transparent;
    this.qqCheckBox9.Font = new Font("宋体", 9f);
    this.qqCheckBox9.Location = new System.Drawing.Point(313, 55);
    this.qqCheckBox9.Name = "qqCheckBox9";
    this.qqCheckBox9.Size = new System.Drawing.Size(42, 16 /*0x10*/);
    this.qqCheckBox9.TabIndex = 25;
    this.qqCheckBox9.Text = "ID:";
    this.qqCheckBox9.UseVisualStyleBackColor = false;
    this.label16.AutoSize = true;
    this.label16.BackColor = Color.Transparent;
    this.label16.Font = new Font("微软雅黑", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    this.label16.ForeColor = Color.Black;
    this.label16.Location = new System.Drawing.Point(20, 14);
    this.label16.Margin = new System.Windows.Forms.Padding(0);
    this.label16.Name = "label16";
    this.label16.Size = new System.Drawing.Size(154, 25);
    this.label16.TabIndex = 8;
    this.label16.Text = "固定ID设置区：";
    this.qqTextBox19.BackColor = Color.White;
    this.qqTextBox19.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox19.EmptyTextTip = (string) null;
    this.qqTextBox19.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox19.Font = new Font("宋体", 9f);
    this.qqTextBox19.Location = new System.Drawing.Point(215, 53);
    this.qqTextBox19.MaxLength = 2;
    this.qqTextBox19.Name = "qqTextBox19";
    this.qqTextBox19.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox19.TabIndex = 22;
    this.qqTextBox19.Text = "00";
    this.qqTextBox19.TextAlign = HorizontalAlignment.Center;
    this.qqCheckBox7.AutoSize = true;
    this.qqCheckBox7.BackColor = Color.Transparent;
    this.qqCheckBox7.Checked = true;
    this.qqCheckBox7.CheckState = CheckState.Checked;
    this.qqCheckBox7.Font = new Font("宋体", 9f);
    this.qqCheckBox7.Location = new System.Drawing.Point(27, 55);
    this.qqCheckBox7.Name = "qqCheckBox7";
    this.qqCheckBox7.Size = new System.Drawing.Size(42, 16 /*0x10*/);
    this.qqCheckBox7.TabIndex = 21;
    this.qqCheckBox7.Text = "ID:";
    this.qqCheckBox7.UseVisualStyleBackColor = false;
    this.qqCheckBox8.AutoSize = true;
    this.qqCheckBox8.BackColor = Color.Transparent;
    this.qqCheckBox8.Font = new Font("宋体", 9f);
    this.qqCheckBox8.Location = new System.Drawing.Point(170, 55);
    this.qqCheckBox8.Name = "qqCheckBox8";
    this.qqCheckBox8.Size = new System.Drawing.Size(42, 16 /*0x10*/);
    this.qqCheckBox8.TabIndex = 23;
    this.qqCheckBox8.Text = "ID:";
    this.qqCheckBox8.UseVisualStyleBackColor = false;
    this.qqTextBox18.BackColor = Color.White;
    this.qqTextBox18.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox18.EmptyTextTip = (string) null;
    this.qqTextBox18.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox18.Font = new Font("宋体", 9f);
    this.qqTextBox18.Location = new System.Drawing.Point(72, 53);
    this.qqTextBox18.MaxLength = 2;
    this.qqTextBox18.Name = "qqTextBox18";
    this.qqTextBox18.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox18.TabIndex = 20;
    this.qqTextBox18.Text = "00";
    this.qqTextBox18.TextAlign = HorizontalAlignment.Center;
    this.listViewNF4.BackColor = Color.RoyalBlue;
    this.listViewNF4.BorderStyle = BorderStyle.None;
    this.listViewNF4.Columns.AddRange(new ColumnHeader[9]
    {
      this.columnHeader28,
      this.columnHeader29,
      this.columnHeader30,
      this.columnHeader31,
      this.columnHeader32,
      this.columnHeader33,
      this.columnHeader34,
      this.columnHeader35,
      this.columnHeader36
    });
    this.listViewNF4.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.listViewNF4.ForeColor = Color.White;
    this.listViewNF4.FullRowSelect = true;
    this.listViewNF4.HideSelection = false;
    this.listViewNF4.Location = new System.Drawing.Point(0, 8);
    this.listViewNF4.Margin = new System.Windows.Forms.Padding(0);
    this.listViewNF4.MultiSelect = false;
    this.listViewNF4.Name = "listViewNF4";
    this.listViewNF4.Size = new System.Drawing.Size(892, 258);
    this.listViewNF4.TabIndex = 49;
    this.listViewNF4.UseCompatibleStateImageBehavior = false;
    this.listViewNF4.View = View.Details;
    this.columnHeader28.Text = "序号";
    this.columnHeader29.Text = "通道";
    this.columnHeader29.TextAlign = HorizontalAlignment.Center;
    this.columnHeader29.Width = 50;
    this.columnHeader30.Text = "方向";
    this.columnHeader30.TextAlign = HorizontalAlignment.Center;
    this.columnHeader30.Width = 70;
    this.columnHeader31.Text = "时间";
    this.columnHeader31.Width = 160 /*0xA0*/;
    this.columnHeader32.Text = "ID[PID]";
    this.columnHeader32.TextAlign = HorizontalAlignment.Center;
    this.columnHeader32.Width = 80 /*0x50*/;
    this.columnHeader33.Text = "数据长度";
    this.columnHeader33.TextAlign = HorizontalAlignment.Center;
    this.columnHeader33.Width = 70;
    this.columnHeader34.Text = "数据(Hex)";
    this.columnHeader34.Width = 210;
    this.columnHeader35.Text = "校验(Hex)";
    this.columnHeader35.TextAlign = HorizontalAlignment.Center;
    this.columnHeader35.Width = 80 /*0x50*/;
    this.columnHeader36.Text = "状态";
    this.columnHeader36.TextAlign = HorizontalAlignment.Center;
    this.columnHeader36.Width = 80 /*0x50*/;
    this.tabPage5.BackColor = Color.DarkSalmon;
    this.tabPage5.Controls.Add((Control) this.dataGridViewX7);
    this.tabPage5.Controls.Add((Control) this.dataGridViewX6);
    this.tabPage5.Controls.Add((Control) this.dataGridViewX5);
    this.tabPage5.Controls.Add((Control) this.dataGridViewX4);
    this.tabPage5.Controls.Add((Control) this.myButton5);
    this.tabPage5.Controls.Add((Control) this.groupBoxEx7);
    this.tabPage5.Controls.Add((Control) this.dS标签18);
    this.tabPage5.Controls.Add((Control) this.comboBox2);
    this.tabPage5.Controls.Add((Control) this.groupBoxEx6);
    this.tabPage5.Controls.Add((Control) this.dS标签3);
    this.tabPage5.Controls.Add((Control) this.dS数字输入框3);
    this.tabPage5.Controls.Add((Control) this.dS数字输入框2);
    this.tabPage5.Controls.Add((Control) this.dS标签4);
    this.tabPage5.Controls.Add((Control) this.dS容器1);
    this.tabPage5.Location = new System.Drawing.Point(4, 22);
    this.tabPage5.Name = "tabPage5";
    this.tabPage5.Size = new System.Drawing.Size(892, 554);
    this.tabPage5.TabIndex = 7;
    this.tabPage5.Text = "离线模式";
    ((DataGridView) this.dataGridViewX7).AllowUserToDeleteRows = false;
    ((DataGridView) this.dataGridViewX7).BackgroundColor = SystemColors.ActiveCaption;
    ((DataGridView) this.dataGridViewX7).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
    ((DataGridView) this.dataGridViewX7).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
    ((DataGridView) this.dataGridViewX7).ColumnHeadersHeight = 43;
    ((DataGridView) this.dataGridViewX7).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
    ((DataGridView) this.dataGridViewX7).Columns.AddRange((DataGridViewColumn) this.dataGridViewCheckBoxColumn6, (DataGridViewColumn) this.dataGridViewTextBoxColumn23, (DataGridViewColumn) this.dataGridViewComboBoxColumn9, (DataGridViewColumn) this.dataGridViewTextBoxColumn24, (DataGridViewColumn) this.dataGridViewTextBoxColumn25, (DataGridViewColumn) this.dataGridViewTextBoxColumn26, (DataGridViewColumn) this.dataGridViewComboBoxColumn10);
    gridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle11.BackColor = SystemColors.Window;
    gridViewCellStyle11.Font = new Font("宋体", 9f);
    gridViewCellStyle11.ForeColor = SystemColors.ControlText;
    gridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle11.SelectionForeColor = SystemColors.ControlText;
    gridViewCellStyle11.WrapMode = DataGridViewTriState.False;
    ((DataGridView) this.dataGridViewX7).DefaultCellStyle = gridViewCellStyle11;
    ((DataGridView) this.dataGridViewX7).EditMode = DataGridViewEditMode.EditOnEnter;
    ((DataGridView) this.dataGridViewX7).GridColor = Color.FromArgb(208 /*0xD0*/, 215, 229);
    ((Control) this.dataGridViewX7).Location = new System.Drawing.Point(438, 362);
    ((Control) this.dataGridViewX7).Margin = new System.Windows.Forms.Padding(0);
    ((DataGridView) this.dataGridViewX7).MultiSelect = false;
    ((Control) this.dataGridViewX7).Name = "dataGridViewX7";
    ((DataGridView) this.dataGridViewX7).RowHeadersVisible = false;
    ((DataGridView) this.dataGridViewX7).RowHeadersWidth = 40;
    ((DataGridView) this.dataGridViewX7).RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
    gridViewCellStyle12.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    ((DataGridView) this.dataGridViewX7).RowsDefaultCellStyle = gridViewCellStyle12;
    ((DataGridView) this.dataGridViewX7).RowTemplate.Height = 23;
    ((DataGridView) this.dataGridViewX7).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    ((DataGridView) this.dataGridViewX7).ShowCellToolTips = false;
    ((Control) this.dataGridViewX7).Size = new System.Drawing.Size(42, 36);
    ((Control) this.dataGridViewX7).TabIndex = 52;
    ((Control) this.dataGridViewX7).Visible = false;
    gridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
    gridViewCellStyle13.Font = new Font("微软雅黑", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    gridViewCellStyle13.NullValue = (object) false;
    this.dataGridViewCheckBoxColumn6.DefaultCellStyle = gridViewCellStyle13;
    this.dataGridViewCheckBoxColumn6.FillWeight = 500f;
    this.dataGridViewCheckBoxColumn6.HeaderText = "从机4";
    this.dataGridViewCheckBoxColumn6.MinimumWidth = 10;
    this.dataGridViewCheckBoxColumn6.Name = "dataGridViewCheckBoxColumn6";
    this.dataGridViewCheckBoxColumn6.Width = 50;
    gridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle14.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dataGridViewTextBoxColumn23.DefaultCellStyle = gridViewCellStyle14;
    this.dataGridViewTextBoxColumn23.HeaderText = "通道";
    this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
    this.dataGridViewTextBoxColumn23.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn23.Width = 75;
    this.dataGridViewComboBoxColumn9.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    this.dataGridViewComboBoxColumn9.DisplayStyleForCurrentCellOnly = true;
    this.dataGridViewComboBoxColumn9.FlatStyle = FlatStyle.Flat;
    this.dataGridViewComboBoxColumn9.HeaderText = "方向";
    this.dataGridViewComboBoxColumn9.Items.AddRange((object) "发送", (object) "接收");
    this.dataGridViewComboBoxColumn9.Name = "dataGridViewComboBoxColumn9";
    this.dataGridViewComboBoxColumn9.Width = 90;
    gridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewTextBoxColumn24.DefaultCellStyle = gridViewCellStyle15;
    this.dataGridViewTextBoxColumn24.HeaderText = "ID";
    this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
    this.dataGridViewTextBoxColumn24.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn24.Width = 108;
    this.dataGridViewTextBoxColumn25.HeaderText = "数据(Hex)";
    this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
    this.dataGridViewTextBoxColumn25.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn25.Width = 300;
    gridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewTextBoxColumn26.DefaultCellStyle = gridViewCellStyle16;
    this.dataGridViewTextBoxColumn26.HeaderText = "长度";
    this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
    this.dataGridViewTextBoxColumn26.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn26.Width = 95;
    gridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewComboBoxColumn10.DefaultCellStyle = gridViewCellStyle17;
    this.dataGridViewComboBoxColumn10.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    this.dataGridViewComboBoxColumn10.DisplayStyleForCurrentCellOnly = true;
    this.dataGridViewComboBoxColumn10.FlatStyle = FlatStyle.Flat;
    this.dataGridViewComboBoxColumn10.HeaderText = "校验和类型";
    this.dataGridViewComboBoxColumn10.Items.AddRange((object) "增强型校验和", (object) "标准型校验和");
    this.dataGridViewComboBoxColumn10.Name = "dataGridViewComboBoxColumn10";
    this.dataGridViewComboBoxColumn10.Resizable = DataGridViewTriState.True;
    this.dataGridViewComboBoxColumn10.Width = 140;
    ((DataGridView) this.dataGridViewX6).AllowUserToDeleteRows = false;
    ((DataGridView) this.dataGridViewX6).BackgroundColor = SystemColors.ActiveCaption;
    ((DataGridView) this.dataGridViewX6).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
    ((DataGridView) this.dataGridViewX6).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
    ((DataGridView) this.dataGridViewX6).ColumnHeadersHeight = 43;
    ((DataGridView) this.dataGridViewX6).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
    ((DataGridView) this.dataGridViewX6).Columns.AddRange((DataGridViewColumn) this.dataGridViewCheckBoxColumn5, (DataGridViewColumn) this.dataGridViewTextBoxColumn19, (DataGridViewColumn) this.dataGridViewComboBoxColumn7, (DataGridViewColumn) this.dataGridViewTextBoxColumn20, (DataGridViewColumn) this.dataGridViewTextBoxColumn21, (DataGridViewColumn) this.dataGridViewTextBoxColumn22, (DataGridViewColumn) this.dataGridViewComboBoxColumn8);
    gridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle18.BackColor = SystemColors.Window;
    gridViewCellStyle18.Font = new Font("宋体", 9f);
    gridViewCellStyle18.ForeColor = SystemColors.ControlText;
    gridViewCellStyle18.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle18.SelectionForeColor = SystemColors.ControlText;
    gridViewCellStyle18.WrapMode = DataGridViewTriState.False;
    ((DataGridView) this.dataGridViewX6).DefaultCellStyle = gridViewCellStyle18;
    ((DataGridView) this.dataGridViewX6).EditMode = DataGridViewEditMode.EditOnEnter;
    ((DataGridView) this.dataGridViewX6).GridColor = Color.FromArgb(208 /*0xD0*/, 215, 229);
    ((Control) this.dataGridViewX6).Location = new System.Drawing.Point(389, 362);
    ((Control) this.dataGridViewX6).Margin = new System.Windows.Forms.Padding(0);
    ((DataGridView) this.dataGridViewX6).MultiSelect = false;
    ((Control) this.dataGridViewX6).Name = "dataGridViewX6";
    ((DataGridView) this.dataGridViewX6).RowHeadersVisible = false;
    ((DataGridView) this.dataGridViewX6).RowHeadersWidth = 40;
    ((DataGridView) this.dataGridViewX6).RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
    gridViewCellStyle19.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    ((DataGridView) this.dataGridViewX6).RowsDefaultCellStyle = gridViewCellStyle19;
    ((DataGridView) this.dataGridViewX6).RowTemplate.Height = 23;
    ((DataGridView) this.dataGridViewX6).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    ((DataGridView) this.dataGridViewX6).ShowCellToolTips = false;
    ((Control) this.dataGridViewX6).Size = new System.Drawing.Size(38, 32 /*0x20*/);
    ((Control) this.dataGridViewX6).TabIndex = 52;
    ((Control) this.dataGridViewX6).Visible = false;
    gridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleCenter;
    gridViewCellStyle20.Font = new Font("微软雅黑", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    gridViewCellStyle20.NullValue = (object) false;
    this.dataGridViewCheckBoxColumn5.DefaultCellStyle = gridViewCellStyle20;
    this.dataGridViewCheckBoxColumn5.FillWeight = 500f;
    this.dataGridViewCheckBoxColumn5.HeaderText = "从机3";
    this.dataGridViewCheckBoxColumn5.MinimumWidth = 10;
    this.dataGridViewCheckBoxColumn5.Name = "dataGridViewCheckBoxColumn5";
    this.dataGridViewCheckBoxColumn5.Width = 50;
    gridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle21.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dataGridViewTextBoxColumn19.DefaultCellStyle = gridViewCellStyle21;
    this.dataGridViewTextBoxColumn19.HeaderText = "通道";
    this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
    this.dataGridViewTextBoxColumn19.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn19.Width = 75;
    this.dataGridViewComboBoxColumn7.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    this.dataGridViewComboBoxColumn7.DisplayStyleForCurrentCellOnly = true;
    this.dataGridViewComboBoxColumn7.FlatStyle = FlatStyle.Flat;
    this.dataGridViewComboBoxColumn7.HeaderText = "方向";
    this.dataGridViewComboBoxColumn7.Items.AddRange((object) "发送", (object) "接收");
    this.dataGridViewComboBoxColumn7.Name = "dataGridViewComboBoxColumn7";
    this.dataGridViewComboBoxColumn7.Width = 90;
    gridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewTextBoxColumn20.DefaultCellStyle = gridViewCellStyle22;
    this.dataGridViewTextBoxColumn20.HeaderText = "ID";
    this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
    this.dataGridViewTextBoxColumn20.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn20.Width = 108;
    this.dataGridViewTextBoxColumn21.HeaderText = "数据(Hex)";
    this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
    this.dataGridViewTextBoxColumn21.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn21.Width = 300;
    gridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewTextBoxColumn22.DefaultCellStyle = gridViewCellStyle23;
    this.dataGridViewTextBoxColumn22.HeaderText = "长度";
    this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
    this.dataGridViewTextBoxColumn22.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn22.Width = 95;
    gridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewComboBoxColumn8.DefaultCellStyle = gridViewCellStyle24;
    this.dataGridViewComboBoxColumn8.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    this.dataGridViewComboBoxColumn8.DisplayStyleForCurrentCellOnly = true;
    this.dataGridViewComboBoxColumn8.FlatStyle = FlatStyle.Flat;
    this.dataGridViewComboBoxColumn8.HeaderText = "校验和类型";
    this.dataGridViewComboBoxColumn8.Items.AddRange((object) "增强型校验和", (object) "标准型校验和");
    this.dataGridViewComboBoxColumn8.Name = "dataGridViewComboBoxColumn8";
    this.dataGridViewComboBoxColumn8.Resizable = DataGridViewTriState.True;
    this.dataGridViewComboBoxColumn8.Width = 140;
    ((DataGridView) this.dataGridViewX5).AllowUserToDeleteRows = false;
    ((DataGridView) this.dataGridViewX5).BackgroundColor = SystemColors.ActiveCaption;
    ((DataGridView) this.dataGridViewX5).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
    ((DataGridView) this.dataGridViewX5).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
    ((DataGridView) this.dataGridViewX5).ColumnHeadersHeight = 43;
    ((DataGridView) this.dataGridViewX5).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
    ((DataGridView) this.dataGridViewX5).Columns.AddRange((DataGridViewColumn) this.dataGridViewCheckBoxColumn4, (DataGridViewColumn) this.dataGridViewTextBoxColumn15, (DataGridViewColumn) this.dataGridViewComboBoxColumn5, (DataGridViewColumn) this.dataGridViewTextBoxColumn16, (DataGridViewColumn) this.dataGridViewTextBoxColumn17, (DataGridViewColumn) this.dataGridViewTextBoxColumn18, (DataGridViewColumn) this.dataGridViewComboBoxColumn6);
    gridViewCellStyle25.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle25.BackColor = SystemColors.Window;
    gridViewCellStyle25.Font = new Font("宋体", 9f);
    gridViewCellStyle25.ForeColor = SystemColors.ControlText;
    gridViewCellStyle25.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle25.SelectionForeColor = SystemColors.ControlText;
    gridViewCellStyle25.WrapMode = DataGridViewTriState.False;
    ((DataGridView) this.dataGridViewX5).DefaultCellStyle = gridViewCellStyle25;
    ((DataGridView) this.dataGridViewX5).EditMode = DataGridViewEditMode.EditOnEnter;
    ((DataGridView) this.dataGridViewX5).GridColor = Color.FromArgb(208 /*0xD0*/, 215, 229);
    ((Control) this.dataGridViewX5).Location = new System.Drawing.Point(349, 362);
    ((Control) this.dataGridViewX5).Margin = new System.Windows.Forms.Padding(0);
    ((DataGridView) this.dataGridViewX5).MultiSelect = false;
    ((Control) this.dataGridViewX5).Name = "dataGridViewX5";
    ((DataGridView) this.dataGridViewX5).RowHeadersVisible = false;
    ((DataGridView) this.dataGridViewX5).RowHeadersWidth = 40;
    ((DataGridView) this.dataGridViewX5).RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
    gridViewCellStyle26.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    ((DataGridView) this.dataGridViewX5).RowsDefaultCellStyle = gridViewCellStyle26;
    ((DataGridView) this.dataGridViewX5).RowTemplate.Height = 23;
    ((DataGridView) this.dataGridViewX5).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    ((DataGridView) this.dataGridViewX5).ShowCellToolTips = false;
    ((Control) this.dataGridViewX5).Size = new System.Drawing.Size(30, 29);
    ((Control) this.dataGridViewX5).TabIndex = 52;
    ((Control) this.dataGridViewX5).Visible = false;
    gridViewCellStyle27.Alignment = DataGridViewContentAlignment.MiddleCenter;
    gridViewCellStyle27.Font = new Font("微软雅黑", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    gridViewCellStyle27.NullValue = (object) false;
    this.dataGridViewCheckBoxColumn4.DefaultCellStyle = gridViewCellStyle27;
    this.dataGridViewCheckBoxColumn4.FillWeight = 500f;
    this.dataGridViewCheckBoxColumn4.HeaderText = "从机2";
    this.dataGridViewCheckBoxColumn4.MinimumWidth = 10;
    this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
    this.dataGridViewCheckBoxColumn4.Width = 50;
    gridViewCellStyle28.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle28.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dataGridViewTextBoxColumn15.DefaultCellStyle = gridViewCellStyle28;
    this.dataGridViewTextBoxColumn15.HeaderText = "通道";
    this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
    this.dataGridViewTextBoxColumn15.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn15.Width = 75;
    this.dataGridViewComboBoxColumn5.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    this.dataGridViewComboBoxColumn5.DisplayStyleForCurrentCellOnly = true;
    this.dataGridViewComboBoxColumn5.FlatStyle = FlatStyle.Flat;
    this.dataGridViewComboBoxColumn5.HeaderText = "方向";
    this.dataGridViewComboBoxColumn5.Items.AddRange((object) "发送", (object) "接收");
    this.dataGridViewComboBoxColumn5.Name = "dataGridViewComboBoxColumn5";
    this.dataGridViewComboBoxColumn5.Width = 90;
    gridViewCellStyle29.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewTextBoxColumn16.DefaultCellStyle = gridViewCellStyle29;
    this.dataGridViewTextBoxColumn16.HeaderText = "ID";
    this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
    this.dataGridViewTextBoxColumn16.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn16.Width = 108;
    this.dataGridViewTextBoxColumn17.HeaderText = "数据(Hex)";
    this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
    this.dataGridViewTextBoxColumn17.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn17.Width = 300;
    gridViewCellStyle30.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewTextBoxColumn18.DefaultCellStyle = gridViewCellStyle30;
    this.dataGridViewTextBoxColumn18.HeaderText = "长度";
    this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
    this.dataGridViewTextBoxColumn18.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn18.Width = 95;
    gridViewCellStyle31.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewComboBoxColumn6.DefaultCellStyle = gridViewCellStyle31;
    this.dataGridViewComboBoxColumn6.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    this.dataGridViewComboBoxColumn6.DisplayStyleForCurrentCellOnly = true;
    this.dataGridViewComboBoxColumn6.FlatStyle = FlatStyle.Flat;
    this.dataGridViewComboBoxColumn6.HeaderText = "校验和类型";
    this.dataGridViewComboBoxColumn6.Items.AddRange((object) "增强型校验和", (object) "标准型校验和");
    this.dataGridViewComboBoxColumn6.Name = "dataGridViewComboBoxColumn6";
    this.dataGridViewComboBoxColumn6.Resizable = DataGridViewTriState.True;
    this.dataGridViewComboBoxColumn6.Width = 140;
    ((DataGridView) this.dataGridViewX4).AllowUserToDeleteRows = false;
    ((DataGridView) this.dataGridViewX4).BackgroundColor = SystemColors.ActiveCaption;
    ((DataGridView) this.dataGridViewX4).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
    ((DataGridView) this.dataGridViewX4).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
    ((DataGridView) this.dataGridViewX4).ColumnHeadersHeight = 43;
    ((DataGridView) this.dataGridViewX4).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
    ((DataGridView) this.dataGridViewX4).Columns.AddRange((DataGridViewColumn) this.dataGridViewCheckBoxColumn3, (DataGridViewColumn) this.dataGridViewTextBoxColumn11, (DataGridViewColumn) this.dataGridViewComboBoxColumn3, (DataGridViewColumn) this.dataGridViewTextBoxColumn12, (DataGridViewColumn) this.dataGridViewTextBoxColumn13, (DataGridViewColumn) this.dataGridViewTextBoxColumn14, (DataGridViewColumn) this.dataGridViewComboBoxColumn4);
    gridViewCellStyle32.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle32.BackColor = SystemColors.Window;
    gridViewCellStyle32.Font = new Font("宋体", 9f);
    gridViewCellStyle32.ForeColor = SystemColors.ControlText;
    gridViewCellStyle32.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle32.SelectionForeColor = SystemColors.ControlText;
    gridViewCellStyle32.WrapMode = DataGridViewTriState.False;
    ((DataGridView) this.dataGridViewX4).DefaultCellStyle = gridViewCellStyle32;
    ((DataGridView) this.dataGridViewX4).EditMode = DataGridViewEditMode.EditOnEnter;
    ((DataGridView) this.dataGridViewX4).GridColor = Color.FromArgb(208 /*0xD0*/, 215, 229);
    ((Control) this.dataGridViewX4).Location = new System.Drawing.Point(305, 362);
    ((Control) this.dataGridViewX4).Margin = new System.Windows.Forms.Padding(0);
    ((DataGridView) this.dataGridViewX4).MultiSelect = false;
    ((Control) this.dataGridViewX4).Name = "dataGridViewX4";
    ((DataGridView) this.dataGridViewX4).RowHeadersVisible = false;
    ((DataGridView) this.dataGridViewX4).RowHeadersWidth = 40;
    ((DataGridView) this.dataGridViewX4).RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
    gridViewCellStyle33.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    ((DataGridView) this.dataGridViewX4).RowsDefaultCellStyle = gridViewCellStyle33;
    ((DataGridView) this.dataGridViewX4).RowTemplate.Height = 23;
    ((DataGridView) this.dataGridViewX4).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    ((DataGridView) this.dataGridViewX4).ShowCellToolTips = false;
    ((Control) this.dataGridViewX4).Size = new System.Drawing.Size(32 /*0x20*/, 28);
    ((Control) this.dataGridViewX4).TabIndex = 52;
    ((Control) this.dataGridViewX4).Visible = false;
    gridViewCellStyle34.Alignment = DataGridViewContentAlignment.MiddleCenter;
    gridViewCellStyle34.Font = new Font("微软雅黑", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    gridViewCellStyle34.NullValue = (object) false;
    this.dataGridViewCheckBoxColumn3.DefaultCellStyle = gridViewCellStyle34;
    this.dataGridViewCheckBoxColumn3.FillWeight = 500f;
    this.dataGridViewCheckBoxColumn3.HeaderText = "从机1";
    this.dataGridViewCheckBoxColumn3.MinimumWidth = 10;
    this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
    this.dataGridViewCheckBoxColumn3.Width = 50;
    gridViewCellStyle35.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle35.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dataGridViewTextBoxColumn11.DefaultCellStyle = gridViewCellStyle35;
    this.dataGridViewTextBoxColumn11.HeaderText = "通道";
    this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
    this.dataGridViewTextBoxColumn11.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn11.Width = 75;
    this.dataGridViewComboBoxColumn3.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    this.dataGridViewComboBoxColumn3.DisplayStyleForCurrentCellOnly = true;
    this.dataGridViewComboBoxColumn3.FlatStyle = FlatStyle.Flat;
    this.dataGridViewComboBoxColumn3.HeaderText = "方向";
    this.dataGridViewComboBoxColumn3.Items.AddRange((object) "发送", (object) "接收");
    this.dataGridViewComboBoxColumn3.Name = "dataGridViewComboBoxColumn3";
    this.dataGridViewComboBoxColumn3.Width = 90;
    gridViewCellStyle36.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewTextBoxColumn12.DefaultCellStyle = gridViewCellStyle36;
    this.dataGridViewTextBoxColumn12.HeaderText = "ID";
    this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
    this.dataGridViewTextBoxColumn12.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn12.Width = 108;
    this.dataGridViewTextBoxColumn13.HeaderText = "数据(Hex)";
    this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
    this.dataGridViewTextBoxColumn13.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn13.Width = 300;
    gridViewCellStyle37.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewTextBoxColumn14.DefaultCellStyle = gridViewCellStyle37;
    this.dataGridViewTextBoxColumn14.HeaderText = "长度";
    this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
    this.dataGridViewTextBoxColumn14.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn14.Width = 95;
    gridViewCellStyle38.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewComboBoxColumn4.DefaultCellStyle = gridViewCellStyle38;
    this.dataGridViewComboBoxColumn4.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    this.dataGridViewComboBoxColumn4.DisplayStyleForCurrentCellOnly = true;
    this.dataGridViewComboBoxColumn4.FlatStyle = FlatStyle.Flat;
    this.dataGridViewComboBoxColumn4.HeaderText = "校验和类型";
    this.dataGridViewComboBoxColumn4.Items.AddRange((object) "增强型校验和", (object) "标准型校验和");
    this.dataGridViewComboBoxColumn4.Name = "dataGridViewComboBoxColumn4";
    this.dataGridViewComboBoxColumn4.Resizable = DataGridViewTriState.True;
    this.dataGridViewComboBoxColumn4.Width = 140;
    this.myButton5.BackColor = Color.Transparent;
    this.myButton5.BackgroundImageLayout = ImageLayout.Center;
    this.myButton5.DownImage = (Image) componentResourceManager.GetObject("myButton5.DownImage");
    this.myButton5.Font = new Font("新宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.myButton5.ForeColor = SystemColors.InfoText;
    this.myButton5.Image = (Image) Resources.btn_green_normal;
    this.myButton5.IsShowBorder = false;
    this.myButton5.Location = new System.Drawing.Point(305, 402);
    this.myButton5.Margin = new System.Windows.Forms.Padding(0);
    this.myButton5.MoveImage = (Image) componentResourceManager.GetObject("myButton5.MoveImage");
    this.myButton5.Name = "myButton5";
    this.myButton5.NormalImage = (Image) componentResourceManager.GetObject("myButton5.NormalImage");
    this.myButton5.Size = new System.Drawing.Size(154, 104);
    this.myButton5.TabIndex = 67;
    this.myButton5.Text = "烧录配置参数";
    this.myButton5.UseVisualStyleBackColor = false;
    this.myButton5.Click += new EventHandler(this.myButton5_Click);
    this.groupBoxEx7.BackgroundImage = (Image) componentResourceManager.GetObject("groupBoxEx7.BackgroundImage");
    this.groupBoxEx7.BackgroundImageLayout = ImageLayout.Stretch;
    this.groupBoxEx7.BorderColor = Color.Green;
    this.groupBoxEx7.Controls.Add((Control) this.qqTextBox55);
    this.groupBoxEx7.Controls.Add((Control) this.qqTextBox54);
    this.groupBoxEx7.Controls.Add((Control) this.qqTextBox53);
    this.groupBoxEx7.Controls.Add((Control) this.qqTextBox52);
    this.groupBoxEx7.Controls.Add((Control) this.dS标签22);
    this.groupBoxEx7.Controls.Add((Control) this.dS标签21);
    this.groupBoxEx7.Controls.Add((Control) this.dS标签20);
    this.groupBoxEx7.Controls.Add((Control) this.dS标签19);
    this.groupBoxEx7.Location = new System.Drawing.Point(615, 362);
    this.groupBoxEx7.Name = "groupBoxEx7";
    this.groupBoxEx7.Size = new System.Drawing.Size(263, 179);
    this.groupBoxEx7.TabIndex = 66;
    this.groupBoxEx7.TabStop = false;
    this.groupBoxEx7.Text = "从机ID(HEX)：";
    this.groupBoxEx7.Visible = false;
    this.qqTextBox55.BackColor = Color.White;
    this.qqTextBox55.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox55.EmptyTextTip = (string) null;
    this.qqTextBox55.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox55.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox55.Location = new System.Drawing.Point(94, 131);
    this.qqTextBox55.MaxLength = 2;
    this.qqTextBox55.Name = "qqTextBox55";
    this.qqTextBox55.Size = new System.Drawing.Size(136, 26);
    this.qqTextBox55.TabIndex = 74;
    this.qqTextBox55.Text = "04";
    this.qqTextBox55.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox55.TextChanged += new EventHandler(this.qqTextBox55_TextChanged);
    this.qqTextBox54.BackColor = Color.White;
    this.qqTextBox54.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox54.EmptyTextTip = (string) null;
    this.qqTextBox54.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox54.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox54.Location = new System.Drawing.Point(94, 94);
    this.qqTextBox54.MaxLength = 2;
    this.qqTextBox54.Name = "qqTextBox54";
    this.qqTextBox54.Size = new System.Drawing.Size(136, 26);
    this.qqTextBox54.TabIndex = 73;
    this.qqTextBox54.Text = "03";
    this.qqTextBox54.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox54.TextChanged += new EventHandler(this.qqTextBox54_TextChanged);
    this.qqTextBox53.BackColor = Color.White;
    this.qqTextBox53.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox53.EmptyTextTip = (string) null;
    this.qqTextBox53.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox53.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox53.Location = new System.Drawing.Point(94, 57);
    this.qqTextBox53.MaxLength = 2;
    this.qqTextBox53.Name = "qqTextBox53";
    this.qqTextBox53.Size = new System.Drawing.Size(136, 26);
    this.qqTextBox53.TabIndex = 72;
    this.qqTextBox53.Text = "02";
    this.qqTextBox53.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox53.TextChanged += new EventHandler(this.qqTextBox53_TextChanged);
    this.qqTextBox52.BackColor = Color.White;
    this.qqTextBox52.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox52.EmptyTextTip = (string) null;
    this.qqTextBox52.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox52.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox52.Location = new System.Drawing.Point(94, 21);
    this.qqTextBox52.MaxLength = 2;
    this.qqTextBox52.Name = "qqTextBox52";
    this.qqTextBox52.Size = new System.Drawing.Size(136, 26);
    this.qqTextBox52.TabIndex = 71;
    this.qqTextBox52.Text = "01";
    this.qqTextBox52.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox52.TextChanged += new EventHandler(this.qqTextBox52_TextChanged);
    this.dS标签22.BackColor = Color.Transparent;
    this.dS标签22.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS标签22.Location = new System.Drawing.Point(18, 132);
    this.dS标签22.Name = "dS标签22";
    this.dS标签22.Size = new System.Drawing.Size(70, 29);
    this.dS标签22.TabIndex = 70;
    this.dS标签22.Text = "从机4-ID:";
    this.dS标签22.偏移 = new System.Drawing.Point(0, 5);
    this.dS标签21.BackColor = Color.Transparent;
    this.dS标签21.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS标签21.Location = new System.Drawing.Point(18, 95);
    this.dS标签21.Name = "dS标签21";
    this.dS标签21.Size = new System.Drawing.Size(70, 29);
    this.dS标签21.TabIndex = 68;
    this.dS标签21.Text = "从机3-ID:";
    this.dS标签21.偏移 = new System.Drawing.Point(0, 5);
    this.dS标签20.BackColor = Color.Transparent;
    this.dS标签20.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS标签20.Location = new System.Drawing.Point(18, 58);
    this.dS标签20.Name = "dS标签20";
    this.dS标签20.Size = new System.Drawing.Size(70, 29);
    this.dS标签20.TabIndex = 66;
    this.dS标签20.Text = "从机2-ID:";
    this.dS标签20.偏移 = new System.Drawing.Point(0, 5);
    this.dS标签19.BackColor = Color.Transparent;
    this.dS标签19.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS标签19.Location = new System.Drawing.Point(18, 21);
    this.dS标签19.Name = "dS标签19";
    this.dS标签19.Size = new System.Drawing.Size(70, 29);
    this.dS标签19.TabIndex = 64 /*0x40*/;
    this.dS标签19.Text = "从机1-ID:";
    this.dS标签19.偏移 = new System.Drawing.Point(0, 5);
    this.dS标签18.BackColor = Color.Transparent;
    this.dS标签18.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS标签18.Location = new System.Drawing.Point(17, 378);
    this.dS标签18.Name = "dS标签18";
    this.dS标签18.Size = new System.Drawing.Size(133, 34);
    this.dS标签18.TabIndex = 63 /*0x3F*/;
    this.dS标签18.Text = "离线模式选择：";
    this.dS标签18.偏移 = new System.Drawing.Point(0, 5);
    this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboBox2.FlatStyle = FlatStyle.Flat;
    this.comboBox2.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.comboBox2.ForeColor = SystemColors.ActiveCaptionText;
    this.comboBox2.FormattingEnabled = true;
    this.comboBox2.Items.AddRange(new object[1]
    {
      (object) "主机"
    });
    this.comboBox2.Location = new System.Drawing.Point(156, 379);
    this.comboBox2.Name = "comboBox2";
    this.comboBox2.Size = new System.Drawing.Size(100, 29);
    this.comboBox2.TabIndex = 64 /*0x40*/;
    this.groupBoxEx6.BackgroundImage = (Image) componentResourceManager.GetObject("groupBoxEx6.BackgroundImage");
    this.groupBoxEx6.BackgroundImageLayout = ImageLayout.Stretch;
    this.groupBoxEx6.BorderColor = Color.Green;
    this.groupBoxEx6.Controls.Add((Control) this.qqCheckBox25);
    this.groupBoxEx6.Controls.Add((Control) this.qqCheckBox24);
    this.groupBoxEx6.Controls.Add((Control) this.qqCheckBox23);
    this.groupBoxEx6.Controls.Add((Control) this.qqCheckBox22);
    this.groupBoxEx6.Location = new System.Drawing.Point(494, 362);
    this.groupBoxEx6.Name = "groupBoxEx6";
    this.groupBoxEx6.Size = new System.Drawing.Size(115, 179);
    this.groupBoxEx6.TabIndex = 65;
    this.groupBoxEx6.TabStop = false;
    this.groupBoxEx6.Text = "从机使能选择：";
    this.groupBoxEx6.Visible = false;
    this.qqCheckBox25.AutoSize = true;
    this.qqCheckBox25.BackColor = Color.Transparent;
    this.qqCheckBox25.Font = new Font("宋体", 9f);
    this.qqCheckBox25.Location = new System.Drawing.Point(30, 139);
    this.qqCheckBox25.Name = "qqCheckBox25";
    this.qqCheckBox25.Size = new System.Drawing.Size(54, 16 /*0x10*/);
    this.qqCheckBox25.TabIndex = 17;
    this.qqCheckBox25.Text = "从机4";
    this.qqCheckBox25.UseVisualStyleBackColor = false;
    this.qqCheckBox24.AutoSize = true;
    this.qqCheckBox24.BackColor = Color.Transparent;
    this.qqCheckBox24.Font = new Font("宋体", 9f);
    this.qqCheckBox24.Location = new System.Drawing.Point(30, 102);
    this.qqCheckBox24.Name = "qqCheckBox24";
    this.qqCheckBox24.Size = new System.Drawing.Size(54, 16 /*0x10*/);
    this.qqCheckBox24.TabIndex = 16 /*0x10*/;
    this.qqCheckBox24.Text = "从机3";
    this.qqCheckBox24.UseVisualStyleBackColor = false;
    this.qqCheckBox23.AutoSize = true;
    this.qqCheckBox23.BackColor = Color.Transparent;
    this.qqCheckBox23.Font = new Font("宋体", 9f);
    this.qqCheckBox23.Location = new System.Drawing.Point(30, 65);
    this.qqCheckBox23.Name = "qqCheckBox23";
    this.qqCheckBox23.Size = new System.Drawing.Size(54, 16 /*0x10*/);
    this.qqCheckBox23.TabIndex = 15;
    this.qqCheckBox23.Text = "从机2";
    this.qqCheckBox23.UseVisualStyleBackColor = false;
    this.qqCheckBox22.AutoSize = true;
    this.qqCheckBox22.BackColor = Color.Transparent;
    this.qqCheckBox22.Checked = true;
    this.qqCheckBox22.CheckState = CheckState.Checked;
    this.qqCheckBox22.Font = new Font("宋体", 9f);
    this.qqCheckBox22.Location = new System.Drawing.Point(30, 28);
    this.qqCheckBox22.Name = "qqCheckBox22";
    this.qqCheckBox22.Size = new System.Drawing.Size(54, 16 /*0x10*/);
    this.qqCheckBox22.TabIndex = 14;
    this.qqCheckBox22.Text = "从机1";
    this.qqCheckBox22.UseVisualStyleBackColor = false;
    this.dS标签3.BackColor = Color.Transparent;
    this.dS标签3.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS标签3.Location = new System.Drawing.Point(17, 446);
    this.dS标签3.Name = "dS标签3";
    this.dS标签3.Size = new System.Drawing.Size(133, 34);
    this.dS标签3.TabIndex = 62;
    this.dS标签3.Text = "定时时间(ms)：";
    this.dS标签3.偏移 = new System.Drawing.Point(0, 5);
    this.dS数字输入框3.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS数字输入框3.Location = new System.Drawing.Point(156, 447);
    this.dS数字输入框3.MaxLength = 5;
    this.dS数字输入框3.Name = "dS数字输入框3";
    this.dS数字输入框3.Size = new System.Drawing.Size(100, 29);
    this.dS数字输入框3.TabIndex = 60;
    this.dS数字输入框3.TextAlign = HorizontalAlignment.Center;
    this.dS数字输入框2.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS数字输入框2.Location = new System.Drawing.Point(156, 510);
    this.dS数字输入框2.MaxLength = 2;
    this.dS数字输入框2.Name = "dS数字输入框2";
    this.dS数字输入框2.Size = new System.Drawing.Size(100, 29);
    this.dS数字输入框2.TabIndex = 59;
    this.dS数字输入框2.TextAlign = HorizontalAlignment.Center;
    this.dS数字输入框2.Visible = false;
    this.dS标签4.BackColor = Color.Transparent;
    this.dS标签4.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS标签4.Location = new System.Drawing.Point(17, 507);
    this.dS标签4.Name = "dS标签4";
    this.dS标签4.Size = new System.Drawing.Size(133, 34);
    this.dS标签4.TabIndex = 58;
    this.dS标签4.Text = "语音音量大小：";
    this.dS标签4.Visible = false;
    this.dS标签4.偏移 = new System.Drawing.Point(0, 5);
    this.dS容器1.BackColor = SystemColors.ScrollBar;
    this.dS容器1.Controls.Add((Control) this.myTabControl1);
    this.dS容器1.Location = new System.Drawing.Point(0, 8);
    this.dS容器1.Margin = new System.Windows.Forms.Padding(0);
    this.dS容器1.Name = "dS容器1";
    this.dS容器1.Size = new System.Drawing.Size(892, 347);
    this.dS容器1.TabIndex = 0;
    this.dS容器1.标题文本偏移 = new System.Drawing.Point(0, 0);
    this.dS容器1.贴图 = (Bitmap) null;
    this.dS容器1.贴图切割边距.上 = 0;
    this.dS容器1.贴图切割边距.下 = 0;
    this.dS容器1.贴图切割边距.右 = 0;
    this.dS容器1.贴图切割边距.左 = 0;
    this.dS容器1.边栏颜色 = Color.Empty;
    this.dS容器1.边框颜色 = Color.Empty;
    this.dS容器1.透明度 = 1f;
    this.myTabControl1.BackColor = Color.Transparent;
    this.myTabControl1.BaseColor = SystemColors.ScrollBar;
    this.myTabControl1.BorderColor = Color.White;
    this.myTabControl1.Controls.Add((Control) this.tabPage11);
    this.myTabControl1.ItemSize = new System.Drawing.Size(80 /*0x50*/, 32 /*0x20*/);
    this.myTabControl1.Location = new System.Drawing.Point(0, 0);
    this.myTabControl1.Margin = new System.Windows.Forms.Padding(0);
    this.myTabControl1.Name = "myTabControl1";
    this.myTabControl1.PageColor = Color.White;
    this.myTabControl1.SelectedIndex = 0;
    this.myTabControl1.Size = new System.Drawing.Size(892, 347);
    this.myTabControl1.SizeMode = TabSizeMode.Fixed;
    this.myTabControl1.TabIndex = 52;
    this.tabPage11.BackColor = Color.White;
    this.tabPage11.Controls.Add((Control) this.dataGridViewX3);
    this.tabPage11.Location = new System.Drawing.Point(4, 36);
    this.tabPage11.Name = "tabPage11";
    this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
    this.tabPage11.Size = new System.Drawing.Size(884, 307);
    this.tabPage11.TabIndex = 0;
    this.tabPage11.Text = "主机";
    ((DataGridView) this.dataGridViewX3).AllowUserToDeleteRows = false;
    ((DataGridView) this.dataGridViewX3).BackgroundColor = SystemColors.ActiveCaption;
    ((DataGridView) this.dataGridViewX3).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
    ((DataGridView) this.dataGridViewX3).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
    ((DataGridView) this.dataGridViewX3).ColumnHeadersHeight = 43;
    ((DataGridView) this.dataGridViewX3).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
    ((DataGridView) this.dataGridViewX3).Columns.AddRange((DataGridViewColumn) this.dataGridViewCheckBoxColumn2, (DataGridViewColumn) this.dataGridViewTextBoxColumn6, (DataGridViewColumn) this.dataGridViewComboBoxColumn2, (DataGridViewColumn) this.dataGridViewTextBoxColumn7, (DataGridViewColumn) this.dataGridViewTextBoxColumn8, (DataGridViewColumn) this.dataGridViewTextBoxColumn9, (DataGridViewColumn) this.dataGridViewTextBoxColumn10);
    gridViewCellStyle39.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle39.BackColor = SystemColors.Window;
    gridViewCellStyle39.Font = new Font("宋体", 9f);
    gridViewCellStyle39.ForeColor = SystemColors.ControlText;
    gridViewCellStyle39.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle39.SelectionForeColor = SystemColors.ControlText;
    gridViewCellStyle39.WrapMode = DataGridViewTriState.False;
    ((DataGridView) this.dataGridViewX3).DefaultCellStyle = gridViewCellStyle39;
    ((DataGridView) this.dataGridViewX3).EditMode = DataGridViewEditMode.EditOnEnter;
    ((DataGridView) this.dataGridViewX3).GridColor = Color.FromArgb(208 /*0xD0*/, 215, 229);
    ((Control) this.dataGridViewX3).Location = new System.Drawing.Point(0, 0);
    ((Control) this.dataGridViewX3).Margin = new System.Windows.Forms.Padding(0);
    ((DataGridView) this.dataGridViewX3).MultiSelect = false;
    ((Control) this.dataGridViewX3).Name = "dataGridViewX3";
    ((DataGridView) this.dataGridViewX3).RowHeadersVisible = false;
    ((DataGridView) this.dataGridViewX3).RowHeadersWidth = 40;
    ((DataGridView) this.dataGridViewX3).RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
    gridViewCellStyle40.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    ((DataGridView) this.dataGridViewX3).RowsDefaultCellStyle = gridViewCellStyle40;
    ((DataGridView) this.dataGridViewX3).RowTemplate.Height = 23;
    ((DataGridView) this.dataGridViewX3).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    ((DataGridView) this.dataGridViewX3).ShowCellToolTips = false;
    ((Control) this.dataGridViewX3).Size = new System.Drawing.Size(884, 307);
    ((Control) this.dataGridViewX3).TabIndex = 51;
    gridViewCellStyle41.Alignment = DataGridViewContentAlignment.MiddleCenter;
    gridViewCellStyle41.Font = new Font("微软雅黑", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    gridViewCellStyle41.NullValue = (object) false;
    this.dataGridViewCheckBoxColumn2.DefaultCellStyle = gridViewCellStyle41;
    this.dataGridViewCheckBoxColumn2.FillWeight = 500f;
    this.dataGridViewCheckBoxColumn2.HeaderText = "主机";
    this.dataGridViewCheckBoxColumn2.MinimumWidth = 10;
    this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
    this.dataGridViewCheckBoxColumn2.Width = 40;
    gridViewCellStyle42.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle42.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dataGridViewTextBoxColumn6.DefaultCellStyle = gridViewCellStyle42;
    this.dataGridViewTextBoxColumn6.HeaderText = "通道";
    this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
    this.dataGridViewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn6.Width = 75;
    this.dataGridViewComboBoxColumn2.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    this.dataGridViewComboBoxColumn2.DisplayStyleForCurrentCellOnly = true;
    this.dataGridViewComboBoxColumn2.FlatStyle = FlatStyle.Flat;
    this.dataGridViewComboBoxColumn2.HeaderText = "方向";
    this.dataGridViewComboBoxColumn2.Items.AddRange((object) "发送", (object) "接收");
    this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
    this.dataGridViewComboBoxColumn2.Width = 90;
    gridViewCellStyle43.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewTextBoxColumn7.DefaultCellStyle = gridViewCellStyle43;
    this.dataGridViewTextBoxColumn7.HeaderText = "ID";
    this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
    this.dataGridViewTextBoxColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn7.Width = 108;
    this.dataGridViewTextBoxColumn8.HeaderText = "数据(Hex)";
    this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
    this.dataGridViewTextBoxColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn8.Width = 300;
    gridViewCellStyle44.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewTextBoxColumn9.DefaultCellStyle = gridViewCellStyle44;
    this.dataGridViewTextBoxColumn9.HeaderText = "长度";
    this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
    this.dataGridViewTextBoxColumn9.SortMode = DataGridViewColumnSortMode.NotSortable;
    this.dataGridViewTextBoxColumn9.Width = 95;
    gridViewCellStyle45.Alignment = DataGridViewContentAlignment.MiddleLeft;
    this.dataGridViewTextBoxColumn10.DefaultCellStyle = gridViewCellStyle45;
    this.dataGridViewTextBoxColumn10.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
    this.dataGridViewTextBoxColumn10.DisplayStyleForCurrentCellOnly = true;
    this.dataGridViewTextBoxColumn10.FlatStyle = FlatStyle.Flat;
    this.dataGridViewTextBoxColumn10.HeaderText = "校验和类型";
    this.dataGridViewTextBoxColumn10.Items.AddRange((object) "增强型校验和", (object) "标准型校验和");
    this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
    this.dataGridViewTextBoxColumn10.Resizable = DataGridViewTriState.True;
    this.dataGridViewTextBoxColumn10.Width = 150;
    this.tabPage6.BackColor = Color.Gainsboro;
    this.tabPage6.Controls.Add((Control) this.qqTextBox49);
    this.tabPage6.Controls.Add((Control) this.qqTextBox50);
    this.tabPage6.Controls.Add((Control) this.dS标签16);
    this.tabPage6.Controls.Add((Control) this.dS按钮12);
    this.tabPage6.Controls.Add((Control) this.dS按钮11);
    this.tabPage6.Controls.Add((Control) this.dS按钮10);
    this.tabPage6.Controls.Add((Control) this.dS标签6);
    this.tabPage6.Controls.Add((Control) this.dS按钮9);
    this.tabPage6.Controls.Add((Control) this.listViewNF5);
    this.tabPage6.Controls.Add((Control) this.qqTextBox33);
    this.tabPage6.Controls.Add((Control) this.qqTextBox30);
    this.tabPage6.Controls.Add((Control) this.qqTextBox31);
    this.tabPage6.Controls.Add((Control) this.qqTextBox32);
    this.tabPage6.Controls.Add((Control) this.label17);
    this.tabPage6.Location = new System.Drawing.Point(4, 22);
    this.tabPage6.Name = "tabPage6";
    this.tabPage6.Size = new System.Drawing.Size(892, 554);
    this.tabPage6.TabIndex = 3;
    this.tabPage6.Text = "BOOT升级";
    this.qqTextBox49.BackColor = Color.White;
    this.qqTextBox49.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox49.EmptyTextTip = (string) null;
    this.qqTextBox49.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox49.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox49.Location = new System.Drawing.Point(179, 19);
    this.qqTextBox49.MaxLength = 8;
    this.qqTextBox49.Name = "qqTextBox49";
    this.qqTextBox49.Size = new System.Drawing.Size(112 /*0x70*/, 26);
    this.qqTextBox49.TabIndex = 70;
    this.qqTextBox49.Text = "0x007800";
    this.qqTextBox49.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox50.BackColor = Color.White;
    this.qqTextBox50.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox50.EmptyTextTip = (string) null;
    this.qqTextBox50.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox50.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox50.Location = new System.Drawing.Point(462, 19);
    this.qqTextBox50.MaxLength = 8;
    this.qqTextBox50.Name = "qqTextBox50";
    this.qqTextBox50.Size = new System.Drawing.Size(112 /*0x70*/, 26);
    this.qqTextBox50.TabIndex = 69;
    this.qqTextBox50.Text = "0x019000";
    this.qqTextBox50.TextAlign = HorizontalAlignment.Center;
    this.dS标签16.BackColor = Color.Transparent;
    this.dS标签16.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS标签16.Location = new System.Drawing.Point(104, 18);
    this.dS标签16.Margin = new System.Windows.Forms.Padding(0);
    this.dS标签16.Name = "dS标签16";
    this.dS标签16.Size = new System.Drawing.Size(470, 29);
    this.dS标签16.TabIndex = 68;
    this.dS标签16.Text = "起始地址:                                            结束地址:   ";
    this.dS标签16.偏移 = new System.Drawing.Point(0, 5);
    this.dS按钮12.BackColor = Color.Transparent;
    this.dS按钮12.BackgroundImage = (Image) componentResourceManager.GetObject("dS按钮12.BackgroundImage");
    this.dS按钮12.Cursor = Cursors.Default;
    this.dS按钮12.DialogResult = DialogResult.None;
    this.dS按钮12.ForeColor = Color.White;
    this.dS按钮12.Location = new System.Drawing.Point(752, 467);
    this.dS按钮12.Margin = new System.Windows.Forms.Padding(1);
    this.dS按钮12.Name = "dS按钮12";
    this.dS按钮12.Size = new System.Drawing.Size(71, 71);
    this.dS按钮12.TabIndex = 62;
    this.dS按钮12.图像 = (Bitmap) null;
    this.dS按钮12.异形透明度采样百分比 = 0.1f;
    进度条7.指示进度 = 0.0f;
    进度条7.进度条颜色 = Color.DodgerBlue;
    this.dS按钮12.指示进度条 = 进度条7;
    this.dS按钮12.文本 = "";
    this.dS按钮12.禁用时透明度 = 0.3f;
    this.dS按钮12.自动尺寸扩展 = new System.Drawing.Size(20, 20);
    this.dS按钮12.自定义图像.按下 = (Bitmap) null;
    this.dS按钮12.自定义图像.禁用 = (Bitmap) null;
    this.dS按钮12.自定义图像.高亮 = (Bitmap) null;
    this.dS按钮12.自定义图像.默认 = (Bitmap) null;
    this.dS按钮12.贴图 = (Bitmap) componentResourceManager.GetObject("dS按钮12.贴图");
    this.dS按钮12.贴图切割边距.上 = 0;
    this.dS按钮12.贴图切割边距.下 = 0;
    this.dS按钮12.贴图切割边距.右 = 0;
    this.dS按钮12.贴图切割边距.左 = 0;
    this.dS按钮12.贴图模式 = DS按钮._贴图模式.贴图;
    this.dS按钮12.透明度 = 1f;
    this.dS按钮12.附加内容字体 = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS按钮12.ButtonClick += new DS按钮.ButtonClickEventHandler(this.dS按钮12_ButtonClick);
    this.dS按钮11.BackColor = Color.Transparent;
    this.dS按钮11.BackgroundImage = (Image) componentResourceManager.GetObject("dS按钮11.BackgroundImage");
    this.dS按钮11.Cursor = Cursors.Default;
    this.dS按钮11.DialogResult = DialogResult.None;
    this.dS按钮11.ForeColor = Color.White;
    this.dS按钮11.Location = new System.Drawing.Point(663, 288);
    this.dS按钮11.Margin = new System.Windows.Forms.Padding(1);
    this.dS按钮11.Name = "dS按钮11";
    this.dS按钮11.Size = new System.Drawing.Size(160 /*0xA0*/, 151);
    this.dS按钮11.TabIndex = 61;
    this.dS按钮11.图像 = (Bitmap) null;
    this.dS按钮11.异形透明度采样百分比 = 0.1f;
    进度条8.指示进度 = 0.0f;
    进度条8.进度条颜色 = Color.DodgerBlue;
    this.dS按钮11.指示进度条 = 进度条8;
    this.dS按钮11.文本 = "";
    this.dS按钮11.禁用时透明度 = 0.3f;
    this.dS按钮11.自动尺寸扩展 = new System.Drawing.Size(20, 20);
    this.dS按钮11.自定义图像.按下 = (Bitmap) null;
    this.dS按钮11.自定义图像.禁用 = (Bitmap) null;
    this.dS按钮11.自定义图像.高亮 = (Bitmap) null;
    this.dS按钮11.自定义图像.默认 = (Bitmap) null;
    this.dS按钮11.贴图 = Resources.灯6;
    this.dS按钮11.贴图切割边距.上 = 0;
    this.dS按钮11.贴图切割边距.下 = 0;
    this.dS按钮11.贴图切割边距.右 = 0;
    this.dS按钮11.贴图切割边距.左 = 0;
    this.dS按钮11.贴图模式 = DS按钮._贴图模式.贴图;
    this.dS按钮11.透明度 = 1f;
    this.dS按钮11.附加内容字体 = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS按钮10.BackColor = Color.Transparent;
    this.dS按钮10.BackgroundImage = (Image) componentResourceManager.GetObject("dS按钮10.BackgroundImage");
    this.dS按钮10.Cursor = Cursors.Default;
    this.dS按钮10.DialogResult = DialogResult.None;
    this.dS按钮10.ForeColor = Color.White;
    this.dS按钮10.Location = new System.Drawing.Point(663, 115);
    this.dS按钮10.Margin = new System.Windows.Forms.Padding(1);
    this.dS按钮10.Name = "dS按钮10";
    this.dS按钮10.Size = new System.Drawing.Size(160 /*0xA0*/, 151);
    this.dS按钮10.TabIndex = 60;
    this.dS按钮10.图像 = (Bitmap) null;
    this.dS按钮10.异形透明度采样百分比 = 0.1f;
    进度条9.指示进度 = 0.0f;
    进度条9.进度条颜色 = Color.DodgerBlue;
    this.dS按钮10.指示进度条 = 进度条9;
    this.dS按钮10.文本 = "";
    this.dS按钮10.禁用时透明度 = 0.3f;
    this.dS按钮10.自动尺寸扩展 = new System.Drawing.Size(20, 20);
    this.dS按钮10.自定义图像.按下 = (Bitmap) null;
    this.dS按钮10.自定义图像.禁用 = (Bitmap) null;
    this.dS按钮10.自定义图像.高亮 = (Bitmap) null;
    this.dS按钮10.自定义图像.默认 = (Bitmap) null;
    this.dS按钮10.贴图 = Resources.按钮3;
    this.dS按钮10.贴图切割边距.上 = 0;
    this.dS按钮10.贴图切割边距.下 = 0;
    this.dS按钮10.贴图切割边距.右 = 0;
    this.dS按钮10.贴图切割边距.左 = 0;
    this.dS按钮10.贴图模式 = DS按钮._贴图模式.贴图;
    this.dS按钮10.透明度 = 1f;
    this.dS按钮10.附加内容字体 = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS按钮10.ButtonClick += new DS按钮.ButtonClickEventHandler(this.dS按钮10_ButtonClick);
    this.dS标签6.BackColor = Color.Transparent;
    this.dS标签6.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS标签6.Location = new System.Drawing.Point(631, 18);
    this.dS标签6.Margin = new System.Windows.Forms.Padding(0);
    this.dS标签6.Name = "dS标签6";
    this.dS标签6.Size = new System.Drawing.Size(256 /*0x0100*/, 29);
    this.dS标签6.TabIndex = 59;
    this.dS标签6.Text = "主机ID:       从机ID:       周期(ms):";
    this.dS标签6.偏移 = new System.Drawing.Point(0, 5);
    this.dS按钮9.BackColor = Color.Transparent;
    this.dS按钮9.BackgroundImage = (Image) componentResourceManager.GetObject("dS按钮9.BackgroundImage");
    this.dS按钮9.Cursor = Cursors.Default;
    this.dS按钮9.DialogResult = DialogResult.None;
    this.dS按钮9.ForeColor = Color.Black;
    this.dS按钮9.Location = new System.Drawing.Point(27, 50);
    this.dS按钮9.Margin = new System.Windows.Forms.Padding(1);
    this.dS按钮9.Name = "dS按钮9";
    this.dS按钮9.Size = new System.Drawing.Size(66, 29);
    this.dS按钮9.TabIndex = 58;
    this.dS按钮9.Text = "打开文件";
    this.dS按钮9.图像 = (Bitmap) null;
    this.dS按钮9.异形透明度采样百分比 = 0.1f;
    进度条10.指示进度 = 0.0f;
    进度条10.进度条颜色 = Color.DodgerBlue;
    this.dS按钮9.指示进度条 = 进度条10;
    this.dS按钮9.文字描边 = Color.Transparent;
    this.dS按钮9.文本 = "打开文件";
    this.dS按钮9.禁用时透明度 = 0.3f;
    this.dS按钮9.自动尺寸扩展 = new System.Drawing.Size(20, 20);
    this.dS按钮9.自定义图像.按下 = (Bitmap) null;
    this.dS按钮9.自定义图像.禁用 = (Bitmap) null;
    this.dS按钮9.自定义图像.高亮 = (Bitmap) null;
    this.dS按钮9.自定义图像.默认 = (Bitmap) null;
    this.dS按钮9.贴图 = (Bitmap) componentResourceManager.GetObject("dS按钮9.贴图");
    this.dS按钮9.贴图切割边距.上 = 0;
    this.dS按钮9.贴图切割边距.下 = 0;
    this.dS按钮9.贴图切割边距.右 = 0;
    this.dS按钮9.贴图切割边距.左 = 0;
    this.dS按钮9.贴图模式 = DS按钮._贴图模式.贴图;
    this.dS按钮9.透明度 = 1f;
    this.dS按钮9.附加内容字体 = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS按钮9.ButtonClick += new DS按钮.ButtonClickEventHandler(this.dS按钮9_ButtonClick);
    this.listViewNF5.BackColor = SystemColors.ActiveCaption;
    this.listViewNF5.BorderStyle = BorderStyle.None;
    this.listViewNF5.Columns.AddRange(new ColumnHeader[1]
    {
      this.columnHeader37
    });
    this.listViewNF5.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.listViewNF5.ForeColor = Color.White;
    this.listViewNF5.HideSelection = false;
    this.listViewNF5.Location = new System.Drawing.Point(27, 96 /*0x60*/);
    this.listViewNF5.Margin = new System.Windows.Forms.Padding(0);
    this.listViewNF5.MultiSelect = false;
    this.listViewNF5.Name = "listViewNF5";
    this.listViewNF5.Size = new System.Drawing.Size(550, 380);
    this.listViewNF5.TabIndex = 57;
    this.listViewNF5.UseCompatibleStateImageBehavior = false;
    this.listViewNF5.View = View.Details;
    this.columnHeader37.Text = "升级状态：";
    this.columnHeader37.Width = 500;
    this.qqTextBox33.BackColor = Color.White;
    this.qqTextBox33.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox33.EmptyTextTip = (string) null;
    this.qqTextBox33.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox33.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox33.Location = new System.Drawing.Point(804, 50);
    this.qqTextBox33.MaxLength = 4;
    this.qqTextBox33.Name = "qqTextBox33";
    this.qqTextBox33.Size = new System.Drawing.Size(58, 26);
    this.qqTextBox33.TabIndex = 56;
    this.qqTextBox33.Text = "20";
    this.qqTextBox33.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox30.BackColor = Color.White;
    this.qqTextBox30.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox30.EmptyTextTip = (string) null;
    this.qqTextBox30.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox30.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox30.Location = new System.Drawing.Point(104, 51);
    this.qqTextBox30.Name = "qqTextBox30";
    this.qqTextBox30.ReadOnly = true;
    this.qqTextBox30.Size = new System.Drawing.Size(470, 26);
    this.qqTextBox30.TabIndex = 52;
    this.qqTextBox31.BackColor = Color.White;
    this.qqTextBox31.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox31.EmptyTextTip = (string) null;
    this.qqTextBox31.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox31.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox31.Location = new System.Drawing.Point(631, 50);
    this.qqTextBox31.MaxLength = 2;
    this.qqTextBox31.Name = "qqTextBox31";
    this.qqTextBox31.Size = new System.Drawing.Size(58, 26);
    this.qqTextBox31.TabIndex = 55;
    this.qqTextBox31.Text = "3E";
    this.qqTextBox31.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox32.BackColor = Color.White;
    this.qqTextBox32.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox32.EmptyTextTip = (string) null;
    this.qqTextBox32.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox32.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox32.Location = new System.Drawing.Point(718, 50);
    this.qqTextBox32.MaxLength = 2;
    this.qqTextBox32.Name = "qqTextBox32";
    this.qqTextBox32.Size = new System.Drawing.Size(58, 26);
    this.qqTextBox32.TabIndex = 54;
    this.qqTextBox32.Text = "3F";
    this.qqTextBox32.TextAlign = HorizontalAlignment.Center;
    this.label17.AutoSize = true;
    this.label17.BackColor = Color.Transparent;
    this.label17.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.label17.ForeColor = Color.Black;
    this.label17.Location = new System.Drawing.Point(642, 488);
    this.label17.Margin = new System.Windows.Forms.Padding(0);
    this.label17.Name = "label17";
    this.label17.Size = new System.Drawing.Size(96 /*0x60*/, 20);
    this.label17.TabIndex = 53;
    this.label17.Text = "打开通信协议:";
    this.tabPage7.BackColor = Color.DarkSalmon;
    this.tabPage7.Controls.Add((Control) this.qqTextBox48);
    this.tabPage7.Controls.Add((Control) this.qqTextBox47);
    this.tabPage7.Controls.Add((Control) this.qqCheckBox21);
    this.tabPage7.Controls.Add((Control) this.qqTextBox46);
    this.tabPage7.Controls.Add((Control) this.qqCheckBox20);
    this.tabPage7.Controls.Add((Control) this.qqTextBox45);
    this.tabPage7.Controls.Add((Control) this.qqCheckBox19);
    this.tabPage7.Controls.Add((Control) this.dS标签15);
    this.tabPage7.Controls.Add((Control) this.qqTextBox44);
    this.tabPage7.Controls.Add((Control) this.dS标签14);
    this.tabPage7.Controls.Add((Control) this.dS按钮14);
    this.tabPage7.Controls.Add((Control) this.dS按钮15);
    this.tabPage7.Controls.Add((Control) this.myButton1);
    this.tabPage7.Controls.Add((Control) this.dS标签13);
    this.tabPage7.Controls.Add((Control) this.dS容器4);
    this.tabPage7.Controls.Add((Control) this.dS容器3);
    this.tabPage7.Location = new System.Drawing.Point(4, 22);
    this.tabPage7.Name = "tabPage7";
    this.tabPage7.Size = new System.Drawing.Size(892, 554);
    this.tabPage7.TabIndex = 4;
    this.tabPage7.Text = "开发者选项";
    this.qqTextBox48.BackColor = Color.White;
    this.qqTextBox48.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox48.EmptyTextTip = (string) null;
    this.qqTextBox48.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox48.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox48.Location = new System.Drawing.Point(531, 430);
    this.qqTextBox48.MaxLength = 5;
    this.qqTextBox48.Name = "qqTextBox48";
    this.qqTextBox48.Size = new System.Drawing.Size(82, 29);
    this.qqTextBox48.TabIndex = 77;
    this.qqTextBox48.Text = "0";
    this.qqTextBox48.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox47.BackColor = Color.White;
    this.qqTextBox47.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox47.EmptyTextTip = (string) null;
    this.qqTextBox47.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox47.Font = new Font("宋体", 9f);
    this.qqTextBox47.Location = new System.Drawing.Point(558, 508);
    this.qqTextBox47.MaxLength = 2;
    this.qqTextBox47.Name = "qqTextBox47";
    this.qqTextBox47.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox47.TabIndex = 76;
    this.qqTextBox47.Text = "00";
    this.qqTextBox47.TextAlign = HorizontalAlignment.Center;
    this.qqCheckBox21.AutoSize = true;
    this.qqCheckBox21.BackColor = Color.Transparent;
    this.qqCheckBox21.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqCheckBox21.Location = new System.Drawing.Point(493, 507);
    this.qqCheckBox21.Name = "qqCheckBox21";
    this.qqCheckBox21.Size = new System.Drawing.Size(59, 21);
    this.qqCheckBox21.TabIndex = 75;
    this.qqCheckBox21.Text = "ID3：";
    this.qqCheckBox21.UseVisualStyleBackColor = false;
    this.qqCheckBox21.CheckedChanged += new EventHandler(this.qqCheckBox21_CheckedChanged);
    this.qqTextBox46.BackColor = Color.White;
    this.qqTextBox46.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox46.EmptyTextTip = (string) null;
    this.qqTextBox46.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox46.Font = new Font("宋体", 9f);
    this.qqTextBox46.Location = new System.Drawing.Point(408, 507);
    this.qqTextBox46.MaxLength = 2;
    this.qqTextBox46.Name = "qqTextBox46";
    this.qqTextBox46.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox46.TabIndex = 74;
    this.qqTextBox46.Text = "00";
    this.qqTextBox46.TextAlign = HorizontalAlignment.Center;
    this.qqCheckBox20.AutoSize = true;
    this.qqCheckBox20.BackColor = Color.Transparent;
    this.qqCheckBox20.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqCheckBox20.Location = new System.Drawing.Point(343, 506);
    this.qqCheckBox20.Name = "qqCheckBox20";
    this.qqCheckBox20.Size = new System.Drawing.Size(59, 21);
    this.qqCheckBox20.TabIndex = 73;
    this.qqCheckBox20.Text = "ID2：";
    this.qqCheckBox20.UseVisualStyleBackColor = false;
    this.qqCheckBox20.CheckedChanged += new EventHandler(this.qqCheckBox20_CheckedChanged);
    this.qqTextBox45.BackColor = Color.White;
    this.qqTextBox45.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox45.EmptyTextTip = (string) null;
    this.qqTextBox45.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox45.Font = new Font("宋体", 9f);
    this.qqTextBox45.Location = new System.Drawing.Point(251, 506);
    this.qqTextBox45.MaxLength = 2;
    this.qqTextBox45.Name = "qqTextBox45";
    this.qqTextBox45.Size = new System.Drawing.Size(55, 21);
    this.qqTextBox45.TabIndex = 72;
    this.qqTextBox45.Text = "00";
    this.qqTextBox45.TextAlign = HorizontalAlignment.Center;
    this.qqCheckBox19.AutoSize = true;
    this.qqCheckBox19.BackColor = Color.Transparent;
    this.qqCheckBox19.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqCheckBox19.Location = new System.Drawing.Point(186, 505);
    this.qqCheckBox19.Name = "qqCheckBox19";
    this.qqCheckBox19.Size = new System.Drawing.Size(59, 21);
    this.qqCheckBox19.TabIndex = 71;
    this.qqCheckBox19.Text = "ID1：";
    this.qqCheckBox19.UseVisualStyleBackColor = false;
    this.qqCheckBox19.CheckedChanged += new EventHandler(this.qqCheckBox19_CheckedChanged);
    this.dS标签15.BackColor = Color.Transparent;
    this.dS标签15.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS标签15.Location = new System.Drawing.Point(644, 402);
    this.dS标签15.Margin = new System.Windows.Forms.Padding(0);
    this.dS标签15.Name = "dS标签15";
    this.dS标签15.Size = new System.Drawing.Size(235, 35);
    this.dS标签15.TabIndex = 70;
    this.dS标签15.Text = "发送状态:  0/0";
    this.dS标签15.偏移 = new System.Drawing.Point(0, 5);
    this.qqTextBox44.BackColor = Color.White;
    this.qqTextBox44.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox44.EmptyTextTip = (string) null;
    this.qqTextBox44.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox44.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox44.Location = new System.Drawing.Point(334, 430);
    this.qqTextBox44.MaxLength = 4;
    this.qqTextBox44.Name = "qqTextBox44";
    this.qqTextBox44.Size = new System.Drawing.Size(89, 29);
    this.qqTextBox44.TabIndex = 69;
    this.qqTextBox44.Text = "50";
    this.qqTextBox44.TextAlign = HorizontalAlignment.Center;
    this.dS标签14.BackColor = Color.Transparent;
    this.dS标签14.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS标签14.Location = new System.Drawing.Point(186, 429);
    this.dS标签14.Margin = new System.Windows.Forms.Padding(0);
    this.dS标签14.Name = "dS标签14";
    this.dS标签14.Size = new System.Drawing.Size(449, 112 /*0x70*/);
    this.dS标签14.TabIndex = 68;
    this.dS标签14.Text = "定时发送间隔(ms)：                          回放次数：\r\n\r\n屏蔽发送ID：    ";
    this.dS标签14.偏移 = new System.Drawing.Point(0, 5);
    this.dS按钮14.BackColor = Color.Transparent;
    this.dS按钮14.BackgroundImage = (Image) componentResourceManager.GetObject("dS按钮14.BackgroundImage");
    this.dS按钮14.Cursor = Cursors.Default;
    this.dS按钮14.DialogResult = DialogResult.None;
    this.dS按钮14.ForeColor = Color.White;
    this.dS按钮14.Location = new System.Drawing.Point(778, 451);
    this.dS按钮14.Margin = new System.Windows.Forms.Padding(1);
    this.dS按钮14.Name = "dS按钮14";
    this.dS按钮14.Size = new System.Drawing.Size(75, 75);
    this.dS按钮14.TabIndex = 57;
    this.dS按钮14.图像 = (Bitmap) null;
    this.dS按钮14.异形透明度采样百分比 = 0.1f;
    进度条11.指示进度 = 0.0f;
    进度条11.进度条颜色 = Color.DodgerBlue;
    this.dS按钮14.指示进度条 = 进度条11;
    this.dS按钮14.文本 = "";
    this.dS按钮14.禁用时透明度 = 0.3f;
    this.dS按钮14.自动尺寸扩展 = new System.Drawing.Size(20, 20);
    this.dS按钮14.自定义图像.按下 = (Bitmap) null;
    this.dS按钮14.自定义图像.禁用 = (Bitmap) null;
    this.dS按钮14.自定义图像.高亮 = (Bitmap) null;
    this.dS按钮14.自定义图像.默认 = (Bitmap) null;
    this.dS按钮14.贴图 = (Bitmap) componentResourceManager.GetObject("dS按钮14.贴图");
    this.dS按钮14.贴图切割边距.上 = 0;
    this.dS按钮14.贴图切割边距.下 = 0;
    this.dS按钮14.贴图切割边距.右 = 0;
    this.dS按钮14.贴图切割边距.左 = 0;
    this.dS按钮14.贴图模式 = DS按钮._贴图模式.贴图;
    this.dS按钮14.透明度 = 1f;
    this.dS按钮14.附加内容字体 = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS按钮14.ButtonClick += new DS按钮.ButtonClickEventHandler(this.dS按钮14_ButtonClick);
    this.dS按钮15.BackColor = Color.Transparent;
    this.dS按钮15.BackgroundImage = (Image) componentResourceManager.GetObject("dS按钮15.BackgroundImage");
    this.dS按钮15.Cursor = Cursors.Default;
    this.dS按钮15.DialogResult = DialogResult.None;
    this.dS按钮15.ForeColor = Color.White;
    this.dS按钮15.Location = new System.Drawing.Point(664, 451);
    this.dS按钮15.Margin = new System.Windows.Forms.Padding(1);
    this.dS按钮15.Name = "dS按钮15";
    this.dS按钮15.Size = new System.Drawing.Size(75, 75);
    this.dS按钮15.TabIndex = 56;
    this.dS按钮15.TabStop = false;
    this.dS按钮15.图像 = (Bitmap) null;
    this.dS按钮15.异形透明度采样百分比 = 0.1f;
    进度条12.指示进度 = 0.0f;
    进度条12.进度条颜色 = Color.DodgerBlue;
    this.dS按钮15.指示进度条 = 进度条12;
    this.dS按钮15.文本 = "";
    this.dS按钮15.禁用时透明度 = 0.3f;
    this.dS按钮15.自动尺寸扩展 = new System.Drawing.Size(20, 20);
    this.dS按钮15.自定义图像.按下 = (Bitmap) null;
    this.dS按钮15.自定义图像.禁用 = (Bitmap) null;
    this.dS按钮15.自定义图像.高亮 = (Bitmap) null;
    this.dS按钮15.自定义图像.默认 = (Bitmap) null;
    this.dS按钮15.贴图 = (Bitmap) componentResourceManager.GetObject("dS按钮15.贴图");
    this.dS按钮15.贴图切割边距.上 = 0;
    this.dS按钮15.贴图切割边距.下 = 0;
    this.dS按钮15.贴图切割边距.右 = 0;
    this.dS按钮15.贴图切割边距.左 = 0;
    this.dS按钮15.贴图模式 = DS按钮._贴图模式.贴图;
    this.dS按钮15.透明度 = 1f;
    this.dS按钮15.附加内容字体 = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS按钮15.ButtonClick += new DS按钮.ButtonClickEventHandler(this.dS按钮15_ButtonClick);
    this.myButton1.BackColor = Color.Transparent;
    this.myButton1.BackgroundImageLayout = ImageLayout.Center;
    this.myButton1.DownImage = (Image) componentResourceManager.GetObject("myButton1.DownImage");
    this.myButton1.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.myButton1.ForeColor = SystemColors.InfoText;
    this.myButton1.Image = (Image) componentResourceManager.GetObject("myButton1.Image");
    this.myButton1.IsShowBorder = false;
    this.myButton1.Location = new System.Drawing.Point(27, 429);
    this.myButton1.Margin = new System.Windows.Forms.Padding(0);
    this.myButton1.MoveImage = (Image) componentResourceManager.GetObject("myButton1.MoveImage");
    this.myButton1.Name = "myButton1";
    this.myButton1.NormalImage = (Image) componentResourceManager.GetObject("myButton1.NormalImage");
    this.myButton1.Size = new System.Drawing.Size(128 /*0x80*/, 100);
    this.myButton1.TabIndex = 55;
    this.myButton1.Text = "导入数据";
    this.myButton1.UseVisualStyleBackColor = false;
    this.myButton1.Click += new EventHandler(this.myButton1_Click);
    this.dS标签13.BackColor = Color.Transparent;
    this.dS标签13.Font = new Font("微软雅黑", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    this.dS标签13.Location = new System.Drawing.Point(27, 383);
    this.dS标签13.Margin = new System.Windows.Forms.Padding(0);
    this.dS标签13.Name = "dS标签13";
    this.dS标签13.Size = new System.Drawing.Size(128 /*0x80*/, 35);
    this.dS标签13.TabIndex = 2;
    this.dS标签13.Text = "数据回放区:";
    this.dS标签13.偏移 = new System.Drawing.Point(0, 5);
    this.dS容器4.BackColor = SystemColors.ActiveCaption;
    this.dS容器4.Controls.Add((Control) this.dS标签12);
    this.dS容器4.Controls.Add((Control) this.dS按钮13);
    this.dS容器4.Controls.Add((Control) this.qqTextBox43);
    this.dS容器4.Controls.Add((Control) this.qqTextBox40);
    this.dS容器4.Controls.Add((Control) this.qqTextBox42);
    this.dS容器4.Controls.Add((Control) this.qqTextBox39);
    this.dS容器4.Controls.Add((Control) this.qqTextBox41);
    this.dS容器4.Controls.Add((Control) this.dS标签11);
    this.dS容器4.Controls.Add((Control) this.imageButton17);
    this.dS容器4.Controls.Add((Control) this.dS标签9);
    this.dS容器4.Location = new System.Drawing.Point(0, 179);
    this.dS容器4.Margin = new System.Windows.Forms.Padding(0);
    this.dS容器4.Name = "dS容器4";
    this.dS容器4.Size = new System.Drawing.Size(892, 195);
    this.dS容器4.TabIndex = 1;
    this.dS容器4.标题文本偏移 = new System.Drawing.Point(0, 0);
    this.dS容器4.贴图 = (Bitmap) null;
    this.dS容器4.贴图切割边距.上 = 0;
    this.dS容器4.贴图切割边距.下 = 0;
    this.dS容器4.贴图切割边距.右 = 0;
    this.dS容器4.贴图切割边距.左 = 0;
    this.dS容器4.边栏颜色 = Color.Empty;
    this.dS容器4.边框颜色 = Color.Empty;
    this.dS容器4.透明度 = 1f;
    this.dS标签12.BackColor = Color.Transparent;
    this.dS标签12.Font = new Font("微软雅黑", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    this.dS标签12.Location = new System.Drawing.Point(769, 63 /*0x3F*/);
    this.dS标签12.Margin = new System.Windows.Forms.Padding(0);
    this.dS标签12.Name = "dS标签12";
    this.dS标签12.Size = new System.Drawing.Size(90, 35);
    this.dS标签12.TabIndex = 69;
    this.dS标签12.Text = "启动唤醒";
    this.dS标签12.偏移 = new System.Drawing.Point(0, 5);
    this.dS按钮13.BackColor = Color.Transparent;
    this.dS按钮13.BackgroundImage = (Image) componentResourceManager.GetObject("dS按钮13.BackgroundImage");
    this.dS按钮13.Cursor = Cursors.Default;
    this.dS按钮13.DialogResult = DialogResult.None;
    this.dS按钮13.ForeColor = Color.White;
    this.dS按钮13.Location = new System.Drawing.Point(778, 106);
    this.dS按钮13.Margin = new System.Windows.Forms.Padding(1);
    this.dS按钮13.Name = "dS按钮13";
    this.dS按钮13.Size = new System.Drawing.Size(75, 75);
    this.dS按钮13.TabIndex = 68;
    this.dS按钮13.TabStop = false;
    this.dS按钮13.图像 = (Bitmap) null;
    this.dS按钮13.异形透明度采样百分比 = 0.1f;
    进度条13.指示进度 = 0.0f;
    进度条13.进度条颜色 = Color.DodgerBlue;
    this.dS按钮13.指示进度条 = 进度条13;
    this.dS按钮13.文本 = "";
    this.dS按钮13.禁用时透明度 = 0.3f;
    this.dS按钮13.自动尺寸扩展 = new System.Drawing.Size(20, 20);
    this.dS按钮13.自定义图像.按下 = (Bitmap) null;
    this.dS按钮13.自定义图像.禁用 = (Bitmap) null;
    this.dS按钮13.自定义图像.高亮 = (Bitmap) null;
    this.dS按钮13.自定义图像.默认 = (Bitmap) null;
    this.dS按钮13.贴图 = (Bitmap) componentResourceManager.GetObject("dS按钮13.贴图");
    this.dS按钮13.贴图切割边距.上 = 0;
    this.dS按钮13.贴图切割边距.下 = 0;
    this.dS按钮13.贴图切割边距.右 = 0;
    this.dS按钮13.贴图切割边距.左 = 0;
    this.dS按钮13.贴图模式 = DS按钮._贴图模式.贴图;
    this.dS按钮13.透明度 = 1f;
    this.dS按钮13.附加内容字体 = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox43.BackColor = Color.White;
    this.qqTextBox43.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox43.EmptyTextTip = (string) null;
    this.qqTextBox43.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox43.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox43.Location = new System.Drawing.Point(693, 136);
    this.qqTextBox43.Name = "qqTextBox43";
    this.qqTextBox43.ReadOnly = true;
    this.qqTextBox43.Size = new System.Drawing.Size(43, 29);
    this.qqTextBox43.TabIndex = 66;
    this.qqTextBox43.Text = "00";
    this.qqTextBox43.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox40.BackColor = Color.White;
    this.qqTextBox40.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox40.EmptyTextTip = (string) null;
    this.qqTextBox40.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox40.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox40.Location = new System.Drawing.Point(186, 136);
    this.qqTextBox40.Name = "qqTextBox40";
    this.qqTextBox40.Size = new System.Drawing.Size(199, 29);
    this.qqTextBox40.TabIndex = 64 /*0x40*/;
    this.qqTextBox40.Text = "00 00 00 00 00 00 00 00";
    this.qqTextBox40.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox42.BackColor = Color.White;
    this.qqTextBox42.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox42.EmptyTextTip = (string) null;
    this.qqTextBox42.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox42.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox42.Location = new System.Drawing.Point(560, 136);
    this.qqTextBox42.Name = "qqTextBox42";
    this.qqTextBox42.ReadOnly = true;
    this.qqTextBox42.Size = new System.Drawing.Size(43, 29);
    this.qqTextBox42.TabIndex = 65;
    this.qqTextBox42.Text = "00";
    this.qqTextBox42.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox39.BackColor = Color.White;
    this.qqTextBox39.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox39.EmptyTextTip = (string) null;
    this.qqTextBox39.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox39.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox39.Location = new System.Drawing.Point(79, 136);
    this.qqTextBox39.Name = "qqTextBox39";
    this.qqTextBox39.Size = new System.Drawing.Size(43, 29);
    this.qqTextBox39.TabIndex = 63 /*0x3F*/;
    this.qqTextBox39.Text = "00";
    this.qqTextBox39.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox41.BackColor = Color.White;
    this.qqTextBox41.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox41.EmptyTextTip = (string) null;
    this.qqTextBox41.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox41.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox41.Location = new System.Drawing.Point(456, 136);
    this.qqTextBox41.Name = "qqTextBox41";
    this.qqTextBox41.Size = new System.Drawing.Size(43, 29);
    this.qqTextBox41.TabIndex = 62;
    this.qqTextBox41.Text = "8";
    this.qqTextBox41.TextAlign = HorizontalAlignment.Center;
    this.dS标签11.BackColor = Color.Transparent;
    this.dS标签11.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS标签11.Location = new System.Drawing.Point(27, 106);
    this.dS标签11.Margin = new System.Windows.Forms.Padding(0);
    this.dS标签11.Name = "dS标签11";
    this.dS标签11.Size = new System.Drawing.Size(724, 74);
    this.dS标签11.TabIndex = 67;
    this.dS标签11.Text = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n帧ID：           数据：                                            长度：             PID:              校验和：\r\n\r\n\r\n\r\n\r\n\r\n";
    this.dS标签11.偏移 = new System.Drawing.Point(0, 5);
    this.imageButton17.BackColor = Color.Transparent;
    this.imageButton17.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton17.DownImage = (Image) componentResourceManager.GetObject("imageButton17.DownImage");
    this.imageButton17.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton17.ForeColor = SystemColors.InfoText;
    this.imageButton17.Image = (Image) componentResourceManager.GetObject("imageButton17.Image");
    this.imageButton17.IsShowBorder = false;
    this.imageButton17.Location = new System.Drawing.Point(27, 56);
    this.imageButton17.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton17.MoveImage = (Image) componentResourceManager.GetObject("imageButton17.MoveImage");
    this.imageButton17.Name = "imageButton17";
    this.imageButton17.NormalImage = (Image) componentResourceManager.GetObject("imageButton17.NormalImage");
    this.imageButton17.Size = new System.Drawing.Size(102, 37);
    this.imageButton17.TabIndex = 54;
    this.imageButton17.Text = "发送睡眠命令";
    this.imageButton17.UseVisualStyleBackColor = false;
    this.imageButton17.Click += new EventHandler(this.imageButton17_Click);
    this.dS标签9.BackColor = Color.Transparent;
    this.dS标签9.Font = new Font("微软雅黑", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    this.dS标签9.Location = new System.Drawing.Point(27, 5);
    this.dS标签9.Margin = new System.Windows.Forms.Padding(0);
    this.dS标签9.Name = "dS标签9";
    this.dS标签9.Size = new System.Drawing.Size(128 /*0x80*/, 35);
    this.dS标签9.TabIndex = 1;
    this.dS标签9.Text = "网络管理区:";
    this.dS标签9.偏移 = new System.Drawing.Point(0, 5);
    this.dS容器3.BackColor = Color.FromArgb(224 /*0xE0*/, 224 /*0xE0*/, 224 /*0xE0*/);
    this.dS容器3.Controls.Add((Control) this.qqTextBox38);
    this.dS容器3.Controls.Add((Control) this.qqTextBox35);
    this.dS容器3.Controls.Add((Control) this.qqTextBox37);
    this.dS容器3.Controls.Add((Control) this.qqTextBox34);
    this.dS容器3.Controls.Add((Control) this.qqTextBox36);
    this.dS容器3.Controls.Add((Control) this.dS标签8);
    this.dS容器3.Controls.Add((Control) this.imageButton16);
    this.dS容器3.Controls.Add((Control) this.imageButton15);
    this.dS容器3.Controls.Add((Control) this.dS标签7);
    this.dS容器3.Location = new System.Drawing.Point(0, 8);
    this.dS容器3.Margin = new System.Windows.Forms.Padding(0);
    this.dS容器3.Name = "dS容器3";
    this.dS容器3.Size = new System.Drawing.Size(892, 171);
    this.dS容器3.TabIndex = 0;
    this.dS容器3.标题文本偏移 = new System.Drawing.Point(0, 0);
    this.dS容器3.贴图 = (Bitmap) null;
    this.dS容器3.贴图切割边距.上 = 0;
    this.dS容器3.贴图切割边距.下 = 0;
    this.dS容器3.贴图切割边距.右 = 0;
    this.dS容器3.贴图切割边距.左 = 0;
    this.dS容器3.边栏颜色 = Color.Empty;
    this.dS容器3.边框颜色 = Color.Empty;
    this.dS容器3.透明度 = 1f;
    this.qqTextBox38.BackColor = Color.White;
    this.qqTextBox38.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox38.EmptyTextTip = (string) null;
    this.qqTextBox38.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox38.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox38.Location = new System.Drawing.Point(829, 117);
    this.qqTextBox38.MaxLength = 2;
    this.qqTextBox38.Name = "qqTextBox38";
    this.qqTextBox38.ReadOnly = true;
    this.qqTextBox38.Size = new System.Drawing.Size(43, 29);
    this.qqTextBox38.TabIndex = 59;
    this.qqTextBox38.Text = "00";
    this.qqTextBox38.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox35.BackColor = Color.White;
    this.qqTextBox35.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox35.EmptyTextTip = (string) null;
    this.qqTextBox35.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox35.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox35.Location = new System.Drawing.Point(322, 117);
    this.qqTextBox35.MaxLength = 23;
    this.qqTextBox35.Name = "qqTextBox35";
    this.qqTextBox35.Size = new System.Drawing.Size(199, 29);
    this.qqTextBox35.TabIndex = 57;
    this.qqTextBox35.Text = "00 00 00 00 00 00 00 00";
    this.qqTextBox35.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox37.BackColor = Color.White;
    this.qqTextBox37.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox37.EmptyTextTip = (string) null;
    this.qqTextBox37.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox37.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox37.Location = new System.Drawing.Point(696, 117);
    this.qqTextBox37.MaxLength = 2;
    this.qqTextBox37.Name = "qqTextBox37";
    this.qqTextBox37.ReadOnly = true;
    this.qqTextBox37.Size = new System.Drawing.Size(43, 29);
    this.qqTextBox37.TabIndex = 58;
    this.qqTextBox37.Text = "00";
    this.qqTextBox37.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox34.BackColor = Color.White;
    this.qqTextBox34.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox34.EmptyTextTip = (string) null;
    this.qqTextBox34.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox34.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox34.Location = new System.Drawing.Point(215, 117);
    this.qqTextBox34.MaxLength = 2;
    this.qqTextBox34.Name = "qqTextBox34";
    this.qqTextBox34.Size = new System.Drawing.Size(43, 29);
    this.qqTextBox34.TabIndex = 56;
    this.qqTextBox34.Text = "00";
    this.qqTextBox34.TextAlign = HorizontalAlignment.Center;
    this.qqTextBox36.BackColor = Color.White;
    this.qqTextBox36.BorderStyle = BorderStyle.FixedSingle;
    this.qqTextBox36.EmptyTextTip = (string) null;
    this.qqTextBox36.EmptyTextTipColor = Color.DarkGray;
    this.qqTextBox36.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.qqTextBox36.Location = new System.Drawing.Point(592, 117);
    this.qqTextBox36.MaxLength = 1;
    this.qqTextBox36.Name = "qqTextBox36";
    this.qqTextBox36.Size = new System.Drawing.Size(43, 29);
    this.qqTextBox36.TabIndex = 55;
    this.qqTextBox36.Text = "8";
    this.qqTextBox36.TextAlign = HorizontalAlignment.Center;
    this.dS标签8.BackColor = Color.Transparent;
    this.dS标签8.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS标签8.Location = new System.Drawing.Point(163, 87);
    this.dS标签8.Margin = new System.Windows.Forms.Padding(0);
    this.dS标签8.Name = "dS标签8";
    this.dS标签8.Size = new System.Drawing.Size(724, 74);
    this.dS标签8.TabIndex = 60;
    this.dS标签8.Text = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n帧ID：           数据：                                            长度：             PID:              校验和：\r\n\r\n\r\n\r\n\r\n\r\n";
    this.dS标签8.偏移 = new System.Drawing.Point(0, 5);
    this.imageButton16.BackColor = Color.Transparent;
    this.imageButton16.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton16.DownImage = (Image) componentResourceManager.GetObject("imageButton16.DownImage");
    this.imageButton16.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton16.ForeColor = SystemColors.InfoText;
    this.imageButton16.Image = (Image) componentResourceManager.GetObject("imageButton16.Image");
    this.imageButton16.IsShowBorder = false;
    this.imageButton16.Location = new System.Drawing.Point(27, 114);
    this.imageButton16.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton16.MoveImage = (Image) componentResourceManager.GetObject("imageButton16.MoveImage");
    this.imageButton16.Name = "imageButton16";
    this.imageButton16.NormalImage = (Image) componentResourceManager.GetObject("imageButton16.NormalImage");
    this.imageButton16.Size = new System.Drawing.Size(102, 37);
    this.imageButton16.TabIndex = 54;
    this.imageButton16.Text = "计算参数";
    this.imageButton16.UseVisualStyleBackColor = false;
    this.imageButton16.Click += new EventHandler(this.imageButton16_Click);
    this.imageButton15.BackColor = Color.Transparent;
    this.imageButton15.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton15.DownImage = (Image) componentResourceManager.GetObject("imageButton15.DownImage");
    this.imageButton15.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton15.ForeColor = SystemColors.InfoText;
    this.imageButton15.Image = (Image) componentResourceManager.GetObject("imageButton15.Image");
    this.imageButton15.IsShowBorder = false;
    this.imageButton15.Location = new System.Drawing.Point(27, 50);
    this.imageButton15.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton15.MoveImage = (Image) componentResourceManager.GetObject("imageButton15.MoveImage");
    this.imageButton15.Name = "imageButton15";
    this.imageButton15.NormalImage = (Image) componentResourceManager.GetObject("imageButton15.NormalImage");
    this.imageButton15.Size = new System.Drawing.Size(102, 37);
    this.imageButton15.TabIndex = 53;
    this.imageButton15.Text = "自动识别从机";
    this.imageButton15.UseVisualStyleBackColor = false;
    this.imageButton15.Click += new EventHandler(this.imageButton15_Click);
    this.dS标签7.BackColor = Color.Transparent;
    this.dS标签7.Font = new Font("微软雅黑", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    this.dS标签7.Location = new System.Drawing.Point(27, 1);
    this.dS标签7.Margin = new System.Windows.Forms.Padding(0);
    this.dS标签7.Name = "dS标签7";
    this.dS标签7.Size = new System.Drawing.Size(128 /*0x80*/, 35);
    this.dS标签7.TabIndex = 0;
    this.dS标签7.Text = "通信参数区:";
    this.dS标签7.偏移 = new System.Drawing.Point(0, 5);
    this.tabPage8.BackColor = SystemColors.ActiveCaption;
    this.tabPage8.Controls.Add((Control) this.imageButton19);
    this.tabPage8.Controls.Add((Control) this.imageButton18);
    this.tabPage8.Controls.Add((Control) this.dS标签10);
    this.tabPage8.Controls.Add((Control) this.dS容器5);
    this.tabPage8.Location = new System.Drawing.Point(4, 22);
    this.tabPage8.Name = "tabPage8";
    this.tabPage8.Size = new System.Drawing.Size(892, 554);
    this.tabPage8.TabIndex = 5;
    this.tabPage8.Text = "关于";
    this.imageButton19.BackColor = Color.Transparent;
    this.imageButton19.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton19.DownImage = (Image) componentResourceManager.GetObject("imageButton19.DownImage");
    this.imageButton19.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton19.ForeColor = SystemColors.InfoText;
    this.imageButton19.Image = (Image) componentResourceManager.GetObject("imageButton19.Image");
    this.imageButton19.IsShowBorder = false;
    this.imageButton19.Location = new System.Drawing.Point(711, 493);
    this.imageButton19.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton19.MoveImage = (Image) componentResourceManager.GetObject("imageButton19.MoveImage");
    this.imageButton19.Name = "imageButton19";
    this.imageButton19.NormalImage = (Image) componentResourceManager.GetObject("imageButton19.NormalImage");
    this.imageButton19.Size = new System.Drawing.Size(102, 37);
    this.imageButton19.TabIndex = 53;
    this.imageButton19.Text = "安装驱动";
    this.imageButton19.UseVisualStyleBackColor = false;
    this.imageButton19.Visible = false;
    this.imageButton19.Click += new EventHandler(this.imageButton19_Click);
    this.imageButton18.BackColor = Color.Transparent;
    this.imageButton18.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton18.DownImage = (Image) componentResourceManager.GetObject("imageButton18.DownImage");
    this.imageButton18.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton18.ForeColor = SystemColors.InfoText;
    this.imageButton18.Image = (Image) componentResourceManager.GetObject("imageButton18.Image");
    this.imageButton18.IsShowBorder = false;
    this.imageButton18.Location = new System.Drawing.Point(711, 432);
    this.imageButton18.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton18.MoveImage = (Image) componentResourceManager.GetObject("imageButton18.MoveImage");
    this.imageButton18.Name = "imageButton18";
    this.imageButton18.NormalImage = (Image) componentResourceManager.GetObject("imageButton18.NormalImage");
    this.imageButton18.Size = new System.Drawing.Size(102, 37);
    this.imageButton18.TabIndex = 52;
    this.imageButton18.Text = "软件升级";
    this.imageButton18.UseVisualStyleBackColor = false;
    this.imageButton18.Visible = false;
    this.imageButton18.Click += new EventHandler(this.imageButton18_Click);
    this.dS标签10.BackColor = Color.Transparent;
    this.dS标签10.Font = new Font("微软雅黑", 14.25f, FontStyle.Bold);
    this.dS标签10.Location = new System.Drawing.Point(27, 413);
    this.dS标签10.Name = "dS标签10";
    this.dS标签10.Size = new System.Drawing.Size(519, 132);
    this.dS标签10.TabIndex = 1;
    this.dS标签10.Text = "LINTest-MI\r\n版本号 : 1.0.5\r\n微信号 :  15007692250         QQ:781764513\r\n欢迎返馈BUG，请帮助我们进步！";
    this.dS标签10.偏移 = new System.Drawing.Point(0, 5);
    this.dS容器5.BackColor = SystemColors.GradientInactiveCaption;
    this.dS容器5.Controls.Add((Control) this.label23);
    this.dS容器5.Controls.Add((Control) this.label22);
    this.dS容器5.Controls.Add((Control) this.dS容器6);
    this.dS容器5.Location = new System.Drawing.Point(0, 8);
    this.dS容器5.Margin = new System.Windows.Forms.Padding(0);
    this.dS容器5.Name = "dS容器5";
    this.dS容器5.Size = new System.Drawing.Size(892, 395);
    this.dS容器5.TabIndex = 0;
    this.dS容器5.标题文本偏移 = new System.Drawing.Point(0, 0);
    this.dS容器5.贴图 = (Bitmap) null;
    this.dS容器5.贴图切割边距.上 = 0;
    this.dS容器5.贴图切割边距.下 = 0;
    this.dS容器5.贴图切割边距.右 = 0;
    this.dS容器5.贴图切割边距.左 = 0;
    this.dS容器5.边栏颜色 = Color.Empty;
    this.dS容器5.边框颜色 = Color.Empty;
    this.dS容器5.透明度 = 1f;
    this.label23.AutoSize = true;
    this.label23.BackColor = Color.Transparent;
    this.label23.Font = new Font("微软雅黑", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    this.label23.ForeColor = SystemColors.ActiveCaption;
    this.label23.Location = new System.Drawing.Point(345, 359);
    this.label23.Name = "label23";
    this.label23.Size = new System.Drawing.Size(237, 21);
    this.label23.TabIndex = 11;
    this.label23.Text = "让   科   技   不   断   创   新";
    this.label22.AutoSize = true;
    this.label22.BackColor = Color.Transparent;
    this.label22.Font = new Font("微软雅黑", 21.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    this.label22.ForeColor = SystemColors.InactiveCaptionText;
    this.label22.Location = new System.Drawing.Point(356, 317);
    this.label22.Margin = new System.Windows.Forms.Padding(0);
    this.label22.Name = "label22";
    this.label22.Size = new System.Drawing.Size(182, 38);
    this.label22.TabIndex = 10;
    this.label22.Text = "LINTest-MI";
    this.dS容器6.BackColor = SystemColors.GradientInactiveCaption;
    this.dS容器6.BackgroundImage = (Image) componentResourceManager.GetObject("dS容器6.BackgroundImage");
    this.dS容器6.BackgroundImageLayout = ImageLayout.Stretch;
    this.dS容器6.Enabled = false;
    this.dS容器6.Location = new System.Drawing.Point(286, 18);
    this.dS容器6.Name = "dS容器6";
    this.dS容器6.Size = new System.Drawing.Size(328, 301);
    this.dS容器6.TabIndex = 0;
    this.dS容器6.标题文本偏移 = new System.Drawing.Point(0, 0);
    this.dS容器6.贴图 = (Bitmap) null;
    this.dS容器6.贴图切割边距.上 = 0;
    this.dS容器6.贴图切割边距.下 = 0;
    this.dS容器6.贴图切割边距.右 = 0;
    this.dS容器6.贴图切割边距.左 = 0;
    this.dS容器6.边栏颜色 = Color.Empty;
    this.dS容器6.边框颜色 = Color.Empty;
    this.dS容器6.透明度 = 1f;
    this.tabPage9.BackColor = SystemColors.InactiveCaption;
    this.tabPage9.Controls.Add((Control) this.dS按钮16);
    this.tabPage9.Controls.Add((Control) this.dS按钮17);
    this.tabPage9.Controls.Add((Control) this.myButton2);
    this.tabPage9.Controls.Add((Control) this.myButton3);
    this.tabPage9.Controls.Add((Control) this.bar6);
    this.tabPage9.Controls.Add((Control) this.listViewNF7);
    this.tabPage9.Controls.Add((Control) this.bar7);
    this.tabPage9.Controls.Add((Control) this.bar5);
    this.tabPage9.Controls.Add((Control) this.listViewNF6);
    this.tabPage9.Location = new System.Drawing.Point(4, 22);
    this.tabPage9.Name = "tabPage9";
    this.tabPage9.Size = new System.Drawing.Size(892, 554);
    this.tabPage9.TabIndex = 0;
    this.tabPage9.Text = "波特率识别";
    this.dS按钮16.BackColor = Color.Transparent;
    this.dS按钮16.BackgroundImage = (Image) componentResourceManager.GetObject("dS按钮16.BackgroundImage");
    this.dS按钮16.Cursor = Cursors.Default;
    this.dS按钮16.DialogResult = DialogResult.None;
    this.dS按钮16.ForeColor = Color.White;
    this.dS按钮16.Location = new System.Drawing.Point(748, 435);
    this.dS按钮16.Margin = new System.Windows.Forms.Padding(1);
    this.dS按钮16.Name = "dS按钮16";
    this.dS按钮16.Size = new System.Drawing.Size(75, 75);
    this.dS按钮16.TabIndex = 68;
    this.dS按钮16.图像 = (Bitmap) null;
    this.dS按钮16.异形透明度采样百分比 = 0.1f;
    进度条14.指示进度 = 0.0f;
    进度条14.进度条颜色 = Color.DodgerBlue;
    this.dS按钮16.指示进度条 = 进度条14;
    this.dS按钮16.文本 = "";
    this.dS按钮16.禁用时透明度 = 0.3f;
    this.dS按钮16.自动尺寸扩展 = new System.Drawing.Size(20, 20);
    this.dS按钮16.自定义图像.按下 = (Bitmap) null;
    this.dS按钮16.自定义图像.禁用 = (Bitmap) null;
    this.dS按钮16.自定义图像.高亮 = (Bitmap) null;
    this.dS按钮16.自定义图像.默认 = (Bitmap) null;
    this.dS按钮16.贴图 = (Bitmap) componentResourceManager.GetObject("dS按钮16.贴图");
    this.dS按钮16.贴图切割边距.上 = 0;
    this.dS按钮16.贴图切割边距.下 = 0;
    this.dS按钮16.贴图切割边距.右 = 0;
    this.dS按钮16.贴图切割边距.左 = 0;
    this.dS按钮16.贴图模式 = DS按钮._贴图模式.贴图;
    this.dS按钮16.透明度 = 1f;
    this.dS按钮16.附加内容字体 = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS按钮16.ButtonClick += new DS按钮.ButtonClickEventHandler(this.dS按钮16_ButtonClick);
    this.dS按钮17.BackColor = Color.Transparent;
    this.dS按钮17.BackgroundImage = (Image) componentResourceManager.GetObject("dS按钮17.BackgroundImage");
    this.dS按钮17.Cursor = Cursors.Default;
    this.dS按钮17.DialogResult = DialogResult.None;
    this.dS按钮17.ForeColor = Color.White;
    this.dS按钮17.Location = new System.Drawing.Point(572, 435);
    this.dS按钮17.Margin = new System.Windows.Forms.Padding(1);
    this.dS按钮17.Name = "dS按钮17";
    this.dS按钮17.Size = new System.Drawing.Size(75, 75);
    this.dS按钮17.TabIndex = 67;
    this.dS按钮17.TabStop = false;
    this.dS按钮17.图像 = (Bitmap) null;
    this.dS按钮17.异形透明度采样百分比 = 0.1f;
    进度条15.指示进度 = 0.0f;
    进度条15.进度条颜色 = Color.DodgerBlue;
    this.dS按钮17.指示进度条 = 进度条15;
    this.dS按钮17.文本 = "";
    this.dS按钮17.禁用时透明度 = 0.3f;
    this.dS按钮17.自动尺寸扩展 = new System.Drawing.Size(20, 20);
    this.dS按钮17.自定义图像.按下 = (Bitmap) null;
    this.dS按钮17.自定义图像.禁用 = (Bitmap) null;
    this.dS按钮17.自定义图像.高亮 = (Bitmap) null;
    this.dS按钮17.自定义图像.默认 = (Bitmap) null;
    this.dS按钮17.贴图 = (Bitmap) componentResourceManager.GetObject("dS按钮17.贴图");
    this.dS按钮17.贴图切割边距.上 = 0;
    this.dS按钮17.贴图切割边距.下 = 0;
    this.dS按钮17.贴图切割边距.右 = 0;
    this.dS按钮17.贴图切割边距.左 = 0;
    this.dS按钮17.贴图模式 = DS按钮._贴图模式.贴图;
    this.dS按钮17.透明度 = 1f;
    this.dS按钮17.附加内容字体 = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS按钮17.ButtonClick += new DS按钮.ButtonClickEventHandler(this.dS按钮17_ButtonClick);
    this.myButton2.BackColor = Color.Transparent;
    this.myButton2.BackgroundImageLayout = ImageLayout.Center;
    this.myButton2.DownImage = (Image) componentResourceManager.GetObject("myButton2.DownImage");
    this.myButton2.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.myButton2.ForeColor = SystemColors.InfoText;
    this.myButton2.Image = (Image) componentResourceManager.GetObject("myButton2.Image");
    this.myButton2.IsShowBorder = false;
    this.myButton2.Location = new System.Drawing.Point(737, 316);
    this.myButton2.Margin = new System.Windows.Forms.Padding(0);
    this.myButton2.MoveImage = (Image) componentResourceManager.GetObject("myButton2.MoveImage");
    this.myButton2.Name = "myButton2";
    this.myButton2.NormalImage = (Image) componentResourceManager.GetObject("myButton2.NormalImage");
    this.myButton2.Size = new System.Drawing.Size(92, 45);
    this.myButton2.TabIndex = 66;
    this.myButton2.Text = "保存数据";
    this.myButton2.UseVisualStyleBackColor = false;
    this.myButton2.Click += new EventHandler(this.myButton2_Click_1);
    this.myButton3.BackColor = Color.Transparent;
    this.myButton3.BackgroundImageLayout = ImageLayout.Center;
    this.myButton3.DownImage = (Image) componentResourceManager.GetObject("myButton3.DownImage");
    this.myButton3.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.myButton3.ForeColor = SystemColors.InfoText;
    this.myButton3.Image = (Image) componentResourceManager.GetObject("myButton3.Image");
    this.myButton3.IsShowBorder = false;
    this.myButton3.Location = new System.Drawing.Point(565, 316);
    this.myButton3.Margin = new System.Windows.Forms.Padding(0);
    this.myButton3.MoveImage = (Image) componentResourceManager.GetObject("myButton3.MoveImage");
    this.myButton3.Name = "myButton3";
    this.myButton3.NormalImage = (Image) componentResourceManager.GetObject("myButton3.NormalImage");
    this.myButton3.Size = new System.Drawing.Size(92, 45);
    this.myButton3.TabIndex = 65;
    this.myButton3.Text = "清除显示";
    this.myButton3.UseVisualStyleBackColor = false;
    this.myButton3.Click += new EventHandler(this.myButton3_Click);
    ((Control) this.bar6).AccessibleDescription = "bar5 (bar5)";
    ((Control) this.bar6).AccessibleName = "bar5";
    ((Control) this.bar6).AccessibleRole = AccessibleRole.ToolBar;
    ((Control) this.bar6).Font = new Font("微软雅黑", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.bar6.Location = new System.Drawing.Point(500, 248);
    ((Control) this.bar6).Margin = new System.Windows.Forms.Padding(0);
    this.bar6.Name = "bar6";
    this.bar6.Size = new System.Drawing.Size(392, 25);
    this.bar6.Stretch = true;
    this.bar6.Style = eDotNetBarStyle.Office2003;
    this.bar6.TabIndex = 64 /*0x40*/;
    this.bar6.TabStop = false;
    ((Control) this.bar6).Text = "bar6";
    this.listViewNF7.BackColor = Color.RoyalBlue;
    this.listViewNF7.BorderStyle = BorderStyle.None;
    this.listViewNF7.Columns.AddRange(new ColumnHeader[4]
    {
      this.columnHeader38,
      this.columnHeader39,
      this.columnHeader40,
      this.columnHeader41
    });
    this.listViewNF7.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.listViewNF7.ForeColor = Color.White;
    this.listViewNF7.FullRowSelect = true;
    this.listViewNF7.HideSelection = false;
    this.listViewNF7.Location = new System.Drawing.Point(500, 38);
    this.listViewNF7.Margin = new System.Windows.Forms.Padding(0);
    this.listViewNF7.MultiSelect = false;
    this.listViewNF7.Name = "listViewNF7";
    this.listViewNF7.Size = new System.Drawing.Size(392, 210);
    this.listViewNF7.TabIndex = 63 /*0x3F*/;
    this.listViewNF7.UseCompatibleStateImageBehavior = false;
    this.listViewNF7.View = View.Details;
    this.columnHeader38.Text = "序号";
    this.columnHeader38.Width = 50;
    this.columnHeader39.Text = "波特率(bps)";
    this.columnHeader39.Width = 100;
    this.columnHeader40.Text = "正脉冲宽度";
    this.columnHeader40.Width = 100;
    this.columnHeader41.Text = "负脉冲宽度";
    this.columnHeader41.Width = 100;
    ((Control) this.bar7).AccessibleDescription = "bar5 (bar5)";
    ((Control) this.bar7).AccessibleName = "bar5";
    ((Control) this.bar7).AccessibleRole = AccessibleRole.ToolBar;
    ((Control) this.bar7).Controls.Add((Control) this.dS标签17);
    this.bar7.Items.AddRange(new BaseItem[1]
    {
      (BaseItem) this.controlContainerItem1
    });
    this.bar7.Location = new System.Drawing.Point(500, 8);
    ((Control) this.bar7).Margin = new System.Windows.Forms.Padding(0);
    this.bar7.Name = "bar7";
    this.bar7.Size = new System.Drawing.Size(392, 30);
    this.bar7.Stretch = true;
    this.bar7.Style = eDotNetBarStyle.Office2003;
    this.bar7.TabIndex = 62;
    this.bar7.TabStop = false;
    ((Control) this.bar7).Text = "bar7";
    this.dS标签17.BackColor = Color.Transparent;
    this.dS标签17.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS标签17.Location = new System.Drawing.Point(3, 2);
    this.dS标签17.Name = "dS标签17";
    this.dS标签17.Size = new System.Drawing.Size(171, 25);
    this.dS标签17.TabIndex = 0;
    this.dS标签17.Text = "当前波特率值：";
    this.dS标签17.偏移 = new System.Drawing.Point(0, 5);
    this.controlContainerItem1.AllowItemResize = false;
    this.controlContainerItem1.Control = (Control) this.dS标签17;
    this.controlContainerItem1.MenuVisibility = eMenuVisibility.VisibleAlways;
    this.controlContainerItem1.Name = "controlContainerItem1";
    ((Control) this.bar5).AccessibleDescription = "bar5 (bar5)";
    ((Control) this.bar5).AccessibleName = "bar5";
    ((Control) this.bar5).AccessibleRole = AccessibleRole.ToolBar;
    this.bar5.DockOrientation = eOrientation.Vertical;
    ((Control) this.bar5).Font = new Font("微软雅黑", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.bar5.Location = new System.Drawing.Point(464, 8);
    ((Control) this.bar5).Margin = new System.Windows.Forms.Padding(0);
    this.bar5.Name = "bar5";
    this.bar5.Size = new System.Drawing.Size(36, 546);
    this.bar5.Stretch = true;
    this.bar5.Style = eDotNetBarStyle.Office2007;
    this.bar5.TabIndex = 61;
    this.bar5.TabStop = false;
    ((Control) this.bar5).Text = "bar5";
    this.listViewNF6.BackColor = Color.RoyalBlue;
    this.listViewNF6.BorderStyle = BorderStyle.None;
    this.listViewNF6.Columns.AddRange(new ColumnHeader[4]
    {
      this.columnHeader47,
      this.columnHeader48,
      this.columnHeader49,
      this.columnHeader50
    });
    this.listViewNF6.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.listViewNF6.ForeColor = Color.White;
    this.listViewNF6.FullRowSelect = true;
    this.listViewNF6.HideSelection = false;
    this.listViewNF6.Location = new System.Drawing.Point(0, 8);
    this.listViewNF6.Margin = new System.Windows.Forms.Padding(0);
    this.listViewNF6.MultiSelect = false;
    this.listViewNF6.Name = "listViewNF6";
    this.listViewNF6.Size = new System.Drawing.Size(464, 546);
    this.listViewNF6.TabIndex = 14;
    this.listViewNF6.UseCompatibleStateImageBehavior = false;
    this.listViewNF6.View = View.Details;
    this.columnHeader47.Text = "序号";
    this.columnHeader47.Width = 70;
    this.columnHeader48.Text = "波特率(bps)";
    this.columnHeader48.Width = 120;
    this.columnHeader49.Text = "正脉冲宽度";
    this.columnHeader49.Width = 110;
    this.columnHeader50.Text = "负脉冲宽度";
    this.columnHeader50.Width = 110;
    this.tabPage10.BackColor = SystemColors.ActiveCaption;
    this.tabPage10.Controls.Add((Control) this.uiTitlePanel3);
    this.tabPage10.Controls.Add((Control) this.uiTitlePanel2);
    this.tabPage10.Controls.Add((Control) this.uiTitlePanel1);
    this.tabPage10.Location = new System.Drawing.Point(4, 22);
    this.tabPage10.Name = "tabPage10";
    this.tabPage10.Size = new System.Drawing.Size(892, 554);
    this.tabPage10.TabIndex = 8;
    this.tabPage10.Text = "LDF解析";
    this.uiTitlePanel3.Controls.Add((Control) this.uiTreeView1);
    this.uiTitlePanel3.Font = new Font("微软雅黑", 12f);
    this.uiTitlePanel3.ForeColor = Color.White;
    this.uiTitlePanel3.Location = new System.Drawing.Point(0, 8);
    this.uiTitlePanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
    this.uiTitlePanel3.Name = "uiTitlePanel3";
    this.uiTitlePanel3.Padding = new System.Windows.Forms.Padding(0, 23, 0, 0);
    this.uiTitlePanel3.Size = new System.Drawing.Size(269, 252);
    this.uiTitlePanel3.Style = UIStyle.Custom;
    this.uiTitlePanel3.TabIndex = 58;
    this.uiTitlePanel3.Text = "LDF基本参数";
    this.uiTitlePanel3.TitleHeight = 23;
    this.uiTreeView1.BackColor = Color.White;
    this.uiTreeView1.CheckBoxes = true;
    this.uiTreeView1.FillColor = Color.White;
    this.uiTreeView1.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiTreeView1.Location = new System.Drawing.Point(0, 23);
    this.uiTreeView1.Margin = new System.Windows.Forms.Padding(0);
    this.uiTreeView1.Name = "uiTreeView1";
    this.uiTreeView1.SelectedNode = (TreeNode) null;
    this.uiTreeView1.ShowLines = true;
    this.uiTreeView1.Size = new System.Drawing.Size(269, 229);
    this.uiTreeView1.Style = UIStyle.Custom;
    this.uiTreeView1.TabIndex = 18;
    this.uiTreeView1.Text = (string) null;
    this.uiTreeView1.AfterSelect += new TreeViewEventHandler(this.uiTreeView1_AfterSelect);
    this.uiTitlePanel2.Controls.Add((Control) this.listView1);
    this.uiTitlePanel2.Font = new Font("微软雅黑", 12f);
    this.uiTitlePanel2.ForeColor = Color.White;
    this.uiTitlePanel2.Location = new System.Drawing.Point(0, 265);
    this.uiTitlePanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
    this.uiTitlePanel2.Name = "uiTitlePanel2";
    this.uiTitlePanel2.Padding = new System.Windows.Forms.Padding(0, 23, 0, 0);
    this.uiTitlePanel2.Size = new System.Drawing.Size(269, 289);
    this.uiTitlePanel2.Style = UIStyle.Custom;
    this.uiTitlePanel2.TabIndex = 57;
    this.uiTitlePanel2.Text = "信号列表";
    this.uiTitlePanel2.TitleHeight = 23;
    this.listView1.BackColor = SystemColors.ActiveCaption;
    this.listView1.Columns.AddRange(new ColumnHeader[2]
    {
      this.columnHeader42,
      this.columnHeader43
    });
    this.listView1.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.listView1.FullRowSelect = true;
    this.listView1.HideSelection = false;
    this.listView1.Location = new System.Drawing.Point(0, 26);
    this.listView1.MultiSelect = false;
    this.listView1.Name = "listView1";
    this.listView1.Size = new System.Drawing.Size(269, 263);
    this.listView1.TabIndex = 0;
    this.listView1.UseCompatibleStateImageBehavior = false;
    this.listView1.View = View.Details;
    this.listView1.MouseClick += new MouseEventHandler(this.listView1_MouseClick);
    this.columnHeader42.Text = "序号";
    this.columnHeader42.Width = 50;
    this.columnHeader43.Text = "信号描述";
    this.columnHeader43.Width = 200;
    this.uiTitlePanel1.Controls.Add((Control) this.uiRichTextBox1);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLabel8);
    this.uiTitlePanel1.Controls.Add((Control) this.myButton4);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLabel7);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLabel6);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLabel5);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLabel4);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLabel3);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLabel2);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLabel1);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLine9);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton63);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton62);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton61);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton60);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton59);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton58);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton57);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton56);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLine16);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton55);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton54);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton53);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton52);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton51);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton50);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton49);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton48);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLine15);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton47);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton46);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton45);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton44);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton43);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton42);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton41);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton40);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLine14);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton39);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton38);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton37);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton36);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton35);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton34);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton33);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton32);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLine13);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton31);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton30);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton29);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton28);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton27);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton26);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton25);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton24);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLine12);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton23);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton22);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton21);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton20);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton19);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton18);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton17);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLine11);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton16);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton15);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton14);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton13);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton12);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton11);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton10);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton9);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton8);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLine8);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLine7);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLine6);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLine5);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLine4);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLine3);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLine1);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLine10);
    this.uiTitlePanel1.Controls.Add((Control) this.uiLine2);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton7);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton6);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton5);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton4);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton3);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton2);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton1);
    this.uiTitlePanel1.Controls.Add((Control) this.uiButton0);
    this.uiTitlePanel1.Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiTitlePanel1.ForeColor = Color.White;
    this.uiTitlePanel1.Location = new System.Drawing.Point(273, 8);
    this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(0);
    this.uiTitlePanel1.Name = "uiTitlePanel1";
    this.uiTitlePanel1.Padding = new System.Windows.Forms.Padding(0, 23, 0, 0);
    this.uiTitlePanel1.Size = new System.Drawing.Size(619, 546);
    this.uiTitlePanel1.Style = UIStyle.Custom;
    this.uiTitlePanel1.TabIndex = 17;
    this.uiTitlePanel1.Text = "距阵图";
    this.uiTitlePanel1.TitleHeight = 23;
    this.uiRichTextBox1.AutoWordSelection = true;
    this.uiRichTextBox1.FillColor = Color.White;
    this.uiRichTextBox1.Font = new Font("微软雅黑", 12f);
    this.uiRichTextBox1.Location = new System.Drawing.Point(12, 439);
    this.uiRichTextBox1.Margin = new System.Windows.Forms.Padding(0);
    this.uiRichTextBox1.Name = "uiRichTextBox1";
    this.uiRichTextBox1.Padding = new System.Windows.Forms.Padding(2);
    this.uiRichTextBox1.Size = new System.Drawing.Size(483, 104);
    this.uiRichTextBox1.Style = UIStyle.Custom;
    this.uiRichTextBox1.TabIndex = 58;
    this.uiLabel8.AutoSize = true;
    this.uiLabel8.BackColor = Color.Transparent;
    this.uiLabel8.Font = new Font("微软雅黑", 12f);
    this.uiLabel8.Location = new System.Drawing.Point(8, 397);
    this.uiLabel8.Name = "uiLabel8";
    this.uiLabel8.Size = new System.Drawing.Size(57, 21);
    this.uiLabel8.Style = UIStyle.Custom;
    this.uiLabel8.TabIndex = 100;
    this.uiLabel8.Text = "7 Byte";
    this.uiLabel8.TextAlign = ContentAlignment.MiddleLeft;
    this.myButton4.BackColor = Color.Transparent;
    this.myButton4.BackgroundImageLayout = ImageLayout.Center;
    this.myButton4.DownImage = (Image) componentResourceManager.GetObject("myButton4.DownImage");
    this.myButton4.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.myButton4.ForeColor = SystemColors.InfoText;
    this.myButton4.Image = (Image) componentResourceManager.GetObject("myButton4.Image");
    this.myButton4.IsShowBorder = false;
    this.myButton4.Location = new System.Drawing.Point(505, 439);
    this.myButton4.Margin = new System.Windows.Forms.Padding(0);
    this.myButton4.MoveImage = (Image) componentResourceManager.GetObject("myButton4.MoveImage");
    this.myButton4.Name = "myButton4";
    this.myButton4.NormalImage = (Image) componentResourceManager.GetObject("myButton4.NormalImage");
    this.myButton4.Size = new System.Drawing.Size(95, 104);
    this.myButton4.TabIndex = 56;
    this.myButton4.Text = "导入LDF";
    this.myButton4.UseVisualStyleBackColor = false;
    this.myButton4.Click += new EventHandler(this.myButton4_Click);
    this.uiLabel7.AutoSize = true;
    this.uiLabel7.BackColor = Color.Transparent;
    this.uiLabel7.Font = new Font("微软雅黑", 12f);
    this.uiLabel7.Location = new System.Drawing.Point(8, 351);
    this.uiLabel7.Name = "uiLabel7";
    this.uiLabel7.Size = new System.Drawing.Size(57, 21);
    this.uiLabel7.Style = UIStyle.Custom;
    this.uiLabel7.TabIndex = 99;
    this.uiLabel7.Text = "6 Byte";
    this.uiLabel7.TextAlign = ContentAlignment.MiddleLeft;
    this.uiLabel6.AutoSize = true;
    this.uiLabel6.BackColor = Color.Transparent;
    this.uiLabel6.Font = new Font("微软雅黑", 12f);
    this.uiLabel6.Location = new System.Drawing.Point(8, 303);
    this.uiLabel6.Name = "uiLabel6";
    this.uiLabel6.Size = new System.Drawing.Size(57, 21);
    this.uiLabel6.Style = UIStyle.Custom;
    this.uiLabel6.TabIndex = 98;
    this.uiLabel6.Text = "5 Byte";
    this.uiLabel6.TextAlign = ContentAlignment.MiddleLeft;
    this.uiLabel5.AutoSize = true;
    this.uiLabel5.BackColor = Color.Transparent;
    this.uiLabel5.Font = new Font("微软雅黑", 12f);
    this.uiLabel5.Location = new System.Drawing.Point(8, (int) byte.MaxValue);
    this.uiLabel5.Name = "uiLabel5";
    this.uiLabel5.Size = new System.Drawing.Size(57, 21);
    this.uiLabel5.Style = UIStyle.Custom;
    this.uiLabel5.TabIndex = 97;
    this.uiLabel5.Text = "4 Byte";
    this.uiLabel5.TextAlign = ContentAlignment.MiddleLeft;
    this.uiLabel4.AutoSize = true;
    this.uiLabel4.BackColor = Color.Transparent;
    this.uiLabel4.Font = new Font("微软雅黑", 12f);
    this.uiLabel4.Location = new System.Drawing.Point(8, 207);
    this.uiLabel4.Name = "uiLabel4";
    this.uiLabel4.Size = new System.Drawing.Size(57, 21);
    this.uiLabel4.Style = UIStyle.Custom;
    this.uiLabel4.TabIndex = 96 /*0x60*/;
    this.uiLabel4.Text = "3 Byte";
    this.uiLabel4.TextAlign = ContentAlignment.MiddleLeft;
    this.uiLabel3.AutoSize = true;
    this.uiLabel3.BackColor = Color.Transparent;
    this.uiLabel3.Font = new Font("微软雅黑", 12f);
    this.uiLabel3.Location = new System.Drawing.Point(8, 160 /*0xA0*/);
    this.uiLabel3.Name = "uiLabel3";
    this.uiLabel3.Size = new System.Drawing.Size(57, 21);
    this.uiLabel3.Style = UIStyle.Custom;
    this.uiLabel3.TabIndex = 95;
    this.uiLabel3.Text = "2 Byte";
    this.uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
    this.uiLabel2.AutoSize = true;
    this.uiLabel2.BackColor = Color.Transparent;
    this.uiLabel2.Font = new Font("微软雅黑", 12f);
    this.uiLabel2.Location = new System.Drawing.Point(8, 112 /*0x70*/);
    this.uiLabel2.Name = "uiLabel2";
    this.uiLabel2.Size = new System.Drawing.Size(57, 21);
    this.uiLabel2.Style = UIStyle.Custom;
    this.uiLabel2.TabIndex = 94;
    this.uiLabel2.Text = "1 Byte";
    this.uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
    this.uiLabel1.AutoSize = true;
    this.uiLabel1.BackColor = Color.Transparent;
    this.uiLabel1.Font = new Font("微软雅黑", 12f);
    this.uiLabel1.Location = new System.Drawing.Point(8, 66);
    this.uiLabel1.Name = "uiLabel1";
    this.uiLabel1.Size = new System.Drawing.Size(57, 21);
    this.uiLabel1.Style = UIStyle.Custom;
    this.uiLabel1.TabIndex = 93;
    this.uiLabel1.Text = "0 Byte";
    this.uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
    this.uiLine9.Direction = UILine.LineDirection.Vertical;
    this.uiLine9.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiLine9.Location = new System.Drawing.Point(63 /*0x3F*/, 66);
    this.uiLine9.Margin = new System.Windows.Forms.Padding(0);
    this.uiLine9.MinimumSize = new System.Drawing.Size(16 /*0x10*/, 16 /*0x10*/);
    this.uiLine9.Name = "uiLine9";
    this.uiLine9.RightToLeft = RightToLeft.No;
    this.uiLine9.Size = new System.Drawing.Size(16 /*0x10*/, 356);
    this.uiLine9.Style = UIStyle.Custom;
    this.uiLine9.TabIndex = 92;
    this.uiLine9.TextAlign = ContentAlignment.MiddleLeft;
    this.uiButton63.Cursor = Cursors.Hand;
    this.uiButton63.Font = new Font("微软雅黑", 12f);
    this.uiButton63.ForeColor = Color.Black;
    this.uiButton63.Location = new System.Drawing.Point(82, 397);
    this.uiButton63.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton63.Name = "uiButton63";
    this.uiButton63.ShowFocusLine = true;
    this.uiButton63.Size = new System.Drawing.Size(50, 25);
    this.uiButton63.Style = UIStyle.Custom;
    this.uiButton63.StyleCustomMode = true;
    this.uiButton63.TabIndex = 91;
    this.uiButton63.Text = "63";
    this.uiButton62.Cursor = Cursors.Hand;
    this.uiButton62.Font = new Font("微软雅黑", 12f);
    this.uiButton62.ForeColor = Color.Black;
    this.uiButton62.Location = new System.Drawing.Point(148, 397);
    this.uiButton62.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton62.Name = "uiButton62";
    this.uiButton62.ShowFocusLine = true;
    this.uiButton62.Size = new System.Drawing.Size(50, 25);
    this.uiButton62.Style = UIStyle.Custom;
    this.uiButton62.StyleCustomMode = true;
    this.uiButton62.TabIndex = 90;
    this.uiButton62.Text = "62";
    this.uiButton61.Cursor = Cursors.Hand;
    this.uiButton61.Font = new Font("微软雅黑", 12f);
    this.uiButton61.ForeColor = Color.Black;
    this.uiButton61.Location = new System.Drawing.Point(214, 397);
    this.uiButton61.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton61.Name = "uiButton61";
    this.uiButton61.ShowFocusLine = true;
    this.uiButton61.Size = new System.Drawing.Size(50, 25);
    this.uiButton61.Style = UIStyle.Custom;
    this.uiButton61.StyleCustomMode = true;
    this.uiButton61.TabIndex = 89;
    this.uiButton61.Text = "61";
    this.uiButton60.Cursor = Cursors.Hand;
    this.uiButton60.Font = new Font("微软雅黑", 12f);
    this.uiButton60.ForeColor = Color.Black;
    this.uiButton60.Location = new System.Drawing.Point(280, 397);
    this.uiButton60.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton60.Name = "uiButton60";
    this.uiButton60.ShowFocusLine = true;
    this.uiButton60.Size = new System.Drawing.Size(50, 25);
    this.uiButton60.Style = UIStyle.Custom;
    this.uiButton60.StyleCustomMode = true;
    this.uiButton60.TabIndex = 88;
    this.uiButton60.Text = "60";
    this.uiButton59.Cursor = Cursors.Hand;
    this.uiButton59.Font = new Font("微软雅黑", 12f);
    this.uiButton59.ForeColor = Color.Black;
    this.uiButton59.Location = new System.Drawing.Point(349, 397);
    this.uiButton59.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton59.Name = "uiButton59";
    this.uiButton59.ShowFocusLine = true;
    this.uiButton59.Size = new System.Drawing.Size(50, 25);
    this.uiButton59.Style = UIStyle.Custom;
    this.uiButton59.StyleCustomMode = true;
    this.uiButton59.TabIndex = 87;
    this.uiButton59.Text = "59";
    this.uiButton58.Cursor = Cursors.Hand;
    this.uiButton58.Font = new Font("微软雅黑", 12f);
    this.uiButton58.ForeColor = Color.Black;
    this.uiButton58.Location = new System.Drawing.Point(415, 397);
    this.uiButton58.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton58.Name = "uiButton58";
    this.uiButton58.ShowFocusLine = true;
    this.uiButton58.Size = new System.Drawing.Size(50, 25);
    this.uiButton58.Style = UIStyle.Custom;
    this.uiButton58.StyleCustomMode = true;
    this.uiButton58.TabIndex = 86;
    this.uiButton58.Text = "58";
    this.uiButton57.Cursor = Cursors.Hand;
    this.uiButton57.Font = new Font("微软雅黑", 12f);
    this.uiButton57.ForeColor = Color.Black;
    this.uiButton57.Location = new System.Drawing.Point(484, 397);
    this.uiButton57.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton57.Name = "uiButton57";
    this.uiButton57.ShowFocusLine = true;
    this.uiButton57.Size = new System.Drawing.Size(50, 25);
    this.uiButton57.Style = UIStyle.Custom;
    this.uiButton57.StyleCustomMode = true;
    this.uiButton57.TabIndex = 85;
    this.uiButton57.Text = "57";
    this.uiButton56.Cursor = Cursors.Hand;
    this.uiButton56.Font = new Font("微软雅黑", 12f);
    this.uiButton56.ForeColor = Color.Black;
    this.uiButton56.Location = new System.Drawing.Point(550, 397);
    this.uiButton56.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton56.Name = "uiButton56";
    this.uiButton56.ShowFocusLine = true;
    this.uiButton56.Size = new System.Drawing.Size(50, 25);
    this.uiButton56.Style = UIStyle.Custom;
    this.uiButton56.StyleCustomMode = true;
    this.uiButton56.TabIndex = 84;
    this.uiButton56.Text = "56";
    this.uiLine16.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiLine16.Location = new System.Drawing.Point(82, 378);
    this.uiLine16.MinimumSize = new System.Drawing.Size(16 /*0x10*/, 16 /*0x10*/);
    this.uiLine16.Name = "uiLine16";
    this.uiLine16.Size = new System.Drawing.Size(518, 16 /*0x10*/);
    this.uiLine16.Style = UIStyle.Custom;
    this.uiLine16.TabIndex = 83;
    this.uiLine16.TextAlign = ContentAlignment.MiddleLeft;
    this.uiButton55.Cursor = Cursors.Hand;
    this.uiButton55.Font = new Font("微软雅黑", 12f);
    this.uiButton55.ForeColor = Color.Black;
    this.uiButton55.Location = new System.Drawing.Point(82, 350);
    this.uiButton55.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton55.Name = "uiButton55";
    this.uiButton55.ShowFocusLine = true;
    this.uiButton55.Size = new System.Drawing.Size(50, 25);
    this.uiButton55.Style = UIStyle.Custom;
    this.uiButton55.StyleCustomMode = true;
    this.uiButton55.TabIndex = 82;
    this.uiButton55.Text = "55";
    this.uiButton54.Cursor = Cursors.Hand;
    this.uiButton54.Font = new Font("微软雅黑", 12f);
    this.uiButton54.ForeColor = Color.Black;
    this.uiButton54.Location = new System.Drawing.Point(148, 350);
    this.uiButton54.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton54.Name = "uiButton54";
    this.uiButton54.ShowFocusLine = true;
    this.uiButton54.Size = new System.Drawing.Size(50, 25);
    this.uiButton54.Style = UIStyle.Custom;
    this.uiButton54.StyleCustomMode = true;
    this.uiButton54.TabIndex = 81;
    this.uiButton54.Text = "54";
    this.uiButton53.Cursor = Cursors.Hand;
    this.uiButton53.Font = new Font("微软雅黑", 12f);
    this.uiButton53.ForeColor = Color.Black;
    this.uiButton53.Location = new System.Drawing.Point(214, 350);
    this.uiButton53.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton53.Name = "uiButton53";
    this.uiButton53.ShowFocusLine = true;
    this.uiButton53.Size = new System.Drawing.Size(50, 25);
    this.uiButton53.Style = UIStyle.Custom;
    this.uiButton53.StyleCustomMode = true;
    this.uiButton53.TabIndex = 80 /*0x50*/;
    this.uiButton53.Text = "53";
    this.uiButton52.Cursor = Cursors.Hand;
    this.uiButton52.Font = new Font("微软雅黑", 12f);
    this.uiButton52.ForeColor = Color.Black;
    this.uiButton52.Location = new System.Drawing.Point(280, 350);
    this.uiButton52.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton52.Name = "uiButton52";
    this.uiButton52.ShowFocusLine = true;
    this.uiButton52.Size = new System.Drawing.Size(50, 25);
    this.uiButton52.Style = UIStyle.Custom;
    this.uiButton52.StyleCustomMode = true;
    this.uiButton52.TabIndex = 79;
    this.uiButton52.Text = "52";
    this.uiButton51.Cursor = Cursors.Hand;
    this.uiButton51.Font = new Font("微软雅黑", 12f);
    this.uiButton51.ForeColor = Color.Black;
    this.uiButton51.Location = new System.Drawing.Point(349, 350);
    this.uiButton51.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton51.Name = "uiButton51";
    this.uiButton51.ShowFocusLine = true;
    this.uiButton51.Size = new System.Drawing.Size(50, 25);
    this.uiButton51.Style = UIStyle.Custom;
    this.uiButton51.StyleCustomMode = true;
    this.uiButton51.TabIndex = 78;
    this.uiButton51.Text = "51";
    this.uiButton50.Cursor = Cursors.Hand;
    this.uiButton50.Font = new Font("微软雅黑", 12f);
    this.uiButton50.ForeColor = Color.Black;
    this.uiButton50.Location = new System.Drawing.Point(415, 350);
    this.uiButton50.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton50.Name = "uiButton50";
    this.uiButton50.ShowFocusLine = true;
    this.uiButton50.Size = new System.Drawing.Size(50, 25);
    this.uiButton50.Style = UIStyle.Custom;
    this.uiButton50.StyleCustomMode = true;
    this.uiButton50.TabIndex = 77;
    this.uiButton50.Text = "50";
    this.uiButton49.Cursor = Cursors.Hand;
    this.uiButton49.Font = new Font("微软雅黑", 12f);
    this.uiButton49.ForeColor = Color.Black;
    this.uiButton49.Location = new System.Drawing.Point(484, 350);
    this.uiButton49.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton49.Name = "uiButton49";
    this.uiButton49.ShowFocusLine = true;
    this.uiButton49.Size = new System.Drawing.Size(50, 25);
    this.uiButton49.Style = UIStyle.Custom;
    this.uiButton49.StyleCustomMode = true;
    this.uiButton49.TabIndex = 76;
    this.uiButton49.Text = "49";
    this.uiButton48.Cursor = Cursors.Hand;
    this.uiButton48.Font = new Font("微软雅黑", 12f);
    this.uiButton48.ForeColor = Color.Black;
    this.uiButton48.Location = new System.Drawing.Point(550, 350);
    this.uiButton48.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton48.Name = "uiButton48";
    this.uiButton48.ShowFocusLine = true;
    this.uiButton48.Size = new System.Drawing.Size(50, 25);
    this.uiButton48.Style = UIStyle.Custom;
    this.uiButton48.StyleCustomMode = true;
    this.uiButton48.TabIndex = 75;
    this.uiButton48.Text = "48";
    this.uiLine15.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiLine15.Location = new System.Drawing.Point(82, 331);
    this.uiLine15.MinimumSize = new System.Drawing.Size(16 /*0x10*/, 16 /*0x10*/);
    this.uiLine15.Name = "uiLine15";
    this.uiLine15.Size = new System.Drawing.Size(518, 16 /*0x10*/);
    this.uiLine15.Style = UIStyle.Custom;
    this.uiLine15.TabIndex = 74;
    this.uiLine15.TextAlign = ContentAlignment.MiddleLeft;
    this.uiButton47.Cursor = Cursors.Hand;
    this.uiButton47.Font = new Font("微软雅黑", 12f);
    this.uiButton47.ForeColor = Color.Black;
    this.uiButton47.Location = new System.Drawing.Point(82, 303);
    this.uiButton47.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton47.Name = "uiButton47";
    this.uiButton47.ShowFocusLine = true;
    this.uiButton47.Size = new System.Drawing.Size(50, 25);
    this.uiButton47.Style = UIStyle.Custom;
    this.uiButton47.StyleCustomMode = true;
    this.uiButton47.TabIndex = 73;
    this.uiButton47.Text = "47";
    this.uiButton46.Cursor = Cursors.Hand;
    this.uiButton46.Font = new Font("微软雅黑", 12f);
    this.uiButton46.ForeColor = Color.Black;
    this.uiButton46.Location = new System.Drawing.Point(148, 303);
    this.uiButton46.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton46.Name = "uiButton46";
    this.uiButton46.ShowFocusLine = true;
    this.uiButton46.Size = new System.Drawing.Size(50, 25);
    this.uiButton46.Style = UIStyle.Custom;
    this.uiButton46.StyleCustomMode = true;
    this.uiButton46.TabIndex = 72;
    this.uiButton46.Text = "46";
    this.uiButton45.Cursor = Cursors.Hand;
    this.uiButton45.Font = new Font("微软雅黑", 12f);
    this.uiButton45.ForeColor = Color.Black;
    this.uiButton45.Location = new System.Drawing.Point(214, 303);
    this.uiButton45.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton45.Name = "uiButton45";
    this.uiButton45.ShowFocusLine = true;
    this.uiButton45.Size = new System.Drawing.Size(50, 25);
    this.uiButton45.Style = UIStyle.Custom;
    this.uiButton45.StyleCustomMode = true;
    this.uiButton45.TabIndex = 71;
    this.uiButton45.Text = "45";
    this.uiButton44.Cursor = Cursors.Hand;
    this.uiButton44.Font = new Font("微软雅黑", 12f);
    this.uiButton44.ForeColor = Color.Black;
    this.uiButton44.Location = new System.Drawing.Point(280, 303);
    this.uiButton44.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton44.Name = "uiButton44";
    this.uiButton44.ShowFocusLine = true;
    this.uiButton44.Size = new System.Drawing.Size(50, 25);
    this.uiButton44.Style = UIStyle.Custom;
    this.uiButton44.StyleCustomMode = true;
    this.uiButton44.TabIndex = 70;
    this.uiButton44.Text = "44";
    this.uiButton43.Cursor = Cursors.Hand;
    this.uiButton43.Font = new Font("微软雅黑", 12f);
    this.uiButton43.ForeColor = Color.Black;
    this.uiButton43.Location = new System.Drawing.Point(349, 303);
    this.uiButton43.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton43.Name = "uiButton43";
    this.uiButton43.ShowFocusLine = true;
    this.uiButton43.Size = new System.Drawing.Size(50, 25);
    this.uiButton43.Style = UIStyle.Custom;
    this.uiButton43.StyleCustomMode = true;
    this.uiButton43.TabIndex = 69;
    this.uiButton43.Text = "43";
    this.uiButton42.Cursor = Cursors.Hand;
    this.uiButton42.Font = new Font("微软雅黑", 12f);
    this.uiButton42.ForeColor = Color.Black;
    this.uiButton42.Location = new System.Drawing.Point(415, 303);
    this.uiButton42.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton42.Name = "uiButton42";
    this.uiButton42.ShowFocusLine = true;
    this.uiButton42.Size = new System.Drawing.Size(50, 25);
    this.uiButton42.Style = UIStyle.Custom;
    this.uiButton42.StyleCustomMode = true;
    this.uiButton42.TabIndex = 68;
    this.uiButton42.Text = "42";
    this.uiButton41.Cursor = Cursors.Hand;
    this.uiButton41.Font = new Font("微软雅黑", 12f);
    this.uiButton41.ForeColor = Color.Black;
    this.uiButton41.Location = new System.Drawing.Point(484, 303);
    this.uiButton41.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton41.Name = "uiButton41";
    this.uiButton41.ShowFocusLine = true;
    this.uiButton41.Size = new System.Drawing.Size(50, 25);
    this.uiButton41.Style = UIStyle.Custom;
    this.uiButton41.StyleCustomMode = true;
    this.uiButton41.TabIndex = 67;
    this.uiButton41.Text = "41";
    this.uiButton40.Cursor = Cursors.Hand;
    this.uiButton40.Font = new Font("微软雅黑", 12f);
    this.uiButton40.ForeColor = Color.Black;
    this.uiButton40.Location = new System.Drawing.Point(550, 303);
    this.uiButton40.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton40.Name = "uiButton40";
    this.uiButton40.ShowFocusLine = true;
    this.uiButton40.Size = new System.Drawing.Size(50, 25);
    this.uiButton40.Style = UIStyle.Custom;
    this.uiButton40.StyleCustomMode = true;
    this.uiButton40.TabIndex = 66;
    this.uiButton40.Text = "40";
    this.uiLine14.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiLine14.Location = new System.Drawing.Point(82, 284);
    this.uiLine14.MinimumSize = new System.Drawing.Size(16 /*0x10*/, 16 /*0x10*/);
    this.uiLine14.Name = "uiLine14";
    this.uiLine14.Size = new System.Drawing.Size(518, 16 /*0x10*/);
    this.uiLine14.Style = UIStyle.Custom;
    this.uiLine14.TabIndex = 65;
    this.uiLine14.TextAlign = ContentAlignment.MiddleLeft;
    this.uiButton39.Cursor = Cursors.Hand;
    this.uiButton39.Font = new Font("微软雅黑", 12f);
    this.uiButton39.ForeColor = Color.Black;
    this.uiButton39.Location = new System.Drawing.Point(82, 256 /*0x0100*/);
    this.uiButton39.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton39.Name = "uiButton39";
    this.uiButton39.ShowFocusLine = true;
    this.uiButton39.Size = new System.Drawing.Size(50, 25);
    this.uiButton39.Style = UIStyle.Custom;
    this.uiButton39.StyleCustomMode = true;
    this.uiButton39.TabIndex = 64 /*0x40*/;
    this.uiButton39.Text = "39";
    this.uiButton38.Cursor = Cursors.Hand;
    this.uiButton38.Font = new Font("微软雅黑", 12f);
    this.uiButton38.ForeColor = Color.Black;
    this.uiButton38.Location = new System.Drawing.Point(148, 254);
    this.uiButton38.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton38.Name = "uiButton38";
    this.uiButton38.ShowFocusLine = true;
    this.uiButton38.Size = new System.Drawing.Size(50, 25);
    this.uiButton38.Style = UIStyle.Custom;
    this.uiButton38.StyleCustomMode = true;
    this.uiButton38.TabIndex = 63 /*0x3F*/;
    this.uiButton38.Text = "38";
    this.uiButton37.Cursor = Cursors.Hand;
    this.uiButton37.Font = new Font("微软雅黑", 12f);
    this.uiButton37.ForeColor = Color.Black;
    this.uiButton37.Location = new System.Drawing.Point(214, 256 /*0x0100*/);
    this.uiButton37.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton37.Name = "uiButton37";
    this.uiButton37.ShowFocusLine = true;
    this.uiButton37.Size = new System.Drawing.Size(50, 25);
    this.uiButton37.Style = UIStyle.Custom;
    this.uiButton37.StyleCustomMode = true;
    this.uiButton37.TabIndex = 62;
    this.uiButton37.Text = "37";
    this.uiButton36.Cursor = Cursors.Hand;
    this.uiButton36.Font = new Font("微软雅黑", 12f);
    this.uiButton36.ForeColor = Color.Black;
    this.uiButton36.Location = new System.Drawing.Point(280, 254);
    this.uiButton36.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton36.Name = "uiButton36";
    this.uiButton36.ShowFocusLine = true;
    this.uiButton36.Size = new System.Drawing.Size(50, 25);
    this.uiButton36.Style = UIStyle.Custom;
    this.uiButton36.StyleCustomMode = true;
    this.uiButton36.TabIndex = 61;
    this.uiButton36.Text = "36";
    this.uiButton35.Cursor = Cursors.Hand;
    this.uiButton35.Font = new Font("微软雅黑", 12f);
    this.uiButton35.ForeColor = Color.Black;
    this.uiButton35.Location = new System.Drawing.Point(349, 254);
    this.uiButton35.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton35.Name = "uiButton35";
    this.uiButton35.ShowFocusLine = true;
    this.uiButton35.Size = new System.Drawing.Size(50, 25);
    this.uiButton35.Style = UIStyle.Custom;
    this.uiButton35.StyleCustomMode = true;
    this.uiButton35.TabIndex = 60;
    this.uiButton35.Text = "35";
    this.uiButton34.Cursor = Cursors.Hand;
    this.uiButton34.Font = new Font("微软雅黑", 12f);
    this.uiButton34.ForeColor = Color.Black;
    this.uiButton34.Location = new System.Drawing.Point(415, 254);
    this.uiButton34.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton34.Name = "uiButton34";
    this.uiButton34.ShowFocusLine = true;
    this.uiButton34.Size = new System.Drawing.Size(50, 25);
    this.uiButton34.Style = UIStyle.Custom;
    this.uiButton34.StyleCustomMode = true;
    this.uiButton34.TabIndex = 59;
    this.uiButton34.Text = "34";
    this.uiButton33.Cursor = Cursors.Hand;
    this.uiButton33.Font = new Font("微软雅黑", 12f);
    this.uiButton33.ForeColor = Color.Black;
    this.uiButton33.Location = new System.Drawing.Point(484, 254);
    this.uiButton33.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton33.Name = "uiButton33";
    this.uiButton33.ShowFocusLine = true;
    this.uiButton33.Size = new System.Drawing.Size(50, 25);
    this.uiButton33.Style = UIStyle.Custom;
    this.uiButton33.StyleCustomMode = true;
    this.uiButton33.TabIndex = 58;
    this.uiButton33.Text = "33";
    this.uiButton32.Cursor = Cursors.Hand;
    this.uiButton32.Font = new Font("微软雅黑", 12f);
    this.uiButton32.ForeColor = Color.Black;
    this.uiButton32.Location = new System.Drawing.Point(550, 254);
    this.uiButton32.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton32.Name = "uiButton32";
    this.uiButton32.ShowFocusLine = true;
    this.uiButton32.Size = new System.Drawing.Size(50, 25);
    this.uiButton32.Style = UIStyle.Custom;
    this.uiButton32.StyleCustomMode = true;
    this.uiButton32.TabIndex = 57;
    this.uiButton32.Text = "32";
    this.uiLine13.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiLine13.Location = new System.Drawing.Point(82, 235);
    this.uiLine13.MinimumSize = new System.Drawing.Size(16 /*0x10*/, 16 /*0x10*/);
    this.uiLine13.Name = "uiLine13";
    this.uiLine13.Size = new System.Drawing.Size(518, 16 /*0x10*/);
    this.uiLine13.Style = UIStyle.Custom;
    this.uiLine13.TabIndex = 56;
    this.uiLine13.TextAlign = ContentAlignment.MiddleLeft;
    this.uiButton31.Cursor = Cursors.Hand;
    this.uiButton31.Font = new Font("微软雅黑", 12f);
    this.uiButton31.ForeColor = Color.Black;
    this.uiButton31.Location = new System.Drawing.Point(82, 207);
    this.uiButton31.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton31.Name = "uiButton31";
    this.uiButton31.ShowFocusLine = true;
    this.uiButton31.Size = new System.Drawing.Size(50, 25);
    this.uiButton31.Style = UIStyle.Custom;
    this.uiButton31.StyleCustomMode = true;
    this.uiButton31.TabIndex = 55;
    this.uiButton31.Text = "31";
    this.uiButton30.Cursor = Cursors.Hand;
    this.uiButton30.Font = new Font("微软雅黑", 12f);
    this.uiButton30.ForeColor = Color.Black;
    this.uiButton30.Location = new System.Drawing.Point(148, 207);
    this.uiButton30.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton30.Name = "uiButton30";
    this.uiButton30.ShowFocusLine = true;
    this.uiButton30.Size = new System.Drawing.Size(50, 25);
    this.uiButton30.Style = UIStyle.Custom;
    this.uiButton30.StyleCustomMode = true;
    this.uiButton30.TabIndex = 54;
    this.uiButton30.Text = "30";
    this.uiButton29.Cursor = Cursors.Hand;
    this.uiButton29.Font = new Font("微软雅黑", 12f);
    this.uiButton29.ForeColor = Color.Black;
    this.uiButton29.Location = new System.Drawing.Point(214, 207);
    this.uiButton29.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton29.Name = "uiButton29";
    this.uiButton29.ShowFocusLine = true;
    this.uiButton29.Size = new System.Drawing.Size(50, 25);
    this.uiButton29.Style = UIStyle.Custom;
    this.uiButton29.StyleCustomMode = true;
    this.uiButton29.TabIndex = 53;
    this.uiButton29.Text = "29";
    this.uiButton28.Cursor = Cursors.Hand;
    this.uiButton28.Font = new Font("微软雅黑", 12f);
    this.uiButton28.ForeColor = Color.Black;
    this.uiButton28.Location = new System.Drawing.Point(280, 207);
    this.uiButton28.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton28.Name = "uiButton28";
    this.uiButton28.ShowFocusLine = true;
    this.uiButton28.Size = new System.Drawing.Size(50, 25);
    this.uiButton28.Style = UIStyle.Custom;
    this.uiButton28.StyleCustomMode = true;
    this.uiButton28.TabIndex = 52;
    this.uiButton28.Text = "28";
    this.uiButton27.Cursor = Cursors.Hand;
    this.uiButton27.Font = new Font("微软雅黑", 12f);
    this.uiButton27.ForeColor = Color.Black;
    this.uiButton27.Location = new System.Drawing.Point(349, 207);
    this.uiButton27.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton27.Name = "uiButton27";
    this.uiButton27.ShowFocusLine = true;
    this.uiButton27.Size = new System.Drawing.Size(50, 25);
    this.uiButton27.Style = UIStyle.Custom;
    this.uiButton27.StyleCustomMode = true;
    this.uiButton27.TabIndex = 51;
    this.uiButton27.Text = "27";
    this.uiButton26.Cursor = Cursors.Hand;
    this.uiButton26.Font = new Font("微软雅黑", 12f);
    this.uiButton26.ForeColor = Color.Black;
    this.uiButton26.Location = new System.Drawing.Point(415, 207);
    this.uiButton26.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton26.Name = "uiButton26";
    this.uiButton26.ShowFocusLine = true;
    this.uiButton26.Size = new System.Drawing.Size(50, 25);
    this.uiButton26.Style = UIStyle.Custom;
    this.uiButton26.StyleCustomMode = true;
    this.uiButton26.TabIndex = 50;
    this.uiButton26.Text = "26";
    this.uiButton25.Cursor = Cursors.Hand;
    this.uiButton25.Font = new Font("微软雅黑", 12f);
    this.uiButton25.ForeColor = Color.Black;
    this.uiButton25.Location = new System.Drawing.Point(484, 207);
    this.uiButton25.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton25.Name = "uiButton25";
    this.uiButton25.ShowFocusLine = true;
    this.uiButton25.Size = new System.Drawing.Size(50, 25);
    this.uiButton25.Style = UIStyle.Custom;
    this.uiButton25.StyleCustomMode = true;
    this.uiButton25.TabIndex = 49;
    this.uiButton25.Text = "25";
    this.uiButton24.Cursor = Cursors.Hand;
    this.uiButton24.Font = new Font("微软雅黑", 12f);
    this.uiButton24.ForeColor = Color.Black;
    this.uiButton24.Location = new System.Drawing.Point(550, 207);
    this.uiButton24.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton24.Name = "uiButton24";
    this.uiButton24.ShowFocusLine = true;
    this.uiButton24.Size = new System.Drawing.Size(50, 25);
    this.uiButton24.Style = UIStyle.Custom;
    this.uiButton24.StyleCustomMode = true;
    this.uiButton24.TabIndex = 48 /*0x30*/;
    this.uiButton24.Text = "24";
    this.uiLine12.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiLine12.Location = new System.Drawing.Point(82, 188);
    this.uiLine12.MinimumSize = new System.Drawing.Size(16 /*0x10*/, 16 /*0x10*/);
    this.uiLine12.Name = "uiLine12";
    this.uiLine12.Size = new System.Drawing.Size(518, 16 /*0x10*/);
    this.uiLine12.Style = UIStyle.Custom;
    this.uiLine12.TabIndex = 47;
    this.uiLine12.TextAlign = ContentAlignment.MiddleLeft;
    this.uiButton23.Cursor = Cursors.Hand;
    this.uiButton23.Font = new Font("微软雅黑", 12f);
    this.uiButton23.ForeColor = Color.Black;
    this.uiButton23.Location = new System.Drawing.Point(82, 160 /*0xA0*/);
    this.uiButton23.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton23.Name = "uiButton23";
    this.uiButton23.ShowFocusLine = true;
    this.uiButton23.Size = new System.Drawing.Size(50, 25);
    this.uiButton23.Style = UIStyle.Custom;
    this.uiButton23.StyleCustomMode = true;
    this.uiButton23.TabIndex = 46;
    this.uiButton23.Text = "23";
    this.uiButton22.Cursor = Cursors.Hand;
    this.uiButton22.Font = new Font("微软雅黑", 12f);
    this.uiButton22.ForeColor = Color.Black;
    this.uiButton22.Location = new System.Drawing.Point(148, 160 /*0xA0*/);
    this.uiButton22.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton22.Name = "uiButton22";
    this.uiButton22.ShowFocusLine = true;
    this.uiButton22.Size = new System.Drawing.Size(50, 25);
    this.uiButton22.Style = UIStyle.Custom;
    this.uiButton22.StyleCustomMode = true;
    this.uiButton22.TabIndex = 45;
    this.uiButton22.Text = "22";
    this.uiButton21.Cursor = Cursors.Hand;
    this.uiButton21.Font = new Font("微软雅黑", 12f);
    this.uiButton21.ForeColor = Color.Black;
    this.uiButton21.Location = new System.Drawing.Point(214, 160 /*0xA0*/);
    this.uiButton21.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton21.Name = "uiButton21";
    this.uiButton21.ShowFocusLine = true;
    this.uiButton21.Size = new System.Drawing.Size(50, 25);
    this.uiButton21.Style = UIStyle.Custom;
    this.uiButton21.StyleCustomMode = true;
    this.uiButton21.TabIndex = 44;
    this.uiButton21.Text = "21";
    this.uiButton20.Cursor = Cursors.Hand;
    this.uiButton20.Font = new Font("微软雅黑", 12f);
    this.uiButton20.ForeColor = Color.Black;
    this.uiButton20.Location = new System.Drawing.Point(280, 160 /*0xA0*/);
    this.uiButton20.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton20.Name = "uiButton20";
    this.uiButton20.ShowFocusLine = true;
    this.uiButton20.Size = new System.Drawing.Size(50, 25);
    this.uiButton20.Style = UIStyle.Custom;
    this.uiButton20.StyleCustomMode = true;
    this.uiButton20.TabIndex = 43;
    this.uiButton20.Text = "20";
    this.uiButton19.Cursor = Cursors.Hand;
    this.uiButton19.Font = new Font("微软雅黑", 12f);
    this.uiButton19.ForeColor = Color.Black;
    this.uiButton19.Location = new System.Drawing.Point(349, 160 /*0xA0*/);
    this.uiButton19.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton19.Name = "uiButton19";
    this.uiButton19.ShowFocusLine = true;
    this.uiButton19.Size = new System.Drawing.Size(50, 25);
    this.uiButton19.Style = UIStyle.Custom;
    this.uiButton19.StyleCustomMode = true;
    this.uiButton19.TabIndex = 42;
    this.uiButton19.Text = "19";
    this.uiButton18.Cursor = Cursors.Hand;
    this.uiButton18.Font = new Font("微软雅黑", 12f);
    this.uiButton18.ForeColor = Color.Black;
    this.uiButton18.Location = new System.Drawing.Point(415, 160 /*0xA0*/);
    this.uiButton18.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton18.Name = "uiButton18";
    this.uiButton18.ShowFocusLine = true;
    this.uiButton18.Size = new System.Drawing.Size(50, 25);
    this.uiButton18.Style = UIStyle.Custom;
    this.uiButton18.StyleCustomMode = true;
    this.uiButton18.TabIndex = 41;
    this.uiButton18.Text = "18";
    this.uiButton17.Cursor = Cursors.Hand;
    this.uiButton17.Font = new Font("微软雅黑", 12f);
    this.uiButton17.ForeColor = Color.Black;
    this.uiButton17.Location = new System.Drawing.Point(484, 160 /*0xA0*/);
    this.uiButton17.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton17.Name = "uiButton17";
    this.uiButton17.ShowFocusLine = true;
    this.uiButton17.Size = new System.Drawing.Size(50, 25);
    this.uiButton17.Style = UIStyle.Custom;
    this.uiButton17.StyleCustomMode = true;
    this.uiButton17.TabIndex = 40;
    this.uiButton17.Text = "17";
    this.uiLine11.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiLine11.Location = new System.Drawing.Point(82, 141);
    this.uiLine11.MinimumSize = new System.Drawing.Size(16 /*0x10*/, 16 /*0x10*/);
    this.uiLine11.Name = "uiLine11";
    this.uiLine11.Size = new System.Drawing.Size(518, 16 /*0x10*/);
    this.uiLine11.Style = UIStyle.Custom;
    this.uiLine11.TabIndex = 39;
    this.uiLine11.TextAlign = ContentAlignment.MiddleLeft;
    this.uiButton16.Cursor = Cursors.Hand;
    this.uiButton16.Font = new Font("微软雅黑", 12f);
    this.uiButton16.ForeColor = Color.Black;
    this.uiButton16.Location = new System.Drawing.Point(550, 160 /*0xA0*/);
    this.uiButton16.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton16.Name = "uiButton16";
    this.uiButton16.ShowFocusLine = true;
    this.uiButton16.Size = new System.Drawing.Size(50, 25);
    this.uiButton16.Style = UIStyle.Custom;
    this.uiButton16.StyleCustomMode = true;
    this.uiButton16.TabIndex = 38;
    this.uiButton16.Text = "16";
    this.uiButton15.Cursor = Cursors.Hand;
    this.uiButton15.Font = new Font("微软雅黑", 12f);
    this.uiButton15.ForeColor = Color.Black;
    this.uiButton15.Location = new System.Drawing.Point(82, 113);
    this.uiButton15.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton15.Name = "uiButton15";
    this.uiButton15.ShowFocusLine = true;
    this.uiButton15.Size = new System.Drawing.Size(50, 25);
    this.uiButton15.Style = UIStyle.Custom;
    this.uiButton15.StyleCustomMode = true;
    this.uiButton15.TabIndex = 37;
    this.uiButton15.Text = "15";
    this.uiButton14.Cursor = Cursors.Hand;
    this.uiButton14.Font = new Font("微软雅黑", 12f);
    this.uiButton14.ForeColor = Color.Black;
    this.uiButton14.Location = new System.Drawing.Point(148, 113);
    this.uiButton14.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton14.Name = "uiButton14";
    this.uiButton14.ShowFocusLine = true;
    this.uiButton14.Size = new System.Drawing.Size(50, 25);
    this.uiButton14.Style = UIStyle.Custom;
    this.uiButton14.StyleCustomMode = true;
    this.uiButton14.TabIndex = 36;
    this.uiButton14.Text = "14";
    this.uiButton13.Cursor = Cursors.Hand;
    this.uiButton13.Font = new Font("微软雅黑", 12f);
    this.uiButton13.ForeColor = Color.Black;
    this.uiButton13.Location = new System.Drawing.Point(214, 113);
    this.uiButton13.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton13.Name = "uiButton13";
    this.uiButton13.ShowFocusLine = true;
    this.uiButton13.Size = new System.Drawing.Size(50, 25);
    this.uiButton13.Style = UIStyle.Custom;
    this.uiButton13.StyleCustomMode = true;
    this.uiButton13.TabIndex = 35;
    this.uiButton13.Text = "13";
    this.uiButton12.Cursor = Cursors.Hand;
    this.uiButton12.Font = new Font("微软雅黑", 12f);
    this.uiButton12.ForeColor = Color.Black;
    this.uiButton12.Location = new System.Drawing.Point(280, 113);
    this.uiButton12.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton12.Name = "uiButton12";
    this.uiButton12.ShowFocusLine = true;
    this.uiButton12.Size = new System.Drawing.Size(50, 25);
    this.uiButton12.Style = UIStyle.Custom;
    this.uiButton12.StyleCustomMode = true;
    this.uiButton12.TabIndex = 34;
    this.uiButton12.Text = "12";
    this.uiButton11.Cursor = Cursors.Hand;
    this.uiButton11.Font = new Font("微软雅黑", 12f);
    this.uiButton11.ForeColor = Color.Black;
    this.uiButton11.Location = new System.Drawing.Point(349, 113);
    this.uiButton11.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton11.Name = "uiButton11";
    this.uiButton11.ShowFocusLine = true;
    this.uiButton11.Size = new System.Drawing.Size(50, 25);
    this.uiButton11.Style = UIStyle.Custom;
    this.uiButton11.StyleCustomMode = true;
    this.uiButton11.TabIndex = 33;
    this.uiButton11.Text = "11";
    this.uiButton10.Cursor = Cursors.Hand;
    this.uiButton10.Font = new Font("微软雅黑", 12f);
    this.uiButton10.ForeColor = Color.Black;
    this.uiButton10.Location = new System.Drawing.Point(415, 113);
    this.uiButton10.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton10.Name = "uiButton10";
    this.uiButton10.ShowFocusLine = true;
    this.uiButton10.Size = new System.Drawing.Size(50, 25);
    this.uiButton10.Style = UIStyle.Custom;
    this.uiButton10.StyleCustomMode = true;
    this.uiButton10.TabIndex = 32 /*0x20*/;
    this.uiButton10.Text = "10";
    this.uiButton9.Cursor = Cursors.Hand;
    this.uiButton9.Font = new Font("微软雅黑", 12f);
    this.uiButton9.ForeColor = Color.Black;
    this.uiButton9.Location = new System.Drawing.Point(484, 113);
    this.uiButton9.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton9.Name = "uiButton9";
    this.uiButton9.ShowFocusLine = true;
    this.uiButton9.Size = new System.Drawing.Size(50, 25);
    this.uiButton9.Style = UIStyle.Custom;
    this.uiButton9.StyleCustomMode = true;
    this.uiButton9.TabIndex = 31 /*0x1F*/;
    this.uiButton9.Text = "9";
    this.uiButton8.Cursor = Cursors.Hand;
    this.uiButton8.Font = new Font("微软雅黑", 12f);
    this.uiButton8.ForeColor = Color.Black;
    this.uiButton8.Location = new System.Drawing.Point(550, 113);
    this.uiButton8.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton8.Name = "uiButton8";
    this.uiButton8.ShowFocusLine = true;
    this.uiButton8.Size = new System.Drawing.Size(50, 25);
    this.uiButton8.Style = UIStyle.Custom;
    this.uiButton8.StyleCustomMode = true;
    this.uiButton8.TabIndex = 30;
    this.uiButton8.Text = "8";
    this.uiLine8.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiLine8.Location = new System.Drawing.Point(82, 94);
    this.uiLine8.MinimumSize = new System.Drawing.Size(16 /*0x10*/, 16 /*0x10*/);
    this.uiLine8.Name = "uiLine8";
    this.uiLine8.Size = new System.Drawing.Size(518, 16 /*0x10*/);
    this.uiLine8.Style = UIStyle.Custom;
    this.uiLine8.TabIndex = 28;
    this.uiLine8.TextAlign = ContentAlignment.MiddleLeft;
    this.uiLine7.Direction = UILine.LineDirection.Vertical;
    this.uiLine7.Font = new Font("微软雅黑", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiLine7.Location = new System.Drawing.Point(132, 66);
    this.uiLine7.Margin = new System.Windows.Forms.Padding(0);
    this.uiLine7.MinimumSize = new System.Drawing.Size(16 /*0x10*/, 16 /*0x10*/);
    this.uiLine7.Name = "uiLine7";
    this.uiLine7.Size = new System.Drawing.Size(16 /*0x10*/, 356);
    this.uiLine7.Style = UIStyle.Custom;
    this.uiLine7.TabIndex = 27;
    this.uiLine7.Text = "uiLine7";
    this.uiLine7.TextAlign = ContentAlignment.MiddleLeft;
    this.uiLine6.Direction = UILine.LineDirection.Vertical;
    this.uiLine6.Font = new Font("微软雅黑", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiLine6.Location = new System.Drawing.Point(198, 67);
    this.uiLine6.Margin = new System.Windows.Forms.Padding(0);
    this.uiLine6.MinimumSize = new System.Drawing.Size(16 /*0x10*/, 16 /*0x10*/);
    this.uiLine6.Name = "uiLine6";
    this.uiLine6.Size = new System.Drawing.Size(16 /*0x10*/, 355);
    this.uiLine6.Style = UIStyle.Custom;
    this.uiLine6.TabIndex = 26;
    this.uiLine6.Text = "uiLine6";
    this.uiLine6.TextAlign = ContentAlignment.MiddleLeft;
    this.uiLine5.Direction = UILine.LineDirection.Vertical;
    this.uiLine5.Font = new Font("微软雅黑", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiLine5.Location = new System.Drawing.Point(264, 67);
    this.uiLine5.Margin = new System.Windows.Forms.Padding(0);
    this.uiLine5.MinimumSize = new System.Drawing.Size(16 /*0x10*/, 16 /*0x10*/);
    this.uiLine5.Name = "uiLine5";
    this.uiLine5.Size = new System.Drawing.Size(16 /*0x10*/, 355);
    this.uiLine5.Style = UIStyle.Custom;
    this.uiLine5.TabIndex = 25;
    this.uiLine5.Text = "uiLine5";
    this.uiLine5.TextAlign = ContentAlignment.MiddleLeft;
    this.uiLine4.Direction = UILine.LineDirection.Vertical;
    this.uiLine4.Font = new Font("微软雅黑", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiLine4.Location = new System.Drawing.Point(330, 67);
    this.uiLine4.Margin = new System.Windows.Forms.Padding(0);
    this.uiLine4.MinimumSize = new System.Drawing.Size(16 /*0x10*/, 16 /*0x10*/);
    this.uiLine4.Name = "uiLine4";
    this.uiLine4.Size = new System.Drawing.Size(16 /*0x10*/, 355);
    this.uiLine4.Style = UIStyle.Custom;
    this.uiLine4.TabIndex = 24;
    this.uiLine4.Text = "uiLine4";
    this.uiLine4.TextAlign = ContentAlignment.MiddleLeft;
    this.uiLine3.Direction = UILine.LineDirection.Vertical;
    this.uiLine3.Font = new Font("微软雅黑", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiLine3.Location = new System.Drawing.Point(399, 67);
    this.uiLine3.Margin = new System.Windows.Forms.Padding(0);
    this.uiLine3.MinimumSize = new System.Drawing.Size(16 /*0x10*/, 16 /*0x10*/);
    this.uiLine3.Name = "uiLine3";
    this.uiLine3.Size = new System.Drawing.Size(16 /*0x10*/, 355);
    this.uiLine3.Style = UIStyle.Custom;
    this.uiLine3.TabIndex = 23;
    this.uiLine3.Text = "uiLine3";
    this.uiLine3.TextAlign = ContentAlignment.MiddleLeft;
    this.uiLine1.Direction = UILine.LineDirection.Vertical;
    this.uiLine1.Font = new Font("微软雅黑", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiLine1.Location = new System.Drawing.Point(468, 67);
    this.uiLine1.Margin = new System.Windows.Forms.Padding(0);
    this.uiLine1.MinimumSize = new System.Drawing.Size(16 /*0x10*/, 16 /*0x10*/);
    this.uiLine1.Name = "uiLine1";
    this.uiLine1.Size = new System.Drawing.Size(16 /*0x10*/, 355);
    this.uiLine1.Style = UIStyle.Custom;
    this.uiLine1.TabIndex = 22;
    this.uiLine1.Text = "uiLine1";
    this.uiLine1.TextAlign = ContentAlignment.MiddleLeft;
    this.uiLine10.Direction = UILine.LineDirection.Vertical;
    this.uiLine10.Font = new Font("微软雅黑", 14.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiLine10.Location = new System.Drawing.Point(534, 66);
    this.uiLine10.Margin = new System.Windows.Forms.Padding(0);
    this.uiLine10.MinimumSize = new System.Drawing.Size(16 /*0x10*/, 16 /*0x10*/);
    this.uiLine10.Name = "uiLine10";
    this.uiLine10.Size = new System.Drawing.Size(16 /*0x10*/, 356);
    this.uiLine10.Style = UIStyle.Custom;
    this.uiLine10.TabIndex = 21;
    this.uiLine10.Text = "uiLine10";
    this.uiLine10.TextAlign = ContentAlignment.MiddleLeft;
    this.uiLine2.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.uiLine2.Location = new System.Drawing.Point(82, 28);
    this.uiLine2.MinimumSize = new System.Drawing.Size(16 /*0x10*/, 16 /*0x10*/);
    this.uiLine2.Name = "uiLine2";
    this.uiLine2.Size = new System.Drawing.Size(518, 35);
    this.uiLine2.Style = UIStyle.Custom;
    this.uiLine2.TabIndex = 20;
    this.uiLine2.Text = "bit7         bit6          bit5         bit4          bit3          bit2           bit1         bit0";
    this.uiLine2.TextAlign = ContentAlignment.BottomLeft;
    this.uiButton7.Cursor = Cursors.Hand;
    this.uiButton7.Font = new Font("微软雅黑", 12f);
    this.uiButton7.ForeColor = Color.Black;
    this.uiButton7.Location = new System.Drawing.Point(82, 66);
    this.uiButton7.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton7.Name = "uiButton7";
    this.uiButton7.ShowFocusLine = true;
    this.uiButton7.Size = new System.Drawing.Size(50, 25);
    this.uiButton7.Style = UIStyle.Custom;
    this.uiButton7.StyleCustomMode = true;
    this.uiButton7.TabIndex = 9;
    this.uiButton7.Text = "7";
    this.uiButton6.Cursor = Cursors.Hand;
    this.uiButton6.Font = new Font("微软雅黑", 12f);
    this.uiButton6.ForeColor = Color.Black;
    this.uiButton6.Location = new System.Drawing.Point(148, 67);
    this.uiButton6.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton6.Name = "uiButton6";
    this.uiButton6.ShowFocusLine = true;
    this.uiButton6.Size = new System.Drawing.Size(50, 25);
    this.uiButton6.Style = UIStyle.Custom;
    this.uiButton6.StyleCustomMode = true;
    this.uiButton6.TabIndex = 8;
    this.uiButton6.Text = "6";
    this.uiButton5.Cursor = Cursors.Hand;
    this.uiButton5.Font = new Font("微软雅黑", 12f);
    this.uiButton5.ForeColor = Color.Black;
    this.uiButton5.Location = new System.Drawing.Point(214, 66);
    this.uiButton5.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton5.Name = "uiButton5";
    this.uiButton5.ShowFocusLine = true;
    this.uiButton5.Size = new System.Drawing.Size(50, 25);
    this.uiButton5.Style = UIStyle.Custom;
    this.uiButton5.StyleCustomMode = true;
    this.uiButton5.TabIndex = 7;
    this.uiButton5.Text = "5";
    this.uiButton4.Cursor = Cursors.Hand;
    this.uiButton4.Font = new Font("微软雅黑", 12f);
    this.uiButton4.ForeColor = Color.Black;
    this.uiButton4.Location = new System.Drawing.Point(280, 66);
    this.uiButton4.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton4.Name = "uiButton4";
    this.uiButton4.ShowFocusLine = true;
    this.uiButton4.Size = new System.Drawing.Size(50, 25);
    this.uiButton4.Style = UIStyle.Custom;
    this.uiButton4.StyleCustomMode = true;
    this.uiButton4.TabIndex = 6;
    this.uiButton4.Text = "4";
    this.uiButton3.Cursor = Cursors.Hand;
    this.uiButton3.Font = new Font("微软雅黑", 12f);
    this.uiButton3.ForeColor = Color.Black;
    this.uiButton3.Location = new System.Drawing.Point(349, 66);
    this.uiButton3.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton3.Name = "uiButton3";
    this.uiButton3.ShowFocusLine = true;
    this.uiButton3.Size = new System.Drawing.Size(50, 25);
    this.uiButton3.Style = UIStyle.Custom;
    this.uiButton3.StyleCustomMode = true;
    this.uiButton3.TabIndex = 5;
    this.uiButton3.Text = "3";
    this.uiButton2.Cursor = Cursors.Hand;
    this.uiButton2.Font = new Font("微软雅黑", 12f);
    this.uiButton2.ForeColor = Color.Black;
    this.uiButton2.Location = new System.Drawing.Point(415, 67);
    this.uiButton2.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton2.Name = "uiButton2";
    this.uiButton2.ShowFocusLine = true;
    this.uiButton2.Size = new System.Drawing.Size(50, 25);
    this.uiButton2.Style = UIStyle.Custom;
    this.uiButton2.StyleCustomMode = true;
    this.uiButton2.TabIndex = 4;
    this.uiButton2.Text = "2";
    this.uiButton1.Cursor = Cursors.Hand;
    this.uiButton1.Font = new Font("微软雅黑", 12f);
    this.uiButton1.ForeColor = Color.Black;
    this.uiButton1.Location = new System.Drawing.Point(484, 67);
    this.uiButton1.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton1.Name = "uiButton1";
    this.uiButton1.ShowFocusLine = true;
    this.uiButton1.Size = new System.Drawing.Size(50, 25);
    this.uiButton1.Style = UIStyle.Custom;
    this.uiButton1.StyleCustomMode = true;
    this.uiButton1.TabIndex = 3;
    this.uiButton1.Text = "1";
    this.uiButton0.Cursor = Cursors.Hand;
    this.uiButton0.Font = new Font("微软雅黑", 12f);
    this.uiButton0.ForeColor = Color.Black;
    this.uiButton0.Location = new System.Drawing.Point(550, 66);
    this.uiButton0.Margin = new System.Windows.Forms.Padding(0);
    this.uiButton0.Name = "uiButton0";
    this.uiButton0.ShowFocusLine = true;
    this.uiButton0.Size = new System.Drawing.Size(50, 25);
    this.uiButton0.Style = UIStyle.Custom;
    this.uiButton0.StyleCustomMode = true;
    this.uiButton0.TabIndex = 2;
    this.uiButton0.Text = "0";
    ((Control) this.myPanel3).BackColor = Color.DarkKhaki;
    ((Control) this.myPanel3).Controls.Add((Control) this.dS数字输入框1);
    ((Control) this.myPanel3).Controls.Add((Control) this.qqRadioButton2);
    ((Control) this.myPanel3).Controls.Add((Control) this.qqRadioButton1);
    ((Control) this.myPanel3).Controls.Add((Control) this.imageButton1);
    ((Control) this.myPanel3).Controls.Add((Control) this.progressBarEx1);
    ((Control) this.myPanel3).Controls.Add((Control) this.label1);
    ((Control) this.myPanel3).Controls.Add((Control) this.comboBox1);
    ((Control) this.myPanel3).Location = new System.Drawing.Point(0, 102);
    ((Control) this.myPanel3).Margin = new System.Windows.Forms.Padding(0);
    ((Control) this.myPanel3).Name = "myPanel3";
    ((Control) this.myPanel3).Size = new System.Drawing.Size(900, 43);
    ((Control) this.myPanel3).TabIndex = 11;
    this.dS数字输入框1.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.dS数字输入框1.Location = new System.Drawing.Point(368, 9);
    this.dS数字输入框1.MaxLength = 6;
    this.dS数字输入框1.Name = "dS数字输入框1";
    this.dS数字输入框1.Size = new System.Drawing.Size(100, 26);
    this.dS数字输入框1.TabIndex = 53;
    this.dS数字输入框1.Text = "19200";
    this.dS数字输入框1.TextAlign = HorizontalAlignment.Center;
    this.qqRadioButton2.AutoSize = true;
    this.qqRadioButton2.BackColor = Color.Transparent;
    this.qqRadioButton2.Font = new Font("宋体", 9f);
    this.qqRadioButton2.Location = new System.Drawing.Point(648, 14);
    this.qqRadioButton2.Name = "qqRadioButton2";
    this.qqRadioButton2.Size = new System.Drawing.Size(95, 16 /*0x10*/);
    this.qqRadioButton2.TabIndex = 51;
    this.qqRadioButton2.Text = "标准型校验和";
    this.qqRadioButton2.UseVisualStyleBackColor = false;
    this.qqRadioButton1.AutoSize = true;
    this.qqRadioButton1.BackColor = Color.Transparent;
    this.qqRadioButton1.Checked = true;
    this.qqRadioButton1.Font = new Font("宋体", 9f);
    this.qqRadioButton1.Location = new System.Drawing.Point(529, 14);
    this.qqRadioButton1.Name = "qqRadioButton1";
    this.qqRadioButton1.Size = new System.Drawing.Size(95, 16 /*0x10*/);
    this.qqRadioButton1.TabIndex = 50;
    this.qqRadioButton1.TabStop = true;
    this.qqRadioButton1.Text = "增强型校验和";
    this.qqRadioButton1.UseVisualStyleBackColor = false;
    this.qqRadioButton1.CheckedChanged += new EventHandler(this.qqRadioButton1_CheckedChanged);
    this.imageButton1.BackColor = Color.Transparent;
    this.imageButton1.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton1.DownImage = (Image) componentResourceManager.GetObject("imageButton1.DownImage");
    this.imageButton1.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton1.ForeColor = SystemColors.InfoText;
    this.imageButton1.Image = (Image) componentResourceManager.GetObject("imageButton1.Image");
    this.imageButton1.IsShowBorder = false;
    this.imageButton1.Location = new System.Drawing.Point(31 /*0x1F*/, 5);
    this.imageButton1.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton1.MoveImage = (Image) componentResourceManager.GetObject("imageButton1.MoveImage");
    this.imageButton1.Name = "imageButton1";
    this.imageButton1.NormalImage = (Image) componentResourceManager.GetObject("imageButton1.NormalImage");
    this.imageButton1.Size = new System.Drawing.Size(69, 32 /*0x20*/);
    this.imageButton1.TabIndex = 49;
    this.imageButton1.Text = "搜索设备";
    this.imageButton1.UseVisualStyleBackColor = false;
    this.imageButton1.Click += new EventHandler(this.imageButton1_Click);
    this.progressBarEx1.BackgroundPainter = (IProgressBackgroundPainter) this.greenGradientBackgroundPainter1;
    this.progressBarEx1.BorderPainter = (IProgressBorderPainter) this.greenPlainBorderPainter1;
    this.progressBarEx1.Location = new System.Drawing.Point(776, 14);
    this.progressBarEx1.MarqueePercentage = 25;
    this.progressBarEx1.MarqueeSpeed = 30;
    this.progressBarEx1.MarqueeStep = 1;
    this.progressBarEx1.Maximum = 100;
    this.progressBarEx1.Minimum = 0;
    this.progressBarEx1.Name = "progressBarEx1";
    this.progressBarEx1.ProgressPadding = 0;
    this.progressBarEx1.ProgressPainter = (IProgressPainter) this.greenPlainProgressPainter1;
    this.progressBarEx1.ProgressType = ProgressType.Smooth;
    this.progressBarEx1.ShowPercentage = true;
    this.progressBarEx1.Size = new System.Drawing.Size(90, 19);
    this.progressBarEx1.TabIndex = 8;
    this.progressBarEx1.Value = 0;
    this.greenGradientBackgroundPainter1.BottomColor = Color.FromArgb(211, 220, 226);
    this.greenGradientBackgroundPainter1.GlossPainter = (IGlossPainter) null;
    this.greenGradientBackgroundPainter1.TopColor = Color.FromArgb(253, 253, 253);
    this.greenPlainBorderPainter1.Color = Color.FromArgb(165, 178, 152);
    this.greenPlainBorderPainter1.RoundedCorners = true;
    this.greenPlainBorderPainter1.Style = PlainBorderPainter.PlainBorderStyle.Flat;
    this.greenPlainProgressPainter1.Color = Color.Orange;
    this.greenPlainProgressPainter1.GlossPainter = (IGlossPainter) this.greenGradientGlossPainter1;
    this.greenPlainProgressPainter1.LeadingEdge = Color.FromArgb(188, 203, 173);
    this.greenPlainProgressPainter1.ProgressBorderPainter = (IProgressBorderPainter) null;
    this.greenGradientGlossPainter1.AlphaHigh = 240 /*0xF0*/;
    this.greenGradientGlossPainter1.AlphaLow = 64 /*0x40*/;
    this.greenGradientGlossPainter1.Angle = 90f;
    this.greenGradientGlossPainter1.Color = Color.White;
    this.greenGradientGlossPainter1.PercentageCovered = 45;
    this.greenGradientGlossPainter1.Style = GlossStyle.Top;
    this.greenGradientGlossPainter1.Successor = (IGlossPainter) null;
    this.label1.AutoSize = true;
    this.label1.BackColor = Color.Transparent;
    this.label1.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.label1.ForeColor = Color.Black;
    this.label1.Location = new System.Drawing.Point(286, 12);
    this.label1.Name = "label1";
    this.label1.Size = new System.Drawing.Size(76, 20);
    this.label1.TabIndex = 6;
    this.label1.Text = "LIN波特率:";
    this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboBox1.FlatStyle = FlatStyle.Flat;
    this.comboBox1.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.comboBox1.ForeColor = SystemColors.ActiveCaptionText;
    this.comboBox1.FormattingEnabled = true;
    this.comboBox1.Location = new System.Drawing.Point(112 /*0x70*/, 9);
    this.comboBox1.Name = "comboBox1";
    this.comboBox1.Size = new System.Drawing.Size(99, 25);
    this.comboBox1.TabIndex = 4;
    this.imageButton2.BackColor = Color.Transparent;
    this.imageButton2.DialogResult = DialogResult.None;
    this.imageButton2.DownImage = (Image) null;
    this.imageButton2.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton2.HoverImage = (Image) null;
    this.imageButton2.Location = new System.Drawing.Point(792, 48 /*0x30*/);
    this.imageButton2.Margin = new System.Windows.Forms.Padding(0);
    this.imageButton2.Name = "imageButton2";
    this.imageButton2.NormalImage = (Image) Resources.关闭;
    this.imageButton2.Size = new System.Drawing.Size(90, 28);
    this.imageButton2.TabIndex = 28;
    this.imageButton2.TabStop = false;
    this.imageButton2.ToolTipText = (string) null;
    this.imageButton2.Click += new EventHandler(this.imageButton2_Click);
    this.myToolBar1.BackColor = Color.Transparent;
    this.myToolBar1.Font = new Font("微软雅黑", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
    this.myToolBar1.ForeColor = Color.White;
    myToolItem1.Image = (Image) componentResourceManager.GetObject("myToolItem1.Image");
    myToolItem1.Tag = (object) null;
    myToolItem1.Text = "单机模式";
    myToolItem2.Image = (Image) componentResourceManager.GetObject("myToolItem2.Image");
    myToolItem2.Tag = (object) null;
    myToolItem2.Text = "列表模式";
    myToolItem3.Image = (Image) componentResourceManager.GetObject("myToolItem3.Image");
    myToolItem3.Tag = (object) null;
    myToolItem3.Text = "从机模式";
    myToolItem4.Image = (Image) componentResourceManager.GetObject("myToolItem4.Image");
    myToolItem4.Tag = (object) null;
    myToolItem4.Text = "监听模式";
    myToolItem5.Image = (Image) componentResourceManager.GetObject("myToolItem5.Image");
    myToolItem5.Tag = (object) null;
    myToolItem5.Text = "开发者选项";
    myToolItem6.Image = (Image) componentResourceManager.GetObject("myToolItem6.Image");
    myToolItem6.Tag = (object) null;
    myToolItem6.Text = "离线模式";
    myToolItem7.Image = (Image) componentResourceManager.GetObject("myToolItem7.Image");
    myToolItem7.Tag = (object) null;
    myToolItem7.Text = "关于";
    this.myToolBar1.Items.Add(myToolItem1);
    this.myToolBar1.Items.Add(myToolItem2);
    this.myToolBar1.Items.Add(myToolItem3);
    this.myToolBar1.Items.Add(myToolItem4);
    this.myToolBar1.Items.Add(myToolItem5);
    this.myToolBar1.Items.Add(myToolItem6);
    this.myToolBar1.Items.Add(myToolItem7);
    this.myToolBar1.ItemSpace = 5;
    this.myToolBar1.Location = new System.Drawing.Point(0, 24);
    this.myToolBar1.Margin = new System.Windows.Forms.Padding(0);
    this.myToolBar1.Name = "myToolBar1";
    this.myToolBar1.Size = new System.Drawing.Size(554, 91);
    this.myToolBar1.TabIndex = 7;
    this.myToolBar1.Text = "myToolBar1";
    this.myToolBar1.SelectedItemChanged += new EventHandler(this.myToolBar1_SelectedItemChanged);
    this.openFileDialog2.FileName = "openFileDialog2";
    this.AutoScaleMode = AutoScaleMode.None;
    this.BackColor = SystemColors.ActiveCaption;
    this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
    this.BackgroundImageLayout = ImageLayout.Stretch;
    this.ClientSize = new System.Drawing.Size(900, 710);
    this.Controls.Add((Control) this.myPanel3);
    this.Controls.Add((Control) this.myPanel11);
    this.Controls.Add((Control) this.myToolBar1);
    this.Controls.Add((Control) this.imageButton2);
    this.Font = new Font("宋体", 9f);
    this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.Location = new System.Drawing.Point(0, 0);
    this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
    this.MaximizeBox = false;
    this.MaximumSize = new System.Drawing.Size(900, 710);
    this.MinimumSize = new System.Drawing.Size(900, 710);
    this.Name = nameof (Form1);
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Text = "LINTest-MI V1.0.5";
    this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
    this.Load += new EventHandler(this.Form1_Load);
    this.Resize += new EventHandler(this.Form1_Resize);
    ((Control) this.myPanel11).ResumeLayout(false);
    this.tabControl1.ResumeLayout(false);
    this.tabPage1.ResumeLayout(false);
    ((Control) this.myPanel8).ResumeLayout(false);
    ((Control) this.myPanel8).PerformLayout();
    ((Control) this.myPanel7).ResumeLayout(false);
    ((Control) this.myPanel7).PerformLayout();
    this.groupBoxEx4.ResumeLayout(false);
    this.groupBoxEx4.PerformLayout();
    this.tabPage2.ResumeLayout(false);
    ((Control) this.myPanel19).ResumeLayout(false);
    ((Control) this.myPanel19).PerformLayout();
    this.groupBoxEx3.ResumeLayout(false);
    this.groupBoxEx3.PerformLayout();
    ((ISupportInitialize) this.bar2).EndInit();
    ((ISupportInitialize) this.dataGridViewX1).EndInit();
    ((ISupportInitialize) this.bar1).EndInit();
    this.bar1.ResumeLayout(false);
    ((Control) this.bar1).PerformLayout();
    this.tabPage3.ResumeLayout(false);
    ((Control) this.myPanel1).ResumeLayout(false);
    this.groupBoxEx1.ResumeLayout(false);
    this.groupBoxEx1.PerformLayout();
    ((ISupportInitialize) this.bar3).EndInit();
    ((ISupportInitialize) this.dataGridViewX2).EndInit();
    ((ISupportInitialize) this.bar4).EndInit();
    this.bar4.ResumeLayout(false);
    ((Control) this.bar4).PerformLayout();
    this.tabPage4.ResumeLayout(false);
    ((Control) this.myPanel15).ResumeLayout(false);
    ((Control) this.myPanel15).PerformLayout();
    this.groupBoxEx2.ResumeLayout(false);
    this.groupBoxEx2.PerformLayout();
    this.groupBoxEx5.ResumeLayout(false);
    this.groupBoxEx5.PerformLayout();
    ((Control) this.myPanel14).ResumeLayout(false);
    ((Control) this.myPanel14).PerformLayout();
    this.tabPage5.ResumeLayout(false);
    this.tabPage5.PerformLayout();
    ((ISupportInitialize) this.dataGridViewX7).EndInit();
    ((ISupportInitialize) this.dataGridViewX6).EndInit();
    ((ISupportInitialize) this.dataGridViewX5).EndInit();
    ((ISupportInitialize) this.dataGridViewX4).EndInit();
    this.groupBoxEx7.ResumeLayout(false);
    this.groupBoxEx7.PerformLayout();
    this.groupBoxEx6.ResumeLayout(false);
    this.groupBoxEx6.PerformLayout();
    this.dS容器1.ResumeLayout(false);
    this.myTabControl1.ResumeLayout(false);
    this.tabPage11.ResumeLayout(false);
    ((ISupportInitialize) this.dataGridViewX3).EndInit();
    this.tabPage6.ResumeLayout(false);
    this.tabPage6.PerformLayout();
    this.tabPage7.ResumeLayout(false);
    this.tabPage7.PerformLayout();
    this.dS容器4.ResumeLayout(false);
    this.dS容器4.PerformLayout();
    this.dS容器3.ResumeLayout(false);
    this.dS容器3.PerformLayout();
    this.tabPage8.ResumeLayout(false);
    this.dS容器5.ResumeLayout(false);
    this.dS容器5.PerformLayout();
    this.tabPage9.ResumeLayout(false);
    ((ISupportInitialize) this.bar6).EndInit();
    ((ISupportInitialize) this.bar7).EndInit();
    this.bar7.ResumeLayout(false);
    ((ISupportInitialize) this.bar5).EndInit();
    this.tabPage10.ResumeLayout(false);
    this.uiTitlePanel3.ResumeLayout(false);
    this.uiTitlePanel2.ResumeLayout(false);
    this.uiTitlePanel1.ResumeLayout(false);
    this.uiTitlePanel1.PerformLayout();
    ((Control) this.myPanel3).ResumeLayout(false);
    ((Control) this.myPanel3).PerformLayout();
    ((ISupportInitialize) this.imageButton2).EndInit();
    this.ResumeLayout(false);
  }

  public delegate void USB_Receive();

  public delegate void Save_listViewNF1_Agency();

  public delegate void Save_listViewNF2_Agency();

  public delegate void Save_listViewNF3_Agency();

  public delegate void Save_listViewNF4_Agency();

  public delegate void Save_listViewNF6_Agency();

  public delegate void Recognition_Slave_Agency();

  public delegate void BOOT_Agency();

  public delegate void Exit_mode4();

  public delegate void Play_Sync();

  public struct POINT
  {
    public int X;
    public int Y;
  }

  public enum MouseEventFlags
  {
    Move = 1,
    LeftDown = 2,
    LeftUp = 4,
    RightDown = 8,
    RightUp = 16, // 0x00000010
    MiddleDown = 32, // 0x00000020
    MiddleUp = 64, // 0x00000040
    Wheel = 2048, // 0x00000800
    Absolute = 32768, // 0x00008000
  }
}
