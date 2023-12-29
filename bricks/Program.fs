open Brick
open System

printfn "All the bricks:"

Brick.bricks
|> Array.iter Brick.print

printfn "\n"

printfn "Count of the bricks"
Brick.bricks
|> Array.length
|> printfn "Count: %i\n"

printfn "Stud counts:"
Brick.bricks
|> Array.map Brick.studCount
|> Array.iter (printf "%i;")

printfn "\n"

printfn "Red bricks"
Brick.bricks
|> Array.filter (fun b -> b.Color = ConsoleColor.Red)
|> Array.iter Brick.print

printfn "\n"

printfn "Group by color"
Brick.bricks
|> Array.groupBy _.Color
|> Array.iter (fun (color, brick) ->
    printfn "\n%s" (color.ToString())
    brick |> Array.iter Brick.print
    printfn ""
)

printfn "Group by stud count"
Brick.bricks
|> Array.groupBy Brick.studCount
|> Array.sortBy fst
|> Array.iter (fun (count, brick) ->
    printf "%i " count
    brick |> Array.iter Brick.print
    printfn ""
)