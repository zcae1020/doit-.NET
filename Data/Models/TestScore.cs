using StudentManager.Data.EnumData;
using System.ComponentModel.DataAnnotations;

namespace StudentManager.Data.Models
{
    public class TestScore
    {
        public string scoreId{get; set;}
        [Required] 
        /*[code]*/
        public string studentId{get; set;} = "0000";
        [Required]
        public SubjectId subjectId{get; set;} = SubjectId.Etc;
        [Required]
        /*[code]*/
        public float score {get; set;} = 0f;
        [Required]
        /*[code]*/
        public int semester {get; set;} = 2101;

        public TestScore(
            string studentId, 
            SubjectId subjectId, 
            float score, 
            int semester)
        {
            this.scoreId = studentId + ((int)subjectId) + semester;
            this.studentId = studentId;
            this.subjectId = subjectId;
            this.score = score;
            this.semester = semester;
        }

    }
}