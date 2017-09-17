namespace MyToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyTodoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Info = c.String(),
                        CrtDate = c.DateTime(nullable: false),
                        IsConclude = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyTodoes");
        }
    }
}
