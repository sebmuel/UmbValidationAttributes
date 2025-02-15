using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using UmbValidationAttributes.Attributes;
using UmbValidationAttributes.Interfaces;

namespace UmbValidationAttributes.Adapter;

public class UmbValidationAdapterProvider : IValidationAttributeAdapterProvider
{
    private readonly ValidationAttributeAdapterProvider _baseProvider = new();
    private readonly IServiceScopeFactory _scopeFactory;

    public UmbValidationAdapterProvider(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public IAttributeAdapter? GetAttributeAdapter(
        ValidationAttribute attribute,
        IStringLocalizer? stringLocalizer)
    {
        using var scope = _scopeFactory.CreateScope();
        var translationService = scope.ServiceProvider.GetRequiredService<IUmbracoTranslationService>();

        return attribute switch
        {
            UmbRequireAttribute umbRequireAttribute
                => new UmbRequireAdapter(umbRequireAttribute, stringLocalizer, translationService),

            UmbEmailAddressAttribute umbEmailAddressAttribute
                => new UmbEmailAddressAdapter(umbEmailAddressAttribute, stringLocalizer, translationService),

            UmbCompareAttribute umbCompareAttribute
                => new UmbCompareAdapter(umbCompareAttribute, stringLocalizer, translationService),

            UmbMinLengthAttribute umbMinLengthAttribute
                => new UmbMinLengthAdapter(umbMinLengthAttribute, stringLocalizer, translationService),

            UmbMaxLengthAttribute umbMaxLengthAttribute
                => new UmbMaxLengthAdapter(umbMaxLengthAttribute, stringLocalizer, translationService),

            _ => _baseProvider.GetAttributeAdapter(attribute, stringLocalizer)
        };
    }
}