using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using MiniRepro.ViewModels;
using MiniRepro.Views;

namespace MiniRepro;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow { DataContext = new MainWindowViewModel() };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        var validators = BindingPlugins.DataValidators;
        var pluginsToRemove = validators.OfType<DataAnnotationsValidationPlugin>().ToList();
        foreach (var plugin in pluginsToRemove)
            validators.Remove(plugin);
    }
}
