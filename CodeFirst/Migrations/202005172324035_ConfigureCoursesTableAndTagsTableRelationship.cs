namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigureCoursesTableAndTagsTableRelationship : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TagCourses", newName: "CourseTags");
            RenameColumn(table: "dbo.CourseTags", name: "Tag_Id", newName: "TagId");
            RenameColumn(table: "dbo.CourseTags", name: "Course_Id", newName: "CourseId");
            RenameIndex(table: "dbo.CourseTags", name: "IX_Course_Id", newName: "IX_CourseId");
            RenameIndex(table: "dbo.CourseTags", name: "IX_Tag_Id", newName: "IX_TagId");
            DropPrimaryKey("dbo.CourseTags");
            AddPrimaryKey("dbo.CourseTags", new[] { "CourseId", "TagId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CourseTags");
            AddPrimaryKey("dbo.CourseTags", new[] { "Tag_Id", "Course_Id" });
            RenameIndex(table: "dbo.CourseTags", name: "IX_TagId", newName: "IX_Tag_Id");
            RenameIndex(table: "dbo.CourseTags", name: "IX_CourseId", newName: "IX_Course_Id");
            RenameColumn(table: "dbo.CourseTags", name: "CourseId", newName: "Course_Id");
            RenameColumn(table: "dbo.CourseTags", name: "TagId", newName: "Tag_Id");
            RenameTable(name: "dbo.CourseTags", newName: "TagCourses");
        }
    }
}
