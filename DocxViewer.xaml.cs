using System;
using System.IO;
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
using WinForm = System.Windows.Forms;

namespace Berry.DocxViewer
{
    /// <summary>
    /// The DOCX file viewer control.
    /// </summary>
    public partial class DocxViewer : UserControl
    {
        #region Private Members
        private string _filename = string.Empty;
        private double _scale = 1.0;
        private bool _showHorizontalGridLines = false;
        private bool _showVerticalGridLines = false;
        #endregion

        #region Constructors
        public DocxViewer()
        {
            InitializeComponent();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Loads the specified docx file.
        /// </summary>
        public string Source
        {
            get => _filename;
            set
            {
                Load(value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicates whether show horizontal document grid lines.
        /// </summary>
        public bool ShowHorizontalGridLines
        {
            get => _showHorizontalGridLines;
            set => _showHorizontalGridLines = value;
        }

        /// <summary>
        /// Gets or sets a value indicates whether show vertical document grid lines.
        /// </summary>
        public bool ShowVerticalGridLines
        {
            get => _showVerticalGridLines;
            set => _showVerticalGridLines = value;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Loads the specified docx file.
        /// </summary>
        /// <param name="filename">Docx file.</param>
        public void Load(string filename)
        {
            _filename = filename;
            if (string.IsNullOrEmpty(filename)) return;
            FileInfo fileInfo = new FileInfo(filename);
            if (!fileInfo.Exists || fileInfo.Extension != ".docx") return;
            UIPageArea.Children.Clear();
            UITotalPage.Content = "¼ÓÔØÖÐ...";
            UIScale.Content = "100%";
            try
            {
                using (var doc = new Berry.Docx.Document(filename, FileShare.ReadWrite))
                {
                    var document = new Berry.Docx.Visual.Document(doc);
                    UITotalPage.Content = $"¹² {document.Pages.Count} Ò³";
                    foreach (var page in document.Pages)
                    {
                        UIPageArea.Children.Add(new Page(page, _showHorizontalGridLines, _showVerticalGridLines));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
        #endregion

        #region Private Methods
        private void UIOpenFileBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var openFileDlg = new WinForm.OpenFileDialog())
            {
                openFileDlg.Filter = "docx files (*.docx)|*.docx";
                openFileDlg.Multiselect = false;
                if (openFileDlg.ShowDialog() == WinForm.DialogResult.OK)
                {
                    Load(openFileDlg.FileName);
                }
            }
        }

        private void OnFileDrop(object sender, DragEventArgs e)
        {
            string filename = ((string[])e.Data.GetData(System.Windows.DataFormats.FileDrop))[0];
            Load(filename);
        }

        private void RefreshMenu_Click(object sender, RoutedEventArgs e)
        {
            Load(_filename);
        }

        private void OnScaling(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.Modifiers != ModifierKeys.Control) return;
            e.Handled = true;
            if (e.Delta > 0)
            {
                _scale += 0.1;
            }
            else
            {
                if (_scale <= 0.2) return;
                _scale -= 0.1;
            }
            UIScale.Content = $"{(int)(_scale * 100)}%";
            UIPageArea.LayoutTransform = new ScaleTransform(_scale, _scale, UIPageArea.ActualWidth / 2, 0);
        }
        #endregion

    }
}