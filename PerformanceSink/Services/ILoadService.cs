namespace PerformanceSink.Services;

public interface ILoadService
{
    Task<decimal> GetPiPrecision(long iterations);
}
