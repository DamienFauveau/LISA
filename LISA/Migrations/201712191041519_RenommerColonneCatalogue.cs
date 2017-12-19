namespace LISA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenommerColonneCatalogue : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Catalogues", "width", "Width");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Catalogues", "Width", "width");
        }
    }
}
