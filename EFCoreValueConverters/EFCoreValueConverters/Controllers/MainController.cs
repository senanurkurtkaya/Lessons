using EFCoreValueConverters.Context;
using EFCoreValueConverters.Enums;
using EFCoreValueConverters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreValueConverters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly ExampleDbContext _context;

        public MainController(ExampleDbContext context)
        {
            _context = context;
        }

        [HttpPost("CreateDatabase")]
        public async Task<IActionResult> CreateDatabase()
        {
            var dbCreateScript = _context.Database.GenerateCreateScript();

            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();

            return Ok();
        }

        [HttpGet("GetDbScript")]
        public async Task<IActionResult> GetDbScript()
        {
            var dbCreateScript = _context.Database.GenerateCreateScript();

            return Ok(dbCreateScript);
        }

        [HttpGet("User/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(user);
        }

        [HttpPost("User")]
        public async Task<IActionResult> Create(User user)
        {
            await _context.AddAsync(user);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
