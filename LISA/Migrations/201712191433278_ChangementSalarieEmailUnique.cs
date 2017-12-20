namespace LISA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangementSalarieEmailUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Salaries", "Email", c => c.String(maxLength: 255));
            CreateIndex("dbo.Salaries", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Salaries", new[] { "Email" });
            AlterColumn("dbo.Salaries", "Email", c => c.String());
        }
    }
}
