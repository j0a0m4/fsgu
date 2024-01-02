namespace MathSequence

module Fibonacci =
    type State =
        {
            n: int
            Fn1: int
            Fn2: int
        }

    let private initialState =
        {
            n = 0
            Fn1 = 0
            Fn2 = 0
        }

    let private nextFn st =
        match st.n with
        | 0
        | 1 -> st.n
        | _ -> st.Fn1 + st.Fn2

    let private nextSt st fn =
        let next =
            {
                n = st.n + 1
                Fn1 = fn
                Fn2 = st.Fn1
            }

        (fn, next)

    let private fibo initSt =
        initSt |> nextFn |> nextSt initSt |> Some
    
    let get n =
        initialState |> Seq.unfold fibo |> Seq.truncate n