open System.IO
open System
open StudentScores

[<EntryPoint>]
let main argv =
    match argv.Length with
    | 2 ->
        let schoolCodes = argv |> Array.head
        let studentRecords = argv[1]

        if schoolCodes |> File.Exists then
            printfn $"Handling file: %s{schoolCodes}"

            try
                studentRecords |> Student.API.summarize schoolCodes
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
            printfn "File not found: %s" schoolCodes
            2
    | _ ->
        printfn
            "Please specify a file for student codes and another for student records"

        1
