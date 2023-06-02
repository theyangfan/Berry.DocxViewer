using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Imaging;
using  BVF = Berry.Docx.Visual.Field;

namespace Berry.DocxViewer.Field
{
    /// <summary>
    /// Picture.xaml 的交互逻辑
    /// </summary>
    public partial class Picture : UserControl
    {
        private Bitmap _bitmap;
        private double _width;
        private double _height;

        internal Picture(BVF.Picture picture)
        {
            InitializeComponent();
            
            using(var stream = picture.Stream)
                _bitmap = new Bitmap(stream);
            _width = picture.Width;
            _height = picture.Height;

            Width = picture.Width;
            Height = picture.Height;

            HorizontalAlignment = picture.HorizontalAlignment.Convert<HorizontalAlignment>();
            VerticalAlignment = VerticalAlignment.Bottom;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            MemoryStream srcStream = new MemoryStream();
            Bitmap bmBuf = new Bitmap(_bitmap);
            bmBuf.Save(srcStream, ImageFormat.Png);
            srcStream.Seek(0, SeekOrigin.Begin);
            BitmapImage bmImg = new BitmapImage();
            bmImg.BeginInit();
            bmImg.StreamSource = srcStream;
            bmImg.EndInit();
            drawingContext.DrawImage(bmImg, new Rect(0, 0, _width, _height));

            _bitmap.Dispose();
            bmBuf.Dispose();
        }
    }
}
