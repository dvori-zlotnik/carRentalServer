using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dal.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    code = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cities__357D4CF8EA54174C", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    code = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__companie__357D4CF8F74A3A71", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "drive_type",
                columns: table => new
                {
                    code = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__drive_ty__357D4CF8BFEFF345", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "type_vehicles",
                columns: table => new
                {
                    code = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__type_veh__357D4CF845930437", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    phone = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    password = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    num_credit_card = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    validity = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    cvv = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    is_manager = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__3213E83F0718FDE4", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    code = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code_company = table.Column<short>(type: "smallint", nullable: false),
                    model = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    drive_type = table.Column<short>(type: "smallint", nullable: true),
                    type_vehicles = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__models__357D4CF8AEFD1D17", x => x.code);
                    table.ForeignKey(
                        name: "FK__models__code_com__4316F928",
                        column: x => x.code_company,
                        principalTable: "companies",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK__models__drive_ty__440B1D61",
                        column: x => x.drive_type,
                        principalTable: "drive_type",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK__models__type_veh__44FF419A",
                        column: x => x.type_vehicles,
                        principalTable: "type_vehicles",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    code = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    license_plate = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    number_of_seats = table.Column<short>(type: "smallint", nullable: true),
                    gear = table.Column<bool>(type: "bit", nullable: true),
                    image = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    year = table.Column<short>(type: "smallint", nullable: true),
                    available = table.Column<bool>(type: "bit", nullable: true),
                    code_model = table.Column<short>(type: "smallint", nullable: true),
                    city = table.Column<short>(type: "smallint", nullable: true),
                    price_per_hour = table.Column<short>(type: "smallint", nullable: true),
                    consumption_per_km = table.Column<short>(type: "smallint", nullable: true),
                    Balance_in_liters = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cars__357D4CF825B9563A", x => x.code);
                    table.ForeignKey(
                        name: "FK__cars__city__48CFD27E",
                        column: x => x.city,
                        principalTable: "cities",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK__cars__code_model__47DBAE45",
                        column: x => x.code_model,
                        principalTable: "models",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "lendings",
                columns: table => new
                {
                    code = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    hour = table.Column<short>(type: "smallint", nullable: true),
                    CodeCar = table.Column<short>(type: "smallint", nullable: true),
                    CodeCarNavigationCode = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lendings__357D4CF84F2A93EC", x => x.code);
                    table.ForeignKey(
                        name: "FK__lendings__id_use__4D94879B",
                        column: x => x.id_user,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_lendings_cars_CodeCarNavigationCode",
                        column: x => x.CodeCarNavigationCode,
                        principalTable: "cars",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "restitutions",
                columns: table => new
                {
                    code = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code_lending = table.Column<short>(type: "smallint", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    hour = table.Column<short>(type: "smallint", nullable: true),
                    balance = table.Column<short>(type: "smallint", nullable: true),
                    total_payable = table.Column<int>(type: "int", nullable: true),
                    paid = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__restitut__357D4CF802D1B0CC", x => x.code);
                    table.ForeignKey(
                        name: "FK__restituti__code___5070F446",
                        column: x => x.code_lending,
                        principalTable: "lendings",
                        principalColumn: "code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_city",
                table: "cars",
                column: "city");

            migrationBuilder.CreateIndex(
                name: "IX_cars_code_model",
                table: "cars",
                column: "code_model");

            migrationBuilder.CreateIndex(
                name: "UQ__cities__72E12F1B5F613DBC",
                table: "cities",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__companie__72E12F1BF1CBF38F",
                table: "companies",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__drive_ty__489B0D97B128B107",
                table: "drive_type",
                column: "description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_lendings_CodeCarNavigationCode",
                table: "lendings",
                column: "CodeCarNavigationCode");

            migrationBuilder.CreateIndex(
                name: "IX_lendings_id_user",
                table: "lendings",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_models_code_company",
                table: "models",
                column: "code_company");

            migrationBuilder.CreateIndex(
                name: "IX_models_drive_type",
                table: "models",
                column: "drive_type");

            migrationBuilder.CreateIndex(
                name: "IX_models_type_vehicles",
                table: "models",
                column: "type_vehicles");

            migrationBuilder.CreateIndex(
                name: "IX_restitutions_code_lending",
                table: "restitutions",
                column: "code_lending");

            migrationBuilder.CreateIndex(
                name: "UQ__type_veh__489B0D9706306BBA",
                table: "type_vehicles",
                column: "description",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "restitutions");

            migrationBuilder.DropTable(
                name: "lendings");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "models");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "drive_type");

            migrationBuilder.DropTable(
                name: "type_vehicles");
        }
    }
}
