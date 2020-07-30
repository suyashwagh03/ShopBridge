# ShopBridge
1) For front end, Blazor is used, for Middleware, ASP.Net Core 3.1 is used, for backend connection Entity Framework Core is used.

2) The project has multi layers -
  * ShopBridge.Web - for Presenttation layer
  * ShopBridge.Model - for POCO classes
  * ShopBridge.Data - for Repository layer
  * ShopBridge.Api - for API layer
  * ShopBridge.Service - for Service layer to access API methods
  
3) To start the project, make ShopBridge.Web and ShopBridge.Api projects as Start up projects

4) To Create database, migrations are added at ShopBridge.Data -> Migration folder. Apply these migrtions by commands at Package manager console

![](/ShopBridge.Web/Project_Screenshots/Screenshot%20(20).png)

5) Database connection settings are present at ShopBridge.Api -> appsettings.json -> appsettings.Developement.json

![](/ShopBridge.Web/Project_Screenshots/Screenshot%20(19).png)

6) Integration tests are added to ensure all coding intgation is working In Tests folder -> ShopBridge.Intgration.Tests -> ProductTests

![](/ShopBridge.Web/Project_Screenshots/Screenshot%20(18).png)

![](/ShopBridge.Web/Project_Screenshots/Screenshot%20(17).png)

6)Project screenshots are placed in ShopBridge.Web -> Project_Screenshots folder
