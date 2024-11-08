﻿namespace StudentAPI.Application.Models
{
    public class Student
    {
        [Key]
        public int      StudentId               { get; set; }

        [ForeignKey("Class")]
        public int      ClassId                 { get; set; }

        [Required, StringLength(20, MinimumLength = 2)]
        public string   FullName                { get; set; }

        [Required, Range(typeof(DateTime), "2001-01-01", "2013-12-31")]
        public DateTime Birthday                { get; set; }

        public string   Address                 { get; set; }

        [JsonIgnore]
        public Class? Class { get; set; }
    }
}
