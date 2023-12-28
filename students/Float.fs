namespace StudentScores

module Float =
    let tryFloat (s: string) =
        match s with
        | "N/A" -> None
        | _ -> Some (float s)

    let getOrDefault (f: float) (s: string) =
        s |> tryFloat |> Option.defaultValue f
