$pluginName = "GenerateApiDump.rbxm"
$destPath = "$env:localappdata\Roblox\Plugins\" + $pluginName

Copy-Item -Path $pluginName -Destination $destPath