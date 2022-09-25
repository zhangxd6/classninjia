using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CourseController : Controller
{
    private readonly ILogger<CourseController> _logger;
    private readonly CourseContext _context;

    public CourseController(ILogger<CourseController> logger, CourseContext context)
    {
        _logger = logger;
        _context = context;
    }

  
    [HttpGet("courses")]
    public async Task<List<Course>> GetAll() => await _context?.Courses?.ToListAsync();

    
    [HttpGet("courses/{id}")]
    public async Task<Course> GetAccount(int id) => await _context.Courses.Where(d => d.Id == id).FirstOrDefaultAsync();

    
    [HttpPost("courses")]
    public async Task<ActionResult> AddOrUpdate([FromBody] Course course)
    {
        if (course.Id == 0)
        {
            await _context.Courses.AddAsync(course);
        }
        else
        {
            var existing = await _context.Courses.Where(d => d.Id== course.Id).FirstOrDefaultAsync();
            if (existing == null)
            {
                return BadRequest();
            }
            existing.Descripton = course.Descripton;
            existing.Title = course.Title;
            existing.Level = course.Level;
        }

        await _context.SaveChangesAsync();
        return Ok();
    }

    
    [HttpDelete("courses/{id}")]
    public async Task<ActionResult> Delete(int id)
    {

        var existing = await _context.Courses.Where(d => d.Id == id).FirstOrDefaultAsync();
        if (existing == null)
        {
            return BadRequest();
        }
         _context.Courses.Remove(existing);
        await _context.SaveChangesAsync();
        return Ok();
    }
}

