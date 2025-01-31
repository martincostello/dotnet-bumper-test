FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG TARGETARCH

COPY . /source
WORKDIR /source

RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet test --framework net6.0 --configuration Release

RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish ./src/Application --framework net6.0 --output /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true

COPY --from=build /app .

ENTRYPOINT ["./Application"]
