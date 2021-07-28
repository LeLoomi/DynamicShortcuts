## DynamicShortcuts
My goal with this project is to write a Windows service and GUI, which let's you set desktop icons that'll dynamically change (.url's that is). The idea is to port the, for mobile calendar apps common, behaviour of changing the icon according to the current date and weekday since I use an online calendar and I found no way online to do this.

**Intended / planned functionality:**
- A GUI to
	- designate which shortcut (.url) you want to dynamically update
	- add all the icons that are needed for this, if I decide to code for weekdays too then that as well (creating all those icons will be a pain tho, maybe we'll try automated image creation at each (daily) icon update?)
- A background service that automatically checks your current icon at 00:00 of each day or if you unlock your user account. If the icon is outdated then the icon will be updated.

**Current functionality:**
- the program can change a hardcoded shortcut between two icons, when a button is pressed, this deletes the windows icon cache and reloads the explorer in order to update the icon.
	- The icon reload part is (automatically) done with the help of Windows' command line
- the program can create a new hardcoded shortcut by pressing a button, for debug reasons
- the program can save the raw text content of the shortcut as a .log file, for debug reasons



*This is a work in progress, using this is not recommended and if anything breaks it is not my resposibility.*
