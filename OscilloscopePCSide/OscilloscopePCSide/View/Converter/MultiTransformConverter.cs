using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace OscilloscopePCSide.View.Converter
{
    public class MultiTransformConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Transform renderTransform = new TransformGroup
            {
                Children = new TransformCollection()
                {
                    new ScaleTransform(1, (double)values[0]),
                    new TranslateTransform(0, (double)values[1])
                }
            };
            return renderTransform;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
