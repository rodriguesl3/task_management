# Task Management
This is a simple project to create, read and update tasks. This project contain 5 applications:

1) Backend projects:

    1.1) **SQL Server database**

    1.2) **External Services**

    1.3) **Task API**

2) **React Application**:
    This is a web application where is possible to read informations in browser (e.g. Google Chrome, Firefox, etc...)

3) **Flutter Application**:
    This is a mobile project using Flutter framework, where is possible to build cross platform Android and iOS.


## Task API Management
Task API Management, is composed for 3 services using docker-compose. 

* To test this project, is necessary run ***"docker-compose up"*** command in ***task-management/api*** folder.

* When all container are up and running, is necessary open your favourite browser and access this url: ```http://localhost:32780/swagger/index.html``` after load, will open swagger documentation, where is possible to read endpoints documentation.


![swagger](https://github.com/rodriguesl3/task_management/blob/master/documentation/swagger.png)



---
## Backend Services overview:

The backend project is responsible for business logic and store information in SQL Server. Task API has 3 services:

![image.png](https://github.com/rodriguesl3/task_management/blob/master/documentation/file-Backend.jpg?raw=true)


* sql_database:
    * It is a container docker responsible for save information in database.
* taskmanagement.api:
    * This is container Docker, where receive HTTP request to create, read, update tasks.
* taskmanagement.externalservice:
    * This service is a container Docker, where validate if task name already exist consulting SQL Server container.
    * It receive a request from **taskmanagement.api** service, through http request.


---
## WEB Task Management
This project is created using React and using Redux architecture. This project can read backend services and update a task status to Open or Completed.

To run this project, is necessary access the web folder (***web/task-management***) and run command
* __*npm install*__
* __*npm start*__

It will open a page like this one:

![](https://github.com/rodriguesl3/task_management/blob/master/documentation/React%20APP.png?raw=true)

---
## Mobile Task Management
Assuming that you have flutter installed in your machine, case not, please follow [this readme document](https://github.com/rodriguesl3/task_management/tree/master/mobile/task_management).

Case you have all flutter stuff installed in your machine.

* Access mobile project paht ***/mobile/task_management***
* Run command ***flutter run***

It will open a simulator or you can choose your connected USB mobile.

In this case, it will run with this layout.

![flutter](https://github.com/rodriguesl3/task_management/blob/master/documentation/flutter.png?raw=true)


