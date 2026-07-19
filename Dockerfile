 # --- Stage 1: Base Runtime ---                                                                                                                                     
# This is the lightweight base image used to execute the app                                                                                                        
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base                                                                                                                    
WORKDIR /app                                                                                                                                                        
EXPOSE 8080                                                                                                                                                         
ENV ASPNETCORE_ENVIRONMENT=Development                                                                                                                              
ENV ASPNETCORE_HTTP_PORTS=8080                                                                                                                                      
                                                                                                                                                                    
# --- Stage 2: Build & Publish ---                                                                                                                                  
# This stage uses the full SDK to restore and compile the app                                                                                                       
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build                                                                                                                      
WORKDIR /src                                                                                                                                                        
                                                                                                                                                                    
# 1. Copy project file first to leverage Docker layer caching for NuGet restore                                                                                     
COPY ["TodoList.csproj", "./"]                                                                                                                                      
RUN dotnet restore "TodoList.csproj"                                                                                                                                
                                                                                                                                                                    
# 2. Copy the rest of the source code and publish                                                                                                                   
COPY . .                                                                                                                                                            
RUN dotnet publish "TodoList.csproj" -c Release -o /app/publish /p:UseAppHost=false                                                                                 
                                                                                                                                                                    
# --- Stage 3: Final Image ---                                                                                                                                      
# Copy the compiled binaries from Stage 2 into Stage 1's runtime image                                                                                              
FROM base AS final                                                                                                                                                  
WORKDIR /app                                                                                                                                                        
COPY --from=build /app/publish .                                                                                                                                    
ENTRYPOINT ["dotnet", "TodoList.dll"]       