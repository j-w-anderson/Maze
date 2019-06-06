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

namespace Maze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GameSession gameSession;
        public MainWindow()
        {
            InitializeComponent();
            gameSession = new GameSession();

            DataContext = gameSession;

        }

        private void NailSlider_Click(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt16((sender as Button).Tag);
            gameSession.MoveNail(index);
        }

        private void Slider_Click(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt16((sender as Button).Tag);
            gameSession.MoveSlider(index);
        }
    }
}
