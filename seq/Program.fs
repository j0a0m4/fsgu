open MathSequence

let printSequence s =
    s |> Seq.iter (printf "%i, ")
    printfn "..."

Pell.get 10 |> printSequence

Fibonacci.get 10 |> printSequence

Drunkard.get 20
|> Seq.iter (fun st -> printf "(%i, %i), " st.x st.y)
printfn "..."
