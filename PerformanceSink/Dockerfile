FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
LABEL org.opencontainers.image.source = "https://github.com/Hounsvad/SoftwareArchitecture-sdu"
LABEL org.opencontainers.image.description = "A web api that recursively calculates pi by running 1700 recursions"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PerformanceSink.csproj", "./"]
RUN dotnet restore "PerformanceSink.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "PerformanceSink.csproj" -c Release -o /app/build
LABEL org.opencontainers.image.source = "https://github.com/Hounsvad/SoftwareArchitecture-sdu"
LABEL org.opencontainers.image.description = "A web api that recursively calculates pi by running 1700 recursions"

FROM build AS publish
RUN dotnet publish "PerformanceSink.csproj" -c Release -o /app/publish
LABEL org.opencontainers.image.source = "https://github.com/Hounsvad/SoftwareArchitecture-sdu"
LABEL org.opencontainers.image.description = "A web api that recursively calculates pi by running 1700 recursions"

FROM base AS final
LABEL org.opencontainers.image.source = "https://github.com/Hounsvad/SoftwareArchitecture-sdu"
LABEL org.opencontainers.image.description = "A web api that recursively calculates pi by running 1700 recursions"
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PerformanceSink.dll"]
