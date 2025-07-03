using System.ComponentModel.DataAnnotations;
using UmbValidationAttributes.Interfaces;

namespace UmbValidationAttributes.Attributes;

public class UmbEmailAddressAttribute : RegularExpressionAttribute, IUmbAttribute
{
    public string DictionaryKey { get; }
    public string FallbackMessage { get; }
    private new const string Pattern = @"^([\w\.\-]+)@([\w\-]+)(\.[\w\-]+)+((\.(\w){2,})+)$";

    public UmbEmailAddressAttribute(string dictionaryKey, string fallbackMessage, string? pattern = null)
        : base(pattern ?? Pattern)
    {
        DictionaryKey = dictionaryKey;
        FallbackMessage = fallbackMessage;
    }
}