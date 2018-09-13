# AspnetCore listen urls lab

A simple project to setup aspnet listen urls from different sources.

## Running

### Reading urls from `hostsettings.json` (default for this project)

Powershell command:
``` powershell
PS> dotnet run --project .\src\Sample\
```

The urls to bind will be loaded from the key `server.urls` in the json file.

``` json
{
  "server.urls": "http://127.0.0.1:5002"
}
```

### Reading urls from env vars

First define the environment variable

Powershell command:
``` powershell
PS> $env:SAMPLE_URLS = "http://127.0.0.1:5003"
```

Then run the application

Powershell command:
``` powershell
PS> dotnet run --project .\src\Sample\
```

Remember to clean the variable to avoid unexpected behavior in others tests

Powershell command:
``` powershell
PS> $env:SAMPLE_URLS = ""
```

### Reading urls from command line args

Powershell command:
``` powershell
PS> dotnet run --project .\src\Sample\ --server.urls="http://127.0.0.1:5004"
```