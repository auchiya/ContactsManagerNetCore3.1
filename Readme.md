# Contacts Manager

A simple Web Api Example made with .Net Core 3.1

## Getting Started

Open the Solution (.sln) in visual studio, build and run the app.
Open your browser and go to http://localhost:44387/swagger to see the docs.

### Prerequisites

```
.Net Core 3.1 SDK for build the app
Visual Studio (2017 or later) or Command line
```

### Running the app

If you use Visual Studio just open the solution, build and run the app.

If you use the command line open it in the /ContactManager.Api folder and run the follow commands

```
dotnet build
cd \bin\Debug\netcoreapp3.1
dotnet ContactManager.Api.dll
```

Then nav to the url that shows your command line e.g. localhost:5000/swagger

If there is an error that your connection is not secure stop the app, close your browser and run:

```
dotnet dev-certs https --trust
```
Click Accept in the popup an follow the running steps again.

## Running the tests

If you use Visual Studio open the solution, in the solution explorer, rigth click on ContactManager.Api.Tests and "Run Tests"

If you use the command line open it in the /ContactManager.Api.Tests folder and run the follow commands

```
dotnet test
```

## Author

* **Agustin Uchiya** - [GitHub](https://github.com/auchiya) - [Linkedin](https://www.linkedin.com/in/agustin-uchiya)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
