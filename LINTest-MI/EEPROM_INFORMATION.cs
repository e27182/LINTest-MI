// Decompiled with JetBrains decompiler
// Type: CH340BCFG.EEPROM_INFORMATION
// Assembly: LINTest-MI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 31F20A11-E735-463D-98C4-C3643CDDF7B8
// Assembly location: C:\Users\xxxxx\Downloads\LIN Test MI\Files.fm_LINTest-MI\电脑软件\LINTest-MI V1.0.5\LINTest-MI.exe

using System.Runtime.InteropServices;

#nullable disable
namespace CH340BCFG;

public struct EEPROM_INFORMATION
{
  private bool bIsEeprom;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
  public byte[] Vid;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
  public byte[] Pid;
  private bool bSN;
  private bool bWP;
  private bool bPS;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
  public byte[] SN;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 44)]
  public byte[] PS;
}
