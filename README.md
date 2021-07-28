# DynamicShortcuts
My goal with this project is to write a Windows service and GUI, which let's you set desktop icons that'll dynamically change. The idea is to port the, for mobile calendar apps common, behaviour of changing the icon according to the current date and weekday.

THIS IS A WORK IN PROGRESS;
current functionality:
- the program can change a hardcoded shortcut between two icons, when a button is pressed, this deleted the windows icon cache and reloads the explorer in order to update the icon. This part is done with the help of Windows' command line (automatically tho)
- the program can create a new hardcoded shortcut by pressing a button
