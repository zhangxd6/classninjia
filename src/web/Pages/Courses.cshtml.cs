using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;

namespace web.Pages;
public class CourseModel : PageModel
{
    private readonly ILogger<CourseModel> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _config;
    public IList<Course>? Courses { get; set; } = new List<Course>();
    public CourseModel(ILogger<CourseModel> logger,
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _config = configuration;
    }

    public async Task OnGetAsync()
    {
        var client = _httpClientFactory.CreateClient();
        try
        {
            var result = await client.GetFromJsonAsync<IList<Course>>(
                $"{_config["APIServices"]}/courses"
            );
            this.Courses = result;
            return ;
        }
        catch (Exception e)
        {

        }
    }

    
}