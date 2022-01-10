FILE TRACKING / DOCUMENT MANAGEMNT SYSTEM (FTS/DMS)
-----

## Introduction
FT/DMS is a web application that keeps track of all the files that move around different offices/departments of an organisation until they reach their destination. Every department needs to register the arrival and departure of files. When anyone searches for a file in FTS, it then displays the track of the file’s movement in a graphical format.
The project is builts on .net framework and microsoft sql server is used to design the models/structure of the database

## Overview
This application has a fully functioning site that is at least capable of doing the following, if not more, using a SQL database:

- creating new file/memo, reject file.
- searching for existing file.
- display history of records to user on permission base

## Main Files: Project Structure**

```sh
├── default.aspx *** the login page.
├── logout.aspx                 
├── web.config *** Database URLs
├── error.log
├── Addons
│   ├── ADM_Department.aspx 
│   ├── ADM_Users.aspx
├── App_Data
│   ├── PublishProfiles
├── Bin
|   ├── AjaxControlToolkit.dll
├──Homepage
|   ├── AdminHome.aspx
|   ├── DirectorHome.aspx
|   ├── SecretaryHome.aspx
|   ├── UnitHeadHome.aspx
├── Masterpages
|    ├── Admin.master
|    ├── Director.master
|    ├── Secretary.master
├── Memo
|    ├── Create_memo.aspx
|    ├── externalmemo.aspx
|    ├── vwAssignedmemo.aspx
├── Pages
|    ├── Sent_memo.aspx
|    ├── ChangePassword.aspx
|    ├── dispatch.aspx
|    ├── virtualShelf.aspx
├── README.md
```

## Tech Stack 
### Tech stack will include:

- Microsoft SQL as our database of choice
- ASP.NET and C# as our server language and server framework
- HTML, CSS, and Javascript with Bootstrap 3 for our website's frontend


## Development Setup
- First, install Microsoft SQL if you haven't already 
- Visual studio 2012 or updated version 
- web browser 

# please contact me for the username and password to login into the system.
