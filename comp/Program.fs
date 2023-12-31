[|
    for num in 1..1000 -> num * num
|]
|> Array.sum
|> printfn "Sum: %i"

Array.init 1001 (fun n -> pown n 2)
|> Array.sum
|> printfn "Sum: %i"