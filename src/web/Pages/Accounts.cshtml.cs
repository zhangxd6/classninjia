using Microsoft.AspNetCore.Mvc.RazorPages;

namespace web.Pages;
public class AccountModel : PageModel
{
    private readonly ILogger<AccountModel> _logger;

    public AccountModel(ILogger<AccountModel> logger)
    {
        _logger = logger;
    }

   
}