GROUP MEMBERS:
1) Eli Bennett
2) Sara Wooten
3) Preston ___

FEATURES:
A-Game is a stricly audio based mobile game developed for people with major, or minor vsual impairments, especially those with full/partial blindness. The game is a "merge type" game similar to many others on the market, with the exception that instead of merging images together to make better items, the user is merging audio clips to make better sounds. The games has the following features:
* Since the game is designed primarrily to be accesable to people who are fully blind, The game features zero visuals, and relys soley on audio queues. This means that there are no visual assets included in the Assets folder, and the application only shows a single black screen throughout the durration of the entire experience. That being said, while the game itself has zero visuals, the unity editor does feature some basic visuals for the develper to use when testing, but these can be turned on/off at any time.
* A-Game features a radial board as aposed to a grid. This means that each cell that the board has is layed out in a circle surrounding the center of the screen. That being said, that center point can move to any part of the scene if it needs to. The number of cells in each board can change dimamically durring runtime, but currently the best number is 8 cells as it is easiest to find the top, bottom, left, right, and diagonals of the screen.
* Aach cell object is proximity based, which means that no matter where the screen is touched, te closest cell will be calculated, and activated.
* The moment the nearest Cell object is found and tapped, a single sound will play corrosponding to the sound object that is held within the cell. If a Cell has no sound it will play an "empty cell" sound.
* if an empty cell is held down, a new sound will be insterted in its place. The amount of time an empty cell must be held is determined by a variable that can change at any time, but its currently set to 0.3 seconds.
* A randomness algorithm is used to determine what kind of sounds are created. Lower valued sounds are much more likely to spawn than higher ones. 
* if a sound object is dragged into another matching sound object (plays the same audio clip), it will merge into a new sound.
* the Audio uses Unity's built in AudioSource component with the spacial setting turned all the way up. This means that the game features 3d sound depending on where a sound is playing from. This makes the gaming experience more enjoyiable, and theoretically easier with headphones, but they are not required.

INSTALLMENT INSTRUCTIONS:

UI DOCUMENTATION:
