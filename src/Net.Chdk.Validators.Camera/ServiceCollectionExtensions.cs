using Microsoft.Extensions.DependencyInjection;
using Net.Chdk.Model.Camera;

namespace Net.Chdk.Validators.Camera
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCameraValidator(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IValidator<CameraInfo>, CameraValidator>();
        }
    }
}
