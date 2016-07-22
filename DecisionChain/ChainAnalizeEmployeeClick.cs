
namespace RAD_Project.DecisionChain
{
    using PRI_Project.Models.BD_Model;

    public class ChainAnalizeEmployeeClick : AnalizeChainEntry
    {
        public ChainAnalizeEmployeeClick(ChainEntry chainItem)
            : base(chainItem)
        {

        }

        protected override string GetName()
        {
            return typeof(Employee).Name;
        }
    }
}
