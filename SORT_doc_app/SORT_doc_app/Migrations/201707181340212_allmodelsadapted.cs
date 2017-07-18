namespace SORT_doc_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allmodelsadapted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppsSupportReqs", "SupComments", c => c.String());
            AddColumn("dbo.ChangeManagementReqs", "ChComments", c => c.String());
            AddColumn("dbo.DBAReqs", "DBAComments", c => c.String());
            AddColumn("dbo.EOCReqs", "EOCComments", c => c.String());
            AddColumn("dbo.GISReqs", "GISComments", c => c.String());
            AddColumn("dbo.IAMReqs", "IAMComments", c => c.String());
            AddColumn("dbo.ITCS", "ITCSComments", c => c.String());
            AddColumn("dbo.NEReqs", "NEComments", c => c.String());
            AddColumn("dbo.PBXes", "PBXComments", c => c.String());
            AddColumn("dbo.QAReqs", "Comments", c => c.String());
            AddColumn("dbo.Risks", "RisksComments", c => c.String());
            AddColumn("dbo.SCVReqs", "SCVComments", c => c.String());
            AddColumn("dbo.ServiceSpecifics", "SSComments", c => c.String());
            AddColumn("dbo.SMOReqs", "SMOComments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SMOReqs", "SMOComments");
            DropColumn("dbo.ServiceSpecifics", "SSComments");
            DropColumn("dbo.SCVReqs", "SCVComments");
            DropColumn("dbo.Risks", "RisksComments");
            DropColumn("dbo.QAReqs", "Comments");
            DropColumn("dbo.PBXes", "PBXComments");
            DropColumn("dbo.NEReqs", "NEComments");
            DropColumn("dbo.ITCS", "ITCSComments");
            DropColumn("dbo.IAMReqs", "IAMComments");
            DropColumn("dbo.GISReqs", "GISComments");
            DropColumn("dbo.EOCReqs", "EOCComments");
            DropColumn("dbo.DBAReqs", "DBAComments");
            DropColumn("dbo.ChangeManagementReqs", "ChComments");
            DropColumn("dbo.AppsSupportReqs", "SupComments");
        }
    }
}
