module OpusParserTests

open Xunit
open Opus.Grammar.Enums
open OpusLexer
open Opus.Kernel.Enums

type OpusLexerTests() =

    [<Theory>]
    [<InlineData("Ix1A3F")>]
    [<InlineData("Ix000F Ix0ABC")>]
    member _.``Tokenize Should Return Instruction Tokens`` (input: string) =
       
        // Act
        let result = tokenize input

        // Assert
        Assert.True(result.IsSucess, "Parser should succeed")
        Assert.NotNull(result.Value)

        result.Value
        |> List.iter (fun t -> Assert.Equal(TokenType.Instruction, t.Type))

    [<Theory>]
    [<InlineData("IxZZZZ")>]
    member _.``Tokenize Should Fail On Invalid Token`` (input: string) =
        
        // Act
        let result = tokenize input

        // Assert
        Assert.False(result.IsSucess, "Tokenizer should fail")
        Assert.NotNull(result.Error)
        Assert.Equal(ErrorCode.UnknownToken, result.Error.ErrorCode)