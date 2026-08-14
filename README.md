# WFH Tracker

A free Progressive Web App (PWA) for tracking work-from-home (WFH) hours and estimating Australian tax deductions using the ATO fixed-rate method.

> **Project Status:** 🚧 In Development

## Features

### Current

* Health check API endpoint (`/api/health`)
* View WFH entries with date, hours worked, and notes
* HTTP service for client-server communication
* Entry management service on the client side
* Blazor WebAssembly client application
* Record new daily work-from-home entries
* Edit previous entries
* Estimate tax deductions using a user-defined hourly rate
* Full installable Progressive Web App (PWA) experience
* User authentication
* Secure cloud data storage
* Calendar view
* Financial year summaries
 
### Planned

* Dashboard with total hours worked from home
* Responsive design enhancements for desktop and mobile - needs work for mobiles
* Export data to CSV
* Offline support with automatic synchronisation
* Charts and reporting
* Better support for PWA
* Improve UX when logging in
* Trial version with limited entries and features
* Checks for large files and data storage limits (spam prevention)

## Technology Stack

### Frontend

* Blazor WebAssembly (.NET 8)
* Progressive Web App (PWA)
* Bootstrap for styling

### Backend

* ASP.NET Core Minimal API (.NET 8)
* Health check endpoints

### Data Models

* `Entry` - Represents a work-from-home entry with:
  * `Id` (Guid) - Unique identifier
  * `Date` (DateOnly) - Date of the entry
  * `HoursWorked` (decimal) - Hours worked
  * `Notes` (string?) - Optional notes

### Storage

* Azure Blob Storage (initial)
* Azure SQL Database (planned)

### Hosting

* Microsoft Azure
* GitHub Actions (CI/CD)

## Project Structure

```text
WfhTracker.sln

src/
├── WfhTracker.Client
├── WfhTracker.Api
└── WfhTracker.Shared

tests/
```


2. Open `WfhTracker.sln` in Visual Studio 2022.

3. Set up your environment:
- Configure Azure Storage credentials (if using blob storage features)
- Update any necessary configuration files

4. Start the API project first (ensure it's set as startup project or run separately).

5. Start the Blazor client project.

6. Open the application in your browser (typically `https://localhost:5173` or similar).

## API Endpoints

### Health Check

- **GET** `/api/health` - Returns the health status of the API

### Entries

- **GET** `/api/entries` - Retrieves all WFH entries
- **POST** `/api/entries` - Creates a new entry (planned)
- **PUT** `/api/entries/{id}` - Updates an entry (planned)
- **DELETE** `/api/entries/{id}` - Deletes an entry (planned)

## Getting Started with Docker and Azurite

### Prerequisites

- Docker Desktop installed and running
- .NET 8 SDK installed locally
- Git

### Running Azurite with Docker

Azurite is an Azure Storage emulator that allows you to develop and test Azure Blob Storage features locally without needing an Azure subscription.

#### Quick Start

1. **Pull and run the Azurite Docker container:**

```bash
docker run -d `
  --name azurite `
  -p 10000:10000 `
  -p 10001:10001 `
  -p 10002:10002 `
  -v C:\azurite:/data `
  mcr.microsoft.com/azure-storage/azurite:latest
```

On Linux/macOS, replace the backquotes with backslashes:
```bash
docker run -d \
  --name azurite \
  -p 10000:10000 \
  -p 10001:10001 \
  -p 10002:10002 \
  -v /azurite:/data \
  mcr.microsoft.com/azure-storage/azurite:latest
```

**Port mappings:**
- `10000` - Blob Storage
- `10001` - Queue Storage
- `10002` - Table Storage

#### Verify Azurite is Running

```bash
docker logs azurite
```

You should see output indicating the services are listening on the specified ports.

#### Stop and Remove Container

```bash
# Stop the container
docker stop azurite

# Remove the container
docker rm azurite
```

### Using Azurite with WFH Tracker

The application is configured to use Azurite in development mode automatically.

**Connection String:**
```
UseDevelopmentStorage=true
```

This connection string (configured in `appsettings.Development.json`) tells the Azure SDK to connect to Azurite running on `http://127.0.0.1:10000`.

**Important:** Azurite version compatibility is handled automatically - the client is configured to skip version checks:

In `BlobStorageService.cs`:
```csharp
var clientOptions = new BlobClientOptions();
clientOptions.IsClientVersionCheckSkipped = true;
```

### Running the Application Locally

1. **Start Azurite** (using Docker as shown above)

2. **Restore NuGet packages:**
```bash
dotnet restore
```

3. **Run the API** (from `src/WfhTracker.Api`):
```bash
dotnet run
```

The API will be available at `https://localhost:7232`

4. **Run the Client** (from `src/WfhTracker.Client` in a separate terminal):
```bash
dotnet run
```

The client will be available at `https://localhost:7154` (or similar, check the terminal output)

5. **Access the application:**
- Open your browser to the client URL
- The API will automatically use Azurite for blob storage operations

### Troubleshooting Azurite

**Issue: "UseDevelopmentStorage=true" connection fails**
- Verify Azurite container is running: `docker ps | grep azurite`
- Check logs: `docker logs azurite`
- Ensure port 10000 is not in use by another process

**Issue: Storage connection timeout**
- Check your firewall settings
- Verify Docker is running and the container hasn't exited
- Try restarting the container: `docker restart azurite`

**Issue: Data persists between runs**
- Azurite stores data in the volume mount (`/data` in the container)
- To clear data, stop and remove the container, then remove the volume

## Development

### Services

#### HttpService
Generic HTTP client wrapper providing:
* `GetAsync<T>()` - Fetch data
* `PostAsync<TRequest, TResponse>()` - Create/Send data with different request/response types
* `PostAsync<T>()` - Create/Send data with same request/response type
* `PutAsync<TRequest, T>()` - Update data
* `DeleteAsync()` - Delete data
* `SendAsync()` - Send custom HTTP requests

#### EntryService
Client-side service for managing WFH entries:
* `GetEntriesAsync()` - Fetch all entries from `/api/entries`

#### HealthService
Client-side service for checking API health:
* `GetStatusAsync()` - Get health status from `/api/health`

## Roadmap

* [x] Create solution structure
* [x] Build Minimal API foundations
* [x] Implement Azure Blob Storage
* [X] Create/Edit WFH entry screen
* [ ] Build dashboard with summary statistics
* [X] Add tax calculator
* [X] Enable user authentication
* [X] Implement database storage
* [X] Publish to Azure
* [X] Configure custom domain
* [X] Add offline support (Service Worker)
* [X] Implement PWA features

## Disclaimer

WFH Tracker provides estimates only and does not constitute tax or financial advice. Users are responsible for ensuring they meet the Australian Taxation Office (ATO) eligibility requirements and maintaining any records required to support their claims.

## License

This project is licensed under the MIT License.



