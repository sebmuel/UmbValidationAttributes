namespace UmbValidationAttributes.Interfaces;

public interface IUmbracoTranslationService
{
    public string? GetTranslation(string key);
    public string GetTranslationWithFallback(string key, string fallback);
    public IEnumerable<string> GetTranslations(IEnumerable<string> keys);
}