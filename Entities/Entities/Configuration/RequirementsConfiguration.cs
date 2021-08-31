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
                    Id = Guid.NewGuid(),
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
                    ProductId = new Guid("75f8b6eb-c15f-42b9-9144-1de81ad70879")
                },
                new ProductSystemRequirements
                {
                    Id = Guid.NewGuid(),
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
                    ProductId = new Guid("354c0183-c7be-4979-aa80-74a7f5906bbb")
                }
                );
        }
    }
}
