function CPU { Get-Process | Where-Object {$_.CPU -ge 10} }

function SetSessionValue ($name, $value){ Set-Variable -Name $name -Value $value -Scope global -Visibility Public}
function GetSessionValue ($name){ Get-Variable -Name $name }

function MSDN {
    $a = Get-Content MSDN.txt
    for($i=0;$i -lt $a.Length;$i++){
        if ($a[$i] -like "*PowerShell*"){
            $i
        }
    }
}

function Salary {
    Import-Csv employees.csv | 
    Select-Object *,@{Name='Month Salary';Expression={[math]::Round($_.SALARY/12, 2)}} | 
    Sort-Object 'Month Salary' |
    Format-Table
}

function RSS {
    $chfeed = [xml](Get-Content PowerShell.rss)
    $chfeed.rss.channel.item | Select-Object title
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