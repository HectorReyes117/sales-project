using System.Reflection;

namespace Sales.Infraestructure.Extension;

public static class MapperExtension
{
    public static TDestination MapTo<TDestination>(this object source) where TDestination : new()
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        TDestination destination = new TDestination();

        var sourceProperties = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var destinationProperties = typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var sourceProperty in sourceProperties)
        {
            var destinationProperty = destinationProperties.FirstOrDefault(dp => dp.Name == sourceProperty.Name && dp.PropertyType == sourceProperty.PropertyType);
            
            if (destinationProperty != null && destinationProperty.CanWrite)
            {
                destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
            }
        }

        return destination;
    }
}