using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    RequirementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OsMin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OsMax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessorMin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessorMax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemoryMin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemoryMax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageMin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageMax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectXMin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectXMax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraphicsMin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraphicsMax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguagesSupported = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrivacyPolicy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.RequirementId);
                    table.ForeignKey(
                        name: "FK_Requirements_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Author", "Description", "Features", "Genre", "Platform", "Price", "Title" },
                values: new object[] { new Guid("e7b032b3-4c53-4266-8811-3052a75d5d6f"), "Piranha Bytes", "War has been waged across the kingdom of Myrtana. Orcish hordes invaded human territory and the king of the land needed a lot of ore to forge enough weapons, should his army stand against this threat. Whoever breaks the law in these darkest of times is sentenced to serve in the giant penal colony of Khorinis, mining the so much needed ore.The whole area, dubbed \"the Colony\", is surrounded by a magical barrier, a sphere two kilometers diameter, sealing off the penal colony from the outside world. The barrier can be passed from the outside in – but once inside, nobody can escape. The barrier was a double-edged sword - soon the prisoners took the opportunity and started a revolt. The Colony became divided into three rivaling factions and the king was forced to negotiate for his ore, not just demand it.You are thrown through the barrier into this prison. With your back against the wall, you have to survive and form volatile alliances until you can finally escape.", "Single Player", "RPG", "Windows", 10.50m, "Gothic" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Author", "Description", "Features", "Genre", "Platform", "Price", "Title" },
                values: new object[] { new Guid("fcb36fd8-e0df-4221-9a51-b6de63e31bf8"), "Piranha Bytes", "You have torn down the magical barrier and released the prisoners of the Mine Valley. Now the former criminals of the forests and mountains are causing trouble around the capital of Khorinis. The town militia is powerless due to their low amount of force – outside of the town, everyone is helpless against the attacks of the bandits.In the meanwhile, however, Xardas the Magician is preparing you to face a much larger threat: The dragons have been summoned to destroy humanity with their armies. And only the “Eye of Innos”, an ancient divine artifact, can help you stop them...", "Single Player", "RPG", "Windows", 12.99m, "Gothic II" });

            migrationBuilder.InsertData(
                table: "Requirements",
                columns: new[] { "RequirementId", "DirectXMax", "DirectXMin", "GraphicsMax", "GraphicsMin", "LanguagesSupported", "MemoryMax", "MemoryMin", "OsMax", "OsMin", "PrivacyPolicy", "ProcessorMax", "ProcessorMin", "ProductId", "StorageMax", "StorageMin" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "DirectX 7.0", "DirectX 7.0", "32MB 3D Accelerated Graphic Card", "16MB 3D Accelerated Graphic Card", "English, German, Polish, Russian, Spanish(Sub), Italian(Sub), French(Sub)", "192MB RAM", "128MB RAM", "Windows 98/ME/XP/2000", "Windows 98/ME/XP/2000", "© 2017 by THQ Nordic GmbH & Piranha Bytes. Piranha Bytes and related logos are registered trademarks or trademarks of Pluto 13 GmbH, Germany in the U.S. and/or other countries. All other brands, product names and logos are trademarks or registered trademarks of their respective owners. All rights reserved.", "Pentium III 600MHz Processor", "Pentium II 400MHz Processor", new Guid("e7b032b3-4c53-4266-8811-3052a75d5d6f"), "4 GB", "4 GB" });

            migrationBuilder.InsertData(
                table: "Requirements",
                columns: new[] { "RequirementId", "DirectXMax", "DirectXMin", "GraphicsMax", "GraphicsMin", "LanguagesSupported", "MemoryMax", "MemoryMin", "OsMax", "OsMin", "PrivacyPolicy", "ProcessorMax", "ProcessorMin", "ProductId", "StorageMax", "StorageMin" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "DirectX 7.0", "DirectX 7.0", "3D graphics card with 32 MB Ram", "3D graphics card with 32 MB Ram", "English, German, Polish, Russian, Spanish(Sub), Italian(Sub), French(Sub)", "256 MB Ram or higher", "256 MB Ram or higher", "Windows XP/2000/ME/98/Vista", "Windows XP/2000/ME/98/Vista", "© 2017 by THQ Nordic GmbH & Piranha Bytes. Piranha Bytes and related logos are registered trademarks or trademarks of Pluto 13 GmbH, Germany in the U.S. and/or other countries. All other brands, product names and logos are trademarks or registered trademarks of their respective owners. All rights reserved.", "Intel Pentium III 700 MHz", "Intel Pentium III 700 MHz", new Guid("fcb36fd8-e0df-4221-9a51-b6de63e31bf8"), "4 GB", "4 GB" });

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_ProductId",
                table: "Requirements",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
