namespace RAD_Project.UI.Tools
{

    public interface ITextBoxFromModel<T>
     where T : class, new()
    {
        System.Windows.Forms.GroupBox GetFormatedOutput();
        System.Collections.Generic.List<System.Windows.Forms.TextBox> GetTextBoxes();
        ITextBoxFromModel<T> SetItem(T item);
        ITextBoxFromModel<T> SetReadOnly(bool isReadOnly);
    }
}
