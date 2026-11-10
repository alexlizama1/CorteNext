#define MyAppName "CorteNext"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "CorteNext"
#define MyAppExeName "CorteNext.exe"

[Setup]

AppId={{A94627AF-93B2-4C88-B089-43A67B0EA931}

AppName={#MyAppName}

AppVersion={#MyAppVersion}

AppVerName={#MyAppName} {#MyAppVersion}

AppPublisher={#MyAppPublisher}

DefaultDirName={autopf}\CorteNext

DefaultGroupName=CorteNext

DisableProgramGroupPage=yes

PrivilegesRequired=admin

ArchitecturesAllowed=x64compatible

ArchitecturesInstallIn64BitMode=x64compatible

WizardStyle=modern

Compression=lzma2

SolidCompression=yes

OutputDir=Output

OutputBaseFilename=CorteNext-Setup-{#MyAppVersion}

UninstallDisplayName=CorteNext

UninstallDisplayIcon={app}\CorteNext.exe


[Files]

Source: "..\publish\*"; \
    DestDir: "{app}"; \
    Flags: ignoreversion recursesubdirs createallsubdirs


[Tasks]

Name: "desktopicon"; \
    Description: "Create a desktop shortcut"; \
    GroupDescription: "Additional shortcuts:"


[Icons]

Name: "{group}\CorteNext"; \
    Filename: "{app}\CorteNext.exe"; \
    WorkingDir: "{app}"

Name: "{autodesktop}\CorteNext"; \
    Filename: "{app}\CorteNext.exe"; \
    WorkingDir: "{app}"; \
    Tasks: desktopicon


[Run]

Filename: "{app}\CorteNext.exe"; \
    Description: "Launch CorteNext"; \
    WorkingDir: "{app}"; \
    Flags: nowait postinstall skipifsilent