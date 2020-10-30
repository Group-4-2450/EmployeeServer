# Developer Notes

## Structure

The following is an overview and summary of the directories and files included within the EmployeeWebApplication project.

- Dependencies
    - This contains the needed dlls needed for the project to run. This includes both system dlls and 3rd party dlls such as Newtonsoft.Json for serialzing and deserialzing JSON.

- Properties
    - This contains files needed for IIS, the websever integrated within an ASP.NET app to run. Contains information about what port is being used, the applications URL, and what profile (debug or release) should be used.

- wwwroot
    - This contains the css, js, and lib folders used by the Views directory which are needed for for the client UI.

- Areas

- Controllers
    - This contains the API implementations. There are two different versions of the API, one is found in the subfolder titled "InMemory" which are to be used only for testing.

    - The other version of the API that are not titled InMemory will have networking capabilites. These are the ones that will be called using the following HTTP Verbs GET, POST, UPDATE, DELETE. 

    - The Web version of the API call will also need to be testing using End-To-End tests rather than unit tests.
    
    - Further information about the endpoints and how they are to be called can be found in the README.MD.

    **Note: The End-To-End tests can be included in the EmployeeWebApplication.Tests project**

- Data
    - This contains information needed for the database connection. Be careful when making changes to these files and reverting changes are going to be hard.

- Interfaces
    - This contains the interfaces used by the controllers, both Web and InMemory versions. These defines which methods and properties the Controllers must implement.

    - Programming to an Interfaces allows us to Unit Test the code a lot easier and help with the development process.

- Models
    - This contains the classes that are used by the Database to model the data found in the Employee.db

    - These files are not the database itself, they are needed to create the tables in the database.

- Views
    - This contains the html used to implement the User Interface.

- appsettings.json
    - This file is used to establish the connection to the Database 'employee.db' and also specify log levels and which hosts are allowed to connect to this web server. 

    - **For the time being do not ever change this line within this file:**

            "AllowedHosts":"*" 

- employee.db
    - This is a SQLite database that contains all of the tables used the server. This contains information about the Employees, and also user login and roles.

- Program.cs
    - This file is the entry point for the server.

- Startup.cs
    - The functions found within this file get called during runtime to set and add configurations to the server.

- EmployeeWebApplication.Tests
    - This is a seperate project included within the EmployeeWebApplication Solution. This project is used only for implementing and running unit tests.

## Unit Tests


## Running