namespace rupsayar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Category",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        ModifyBy = c.String(),
                        ModifyAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_ProductOrder",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RequiredQuantity = c.Int(nullable: false),
                        Amount = c.Single(nullable: false),
                        IsOrderPlace = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        ModifyBy = c.String(),
                        ModifyAt = c.DateTime(),
                        Tbl_Product_Id = c.Long(),
                        Tbl_User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_Product", t => t.Tbl_Product_Id)
                .ForeignKey("dbo.Tbl_User", t => t.Tbl_User_Id)
                .Index(t => t.Tbl_Product_Id)
                .Index(t => t.Tbl_User_Id);
            
            CreateTable(
                "dbo.Tbl_Product",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Tbl_CategoryId = c.Long(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                        IsNewArrival = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        ModifyBy = c.String(),
                        ModifyAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_Category", t => t.Tbl_CategoryId, cascadeDelete: true)
                .Index(t => t.Tbl_CategoryId);
            
            CreateTable(
                "dbo.Tbl_ProductRate",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Rate = c.Single(nullable: false),
                        Review = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        ModifyBy = c.String(),
                        ModifyAt = c.DateTime(),
                        Product_Id = c.Long(),
                        User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_Product", t => t.Product_Id)
                .ForeignKey("dbo.Tbl_User", t => t.User_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Tbl_User",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        HashPassword = c.String(),
                        Division = c.String(),
                        District = c.String(),
                        ZipCode = c.String(),
                        Address = c.String(),
                        IsVerified = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        ModifyBy = c.String(),
                        ModifyAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_ProductVariant",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Color = c.String(),
                        Size = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        ModifyBy = c.String(),
                        ModifyAt = c.DateTime(),
                        Tbl_Product_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_Product", t => t.Tbl_Product_Id)
                .Index(t => t.Tbl_Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_ProductOrder", "Tbl_User_Id", "dbo.Tbl_User");
            DropForeignKey("dbo.Tbl_ProductOrder", "Tbl_Product_Id", "dbo.Tbl_Product");
            DropForeignKey("dbo.Tbl_ProductVariant", "Tbl_Product_Id", "dbo.Tbl_Product");
            DropForeignKey("dbo.Tbl_ProductRate", "User_Id", "dbo.Tbl_User");
            DropForeignKey("dbo.Tbl_ProductRate", "Product_Id", "dbo.Tbl_Product");
            DropForeignKey("dbo.Tbl_Product", "Tbl_CategoryId", "dbo.Tbl_Category");
            DropIndex("dbo.Tbl_ProductVariant", new[] { "Tbl_Product_Id" });
            DropIndex("dbo.Tbl_ProductRate", new[] { "User_Id" });
            DropIndex("dbo.Tbl_ProductRate", new[] { "Product_Id" });
            DropIndex("dbo.Tbl_Product", new[] { "Tbl_CategoryId" });
            DropIndex("dbo.Tbl_ProductOrder", new[] { "Tbl_User_Id" });
            DropIndex("dbo.Tbl_ProductOrder", new[] { "Tbl_Product_Id" });
            DropTable("dbo.Tbl_ProductVariant");
            DropTable("dbo.Tbl_User");
            DropTable("dbo.Tbl_ProductRate");
            DropTable("dbo.Tbl_Product");
            DropTable("dbo.Tbl_ProductOrder");
            DropTable("dbo.Tbl_Category");
        }
    }
}
