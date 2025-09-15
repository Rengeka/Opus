module LiteralLexerUnitTests

open Xunit
open FParsec
open Opus.Grammar.Enums
open LiteralLexer

let private parseLiteral (input: string) =
    match run litLexer input with
    | Success(result, _, _) -> Some result
    | Failure(_, _, _) -> None

[<Fact>]
let ``Tokenize Int Literal Should Be Equal`` () =
    // Arrange
    let input = "123"

    // Act
    let result = parseLiteral input

    // Assert
    match result with
    | Some token ->
        Assert.Equal(TokenType.Literal, token.Type)
        Assert.Equal("123", token.Value)
    | None ->
        Assert.Fail("Failed to parse int literal")

[<Fact>]
let ``Tokenize Float Literal Should Be Equal`` () =
    // Arrange
    let input = "123.45"

    // Act
    let result = parseLiteral input

    // Assert
    match result with
    | Some token ->
        Assert.Equal(TokenType.Literal, token.Type)
        Assert.Equal("123.45", token.Value)
    | None ->
        Assert.Fail("Failed to parse float literal")

[<Fact>]
let ``Tokenize String Literal Should Be Equal`` () =
    // Arrange
    let input = "\"hello\""

    // Act
    let result = parseLiteral input

    // Assert
    match result with
    | Some token ->
        Assert.Equal(TokenType.Literal, token.Type)
        Assert.Equal("hello", token.Value)
    | None ->
        Assert.Fail("Failed to parse string literal")

[<Fact>]
let ``Tokenize Should Be Error`` () =
    // Arrange
    let input = "abc"

    // Act
    let result = parseLiteral input

    // Assert
    Assert.True(result.IsNone, "Expected parse failure on invalid literal")