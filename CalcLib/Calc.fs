﻿namespace IofXmlLib

module Calc =

    type CalculationRule(calcFunction, format) =
        member this.Execute wt rt pos = calcFunction wt rt pos
        member this.FormatPoints (points : decimal) = sprintf format points

    let calcPointsFromPosition _ _ pos =
        match pos with
        | 1 -> 25m
        | 2 -> 20m
        | 3 -> 16m
        | 4 -> 13m
        | 5 -> 11m
        | 6 -> 10m
        | 7 -> 9m
        | 8 -> 8m
        | 9 -> 7m
        | 10 -> 6m
        | 11 -> 5m
        | 12 -> 4m
        | 13 -> 3m
        | 14 -> 2m
        | 15 -> 1m
        | _ -> 0m
    
    let calcPointsFromTime winningTime time _ =
        let p = 100m - (((time - winningTime) / winningTime) * 50m)
        if p < 0m then 0m
        else p

    let sum _ time _ =
        time
    let getCalcStrategy calcRule =
        match calcRule with
            | "time" -> CalculationRule(calcPointsFromTime, "%.2f")
            | "position" -> CalculationRule(calcPointsFromPosition, "%.0f")
            | _ -> CalculationRule(sum, "%.2f")
    


