module IdentifierLexer

open Opus.Grammar
open FParsec

let identifier: Parser<string, unit> =
    many1SatisfyL (fun c -> System.Char.IsLetterOrDigit(c) || c = '_') "identifier"