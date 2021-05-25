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
            await _testScoreTest.GetTestScoresAsync();

        [HttpGet("{id:length(24)}", Name = "GetTestScore")]
        public async Task<ActionResult<TestScore>> GetAsync(string id)
        {
            var score = await _testScoreTest.GetAsync(id);

            if (score == null)
            {
                return NotFound();
            }

            return score;
        }

        [HttpGet("testscoreId={id:length(4)}")]
        public async Task<ActionResult<TestScore>> GetByIdAsync(string id)
        {
            var score = await _testScoreTest.GetByTestScoreIdAsync(id);

            if (score == null)
            {
                return NotFound();
            }

            return score;
        }

        [HttpPost]
        public async Task<ActionResult<TestScore>> CreateAsync(TestScore_Dto scoreDto)
        {
            var score = new TestScore(scoreDto);
            await _testScoreTest.CreateAsync(score);

            return CreatedAtRoute("GetTestScore", new { id = score.Id.ToString() }, score);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateAsync(string id, TestScore_Dto scoreDtoIn)
        {
            var score = await _testScoreTest.GetAsync(id);

            if (score == null)
            {
                return NotFound();
            }
            var scoreIn = new TestScore(scoreDtoIn);
            scoreIn.Id = id;
            
            await _testScoreTest.UpdateAsync(id, scoreIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
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