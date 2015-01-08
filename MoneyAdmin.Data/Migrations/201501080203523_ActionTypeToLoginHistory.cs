namespace MoneyAdmin.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActionTypeToLoginHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoginHistories", "Action", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoginHistories", "Action");
        }
    }
}
