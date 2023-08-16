using CommunityToolkit.Mvvm.ComponentModel;
using Gladhen.Services;
using Microsoft.UI.Xaml;
using System;

namespace Gladhen.ViewModels;
public partial class HomeViewModel : ObservableObject
{
    private readonly ICpuService _cpuService;
    private readonly DispatcherTimer _timer;

    public HomeViewModel(ICpuService cpuService)
    {
        _cpuService = cpuService;
        _cpuName = _cpuService.GetCpuName();
        _cpuTemperature = _cpuService.GetTemperature();


        _timer = new DispatcherTimer() {
            Interval = TimeSpan.FromSeconds(2),
        };
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }

    private void Timer_Tick(object sender, object e)
    {
        _cpuService.Update();
        CpuTemperature = _cpuService.GetTemperature();
    }

    [ObservableProperty]
    private string _cpuName;

    [ObservableProperty]
    private string _cpuTemperature;
}
