This application template contains a theme system that supports Lightmode and Darkmode\
It also contains tools and utilities that Winforms typically doesn't give you access to\

Dark mode :

![DarkMode](https://user-images.githubusercontent.com/72354122/155618104-d9af6832-5705-44a9-bb2e-db890a8b114c.png)

Light mode :

![LightMode](https://user-images.githubusercontent.com/72354122/155618109-b11aa732-c344-4262-8366-e906f1646bf3.png)

The theme system contains a palette of colors:\
|Color name|  |Red|Green|Blue|\
Accent:         50, 50, 65\
BrightAccent:   60, 60, 75\
DarkAccent:     40, 40, 55\
Inactive:       30, 30, 35\
Background:     20, 20, 20\
Panel:          25, 25, 27\
BrightPanel:    35, 35, 40\

Examples:\
panel1.BackColor = Theme.Accent;\
panel2.BackColor = Theme.Panel;\
panel3.BackColor = Theme.Inactive;
