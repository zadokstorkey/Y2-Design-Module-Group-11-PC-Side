using OscilloscopePCSide.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OscilloscopePCSide.View.Utils
{
    public class DocumentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DocumentTemplate
        {
            get;
            set;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ITraceTabViewModel)
            {
                return DocumentTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
