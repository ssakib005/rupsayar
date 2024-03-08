namespace rupsayar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductImageTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_ProductImages",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FileName = c.String(),
                        FilePath = c.String(),
                        Tbl_ProductId = c.Long(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        ModifyBy = c.String(),
                        ModifyAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_Product", t => t.Tbl_ProductId, cascadeDelete: true)
                .Index(t => t.Tbl_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_ProductImages", "Tbl_ProductId", "dbo.Tbl_Product");
            DropIndex("dbo.Tbl_ProductImages", new[] { "Tbl_ProductId" });
            DropTable("dbo.Tbl_ProductImages");
        }
    }
}
