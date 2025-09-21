// Decompiled with JetBrains decompiler
// Type: LINTest.PDFForm
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

public class PDFForm : FormEx
{
  private IContainer components = (IContainer) null;
  private Label label1;
  private MyButton imageButton1;
  private DS容器 dS容器1;

  public PDFForm() => this.InitializeComponent();

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
    PDFForm.DrawFromAlphaMainPart((Form) this, e.Graphics);
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

  private void Form2_Load(object sender, EventArgs e)
  {
    this.label1.Text = init_Configuration.Output_Message;
  }

  private void imageButton1_Click_1(object sender, EventArgs e)
  {
    init_Configuration.PDFForm_OK_flag = true;
    init_Configuration.PDF_Interface.Close();
    Application.DoEvents();
  }

  private void PDFForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    if (!init_Configuration.PDFForm_OK_flag)
    {
      init_Configuration.PDFForm_OK_flag = true;
      init_Configuration.PDF_Interface.Close();
    }
    Application.DoEvents();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (PDFForm));
    this.label1 = new Label();
    this.imageButton1 = new MyButton();
    this.dS容器1 = new DS容器();
    this.dS容器1.SuspendLayout();
    this.SuspendLayout();
    this.label1.AutoSize = true;
    this.label1.BackColor = Color.Transparent;
    this.label1.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.label1.ForeColor = SystemColors.ControlText;
    this.label1.Location = new Point(28, 37);
    this.label1.Name = "label1";
    this.label1.Size = new Size(121, 20);
    this.label1.TabIndex = 9;
    this.label1.Text = "通信协议文件丢失";
    this.imageButton1.BackColor = Color.Transparent;
    this.imageButton1.BackgroundImageLayout = ImageLayout.Center;
    this.imageButton1.DownImage = (Image) componentResourceManager.GetObject("imageButton1.DownImage");
    this.imageButton1.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
    this.imageButton1.ForeColor = SystemColors.InfoText;
    this.imageButton1.Image = (Image) componentResourceManager.GetObject("imageButton1.Image");
    this.imageButton1.IsShowBorder = false;
    this.imageButton1.Location = new Point(96 /*0x60*/, 88);
    this.imageButton1.Margin = new Padding(0);
    this.imageButton1.MoveImage = (Image) componentResourceManager.GetObject("imageButton1.MoveImage");
    this.imageButton1.Name = "imageButton1";
    this.imageButton1.NormalImage = (Image) componentResourceManager.GetObject("imageButton1.NormalImage");
    this.imageButton1.Size = new Size(101, 36);
    this.imageButton1.TabIndex = 51;
    this.imageButton1.Text = "确定";
    this.imageButton1.UseVisualStyleBackColor = false;
    this.imageButton1.Click += new EventHandler(this.imageButton1_Click_1);
    this.dS容器1.BackColor = SystemColors.ScrollBar;
    this.dS容器1.Controls.Add((Control) this.label1);
    this.dS容器1.Controls.Add((Control) this.imageButton1);
    this.dS容器1.Location = new Point(0, 26);
    this.dS容器1.Name = "dS容器1";
    this.dS容器1.Size = new Size(300, 148);
    this.dS容器1.TabIndex = 52;
    this.dS容器1.标题文本偏移 = new Point(0, 0);
    this.dS容器1.贴图 = (Bitmap) null;
    this.dS容器1.贴图切割边距.上 = 0;
    this.dS容器1.贴图切割边距.下 = 0;
    this.dS容器1.贴图切割边距.右 = 0;
    this.dS容器1.贴图切割边距.左 = 0;
    this.dS容器1.边栏颜色 = Color.Empty;
    this.dS容器1.边框颜色 = Color.Empty;
    this.dS容器1.透明度 = 1f;
    this.AutoScaleDimensions = new SizeF(96f, 96f);
    this.AutoScaleMode = AutoScaleMode.Dpi;
    this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
    this.BackgroundImageLayout = ImageLayout.Stretch;
    this.ClientSize = new Size(300, 174);
    this.Controls.Add((Control) this.dS容器1);
    this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.Location = new Point(0, 0);
    this.MaximizeBox = false;
    this.MaximumSize = new Size(300, 174);
    this.MinimizeBox = false;
    this.MinimumSize = new Size(300, 174);
    this.Name = nameof (PDFForm);
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Text = "提示";
    this.FormClosing += new FormClosingEventHandler(this.PDFForm_FormClosing);
    this.Load += new EventHandler(this.Form2_Load);
    this.dS容器1.ResumeLayout(false);
    this.dS容器1.PerformLayout();
    this.ResumeLayout(false);
  }
}
