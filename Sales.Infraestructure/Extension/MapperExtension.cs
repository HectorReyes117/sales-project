using System.Collections;
using System.Reflection;

namespace Sales.Infraestructure.Extension;

public static class MapperExtension
{
   
    
    public static List<TDestination> MapToList<TSource,TDestination>(this List<TSource> source) where TDestination : new()
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        List<TDestination> destinationList = new List<TDestination>();

        foreach (var item in source)
        {
            if (item != null)
            {
                destinationList.Add(item.MapTo<TDestination>());
            }
        }

        return destinationList;
    }

    public static ICollection<TDestination> MapToCollection<TSource, TDestination>(this ICollection<TSource> source) where TDestination : new() 
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        ICollection<TDestination> destinationCollection = new List<TDestination>();

        foreach (var item in source)
        {
            if (item != null)
            {
                destinationCollection.Add(item.MapTo<TDestination>());
            }
        }

        return destinationCollection;
    }

    public static IEnumerable<TDestination> MapToEnumerable<TSource, TDestination>(this IEnumerable<TSource> source) where TDestination : new()
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        List<TDestination> destinationEnumerable = new List<TDestination>();

        foreach (var item in source)
        {
            if (item != null)
            {
                destinationEnumerable.Add(item.MapTo<TDestination>());
            }
        }

        return destinationEnumerable;
    }
    
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
    
    
   
