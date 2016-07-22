namespace RAD_Project.UI.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class GenericTool<T>
        where T : class, new()
    {
        protected List<string> _filedsName { get; set; }
        protected String _name { get; set; }

        public GenericTool()
        {
            T t = new T();
            _filedsName = t.GetType().GetProperties().Where(item => item.PropertyType.Name.Equals("String") || item.PropertyType.Name.Equals("Int32")).Select(item => item.Name).ToList();
            _name = t.GetType().Name;
        }
    }
}
