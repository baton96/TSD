function SortingPerformance {
    $a = New-Object System.Collections.Generic.List[int]
    for($i=0;$i -lt 10000;$i++){
        $r = Get-Random
        $a.Add($r)
    }
    Measure-Command { $a | Sort-Object }
    Measure-Command { $a.Sort() }
}