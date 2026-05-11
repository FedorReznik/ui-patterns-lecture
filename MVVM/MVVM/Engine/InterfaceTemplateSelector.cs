using System.Windows;
using System.Windows.Controls;

namespace MVVM.Engine;

/// <summary>
/// Allows WPF DataTemplates to be resolved by interface type,
/// preferring the most specific interface first.
/// </summary>
public sealed class InterfaceTemplateSelector : DataTemplateSelector
{
    public override DataTemplate? SelectTemplate(object? item, DependencyObject container)
    {
        if (item == null || container is not FrameworkElement element)
            return base.SelectTemplate(item, container);

        var type = item.GetType();

        // 1. Exact type first (default WPF behavior)
        var template = FindTemplate(type, element);
        if (template != null)
            return template;

        // 2. Cached interfaces ordered from most specific to the least specific
        foreach (var @interface in type.GetInterfaces())
        {
            template = FindTemplate(@interface, element);
            if (template != null)
                return template;
        }

        // 3. Base classes
        var baseType = type.BaseType;
        while (baseType != null)
        {
            template = FindTemplate(baseType, element);
            if (template != null)
                return template;

            baseType = baseType.BaseType;
        }

        return base.SelectTemplate(item, container);
    }

    private static DataTemplate? FindTemplate(Type type, FrameworkElement element)
    {
        var key = new DataTemplateKey(type);

        return element.TryFindResource(key) as DataTemplate
               ?? Application.Current.TryFindResource(key) as DataTemplate;
    }
}