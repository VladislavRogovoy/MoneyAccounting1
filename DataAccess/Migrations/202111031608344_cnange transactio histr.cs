namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cnangetransactiohistr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionsHistories", "IsAddition", c => c.Boolean(nullable: false));
            AddColumn("dbo.TransactionsHistories", "Amount", c => c.Single(nullable: false));
            DropColumn("dbo.TransactionsHistories", "History");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransactionsHistories", "History", c => c.String());
            DropColumn("dbo.TransactionsHistories", "Amount");
            DropColumn("dbo.TransactionsHistories", "IsAddition");
        }
    }
}
