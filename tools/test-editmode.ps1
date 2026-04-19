param(
    [string]$UnityExe = "C:\Program Files\Unity\Hub\Editor\2021.3.45f2\Editor\Unity.exe"
)

$RepoRoot = Split-Path -Parent $PSScriptRoot
$LogDir = Join-Path $RepoRoot "Logs"
$ResultFile = Join-Path $LogDir "editmode-results.xml"
$LogFile = Join-Path $LogDir "editmode.log"

New-Item -ItemType Directory -Force -Path $LogDir | Out-Null

Write-Host "Running Unity EditMode tests..."
Write-Host "Project: $RepoRoot"
Write-Host "Unity : $UnityExe"

if (!(Test-Path $UnityExe)) {
    Write-Error "Unity executable not found: $UnityExe"
    exit 1
}

& $UnityExe `
    -batchmode `
    -quit `
    -projectPath $RepoRoot `
    -runTests `
    -testPlatform EditMode `
    -testResults $ResultFile `
    -logFile $LogFile

$ExitCode = $LASTEXITCODE

Write-Host "Unity exited with code: $ExitCode"
Write-Host "Test results: $ResultFile"
Write-Host "Log file: $LogFile"

exit $ExitCode