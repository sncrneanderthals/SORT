namespace SORT_doc_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class summaryedits : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Summaries", "SummaryComments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Summaries", "SummaryComments");
        }
    }
}
