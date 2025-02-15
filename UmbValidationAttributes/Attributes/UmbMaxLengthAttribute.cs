using System.ComponentModel.DataAnnotations;
using UmbValidationAttributes.Interfaces;

namespace UmbValidationAttributes.Attributes;

public class UmbMaxLengthAttribute : MaxLengthAttribute, IUmbAttribute
{
    public string DictionaryKey { get; }
    public string FallbackMessage { get; }

    public UmbMaxLengthAttribute(string dictionaryKey, string fallbackMessage, int length) : base(length)
    {
        DictionaryKey = dictionaryKey;
        FallbackMessage = fallbackMessage;
    }

    public UmbMaxLengthAttribute(string dictionaryKey, string fallbackMessage)
    {
        DictionaryKey = dictionaryKey;
        FallbackMessage = fallbackMessage;
    }
}