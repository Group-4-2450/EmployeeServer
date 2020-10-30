# Employee Web Application

## How To Run

1. Download and install Docker for your operating system
    - https://docs.docker.com/desktop/

    (Or suffer the consequences of installing PostgreSQL locally. Your choice :))

2. Open a command prompt and navigate to the project directory

3. Run the following command

    ```
    docker-compose up -d
    ```

4. Double click the .sln file to launch Visual Studio

5. At the top of Visual Studio click the 'Tools' dropdown. Then click 'Nuget Package Manager'. Then click 'Package Manager Console'
    - You should see a console open at the bottom of Visual Studio.

6. Run the following command to recreate the database tables
    
    ```
    Update-Database
    ```

7. Click the run button at the top of Visual Studio to start the server.