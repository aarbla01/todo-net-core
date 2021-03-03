# TODO | REST API | ASP.NET Core

<!--- These are examples. See https://shields.io for others or to customize this set of shields. You might want to include dependencies, project status and licence info here --->
![GitHub repo size](https://img.shields.io/github/repo-size/aarbla01/todo-net-core)
![Twitter Follow](https://img.shields.io/twitter/follow/sonicaab?style=social)

This is an example REST API for a TODO application, built using ASP.NET Core

## Prerequisites

Before you begin, ensure you have met the following requirements:
<!--- These are just example requirements. Add, duplicate or remove as required --->
* You have installed `.NET 5` or later (https://docs.microsoft.com/en-us/dotnet/core/install/)
* You have a `<Windows/Linux/Mac>` machine. State which supports `.NET 5`.

## Installing

To run, follow these steps:

Windows:
```
cd src/ToDo.Api
dotnet run
```
This will start the appliction at the following URL:
http://localhost:5000/swagger

The default port will be 5000, however you can change this be starting the application using:
```
cd src/ToDo.Api
dotnet run --urls=http://localhost:{PORT NUMBER}/
```

## Using

To use follow these steps:
The swagger definition can be viewed at:
http://localhost:5000/swagger

### Endpoints

#### Get all
```
curl -X GET "http://localhost:5000/todos" -H  "accept: text/plain"
```
#### Get by ID
```
curl -X GET "http://localhost:5000/todos/3fa85f64-5717-4562-b3fc-2c963f66afa6" -H  "accept: text/plain"
```
#### Create
```
curl -X POST "http://localhost:5000/todos" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\"description\":\"string\"}"
```
#### Delete
```
curl -X DELETE "http://localhost:5000/todos/3fa85f64-5717-4562-b3fc-2c963f66afa6" -H  "accept: text/plain"
```
#### Complete
```
curl -X POST "http://localhost:5000/todos/complete" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}"
```


## License

This project uses the following license: [MIT](LICENSE).