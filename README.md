# Videogame Database

Access to a database on video games with their corresponding platforms, companies and distributors. Admin users can view, create, modify and delete the respective tables mentioned above and normal users can see all the information about them, in addition, you can provide information about themselves with respect to those video games (Completed, analysis).

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

What things you need to install the software and how to install them

```
•	IDE: Visual Studio 2019
•	Visual Studio Requeriment (install): Xamarin, ASP.net
•	System database: SQL server
•	Database Management: SQL server Management Studio
•	API REST test: Postman
•	Emulator: Android Studio
•	ORM: Entity Framework
```

### Installing the APP

First you will need to install [Visual Studio 2019](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16)

Next, you have to install the dependencies:

![alt](https://image.prntscr.com/image/J0otTId-Si27uL_5k6he-Q.png)
Choose install more tools and then
![alt](https://image.prntscr.com/image/AE3TpbdgQBS037kfULCuqw.png)
![alt](https://image.prntscr.com/image/OBkDjPTFSOOecgEI6w_lhg.png)

Now you can open the xamarin application, selecting open an existing solution

![alt](https://image.prntscr.com/image/xgCtEBFhRBOaXaZzAAqKAA.png)

Once you have opened the file, you will need to create an android emulator if you don't have it
![alt](https://image.prntscr.com/image/IbnVgQIZR1qClZFLg8VB4A.png)

And then you will be able to run the application

### Installing the API

First you will need to install [SQL server](https://go.microsoft.com/fwlink/?linkid=853016)

Next, you have to install the management studio [SQL server Management Studio](https://aka.ms/ssmsfullsetup)

Once you have installed it, you will need to connect to Database Engine, and then add a new query.
Drag and drop the "admin.sql" and "VideogamesDB.sql" files that are on the "Inicio" folder to the SQL server Management Studio and execute them.
![alt](https://image.prntscr.com/image/4z4gVjFsTX_HGp-nXTOCgg.png)

Now, you have to modify two files in the API folder.
API\.vs\MVCCrudAPI\config\applicationhost.config
![alt](https://image.prntscr.com/image/BCL5juW2RB2BWeA1m09Q3g.png)

API\MVCCrudAPI\MVCCrudAPI.csproj
![alt](https://image.prntscr.com/image/93KAFOj6T16GiorKyca6Zg.png)

Now you are able to run the server.

### Connecting the APP to the API

You just need to execute the APP, and then go to options and select an IP.
![alt](https://image.prntscr.com/image/9sJKt1SsQe6n9P6wocpGJg.png)

### Register and Login (APIvgd)

The methods are not implemented in the APP, but there's a second API folder (called APIvgd) that contains every methods that will be implemented in the future.

![alt](https://image.prntscr.com/image/-_HROMKFS_Oytg5mUSotHA.png)

### POSTMAN TEST
[API DOCUMENTATION](https://asdgdsgsagd.postman.co/collections/8886235-b1da850a-35bf-491d-9cad-cb6665e0b613?version=latest&workspace=54ad114d-cf16-4e12-8269-8b1b9d9f85f0)
