using System;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = new Guid("E7B032B3-4C53-4266-8811-3052A75D5D6F"),
                    Title = "Gothic",
                    Author = "Piranha Bytes",
                    Description = "War has been waged across the kingdom of Myrtana. Orcish hordes invaded human territory and the king of the land needed a lot of ore to forge enough weapons, should his army stand against this threat. Whoever breaks the law in these darkest of times is sentenced to serve in the giant penal colony of Khorinis, mining the so much needed ore." +
                    "The whole area, dubbed \"the Colony\", is surrounded by a magical barrier, a sphere two kilometers diameter, sealing off the penal colony from the outside world. The barrier can be passed from the outside in – but once inside, nobody can escape. The barrier was a double-edged sword - soon the prisoners took the opportunity and started a revolt. The Colony became divided into three rivaling factions and the king was forced to negotiate for his ore, not just demand it." +
                    "You are thrown through the barrier into this prison. With your back against the wall, you have to survive and form volatile alliances until you can finally escape.",
                    Genre = "RPG",
                    Price = 10.50m,
                    Features = "Single Player",
                    Platform = "Windows"
                },
                new Product
                {
                    Id = new Guid("FCB36FD8-E0DF-4221-9A51-B6DE63E31BF8"),
                    Title = "Gothic II",
                    Author = "Piranha Bytes",
                    Description = "You have torn down the magical barrier and released the prisoners of the Mine Valley. Now the former criminals of the forests and mountains are causing trouble around the capital of Khorinis. The town militia is powerless due to their low amount of force – outside of the town, everyone is helpless against the attacks of the bandits." +
                    "In the meanwhile, however, Xardas the Magician is preparing you to face a much larger threat: The dragons have been summoned to destroy humanity with their armies. And only the “Eye of Innos”, an ancient divine artifact, can help you stop them...",
                    Genre = "RPG",
                    Price = 12.99m,
                    Features = "Single Player",
                    Platform = "Windows"
                }
                );
        }
    }
}
