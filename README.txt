Game Rules:
=================
A match takes place between 2 players and is made up of 3 games, with the overall winner being the first player to win 2 games (i.e. best of 3).
Each game consists of both players selecting one of Rock, Paper or Scissors; the game winner is determined based on the following rules:
- Rock beats scissors
- Scissors beats paper
- Paper beats rock

Requirements:
===================
application support two types of player:

Human Player:
--------------
The user will be prompted for name and then a selection of Rock, Paper or Scissors for each turn

Random Computer Player:
------------------------
The random computer player should automatically select one of Rock, Paper or Scissors.


appsettings File:
==================
you can configure the different settings for the application for a start you can set the following

"GameSettings": {
    "NoOfGames": "3",                       //e.g Best of 3 Games
    "SecondPlayerName": "ComputerPlayer"    //Name of the second player
  }
