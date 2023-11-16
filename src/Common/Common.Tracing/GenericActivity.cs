using System.Diagnostics;

namespace Common.Tracing;

public static class GenericActivity
{
    public static string Name = nameof(GenericActivity);
    public static ActivitySource Instance = new(Name);
}
