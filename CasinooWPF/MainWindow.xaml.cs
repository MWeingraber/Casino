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
using System.Text.Json;
using System.Text.Json.Serialization;
//using Json.Net;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;

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
        Data data = new Data
        {
            counter = 0,
            bet = 5,
            credit = 50
        };
        Random rnd = new Random();
        int m;
        int a;
        int b;
        int c;
        //int credit = 50;
        //int bet = 5;
        //int counter = 0;
        int button = 0;
        int coutIntern = 0;
        DispatcherTimer timer1 = new DispatcherTimer();
        public List<Data> result = new List<Data>();

        //List<Data> desData = JsonConvert.DeserializeObject<List<Data>>(@"../../../TxtFile/Data.json");

        private void timer1_Tick(object sender, EventArgs e)
        {
            m = m + 10;
            //MessageBox.Show("I tic");
            if (m < 100)
            {
                a = Convert.ToInt32(1 + rnd.NextDouble() * 3);

                b = Convert.ToInt32(1 + rnd.NextDouble() * 3);

                c = Convert.ToInt32(1 + rnd.NextDouble() * 3);
                //Uri Watermelon = new Uri(@"..\..\..\images\rsz_watermelon.png", UriKind.Relative);
                //Uri Grapes = new Uri(@"..\..\..\images\rsz_grapes.png", UriKind.Relative);
                //Uri Sedmica = new Uri(@"..\..\..\images\rsz_sedmica.bmp", UriKind.Relative);
                Uri Watermelon = new Uri(@"C:\Users\morit\Desktop\Schule\SEW\Casino\CasinoWPF\CasinooWPF\images\rsz_watermelon.png");
                Uri Grapes = new Uri(@"C:\Users\morit\Desktop\Schule\SEW\Casino\CasinoWPF\CasinooWPF\images\rsz_grapes.png");
                Uri Sedmica = new Uri(@"C:\Users\morit\Desktop\Schule\SEW\Casino\CasinoWPF\CasinooWPF\images\rsz_sedmica.bmp");

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
                if (button==1&& coutIntern >= 0)
                {
                    coutIntern = 0;
                    timer1.IsEnabled = false;
                }
                else if (button==2&& coutIntern == 100)
                {
                    timer1.IsEnabled = false;
                    MessageBox.Show(Convert.ToString(data.counter));
                    coutIntern = 0;
                }
                m = 0;
                if ((a == b) && (a == c))
                {
                    lblMsg.Content = "Jackpot! You won " + (2 * data.bet).ToString() + " $!!!";
                    data.credit = data.credit + data.bet;
                    infolbl.Content = "CREDIT: " + data.credit.ToString() + " $";
                    //Data indiv = new Data
                    //{
                    //    counter = data.counter + 1,
                    //    bet = -data.bet,
                    //    credit = data.credit
                    //};
                    //result.Add(indiv);
                    coutIntern++;
                    data.counter += 1;
                }
                else
                {
                    lblMsg.Content = "No luck, try again";
                    data.credit = data.credit - data.bet;
                    infolbl.Content = "CREDIT: " + data.credit.ToString() + " $";
                    if (data.credit < data.bet)
                    {
                        Button1.IsEnabled = false;

                    }
                    if (data.credit == 0)
                    {
                        button2.IsEnabled = true;
                        button8.IsEnabled = false;
                        button5.IsEnabled = false;

                    }
                    
                    
                    coutIntern++;
                    data.counter += 1;
                }
                Data indiv = new Data
                {
                    counter = data.counter + 1,
                    bet = -data.bet,
                    credit = data.credit
                };
                result.Add(indiv);
                string json = JsonConvert.SerializeObject(result, Formatting.Indented);
                System.IO.File.AppendAllText(@"../../../TxtFile/Data.json", json);
                button8.IsEnabled = true;
                button5.IsEnabled = true;

                //using (StreamReader r = new StreamReader(@"../../../TxtFile/Data.json"))
                //{
                //    string json = r.ReadToEnd();
                //    result = JsonConvert.DeserializeObject<List<Data>>(json);
                //}
            }

        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            button = 1;
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
            data.credit = 50;
            infolbl.Content = "CREDIT: " + "50 $";

            button3.IsEnabled = true;
            button4.IsEnabled = true;

            button9.IsEnabled = true;
            button2.IsEnabled = false;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            data.credit++;
            infolbl.Content = "CREDIT: " + data.credit.ToString() + " $";
            button9.IsEnabled = true;
            button4.IsEnabled = true;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if ((data.credit > 0) && (data.bet < data.credit)) data.credit--;
            if (data.credit >= 0)
                infolbl.Content = "CREDIT: " + data.credit.ToString() + " $";
            if (data.credit == 0)
            {
                Button1.IsEnabled = false;
                button9.IsEnabled = false;
            }
            if (data.credit == 5) button4.IsEnabled = false;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if ((data.bet <= data.credit) && (data.bet > 0)) Button1.IsEnabled = true;
            button6.IsEnabled = true;
            button7.IsEnabled = true;
            button5.IsEnabled = false;
            Button10.IsEnabled = true;
            betlbl.Content = "BET: " + data.bet.ToString() + " $";
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (data.bet < data.credit)
            {
                Button1.IsEnabled = true;
                data.bet++;
                betlbl.Content = "BET: " + data.bet.ToString() + " $";
            }
            button7.IsEnabled = true;
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if (data.bet > 0) data.bet--;
            if (data.bet <= data.credit) Button1.IsEnabled = true;
            betlbl.Content = "BET: " + data.bet.ToString() + " $";
            if (data.bet == 0)
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
                data.credit = 50;
                data.bet = 5;
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
        private void Button10_Click(object sender, RoutedEventArgs e)
        {
            button = 2;
            timer1.Interval = TimeSpan.FromMilliseconds(0);
            timer1.Start();
            //using (StreamReader r = new StreamReader(@"../../../TxtFile/Data.json"))
            //{
            //   string json = r.ReadToEnd();
            //    result = JsonConvert.DeserializeObject<List<Data>>(json);
            //}
            //listBx.Items.Add(result);
        }
    }
}