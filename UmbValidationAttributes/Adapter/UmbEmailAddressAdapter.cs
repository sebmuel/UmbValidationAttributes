using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using UmbValidationAttributes.Attributes;
using UmbValidationAttributes.Interfaces;

namespace UmbValidationAttributes.Adapter;

public class UmbEmailAddressAdapter : UmbAttributeAdapterBase<UmbEmailAddressAttribute>
{
    public UmbEmailAddressAdapter(
        UmbEmailAddressAttribute attribute,
        IStringLocalizer? stringLocalizer,
        IUmbracoTranslationService translationService
    ) : base(attribute, stringLocalizer, translationService)
    {
    }

    public override void AddValidation(ClientModelValidationContext context)
    {
        MergeAttribute(context.Attributes, "data-val", "true");
        MergeAttribute(context.Attributes, "data-val-email", GetErrorMessage(context));
    }
}