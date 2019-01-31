namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        SenderPhone = c.String(maxLength: 128),
                        RecepientPhone = c.String(maxLength: 128),
                        DateOfSend = c.DateTime(nullable: false),
                        TimeOfSend = c.DateTime(nullable: false),
                        TextOfMessage = c.String(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Recepients", t => t.RecepientPhone)
                .ForeignKey("dbo.Users", t => t.SenderPhone)
                .Index(t => t.SenderPhone)
                .Index(t => t.RecepientPhone);
            
            CreateTable(
                "dbo.Recepients",
                c => new
                    {
                        RecepientId = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.RecepientId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        UserPhone = c.String(),
                        Passeword = c.String(),
                        FullName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "SenderPhone", "dbo.Users");
            DropForeignKey("dbo.Messages", "RecepientPhone", "dbo.Recepients");
            DropIndex("dbo.Messages", new[] { "RecepientPhone" });
            DropIndex("dbo.Messages", new[] { "SenderPhone" });
            DropTable("dbo.Users");
            DropTable("dbo.Recepients");
            DropTable("dbo.Messages");
        }
    }
}
