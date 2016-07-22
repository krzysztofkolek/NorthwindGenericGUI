﻿
namespace RAD_Project.DecisionChain
{
    using PRI_Project.Models.BD_Model;

    public class ChainAnalizeProductClick  : AnalizeChainEntry
    {
        public ChainAnalizeProductClick(ChainEntry chainItem)
            : base(chainItem)
        {

        }

        protected override string GetName()
        {
            return typeof(Product).Name;
        }
    }
}
