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

* In order to use this application you must have MySQL Workbench installed. Depending on your machine please follow setup instructions listed [here](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql)
* Clone this repository to your local machine
* Navigate to the project's ```AnimalShelter``` folder.
* In the project's ```AnimalShelter``` folder, you will next need to create an appsettings.json file with the following information where YOURPASSWORDHERE is the password used to connect to MySQL:

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
    "DefaultConnection": "Server=localhost;Port=3306;database=brenna_lavin;uid=root;pwd=[YOURPASSWORDHERE];"
  }
  }
  ```

* To install the project's dependencies, in the command line type ```dotnet restore```
* To ensure the database is properly connected to the project, type ```dotnet ef database update```, this will ideally apply the most recent migration of the database.
* Once in the Project folder, type ```dotnet run`` in the command line to run the program.

## API Documentation
You can explore the endpoints in Postman or in a browser!

### Using Swagger Documentation
To Explore the Animal Shelter Api with NSwag, after launching the project using ```dotnet run``` navigate to ```http://localhost:5004/swagger```
### Note on Pagination AND Versioning
Currently the pagination only works within version 1.0 of the api, to explore the pagination navigate to ```http://localhost:5004/api/1.0/animals in the browser.
Each page shows 5 entries, and will provide links to the first, last, previous and next page. 

### Endpoints

Base URL: ```http://localhost:5004```

#### Http Request Structure

```
GET /api/{component}
POST /api/{component}
GET /api/{component}/{id}
PUT /api/{component}/{id}
DELETE /api/{component}/{id}
```

Example Query:

```
http://localhost:5004/api/animals/3
```

Example JSON Response:

```
{
animalId: 3,
type: "Cat",
name: "Mr.Mistopholes",
gender: "Male",
breed: "Tuxedo",
admissionDate: "2022-03-06T00:00:00"
}
```

Path Parameters:

| Parameter | Type |Default| Required | Description|
| ----------- | ----------- | ----------- | ----------- | ----------- |
| id    | int | none | Return matches by id
| type   | string | none | Return matches by type
| gender | string | none | Return matches by gender
|breed | string | none | Return matches by breed

Example query string:

```
http://localhost:5004/api/animals?type=cat&gender=male
```

Example JSON response:

```
{
animalId: 1,
type: "Cat",
name: "McCavity",
gender: "Male",
breed: "Ginger Tabby",
admissionDate: "2022-03-18T00:00:00"
},
{
animalId: 3,
type: "Cat",
name: "Mr.Mistopholes",
gender: "Male",
breed: "Tuxedo",
admissionDate: "2022-03-06T00:00:00"
}
```

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
