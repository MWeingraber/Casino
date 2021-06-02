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
using System.Windows.Threading;

namespace CasinooWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            timer1.Tick += timer1_Tick;
        }
        Random rnd = new Random();
        int m;
        int a;
        int b;
        int c;
        int credit = 50;
        int bet = 5;

        DispatcherTimer timer1 = new DispatcherTimer();
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            m = m + 10;
            if (m < 100)
            {

                a = Convert.ToInt32(1 + rnd.NextDouble() * 3);

                b = Convert.ToInt32(1 + rnd.NextDouble() * 3);

                c = Convert.ToInt32(1 + rnd.NextDouble() * 3);
                Uri Watermelon = new Uri("C:/Users/morit/Desktop/Schule/SEW/CasinoWPF/CasinooWPF/images/rsz_watermelon.png");
                Uri Grapes = new Uri("C:/Users/morit/Desktop/Schule/SEW/CasinoWPF/CasinooWPF/images/rsz_grapes.png");
                Uri Sedmica = new Uri("C:/Users/morit/Desktop/Schule/SEW/CasinoWPF/CasinooWPF/images/rsz_sedmica.bmp");

                switch (a)
                {
                    case 1:
                        PictureBox1.Source = new BitmapImage(Watermelon);
                        //MessageBox.Show("H");
                        break;
                    case 2:
                        PictureBox1.Source = new BitmapImage(Grapes);
                        //MessageBox.Show("H");
                        break;
                    case 3:
                        PictureBox1.Source = new BitmapImage(Sedmica);
                        //MessageBox.Show("H");
                        break;

                }
                switch (b)
                {
                    case 1:
                        PictureBox2.Source = new BitmapImage(Watermelon);
                        break;
                    case 2:
                        PictureBox2.Source = new BitmapImage(Grapes);
                        break;
                    case 3:
                        PictureBox2.Source = new BitmapImage(Sedmica);
                        break;

                }
                switch (c)
                {
                    case 1:
                        PictureBox3.Source = new BitmapImage(Watermelon);
                        break;
                    case 2:
                        PictureBox3.Source = new BitmapImage(Grapes);
                        break;
                    case 3:
                        PictureBox3.Source = new BitmapImage(Sedmica);
                        break;

                }
            }
            else
            {
                timer1.IsEnabled = false;
                m = 0;
                if ((a == b) && (a == c))
                {
                    lblMsg.Content = "Jackpot! You won " + (2 * bet).ToString() + " $!!!";
                    credit = credit + bet;
                    infolbl.Content = "CREDIT: " + credit.ToString() + " $";

                }
                else
                {
                    lblMsg.Content = "No luck, try again";
                    credit = credit - bet;
                    infolbl.Content = "CREDIT: " + credit.ToString() + " $";
                    if (credit < bet)
                    {
                        Button1.IsEnabled = false;

                    }
                    if (credit == 0)
                    {
                        button2.IsEnabled = true;
                        button8.IsEnabled = false;
                        button5.IsEnabled = false;

                    }
                }

                button8.IsEnabled = true;
                button5.IsEnabled = true;
            }

        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            button6.IsEnabled = false;
            button7.IsEnabled = false;
            button9.IsEnabled = false;
            button8.IsEnabled = false;
            timer1.IsEnabled = true;
            timer1.Interval = TimeSpan.FromMilliseconds(50);
            timer1.Start();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            credit = 50;
            infolbl.Content = "CREDIT: " + "50 $";

            button3.IsEnabled = true;
            button4.IsEnabled = true;

            button9.IsEnabled = true;
            button2.IsEnabled = false;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            credit++;
            infolbl.Content = "CREDIT: " + credit.ToString() + " $";
            button9.IsEnabled = true;
            button4.IsEnabled = true;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if ((credit > 0) && (bet < credit)) credit--;
            if (credit >= 0)
                infolbl.Content = "CREDIT: " + credit.ToString() + " $";
            if (credit == 0)
            {
                Button1.IsEnabled = false;
                button9.IsEnabled = false;
            }
            if (credit == 5) button4.IsEnabled = false;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if ((bet <= credit) && (bet > 0)) Button1.IsEnabled = true;
            button6.IsEnabled = true;
            button7.IsEnabled = true;
            button5.IsEnabled = false;
            betlbl.Content = "BET: " + bet.ToString() + " $";
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (bet < credit)
            {
                Button1.IsEnabled = true;
                bet++;
                betlbl.Content = "BET: " + bet.ToString() + " $";
            }
            button7.IsEnabled = true;
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if (bet > 0) bet--;
            if (bet <= credit) Button1.IsEnabled = true;
            betlbl.Content = "BET: " + bet.ToString() + " $";
            if (bet == 0)
            {
                Button1.IsEnabled = false;
                button7.IsEnabled = false;
            }
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Thank you for playing!\n Would you like to play again?", "End of game", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Button1.IsEnabled = false;
                button5.IsEnabled = false;
                button3.IsEnabled = false;
                button4.IsEnabled = false;
                button6.IsEnabled = false;
                button7.IsEnabled = false;
                button9.IsEnabled = false;
                button8.IsEnabled = false;
                button2.IsEnabled = true;
                credit = 50;
                bet = 5;
                infolbl.Content = "CREDIT: ";
                betlbl.Content = "BET: ";
                lblMsg.Content = "";
            }
            else Environment.Exit(0);
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            button9.IsEnabled = false;
            button5.IsEnabled = true;


        }
        
    }
}
