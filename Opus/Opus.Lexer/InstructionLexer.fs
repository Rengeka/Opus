module InstructionLexer

open System
open Opus.Grammar
open FParsec
open Opus.Grammar.Enums

let hexDigit: Parser<char, unit> = satisfy (fun c -> Char.IsDigit(c) || ('a' <= c && c <= 'f') || ('A' <= c && c <= 'F')) <?> "hex digit"

let instrLexer: Parser<Token, unit> =
    pstring "Ix" >>. parray 4 hexDigit .>> notFollowedBy (letter <|> digit)
    |>> fun chars -> Token(TokenType.Instruction, "Ix" + String(chars))