using System.Collections.Generic;

namespace ComputeService.v1.Interfaces
{
    public interface IRandom<out T>
    {
        T Generate();
        IEnumerable<T> Generate(int count);
    }
}
