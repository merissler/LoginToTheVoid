[Setup]
AppName=Login To The Void
AppVersion=1.0
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
DefaultDirName={autopf64}\LoginToTheVoid
DefaultGroupName=LoginToTheVoid
OutputDir=bin\Installer
OutputBaseFilename=LoginToTheVoid-Installer
Compression=lzma
SolidCompression=yes
WizardStyle=modern
DisableWelcomePage=yes
DisableDirPage=yes
DisableProgramGroupPage=yes
DisableFinishedPage=yes
UninstallDisplayIcon={app}\LoginToTheVoid.exe

[Files]
Source: "bin\Publish\*.exe"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\LoginToTheVoid"; Filename: "{app}\LoginToTheVoid.exe"

[Run]
Filename: "{app}\LoginToTheVoid.exe"; Flags: postinstall nowait
