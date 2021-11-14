namespace EmployeeBonus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBonusAndAdditionals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bonus",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(maxLength: 150),
                        ExperienceLevel = c.Int(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        JoiningDate = c.DateTime(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bonus", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Bonus", new[] { "DepartmentId" });
            DropTable("dbo.Bonus");
        }
    }
}
