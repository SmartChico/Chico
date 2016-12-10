#Introduction
CHICO project is intended to be a gateway for all parties in construction business to connect to each other and find the services they need.

#Getting started
At this stage, Chico common app is actively under development by SmartChico team. To join our team, please send an email to our team leader, Ms.Deepali Mokashi.

#Tools setup
1. Install Visual Studio 2015 from this [link](https://www.microsoft.com/net/core#windowsvs2015)
2. Update to net core 1.1.0 preview by downloading and running the installer from this [link](https://github.com/dotnet/core/blob/master/release-notes/preview-download.md)
3. At this point you should be ready to pull the project from Github. Use a Git program (or Visual Studio built-in tool) to clone the online repository.
4. Open Chico.sln file in VS IDE. If you are still getting errors, open package manager console and type:
`dotnet restore`
5. If you are still getting errors, open project.json and find out which package has not been updated to 1.1.0 (it will be underlined by a red line) and install them manually. Please contact the Chico team for help if there are any more problems.
6. Use the SQL script in the Github repository to generate the database locally. Then run the SQL initialization script in this repository. We recommend using our database since it has all the required initial data and some test data already entered. To use the online development database or to get attachable (.mdf and .ldf) files, please contact the Chico team.
7. In Visual Studio IDE, from the Solution Explorer tab, open appsettings.json file. In line 3, there is a connection string in the form:
`"DefaultConnection":"Server={YourMachineName}\\{Sql server name};Database=chico;Trusted_Connection=True;MultipleActiveResultSets=true"`.

Replace {YourMachineName} and {Sql server name} with the values from your own development box. You can usually find these values just by opening SQL Server Management Studio and see the server and machine name in connection dialog.
Note: You do not need to have a local copy of the database. You can set the connectionstring in appsettings.json to directly use our online database hosted on Azure cloud. But this will require whitelisting your IP address by the cloud admin.

#Test
To test the app, please visit [our live demo website](http://smartchico.azurewebsites.net)
