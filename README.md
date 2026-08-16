# WFH Tracker

A free Progressive Web App (PWA) for tracking work-from-home (WFH) hours and estimating Australian tax deductions using the ATO fixed-rate method.

> **Project Status:** ✅ POC Complete

WFH Tracker is a DC Digital proof-of-concept application demonstrating a complete cloud-hosted Blazor WebAssembly PWA, including authentication, persistent user data, Azure hosting, and PWA capabilities.

## Features

### Current

* View WFH entries with date, hours worked, and notes
* Record new daily work-from-home entries
* Edit previous entries
* Estimate tax deductions using a user-defined hourly rate
* Calendar view
* Financial year summaries
* User authentication and account creation using Microsoft Entra External ID
* Secure, user-specific cloud data storage
* Azure Blob Storage persistence
* HTTP service for client-server communication
* Entry management service on the client side
* Health check API endpoint (`/api/health`)
* Full installable Progressive Web App (PWA) experience
* Deployed to Microsoft Azure
* Custom application domain
* Service worker and offline support

### Future Improvements

* Dashboard with additional summary statistics
* Responsive design enhancements for desktop and mobile
* Export data to CSV
* Offline data synchronisation
* Charts and reporting
* Improved PWA update/version handling
* Further UX refinements
* Checks for large files and data storage limits (spam prevention)

> **Note:** WFH Tracker is intentionally being kept as a free proof-of-concept. Commercialisation and trial/limited-feature functionality are not currently planned.

## Authentication

WFH Tracker uses **Microsoft Entra External ID** for customer authentication.

The application supports:

* User registration
* User sign-in
* User sign-out
* Authentication-protected application functionality
* Redirect to the WFH Tracker welcome page after logout
* Authentication working in both local development and the deployed PWA

The tenant currently uses Microsoft's default External ID authentication domain.

A branded custom authentication URL (for example, `auth.dcdigital.au`) is a potential future DC Digital platform improvement and is intentionally deferred.

## Technology Stack

### Frontend

* Blazor WebAssembly (.NET 8)
* Progressive Web App (PWA)
* Bootstrap for styling

### Backend

* ASP.NET Core Minimal API (.NET 8)
* Health check endpoints
* Azure Blob Storage integration

### Data Models

* `Entry` - Represents a work-from-home entry with:

  * `Id` (Guid) - Unique identifier
  * `Date` (DateOnly) - Date of the entry
  * `HoursWorked` (decimal) - Hours worked
  * `Notes` (string?) - Optional notes

### Storage

* Azure Blob Storage
* Azurite for local development
* Azure SQL Database was considered as a future storage option but is not currently required

### Hosting

* Microsoft Azure
* Azure Static Web Apps
* GitHub Actions (CI/CD)
* Custom domain

## Project Structure

```text
WfhTracker.sln

src/
├── WfhTracker.Client
├── WfhTracker.Api
└── WfhTracker.Shared

tests/
```

## Getting Started

1. Clone the repository.

2. Open `WfhTracker.sln` in Visual Studio 2022.

3. Set up your environment:

   * Configure Azure Storage credentials if using Azure Storage.
   * Configure any required application settings.

4. Start the API project.

5. Start the Blazor client project.

6. Open the application in your browser using the URL shown by the development environment.

## API Endpoints

### Health Check

* **GET** `/api/health` - Returns the health status of the API.

### Entries

* **GET** `/api/entries` - Retrieves WFH entries for the authenticated user.
* **POST** `/api/entries` - Creates a new WFH entry.
* **PUT** `/api/entries/{id}` - Updates an existing WFH entry.
* **DELETE** `/api/entries/{id}` - Deletes an existing WFH entry.

## Getting Started with Docker and Azurite

### Prerequisites

* Docker Desktop installed and running
* .NET 8 SDK installed locally
* Git

### Running Azurite with Docker

Azurite is an Azure Storage emulator that allows local development and testing of Azure Blob Storage features without requiring a live Azure Storage account.

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

* `10000` - Blob Storage
* `10001` - Queue Storage
* `10002` - Table Storage

#### Verify Azurite is Running

```bash
docker logs azurite
```

You should see output indicating the services are listening on the specified ports.

#### Stop and Remove Container

```bash
docker stop azurite
docker rm azurite
```

### Using Azurite with WFH Tracker

The application is configured to use Azurite in development mode.

**Connection String:**

```text
UseDevelopmentStorage=true
```

This connection string, configured in `appsettings.Development.json`, tells the Azure SDK to connect to Azurite running locally.

### Running the Application Locally

1. **Start Azurite** using Docker as shown above.

2. **Restore NuGet packages:**

```bash
dotnet restore
```

3. **Run the API** from `src/WfhTracker.Api`:

```bash
dotnet run
```

The API will be available at the URL shown in the terminal.

4. **Run the Client** from `src/WfhTracker.Client` in a separate terminal:

```bash
dotnet run
```

5. **Access the application** using the client URL shown in the terminal.

### Troubleshooting Azurite

**Issue: `UseDevelopmentStorage=true` connection fails**

* Verify the Azurite container is running:
  `docker ps`
* Check the logs:
  `docker logs azurite`
* Ensure port `10000` is not already in use.

**Issue: Storage connection timeout**

* Check your firewall settings.
* Verify Docker is running and the container has not exited.
* Try restarting the container:

```bash
docker restart azurite
```

**Issue: Data persists between runs**

Azurite stores data in the configured volume. To clear the local data, stop and remove the container and remove the associated data.

## Development

### Services

#### HttpService

Generic HTTP client wrapper providing:

* `GetAsync<T>()` - Fetch data
* `PostAsync<TRequest, TResponse>()` - Create/send data with different request/response types
* `PostAsync<T>()` - Create/send data with the same request/response type
* `PutAsync<TRequest, T>()` - Update data
* `DeleteAsync()` - Delete data
* `SendAsync()` - Send custom HTTP requests

#### EntryService

Client-side service for managing WFH entries:

* `GetEntriesAsync()` - Fetch entries from `/api/entries`

#### HealthService

Client-side service for checking API health:

* `GetStatusAsync()` - Get API health status from `/api/health`

## PWA and Caching

WFH Tracker uses a service worker to provide PWA and offline functionality.

Published assets are versioned using the generated Blazor assets manifest. Each deployment receives a new cache version, allowing the service worker to remove obsolete cached assets when the new service worker activates.

During development, caching is disabled to make local development easier.

> **Known improvement:** Existing installed PWAs or browsers may temporarily continue running a previous cached version after a deployment. Improved update detection and user notification are potential future enhancements.

## Roadmap

* [x] Create solution structure
* [x] Build Minimal API foundations
* [x] Implement Azure Blob Storage
* [x] Create/Edit WFH entry screen
* [x] Add tax calculator
* [x] Enable user authentication
* [x] Implement user-specific cloud storage
* [x] Publish to Azure
* [x] Configure custom application domain
* [x] Add offline support (Service Worker)
* [x] Implement PWA features
* [x] Add calendar view
* [x] Add financial year summaries
* [x] Implement clean logout flow

### Future

* [ ] Dashboard with additional summary statistics
* [ ] CSV export
* [ ] Offline data synchronisation
* [ ] Charts and reporting
* [ ] Improved PWA update handling
* [ ] Additional responsive/mobile refinements
* [ ] Storage/abuse protection

## Disclaimer

WFH Tracker provides estimates only and does not constitute tax or financial advice. Users are responsible for ensuring they meet the Australian Taxation Office (ATO) eligibility requirements and maintaining any records required to support their claims.

## License

This project is licensed under the MIT License.
