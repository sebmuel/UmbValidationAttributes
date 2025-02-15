using System.ComponentModel.DataAnnotations;
using UmbValidationAttributes.Interfaces;

namespace UmbValidationAttributes.Attributes;

public class UmbMinLengthAttribute : MinLengthAttribute, IUmbAttribute
{
    public string DictionaryKey { get; }
    public string FallbackMessage { get; }

    public UmbMinLengthAttribute(string dictionaryKey, string fallbackMessage, int length) : base(length)
    {
        DictionaryKey = dictionaryKey;
        FallbackMessage = fallbackMessage;
    }

}