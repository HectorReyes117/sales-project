using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Http;

namespace Sales.Application.Filters;

public abstract class Filterable<TEntity>
{
    public abstract string[] FullTextSearchColumns();
    public abstract string[] FilterableColumns();
    public virtual string KeyOnFullTextSearch() => "search";
    public virtual string KeyOnPaginator() => "paginator";
    public virtual string KeyOnPerPage() => "per_page";
    public virtual string KeyOnWhereIn() => "where_in";
    public virtual string KeyOnNot() => "not";
    public virtual string KeyOnSortBy() => "sort_by";
    public virtual string KeyOnSortByDesc() => "sort_by_desc";

    public virtual void Authorize(HttpContext context)
    {
        // Implementar lógica de autorización según sea necesario
    }

    public IQueryable<TEntity> Filter(IQueryable<TEntity> query, HttpContext context)
    {
        Authorize(context);
        query = BuildFilterableQuery(query, context);

        var request = context.Request;
        bool paginate = bool.Parse(request.Query[KeyOnPaginator()].FirstOrDefault() ?? "false");
        int perPage = int.Parse(request.Query[KeyOnPerPage()].FirstOrDefault() ?? "15");

        if (paginate)
        {
            // Implementar paginación si es necesario
        }
        else
        {
            // Implementar toma de registros si es necesario
        }

        // Aquí puedes transformar el resultado según sea necesario, por ejemplo, con AutoMapper o manualmente
        return query;
    }

    private IQueryable<TEntity> BuildFilterableQuery(IQueryable<TEntity> query, HttpContext context)
    {
        var request = context.Request;
        
        query = BuildFiltersByFunctions(query, request);
        query = BuildFilterColumnsQuery(query, request);
        query = BuildFullTextSearchQuery(query, request);
        query = BuildWhereInQuery(query, request);
        query = LoadRelationships(query, request);
        query = BuildSortedQuery(query, request);
        query = BuildColumnNotQuery(query, request);

        return query;
    }

    private IQueryable<TEntity> BuildFiltersByFunctions(IQueryable<TEntity> query, HttpRequest request)
    {
        // Implementar lógica similar a Laravel
        return query;
    }

    private IQueryable<TEntity> BuildWhereInQuery(IQueryable<TEntity> query, HttpRequest request)
    {
        // Implementar lógica similar a Laravel
        return query;
    }

    private IQueryable<TEntity> BuildSortedQuery(IQueryable<TEntity> query, HttpRequest request)
    {
        // Implementar lógica similar a Laravel
        return query;
    }

    private IQueryable<TEntity> LoadRelationships(IQueryable<TEntity> query, HttpRequest request)
    {
        // Implementar lógica similar a Laravel
        return query;
    }

    private IQueryable<TEntity> BuildFullTextSearchQuery(IQueryable<TEntity> query, HttpRequest request)
    {
        // Implementar lógica similar a Laravel
        return query;
    }

    private IQueryable<TEntity> BuildFilterColumnsQuery(IQueryable<TEntity> query, HttpRequest request)
    {
        IQueryable<TEntity> result = null!;
        
        foreach (var column in FilterableColumns())
        {
            if (request.Query.ContainsKey(column))
            {
                PropertyInfo? property = typeof(TEntity).GetProperty(column);

                if (property is not null)
                {
                    var parameter = Expression.Parameter(typeof(TEntity), property.Name);
                    var _property = Expression.Property(parameter, property);
                    
                    //Get type of property
                    var targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    
                    //Convert the request value to the property type 
                    ConstantExpression _constant = null;
                    try
                    {
                        var value = Convert.ChangeType(request.Query[column].ToString(), targetType);
                        _constant = Expression.Constant(value, targetType);
                    }
                    catch (InvalidCastException e)
                    {
                        throw new InvalidCastException($"El tipo de dato del parámetro {property.Name} es incorrecto", e);
                    }
                    
                    // If the property type is nullable, convert the property access to the target type
                    Expression comparison;
                    if (property.PropertyType != targetType)
                    {
                        var convertedPropertyAccess = Expression.Convert(_property, targetType);
                        comparison = Expression.Equal(convertedPropertyAccess, _constant);
                    }
                    else
                    {
                        comparison = Expression.Equal(_property, _constant);
                    }
                
                    var predicate = Expression.Lambda<Func<TEntity, bool>>(
                        comparison, parameter
                    );

                    query = query.Where(predicate);
                
                }
            }
        }
        
        return query;
    }

    private IQueryable<TEntity> BuildColumnNotQuery(IQueryable<TEntity> query, HttpRequest request)
    {
        // Implementar lógica similar a Laravel
        return query;
    }
}
