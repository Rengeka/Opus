namespace Compiler;

[Flags]
public enum NextExpected
{
    Nothing = 0,
    Literal = 1,
    Module = 2,
    Identifier = 4,
}