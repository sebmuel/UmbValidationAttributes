using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using UmbValidationAttributes.Attributes;
using UmbValidationAttributes.Interfaces;

namespace UmbValidationAttributes.Adapter;

public class UmbCompareAdapter : UmbAttributeAdapterBase<UmbCompareAttribute>
{
    public UmbCompareAdapter(
        UmbCompareAttribute attribute,
        IStringLocalizer? stringLocalizer,
        IUmbracoTranslationService translationService) : base(attribute, stringLocalizer, translationService)
    {
    }

    public override void AddValidation(ClientModelValidationContext context)
    {

        MergeAttribute(context.Attributes, "data-val", "true");
        MergeAttribute(context.Attributes, "data-val-equalto", GetErrorMessage(context));
        MergeAttribute(context.Attributes, "data-val-equalto-other", "*." + Attribute.OtherProperty);
    }
}