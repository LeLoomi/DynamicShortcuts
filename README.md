## DynamicShortcuts (iCloud Calendar)
My goal with this project is to write a Windows service and GUI, which let's you set desktop icons that'll dynamically change (.url's that is). The idea is to port the, for mobile calendar apps common, behaviour of changing the icon according to the current date and weekday since I found no way online to do this.

**Development Progress**

 - [x] Have the program generate the icons, day of month and weekday incl.
 - [x] The program can replace and reload the shortcut icon
 - [x] the program can automatically generates and set the icon in the background
 - [ ] GUI to set which shortcut to manage
 - [x] add argument to start program only for updating the icon, no GUI (runfullbgservice)
 - [ ] create the background service that subs to windows events
 - [ ] possible goal: other icon styles presets


*This is a work in progress, using this is not recommended and if anything breaks it is not my resposibility.*
*This project uses the [lineChanger](https://stackoverflow.com/a/35496185) code snippet by Bruce Afruz, as well as the [ImageMagick](https://imagemagick.org/) libraries.*
