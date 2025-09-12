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
    member _.``Tokenize Instructions Should Be Equal`` (input: string) =
        // Act
        let result = _lexer.Tokenize input

        // Assert
        Assert.True(result.IsSucess, "Parser should succeed")
        Assert.NotNull(result.Value)

        result.Value
        |> Array.iter (fun t -> Assert.Equal(TokenType.Instruction, t.Type))

    [<Theory>]
    [<InlineData("Ix123J")>]
    member _.``Tokenize Instructions Should Be Error`` (input: string) =
        
        // Act
        let result = _lexer.Tokenize input

        // Assert
        Assert.False(result.IsSucess, "Tokenizer should fail")
        Assert.NotNull(result.Error)
        Assert.Equal(ErrorCode.UnknownToken, result.Error.ErrorCode)


    [<Theory>]
    [<InlineData("123", "123")>]
    [<InlineData("456.78", "456.78")>]
    [<InlineData("\"hello\"", "hello")>]
    member _.``Tokenize Literals Should Be Equal`` (input: string, expected: string) =

        // Act
        let result = _lexer.Tokenize input

        // Assert
        Assert.True(result.IsSucess, "Parser should succeed")
        Assert.NotNull(result.Value)
        Assert.Single(result.Value)
        Assert.Equal(TokenType.Literal, result.Value.[0].Type)
        Assert.Equal(expected, result.Value.[0].Value)

    [<Theory>]
    [<InlineData("Ix1A3F 123")>]
    [<InlineData("\"test\" Ix0ABC")>]
    [<InlineData("Ix000F 123.45 \"foo\"")>]
    member _.``Tokenize Literals Should Be Ture`` (input: string) =

        // Act
        let result = _lexer.Tokenize input

        // Assert
        Assert.True(result.IsSucess, "Parser should succeed")
        Assert.NotNull(result.Value)
        Assert.NotEmpty(result.Value)

        result.Value
        |> Array.iter (fun t ->
            Assert.True(
                t.Type = TokenType.Instruction || t.Type = TokenType.Literal,
                "Unexpected token type"
            )
        )