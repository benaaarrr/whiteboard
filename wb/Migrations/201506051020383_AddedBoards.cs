namespace wb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBoards : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cards", "Board_Id", c => c.Int());
            CreateIndex("dbo.Cards", "Board_Id");
            AddForeignKey("dbo.Cards", "Board_Id", "dbo.Boards", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "Board_Id", "dbo.Boards");
            DropIndex("dbo.Cards", new[] { "Board_Id" });
            DropColumn("dbo.Cards", "Board_Id");
            DropTable("dbo.Boards");
        }
    }
}
