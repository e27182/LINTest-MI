// Decompiled with JetBrains decompiler
// Type: LINTest.CloseForm
// Assembly: LINTest-MI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 31F20A11-E735-463D-98C4-C3643CDDF7B8
// Assembly location: C:\Users\xxxxx\Downloads\LIN Test MI\Files.fm_LINTest-MI\电脑软件\LINTest-MI V1.0.5\LINTest-MI.exe

using ControlExs;
using DSControls;
using MyControl.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#nullable disable
namespace LINTest;

public class CloseForm : FormEx
{
  private IContainer components = (IContainer) null;
  private DS容器 dS容器1;
  private MyButton imageButton2;
  private MyButton imageButton1;
  private Label label1;

  public CloseForm() => this.InitializeComponent();

  protected override CreateParams CreateParams
  {
    get
    {
      CreateParams createParams = base.CreateParams;
      if (!this.DesignMode)
        createParams.ExStyle |= 33554432 /*0x02000000*/;
      return createParams;
    }
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    base.OnPaint(e);
    CloseForm.DrawFromAlphaMainPart((Form) this, e.Graphics);
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

  private void CloseForm_FormClosing(object sender, FormClosingEventArgs e)
  {
  }

  private void imageButton1_Click(object sender, EventArgs e)
  {
    init_Configuration.CloseForm_Main_flag = true;
    init_Configuration.Close_Interface.Close();
  }

  private void imageButton2_Click(object sender, EventArgs e)
  {
    init_Configuration.CloseForm_Main_flag = false;
    init_Configuration.Close_Interface.Close();
  }

  private void CloseForm_Load(object sender, EventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (CloseForm));
    this.dS容器1 = new DS容器();
    this.imageButton2 = new MyButton();
    this.imageButton1 = new MyButton();
    this.label1 = new Label();
    this.dS容器1.SuspendLayout();
    this.SuspendLayout();
    this.dS容器1.BackColor = SystemColors.ScrollBar;
    this.dS容器1.Controls.Add((Control) this.imageButton2);
    this.dS容器1.Controls.Add((Control) this.imageButton1);
    this.dS容器1.Controls.Add((Control) this.label1);
    this.dS容器1.Location = new Point(0, 26);
    this.dS容器1.Name = "dS容器1";
    this.dS容器1.Size = new Size(300, 148);
    this.dS容器1.TabIndex = 60;
    this.dS容器1.标题文本偏移 = new Point(0, 0);
    this.dS容器1.贴图 = (Bitmap) null;
    this.dS容器1.贴图切割边距.上 = 0;
    this.dS容器1.贴图切割边距.下 = 0;
    this.dS容器1.贴图切割边距.右 = 0;
    this.dS容器1.贴图切割边距.左 = 0;
    this.dS容器1.边栏颜色 = Color.Empty;
    this.dS容器1.边框颜色 = Color.Empty;
    this.dS容器1.透明度 = 1f;
    this.imageButton2.BackColor = SystemColors.ScrollBar;
    this.imageButton2.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton2.DownImage = (Image) componentResourceManager.GetObject("imageButton2.DownImage");
    this.imageButton2.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton2.ForeColor = SystemColors.InfoText;
    this.imageButton2.Image = (Image) componentResourceManager.GetObject("imageButton2.Image");
    this.imageButton2.IsShowBorder = false;
    this.imageButton2.Location = new Point(193, 92);
    this.imageButton2.Margin = new Padding(0);
    this.imageButton2.MoveImage = (Image) componentResourceManager.GetObject("imageButton2.MoveImage");
    this.imageButton2.Name = "imageButton2";
    this.imageButton2.NormalImage = (Image) componentResourceManager.GetObject("imageButton2.NormalImage");
    this.imageButton2.Size = new Size(69, 32 /*0x20*/);
    this.imageButton2.TabIndex = 62;
    this.imageButton2.Text = "否";
    this.imageButton2.UseVisualStyleBackColor = false;
    this.imageButton2.Click += new EventHandler(this.imageButton2_Click);
    this.imageButton1.BackColor = SystemColors.ScrollBar;
    this.imageButton1.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton1.DownImage = (Image) componentResourceManager.GetObject("imageButton1.DownImage");
    this.imageButton1.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton1.ForeColor = SystemColors.InfoText;
    this.imageButton1.Image = (Image) componentResourceManager.GetObject("imageButton1.Image");
    this.imageButton1.IsShowBorder = false;
    this.imageButton1.Location = new Point(34, 92);
    this.imageButton1.Margin = new Padding(0);
    this.imageButton1.MoveImage = (Image) componentResourceManager.GetObject("imageButton1.MoveImage");
    this.imageButton1.Name = "imageButton1";
    this.imageButton1.NormalImage = (Image) componentResourceManager.GetObject("imageButton1.NormalImage");
    this.imageButton1.Size = new Size(69, 32 /*0x20*/);
    this.imageButton1.TabIndex = 61;
    this.imageButton1.Text = "是";
    this.imageButton1.UseVisualStyleBackColor = false;
    this.imageButton1.Click += new EventHandler(this.imageButton1_Click);
    this.label1.AutoSize = true;
    this.label1.BackColor = SystemColors.ScrollBar;
    this.label1.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.label1.ForeColor = SystemColors.ControlText;
    this.label1.Location = new Point(30, 26);
    this.label1.Name = "label1";
    this.label1.Size = new Size(93, 20);
    this.label1.TabIndex = 60;
    this.label1.Text = "是否关闭软件";
    this.AutoScaleDimensions = new SizeF(8f, 20f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.BackColor = Color.Green;
    this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
    this.BackgroundImageLayout = ImageLayout.Stretch;
    this.ClientSize = new Size(300, 174);
    this.Controls.Add((Control) this.dS容器1);
    this.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.Location = new Point(0, 0);
    this.Margin = new Padding(4, 5, 4, 5);
    this.MaximizeBox = false;
    this.MaximumSize = new Size(300, 174);
    this.MinimizeBox = false;
    this.MinimumSize = new Size(300, 174);
    this.Name = nameof (CloseForm);
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Text = "提示";
    this.FormClosing += new FormClosingEventHandler(this.CloseForm_FormClosing);
    this.Load += new EventHandler(this.CloseForm_Load);
    this.dS容器1.ResumeLayout(false);
    this.dS容器1.PerformLayout();
    this.ResumeLayout(false);
  }
}
