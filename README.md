# TodoList Project Overview

This project consists of two main applications:
1. **Backend**: An ASP.NET 8 application.
2. **Frontend**: An Angular 18 application.

Both applications can be built and run using Docker.

## Backend - ASP.NET 8

### Prerequisites

- Docker installed on your machine.

### Building and Running the Backend

1. Navigate to the backend directory:
    ```sh
    cd .\backend\src\
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

- Docker installed on your machine.

### Building and Running the Frontend

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
