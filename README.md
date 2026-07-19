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

### Planned

* Record new daily work-from-home entries
* Edit previous entries
* Dashboard with total hours worked from home
* Estimate tax deductions using a user-defined hourly rate
* Responsive design enhancements for desktop and mobile
* Full installable Progressive Web App (PWA) experience
* User authentication
* Secure cloud data storage
* Calendar view
* Financial year summaries
* Export data to CSV
* Offline support with automatic synchronisation
* Charts and reporting
* Reminders for missing entries

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
* [ ] Create/Edit WFH entry screen
* [ ] Build dashboard with summary statistics
* [ ] Add tax calculator
* [ ] Enable user authentication
* [ ] Implement database storage
* [ ] Publish to Azure
* [ ] Configure custom domain
* [ ] Add offline support (Service Worker)
* [ ] Implement PWA features

## Disclaimer

WFH Tracker provides estimates only and does not constitute tax or financial advice. Users are responsible for ensuring they meet the Australian Taxation Office (ATO) eligibility requirements and maintaining any records required to support their claims.

## License

This project is licensed under the MIT License.



