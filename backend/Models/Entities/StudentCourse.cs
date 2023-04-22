
namespace gerdisc.Models.Entities
{
    /// <summary>
    /// Represents the association between a student and a course they are enrolled in.
    /// </summary>
    public record StudentCourseEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the student.
        /// </summary>
        /// <remarks>
        /// This property is a foreign key to the <see cref="StudentEntity"/> entity.
        /// </remarks>
        public Guid StudentId { get; set; }

        /// <summary>
        /// Gets or sets the student navigation property.
        /// </summary>
        /// <remarks>
        /// This property allows lazy loading of the <see cref="StudentEntity"/> entity.
        /// </remarks>
        public virtual StudentEntity Student { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the course.
        /// </summary>
        /// <remarks>
        /// This property is a foreign key to the <see cref="CourseEntity"/> entity.
        /// </remarks>
        public Guid CourseId { get; set; }

        /// <summary>
        /// Gets or sets the course navigation property.
        /// </summary>
        /// <remarks>
        /// This property allows lazy loading of the <see cref="CourseEntity"/> entity.
        /// </remarks>
        public virtual CourseEntity Course { get; set; }

        public StudentCourseEntity()
        {
            Course = new CourseEntity();
            Student = new StudentEntity();
        }
    }
}