namespace P07_StudentClass
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PropertyChangedEventArgs
    {
        public PropertyChangedEventArgs(string propertyName, string oldValue, string newValue)
        {
            this.PropertyName = propertyName;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }

        public string PropertyName { get; }

        public string OldValue { get; }

        public string NewValue { get; }
    }
}