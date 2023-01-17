# CastleStory: Multiplayer+
This mod extends and adds multiplayer related features to the game.

## Features
### 1. 10-Players
By default mod changes number of players from 4 to 10. Only host is required to have it installed.
In future clients could also benefit from additional changes like proper size of lobby (currently game has it hardcoded to 4).

Vanilla game has some additional logic for multiplayer which mod keep unaltered:
 - if there is more players than teams (again hardcoded to 4), they will be sharing the same bricktrons - all players in the same team are allies
 - if there is more players than spawnpoints (map related setting), they will be sharing the same bricktrons and crystal
 - if there is more players than colors (flags, map related setting), they can have the same color features but still be an enemy

Ass one thing is unrelated to map (teams), mod introduces custom command to lobby chat: `/teams`, which will assign separete team to each player.
It causes that players above team D (4th) will disappear from list, but will be still in lobby.