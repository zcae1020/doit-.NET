using Microsoft.AspNetCore.Mvc;
using StudentManager.Data.Services;
using StudentManager.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManager.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestScoresController : ControllerBase
    {
        private readonly TestScoreService _testScoreTest;

        public TestScoresController(TestScoreService testScoreTest)
        {
            _testScoreTest = testScoreTest;
        }

        [HttpGet]
        public async Task<ActionResult<List<TestScore>>> GetAsync() =>
            //Service의 Scores를 Return
            await _testScoreTest.GetTestScoresAsync();

        [HttpGet("{id:length(24)}", Name = "GetTestScore")]
        public async Task<ActionResult<TestScore>> GetAsync(string id)
        {
            //파라미터 ID를 DB Id로 갖는 Score를 Return
            var testScore = await _testScoreTest.GetAsync(id);

            if (testScore == null)
            {
                return NotFound();
            }

            return testScore;
        }

        [HttpGet("testscoreId={id:length(4)}")]
        public async Task<ActionResult<TestScore>> GetByIdAsync(string id)
        {
            //파라미터 ID를 StudentId로 갖는 Score를 Return
            var testScore = await _testScoreTest.GetByTestScoreIdAsync(id);

            if (testScore == null)
            {
                return NotFound();
            }

            return testScore;
        }

        [HttpPost]
        public async Task<ActionResult<TestScore>> CreateAsync(TestScore_Dto scoreDto)
        {
            //파라미터 Score를 DB에 생성.
            var testScore = new TestScore(scoreDto);
            await _testScoreTest.CreateAsync(testScore);

            return CreatedAtRoute("GetTestScore", new { id = testScore.Id.ToString() }, testScore);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateAsync(string id, TestScore_Dto scoreDtoIn)
        {
            //파라미터 ID를 DB Id로 갖는 Score를 scoreDtoIn내용으로 업테이트.
            var testScore = await _testScoreTest.GetAsync(id);
            var scoreIn = new TestScore(scoreDtoIn);
            scoreIn.Id = id;

            if (testScore == null)
            {
                return NotFound();
            }

            await _testScoreTest.UpdateAsync(id, scoreIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            //파라미터 ID를 DB Id로 갖는 Score를 제거.
            var score = await _testScoreTest.GetAsync(id);

            if (score == null)
            {
                return NotFound();
            }

            await _testScoreTest.Remove(score.Id);

            return NoContent();
        }
    }
}