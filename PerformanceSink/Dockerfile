FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PerformanceSink.csproj", "./"]
RUN dotnet restore "PerformanceSink.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "PerformanceSink.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PerformanceSink.csproj" -c Release -o /app/publish

FROM base AS final
LABEL org.opencontainers.image.source=https://github.com/hounsvad/SoftwareArchitecture
LABEL org.opencontainers.image.description="A web api that recursively calculates pi by running 1700 recursions"
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PerformanceSink.dll"]
