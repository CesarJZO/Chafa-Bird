using System;
using Range = Utilities.Range;

namespace Core
{
    public interface IHasProgress
    {
        event Action<float> ProgressUpdated;

        float ProgressNormalized { get; }

        Range ProgressRange { get; }
    }
}
