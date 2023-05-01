FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY ./Books.Api/*.csproj ./Books.Api/
COPY ./Books.DataBase.SqlServer/*.csproj ./Books.DataBase.SqlServer/
COPY ./Books.Models/*.csproj ./Books.Models/
COPY ./BooksService/*.csproj ./BooksService/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Books.Api.dll"]