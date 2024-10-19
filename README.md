# Project Overview

This project consists of two main applications:
1. **Backend**: An ASP.NET 8 application.
2. **Frontend**: An Angular 18 application.

## Backend - ASP.NET 8

### Prerequisites

- .NET 8 SDK installed on your machine.
- Docker installed on your machine (optional for Docker build).

### Building and Running the Backend Locally

1. Navigate to the backend directory:
    ```sh
    cd .\backend\src\
    ```

2. Restore the dependencies:
    ```sh
    dotnet restore
    ```

3. Build the project:
    ```sh
    dotnet build
    ```

4. Run the application:
    ```sh
    dotnet run
    ```

5. The backend application will be available at `http://localhost:7280`.

### Building and Running the Backend with Docker

1. Navigate to the backend directory:
    ```sh
    cd backend
    ```

2. Build the Docker image:
    ```sh
    docker build -t backend-app .
    ```

3. Run the Docker container:
    ```sh
    docker run -p 7280:80 backend-app
    ```

4. The backend application will be available at `http://localhost:7280`.

## Frontend - Angular 18

### Prerequisites

- Node.js and npm installed on your machine.
- Docker installed on your machine (optional for Docker build).

### Building and Running the Frontend Locally

1. Navigate to the frontend directory:
    ```sh
    cd frontend
    ```

2. Install the dependencies:
    ```sh
    npm install
    ```

3. Build the project:
    ```sh
    npm run build
    ```

4. Run the application:
    ```sh
    npm start
    ```

5. The frontend application will be available at `http://localhost:4200`.

### Building and Running the Frontend with Docker

1. Navigate to the frontend directory:
    ```sh
    cd frontend
    ```

2. Build the Docker image:
    ```sh
    docker build -t frontend-app .
    ```

3. Run the Docker container:
    ```sh
    docker run -p 4200:80 frontend-app
    ```

4. The frontend application will be available at `http://localhost:4200`.

## Additional Information

For more detailed information on Docker, refer to the [Docker documentation](https://docs.docker.com/).

For more detailed information on Angular, refer to the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli).

For more detailed information on ASP.NET, refer to the [ASP.NET documentation](https://docs.microsoft.com/en-us/aspnet/core/).
