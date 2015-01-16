namespace MoneyAdmin.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Path = c.String(),
                        TransactionId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy)
                .ForeignKey("dbo.Users", t => t.UpdatedBy)
                .ForeignKey("dbo.Transactions", t => t.TransactionId)
                .Index(t => t.TransactionId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy);
            
            CreateTable(
                "dbo.LoginHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ShareCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        WalletId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy)
                .ForeignKey("dbo.Users", t => t.UpdatedBy)
                .ForeignKey("dbo.Wallets", t => t.WalletId)
                .Index(t => t.WalletId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy);
            
            AddColumn("dbo.Wallets", "AvailableBalance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShareCodes", "WalletId", "dbo.Wallets");
            DropForeignKey("dbo.ShareCodes", "UpdatedBy", "dbo.Users");
            DropForeignKey("dbo.ShareCodes", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.LoginHistories", "UserId", "dbo.Users");
            DropForeignKey("dbo.Files", "TransactionId", "dbo.Transactions");
            DropForeignKey("dbo.Files", "UpdatedBy", "dbo.Users");
            DropForeignKey("dbo.Files", "CreatedBy", "dbo.Users");
            DropIndex("dbo.ShareCodes", new[] { "UpdatedBy" });
            DropIndex("dbo.ShareCodes", new[] { "CreatedBy" });
            DropIndex("dbo.ShareCodes", new[] { "WalletId" });
            DropIndex("dbo.LoginHistories", new[] { "UserId" });
            DropIndex("dbo.Files", new[] { "UpdatedBy" });
            DropIndex("dbo.Files", new[] { "CreatedBy" });
            DropIndex("dbo.Files", new[] { "TransactionId" });
            DropColumn("dbo.Wallets", "AvailableBalance");
            DropTable("dbo.ShareCodes");
            DropTable("dbo.LoginHistories");
            DropTable("dbo.Files");
        }
    }
}
