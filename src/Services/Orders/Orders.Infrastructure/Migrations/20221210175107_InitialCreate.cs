using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPriceAmount = table.Column<decimal>(name: "TotalPrice_Amount", type: "decimal(18,2)", nullable: false),
                    TotalPriceCurrencyName = table.Column<string>(name: "TotalPrice_Currency_Name", type: "nvarchar(max)", nullable: false),
                    TotalPriceCurrencyId = table.Column<int>(name: "TotalPrice_Currency_Id", type: "int", nullable: false),
                    BillingAddressFirstName = table.Column<string>(name: "BillingAddress_FirstName", type: "nvarchar(max)", nullable: false),
                    BillingAddressLastName = table.Column<string>(name: "BillingAddress_LastName", type: "nvarchar(max)", nullable: false),
                    BillingAddressEmailAddress = table.Column<string>(name: "BillingAddress_EmailAddress", type: "nvarchar(max)", nullable: false),
                    BillingAddressAddressLine = table.Column<string>(name: "BillingAddress_AddressLine", type: "nvarchar(max)", nullable: false),
                    BillingAddressCountry = table.Column<string>(name: "BillingAddress_Country", type: "nvarchar(max)", nullable: false),
                    BillingAddressState = table.Column<string>(name: "BillingAddress_State", type: "nvarchar(max)", nullable: false),
                    BillingAddressZipCode = table.Column<string>(name: "BillingAddress_ZipCode", type: "nvarchar(max)", nullable: false),
                    PaymentDetailsCardName = table.Column<string>(name: "PaymentDetails_CardName", type: "nvarchar(max)", nullable: false),
                    PaymentDetailsCardNumber = table.Column<string>(name: "PaymentDetails_CardNumber", type: "nvarchar(max)", nullable: false),
                    PaymentDetailsExpiration = table.Column<string>(name: "PaymentDetails_Expiration", type: "nvarchar(max)", nullable: false),
                    PaymentDetailsCVV = table.Column<string>(name: "PaymentDetails_CVV", type: "nvarchar(max)", nullable: false),
                    PaymentDetailsPaymentMethod = table.Column<int>(name: "PaymentDetails_PaymentMethod", type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OccurredOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Error = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OutboxMessages");
        }
    }
}
