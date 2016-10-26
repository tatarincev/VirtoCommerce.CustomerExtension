namespace VirtoCommerce.CustomerExtModule.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
           
            CreateTable(
                "dbo.VendorExtension",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.String(maxLength: 128),
                        CustomerName = c.String(maxLength: 255),
                        EmployeeId = c.String(maxLength: 128),
                        EmployeeName = c.String(maxLength: 255),
                        Type1 = c.String(maxLength: 50),
                        AcctRep = c.Int(nullable: false),
                        DirectoryLive = c.Boolean(nullable: false),
                        ExternalWebsiteUrl = c.String(maxLength: 100),
                        AcctField1 = c.String(maxLength: 255),
                        AcctField2 = c.String(maxLength: 255),
                        AcctField3 = c.String(maxLength: 255),
                        AcctField4 = c.String(maxLength: 255),
                        AcctField5 = c.String(maxLength: 255),
                        AcctField6 = c.String(maxLength: 255),
                        AcctField7 = c.String(maxLength: 255),
                        AcctField8 = c.String(maxLength: 255),
                        AcctField9 = c.String(maxLength: 255),
                        AcctField10 = c.String(maxLength: 255),
                        AcctField11 = c.String(maxLength: 255),
                        AcctField12 = c.String(maxLength: 255),
                        AdminNotes = c.String(unicode: false, storeType: "text"),
                        LastUsed = c.DateTime(nullable: false),
                        ConfiguratorSettings = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vendor", t => t.Id)
                .Index(t => t.Id);
 
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendorExtension", "Id", "dbo.Vendor");
            DropIndex("dbo.VendorExtension", new[] { "Id" });
            DropTable("dbo.VendorExtension");
        }
    }
}
