# Azure Functions Demo

This walk-through shows how to use Visual Studio to create an Azure Functions project.

The sample project includes two different types of Azure Functions and demonstrates:
- how to trigger a function when an item shows up in a Queue (using a Queue Trigger)
- how to trigger a function when a user posts an HTTP request (using an HTTP Trigger)
- how to configure a local storage queue for testing (using Windows Storage Emulator)
- how to locally debug an Azure Function


The major steps in the tutorial are:
1. [Setup Functions Project inside Visual Studio](#setupProject)
2. [Setup Queue (for Queue Trigger)](#setupQueue)
3. [Test/Debug the Queue Trigger (Locally)](#testQueueTrigger)
4. [Test the Http Trigger (Locally)](#testHttpTrigger)

## <a name="setupProject"></a> Setup Functions Project inside Visual Studio

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

## <a name="setupQueue"></a>Setup Queue (for Queue Trigger)

- Start Azure Storage Emulator
  - From Windows Status bar<br>
![Start Storage Emulator](Resources/StartStorageEmulator.png)

- Open Cloud Explorer in Visual Studio
  - View->Cloud Explorer
- Add queue to local storage account
  - Expand: (Local) -> Storage Accounts -> (Development) -> Queues
  - Create Queue: "myqueue-items"<br>
![Cloud Explorer - Local Queues](Resources/CloudExplorer-LocalQueues.png)

## <a name="testQueueTrigger"></a>Test/Debug the Queue Trigger (Locally)

### Run Project (in Debug mode)

- Debug -> Start Debugging (F5)<br>
Functions Terminal Window will start<br>
![Functions Terminal Window](Resources/FunctionsStarted.png)

- Set breakpoint in QueueTriggerFunction.cs (line 12)<br>
![Queue Trigger Breakpoint](Resources/QueueTriggerBreakpoint.png)

### Add a message to the queue: "Test message 1"

- Open queue: myqueue-items (from Cloud Explorer)<br>
![MyQueue-Items - No messages](Resources/MyQueueItems-NoMessages.png)

- Use the "Add Message" icon - 3rd from the right on queue toolbar
- Enter text into message box: "Test message 1"<br>
![Add Message Textbox](Resources/AddMessageTextBox.png)<br>
  Message appears in queue explorer window in Visual Studio<br>
![MyQueue-Items - With message](Resources/MyQueueItems-WithMessage.png)

### Step through code in Visual Studio

- [Wait 10 seconds]<br>
Program will break on line 12<br>
![QueueTrigger Hits Breakpoint](Resources/BreakingOnQueueTrigger.png)

- Debug -> Step Over (F10)<br>
New messages printed in Functions Terminal Window<br>
![Message printed in Functions Terminal Window](Resources/ConsoleMessagePrinted.png)<br>
Note: "Test message 1" appears printed on the console.

- Debug -> Continue (F5)<br>
Execution completes.

- Debug -> Stop Debugging (Shift+F5)

## <a name="testHttpTrigger"></a>Test the Http Trigger (Locally)

- Debug -> Start Debugging (F5)<br>
Functions Terminal Window will start<br>
![Functions Terminal Window](Resources/FunctionsStarted.png)

- Note the URL of the Http Function (HttpTriggerFunction) printed in the terminal window.<br>
Eg. http://localhost:7071/api/HttpTriggerFunction

- Open a web browser and enter the Http Function URL<br>
![Hello World - Needs name](Resources/HelloWorld-NeedName.png)<br>
Program runs and asks for a "name" parameter.

- Append name parameter to URL query string<br>
Eg. http://localhost:7071/api/HttpTriggerFunction?name=Harry <br>
![Hello World - Hello Harry](Resources/HelloWorld-HelloHarry.png)<br>
Program runs and outputs: "Hello Harry"

- Debug -> Stop Debugging (Shift+F5)
