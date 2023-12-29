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
            let elements = s.Split(',')

            {
                Surname = elements[0].Trim()
                Given = elements[1].Trim()
            }

    type Student =
        {
            ID: string
            Name: Name.Name
            Score: Score.Score
        }

    let from (s: string) : Student =
        let data = s.Split('\t')

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

        let printBySurname (sn: string, sta: array<Student>) =
            printfn "%s" (sn.ToUpperInvariant())

            sta
            |> Array.sortBy (fun s -> s.Name.Given, s.ID)
            |> Array.map toString
            |> Array.iter (printfn "\t%s")

        let summarize filePath =
            let students = filePath |> readFile

            printfn "\nStudents Summary:"
            students |> printCount

            printfn "\nStudents sorted by descending mean score:"
            students |> printBy (Array.sortByDescending _.Score.Mean)

            printfn "\nStudents sorted by ascending given name:"
            students |> printBy (Array.sortBy _.Name.Given)

            printfn "\nStudents grouped by ascending surname:"

            students
            |> Array.groupBy _.Name.Surname
            |> Array.iter printBySurname
