// Decompiled with JetBrains decompiler
// Type: 工程.ListViewNF
// Assembly: LINTest-MI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 31F20A11-E735-463D-98C4-C3643CDDF7B8
// Assembly location: C:\Users\xxxxx\Downloads\LIN Test MI\Files.fm_LINTest-MI\电脑软件\LINTest-MI V1.0.5\LINTest-MI.exe

using System.Windows.Forms;

#nullable disable
namespace 工程;

internal class ListViewNF : ListView
{
  public ListViewNF()
  {
    this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    this.SetStyle(ControlStyles.EnableNotifyMessage, true);
  }

  protected override void OnNotifyMessage(Message m)
  {
    if (m.Msg == 20)
      return;
    base.OnNotifyMessage(m);
  }
}
