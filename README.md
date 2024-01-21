# _Green Harbor - Client Side_

#### By _**Kari Vigna, Jessica Hattig, Will Jolley, Greg Stillwell, Mac Granger**_

#### _An MVC C# client-side web application leveraging [greenharborAPI](https://github.com/KariVigna/greenharborAPI) for the storage and retrieval of composting host information._

## Technologies Used

* C#
* Razor HTML
* CSS
* .NET 6.0
* Entity Framework Core
* JSON
* MySQL
* Visual Studio Code
* Github
* Git
* Swagger

## Description
GreenHarbor Compost connects users with local compost hosts, facilitating easy and eco-friendly disposal of organic waste. Become a compost host or find nearby composting locations to contribute to a sustainable and greener community.

## Setup/Installation Requirements

If you have not already, install the `dotnet-ef` tool by running the following command in your terminal:

```
dotnet tool install --global dotnet-ef --version 6.0.0
```
### Set Up and Run Project

1. Clone this repo.
2. Open the terminal and navigate to this project's main directory called "GreenHarborClient.Solution".
3. Within the production directory "GreenHarborCient", create new file: `appsettings.json`.
4. Within `appsettings.json`, put in the following code. Make sure to replacing the `uid` and `pwd` values in the MySQL database connection string with your own username and password for MySQL. 

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=gh-user;uid=[YOUR_USERNAME];pwd=[YOUR_MYSQL_PASSWORD];"
  }
}
```
5. Install all necessary packages by running `dotnet restore` in the shell while within the production directory "GreenHarborClient".
6. Create the database using the migrations in the GreenHarborClient project. Open your shell (e.g., Terminal or GitBash) to the production directory "GreeHarborClient", and run `dotnet ef database update`. 
7. Within the production directory "GreenHarborClient", run `dotnet watch run` in the command line to start the project server and open the webpage within your browser. 
9. The Client side program will use the domain _http://localhost:7200_. 
10. Next, Within the production directory "GreenHarborApi" found at this [remote repository](lhttps://github.com/KariVigna/greenharborAPI),follow the API setup instructions and then use Git command `dotnet watch run` in the command line to start the project server and open the swagger webpage within your browser. NOTE: Both the client side and the API need to be running at the same time for the relationship between the two to be working.
11. The API side program will use the domain _http://localhost:7000_.
12. Next, create a user for "Green Harbor" by navigating to the `Register` section. Then Login to access stored composter host informtion and to add to the compster database.


## Known Bugs

* _When a user is logged in, there is a security vulnerability allowing them to edit and delete all composting host posts without proper authorization. This poses a risk to data integrity and user privacy. To address this issue, future versions will implement user roles for proper authorization and access control. This enhancement is crucial to ensure a secure and permission-controlled environment._
* _Please visit this projects [GitHub repository]() to submit Issues and Pull Requests._

## License

MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

Copyright (c) Kari Vigna, Jessica Hattig, Will Jolley, Greg Stillwell, Mac Granger 2023 
