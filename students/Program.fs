open System.IO
open StudentScores

[<EntryPoint>]
let main argv =
    match argv.Length with
    | 1 ->
        let filePath = argv |> Array.head
        if filePath |> File.Exists then
            printfn $"Handling file: %s{filePath}"
            Student.API.summarize filePath
            0
        else
            printfn "File not found: %s" filePath
            2
    | _ ->
        printfn "Please specify a file"
        1
