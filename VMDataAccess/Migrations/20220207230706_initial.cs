using Microsoft.EntityFrameworkCore.Migrations;

namespace VMDataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authorities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BrandId = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorityId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthRoles_Authorities_AuthorityId",
                        column: x => x.AuthorityId,
                        principalTable: "Authorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModelId = table.Column<long>(type: "bigint", nullable: false),
                    ColorId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authorities",
                columns: new[] { "Id", "Active", "Name" },
                values: new object[,]
                {
                    { 1L, true, "Vehicle Insert Authority" },
                    { 2L, true, "Vehicle Update Authority" },
                    { 3L, true, "Vehicle Delete Authority" },
                    { 4L, true, "Vehicle List Authority" },
                    { 5L, true, "Brand List Authority" },
                    { 6L, true, "Model List Authority" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Active", "Name" },
                values: new object[,]
                {
                    { 1L, true, "Bmw" },
                    { 2L, true, "Toyota" },
                    { 3L, true, "Fiat" },
                    { 4L, true, "Opel" },
                    { 5L, true, "Audi" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Active", "Name" },
                values: new object[,]
                {
                    { 5L, true, "Space Grey" },
                    { 4L, true, "Black" },
                    { 2L, true, "Red" },
                    { 1L, true, "White" },
                    { 3L, true, "Night Blue" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Active", "Name" },
                values: new object[,]
                {
                    { 1L, true, "System Administrator" },
                    { 2L, true, "Vehicle Administrator" },
                    { 3L, true, "Brand Administrator" },
                    { 4L, true, "Model Administrator" },
                    { 5L, true, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "EMail", "Name", "Password" },
                values: new object[,]
                {
                    { 4L, true, "sven.ottlieb@test.com", "Sven Ottlieb", "1234" },
                    { 1L, true, "okankaan.cetinkaya@gmail.com", "Okan Kaan Cetinkaya", "1234" },
                    { 2L, true, "maria.anders@test.com", "Maria Anders", "1234" },
                    { 3L, true, "antonio.moreno@test.com", "Antonio Moreno Taquería", "1234" },
                    { 5L, true, "carine.schmitt@test.com", "Carine Schmitt", "1234" }
                });

            migrationBuilder.InsertData(
                table: "AuthRoles",
                columns: new[] { "Id", "Active", "AuthorityId", "RoleId" },
                values: new object[,]
                {
                    { 8L, true, 2L, 2L },
                    { 15L, true, 6L, 5L },
                    { 14L, true, 5L, 5L },
                    { 13L, true, 4L, 5L },
                    { 12L, true, 6L, 4L },
                    { 1L, true, 1L, 1L },
                    { 2L, true, 2L, 1L },
                    { 3L, true, 3L, 1L },
                    { 4L, true, 4L, 1L },
                    { 5L, true, 5L, 1L },
                    { 6L, true, 6L, 1L },
                    { 7L, true, 1L, 2L },
                    { 11L, true, 5L, 3L },
                    { 9L, true, 3L, 2L },
                    { 10L, true, 4L, 2L }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Active", "BrandId", "Name" },
                values: new object[,]
                {
                    { 3L, true, 1L, "x5" },
                    { 4L, true, 4L, "Corsa" },
                    { 5L, true, 2L, "Corolla" },
                    { 2L, true, 2L, "Rav 4" },
                    { 1L, true, 2L, "Yaris" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Active", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1L, true, 1L, 1L },
                    { 2L, true, 2L, 2L },
                    { 3L, true, 3L, 3L },
                    { 4L, true, 4L, 4L },
                    { 5L, true, 5L, 5L }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Active", "ColorId", "ModelId", "Price", "UserId" },
                values: new object[,]
                {
                    { 3L, true, 4L, 3L, 230000m, 5L },
                    { 2L, true, 5L, 1L, 150000m, 1L },
                    { 1L, true, 2L, 2L, 200000m, 1L },
                    { 5L, true, 2L, 2L, 200000m, 3L },
                    { 6L, true, 3L, 5L, 300000m, 3L },
                    { 4L, true, 2L, 4L, 500000m, 4L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthRoles_AuthorityId",
                table: "AuthRoles",
                column: "AuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthRoles_RoleId",
                table: "AuthRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ColorId",
                table: "Vehicles",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthRoles");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Authorities");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
