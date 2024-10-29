# JobCandidates

## Overview

The JobCandidates is a .NET-based RESTful service designed to manage candidate information efficiently. This API allows you to add, update, and retrieve candidate profiles, using the candidate's email as a unique identifier. This document provides detailed instructions for setting up the application, configuring settings, managing database migrations, and running tests.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet) (version compatible with the project)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or a compatible database server
- Visual Studio or any .NET-compatible IDE

## Configuration

### Updating `appsettings.json`

1. Open the `appsettings.json` file located in the **main project**.

2. Locate the `ConnectionStrings` section. It should look something like this:

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;Trusted_Connection=True;"
   }

3. Goto Package Manager Console and set default project as CandidateManagement.Infrastructure.
4. Run script "Add-Migration "Migration Name".
5. Run Script "Update-Database".
