namespace StudentAPI.Application.Models
{
    public class Class
    {
        [Key]
        public int    ClassId         { get; set; }

        [Required, StringLength(10)]
        public string ClassName       { get; set; }

        [Required, Range(0, 20)]
        public int    NumberOfStudent { get; set; }

        [JsonIgnore]
        public ICollection<Student>? Students { get; set; }
    }
}
