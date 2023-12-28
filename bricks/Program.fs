open Brick

printfn "All the bricks:"

Brick.bricks
|> Array.iter Brick.print

printfn "\n"