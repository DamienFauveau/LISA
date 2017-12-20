namespace LISA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutSalarieTokenExpirationDate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Salaries", name: "TokenExpirationDate", newName: "Token_Exipiration_Date");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Salaries", name: "Token_Exipiration_Date", newName: "TokenExpirationDate");
        }
    }
}
