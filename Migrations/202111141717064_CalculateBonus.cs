namespace EmployeeBonus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CalculateBonus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropTable("dbo.Employees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        DepartmentId = c.Int(nullable: false),
                        ExperienceLevel = c.String(),
                        JoiningDate = c.DateTime(nullable: false),
                        Salary = c.Int(nullable: false),
                        Bonus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Employees", "DepartmentId");
            AddForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
