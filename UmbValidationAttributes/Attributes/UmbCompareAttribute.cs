using System.ComponentModel.DataAnnotations;
using UmbValidationAttributes.Interfaces;

namespace UmbValidationAttributes.Attributes;

public class UmbCompareAttribute : CompareAttribute, IUmbAttribute
{
    public string DictionaryKey { get; }
    public string FallbackMessage { get; }

    public UmbCompareAttribute(string dictionaryKey, string fallbackMessage, string otherProperty) : base(otherProperty)
    {
        DictionaryKey = dictionaryKey;
        FallbackMessage = fallbackMessage;
    }
}