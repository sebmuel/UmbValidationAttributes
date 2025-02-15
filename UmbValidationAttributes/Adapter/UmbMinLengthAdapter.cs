using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using UmbValidationAttributes.Attributes;
using UmbValidationAttributes.Interfaces;

namespace UmbValidationAttributes.Adapter;

public class UmbMinLengthAdapter : UmbAttributeAdapterBase<UmbMinLengthAttribute>
{
    private readonly string _min;

    public UmbMinLengthAdapter(
        UmbMinLengthAttribute attribute,
        IStringLocalizer? stringLocalizer,
        IUmbracoTranslationService translationService) : base(attribute, stringLocalizer, translationService)
    {
        _min = Attribute.Length.ToString(CultureInfo.InvariantCulture);
    }

    public override void AddValidation(ClientModelValidationContext context)
    {
        MergeAttribute(context.Attributes, "data-val", "true");
        MergeAttribute(context.Attributes, "data-val-minlength", GetErrorMessage(context));
        MergeAttribute(context.Attributes, "data-val-minlength-min", _min);
    }
}