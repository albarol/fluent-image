@echo off

%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe app/ImageNet.sln /t:Clean,Rebuild /p:AllowUnsafeBlocks=true;Configuration=Release

if not exist Download\Package\lib\net35 mkdir Download\Package\lib\net35

copy app\src\ImageNet\bin\Release\ImageNet.dll Download\Package\lib\net35

.\.nuget\NuGet.exe update -self
.\.nuget\NuGet.exe pack FluentImage.nuspec -BasePath Download\Package -Output Download