using System;

namespace Gladhen.Services;

public interface ICpuService : IDisposable
{
    string GetCpuName();
    string GetTemperature();
    void Update();
}