using Gladhen.Views;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Linq;

namespace Gladhen;
public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Navigation.SelectedItem = Navigation.MenuItems.ElementAt(0);
        Navigation.Content = new HomeView();
    }

    private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        switch (sender.MenuItems.IndexOf(args.InvokedItemContainer))
        {
            case 0:
                sender.Content = new HomeView();
                break;
        }
    }
}
