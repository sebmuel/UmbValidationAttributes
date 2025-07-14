using UmbValidationAttributes.Attributes;

namespace Umbraco.TestInstance.Models.Forms;

public class EmailAttributeFormModel
{
    [UmbEmailAddress("Forms.Attribute.Email", "Please Provide Email")]
    public string? Email { get; set; }
}