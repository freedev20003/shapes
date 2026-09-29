using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Shapes.Application.Services;
using Shapes.Application.Services.Interfaces;
using Shapes.Domain.Factories;
using Shapes.Domain.Factories.Interfaces;
using Shapes.Domain.Providers;
using Shapes.Domain.Providers.Interfaces;
using Shapes.App.Services;
using Shapes.App.ViewModels;
using Shapes.App.Views;

namespace Shapes.App;

public partial class App : System.Windows.Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var services = new ServiceCollection();
        ConfigureServices(services);

        var serviceProvider = services.BuildServiceProvider();

        var viewModel = serviceProvider.GetRequiredService<MainWindowViewModel>();
        var mainWindow = new MainWindow(viewModel);
        mainWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IShapeFactory, ShapeFactory>();
        services.AddSingleton<IShapeTypeProvider, ShapeTypeProvider>();

        services.AddSingleton<IShapesService, ShapesService>();

        services.AddSingleton<IDialogService, DialogService>();

        services.AddSingleton<MainWindowViewModel>();
    }
}