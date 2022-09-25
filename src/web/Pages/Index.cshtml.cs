using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IConfiguration _config;
    private readonly IHttpClientFactory _httpClientFactory;

    public string ApiUrl{ get; set; }
    public IList<Course>? Courses { get; set; } = new List<Course>();
    public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration,IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _config=configuration;
        _httpClientFactory=httpClientFactory;
        ApiUrl= _config["APIServices"];

    }

    public async Task OnGet()
    {
        var client = _httpClientFactory.CreateClient();
        try
        {
            var result = await client.GetFromJsonAsync<IList<Course>>(
                $"{ApiUrl}/courses"
            );
            this.Courses = result;
            return ;
        }
        catch (Exception e)
        {

        }
    }
}
