@echo off
echo Fetching Roblox version...

for /F "delims=" %%I in ('curl -s https://raw.githubusercontent.com/MaximumADHD/Roblox-Client-Tracker/refs/heads/roblox/version.txt') do (
    set "RBX_VERSION=%%I"
)

echo Version is: %RBX_VERSION%

echo Updating API...
cd Update

RobloxFileFormat.Update.exe
if %errorlevel% NEQ 0 goto updateError

echo Syncing w/ GitHub
git pull

echo Building RobloxFileFormat.dll
cd ..

msbuild RobloxFileFormat.csproj /p:Configuration=Release
if %errorlevel% NEQ 0 goto updateError

echo Committing...
git add .
git commit -m %RBX_VERSION%
git push

echo Finished!
goto done

:updateError
echo Something went wrong while updating! Error Code: %errorlevel%
goto done

:buildError
echo Something went wrong while building! Error Code: %errorlevel%
goto done

:done
exit