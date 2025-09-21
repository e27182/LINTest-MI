// Decompiled with JetBrains decompiler
// Type: CH340BCFG.CH340BCFGDLL
// Assembly: LINTest-MI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 31F20A11-E735-463D-98C4-C3643CDDF7B8
// Assembly location: C:\Users\xxxxx\Downloads\LIN Test MI\Files.fm_LINTest-MI\电脑软件\LINTest-MI V1.0.5\LINTest-MI.exe

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace CH340BCFG;

internal class CH340BCFGDLL
{
  public const uint GENERIC_READ = 2147483648 /*0x80000000*/;
  public const uint GENERIC_WRITE = 1073741824 /*0x40000000*/;
  public const int OPEN_EXISTING = 3;

  [DllImport("CH340.DLL")]
  public static extern bool CH340BSetSerial(IntPtr hSerial);

  [DllImport("CH340.DLL")]
  public static extern bool CH340BEepromReadTotal(IntPtr hSerial, ref EEPROM_INFORMATION EepromInf);

  [DllImport("CH340.DLL")]
  public static extern bool CH340BEepromWriteTotal(IntPtr hSerial, ref EEPROM_INFORMATION EepromInf);

  [DllImport("kernel32.DLL")]
  public static extern bool CloseHandle(IntPtr hSerial);

  public static IntPtr CreateFilev(
    string lpFileName,
    uint dwDesiredAccess,
    int dwShareMode,
    int lpSecurityAttributes,
    int dwCreationDisposition,
    int dwFlagsAndAttributes,
    int hTemplateFile)
  {
    return CH340BCFGDLL.CreateFile(lpFileName, dwDesiredAccess, dwShareMode, lpSecurityAttributes, dwCreationDisposition, dwFlagsAndAttributes, hTemplateFile);
  }

  [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
  public static extern IntPtr CreateFile(
    string lpFileName,
    uint dwDesiredAccess,
    int dwShareMode,
    int lpSecurityAttributes,
    int dwCreationDisposition,
    int dwFlagsAndAttributes,
    int hTemplateFile);
}
