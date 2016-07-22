
namespace RAD_Project.DecisionChain
{
    using RAD_Project.Models.BD_Model;

    public class ChainAnalizeCustomerClick : AnalizeChainEntry
    {
        public ChainAnalizeCustomerClick(ChainEntry chainItem)
            : base(chainItem)
        { }

        protected override string GetName()
        {
            return typeof(Customer).Name;
        }
    }
}
