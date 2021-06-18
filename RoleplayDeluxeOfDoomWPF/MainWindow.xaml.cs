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

namespace RoleplayDeluxeOfDoomWPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player player;
        Player enemy;
        public static Image ritter;
        public static Image elDiablo;
        public static ProgressBar playerPbar;
        public static TextBlock playertb;
        public MainWindow()
        {
            InitializeComponent();
            playerPbar = pbar_Player;
            playertb = tb_HealthPlayer;
            elDiablo = pb_Enemy;
            player = new Player("John Johnson", 500, new List<Attack>()
            {
                new Attack("Faustschlag",70,95),
                new Attack("Fliesentischpunch",95,85),
                new Attack("Aus der Leitung-Werfer",110,70),
                new Attack("Ritterschlag",150,50)
            }) ;
            enemy = new Player("El Diablo de Velocista ", 750, new List<Attack>() {
                new Attack("Knöpfchendrücken", 55,100),
                new Attack("Ansage",77,70),
                new Attack("Verwirren",100,50),
                new Attack("Busflucht",250,25)
            });

            pbar_Player.Maximum = player.HP;
            pbar_Player.Value = player.HP;
            Helper.Methods.ChangeProgressbar(player, pbar_Player, tb_HealthPlayer, 0);
            pbar_Enemy.Maximum = enemy.HP;
            pbar_Enemy.Value = enemy.HP;
            Helper.Methods.ChangeProgressbar(enemy, pbar_Enemy, tb_HealthEnemy, 0);
            ritter = pb_Player;

        }

        private void btn_pl_Attack1_Click(object sender, RoutedEventArgs e) => Helper.Methods.UseAttack(player, enemy,tb_Log, 0, pbar_Enemy, tb_HealthEnemy);  
        private void btn_pl_Attack2_Click(object sender, RoutedEventArgs e) => Helper.Methods.UseAttack(player, enemy, tb_Log, 1, pbar_Enemy, tb_HealthEnemy);
        private void btn_pl_Attack3_Click(object sender, RoutedEventArgs e) => Helper.Methods.UseAttack(player, enemy, tb_Log, 2, pbar_Enemy, tb_HealthEnemy);
        private void btn_pl_Attack4_Click(object sender, RoutedEventArgs e) => Helper.Methods.UseAttack(player, enemy, tb_Log,3, pbar_Enemy, tb_HealthEnemy);

    }
}
