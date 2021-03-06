# ED Minor Faction Support

## Overview

Creates a summary of pro- and anti-minor faction work by players for **Elite:Dangerous** ("Elite"). The tool is intended for use by the "Elite Dangerous AU & NZ" squadron supporting the "EDA Kunti League" minor faction. However, a different minor faction can be specified.

Instructions:
1. Install .Net Core. See https://docs.microsoft.com/en-us/dotnet/core/install/windows for details.
2. Download the latest release and extract the ZIP file.
3. After a session of playing Elite, open a command prompt (e.g. cmd.exe).
4. Navigate to the folder where the ZIP file extracted to.
5. Run "edmfs". It will scan the game's journal files and output a summary to the console window. It shows nothing if you have no relevant activity or have not played Elite today.
6. For command line options, run it with the "--help" paramater. For example, you can see results of other day's sessions.

I recommend piping the results to the Windows clipboard by using the built-in "clip" command, e.g. "edmfs | clip". You can then paste the result in Discord.

What does it support?
1. Missions. It displays missions that increase and decrease "EDA Kunti League" influence. It also displays missions that impact other minor factions' influce in systems where "EDA Kunti League" is present, although the effects of these are harder to quantify.
2. Bounties, combat bonds and other "vouchers". It ignores bounties handed into minor factions other than "EDA Kunti League Factions".

What does it not support (yet)?
1. Combat Zone activity. The journal files do not currently log this detail. However, selling combat bonds is covered.
2. Selling Cartography data at a minor faction controlled station.
3. Trading at a minor faction controlled stations.
4. Mission failure and abandonment. There is partial support for mission redirection.
5. Non-Windows installs. Sorry, PS4 and XBox players.

If this tool proves useful we may automate the collation of these further, e.g. by pasting the results to Discord directly or sending them to a central source for consolidated reporting.

## Disclaimer

**Elite: Dangerous** ("Elite") is a game developed by Frontier Developments PLC ("Frontier"). The author of "ED Minor Faction Support" ("EDMFS") has no relationship with Frontier other than purchasing and playing Elite. 

EDMFS does not intend to exploit Elite or breach the terms of service. EDMFS uses publically documented journal files created by the Elite game client. The latest version of Frontier's documentation at the time of writing is http://hosting.zaonce.net/community/journal/v27/Journal-Manual_v27.pdf.

Using these journal files also means the accuracy and completeness of the data produced by EDMFS depends on the accuracy and completes of the data written to these journal files. For example, the data in the journal file may be inconsistent with the game client. The journal format may also change, meaning EDMFS may parse it incorrectly until modified.

Frontier does not publish detailed descriptions of Elite's different mechanics. EDMFS makes assumptions about the meaning and relevance of data stored in the journal.

## License
 
See LICENCE.txt (MIT license)
