namespace MoneyAdmin.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeletedAtToEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Transactions", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Wallets", "DeletedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wallets", "DeletedAt");
            DropColumn("dbo.Transactions", "DeletedAt");
            DropColumn("dbo.Categories", "DeletedAt");
        }
    }
}
