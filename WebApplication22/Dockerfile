FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WebApplication22/Visma.Training.Serverless.Web.csproj", "WebApplication22/"]
COPY ["Visma.Training.Serverless.ServiceBus/Visma.Training.Serverless.ServiceBus.csproj", "Visma.Training.Serverless.ServiceBus/"]
RUN dotnet restore "WebApplication22/Visma.Training.Serverless.Web.csproj"
COPY . .
WORKDIR "/src/WebApplication22"
RUN dotnet build "Visma.Training.Serverless.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Visma.Training.Serverless.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Visma.Training.Serverless.Web.dll"]