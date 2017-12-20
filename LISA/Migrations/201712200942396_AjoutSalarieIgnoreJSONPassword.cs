namespace LISA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutSalarieIgnoreJSONPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salaries", "TokenExpirationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salaries", "TokenExpirationDate");
        }
    }
}
