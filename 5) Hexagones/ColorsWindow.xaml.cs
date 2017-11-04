using System.Windows;
using System.Windows.Media;

namespace WPF_Hexagones
{
    public partial class ColorsWindow : Window
    {
        public ColorsWindow(MainViewModel mainViewModel)
        {
			InitializeComponent();
			DataContext = mainViewModel;
		}
	}
}
