namespace Opus.Grammar.Enums;

[Flags]
internal enum NextExpected
{
    EOF = 0,
    Identifier = 1,
    Literal = 2,
}