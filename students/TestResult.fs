namespace StudentScores

module TestResult = 
    type TestResult =
        | Absent
        | Excused
        | Voided
        | Scored of float
    
    let from s =
        match s with
        | "A" -> Absent
        | "E" -> Excused
        | "V" -> Voided
        | _ -> Scored (s |> float)

    let tryEffectiveScore (testResult: TestResult) =
        match testResult with
        | Scored score -> Some score
        | Absent -> Some 0.0
        | Excused 
        | Voided -> None