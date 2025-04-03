# FormGeneratorAPI

## Description
FormGeneratorAPI is a C# application that allows dynamic form generation. The solution is organized into several projects to maintain a clean and modular architecture.

## Project Structure
The solution consists of the following projects:

- **Domain**: Contains the entities and business logic.
- **Application**: Contains the services and use cases of the application.
- **Infrastructure**: Contains the data access implementation and other external services.
- **Presentation**: Contains the presentation layer, such as controllers and views.

## Requirements
- .NET SDK
- Visual Studio or JetBrains Rider

## Installation Instructions
1. Clone the repository:
    ```sh
    git clone <REPOSITORY_URL>
    ```
2. Navigate to the project directory:
    ```sh
    cd FormGeneratorAPI
    ```
3. Restore the NuGet packages:
    ```sh
    dotnet restore
    ```

## Running the Application
To run the application in development mode:
```sh
dotnet run --project Presentation/Presentation.csproj