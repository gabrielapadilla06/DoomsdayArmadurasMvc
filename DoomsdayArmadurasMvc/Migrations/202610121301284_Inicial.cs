namespace DoomsdayArmadurasMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Armaduras",
                c => new
                    {
                        ArmaduraId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 60),
                        Nivel = c.Int(nullable: false),
                        Portador = c.String(),
                        ReinoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArmaduraId)
                .ForeignKey("dbo.Reinoes", t => t.ReinoId, cascadeDelete: true)
                .Index(t => t.ReinoId);
            
            CreateTable(
                "dbo.Reinoes",
                c => new
                    {
                        ReinoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 60),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ReinoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Armaduras", "ReinoId", "dbo.Reinoes");
            DropIndex("dbo.Armaduras", new[] { "ReinoId" });
            DropTable("dbo.Reinoes");
            DropTable("dbo.Armaduras");
        }
    }
}
