using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using UmbValidationAttributes.Adapter;
using UmbValidationAttributes.Interfaces;
using UmbValidationAttributes.Services;

namespace UmbValidationAttributes.Composers
{
    public class ValidationAttributesComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddSingleton<IValidationAttributeAdapterProvider, UmbValidationAdapterProvider>();
            builder.Services.AddScoped<IUmbracoTranslationService, UmbracoTranslationService>();
        }
    }
}