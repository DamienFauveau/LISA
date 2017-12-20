namespace LISA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangementSalarieRequired : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Salaries", new[] { "Email" });
            AlterColumn("dbo.Salaries", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Salaries", "Password", c => c.String(nullable: false));
            CreateIndex("dbo.Salaries", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Salaries", new[] { "Email" });
            AlterColumn("dbo.Salaries", "Password", c => c.String());
            AlterColumn("dbo.Salaries", "Email", c => c.String(maxLength: 255));
            CreateIndex("dbo.Salaries", "Email", unique: true);
        }
    }
}
