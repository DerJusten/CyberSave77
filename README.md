# CyberStart77

Save all of your Quick/Autosaves in Cyberpunk2077 automatically, start additional apps on game start and a bit more

- Copy new Quick/Autosaves to a different location (can be filtered by age)
- Create customnames for your savefiles (like Level, Gender etc.) based on your progress
- Start any 3rd party applications (e.g. camera tools) when the game is starting or already running
- Autosave the game (if possible) if the last save reached a specific age

## Install
Download the latest CyberStart77_VX.X.zip from the release tab. Unzip the file and execute the CyberStart77.exe, thats it.

## How to use
* set the "Extra savegames path" to any location **except the original savegame location**  (I also don't recommend a subfolder in the original savagame location, since the game will show your copied saves as corrupted)
* (optional) adjust the timers (if you want to use Autosave, do not set the "Savegame interval" higher than 60 seconds)
* (optional) add 3rd party applications, which will be started when the game starts or is already running (NOTE: if the game gets closed, these process will be terminated)
* (optional) adjust options for 'minimum minutes between savefiles', Autosave and CustomNames (top right corner)
* Press Start

## How does it work

This application just checks if a process called "Cyberpunk2077.exe" is running. If the process is not running, it keeps checking and checking until you stop/exit the application or until the process actually gets started. If it gets started or is already running, two things happen.
1. The list of external applications will be checked and will be started, if they are any. 
2. "GameSaveChecker" starts, which will compare the directories of the original savegame and your extra savegame directory. It keeps checking these directories until there are new Auto-or Quicksaves. The default settings copies only savegames which are **older than 5 minutes** than the last save.
<br>This Process is also responsible for the "autosave" feature, which is pretty rudimental. It checks if the game is in foreground and just sends a keypress (F5). I will probably rework this when I have the time.

 

#### Disclaimer:
This is just a personal project I wrote for myself, since I wanted to start automatically these great cameras tools https://github.com/FransBouma/InjectableGenericCameraSystem/releases/tag/CP102
<br>The code is pure spaghetti and there are probably a lot of bugs I don't know of.
Also I am sorry for any grammar errors, since English isn't my mother tongue..
