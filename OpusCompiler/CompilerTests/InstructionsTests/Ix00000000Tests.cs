using Compiler.CompileStrategies;
using Domain;
using Domain.Result;
using Moq;

namespace CompilerTests.InstructionsTests;

public class Ix00000000Tests
{
    private readonly IOInstruction _instruction;
    private readonly Mock<ICPUFacade> _CPUMock;

    public Ix00000000Tests()
    {
        _CPUMock = new Mock<ICPUFacade>();
        _instruction = new Ix00000000(_CPUMock.Object);
    }

    [Fact]
    public void COMPILE_ShouldBeEquivalent()
    {
        // Arrange
        var expectedResult = CompilationResult<byte[]>.Success([0x90]);
        _CPUMock.Setup(cpu => cpu.NOP()).Returns(expectedResult);

        // Act
        var result = _instruction.COMPILE();

        // Assert
        Assert.Equivalent(result, expectedResult);
    }
}