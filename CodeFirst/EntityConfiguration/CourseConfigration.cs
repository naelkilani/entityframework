using CodeFirst.Models;
using System.Data.Entity.ModelConfiguration;

namespace CodeFirst.EntityConfiguration
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .Map(m =>
                {
                    m.ToTable("CourseTags");
                    m.MapLeftKey("CourseId");
                    m.MapRightKey("TagId");
                });
        }
    }
}
