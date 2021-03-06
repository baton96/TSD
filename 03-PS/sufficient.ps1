function Multiply($a, $b){
    return $a * $b
}

function Increment {
    [CmdletBinding()]
    param(
        [Parameter(mandatory=$true)]
        [int]$a,
        [int]$b=1
    )
    $a+$b
}

function Date { Get-Date -f "dddd, MMMM dd, yyyy" }

function GroupByExtension { Get-ChildItem | Group-Object -Property extension -NoElement }

function GroupByExtension {
    $extensions = Get-ChildItem | Select-Object -Unique Extension | Where-Object {$_.Extension -ne ''}
    foreach ($extension in $extensions) {
        Write-Host 'Extension:' $extension.Extension
        $files = Get-ChildItem |  Where-Object {$_.Name -match $extension.Extension}
        foreach ($file in $files) { Write-Host $file.Name }
        Write-Host
    }
}

function SortByName { Get-ChildItem | Sort-Object Name | Select-Object Name, Length }

function HiddenFiles { Get-ChildItem -Recurse -Force | Where-Object {$_.Name -eq 'desktop.ini'} }

function BiggerThan1MB { Get-ChildItem -Recurse | Where-Object {$_.Length -gt 1MB} }

function GridView { SortByName | Where-Object {$_.Length -ge 1MB} | Out-GridView }