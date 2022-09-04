
namespace cs_form_transform;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        // フォームの境界線とタイトルを表示しない
        this.FormBorderStyle = FormBorderStyle.None;
        // 画像サイズ
        this.Size = new Size(584, 396);
        // 画像を読み込む( 吹き出し部分以外青 )
        Bitmap bmp = new Bitmap("fu.png");
        // 透明にする色
        Color tColor = Color.Blue;
        // 背景画像に指定する
        this.BackgroundImage = bmp;

        // 透明を指定する
        this.TransparencyKey = tColor;

        // ウインドウを　richTextBox 以外で移動できるようにする
        this.MouseDown +=
            new MouseEventHandler(Form1_MouseDown);
        this.MouseMove +=
            new MouseEventHandler(Form1_MouseMove);
    }

    // マウスのクリック位置
    private Point mousePoint;

    // マウスのボタンが押された
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
        {
            // 押された位置
            mousePoint = new Point(e.X, e.Y);
        }
    }

    // マウスのドラッグ処理
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
        {
            this.Left += e.X - mousePoint.X;
            this.Top += e.Y - mousePoint.Y;
        }
    }
}
