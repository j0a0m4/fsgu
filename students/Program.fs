open System.IO
open System
open StudentScores

[<EntryPoint>]
let main argv =
    match argv.Length with
    | 1 ->
        let filePath = argv |> Array.head

        if filePath |> File.Exists then
            printfn $"Handling file: %s{filePath}"

            try
                Student.API.summarize filePath
                0
            with
            | :? FormatException as e ->
                printfn "Error: %s" e.Message
                printfn "The file was not in the expected format."
                3
            | :? IOException as e ->
                printfn "Error: %s" e.Message

                printfn
                    "The file is opened in another program, please close it."

                4
            | _ as e ->
                printfn "An unexpected error occurred: %s" e.Message
                5
        else
            printfn "File not found: %s" filePath
            2
    | _ ->
        printfn "Please specify a file"
        1
