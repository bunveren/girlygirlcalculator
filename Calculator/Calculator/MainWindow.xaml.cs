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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber;
        double result {get; set;}
        islem islem = islem.hic;
        Boolean resultComma = false;
        
        public MainWindow()
        {
            InitializeComponent();
            result = 0; resultLabel.Text = "0";
        }

        private void IslemButton_click(object sender, RoutedEventArgs e)
        {
            //if (sender == YUZDE) Console.WriteLine("i can do anything rn!");
            result = Double.Parse(resultLabel.Text.ToString());

            if (sender == AC) 
            {
                result = 0;
            }
            else
            if (sender == YUZDE)
            {
                result = (double)(result / 100);
                
            }
            else
            if (sender == SIL)
            {
                result = Double.Parse(
                    ((result + "")).Length == 1 ? 
                    "0" : ((result + "")).Substring(0, (result + "").Length - 1)
                );
            }
            else
            if (sender == VIRGUL) 
            {
                resultLabel.Text = resultLabel.Text + ",0";
                resultComma = true;
            }
            else
            if (sender == ESIT)
            {
                if (islem != islem.hic) {
                    Console.WriteLine("hic olmayan islem");
                    switch (islem) 
                    {
                        case islem.topla:
                            {
                                result = result + lastNumber;
                                break;
                            }
                        case islem.cikar:
                            {
                                result = lastNumber - result;
                                break;
                            }
                        case islem.carp:
                            {
                                result = result * lastNumber;
                                break;
                            }
                        case islem.bol:
                            {
                                result = lastNumber / result;
                                break;
                            }

                    }
                    resultLabel.Text = result.ToString();
                }
            }
            /*************/
            else 
            if (sender == BOL)
            {
                lastNumber = result;
                result = 0;
                islem = islem.bol;
            }
            else
            if (sender == CARP)
            {
                lastNumber = result;
                result = 0;
                islem = islem.carp;
            }
            else
            if (sender == CIKAR)
            {
                lastNumber = result;
                result = 0;
                islem = islem.cikar;
            }
            else
            if (sender == TOPLA)
            {
                lastNumber = result;
                result = 0;
                islem = islem.topla;
            }
            

            resultLabel.Text = result.ToString();
        }


        private void Number_Click(object sender, RoutedEventArgs e)
        {

            if (resultLabel.Text != null)
            {
                string temp_resultlabel = resultLabel.Text.ToString();
                temp_resultlabel = temp_resultlabel.Replace("0", "");
                if (temp_resultlabel.Length == 0) resultLabel.Text = "";
            }

            if (!resultComma)
            {
                if (resultLabel.Text == "" && (sender as Button == CIFTSIFIR)) sender = SIFIR;
                resultLabel.Text += (sender as Button).Content.ToString();
            }
            else {
                resultLabel.Text += ","+(sender as Button).Content.ToString();
                resultComma = false;
            }
            

            result = Double.Parse(resultLabel.Text.ToString());
        }
    }

    enum islem 
    {
        topla,
        cikar,
        carp,
        bol,
        hic
    }
}
