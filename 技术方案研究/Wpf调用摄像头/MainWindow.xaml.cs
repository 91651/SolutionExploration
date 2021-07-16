using System;
using System.Drawing;
using System.Windows;
using Emgu.CV;

namespace Wpf调用摄像头
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // 需要x86 或者 x64 否则异常
            // ImageViewer viewer = new ImageViewer();
            var c = new Emgu.CV.VideoCapture();

            // Capture capture = new Capture();
            // 使用线程闲余加载图像
            //System.Windows.Interop.ComponentDispatcher.ThreadIdle += delegate
            //{
            //    viewer.Image = c.QueryFrame();
            //};
            // c.Start();


            c.FlipVertical = true;
            viewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            c.ImageGrabbed += (object _sender, EventArgs _e) =>
            {
                Mat fr = new Mat();
                c.Read(fr);

                viewer.Image = fr;
                viewer.BackColor = Color.Red;
            };
            c.Start();

        }
    }
}
