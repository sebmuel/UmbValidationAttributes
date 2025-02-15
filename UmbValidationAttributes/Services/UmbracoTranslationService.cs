using Umbraco.Cms.Web.Common;
using UmbValidationAttributes.Interfaces;

namespace UmbValidationAttributes.Services;

public class UmbracoTranslationService : IUmbracoTranslationService
{
    private readonly UmbracoHelper _umbracoHelper;

    public UmbracoTranslationService(IUmbracoHelperAccessor umbracoHelperAccessor)
    {
        if (!umbracoHelperAccessor.TryGetUmbracoHelper(out var helper))
        {
            throw new NullReferenceException("Unable to get umbraco helper");
        }

        _umbracoHelper = helper;
    }

    public string? GetTranslation(string key)
    {
        return _umbracoHelper.GetDictionaryValue(key);
    }

    public string GetTranslationWithFallback(string key, string fallback)
    {
        return _umbracoHelper.GetDictionaryValueOrDefault(key, fallback);
    }

    public IEnumerable<string> GetTranslations(IEnumerable<string> keys)
    {
        foreach (var key in keys)
        {
            var message = _umbracoHelper.GetDictionaryValue(key);

            if (string.IsNullOrEmpty(message)) continue;

            yield return message;
        }
    }
}