# CatchUp Platform REST API Technical Stories

## Overview
This document contains API-focused technical stories intended for frontend or mobile developers integrating with the catch-up-platform REST API.

## Technical Stories

### TS001 — List favorite sources by NewsAPI key
As a frontend developer, I want to request the API to list favorite sources for a given `{newsApiKey}` so that I can implement the listing feature in my application.
#### Acceptance criteria:
- Scenario: Returns one or more favorites
    - Given a request to list favorite sources filtered by `{newsApiKey}` is received
    - When the API finds one or more matching favorite resources
    - Then the API responds with `200 OK` and returns a non-empty array of favorite source resources, with each resource including `id`, `newsApiKey`, and `sourceId`.
- Scenario: Returns no favorites
    - Given a request to list favorite sources filtered by `{newsApiKey}` is received
    - When the API finds no matching resources
    - Then the API responds with `200 OK` and returns an empty array.
---
### TS002 — Retrieve a favorite source by id
As a frontend developer, I want to request a favorite source by its `{id}` so that I can implement the details view in my application.
#### Acceptance criteria:
- Scenario: Found
    - Given a request for a favorite source identified by `{id}` is received
    - When the API finds the resource
    - Then the API responds with `200 OK` and returns the favorite source resource (`id`, `newsApiKey`, `sourceId`).
- Scenario: Not found
    - Given a request for a favorite source identified by a non-existent `{id}` is received
    - When the API does not find the resource
    - Then the API responds with `404 Not Found` and an error payload.
---
### TS003 — Check whether a source is favorite for a NewsAPI key
As a frontend developer, I want to query the API with `{newsApiKey}` and `{sourceId}` so that I can implement the UI state that indicates whether a source is favorite.
#### Acceptance criteria:
- Scenario: Favorite exists
    - Given a request that specifies both `{newsApiKey}` and `{sourceId}` is received
    - When the API finds a matching favorite resource
    - Then the API responds with `200 OK` and returns the matching favorite resource.
- Scenario: Favorite does not exist
    - Given a request that specifies both `{newsApiKey}` and `{sourceId}` with no match is received
    - When the API does not find a matching resource
    - Then the API responds with `404 Not Found` and an error payload.
---
### TS004 — Create a favorite source
As a frontend developer, I want to add a favorite source through the API so that I can implement the creation feature in my application.
#### Acceptance criteria:
- Scenario: Successful create
    - Given a creation request that includes required fields (`newsApiKey`, `sourceId`) is received
    - When the API validates and persists the new resource successfully
    - Then the API responds with `201 Created`, and returns the created resource representation (`id`, `newsApiKey`, `sourceId`).
- Scenario: Validation error
    - Given a creation request with missing required fields or containing invalid values is received
    - When the API validation fails
    - Then the API responds with `400 Bad Request` and an error payload describing validation errors.
- Scenario: Duplicate favorite
    - Given a creation request for a `newsApiKey` + `sourceId` combination that already exists is received
    - When the API detects the duplicate constraint violation
    - Then the API responds with `409 Conflict` and an explanatory error payload.