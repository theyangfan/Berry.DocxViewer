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
    /// TableCell.xaml 的交互逻辑
    /// </summary>
    public partial class TableCell : UserControl
    {
        internal TableCell(V.TableCell cell)
        {
            InitializeComponent();

            Width = cell.Width;
            Height = cell.Height;
            
            Grid.SetRow(this, cell.RowIndex);
            Grid.SetColumn(this, cell.ColumnIndex);
            Grid.SetRowSpan(this, cell.RowSpan);
            Grid.SetColumnSpan(this, cell.ColumnSpan);

            UIContent.Margin = new Thickness(cell.Padding.Left,
                cell.Padding.Top,
                cell.Padding.Right,
                cell.Padding.Bottom);
            Background = new SolidColorBrush(cell.Background.Convert());

            UILeftBorder.BorderThickness = new Thickness(cell.Borders.Left.Width, 0, 0, 0);
            UILeftBorder.BorderBrush = new SolidColorBrush(cell.Borders.Left.Color.Convert());

            UITopBorder.BorderThickness = new Thickness(0, cell.Borders.Top.Width, 0, 0);
            UITopBorder.BorderBrush = new SolidColorBrush(cell.Borders.Top.Color.Convert());

            UIRightBorder.BorderThickness = new Thickness(0, 0, cell.Borders.Right.Width, 0);
            UIRightBorder.BorderBrush = new SolidColorBrush(cell.Borders.Right.Color.Convert());
            
            UIBottomBorder.BorderThickness = new Thickness(0, 0, 0, cell.Borders.Bottom.Width);
            UIBottomBorder.BorderBrush = new SolidColorBrush(cell.Borders.Bottom.Color.Convert());

            UIContent.VerticalAlignment = cell.VerticalAlignment.Convert<VerticalAlignment>();

            foreach(var p in cell.Paragraphs)
            {
                Paragraph paragraph  = new Paragraph(p);
                UIContent.Children.Add(paragraph);
            }
        }
    }
}
