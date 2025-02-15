using System.ComponentModel.DataAnnotations;
using UmbValidationAttributes.Interfaces;

namespace UmbValidationAttributes.Attributes;

public class UmbRequireAttribute : RequiredAttribute, IUmbAttribute
{
    public string DictionaryKey { get; set; }
    public string FallbackMessage { get; set; }

    public UmbRequireAttribute(string dictionaryKey, string fallbackMessage)
    {
        DictionaryKey = dictionaryKey;
        FallbackMessage = fallbackMessage;
    }
}