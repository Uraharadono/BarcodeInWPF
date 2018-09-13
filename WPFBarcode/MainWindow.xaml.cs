using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFBarcode
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            // **********************************
            // Encode The Data
            // **********************************
            Barcode barcode = new Barcode();
            barcode.BarcodeType = Barcode.BarcodeEnum.Code39;
            barcode.Data = "1234567";
            barcode.CheckDigit = Barcode.YesNoEnum.Yes;
            barcode.Encode();

            var thinness = 3;
            var thickness = 3 * thinness;

            string outputString = barcode.EncodedData;
            string humanText = barcode.HumanText;


            // **********************************
            // Draw The Barcode
            // **********************************
            int len = outputString.Length;
            int currentPos = 10;
            int currentTop = 10;
            int currentColor = 0;
            for (int i = 0; i < len; i++)
            {
                Rectangle rect = new Rectangle();
                rect.Height = 200;
                if (currentColor == 0)
                {
                    currentColor = 1;
                    rect.Fill = new SolidColorBrush(Colors.Black);

                }
                else
                {
                    currentColor = 0;
                    rect.Fill = new SolidColorBrush(Colors.White);

                }
                Canvas.SetLeft(rect, currentPos);
                Canvas.SetTop(rect, currentTop);

                if (outputString[i] == 't')
                {
                    rect.Width = thinness;
                    currentPos += thinness;

                }
                else if (outputString[i] == 'w')
                {
                    rect.Width = thickness;
                    currentPos += thickness;

                }
                mainCanvas.Children.Add(rect);

            }

            // **********************************
            // Add the Human Readable Text
            // **********************************

            TextBlock textUnderBarcode = new TextBlock();
            textUnderBarcode.Text = humanText;
            textUnderBarcode.FontSize = 32;
            textUnderBarcode.FontFamily = new FontFamily("Courier New");
            Rect rx = new Rect(0, 0, 0, 0);
            textUnderBarcode.Arrange(rx);
            Canvas.SetLeft(textUnderBarcode, (currentPos - textUnderBarcode.ActualWidth) / 2);
            Canvas.SetTop(textUnderBarcode, currentTop + 205);
            mainCanvas.Children.Add(textUnderBarcode);
        }
    }
}