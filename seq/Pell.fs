namespace MathSequence

module Pell =
    type private State =
        {
            n: int
            Pn1: int
            Pn2: int
        }

    let private initialState =
        {
            n = 0
            Pn1 = 0
            Pn2 = 0
        }

    let private nextPn st =
        match st.n with
        | 0
        | 1 -> st.n
        | _ -> 2 * st.Pn1 + st.Pn2

    let private nextSt st pn =
        let nextSt =
            {
                n = st.n + 1
                Pn1 = pn
                Pn2 = st.Pn1
            }

        (pn, nextSt)

    let private pell initSt =
        initSt |> nextPn |> nextSt initSt |> Some

    let get n =
        initialState |> Seq.unfold pell |> Seq.truncate n
