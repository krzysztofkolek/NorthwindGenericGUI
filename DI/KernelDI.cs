namespace RAD_Project.DI
{
    using DB_Model.DI;
    using DB_Repository.DI;
    using Ninject;
    using Ninject.Modules;

    static class KernelDI
    {
        public static StandardKernel Kernel { get; set; }
        static KernelDI()
        {
            Kernel = new StandardKernel(
                         new NinjectSettings()
                         {
                             InjectNonPublic = true,
                             InjectParentPrivateProperties = true
                         },
                         new INinjectModule[]
                         {
                             new MainUIModule(), 
                             new UIToolsModule(),
                             new DBModelModule(),
                             new AlgorithmModule(),
                             new RepositoryDI()
                         });
        }
    }
}
