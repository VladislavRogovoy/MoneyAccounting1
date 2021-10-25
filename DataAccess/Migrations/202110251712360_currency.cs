namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class currency : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Currency", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Currency");
        }
    }
}
