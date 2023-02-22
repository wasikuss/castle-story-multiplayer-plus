# CastleStory: Multiplayer+
This mod extends and adds multiplayer related features to the game.

## Features
### 1. 10-Players
By default mod changes number of players from 4 to 10. Only host is required to have it installed.
In future clients could also benefit from additional changes like proper size of lobby (currently game has it hardcoded to 4).

Vanilla game has some additional logic for multiplayer which mod keep unaltered:
 - if there is more players than teams (again hardcoded to 4), they will be sharing the same bricktrons - all players in the same team are allies
 - if there is more players than spawnpoints (map related setting), they will be sharing the same bricktrons and crystal
 - if there is more players than colors (flags, map related setting), they can have the same color regardless if enemies or allies

As Teams are unrelated to map, mod introduces custom commands to lobby chat:
- `/teams`, which will assign separete team to each player.

  It causes that players above team D (4th) will disappear from list, but will be still in lobby.
- `/team X`, allow to player change own team. Valid team number is between 0 and 9

As host-only installation of mod can cause some troubles in starting game so it's recommended to:

1. Make sure all players are Ready (players above vanilla cap (4) can still se NOT READY, but player list will reveal real status)
2. Issue `/teams` command for making all enemies to each other
3. (OPTIONAL) Wait for players to team up by assigning to other players teams via `/team X` command
4. Start game
