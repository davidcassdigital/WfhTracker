# Architecture

## Client

Blazor WebAssembly PWA

Responsibilities

- UI
- Forms
- API calls

## API

Responsibilities

- Authentication
- Business logic
- Validation

## Repository

Responsible for data persistence.

## Storage

Azure Blob Storage.

Designed so the implementation can later be replaced with SQL Server without affecting the client.