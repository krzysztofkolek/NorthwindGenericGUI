
namespace RAD_Project.ChartAlgorithm
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAlgorithm<T>
    {
        IAlgorithm<T> SetData(List<T> data);
        Task<List<KeyValuePair<double, string>>> GetResult();
        string GetAlgorithmTitle();
    }
}
