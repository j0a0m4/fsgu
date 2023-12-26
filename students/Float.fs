namespace StudentScores

module Float =
    let valueOf (s: string) : option<float> =
        match s with
        | "N/A" -> None
        | _ ->  Some (float s)
    
    let getOrDefault (f: float) (s: string) : float =
        s 
        |> valueOf
        |> Option.defaultValue f