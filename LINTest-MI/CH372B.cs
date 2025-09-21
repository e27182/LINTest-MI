// Decompiled with JetBrains decompiler
// Type: 工程.CH372B
// Assembly: LINTest-MI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 31F20A11-E735-463D-98C4-C3643CDDF7B8
// Assembly location: C:\Users\xxxxx\Downloads\LIN Test MI\Files.fm_LINTest-MI\电脑软件\LINTest-MI V1.0.5\LINTest-MI.exe

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace 工程;

internal class CH372B
{
  public static CH372B.deleSetNotify Notify_Variable = (CH372B.deleSetNotify) null;
  public const int DEVICE_ARRIVAL = 3;
  public const int DEVICE_REMOVE_PEND = 1;
  public const int DEVICE_REMOVE = 0;
  private static int[] ReadLength;

  public static void Init()
  {
    CH372B.ReadLength = new int[1];
    CH372B.ReadLength[0] = 0;
  }

  public static int OpenDevice(int index) => (int) CH372B.CH375OpenDevice(index);

  public static void CloseDevice(int index) => CH372B.CH375CloseDevice(index);

  public static int GetVersion() => CH372B.CH375GetVersion();

  public static int CH372DriverCommand(int index, uint Command)
  {
    return CH372B.CH375DriverCommand(index, Command);
  }

  public static int GetDrvVersion() => CH372B.CH375GetDrvVersion();

  public static bool ResetDevice(short index) => CH372B.CH375ResetDevice(index);

  public static bool GetDeviceDescr(short index, byte[] oBuffer, ref int ioLength)
  {
    CH372B.ReadLength[0] = ioLength;
    bool deviceDescr = CH372B.CH375GetDeviceDescr(index, oBuffer, CH372B.ReadLength);
    ioLength = CH372B.ReadLength[0];
    return deviceDescr;
  }

  public static bool GetConfigDescr(short index, byte[] oBuffer, ref int ioLength)
  {
    CH372B.ReadLength[0] = ioLength;
    bool configDescr = CH372B.CH375GetConfigDescr(index, oBuffer, CH372B.ReadLength);
    ioLength = CH372B.ReadLength[0];
    return configDescr;
  }

  public static void SetIntRoutine(short index, CH372B.deleSetIntRoutine iNotifyRoutine)
  {
    CH372B.CH375SetIntRoutine(index, iNotifyRoutine);
  }

  public static bool ReadInter(short index, byte[] oBuffer, ref int ioLength)
  {
    CH372B.ReadLength[0] = ioLength;
    bool flag = CH372B.CH375ReadInter(index, oBuffer, CH372B.ReadLength);
    ioLength = CH372B.ReadLength[0];
    return flag;
  }

  public static void AbortInter(short index) => CH372B.CH375AbortInter(index);

  public static bool ReadData(int index, byte[] buffer, ref int length)
  {
    CH372B.ReadLength[0] = length;
    bool flag = CH372B.CH375ReadData((short) index, buffer, CH372B.ReadLength);
    length = CH372B.ReadLength[0];
    return flag;
  }

  public static void AbortRead(short index) => CH372B.CH375AbortRead(index);

  public static bool WriteData(int index, byte[] buffer, ref int length)
  {
    CH372B.ReadLength[0] = length;
    bool flag = CH372B.CH375WriteData((short) index, buffer, CH372B.ReadLength);
    length = CH372B.ReadLength[0];
    return flag;
  }

  public static void AbortWrite(short index) => CH372B.CH375AbortWrite(index);

  public static bool SetTimeout(
    short index,
    uint iWriteTimeout,
    uint iReadTimeout,
    uint iAuxTimeout,
    uint iInterTimeout)
  {
    return CH372B.CH375SetTimeoutEx(index, iWriteTimeout, iReadTimeout, iAuxTimeout, iInterTimeout);
  }

  public static bool WriteAuxData(short index, byte[] oBuffer, ref int ioLength)
  {
    CH372B.ReadLength[0] = ioLength;
    bool flag = CH372B.CH375WriteAuxData(index, oBuffer, CH372B.ReadLength);
    ioLength = CH372B.ReadLength[0];
    return flag;
  }

