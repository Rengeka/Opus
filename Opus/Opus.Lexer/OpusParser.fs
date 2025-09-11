module OpusLexer

open InstructionLexer

open FParsec
open Opus.Grammar
open Opus.Kernel.Result
open Opus.Kernel.Enums

let opusLexer: Parser<Token list, unit> =
    many (spaces >>. instrLexer .>> spaces(* <|> directiveParser <|> moduleParser <|> literalParser*) )

let tokenize (input: string) : CompilationResult<Token list> =
    match run opusLexer input with
    | Success(tokens, _, _) -> CompilationResult<Token list>.Success(tokens)
    | Failure(msg, _, _) -> CompilationResult<Token list>.Failure(msg, ErrorCode.UnknownToken)