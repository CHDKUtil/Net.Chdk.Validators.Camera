using Microsoft.Extensions.DependencyInjection;
using Net.Chdk.Model.Camera;
using System;

namespace Net.Chdk.Validators.Camera
{
    public static class ServiceCollectionExtensions
    {
        [Obsolete]
        public static IServiceCollection AddCameraValidator(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IValidator<CameraInfo>, CameraValidator>();
        }
    }
}
