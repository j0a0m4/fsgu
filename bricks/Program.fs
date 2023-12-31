open Brick
open System

printfn "All the bricks:"

Brick.bricks
|> Seq.iter Brick.print

printfn "\n"

printfn "Count of the bricks"
Brick.bricks
|> Seq.length
|> printfn "Count: %i\n"

printfn "Stud counts:"
Brick.bricks
|> Seq.map Brick.size
|> Seq.iter (printf "%i;")

printfn "\n"

printfn "Red bricks"
Brick.bricks
|> Seq.filter (fun b -> b.Color = ConsoleColor.Red)
|> Seq.iter Brick.print

printfn "\n"

printfn "Group by color"
Brick.bricks
|> Seq.groupBy _.Color
|> Seq.iter (fun (color, brick) ->
    printfn "\n%s" (color.ToString())
    brick |> Seq.iter Brick.print
    printfn ""
)

printfn "Group by stud count"
Brick.bricks
|> Seq.groupBy Brick.size
|> Seq.sortBy fst
|> Seq.iter (fun (count, brick) ->
    printf "%i " count
    brick |> Seq.iter Brick.print
    printfn ""
)