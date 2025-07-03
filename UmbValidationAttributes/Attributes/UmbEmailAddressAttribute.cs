using System.ComponentModel.DataAnnotations;
using UmbValidationAttributes.Interfaces;

namespace UmbValidationAttributes.Attributes;

public class UmbEmailAddressAttribute : RegularExpressionAttribute, IUmbAttribute
{
    public string DictionaryKey { get; }
    public string FallbackMessage { get; }
    private new const string Pattern = @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";

    public UmbEmailAddressAttribute(string dictionaryKey, string fallbackMessage, string? pattern = null)
        : base(pattern ?? Pattern)
    {
        DictionaryKey = dictionaryKey;
        FallbackMessage = fallbackMessage;
    }
}