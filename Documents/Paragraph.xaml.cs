using System;
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

using V = Berry.Docx.Visual.Documents;

namespace Berry.DocxViewer.Documents
{
    /// <summary>
    /// Paragraph.xaml 的交互逻辑
    /// </summary>
    public partial class Paragraph : UserControl
    {
        internal Paragraph(V.Paragraph paragraph)
        {
            InitializeComponent();

            Width = paragraph.Width;
            Height = paragraph.Height;
            Margin = new Thickness(paragraph.Margin.Left,
                paragraph.Margin.Top,
                paragraph.Margin.Right,
                paragraph.Margin.Bottom);

            Padding = new Thickness(paragraph.Padding.Left,
                paragraph.Padding.Top,
                paragraph.Padding.Right,
                paragraph.Padding.Bottom);

            foreach (var line in paragraph.Lines)
            {
                UIContentArea.Children.Add(new ParagraphLine(line));
            }
        }
    }
}
