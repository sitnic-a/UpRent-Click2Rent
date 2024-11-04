using System.Windows;

namespace Click2Rent.WPFClient.Views
{
    /// <summary>
    /// Interaction logic for UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
            InitializeComponent();
            dg_ListaKorisnika.Items.Refresh();
        }
    }
}
