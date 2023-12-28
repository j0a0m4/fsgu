open Points.Point

let pFloat1 =
    {
        X = 1.0
        Y = 2.0
    }

let pFloat2 = pFloat1 |> moveBy 3.0 4.0

printfn "pFloat1: %A pFloat2: %A" pFloat1 pFloat2

let pInt1 =
    {
        X = 1
        Y = 2
    }

let pInt2 = pInt1 |> moveBy 3 4

printfn "pInt1: %A pInt2: %A" pInt1 pInt2