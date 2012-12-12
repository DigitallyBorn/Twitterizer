using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace TestApplication
{
    public class ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void OnPropertyChanged(Expression<Func<object>> expression)
        {
            string propertyName = PropertyName.For(expression);
            this.PropertyChanged(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    };

}
