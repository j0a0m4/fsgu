namespace Points

module Point =
    type Point<'T> =
        {
            X: 'T
            Y: 'T
        }
    
    let inline moveBy (dx: 'T) (dy: 'T) (p: Point<'T>) =
        {
            X = p.X + dx
            Y = p.Y + dy
        }