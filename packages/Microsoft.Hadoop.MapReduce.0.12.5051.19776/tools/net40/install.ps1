param($installPath, $toolsPath, $package, $project)

$dir = split-Path $MyInvocation.MyCommand.Path;
& "$dir\0264f46efa614897b07c3d403bfd2ecb.ps1" $installPath $toolsPath $package $project;

