using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.TestInstance.Models.Forms;

namespace Umbraco.TestInstance.Controllers;

public class EmailAttributeController : SurfaceController
{
    public EmailAttributeController(IUmbracoContextAccessor umbracoContextAccessor,
        IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches,
        IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider)
        : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {
    }

    [HttpPost]
    public async Task<IActionResult> PostEmailAttributeForm(EmailAttributeFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return CurrentUmbracoPage();
        }

        await Task.Delay(1000);

        return RedirectToCurrentUmbracoPage(QueryString.Create("email", model.Email));
    }
}