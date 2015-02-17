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
        Templates templates;
        Templates samples;
        public Template selectedTemplate;
        Bitmap bmp;


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
                ShowContours(processor.templates, processor.samples, frame);
            }
            else
            {
                //No file
            }
        }

        private void ShowContours(Templates templates, Templates samples, IImage image)
        {
           
            
        }

        private void dgTemplatese_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            //this.templates = templates;
            //this.samples = samples;

            this.samples = new Templates();
            foreach (var sample in samples)
                this.samples.Add(sample);
            int i=0;

            Template template = samples[dgTemplatese.Items.Count];

            Graphics gr;

            dgTemplatese.ro

            System.Drawing.Rectangle r = new System.Drawing.Rectangle(dgTemplatese.Items);
            
            var rect = new System.Drawing.Rectangle(e.CellBounds.X, e.CellBounds.Y, (e.CellBounds.Width - 24) / 2, e.CellBounds.Height);
            rect.Inflate(-20, -20);
            System.Drawing.Rectangle boundRect = template.contour.SourceBoundingRect;
            float k1 = 1f * rect.Width / boundRect.Width;
            float k2 = 1f * rect.Height / boundRect.Height;
            float k = Math.Min(k1, k2);

            gr.DrawImage(bmp,
                new System.Drawing.Rectangle(rect.X, rect.Y, (int)(boundRect.Width * k), (int)(boundRect.Height * k)),
                boundRect, GraphicsUnit.Pixel);


            template.Draw(gr, e.CellBounds);
            
        }

    }
}
