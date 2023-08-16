using CommunityToolkit.Mvvm.DependencyInjection;
using Gladhen.Services;
using Gladhen.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;

namespace Gladhen;
public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    private Window _window;

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        Ioc.Default.ConfigureServices(ConfigureServices());
        _window = new MainWindow();
        _window.Closed += ClosedWindow;
        _window.Activate();
    }

    private void ClosedWindow(object sender, WindowEventArgs args)
    {
        Ioc.Default.GetRequiredService<CpuService>().Dispose();
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<ICpuService, CpuService>();
        services.AddTransient<HomeViewModel>();

        return services.BuildServiceProvider();
    }
}
