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
FormGeneratorAPI is a C# application that allows dynamic form generation. The solution is organized into several projects to maintain a clean and modular architecture, making it easy to evolve over time while keeping business logic separate from infrastructure and external dependencies.


Technologies Used
------------------
- C# 
- net8.0 
- Entity Framework (for data access)
- EntityFrameworkCore.PostgreSQL
- EntityFrameworkCore.SqlServer
- ASP.NET Core
- Dependency Injection (built-in DI container in .NET)
- XUnit 2.5 + FluentAssertions 8.2(for unit testing)
- Docker


Project structure
-----------------
The solution consists of the following projects:

- **Domain**: Contains the entities and business logic.
- **Application**: Contains the services and use cases of the application.
- **Infrastructure**: Contains the data access implementation and other external services.
- **Presentation**: Contains the presentation layer, such as controllers and views.

To have a visible idea about the project structure, you can check the :doc:`diagrams` section


Design patterns used in the project
-----------------------------------
The following design patterns were used inside the solution:

- **Dependency Injection**: Used to manage object lifetimes and dependencies, promoting loose coupling and easier testing.
- **Builder Pattern**: Helps to construct complex objects step by step. (example: the ConnectionStringBuilder)
- **Repository Pattern**: Provides an abstraction over data access, allowing for more flexible and maintainable data storage solutions. (example: the repositories inside Infrastructure)
- **Factory Pattern**: Used to create instances of objects without exposing the creation logic. (example: the html generator inside Application)


Requirements
------------
- .NET SDK
- Visual Studio or JetBrains Rider


Installation Instructions
-------------------------
1. Clone the repository:

.. code-block:: console

        git clone <REPOSITORY_URL>

2. Navigate to the project directory:

.. code-block:: console

        cd FormGeneratorAPI

3. Restore the NuGet packages:

.. code-block:: console

        dotnet restore


Running the Application
-------------------------
To run the application in development mode:

.. code-block:: console

	dotnet run --project Presentation/Presentation.csproj


Running Tests
-------------------------
To run the tests, use the following command:

.. code-block:: console

	dotnet test


Docker Setup
-------------------------
To start the application using Docker, use the following command:

.. code-block:: console

	 docker-compose -f docker-compose.dev.yml up

To stop the application, use the following command:

.. code-block:: console

	 docker-compose -f docker-compose.dev.yml down


Environment Variables
-------------------------
Ensure the following environment variables are configured:

.. code-block:: console
	
	# External PostgreSQL Server
	POSTGRES_HOST="{{addYourHost}}"
	POSTGRES_DB="{{addYourDb}}"
	POSTGRES_USER="{{addYourUser}}"
	POSTGRES_PASSWORD="{{addYourPass}}"

	# SQL Database
	DATABASESETTINGS__HOST="{{addYourHost}}"
	DATABASESETTINGS__USER="{{addYourUser}}"
	DATABASESETTINGS__PASSWORD="{{addYourPass}}"

Replace the placeholder values with your actual configuration.


Team members:
-------------
Daniel Del Cid.

Luis Regalado


Links:
-------------
https://formgenerator.readthedocs.io/en/latest/index.html
https://dev.azure.com/Cikume/Cikume%20Academy/_git/lead-prospect-form-generator-api-fork-ddelcid-lregalado