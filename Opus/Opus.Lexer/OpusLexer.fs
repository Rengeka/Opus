namespace Opus.Lexer

open Opus.Contracts
open Opus.Grammar
open Opus.Kernel.Result
open Opus.Kernel.Enums
open FParsec
open InstructionLexer

type OpusLexer() =
    
    let opusLexer: Parser<Token list, unit> =
        many (spaces >>. instrLexer .>> spaces)

    interface ITokenizer with
        member _.Tokenize(code: string) : CompilationResult<Token[]> =
            match run opusLexer code with
            | Success(tokens, _, _) -> 
                CompilationResult<Token[]>.Success(tokens |> List.toArray)
            | Failure(msg, _, _) -> 
                CompilationResult<Token[]>.Failure(msg, ErrorCode.UnknownToken)