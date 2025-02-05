using AMD_x86;
using Domain;

namespace AMD_x86_Tests;

public class AMD_x86_NOP_Tests
{
    private readonly ICPUFasade _CPU;

    public AMD_x86_NOP_Tests()
    {
        _CPU = new AMD_x86_Fasade();
    }

    [Fact]
    public void COMPILE_ShouldBeEquivalent()
    {
        // Arrange
        byte[] expectedResult = [0x90];

        // Act
        var result = _CPU.NOP();

        // Assert
        Assert.Equal(result.Value, expectedResult);
    }
}
