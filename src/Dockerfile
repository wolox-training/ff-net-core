FROM microsoft/dotnet:2.2-sdk
WORKDIR /app
EXPOSE 80

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy and build everything else
COPY . ./
RUN dotnet publish -c Release -o out
CMD ASPNETCORE_URLS=http://*:$PORT dotnet out/src.dll