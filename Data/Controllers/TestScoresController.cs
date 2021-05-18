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
        public async Task<ActionResult<List<TestScore>>> GetAsync(){
            
        }

        [HttpGet("{id:length(24)}", Name = "GetTestScore")]
        public async Task<ActionResult<TestScore>> GetAsync(string id)
        {
            
        }

        [HttpGet("testscoreId={id:length(4)}")]
        public async Task<ActionResult<TestScore>> GetByIdAsync(string id)
        {
            
        }

        [HttpPost]
        public async Task<ActionResult<TestScore>> CreateAsync(TestScore_Dto scoreDto)
        {
            
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateAsync(string id, TestScore_Dto scoreDtoIn)
        {
            
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            
        }
    }
}