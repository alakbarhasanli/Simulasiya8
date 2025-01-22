using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class tables3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DoctorImageUrl",
                table: "treatments",
                newName: "TreatmentImageUrl");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3e3b4e5-9562-498a-b821-ba1cde7aae8d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d263b8e-3184-4b0e-acd5-6f7343ae298d", "AQAAAAIAAYagAAAAEByx/jpEn2u8PS3nmaRpVhJOga1A68fhqIIstjfhWMqgcVfL5Kuut6/BBY5y4E06jg==", "72475e68-112e-48a0-b9ef-417314787986" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TreatmentImageUrl",
                table: "treatments",
                newName: "DoctorImageUrl");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3e3b4e5-9562-498a-b821-ba1cde7aae8d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "975300cd-642c-44ac-b080-5e3a1f6e0840", "AQAAAAIAAYagAAAAEJsCSwBwApB7PadKMBspPuWuv0YGW1+r64+nGb7sAnSwBI1h8J/NIdljCv9kRLsLKw==", "c8e7cace-aef5-4d12-94f1-e8ccdc4e6334" });
        }
    }
}
