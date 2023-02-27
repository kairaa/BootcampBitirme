using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mvc.Migrations
{
    /// <inheritdoc />
    public partial class NewColumnAddedForList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "ShoppingList",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "ShoppingList");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42cb5de4-3d2e-438d-bbf9-aa770d5f2ed1", "AQAAAAIAAYagAAAAEFa+hFs1uaG79mPojoZ//Fg8Dsg8qHPMjD4Aeq9doQPRdzEmxyDgiauRPc2MzIhI/g==", "3e058411-3f72-4d5a-87b5-542734b2a9c2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f82fff83-e366-42a6-85a6-5cc40aff3b5f", "AQAAAAIAAYagAAAAEDJlpyIOTgEFDvRhXjSUAwhVPbZOa3sn9XeCJ7/RnULv7+L1ut+yuCm90Ja052IN4A==", "5b566006-b1ba-496f-92a6-832de25307f5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9eb4590-d9ac-4904-9904-aebf5b3d742d", "AQAAAAIAAYagAAAAENrSPsuKsdgAaeqVBFdRr0aHNet2PrDfx0wNKXM6RlubJ6mS0iDy5INP4/nudmkkLA==", "f45e6b47-6443-4788-aa4c-affac6c707c9" });
        }
    }
}
