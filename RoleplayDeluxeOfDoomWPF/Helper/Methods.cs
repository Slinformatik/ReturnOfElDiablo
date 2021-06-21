using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace RoleplayDeluxeOfDoomWPF.Helper
{
    class Methods
    {
        public static Random rnd = new Random();
        public static void ChangeProgressbar(Player pl, ProgressBar pbar, TextBlock tb, int value)
        {
            pbar.Value -= value;
            pl.HP = Convert.ToInt32(pbar.Value);
            tb.Text = pl.HP.ToString()+"/"+pl.Max;
        }

        public static void UseAttack(Player player, Player enemy, TextBox tb, int whichAttack, ProgressBar pb, TextBlock tbHP)
        {
            Attack tempAttack = player.Attacks[whichAttack];
            if(rnd.Next(0,100)<= tempAttack.Accuracy)
            {
                ChangeProgressbar(enemy, pb , tbHP , tempAttack.Damage);
                ShowTextInDramatic($"{player.Name} hat mit der Attacke {tempAttack.Name} ins schwarze getroffen. {enemy.Name} hat {tempAttack.Damage} Schaden erhalten!",tb);
                IsDeath(enemy,tb);
                
            }
            else ShowTextInDramatic($"{player.Name} hat mit der Attacke {tempAttack.Name} nicht getroffen. {enemy.Name} bleibt unversehrt!",tb);
            //f
            Vibrations(player);
            if (player.Name == "John Johnson")
            {
                UseAttack(enemy, player, tb, rnd.Next(0, 4), MainWindow.playerPbar, MainWindow.playertb);
                IsDeath(player,tb);
            }
                
        }
        private static void ShowTextInDramatic(string text, TextBox tb)
        {
            tb.Text = "";
            char[] array = text.ToCharArray();
            foreach(char c in array)
            {
                
                tb.Text += c;
                Thread.Sleep(1);
                DoEvents();
            }
            Thread.Sleep(1000);
            DoEvents();
        }
        private static void IsDeath(Player pl,TextBox tb)
        {
            if(pl.HP <= 0)
            {
                ShowTextInDramatic($"{pl.Name} ist zusammengebrochen",tb);
           
                if (pl.Name == "John Johnson")
                    MainWindow.ritter.Source = new BitmapImage(new Uri("pack://application:,,,/RoleplayDeluxeOfDoomWPF;component/Resources/Bernd_Ritter.png"));
            }
        }
        public static void Vibrations(Player pl) 
        { 
            if(pl.Name == "John Johnson")
            {
                MainWindow.ritter.Margin = new Thickness(MainWindow.ritter.Margin.Left+5, MainWindow.ritter.Margin.Top, MainWindow.ritter.Margin.Right, MainWindow.ritter.Margin.Bottom);
                Thread.Sleep(25);
                DoEvents();
                for(int i = 0; i < 4; i++)
                {
                    MainWindow.ritter.Margin = new Thickness(MainWindow.ritter.Margin.Left -10, MainWindow.ritter.Margin.Top, MainWindow.ritter.Margin.Right, MainWindow.ritter.Margin.Bottom);
                    Thread.Sleep(25);
                    DoEvents();
                    MainWindow.ritter.Margin = new Thickness(MainWindow.ritter.Margin.Left + 10, MainWindow.ritter.Margin.Top, MainWindow.ritter.Margin.Right, MainWindow.ritter.Margin.Bottom);
                    Thread.Sleep(25);
                    DoEvents();
                }
                MainWindow.ritter.Margin = new Thickness(MainWindow.ritter.Margin.Left - 5, MainWindow.ritter.Margin.Top, MainWindow.ritter.Margin.Right, MainWindow.ritter.Margin.Bottom);
                Thread.Sleep(25);
                DoEvents();

            }
            else
            {

            }
        }
        public static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
        }
    }
}
