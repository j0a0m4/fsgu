namespace Brick

open System

module Brick =
    type Brick =
        {
            StudColumns: int
            StudRows: int
            Color: ConsoleColor
        }
    
    let studCount b = b.StudColumns * b.StudRows

    let bricks =
        [|
            (3, 2, ConsoleColor.Yellow)
            (4, 2, ConsoleColor.Green)
            (2, 1, ConsoleColor.Magenta)
            (1, 1, ConsoleColor.Blue)
            (2, 2, ConsoleColor.Red)
            (4, 2, ConsoleColor.Blue)
            (4, 2, ConsoleColor.Magenta)
            (2, 2, ConsoleColor.Magenta)
            (2, 2, ConsoleColor.Red)
            (4, 2, ConsoleColor.Blue)
            (3, 2, ConsoleColor.Magenta)
            (4, 2, ConsoleColor.Green)
            (3, 2, ConsoleColor.Red)
            (4, 1, ConsoleColor.Blue)
            (4, 2, ConsoleColor.Yellow)
            (4, 2, ConsoleColor.Yellow)
            (1, 1, ConsoleColor.Blue)
            (1, 1, ConsoleColor.Green)
            (2, 1, ConsoleColor.Yellow)
            (4, 1, ConsoleColor.Magenta)
        |]
        |> Array.map (fun (col, row, color) ->
            {
                StudColumns = col
                StudRows = row
                Color = color
            }
        )
    
    let toString (brick: Brick) =
        let rowChar =
            match brick.StudRows with
            | 1 -> "·"
            | 2 -> ":"
            | _ -> raise <| ArgumentException("Unsupported row count")

        let pattern = String.replicate brick.StudColumns rowChar
        let label = brick.Color.ToString().Substring(0, 1)
        (label, pattern)

    let print (brick: Brick) =
        let (label, pattern) = brick |> toString
        printf "%s " label
        
        Console.BackgroundColor <- brick.Color
        Console.ForegroundColor <- ConsoleColor.Black
        printf "[%s]" pattern
        
        Console.ResetColor()
        printf " "
