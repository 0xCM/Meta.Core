# based on local file, see above instructions for how you can obtain package
# from internal repository and download it local
$srcPackage = "X:\Platform\choco\chocolatey.0.10.7.nupkg"
if (!(Test-Path($srcPackage))) {
  throw "No file exists at $srcPackage"
}

$tempDir = "C:\Tools\choco-test\temp"
if (![System.IO.Directory]::Exists($tempDir)) {
  [System.IO.Directory]::CreateDirectory($tempDir)
}

$tempInstallDir = "C:\Tools\choco-test\temp\install"
  if (![System.IO.Directory]::Exists($tempInstallDir)) {
    [System.IO.Directory]::CreateDirectory($tempInstallDir)
  }

$installDir = "C:\Tools\choco-test"
$env:ChocolateyInstall = $installDir
$env:Path += ";$installDir"
$DebugPreference = "Continue";

function Install-LocalChocolateyPackage {
  param ()
  
  $zipPath = Join-Path $tempInstallDir "chocolatey.zip"
  Copy-Item $srcPackage $zipPath -Force

  # unzip the package
  Write-Output "Extracting $zipPath to $tempDir..."
  $shellApplication = new-object -com shell.application
  $zipPackage = $shellApplication.NameSpace($zipPath)
  $destinationFolder = $shellApplication.NameSpace($tempDir)
  $destinationFolder.CopyHere($zipPackage.Items(),0x10)

  # Call chocolatey install
  Write-Output "Installing chocolatey on this machine"
  $toolsFolder = Join-Path $tempDir "tools"
  $chocInstallPS1 = Join-Path $toolsFolder "chocolateyInstall.ps1"

  & $chocInstallPS1

  Write-Output 'Ensuring chocolatey commands are on the path'
  $chocInstallVariableName = "ChocolateyInstall"
  $chocoPath = [Environment]::GetEnvironmentVariable($chocInstallVariableName)
  $chocoExePath = Join-Path $chocoPath 'bin'

  if ($($env:Path).ToLower().Contains($($chocoExePath).ToLower()) -eq $false) {
    $env:Path = [Environment]::GetEnvironmentVariable('Path',[System.EnvironmentVariableTarget]::Machine);
  }
}

# Idempotence - do not install Chocolatey if it is already installed
if (!(Test-Path $installDir)) {
  # Install Chocolatey
  Install-LocalChocolateyPackage $localChocolateyPackageFilePath
}