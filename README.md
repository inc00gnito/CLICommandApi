# CommandApi
CommandApi stores command line snippets along with a short description of what it does, as well as what platform it's for.

### Technologies
This project was created to learn and practice concepts related to: 
  * REST Api
  * .Net Core
  * MVC design pattern
  * C#
 #### To create this API, I used the following: 
  * Entity Framework Core - DbContext, Migrations
  * SQL Server
  * Dependency Injection
  * Data Transfer Objects (DTOs) 
  * HTTP (GET, POST, PUT, PATCH, DELETE, status codes)
  * Testing API Endpoints (SwaggerUI & Postman)
  
#### Example of endpoints using Postman:
##### [HttpPost] creates a command and returns location header and '200 OK' status code
![HttpPost](https://user-images.githubusercontent.com/23665243/129458905-67213b97-4c2d-45f3-9f96-65e2ea2133c7.png)
##### [HttpGet] Retrieves a command using its unique id, and returns '20 Created' status code
![HttpGet](https://user-images.githubusercontent.com/23665243/129458906-ce77dce7-cb4e-43b0-ab8d-61344ebf422a.png)
