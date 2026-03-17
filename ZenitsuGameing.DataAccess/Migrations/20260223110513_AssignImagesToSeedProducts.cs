using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenitsuGameing.Migrations
{
    /// <inheritdoc />
    public partial class AssignImagesToSeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Assign the existing uploaded images to the seed products
            migrationBuilder.Sql(@"
                UPDATE Products 
                SET ImageUrl = '\Images\Products\0dd5e5b8-f640-41e6-830f-d196eb489296.jpg'
                WHERE Id = 1 AND (ImageUrl IS NULL OR ImageUrl = '');

                UPDATE Products 
                SET ImageUrl = '\Images\Products\7f4d0702-9817-4b16-9965-bdfface6df47.jpg'
                WHERE Id = 2 AND (ImageUrl IS NULL OR ImageUrl = '');

                UPDATE Products 
                SET ImageUrl = '\Images\Products\83e0b0dc-ae52-4fee-b7c4-17bbb7e25663.jpg'
                WHERE Id = 3 AND (ImageUrl IS NULL OR ImageUrl = '');
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert the image assignments
            migrationBuilder.Sql(@"
                UPDATE Products 
                SET ImageUrl = ''
                WHERE Id IN (1, 2, 3);
            ");
        }
    }
}
