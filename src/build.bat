@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)

set version=1.0.0
if not "%PackageVersion%" == "" (
   set version=%PackageVersion%
)

set nuget=nuget\nuget.exe

nuget restore src\Swatcher.sln

%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild src\Swatcher.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false

mkdir Build
mkdir Build\lib
mkdir Build\lib\net45

nuget pack "src\Swatcher.nuspec" -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"
