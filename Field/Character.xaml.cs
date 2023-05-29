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

using V = Berry.Docx.Visual.Field;

namespace Berry.DocxViewer.Field
{
    /// <summary>
    /// Character.xaml 的交互逻辑
    /// </summary>
    public partial class Character : UserControl
    {
        private FormattedText _formattedText;
        internal Character(V.Character character)
        {
            InitializeComponent();

            _formattedText = character.FormattedText;
            Width = character.Width;
            Height = character.Height;

            HorizontalAlignment = character.HorizontalAlignment.Convert<HorizontalAlignment>();
            VerticalAlignment = character.VerticalAlignment.Convert<VerticalAlignment>();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawText(_formattedText, new Point(0, 0));
        }
    }
}
