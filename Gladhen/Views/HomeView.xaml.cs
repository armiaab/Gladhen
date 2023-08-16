using CommunityToolkit.Mvvm.DependencyInjection;
using Gladhen.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Gladhen.Views;
public sealed partial class HomeView : Page
{
    private readonly HomeViewModel _viewModel;

    public HomeView()
    {
        InitializeComponent();
        _viewModel = Ioc.Default.GetRequiredService<HomeViewModel>();
    }
}
