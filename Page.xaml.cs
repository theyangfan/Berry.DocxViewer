using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using V = Berry.Docx.Visual;
using VD = Berry.Docx.Visual.Documents;
using Berry.DocxViewer.Documents;

namespace Berry.DocxViewer
{
    /// <summary>
    /// Page.xaml 的交互逻辑
    /// </summary>
    public partial class Page : UserControl
    {
        internal Page(V.Page page, bool showHorizontalGridLines, bool showVerticalGridLines)
        {
            InitializeComponent();

            Width = page.Width;
            Height = page.Height;
            UIBody.Width = page.Width - page.Padding.Left - page.Padding.Right;
            UIBody.Height = page.Height - page.Padding.Top - page.Padding.Bottom;
            UIBody.Margin = new Thickness(page.Padding.Left, page.Padding.Top, 0, 0);
            
            foreach (var item in page.ChildItems)
            {
                if(item is VD.Paragraph)
                    UIBody.Children.Add(new Paragraph((VD.Paragraph)item));
                else if (item is VD.Table)
                    UIBody.Children.Add(new Table((VD.Table)item));
            }

            // Draw gird lines
            DrawingVisual visual = new DrawingVisual();
            DrawingContext drawingContext = visual.RenderOpen();
            Pen pen = new Pen(new SolidColorBrush(Color.FromRgb(170, 170, 170)), 0.5);
            double width = page.Width - page.Padding.Left - page.Padding.Right;
            double height = page.Height - page.Padding.Top - page.Padding.Bottom;
            if (showVerticalGridLines && page.CharSpace > 0)
            {
                for (double x = 0; x < width; x += page.CharSpace)
                {
                    drawingContext.DrawLine(pen, new Point(x, 0), new Point(x, height));
                }
            }
            if (showHorizontalGridLines && page.LineSpace > 0)
            {
                for (double y = 0; y < height; y += page.LineSpace)
                {
                    drawingContext.DrawLine(pen, new Point(0, y), new Point(width, y));
                }
            }
            drawingContext.Close();
            VisualBrush brush = new VisualBrush(visual);
            brush.Stretch = Stretch.UniformToFill;
            UIBody.Background = brush;
        }
    }
}
