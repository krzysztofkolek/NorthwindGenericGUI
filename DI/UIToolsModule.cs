namespace RAD_Project.DI
{
    using Ninject.Modules;
    using RAD_Project.UI;
    using RAD_Project.UI.TelerikTools;
    using RAD_Project.UI.Tools;

    public class UIToolsModule : NinjectModule
    {


        public UIToolsModule()
        {
        }

        public override void Load()
        {
            Bind(typeof(ITextBoxFromModel<>)).To(typeof(TextBoxFromModel<>));
            Bind(typeof(TextBoxFormFromModel<>)).To(typeof(TextBoxFormFromModel<>));
            //Bind(typeof(GenericGridView<>)).To(typeof(GenericGridView<>));
            //Bind(typeof(GenericTeeChart<>)).To(typeof(GenericTeeChart<>));
        }
    }
}
