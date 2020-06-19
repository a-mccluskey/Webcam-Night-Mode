# Webcam-Night-Mode
Updates Exposure level for specific webcam

Windows' default USB video driver does not increase the exposure to high enough levels when light levels are very low

Sets the exposure level after 10PM and before 4AM to -1 (the highest level) The rest of the time the exposure is automated

This runs as a console app (best useage is to set to an hourly automated task in task scheduler).

Uses the AForge.Video.DirectShow NuGet libary.
