namespace GigHub1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class poo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserNotifications", new[] { "User_Id" });
            DropPrimaryKey("dbo.UserNotifications");
            AlterColumn("dbo.UserNotifications", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserNotifications", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserNotifications", new[] { "UserId", "NotificationId" });
            CreateIndex("dbo.UserNotifications", "UserId", false, "testindex");
        }

        public override void Down()
        {
            DropIndex("dbo.UserNotifications", new[] { "UserId" });
            DropPrimaryKey("dbo.UserNotifications");
            AlterColumn("dbo.UserNotifications", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserNotifications", "UserId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserNotifications", new[] { "UserId", "NotificationId" });
            RenameColumn(table: "dbo.UserNotifications", name: "UserId", newName: "User_Id");
            AddColumn("dbo.UserNotifications", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserNotifications", "User_Id");
        }
    }
}
