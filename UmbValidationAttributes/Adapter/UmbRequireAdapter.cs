using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using UmbValidationAttributes.Attributes;
using UmbValidationAttributes.Interfaces;

namespace UmbValidationAttributes.Adapter;

public class UmbRequireAdapter : UmbAttributeAdapterBase<UmbRequireAttribute>
{
    public UmbRequireAdapter(UmbRequireAttribute attribute,
        IStringLocalizer? stringLocalizer,
        IUmbracoTranslationService translationService)
        : base(attribute, stringLocalizer, translationService)
    {
    }

    public override void AddValidation(ClientModelValidationContext context)
    {
        MergeAttribute(context.Attributes, "data-val", "true");
        MergeAttribute(context.Attributes, "data-val-required", GetErrorMessage(context));
    }
}