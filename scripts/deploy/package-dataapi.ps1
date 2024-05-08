<#
.SYNOPSIS
Package Chat Copilot application for deployment to Azure
#>

param(
    [string]
    # Build configuration to publish.
    $BuildConfiguration = "Release",

    [string]
    # .NET framework to publish.
    $DotNetFramework = "net8.0",

    [string]
    # Target runtime to publish.
    $TargetRuntime = "win-x86",

    [string]
    # Output directory for published assets.
    $OutputDirectory = "$PSScriptRoot",

    [string]
    # Version to give to assemblies and files.
    $Version = "0.0.0",

    [string]
    # Additional information given in version info.
    $InformationalVersion = "",

    [bool]
    # Whether to skip building frontend files (false by default)
    $SkipFrontendFiles = $false
)

Write-Host "Building backend executables..."

Write-Host "BuildConfiguration: $BuildConfiguration"
Write-Host "DotNetFramework: $DotNetFramework"
Write-Host "TargetRuntime: $TargetRuntime"
Write-Host "OutputDirectory: $OutputDirectory"

$publishOutputDirectory = "$OutputDirectory/publish"
$publishedZipDirectory = "$OutputDirectory/out"
$publishedZipFilePath = "$publishedZipDirectory/dataapi.zip"
if (!(Test-Path $publishedZipDirectory)) {
    New-Item -ItemType Directory -Force -Path $publishedZipDirectory | Out-Null
}
if (Test-Path $publishOutputDirectory) {
    rm $publishOutputDirectory/* -r -force
}

New-Item -ItemType Directory -Force -Path $publishOutputDirectory | Out-Null

Write-Host "Build configuration: $BuildConfiguration"


dotnet publish "$PSScriptRoot/../../dataapi/DataApi.csproj" --configuration $BuildConfiguration --framework $DotNetFramework --runtime $TargetRuntime --self-contained --output "$publishOutputDirectory" /p:AssemblyVersion=$Version /p:FileVersion=$Version /p:InformationalVersion=$InformationalVersion
if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}


Write-Host "Compressing package to $publishedZipFilePath"
Compress-Archive -Path $publishOutputDirectory\* -DestinationPath $publishedZipFilePath -Force

Write-Host "Published package to '$publishedZipFilePath'"