using System;
using StudentManager.Data.EnumData;
using System.ComponentModel.DataAnnotations;

namespace StudentManager.Data.Models
{
    public class Student
    {
        public static string studentDefaultId = "0000";
        [Required]
        [StringLength(4)]
        public string studentId{get; set;} = default;
        [Required]
        public string name{get; set;} = string.Empty;
        [Required]
        [Range(0,1000)]
        public int age{get; set;} = 0;
        [Required]
        public GenderId gender{get; set;} = GenderId.Etc;
        public CountryId country{get; set;} = CountryId.Etc;
        public DateTime admissionTime{get; set;} = DateTime.Today;

        public Student(
            string studentId,
            string name,
            int age,
            GenderId gender,
            CountryId country,
            DateTime admissionTime)
        {
            this.studentId = studentId;
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.country = country;
            this.admissionTime = admissionTime;
        }
        public Student(){}

    }
}