# MoviesAPI
This project provides a RESTful API for managing movies using ASP.NET Core Web API. It allows you to perform CRUD (Create, Read, Update, Delete) operations on movie data. It uses code first migrations to create the local SQL Server DB

**API Endpoints**

-   **GET /api/movies** - Retrieves a list of all movies (JSON format)
-   **GET /api/movies/{id}** - Retrieves a specific movie by ID (JSON format)
-   **POST /api/movies** - Creates a new movie (JSON request body containing movie details)
-   **PUT /api/movies/{id}** - Updates an existing movie (JSON request body containing updated movie details)
-   **DELETE /api/movies/{id}** - Deletes a movie by ID
