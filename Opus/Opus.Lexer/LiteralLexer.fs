module LiteralLexer

open Opus.Grammar
open FParsec
open Opus.Grammar.Enums

let strLiteral: Parser<Token, unit> =
    between (pchar '"') (pchar '"') (manyChars (noneOf ['"']))
    |>> fun s -> Token(TokenType.Literal, s)

let floatLiteral: Parser<Token, unit> =
    attempt (many1Chars digit .>>. (pchar '.' >>. many1Chars digit))
    |>> fun (intPart, fracPart) ->
        let text = intPart + "." + fracPart
        Token(TokenType.Literal, text)

let intLiteral: Parser<Token, unit> =
    many1Chars digit
    |>> fun digits -> Token(TokenType.Literal, digits)

let litLexer: Parser<Token, unit> =
    choice [
        strLiteral
        floatLiteral
        intLiteral
    ]