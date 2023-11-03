# Abstract Bank
Small ASP.NET 7 project to scrap rust from my skills.

# Tech Stack
* [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
* [MediatR](https://github.com/jbogard/MediatR)
* [Fluent Validation](https://docs.fluentvalidation.net/en/latest/)
* [Reactive Extensions](https://github.com/dotnet/reactive)
* [Entity Framework](https://github.com/dotnet/efcore)
* [xUnit](https://xunit.net/)
* [NSubstitute](https://nsubstitute.github.io/)
* [Fluent Assertions](https://fluentassertions.com/)

# How to run
* Clone repository
* With Sql DB: 
  * Update **DefaultConnection** to point empty DB
  * Set **UseInMemoryDatabase** to **false**
* With in memory DB:  
  * Set **UseInMemoryDatabase** to **true**
* Run Api project
* Navigate in browser to **https://<host>/swagger/index.html**
* Enjoy
