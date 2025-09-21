// Decompiled with JetBrains decompiler
// Type: LINTest.Program
// Assembly: LINTest-MI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 31F20A11-E735-463D-98C4-C3643CDDF7B8
// Assembly location: C:\Users\xxxxx\Downloads\LIN Test MI\Files.fm_LINTest-MI\电脑软件\LINTest-MI V1.0.5\LINTest-MI.exe

using System;
using System.Windows.Forms;

#nullable disable
namespace LINTest;

internal static class Program
{
  [STAThread]
  private static void Main()
  {
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run((Form) new Form1());
  }
}
