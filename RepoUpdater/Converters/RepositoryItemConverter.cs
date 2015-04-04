using RepoUpdater.Model.Abstraction;
using RepoUpdater.Model.ModelView;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace RepoUpdater.Converters
{
    class RepositoryItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return value;

            var repositories = value as IEnumerable<RepositoryBase>;
            if (repositories == null)
                return value;

            return repositories.Select(item => new RepositoryItem()
            {
                Path = item.RepositoryPath,
                RepositoryType = item.Name
            });
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
