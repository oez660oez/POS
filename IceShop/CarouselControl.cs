using System;
using System.Drawing;
using System.Windows.Forms;

namespace IceShop
{
    public partial class CarouselControl : UserControl
    {
        private Timer slideTimer;
        private Timer pauseTimer;
        private int currentIndex = 0;
        private PictureBox[] pictureBoxes;
        private Panel panel;
        private string[] images;
        private int slideSpeed = 10; // 控制滑動速度
        private int targetX; // 目標位置的 X 坐標
        private int pauseDuration = 5000; // 停留時間（5秒）

        public CarouselControl()
        {
            InitializeComponent();

            // 設定輪播的圖片
            images = new string[]
            {
                $"{GlobalVar.image_dir}\\輪播1.jpg", // 替換為你實際的圖片路徑
                $"{GlobalVar.image_dir}\\輪播2.jpg",
                $"{GlobalVar.image_dir}\\輪播3.jpg"
            };

            // 創建 Panel 控件
            panel = new Panel();
            panel.Size = new Size(430, 170);
            panel.Location = new Point(0, 0);
            panel.BorderStyle = BorderStyle.None;
            this.Controls.Add(panel);

            // 創建 PictureBox 控件並添加到 Panel 中
            pictureBoxes = new PictureBox[images.Length];
            for (int i = 0; i < images.Length; i++)
            {
                PictureBox pb = new PictureBox();
                pb.Image = Image.FromFile(images[i]);
                pb.SizeMode = PictureBoxSizeMode.Zoom; // 設置為 Zoom 模式
                pb.Size = new Size(panel.Width, panel.Height);
                pb.Location = new Point(i * panel.Width, 0); // 水平排列
                pictureBoxes[i] = pb;
                panel.Controls.Add(pb);
            }

            // 設定滑動 Timer 控件
            slideTimer = new Timer();
            slideTimer.Interval = 50; // 控制滑動效果的更新頻率
            slideTimer.Tick += SlideTimer_Tick;

            // 設定停留 Timer 控件
            pauseTimer = new Timer();
            pauseTimer.Interval = pauseDuration; // 停留時間
            pauseTimer.Tick += PauseTimer_Tick;

            // 一開始將第一張圖片放置在中間
            panel.Left = 0;
            targetX = -panel.Width;

            // 開始停留計時器
            pauseTimer.Start();
        }

        private void PauseTimer_Tick(object sender, EventArgs e)
        {
            // 停留時間結束，開始滑動
            pauseTimer.Stop();
            slideTimer.Start();
        }

        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            // 控制 Panel 向右滑動
            if (panel.Left < targetX)
            {
                panel.Left += slideSpeed; // 向右滑動
            }
            else
            {
                // 當面板到達目標位置（右側外部）時，切換到下一張圖片
                slideTimer.Stop();
                SwitchToNextImage();
                panel.Left = 0; // 重置 Panel 位置到中間
                targetX = -panel.Width; // 更新目標位置為右側外部
                pauseTimer.Start(); // 開始停留計時器
            }
        }

        private void SwitchToNextImage()
        {
            currentIndex = (currentIndex + 1) % images.Length;

            // 更新圖片位置
            for (int i = 0; i < images.Length; i++)
            {
                pictureBoxes[i].Location = new Point((i - currentIndex) * panel.Width, 0);
            }
        }
    }
}
