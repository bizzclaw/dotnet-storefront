# StoreFront
Joseph Tomlinson

A Web application programmed in ASP .NET 1.1 meant to showcase and review products.


## Requirements for building
__.NET 1.1 SDK__ [Windows](https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-win-x64.1.1.4.exe) | [Mac OSX](https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-osx-x64.1.1.4.pkg)

__.NET Runtime__ [Windows](https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-win-x64.1.1.4.exe) | [Max OSX](https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-osx-x64.1.1.4.pkg)

__MySQL Server__ [NAMP](https://www.mamp.info/en/) | [MySQL Community Server](https://dev.mysql.com/downloads/mysql/)

__IDE:__ [Visual Studio](https://www.visualstudio.com)

__GIT CLI__ [Git-SCM](https://git-scm.com/downloads)

## Build Instructions
1. Clone with git to your local machine.
2. cd into dotnet-storefront/storefront with your terminal/command prompt
3. run `dotnet restore`, this will install needed packaged for the app.
4. run `dotnet ef database update`, this will prepare the database for the app.
5. Open "Portfolio.sln" with Visual Studio.
6. Click "__Run__" from visual studio, a web page will open displaying the site.
