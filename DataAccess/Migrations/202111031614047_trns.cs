namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trns : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TransactionsHistories", newName: "Transactions");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Transactions", newName: "TransactionsHistories");
        }
    }
}
