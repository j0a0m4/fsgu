namespace StudentScores

module Student =
    module Score =
        type Score =
            {
                Mean: float
                Min: float
                Max: float
            }

        let notExcused tr = (tr = TestResult.Excused) |> not

        let from (data: array<string>) =
            let score =
                data
                |> Array.map TestResult.from
                |> Array.filter notExcused
                |> Array.choose TestResult.tryEffectiveScore

            {
                Mean = score |> Array.average
                Min = score |> Array.min
                Max = score |> Array.max
            }

    module Name =
        type Name =
            {
                Surname: string
                Given: string
            }

        let from (s: string) =
            let elements = s.Split (',')

            {
                Surname = elements[0].Trim ()
                Given = elements[1].Trim ()
            }

    type Student =
        {
            ID: string
            Name: Name.Name
            Score: Score.Score
        }

    let from (s: string) : Student =
        let data = s.Split ('\t')

        {
            ID = data[1]
            Name = data[0] |> Name.from
            Score = data |> Array.skip 2 |> Score.from
        }

    let toString (s: Student) =
        $"ID: %s{s.ID}\t"
        + $"Name: %s{s.Name.Surname},%s{s.Name.Given}\t"
        + $"Mean: %0.1f{s.Score.Mean}\t"
        + $"Min: %0.1f{s.Score.Min}\t"
        + $"Max: %0.1f{s.Score.Max}"

    module API =
        open System.IO

        let readFile (filePath: string) : array<Student> =
            filePath
            |> File.ReadAllLines
            |> Array.skip 1
            |> Array.map from

        let printCount students =
            students |> Array.length |> printfn "Students count: %i"

        let printBy func students =
            students
            |> func
            |> Array.map toString
            |> Array.iter (printfn "%s")

        let summarize filePath =
            let students = filePath |> readFile

            students |> printCount

            students
            |> printBy (
                Array.sortByDescending (fun s -> s.Score.Mean)
            )

            students |> printBy (Array.sortBy (fun s -> s.Name))
