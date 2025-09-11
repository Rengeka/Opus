module Tests

open Xunit
open FParsec
open Opus.Grammar.Enums
open InstructionParser

[<Theory>]
[<InlineData("Ix0001")>]
[<InlineData("Ix1234")>]
[<InlineData("IxFFFF")>]
[<InlineData("IxABCD")>]
[<InlineData("Ix00FF")>]
let ``Parse Instruction Should Be Equal`` (input: string) =
    
    // Act
    let result = run instrParser input

    // Assert
    match result with
    | Success(token, _, _) ->
        Assert.Equal(TokenType.Instruction, token.Type)
        Assert.Equal(input, token.Value)
    | Failure(msg, _, _) ->
        Assert.True(false, $"Parsing failed for input '{input}': {msg}")

[<Theory>]
[<InlineData("I0001")>]
[<InlineData("Ix11234")>]
[<InlineData("xFFFF")>]
[<InlineData("")>]
[<InlineData("Ix00JF")>]
let ``Parse Instruction Should Be Error`` (input: string) =
    
    // Act
    let result = run instrParser input

    // Assert
    match result with
    | Success(token, _, _) ->
        Assert.True(false, $"Expected failure but got success with token: {token.Value}")
    | Failure(_, _, _) ->
        Assert.True(true)