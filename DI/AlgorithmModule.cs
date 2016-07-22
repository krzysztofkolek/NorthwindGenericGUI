

namespace RAD_Project.DI
{
    using Ninject.Modules;
    using RAD_Project.Models.BD_Model;
    using RAD_Project.ChartAlgorithm;

    public class AlgorithmModule : NinjectModule
    {
        public AlgorithmModule()
        {
        }
        public override void Load()
        {
            Bind(typeof(IAlgorithm<Employee>)).To(typeof(EmployeeAlg<Employee>));
            Bind(typeof(IAlgorithm<Customer>)).To(typeof(CustomerAlg<Customer>));
            Bind(typeof(IAlgorithm<Product>)).To(typeof(ProductAlg<Product>));
        }
    }
}
