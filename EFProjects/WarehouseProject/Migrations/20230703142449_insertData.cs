using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseProject.Migrations
{
    /// <inheritdoc />
    public partial class insertData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Stores",
            columns: new[] { "Id", "Name", "Address" },
            values: new object[,]
                         {
                { 1, "Store1", "Address1" },
                { 2, "Store2", "Address3" },
                { 3, "Store3", "Address4" },
                { 4, "Store4", "Address5" },
                { 5, "Store5", "Address6" },
                         });


            migrationBuilder.InsertData(
           table: "Products",
           columns: new[] { "Id", "Name", "Quantity" },
           values: new object[,]
                         {
                { 1, "Product1", 10 },
                { 2, "Product2", 12 },
                { 3, "Product3", 10 },
                { 4, "Product4", 50 },
                         });

            migrationBuilder.InsertData(
           table: "Providers",
           columns: new[] { "Id", "Name", "Address" },
           values: new object[,]
                        {
                { 1, "Provider1", "Address1" },
                { 2, "Provider2", "Address2" },
                { 3, "Provider3", "Address3" },
                { 4, "Provider4", "Address4" },
                        });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
