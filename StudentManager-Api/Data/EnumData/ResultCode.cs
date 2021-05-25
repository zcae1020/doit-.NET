namespace StudentManager.Data.EnumData
{
    public enum ResultId{
        Success,
        Failed
    }
    public class ResultCode{
        public ResultId id {get; set;}
        public string description{get; set;}

        public ResultCode(ResultId id, string description){
            this.id = id;
            this.description = description;
        }

    }
}