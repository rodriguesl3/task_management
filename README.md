# Task Management

## Task API Management
Task API Management, is composed for 3 services using docker-compose. 

To test this project, is necessary run ***"docker-compose up"*** command in ***task-management/api*** folder.

---
## Services overview:

The backend project is responsible for business logic and store information in SQL Server. Task API has 3 services:

![image.png](https://avatars1.githubusercontent.com/u/19299997?s=460&v=4)



* sql_database:
    * It is a container docker responsible for save information in database.
* taskmanagement.api:
    * This is container Docker, where receive HTTP request to create, read, update tasks.
* taskmanagement.externalservice:
    * This service is container Docker, where validate if task name already exist.
    * It receive a request from **taskmanagement.api** service, through http request.


---
## WEB Task Management
shdfkashdflkajhsdfkjashdfkjlashdf

---
## Mobile Task Management
sdajfhkajkldhsfjakhsdfjkahsdfjkalsdf