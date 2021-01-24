# CyberSave77 

CyberSave77 (prev. CyberStart77) is a little application which copies your **Auto-/and Quicksaves** in Cyberpunk2077, so you never have to worry about going back in the future anymore. But it is more than just a simple copy job. You can customize the name based on your savegame stats and keep it clean by setting a time difference between the savegames you want to copy.

## Features
- copies all or just some of your Auto-/Quicksave while the game is running
- start any additional applications like camera tools, video recording  etc. when the game is running or starting for the first time
- create a backup of your savegame folder
- create automatically a quicksave after a specific time (this can be probably ignored by most of the people, since the game has an Autosave feature)
## How to use
- download ZIP file in the release tab unzip it to any location and start CyberSave77.exe
- adjust the settings like you want to
- click on Start
- run Cyberpunk2077.exe (also works if it is already running)

## What does it do 
This tool checks every X seconds (you can adjust the seconds) if the game (Cyberpunk2077) is running or not. If it is, it starts to check the savegame directories and compares them by their creation date. Based on your settings, it copies the matching directories (including their files) to your "Savegame history path", which is by default %username%\Saved Games\CD Projekt Red\SaveGameHistory.

## Known bugs
If a shortcut of CyberSave77 gets added to the AutoStart (Settings -> Start with Windows), Windows Defender sometimes detects it as a trojan and put it in quarantine. This is (obviously) a false-positive, but I haven't figured out what is causing it. 

### Disclaimer
This is just a hobby project I made for myself but I decided that I want to share it with anyone, who also wants to use any of the features. I am not a great coder and there are probably alot of things which can be made better. Also I am terrible at giving names so I am sorry for any grammar errors and the weird naming.
