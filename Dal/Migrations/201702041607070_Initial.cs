namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Meals.Meals",
                c => new
                    {
                        MealId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MealId);
            
        }
        
        public override void Down()
        {
            DropTable("Meals.Meals");
        }
    }
}
