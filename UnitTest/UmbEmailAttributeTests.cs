using UmbValidationAttributes.Attributes;

namespace UnitTest;

public class UmbEmailAttributeTests
{
    [Theory]
    [InlineData("b.pollok@med.uni-goettingen.de", true)]
    [InlineData("rohde@paediat.med.uni-giessen.de", true)]
    [InlineData("user@123.123.123.123", true)]
    [InlineData("john.doe@example.com", true)]
    [InlineData("max.mustermann@example-domain.com", true)]
    [InlineData("user123@sub.domain.co.uk", true)]
    [InlineData("jane_doe+test123@example-domain.org", true)]
    [InlineData("a!#$%&'*+/=?^_`{|}~-@example.io", true)]
    [InlineData("firstname.lastname@company123.de", true)]
    [InlineData("simple@example.co", true)]
    [InlineData("x@y.z", true)]
    [InlineData("very.common@example.com", true)]
    [InlineData("disposable.style.email.with+symbol@example.com", true)]
    [InlineData("user_name@sub-domain.example.com", true)]
    [InlineData("user@domain.c", true)]
    [InlineData("max..mustermann@example.com", false)]
    [InlineData(".user@example.com", false)]
    [InlineData("user.@example.com", false)]
    [InlineData("user@-example.com", false)]
    [InlineData("user@example..com", false)]
    [InlineData("user@example.com-", false)]
    [InlineData("user@example_com", false)]
    [InlineData("user@.example.com", false)]
    [InlineData("user@exam!ple.com", false)]
    public void Test1(string email, bool expected)
    {
        // Arrange
        var attribute = new UmbEmailAddressAttribute("test", "y");
        
        // Act
        var result = attribute.IsValid(email);
        
        // Assert
        Assert.Equal(expected, result);
    }
}