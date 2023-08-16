using LibreHardwareMonitor.Hardware;
using System.Linq;

namespace Gladhen.Services;
public class CpuService : ICpuService
{
    private readonly Computer _computer;
    private readonly IHardware _hardware;

    public CpuService()
    {
        _computer = new Computer
        {
            IsCpuEnabled = true
        };
        _computer.Open();

        _hardware = _computer.Hardware.FirstOrDefault(h => h.HardwareType == HardwareType.Cpu);
    }

    public void Update()
    {
        _hardware.Update();
    }

    public string GetTemperature()
    {
        var temp = _hardware.Sensors.FirstOrDefault(s => s.SensorType == SensorType.Temperature).Value;
        return temp.HasValue ? temp.Value.ToString("N2") : "0";
    }

    public string GetCpuName()
    {
        return _computer.Hardware.FirstOrDefault(h => h.HardwareType == HardwareType.Cpu).Name;
    }

    public void Dispose()
    {
        _computer.Close();
    }
}
