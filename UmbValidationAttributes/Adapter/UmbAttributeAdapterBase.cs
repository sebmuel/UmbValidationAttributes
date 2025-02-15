using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using UmbValidationAttributes.Interfaces;

namespace UmbValidationAttributes.Adapter;

public abstract class UmbAttributeAdapterBase<TAttribute> : AttributeAdapterBase<TAttribute>
    where TAttribute : ValidationAttribute, IUmbAttribute
{
    private readonly IUmbracoTranslationService _translationService;

    protected UmbAttributeAdapterBase(
        TAttribute attribute,
        IStringLocalizer? stringLocalizer,
        IUmbracoTranslationService translationService) : base(attribute, stringLocalizer)
    {
        _translationService = translationService;
    }

    public override string GetErrorMessage(ModelValidationContextBase validationContext)
    {
        var message = _translationService.GetTranslation(Attribute.DictionaryKey);

        return string.IsNullOrEmpty(message) ? Attribute.FallbackMessage : message;
    }
}