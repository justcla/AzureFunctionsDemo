# Azure Functions Demo

## Setup Functions Project inside Visual Studio

### Option 1: Fetch source from GitHub

- Clone source from GitHub: https://github.com/justcla/AzureFunctionsDemo

### Option 2: Setup Project from Scratch

#####  Create New Azure Functions Project (AzureFunctionsDemo)

- File -> New -> Project
  - Visual C# -> Cloud -> Azure Functions
    - Name: "AzureFunctionsDemo"

##### Create New Function - Http Trigger (HttpTriggerFunction.cs)

- Project -> Add New Item…
  - Visual C# Items -> Azure Function
    - Name: "HttpTriggerFunction.cs"

##### Create New Function - Queue Trigger (QueueTriggerFunction.cs)

- Project -> Add New Item…
  - Visual C# Items -> Azure Function
    - Name: "QueueTriggerFunction.cs"
    - Connection: "AzureWebJobsStorage"
- Update local.settings.json
    - "AzureWebJobsStorage": "UseDevelopmentStorage=true"

## Setup Queue (for Queue Trigger)

- Start Azure Storage Emulator
  - From Windows Status bar
- Open Cloud Explorer in Visual Studio (View->Cloud Explorer)
- Add queue to local storage account
  - Expand: (Local) -> Storage Accounts -> (Development) -> Queues
  - Create Queue: "myqueue-items"

## Test the Queue Trigger (Locally)

##### Run Project (in Debug mode)

- Debug -> Start Debugging (F5)<br>
Functions Terminal Window will start

- Set breakpoint in QueueTriggerFunction.cs (line 12)
    
##### Add a message to the queue: "Test message 1"

- Open queue: myqueue-items (from Cloud Explorer)
- Use the "Add Message" icon - 3rd from the right on queue toolbar
- Enter text into message box: "Test message 1"<br>
    Message appears in queue explorer window in Visual Studio

##### Step through code in Visual Studio

- [Wait 10 seconds]<br>
Program will break on line 12
    
- Debug -> Step Over (F10)<br>
New messages printed in Functions Terminal Window<br>
Note: "Test message 1" appears printed on the console.
    
- Debug -> Continue (F5)<br>
Execution completes.
    
- Debug -> Stop Debugging (Shift+F5)

## Test the Http Trigger (Locally)

- Debug -> Start Debugging (F5)<br>
Functions Terminal Window will start

- Note the URL of the Http Function (HttpTriggerFunction) printed in the terminal window.<br>
Eg. http://localhost:7071/api/HttpTriggerFunction
    
- Open a web browser and enter the Http Function URL<br>
Program runs and asks for a "name" parameter.
    
- Append name parameter to URL query string<br>
Eg. http://localhost:7071/api/HttpTriggerFunction?name=Harry<br>
Program runs and outputs: "Hello Harry"
    
- Debug -> Stop Debugging (Shift+F5)
