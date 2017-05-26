using Net.Chdk.Model.Camera;
using System;
using System.ComponentModel.DataAnnotations;

namespace Net.Chdk.Validators.Camera
{
    sealed class CameraValidator : IValidator<CameraInfo>
    {
        public void Validate(CameraInfo camera, string basePath)
        {
            if (camera == null)
                throw new ArgumentNullException(nameof(camera));

#if METADATA
            Validate(camera.Version);
#endif
            Validate(camera.Base);
            Validate(camera.Canon);
        }

#if METADATA
        private static void Validate(Version version)
        {
            if (version == null)
                throw new ValidationException("Null version");

            if (version.Major < 1 || version.Minor < 0)
                throw new ValidationException("Invalid version");
        }
#endif

        private static void Validate(BaseInfo @base)
        {
            if (@base == null)
                throw new ValidationException("Null base");

            if (string.IsNullOrEmpty(@base.Make))
                throw new ValidationException("Missing make");

            if (string.IsNullOrEmpty(@base.Model))
                throw new ValidationException("Missing model");
        }

        private static void Validate(CanonInfo canon)
        {
            if (canon == null)
                throw new ValidationException("Null canon");

            if (canon.ModelId < 0x100000)
                throw new ValidationException("Invalid modelId");

            if (canon.FirmwareRevision < 0x1000000)
                throw new ValidationException("Invalid firmwareRevision");

            if ((canon.FirmwareRevision & 0xffff) < 0x100)
                throw new ValidationException("Invalid firmwareRevision");
        }
    }
}
