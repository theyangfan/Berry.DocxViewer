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
    /// Table.xaml 的交互逻辑
    /// </summary>
    public partial class Table : UserControl
    {
        internal Table(V.Table table)
        {
            InitializeComponent();

            Width = table.Width;
            Height = table.Height;
            HorizontalAlignment = table.HorizontalAlignment.Convert<HorizontalAlignment>();

            foreach(var height in table.RowHeights)
            {
                RowDefinition row = new RowDefinition() { Height = new GridLength(height) };
                UIGrid.RowDefinitions.Add(row);
            }

            foreach(var width in table.ColumnWidths)
            {
                ColumnDefinition column = new ColumnDefinition() { Width = new GridLength (width) };
                UIGrid.ColumnDefinitions.Add(column);
            }

            foreach(var cell in table.Cells)
            {
                var tc = new TableCell(cell);
                
                
                UIGrid.Children.Add(tc);
            }
        }
    }
}
