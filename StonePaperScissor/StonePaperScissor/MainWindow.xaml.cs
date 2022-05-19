//Author : Group 6

using System.Windows;

namespace StonePaperScissor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM vm = new VM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            vm.SetStartVisibility();
        }

        private void EndGame_Click(object sender, RoutedEventArgs e)
        {
            vm.EndGame();
        }

        private void Rock_Click(object sender, RoutedEventArgs e)
        {
            vm.DefaultVisibility();
            UserOptions OptionName = vm.CalculateMove(UserOptions.Rock);
            vm.ToggleVisibility(OptionName);
        }

        private void Paper_Click(object sender, RoutedEventArgs e)
        {
            vm.DefaultVisibility();
            UserOptions OptionName = vm.CalculateMove(UserOptions.Paper);
            vm.ToggleVisibility(OptionName);
        }

        private void Scissor_Click(object sender, RoutedEventArgs e)
        {
            vm.DefaultVisibility();
            UserOptions OptionName = vm.CalculateMove(UserOptions.Scissors);
            vm.ToggleVisibility(OptionName);
        }
    }
}
