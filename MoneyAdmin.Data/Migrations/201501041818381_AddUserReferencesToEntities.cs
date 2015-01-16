namespace MoneyAdmin.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserReferencesToEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Transactions", "WalletId", "dbo.Wallets");
            CreateIndex("dbo.Categories", "CreatedBy");
            CreateIndex("dbo.Categories", "UpdatedBy");
            CreateIndex("dbo.Transactions", "CreatedBy");
            CreateIndex("dbo.Transactions", "UpdatedBy");
            CreateIndex("dbo.Wallets", "CreatedBy");
            CreateIndex("dbo.Wallets", "UpdatedBy");
            AddForeignKey("dbo.Transactions", "CreatedBy", "dbo.Users", "Id");
            AddForeignKey("dbo.Transactions", "UpdatedBy", "dbo.Users", "Id");
            AddForeignKey("dbo.Wallets", "CreatedBy", "dbo.Users", "Id");
            AddForeignKey("dbo.Wallets", "UpdatedBy", "dbo.Users", "Id");
            AddForeignKey("dbo.Categories", "CreatedBy", "dbo.Users", "Id");
            AddForeignKey("dbo.Categories", "UpdatedBy", "dbo.Users", "Id");
            AddForeignKey("dbo.Transactions", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.Transactions", "WalletId", "dbo.Wallets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "WalletId", "dbo.Wallets");
            DropForeignKey("dbo.Transactions", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "UpdatedBy", "dbo.Users");
            DropForeignKey("dbo.Categories", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.Wallets", "UpdatedBy", "dbo.Users");
            DropForeignKey("dbo.Wallets", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.Transactions", "UpdatedBy", "dbo.Users");
            DropForeignKey("dbo.Transactions", "CreatedBy", "dbo.Users");
            DropIndex("dbo.Wallets", new[] { "UpdatedBy" });
            DropIndex("dbo.Wallets", new[] { "CreatedBy" });
            DropIndex("dbo.Transactions", new[] { "UpdatedBy" });
            DropIndex("dbo.Transactions", new[] { "CreatedBy" });
            DropIndex("dbo.Categories", new[] { "UpdatedBy" });
            DropIndex("dbo.Categories", new[] { "CreatedBy" });
            AddForeignKey("dbo.Transactions", "WalletId", "dbo.Wallets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
