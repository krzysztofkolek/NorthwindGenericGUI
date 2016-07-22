
namespace RAD_Project.ChartAlgorithm
{
    using PRI_Project.Models.BD_Model;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    class CustomerAlg<T> : IAlgorithm<T>
        where T : Customer, new()
    {
        private List<T> _data;
        public IAlgorithm<T> SetData(System.Collections.Generic.List<T> data)
        {
            _data = data;
            return this;
        }

        public async Task<List<KeyValuePair<double, string>>> GetResult()
        {
            List<KeyValuePair<double, string>> ret = new List<KeyValuePair<double, string>>();
            Dictionary<string, double> dataContainer = new Dictionary<string, double>();
            foreach (T itemInCollection in _data)
            {
                if (!dataContainer.Keys.Contains(itemInCollection.Country))
                {
                    dataContainer.Add(itemInCollection.Country, 1);
                }
                else
                {
                    dataContainer[itemInCollection.Country] += 1;
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
            return "Customers by country";
        }
    }
}
