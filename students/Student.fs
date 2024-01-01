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

        let from (data: seq<string>) =
            let score =
                data
                |> Seq.map TestResult.from
                |> Seq.filter notExcused
                |> Seq.choose TestResult.tryEffectiveScore

            {
                Mean = score |> Seq.average
                Min = score |> Seq.min
                Max = score |> Seq.max
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
            Score = data |> Seq.skip 2 |> Score.from
        }

    let toString (s: Student) =
        $"ID: %s{s.ID}\t"
        + $"Name: %s{s.Name.Surname},%s{s.Name.Given}\t"
        + $"Mean: %0.1f{s.Score.Mean}\t"
        + $"Min: %0.1f{s.Score.Min}\t"
        + $"Max: %0.1f{s.Score.Max}"

    module API =
        open System.IO

        let readFile (filePath: string) : seq<Student> =
            filePath |> File.ReadLines |> Seq.skip 1 |> Seq.map from

        let printCount students =
            students |> Seq.length |> printfn "Students count: %i"

        let printBy func students =
            students
            |> func
            |> Seq.map toString
            |> Seq.iter (printfn "%s")

        let printBySurname (sn: string, sts: seq<Student>) =
            printfn "%s" (sn.ToUpperInvariant())

            sts
            |> Seq.sortBy (fun s -> s.Name.Given, s.ID)
            |> Seq.map toString
            |> Seq.iter (printfn "\t%s")

        let summarize filePath =
            let students = filePath |> readFile |> Seq.cache

            printfn "\nStudents Summary:"
            students |> printCount

            printfn "\nStudents sorted by descending mean score:"
            students |> printBy (Seq.sortByDescending _.Score.Mean)

            printfn "\nStudents sorted by ascending given name:"
            students |> printBy (Seq.sortBy _.Name.Given)

            printfn "\nStudents grouped by ascending surname:"

            students
            |> Seq.groupBy _.Name.Surname
            |> Seq.iter printBySurname
