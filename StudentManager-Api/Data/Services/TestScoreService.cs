using System.Linq;
using System;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Threading.Tasks;
using StudentManager.Data.Models;

namespace StudentManager.Data.Services
{
    public class TestScoreService
    {
        private readonly IMongoCollection<TestScore> _testScore;

        public TestScoreService(IDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _testScore = database.GetCollection<TestScore>(settings.TestScoresCollectionName);
        }


        public async Task<List<TestScore>> GetTestScoresAsync() => 
            await _testScore.Find(st => true).ToListAsync();

        public async Task<TestScore> GetAsync(string id) =>
            await _testScore.Find<TestScore>(score => score.Id == id).FirstOrDefaultAsync();


        public async Task<TestScore> GetByTestScoreIdAsync(string id) =>
            await _testScore.Find(score => score.scoreId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(TestScore score){
            await _testScore.InsertOneAsync(score);
        }

        public async Task UpdateAsync(string id, TestScore scoreIn) =>
            await _testScore.ReplaceOneAsync(score => score.Id == id, scoreIn);

        public async Task RemoveByTestScoreIdAsync(string id){
            TestScore score = await GetByTestScoreIdAsync(id);
            await _testScore.DeleteOneAsync(s => s.Id == score.Id);
        }
        public async Task RemoveAsync(TestScore scoreIn) =>
            await _testScore.DeleteOneAsync(s => s.Id == scoreIn.Id);

        public async Task Remove(string id) => 
            await _testScore.DeleteOneAsync(s => s.Id == id);
    }
}