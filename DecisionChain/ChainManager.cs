

namespace RAD_Project.DecisionChain
{

    public static class ChainManager
    {
        private static ChainEntry _chainitem { get; set; }

        static ChainManager()
        {
            _chainitem =
                new ChainAnalizeEmployeeClick(
                new ChainAnalizeCustomerClick(
                new ChainAnalizeProductClick(null)));
        }

        public static bool Start(string chainInputCondition)
        {
            if (string.Empty.Equals(chainInputCondition))
                return false;
            return _chainitem.Next(chainInputCondition);
        }
    }
}
