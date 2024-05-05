FROM mcr.microsoft.com/dotnet/core/sdk:8.0

WORKDIR /app

COPY PaymentAPI.csproj ./
COPY PaymentAPI.sln ./

RUN dotnet restore

RUN dotnet add package Microsoft.EntityFrameworkCore.SqlServer

COPY . .

RUN dotnet publish -c Release

EXPOSE 5199

RUN dotnet ef migrations apply

ENTRYPOINT ["dotnet", "PaymentAPI.API.dll"]