 # .NET Web API "_Addresses_"
 ## Table of Contents
* [General Info](#general-information)
* [Technologies Used](#technologies-used)
* [Features](#features)
* [Screenshots](#screenshots)
* [Setup](#setup)
* [Usage](#usage)
* [Project Status](#project-status)
* [Room for Improvement](#room-for-improvement)
* [Acknowledgements](#acknowledgements)
* [Contact](#contact)

## General information
- API for working with addresses(CRUD operations) and besides that calculated distance between waypoints by Google Maps Distance Matrix API.
- Solution contains two project :  
 
1. BackendData library in  Data folder.

2. TaskAPI. 

   [View](#project-folders-view)

## Technologies Used
- Visual Studio 2022.
- .NET 6.
- SwaggerUI.
- Swashbuckle.AspNetCore Version="6.2.3".
- Database: SQLite Version="3.13.0".
- Microsoft.EntityFrameworkCore Version="7.0.2". 
- AutoMapper Version="12.0.1".
- Microsoft.AspNet.Mvc Version="5.2.9".
- Newtonsoft.Json Version="13.0.2".
- Google Maps Distance Matrix API .

## Features
- You don't need to authorise because this function isn't ready yet.

   [View](#project-folders-view)

#### Addresses controller :
- CRUD operations.
- Search by any property value, except Id.
- Sort by any property name, ASC and DESC.
- Setup pagination.

   [View](#addresses-controller-view)


#### Distance controller:
- Calculating distance between two waypoints by Google Maps Distance Matrix API.(waypoints should be on the same continent)

   [View](#distance-controller-view)
   
 - Response view
 
   [View](#response-view)
   
## Setup
- 1.Clone this repository in your machine.
- 2.You do not need input data cause project include data preset.(10 addresses) and database.sqlite file.
- 3.You can use Swagger UI and Postman for testing API.
- Swagger UI address :          
-             https://localhost:7166/swagger/index.html
   
   [View](#swagger-view)


* [Key Features](#Key-Features)


## Screenshots
#### Project folders view
![Screenshot_20230209_033748](https://user-images.githubusercontent.com/61758319/217843639-9fd507e3-b5af-45b3-871a-1695caa7c086.png)

#### Authorisation button
![Screenshot_20230209_035901](https://user-images.githubusercontent.com/61758319/217848793-63b312fa-034b-4f44-b46a-7af5b2416062.png)

#### Setup pagination
![Screenshot_20230209_040510](https://user-images.githubusercontent.com/61758319/217850310-4359492c-5ad2-4b0a-bed6-8b93d2664396.png)

#### Addresses controller view
![Screenshot_20230209_040510](https://user-images.githubusercontent.com/61758319/217850310-4359492c-5ad2-4b0a-bed6-8b93d2664396.png)

#### Distance controller view
![Screenshot_20230209_040654](https://user-images.githubusercontent.com/61758319/217850979-1d0cfbac-7ce7-4613-9f9a-979734ad710d.png)
![Screenshot_20230209_093910](https://user-images.githubusercontent.com/61758319/217934543-13571f8b-570f-4ed3-977d-753428732ee5.png)

#### Response view
![Screenshot_20230209_093942](https://user-images.githubusercontent.com/61758319/217934024-aeabf9a2-609e-4242-bf85-ecff2cc5eb9f.png)

#### Swagger view
![Screenshot_20230209_034500](https://user-images.githubusercontent.com/61758319/217845307-674aa59e-76ef-4fc8-b429-16f8c0ab1f93.png)




* [Default](#default)
 ###### sort filter = "ASC".
![Screenshot_20230209_041140](https://user-images.githubusercontent.com/61758319/217852231-51ad661d-08ac-4fb7-a3bc-44c4ac296643.png)
 ###### column filter = "City"
 ![Screenshot_20230209_051021](https://user-images.githubusercontent.com/61758319/217870261-fb22a9fb-7ab2-4524-9d93-27bce1de6ff3.png)

 ###### page number = 1.
 ###### page size = 50.
![Screenshot_20230209_041157](https://user-images.githubusercontent.com/61758319/217852305-b7cefbdd-e8c4-43cf-ad83-074be4d174ef.png)

 * [strengths](#strengths)
 ###### Leveraged encapsulation between API backed data resources and application implementation details.
 ###### IAsyncRepository<T>  that is generic interface that is make work with database more flexible and reusable.
 ###### Working with resources implemented with async/await.
 ###### Implemented versioning.
 ###### Implemented Installer interface that made Program file cleaner.
 Error handle model
 * [Should be improve](#should-be-improve)
 ###### Validation for requests should be more liberal so I will be able to accept all formats and just transform data to format what I exactly need that’s remain     ###### clients unbroken and still achieve data consistency.
 Delivered endpoint documentation through a Swagger implementation.

 
 

 
 





 




