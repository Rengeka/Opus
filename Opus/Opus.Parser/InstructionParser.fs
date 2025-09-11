module InstructionParser

open Opus.Grammar
open FParsec
open Opus.Grammar.Enums

let hexDigit: Parser<char, unit> = satisfy (fun c -> System.Char.IsDigit(c) || ('a' <= c && c <= 'f') || ('A' <= c && c <= 'F')) <?> "hex digit"

let instrParser: Parser<Token, unit> =
    between (pstring "Ix") eof (parray 4 hexDigit)
    |>> fun chars -> Token(TokenType.Instruction, "Ix" + System.String(chars))