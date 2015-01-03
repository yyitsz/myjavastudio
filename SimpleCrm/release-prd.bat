@echo off

@%NANT_HOME%\bin\nant.exe Build -D:project.config=Release -buildfile:simplecrm.build
@set sa_com="C:\apps\SmartAssembly 6\SmartAssembly.com"
set TARGET_DIR="dist\simplecrm_obfuscated"
set ASSEMBLY_DIR="dist\Simple客户管理系统-PRD\"
@echo -----------delete temp folder
@del "%TARGET_DIR%\*" /q/s

@echo -----------WinClient
@%sa_com% "simplecrm\SimpleCrm.saproj"

@echo ----------- copy files
@xcopy "%TARGET_DIR%\*" "%ASSEMBLY_DIR%" /y/s/r/f

@pause "Press any key to continue..."