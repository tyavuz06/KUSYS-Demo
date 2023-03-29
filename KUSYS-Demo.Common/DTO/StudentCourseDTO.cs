namespace KUSYS_Demo.Common.DTO
{
    public class StudentCourseDTO
    {
        public StudentCourseDTO() { }
        public int Id { get; set; }
        public int[] SelectedCourses { get; set; }
        public int CourseId { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public int StudentId { get; set; }
        //public StudentDTO Student { get; set; }
        //public CourseDTO Course { get; set; }
    }
}
