namespace LISA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutSalarieToken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salaries", "Token", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salaries", "Token");
        }
    }
}
