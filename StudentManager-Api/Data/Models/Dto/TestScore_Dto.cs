using System;
using StudentManager.Data.EnumData;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace StudentManager.Data.Models
{
    public class TestScore_Dto
    {
        [Required] 
        [StringLength(4)]
        public string studentId{get; set;} = "0000";

        [Required]
        public SubjectId subjectId{get; set;} = SubjectId.Etc;

        [Required]
        [Range(0,100)]

        public float score {get; set;} = 0f;
        [Required]
        [Range(1000,9999)]
        public int semester {get; set;} = 2101;

        public TestScore_Dto(
            string studentId, 
            SubjectId subjectId, 
            float score, 
            int semester)
        {
            this.studentId = studentId;
            this.subjectId = subjectId;
            this.score = score;
            this.semester = semester;
        }
    }
}