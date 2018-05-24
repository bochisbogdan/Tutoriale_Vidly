namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStocNumberInMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "StockNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "StockNumber");
        }
    }
}
