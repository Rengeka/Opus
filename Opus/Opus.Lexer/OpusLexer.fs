namespace Opus.Lexer

open Opus.Contracts
open Opus.Grammar
open Opus.Kernel.Result
open Opus.Kernel.Enums
open FParsec

open InstructionLexer
open LiteralLexer

type OpusLexer() =
    
    let opusLexer: Parser<Token list, unit> =
        many (spaces >>. choice [ instrLexer; litLexer ] .>> spaces)

    interface ITokenizer with
        member _.Tokenize(code: string) : Result<Token[]> =
            match run opusLexer code with
            | Success(tokens, _, _) -> 
                Result<Token[]>.Success(tokens |> List.toArray)
            | Failure(msg, _, _) -> 
                Result<Token[]>.Failure(msg, ErrorCode.UnknownToken)