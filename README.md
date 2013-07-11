Unit Of Work Starter Kit
========================

Summary
-------
The *UnitOfWork* package provides a lightweight starter kit for using the UOW, and Repository patterns with Entity Framework.  It has been implemented in an easily testable way, so that you can mock data access to make testing easier.  

A complimentary package to this is *UnitOfWork.Test*.  This shows you how you can mock out the repositories for more control and isolation during your unit tests.

Data Access Unit Testing
------------------------
You will want to do integration testing between your code and the DB. This is needed to ensure that your columns/entities are corrently mapped and that the DB constraints are not broken.  To accomplish this simply add an app.config to your unit test project and add a connection string with the same name as your context.  Point this to a localdb instance of SQL, and the DataInitialiser
will create a DB for you.

Logic Unit Testing
------------------
With complex entities it can become a complicated and involved task to set up data structures in your DB for tests to work.  In these cases it's easier to mock out the DB and hard code some entites for your tests to use.  This can be done with a mocking framework (like NSubstitute) and and IoC container.  For example:

```csharp  
var mock = Substitute.For<IUnitOfWork>();  
mock.Customers.GetByName("").ReturnsForAnyArgs(GetCustomers());  
DataContainer.RegisterInstance(mock);
```
IoC Container
-------------
Unity is used as the IoC container.  You can replace this with your favourite IoC container by changing the implementation of DataContainer or UnitOfWork.Begin()

ORM
---
Entity Framework Code First is used as the ORM.  This can be changed by re-implementing your repositories to use any other ORM or even stored procedures!



Project structure
-----------------
The project contains two nuget packages *UnitOfWork* and *UnitOfWork.Test*.  Each nuget package contains two projects.  One for the actual package, and a *target* which can be used to test and consume the package.
