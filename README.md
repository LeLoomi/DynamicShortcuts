## DynamicShortcuts (iCloud Calendar)
*This is a work in progress, use at own risk.*
My goal with this project is to write a Windows service and GUI, which let's you set desktop icons that'll dynamically change (.url's that is). The idea is to port the, for mobile calendar apps common, behaviour of changing the icon according to the current date and weekday since I found no way online to do this.

**Development Progress**

 - [x] Have the program generate the icons, day of month and weekday incl.
 - [x] The program can replace and reload the shortcut icon
 - [x] the program can automatically generates and set the icon in the background
 - [x] GUI to set which shortcut to manage
 - [x] add argument to start program only for updating the icon, no GUI (runfullbgservice)
 - [ ] create the background service that subs to windows events
 - [ ] possible goal: other icon styles presets

[![GitHub issues](https://img.shields.io/github/issues/LeLoomi/DynamicShortcuts?color=red)](https://github.com/LeLoomi/DynamicShortcuts/issues)

*This project uses the external code, click [here](https://github.com/LeLoomi/DynamicShortcuts/blob/main/EXTERNAL-CODE.md) to see which.*
*This project is written based on the .NET Framework version 4.8.*
