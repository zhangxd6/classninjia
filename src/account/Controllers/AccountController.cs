using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AccoutnController : Controller
{
    private readonly ILogger<AccoutnController> _logger;
    private readonly AccountContext _context;

    public AccoutnController(ILogger<AccoutnController> logger, AccountContext context)
    {
        _logger = logger;
        _context = context;
    }

  
    [HttpGet("accounts")]
    public async Task<List<Account>> GetAll() => await _context?.Accounts?.ToListAsync();

    
    [HttpGet("accounts/{id}")]
    public async Task<Account> GetAccount(int id) => await _context.Accounts.Where(d => d.Id == id).FirstOrDefaultAsync();

    
    [HttpPost("accounts")]
    public async Task<ActionResult> AddOrUpdate([FromBody] Account account)
    {
        if (account.Id == 0)
        {
            await _context.Accounts.AddAsync(account);
        }
        else
        {
            var existing = await _context.Accounts.Where(d => d.Id == account.Id).FirstOrDefaultAsync();
            if (existing == null)
            {
                return BadRequest();
            }
            existing.FirstMidName = account.FirstMidName;
            existing.LastName = account.LastName;
            existing.EnrollmentDate = account.EnrollmentDate;
        }

        await _context.SaveChangesAsync();
        return Ok();
    }

    
    [HttpDelete("accounts/{id}")]
    public async Task<ActionResult> Delete(int id)
    {

        var existing = await _context.Accounts.Where(d => d.Id == id).FirstOrDefaultAsync();
        if (existing == null)
        {
            return BadRequest();
        }
         _context.Accounts.Remove(existing);
        await _context.SaveChangesAsync();
        return Ok();
    }
}

