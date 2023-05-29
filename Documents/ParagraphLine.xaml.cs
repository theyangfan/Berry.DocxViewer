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
using Berry.DocxViewer.Field;

namespace Berry.DocxViewer.Documents
{
    /// <summary>
    /// ParagraphLine.xaml 的交互逻辑
    /// </summary>
    public partial class ParagraphLine : UserControl
    {
        internal ParagraphLine(V.ParagraphLine line)
        {
            InitializeComponent();

            Width = line.Width;
            Height = line.Height;
            Margin = new Thickness(line.Margin.Left,
                line.Margin.Top,
                line.Margin.Right,
                line.Margin.Bottom);

            Padding = new Thickness(line.Padding.Left,
                line.Padding.Top,
                line.Padding.Right,
                line.Padding.Bottom);

            UIGrid.HorizontalAlignment = line.HorizontalAlignment.Convert<HorizontalAlignment>();

            int index = 0;
            foreach (var c in line.Characters)
            {
                Character character = new Character(c);
                UIGrid.Children.Add(character);
                UIGrid.ColumnDefinitions.Add(new ColumnDefinition() { MinWidth = c.Width });
                Grid.SetColumn(character, index++);
            }

        }
    }
}
