#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ConsoleForInterview/ConsoleForInterview.csproj", "ConsoleForInterview/"]
COPY ["HelperLibrary/HelperLibrary.csproj", "HelperLibrary/"]
RUN dotnet restore "ConsoleForInterview/ConsoleForInterview.csproj"
COPY . .
WORKDIR "/src/ConsoleForInterview"
RUN dotnet build "ConsoleForInterview.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsoleForInterview.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleForInterview.dll"]