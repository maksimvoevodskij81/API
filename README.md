  # TaskAPI that is REST API 
###### That is API for working(CRUD operations) with addresses and besides that for calculating distance between waypoints.
###### Solution contains two project:
###### 1. TaskAPI. 
###### 2. BackendData library.
* [Technologies](#technologies)
###### Visual Studio 2022.
###### .NET 6.
###### SwaggerUI.
###### Swashbuckle.AspNetCore Version="6.2.3".
###### Database: SQLite Version="3.13.0".
###### Microsoft.EntityFrameworkCore Version="7.0.2". 
###### AutoMapper Version="12.0.1".
###### Microsoft.AspNet.Mvc Version="5.2.9".
###### Newtonsoft.Json Version="13.0.2".
###### Google Maps Distance Matrix API .
* [Setup](#setup)
###### 1.Clone this repository in your machine.
###### 2.You do not need input data cause project include data preset.(10 addresses) and database.sqlite file.
###### 3.You can use Swagger UI and Postman for testing API.
* [functions](#functions)
##### Addresses controller:
###### CRUD operations.
###### Search by any property value, except Id.
###### Sort by any property name, ASC and DESC.
###### Pagination.
##### Distance controller:
###### Calculating distance between two waypoints.
* [General info](#general-info)
###### You don't need to authorise because this function isn't ready yet.
###### Delivered endpoint documentation through a Swagger implementation.
* [Default](#default)
 ###### sort filter "City ASC".
 ###### page number 1.
 ###### page size 50.
 * [strengths](#strengths)
 ###### Leveraged encapsulation between API backed data resources and application implementation details.
 ###### IAsyncRepository<T>  that is generic interface that is make work with database more flexible and reusable.
 ###### Working with resources implemented with async/await.
 ###### Implemented versioning.
 ###### Implemented Installer interface that made Program file cleaner.
 * [Should be improve](#should-be-improve)
 ###### Validation for requests should be more liberal so I will be able to accept all formats and just transform data to format what I exactly need that’s remain     ###### clients unbroken and still achieve data consistency.

 
 

 
 





 




