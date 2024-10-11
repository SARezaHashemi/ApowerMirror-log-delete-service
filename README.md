# What is it?
This is a standard Windows service that runs in the background. Every 5 minutes, it checks if the size of the "Apowersoft Mirror" application's logs folder exceeds 500MB. If the folder size is greater than 500MB, the logs will be deleted.

# Installation
1. Clone the repository.
2. Run this command:
```bash
   dotnet build
```
3. Use a service installer like `InstallUtil.exe` or another tool to install the service.
4. Press `Win + R` to open the Run dialog.
5. Type `services.msc` and press Enter.
6. Find the service with the service name `ApowerMirrorLogHandlerService` and display name `AMLDeletorService`.
7. Right-click and start the service. Done!

# Logs
Logs will be created in the directory where the executable file is located.

# Bugs =/
Unfortunately, I didn't try to handle any bugs yet. On my own PC, I couldn't install the service using InstallUtil.exe.
