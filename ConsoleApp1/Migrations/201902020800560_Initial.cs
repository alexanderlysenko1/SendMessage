namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        DateOfSend = c.DateTime(nullable: false),
                        TimeOfSend = c.DateTime(nullable: false),
                        TextOfMessage = c.String(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Users", t => t.SenderId, cascadeDelete: true)
                .Index(t => t.SenderId);
            
            CreateTable(
                "dbo.RecepientMessages",
                c => new
                    {
                        RecepientMessageId = c.Int(nullable: false, identity: true),
                        RecepientId = c.Int(nullable: false),
                        MessageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecepientMessageId)
                .ForeignKey("dbo.Messages", t => t.MessageId, cascadeDelete: true)
                .ForeignKey("dbo.Recepients", t => t.RecepientId, cascadeDelete: true)
                .Index(t => t.RecepientId)
                .Index(t => t.MessageId);
            
            CreateTable(
                "dbo.Recepients",
                c => new
                    {
                        RecepientId = c.Int(nullable: false, identity: true),
                        RecepientPhone = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.RecepientId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserPhone = c.String(),
                        Password = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "SenderId", "dbo.Users");
            DropForeignKey("dbo.RecepientMessages", "RecepientId", "dbo.Recepients");
            DropForeignKey("dbo.RecepientMessages", "MessageId", "dbo.Messages");
            DropIndex("dbo.RecepientMessages", new[] { "MessageId" });
            DropIndex("dbo.RecepientMessages", new[] { "RecepientId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropTable("dbo.Users");
            DropTable("dbo.Recepients");
            DropTable("dbo.RecepientMessages");
            DropTable("dbo.Messages");
        }
    }
}
