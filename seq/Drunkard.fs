namespace MathSequence

module Drunkard =
    type State =
        {
            x: int
            y: int
        }

    let private initialState =
        {
            x = 0
            y = 0
        }

    let private randomInt min max = System.Random().Next(min, max)

    let private MIN = -1
    let private MAX = 2

    let step st =
        let next =
            {
                x = st.x + randomInt MIN MAX
                y = st.y + randomInt MIN MAX
            }

        (next, next)

    let private drunkard initSt = initSt |> step |> Some

    let get n =
        initialState
        |> Seq.unfold drunkard 
        |> Seq.truncate n
        |> Seq.insertAt 0 initialState
