# WFH Tracker

A free Progressive Web App (PWA) for tracking work-from-home (WFH) hours and estimating Australian tax deductions using the ATO fixed-rate method.

> **Project Status:** 🚧 In Development

## Features

### Current



### Planned

* Record daily work-from-home hours
* View and edit previous entries
* Dashboard with total hours worked from home
* Estimate tax deductions using a user-defined hourly rate
* Responsive design for desktop and mobile
* Installable as a Progressive Web App (PWA)
  
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

* Blazor WebAssembly
* Progressive Web App (PWA)
* .NET

### Backend

* ASP.NET Core Minimal API

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

## Getting Started

### Prerequisites

* .NET SDK
* Visual Studio 2022 or later
* Azure Storage Account (for development)
* Git

### Running Locally

1. Clone the repository.
2. Open `WfhTracker.sln` in Visual Studio.
3. Start the API project.
4. Start the Blazor client.
5. Open the application in your browser.

## Roadmap

* [ ] Create solution structure
* [ ] Build Minimal API
* [ ] Implement Azure Blob Storage
* [ ] Create WFH entry screen
* [ ] Build dashboard
* [ ] Add tax calculator
* [ ] Enable authentication
* [ ] Publish to Azure
* [ ] Configure custom domain

## Disclaimer

WFH Tracker provides estimates only and does not constitute tax or financial advice. Users are responsible for ensuring they meet the Australian Taxation Office (ATO) eligibility requirements and maintaining any records required to support their claims.

## License

This project is licensed under the MIT License.
