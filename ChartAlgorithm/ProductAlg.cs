
namespace RAD_Project.ChartAlgorithm
{
    using RAD_Project.Models.BD_Model;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class ProductAlg<T> : IAlgorithm<T>
        where T : Product, new()
    {
        private List<T> _data { get; set; }

        public IAlgorithm<T> SetData(List<T> data)
        {
            _data = data;
            return this;
        }

        async public Task<List<KeyValuePair<double, string>>> GetResult()
        {
            List<KeyValuePair<double, string>> ret = new List<KeyValuePair<double, string>>();
            Dictionary<string, double> dataContainer = new Dictionary<string, double>();
            foreach (T itemInCollection in _data)
            {
                if (!dataContainer.Keys.Contains(itemInCollection.ProductName))
                {
                    double count = 0;
                    if (itemInCollection.UnitsInStock.HasValue)
                        count = itemInCollection.UnitsInStock.Value;
                    dataContainer.Add(itemInCollection.ProductName, count);
                }
                else
                {
                    double count = 0;
                    if (itemInCollection.UnitsInStock.HasValue)
                        count = itemInCollection.UnitsInStock.Value;
                    dataContainer[itemInCollection.ProductName] += count;
                }
            }
            foreach (var dictionaryentry in dataContainer)
            {
                ret.Add(new KeyValuePair<double, string>(dictionaryentry.Value, dictionaryentry.Key));
            }
            return ret;
        }

        public string GetAlgorithmTitle()
        {
            return "Products by count";
        }
    }
}
