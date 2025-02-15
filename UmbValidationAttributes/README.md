# UmbDictionary.Validation.Attributes

UmbValidationAttributes is a NuGet package that provides custom validation attributes for Umbraco forms. These
attributes allow error messages to be translated dynamically using Umbraco's dictionary feature, with a fallback message
if no dictionary entry is found.

## Installation

Install the package via NuGet:

```sh
dotnet add package Sitepoint.UmbValidationAttributes
```

## Usage

Apply the custom validation attributes to your model properties, specifying both the dictionary key and a fallback error
message.

### Example

```csharp
public class FormModel
{
    [UmbRequire("Form.UmbRequire", "This field is required.")]
    [UmbMaxLength("Form.UmbMaxLength", "This field is too long.", 20)]
    [UmbMinLength("Form.UmbMinLength", "This field is too short.", 5)]
    public string? Name { get; set; }

    [UmbEmailAddress("Form.UmbEmailAddress", "Please enter a valid email address.")]
    public string? Email { get; set; }

    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [UmbCompare("Form.UmbCompare", "Passwords do not match.", "Password")]
    public string? ConfirmPassword { get; set; }
}
```

## How It Works

1. The validation attributes check Umbraco's dictionary for the provided key.
2. If a translation exists, it is used as the error message.
3. If no translation is found, the fallback message is displayed.
