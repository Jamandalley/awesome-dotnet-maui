using System;
using System.Text.Json;
using Xunit;
using AwesomeDotnetMaui.UtilityExtension;

public class UtilityExtensionTests
{
    // Example serializable class for testing
    [Serializable]
    public class MyClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    [Fact]
    public void ConvertToByte_ShouldReturnByteArray()
    {
        // Arrange
        var obj = new MyClass { Name = "Alice", Age = 30 };

        // Act
        var byteArray = obj.ConvertToByte();

        // Assert
        Assert.NotNull(byteArray);
        Assert.NotEmpty(byteArray);
    }

    [Fact]
    public void ConvertFromByte_ShouldReturnObject()
    {
        // Arrange
        var obj = new MyClass { Name = "Bob", Age = 40 };
        var byteArray = obj.ConvertToByte();

        // Act
        var result = byteArray.ConvertFromByte<MyClass>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Bob", result.Name);
        Assert.Equal(40, result.Age);
    }

    [Fact]
    public void ConvertFromByte_ShouldThrowArgumentNullException_ForNullArray()
    {
        // Arrange
        byte[] nullArray = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => nullArray.ConvertFromByte<MyClass>());
        Assert.Equal("Byte array cannot be null or empty. (Parameter 'byteArray')", exception.Message);
    }

    [Fact]
    public void ConvertToByte_ShouldThrowArgumentNullException_ForNullObject()
    {
        // Arrange
        MyClass nullObject = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => nullObject.ConvertToByte());
        Assert.Equal("Object cannot be null. (Parameter 'obj')", exception.Message);
    }
}
