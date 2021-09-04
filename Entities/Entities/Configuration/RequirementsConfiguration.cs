using System;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    class RequirementsConfiguration : IEntityTypeConfiguration<ProductSystemRequirements>
    {
        public void Configure(EntityTypeBuilder<ProductSystemRequirements> builder)
        {
            builder.HasData(
                new ProductSystemRequirements
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    OsMin = "Windows 98/ME/XP/2000",
                    OsMax = "Windows 98/ME/XP/2000",
                    ProcessorMin = "Pentium II 400MHz Processor",
                    ProcessorMax = "Pentium III 600MHz Processor",
                    MemoryMin = "128MB RAM",
                    MemoryMax = "192MB RAM",
                    StorageMin = "4 GB",
                    StorageMax = "4 GB",
                    DirectXMin = "DirectX 7.0",
                    DirectXMax = "DirectX 7.0",
                    GraphicsMin = "16MB 3D Accelerated Graphic Card",
                    GraphicsMax = "32MB 3D Accelerated Graphic Card",
                    LanguagesSupported = "English, German, Polish, Russian, Spanish(Sub), Italian(Sub), French(Sub)",
                    PrivacyPolicy = "© 2017 by THQ Nordic GmbH & Piranha Bytes. Piranha Bytes and related logos are registered trademarks or trademarks of Pluto 13 GmbH, Germany in the U.S. and/or other countries. All other brands, product names and logos are trademarks or registered trademarks of their respective owners. All rights reserved.",
                    ProductId = new Guid("E7B032B3-4C53-4266-8811-3052A75D5D6F")
                },
                new ProductSystemRequirements
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    OsMin = "Windows XP/2000/ME/98/Vista",
                    OsMax = "Windows XP/2000/ME/98/Vista",
                    ProcessorMin = "Intel Pentium III 700 MHz",
                    ProcessorMax = "Intel Pentium III 700 MHz",
                    MemoryMin = "256 MB Ram or higher",
                    MemoryMax = "256 MB Ram or higher",
                    StorageMin = "4 GB",
                    StorageMax = "4 GB",
                    DirectXMin = "DirectX 7.0",
                    DirectXMax = "DirectX 7.0",
                    GraphicsMin = "3D graphics card with 32 MB Ram",
                    GraphicsMax = "3D graphics card with 32 MB Ram",
                    LanguagesSupported = "English, German, Polish, Russian, Spanish(Sub), Italian(Sub), French(Sub)",
                    PrivacyPolicy = "© 2017 by THQ Nordic GmbH & Piranha Bytes. Piranha Bytes and related logos are registered trademarks or trademarks of Pluto 13 GmbH, Germany in the U.S. and/or other countries. All other brands, product names and logos are trademarks or registered trademarks of their respective owners. All rights reserved.",
                    ProductId = new Guid("FCB36FD8-E0DF-4221-9A51-B6DE63E31BF8")
                }
                );
        }
    }
}
