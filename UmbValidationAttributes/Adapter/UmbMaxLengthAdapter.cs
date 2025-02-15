using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using UmbValidationAttributes.Attributes;
using UmbValidationAttributes.Interfaces;

namespace UmbValidationAttributes.Adapter;

public class UmbMaxLengthAdapter : UmbAttributeAdapterBase<UmbMaxLengthAttribute>
{
    private readonly string _max;

    public UmbMaxLengthAdapter(
        UmbMaxLengthAttribute attribute,
        IStringLocalizer? stringLocalizer,
        IUmbracoTranslationService translationService) : base(attribute, stringLocalizer, translationService)
    {
        _max = Attribute.Length.ToString(CultureInfo.InvariantCulture);
    }

    public override void AddValidation(ClientModelValidationContext context)
    {
        MergeAttribute(context.Attributes, "data-val", "true");
        MergeAttribute(context.Attributes, "data-val-maxlength", GetErrorMessage(context));
        MergeAttribute(context.Attributes, "data-val-maxlength-max", _max);
    }
}