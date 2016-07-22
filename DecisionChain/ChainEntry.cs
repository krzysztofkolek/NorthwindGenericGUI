
namespace RAD_Project.DecisionChain
{

    using System;

    public abstract class ChainEntry
    {
        public ChainEntry ChainItem;

        protected abstract bool ChainEntryCondition(String chainInputCondition);

        public ChainEntry(ChainEntry chainItem)
        {
            ChainItem = chainItem;
        }

        public bool Next(String chainInputCondition)
        {
            if (ChainEntryCondition(chainInputCondition))
                return true;
            if (ChainItem != null)
                return ChainItem.Next(chainInputCondition);
            return false;
        }
    }
}
