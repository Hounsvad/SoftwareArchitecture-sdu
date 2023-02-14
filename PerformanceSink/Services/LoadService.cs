namespace PerformanceSink.Services;

public class LoadService : ILoadService
{
    public async Task<decimal> GetPiPrecision(long iterations)
    {
        if (iterations > 1700)
            throw new ArgumentOutOfRangeException(nameof(iterations), iterations,
                "The number of iterations must be less than 1000.");
        return 2 * await InternalGetPiPrecision(1, iterations);
    }

    private async Task<decimal> InternalGetPiPrecision(decimal input, long iterations, long count = 0)
    {
        if (count >= iterations) return (input);
        return 1 + input / (2*input+1) * await InternalGetPiPrecision(input+1, iterations, count + 1);
    }
}
