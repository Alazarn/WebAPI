using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class requirement : Migration
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
                values: new object[] { new Guid("75f8b6eb-c15f-42b9-9144-1de81ad70879"), "Piranha Bytes", "War has been waged across the kingdom of Myrtana. Orcish hordes invaded human territory and the king of the land needed a lot of ore to forge enough weapons, should his army stand against this threat. Whoever breaks the law in these darkest of times is sentenced to serve in the giant penal colony of Khorinis, mining the so much needed ore.The whole area, dubbed \"the Colony\", is surrounded by a magical barrier, a sphere two kilometers diameter, sealing off the penal colony from the outside world. The barrier can be passed from the outside in – but once inside, nobody can escape. The barrier was a double-edged sword - soon the prisoners took the opportunity and started a revolt. The Colony became divided into three rivaling factions and the king was forced to negotiate for his ore, not just demand it.You are thrown through the barrier into this prison. With your back against the wall, you have to survive and form volatile alliances until you can finally escape.", "Single Player", "RPG", "Windows", 10.50m, "Gothic" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Author", "Description", "Features", "Genre", "Platform", "Price", "Title" },
                values: new object[] { new Guid("354c0183-c7be-4979-aa80-74a7f5906bbb"), "Piranha Bytes", "You have torn down the magical barrier and released the prisoners of the Mine Valley. Now the former criminals of the forests and mountains are causing trouble around the capital of Khorinis. The town militia is powerless due to their low amount of force – outside of the town, everyone is helpless against the attacks of the bandits.In the meanwhile, however, Xardas the Magician is preparing you to face a much larger threat: The dragons have been summoned to destroy humanity with their armies. And only the “Eye of Innos”, an ancient divine artifact, can help you stop them...", "Single Player", "RPG", "Windows", 12.99m, "Gothic II" });

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_ProductId",
                table: "Requirements",
                column: "ProductId");
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
