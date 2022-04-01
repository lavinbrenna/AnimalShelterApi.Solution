# _🐶 Animal Shelter API 🐱_
#### By _**Brenna Lavin**_

#### _This project is a Web Api application for an animal shelter_

## Technologies Used

* C#
* .NET
* Swagger
* MySQL Workbench
* Microsoft EntityFramework Core

## Description

_This project is an exploration in creating APIs while adding a variety of features like versioning, pagination and Swagger documentation_

## Setup/Installation Requirements

* In order to use this application you must have MySQL Workbench installed. Depending on your machine please follow setup instructions listed here
* Clone this repository to your local machine
* Navigate to the project's ```AnimalShelter``` folder.
* In the project's ```Animal Shelter``` folder, you will next need to create an appsettings.json file with the following information where YOURPASSWORDHERE is the password used to connect to MySQL:
  
```
  {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=brenna_lavin;uid=root;pwd=Literatur3!;"
  }
  ```

}
Once saved, type cd Pierre in your command line to navigate to the main project folder.
To install the project's dependencies, in the command line type dotnet restore
To ensure the database is properly connected to the project, type dotnet ef database update, this will ideally apply the most recent migration of the database.
Once in the Project folder, type dotnet run in the command line to run the program.

## Known Bugs

* _No known bugs

## License

MIT License

Copyright (c) [2022] [Brenna Lavin](https://github.com/lavinbrenna)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
