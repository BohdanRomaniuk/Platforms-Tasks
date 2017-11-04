using System.Windows;

namespace WPF_Hexagones
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
			DataContext = new MainViewModel();
        }
    }
}
