namespace Brick

open System

module Brick =
    type Brick =
        {
            StudColumns: int
            StudRows: int
            Color: ConsoleColor
        }

    let from (color: ConsoleColor) (cols: int, rows: int) =
        {
            Color = color
            StudColumns = cols
            StudRows = rows
        }

    let size b = b.StudColumns * b.StudRows

    let bricks =
        [|
            ConsoleColor.Yellow,
            [|
                3, 2
                4, 2
                4, 2
                2, 1
            |]
            ConsoleColor.Green,
            [|
                4, 2
                4, 2
                1, 1
            |]
            ConsoleColor.Magenta,
            [|
                2, 1
                4, 2
                2, 2
                3, 2
                4, 1
            |]
            ConsoleColor.Blue,
            [|
                1, 1
                4, 2
                4, 2
                4, 1
                1, 1
            |]
            ConsoleColor.Red,
            [|
                2, 2
                2, 2
                3, 2
            |]
        |]
        |> Seq.collect (fun (color, pairs) ->
            pairs |> Seq.map (from color)
        )
        |> Seq.cache

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
