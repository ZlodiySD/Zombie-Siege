# Zombie-Siege
## Overview
This is a simple zombie survival game made as part of a test task.

### Project goals
The project implemented 3 features that were described in more detail in the requirements: 
- Creating an attractive level using a post-processing unit and several light sources
- Implementing player with shooting mechanic shoot and health and a zombiewith melee attack and simple AI
- Implementation of UI and adding differend sound to the game

## Assets used in the project
[POLYGON Apocalypse](https://assetstore.unity.com/packages/3d/environments/urban/polygon-apocalypse-low-poly-3d-art-by-synty-154193)

[GUI PRO Kit - Sci-Fi Survival](https://assetstore.unity.com/packages/2d/gui/gui-pro-kit-sci-fi-194741)

[Third Person Controller v2.2](https://assetstore.unity.com/packages/tools/game-toolkits/ultimate-character-controller-233710)

[Cartoon FX Remaster](https://assetstore.unity.com/packages/vfx/particles/cartoon-fx-remaster-4010)

[Fog plane shader by Cyan](https://cyangamedev.wordpress.com/2019/12/05/fog-plane-shader-breakdown)

# Instalation
You can get the code by cloning the github repository. You can do this in a UI like SourceTree or you can do it from the command line as follows:

```git clone https://github.com/Apanyold/Zombie-Siege.git```

To correctly launch the game from the editor, you should run the scene "Bootstrap"

## About project

### Project architecture
Entry point in this game is the ```Bootstraper``` script, which initializes the game. the game is divided into states, each state is stored in the ```GameStateMachine``` script with all the dependencies it needs. 

The game implemented a simple DI container in the state ```BootstrapState```

The game is divided into states, and implementations of specific states are responsible for setting up specific scenes, which allows you to control the process of launching the game.
