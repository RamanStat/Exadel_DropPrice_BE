﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ProcedureArchiveDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"GO
                                CREATE PROCEDURE ArchiveExpiredDiscount @dateNow DATE AS
                                UPDATE Discounts SET ActivityStatus = 0 WHERE ActivityStatus = 1 and EndDate < @dateNow;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE ArchiveExpiredDiscount;");
        }
    }
}
