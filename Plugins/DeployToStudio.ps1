$pluginName = "GenerateApiDump.rbxm"

$studioKey = "HKCU:\Software\Roblox\RobloxStudio"
$contentDir = Get-ItemPropertyValue -Path $studioKey -Name "ContentFolder"

$destPath = $contentDir + "/../BuiltInPlugins/" + $pluginName
Copy-Item -Path $pluginName -Destination $destPath