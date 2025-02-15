namespace UmbValidationAttributes.Interfaces;

public interface IUmbAttribute
{
    string DictionaryKey { get; }
    string FallbackMessage { get; }
}