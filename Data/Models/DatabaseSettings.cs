namespace StudentManager.Data.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string TestScoresCollectionName { get; set; }
        public string StudentsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IDatabaseSettings
    {
        string TestScoresCollectionName { get; set; }
        string StudentsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}