using AMD_x86;
using Domain;
using BufferTable;

namespace AMD_x86_Tests;

public class AMD_x86_PUSH_imm16_32_Tests
{
    private readonly ICPUFasade _CPU;

    public AMD_x86_PUSH_imm16_32_Tests()
    {
        _CPU = new AMD_x86_Fasade();
    }

    [Fact]
    public void COMPILE_ShouldBeEquivalent_WhenRegister()
    {
        // Arrange
        IBuffer buffer = new RegisterBuffer(0x50);
        byte[] expectedResult = [0x50, 0x50];

        // Act
        var result = _CPU.PUSH(buffer);

        // Assert
        Assert.Equal(result.Value, [0x50, 0x50]);
    }
}