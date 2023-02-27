using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mvc.Migrations
{
    /// <inheritdoc />
    public partial class NewColumnAddedForListAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "GoingToShopping",
                table: "ShoppingList",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd3dd11a-b7d2-4ecc-96b2-49db3cc8ce3b", "AQAAAAIAAYagAAAAEKE50zSBDOYrmdxTfR11ppbzHKeSTEJMHQ1stHne3Du+HPm/kytVrvGL9e1Vh8v2qQ==", "43b1492b-31a1-4cf6-b055-d583b8f70a86" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "633016df-3165-481c-a11f-5273e930202b", "AQAAAAIAAYagAAAAEO5+uulKgKow+mS9DQXOVmqRDcJefcTlGwswypU67pz7JECbf8UJpCpcQL61KsA4fg==", "a03c1276-0c6e-4f75-ae71-abf812b4907d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d6687c2-2db0-4fd5-b372-67d5d3dbcc81", "AQAAAAIAAYagAAAAECpzU3EyGOF9ufRQuAAS5w2regS28MI9yKJ1UOv9KS4/rDR7lnxVU7bZoflJqbAYZQ==", "1e0378bf-4f9d-4987-b0e4-081ca827cf1c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoingToShopping",
                table: "ShoppingList");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f16639a3-ba92-480d-94a1-e47a5b31bcf1", "AQAAAAIAAYagAAAAEKdJisF3OZY1ardsmTrF0y17Iw0+7jLOnXWF1NVYZZ/d07Kt8/DteZFOynfrJdSr/w==", "add29406-1030-48fe-a74b-ba42865e8928" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e1ca0c4-35af-4fad-a247-f61e3c8c4286", "AQAAAAIAAYagAAAAEAY8WpKwMaaMfUw7nmWcj1sUXJJh7MiQKOHRxsRSaJTTlzMVW1/A/GWTJ9PnlzveHA==", "1585fd6c-d98b-47bc-bab7-2875e32f0396" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "719d6621-c2b6-410e-a721-c7e56b6a0a46", "AQAAAAIAAYagAAAAEGtF8OOCDqzFWuIw7zH9nOOSg9lKSX6ajn/1TaZLlsA8EgLtGpuzMyzTG1+mNm5PpQ==", "b3fb0ce6-6190-4c01-a228-acd6376c568f" });
        }
    }
}
