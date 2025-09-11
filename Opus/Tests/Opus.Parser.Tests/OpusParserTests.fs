module OpusParserTests

open Xunit
open Opus.Grammar.Enums
open OpusParser
open Opus.Kernel.Result
open Opus.Kernel.Enums

type OpusParserTests() =

    [<Theory>]
    [<InlineData("Ix1A3F")>]
    [<InlineData("Ix000F Ix0ABC")>]
    member _.``Parse Should Return Instruction Tokens`` (input: string) =
       
        // Act
        let result = parse input

        // Assert
        Assert.True(result.IsSucess, "Parser should succeed")
        Assert.NotNull(result.Value)

        result.Value
        |> List.iter (fun t -> Assert.Equal(TokenType.Instruction, t.Type))

    [<Theory>]
    [<InlineData("IxZZZZ")>]
    member _.``Parse Should Fail On Invalid Input`` (input: string) =
        
        // Act
        let result = parse input

        // Assert
        Assert.False(result.IsSucess, "Parser should fail")
        Assert.NotNull(result.Error)
        Assert.Equal(ErrorCode.UnknownToken, result.Error.ErrorCode)