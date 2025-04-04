.. formGenerator documentation master file, created by
   sphinx-quickstart on Thu Apr  3 15:51:14 2025.
   You can adapt this file completely to your liking, but it should at least
   contain the root `toctree` directive.

Table of Contents
-----------------
.. toctree::
   :maxdepth: 2
   :caption: "Main Sections"

   diagrams

FormGeneratorAPI
================

Description
-----------
FormGeneratorAPI is a C# application that allows dynamic form generation. The solution is organized into several projects to maintain a clean and modular architecture.

Project Structure
-----------------
The solution consists of the following projects:

- **Domain**: Contains the entities and business logic.
- **Application**: Contains the services and use cases of the application.
- **Infrastructure**: Contains the data access implementation and other external services.
- **Presentation**: Contains the presentation layer, such as controllers and views.

Requirements
------------
- .NET SDK
- Visual Studio or JetBrains Rider

Installation Instructions
-------------------------
1. Clone the repository:
    .. code-block:: sh
        git clone <REPOSITORY_URL>

2. Navigate to the project directory:
    .. code-block:: sh
        cd FormGeneratorAPI

3. Restore the NuGet packages:
    .. code-block:: sh
        dotnet restore

Running the Application
-----------------------
To run the application in development mode:

.. code-block:: sh
    dotnet run --project Presentation/Presentation.csproj

