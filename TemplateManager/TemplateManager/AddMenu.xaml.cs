using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Emgu.CV.Structure;
using ContourAnalysisNS;
using System.Drawing;
using Emgu.CV;

namespace TemplateManager
{
    /// <summary>
    /// Interaction logic for AddMenu.xaml
    /// </summary>
    public partial class AddMenu : Window
    {
        ImageProcessor processor = new ImageProcessor();
        Image<Bgr, Byte> frame;

        public AddMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg";
            if ((bool)dlg.ShowDialog())
            {
                ImageSource imageSource = new BitmapImage(new Uri(dlg.FileName));
                iTemplate.Source = imageSource;
                Capture capture = new Capture(dlg.FileName);
                processor.ProcessImage(capture.QueryFrame());
                int i= processor.contours.Count;
            }
            else
            {
                //No file
            }
        }

    }
}