  public static void SetExclusive(short index, bool iExclusive)
  {
    CH372B.CH375SetExclusive(index, iExclusive);
  }

  public static uint GetUsbID(short index) => CH372B.CH375GetUsbID(index);

  public static void SetDeviceNotify(int index, CH372B.deleSetNotify iNotifyRoutine)
  {
    CH372B.CH375SetDeviceNotify(index, (string) null, iNotifyRoutine);
  }

  [DllImport("CH375DLL.dll")]
  private static extern IntPtr CH375OpenDevice(int iIndex);

  [DllImport("CH375DLL.dll")]
  private static extern void CH375CloseDevice(int iIndex);

  [DllImport("CH375DLL.dll")]
  private static extern int CH375GetVersion();

  [DllImport("CH375DLL.dll")]
  private static extern int CH375GetDrvVersion();

  [DllImport("CH375DLL.dll")]
  private static extern int CH375DriverCommand(int index, uint Command);

  [DllImport("CH375DLL.dll")]
  private static extern bool CH375ResetDevice(short iIndex);

  [DllImport("CH375DLL.dll")]
  private static extern bool CH375GetDeviceDescr(short iIndex, [MarshalAs(UnmanagedType.LPArray)] byte[] oBuffer, [MarshalAs(UnmanagedType.LPArray)] int[] ioLength);

  [DllImport("CH375DLL.dll")]
  private static extern bool CH375GetConfigDescr(short iIndex, [MarshalAs(UnmanagedType.LPArray)] byte[] oBuffer, [MarshalAs(UnmanagedType.LPArray)] int[] ioLength);

  [DllImport("CH375DLL.DLL ")]
  private static extern bool CH375SetIntRoutine(short iIndex, CH372B.deleSetIntRoutine iIntRoutine);

  [DllImport("CH375DLL.dll")]
  private static extern bool CH375ReadInter(short iIndex, [MarshalAs(UnmanagedType.LPArray)] byte[] oBuffer, [MarshalAs(UnmanagedType.LPArray)] int[] ioLength);

  [DllImport("CH375DLL.DLL ")]
  private static extern bool CH375AbortInter(short iIndex);

  [DllImport("CH375DLL.DLL", SetLastError = true)]
  private static extern bool CH375ReadData(short iIndex, [MarshalAs(UnmanagedType.LPArray)] byte[] oBuffer, [MarshalAs(UnmanagedType.LPArray)] int[] ioLength);

  [DllImport("CH375DLL.DLL ")]
  private static extern bool CH375AbortRead(short iIndex);

  [DllImport("CH375DLL.DLL", SetLastError = true)]
  private static extern bool CH375WriteData(short iIndex, [MarshalAs(UnmanagedType.LPArray)] byte[] iBuffer, [MarshalAs(UnmanagedType.LPArray)] int[] ioLength);

  [DllImport("CH375DLL.DLL ")]
  private static extern bool CH375AbortWrite(short iIndex);

  [DllImport("CH375DLL.DLL")]
  private static extern bool CH375SetTimeoutEx(
    short index,
    uint iWriteTimeout,
    uint iReadTimeout,
    uint iAuxTimeout,
    uint iInterTimeout);

  [DllImport("CH375DLL.DLL", SetLastError = true)]
  private static extern bool CH375WriteAuxData(short iIndex, [MarshalAs(UnmanagedType.LPArray)] byte[] iBuffer, [MarshalAs(UnmanagedType.LPArray)] int[] ioLength);

  [DllImport("CH375DLL.DLL ")]
  private static extern bool CH375SetExclusive(short index, bool iExclusive);

  [DllImport("CH375DLL.DLL ")]
  private static extern uint CH375GetUsbID(short index);

  [DllImport("CH375DLL.DLL ")]
  private static extern bool CH375SetDeviceNotify(
    int iIndex,
    string iDeviceID,
    CH372B.deleSetNotify iNotifyRoutine);

  public delegate void deleSetNotify(IntPtr iBuffer);

  public delegate void deleSetIntRoutine(IntPtr iBuffer);
}
