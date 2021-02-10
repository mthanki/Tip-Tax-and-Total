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

namespace Tip__Tax_and_Total
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        const decimal TIP_PERCENT = 15;
        const decimal SALES_TAX_PERCENT = 7;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ApplyErrorStyle()
        {
            BillAmountTextBox.BorderBrush = Brushes.Red;
        }

        private void ResetToMainStyle()
        {
            BillAmountTextBox.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 171, 173, 179));
        }

        private void CalculateTotalAmount_Click(object sender, RoutedEventArgs e)
        {
            ResetToMainStyle();
            try
            {
                decimal BillAmount = decimal.Parse(BillAmountTextBox.Text);

                decimal TipAmount = (BillAmount * TIP_PERCENT) / 100;
                decimal SalesTaxAmount = (BillAmount * SALES_TAX_PERCENT) / 100;

                decimal TotalAmount = BillAmount + TipAmount + SalesTaxAmount;

                TipAmountLabel.Content = TipAmount;
                SalesTaxAmountLabel.Content = SalesTaxAmount;
                TotalAmountLabel.Content = TotalAmount;

            }
            catch
            {
                BillAmountTextBox.Text = "";
                ApplyErrorStyle();
                ErrorWindow E = new ErrorWindow();
                E.Show();
            }
        }
    }
}
