using BufferTable;
using Compiler;
using Compiler.CompileStrategies;
using Domain;
using Moq;

namespace CompilerTests.InstructionsTests;

public class Ix00000001Tests
{
    private readonly IOInstruction _instruction;
    private readonly Mock<ICPUFacade> _CPUMock;
    private readonly Mock<BufferTableFasade> _bufferTableFacadeMock;

    public Ix00000001Tests()
    {
        _CPUMock = new Mock<ICPUFacade>();
        _bufferTableFacadeMock = new Mock<BufferTableFasade>();
        _instruction = new Ix00000001(_CPUMock.Object, _bufferTableFacadeMock.Object);
    }

    [Fact]
    public void COMPILE_ShouldBeequivalent()
    {
        // Arrange
        //_CPUMock.Setup(cpu => cpu.MOV);

        // Act


        // Assert


    }
}