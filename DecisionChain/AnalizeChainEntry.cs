
namespace RAD_Project.DecisionChain
{
    public abstract class AnalizeChainEntry : ChainEntry
    {
        protected string Prefix { get { return ""; } }

        public AnalizeChainEntry(ChainEntry chainItem)
            : base(chainItem)
        { }

        protected abstract string GetName();

        protected virtual bool AnalizeChainEntryCondition(string chainInputCondition)
        {
            if (string.Format("{0}{1}", Prefix, GetName()).Equals(chainInputCondition))
                return true;
            return false;
        }

        protected override bool ChainEntryCondition(string chainInputCondition)
        {
            return AnalizeChainEntryCondition(chainInputCondition);
        }
    }
}
