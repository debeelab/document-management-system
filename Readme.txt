**Introduction**
FT/DMS is a web application that keeps track of all the files that move around different offices/departments of an organisation until they reach their destination. Every department needs to register the arrival and departure of files. When anyone searches for a file in FTS, it then displays the track of the file’s movement in a graphical format.



Overview
This app has a fully functioning site that is at least capable of doing the following, if not more, using a SQL database:

creating new file/memo, reject file.
searching for existing file.


**Main Files: Project Structure**

├── README.md
├── default.aspx *** the main driver of the app. Includes your SQLAlchemy models.
├── logout.aspx                  "python app.py" to run after installing dependences
├── web.config *** Database URLs, CSRF generation, etc
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


**Tech Stack**
Tech stack will include:

Microsoft SQL as our database of choice
asp.net and C# as our server language and server framework
HTML, CSS, and Javascript with Bootstrap 3 for our website's frontend
Main Files: Project Structure