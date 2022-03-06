#!/bin/bash
ModDir="C:/Program Files (x86)/Steam/steamapps/common/Cities_Skylines/Files/Mods/ZoningMultitool/"
[ -d "$ModDir" ] && [ ! -h "$ModDir" ] || mkdir "$ModDir"
cp -u ./bin/Debug/ZoningMultitool.dll  "$ModDir/ZoningMultitool.dll"