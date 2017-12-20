namespace LISA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutSalarieTokenExpirationDate2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Salaries", name: "Token_Exipiration_Date", newName: "Token_Expiration_Date");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Salaries", name: "Token_Expiration_Date", newName: "Token_Exipiration_Date");
        }
    }
}
