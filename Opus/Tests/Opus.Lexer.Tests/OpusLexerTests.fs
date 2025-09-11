module OpusParserTests

open Xunit
open Opus.Grammar.Enums
open Opus.Lexer
open Opus.Kernel.Enums
open Opus.Contracts

type OpusLexerTests() =
        
    let _lexer : ITokenizer = OpusLexer() :> ITokenizer

    [<Theory>]
    [<InlineData("Ix1A3F")>]
    [<InlineData("Ix000F Ix0ABC")>]
    member _.``Tokenize Should Return Instruction Tokens`` (input: string) =
        // Act
        let result = _lexer.Tokenize input

        // Assert
        Assert.True(result.IsSucess, "Parser should succeed")
        Assert.NotNull(result.Value)

        result.Value
        |> Array.iter (fun t -> Assert.Equal(TokenType.Instruction, t.Type))

    [<Theory>]
    [<InlineData("Ix123J")>]
    member _.``Tokenize Should Fail On Invalid Token`` (input: string) =
        
        // Act
        let result = _lexer.Tokenize input

        // Assert
        Assert.False(result.IsSucess, "Tokenizer should fail")
        Assert.NotNull(result.Error)
        Assert.Equal(ErrorCode.UnknownToken, result.Error.ErrorCode)