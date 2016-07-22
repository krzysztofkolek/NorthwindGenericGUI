namespace RAD_Project.DI
{
    using Ninject.Modules;

    class MainUIModule : NinjectModule
    {

        public MainUIModule()
        {
        }

        public override void Load()
        {
            Bind<MainForm>().ToSelf();
        }
    }
}
