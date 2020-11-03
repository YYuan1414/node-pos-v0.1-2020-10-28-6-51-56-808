# Create a asp.net web api project which has 3 APIs:

## Requirements

* ### Create a ToDoItem

ToDoItem struct is:

```
long Id
string Name
bool IsComplete
```
The `Id` property functions as the unique key in an array.

* ### Get all ToDoItem

* ### Get a specified ToDoItem
```
As a user
I can get the the ToDoItem by Id.
```
## How to test
1. run command `dotnet run`
2. open https://localhost:5001/swagger/index.html to test your apis