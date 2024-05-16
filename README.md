GROUP MEMBERS:
1) Eli Bennett
2) Sara Wooten: Empty cell sounds & Probability of different sounds spawning
3) Preston ___

FEATURES: 
A-Game is a strictly audio based mobile game developed for people with major, or minor visual impairments, especially those with full/partial blindness. The game is a "merge type" game similar to many others on the market, with the exception that instead of merging images together to make better items, the user is merging audio clips to make better sounds. The games has the following features:
* Since the game is designed primarily to be accessible to people who are fully blind, The game features zero visuals, and relies solely on audio queues. This means that there are no visual assets included in the Assets folder, and the application only shows a single black screen throughout the duration of the entire experience. That being said, while the game itself has zero visuals, the unity editor does feature some basic visuals for the developer to use when testing, but these can be turned on/off at any time.
* A-Game features a radial board as opposed to a grid. This means that each cell that the board has is laid out in a circle surrounding the center of the screen. That being said, that center point can move to any part of the scene if it needs to. The number of cells in each board can change dynamically during runtime, but currently the best number is 8 cells as it is easiest to find the top, bottom, left, right, and diagonals of the screen.
* Each cell object is proximity based, which means that no matter where the screen is touched, the closest cell will be calculated, and activated.
* The moment the nearest Cell object is found and tapped, a single sound will play corresponding to the sound object that is held within the cell. If a Cell has no sound it will play an "empty cell" sound.
* if an empty cell is held down, a new sound will be inserted in its place. The amount of time an empty cell must be held is determined by a variable that can change at any time, but its currently set to 0.3 seconds.
* A randomness algorithm is used to determine what kind of sounds are created. Lower valued sounds are much more likely to spawn than higher ones.
* If a sound object is dragged into another matching sound object (plays the same audio clip), it will merge into a new sound.
* The Audio uses Unity's built in AudioSource component with the spatial setting turned all the way up. This means that the game features 3d sound depending on where a sound is playing from. This makes the gaming experience more enjoyable, and theoretically easier with headphones, but they are not required.

INSTALLMENT INSTRUCTIONS:

UI DOCUMENTATION: <br />
![image](https://github.com/Teaching-Accessibility/course-project-A-Game/assets/108377756/3b49af15-79bf-41d0-bfbe-52b178cdf447) <br />
SCREEN ID: 1 <br />
TITLE: Users View <br />
DESCRIPTION: 
* System Features: This is the simulated screen that the user would see when playing the game in the unity simulator or on an actual phone. The underlying structure of the game contains 10 cells that are not visible to the user but hold the sound objects that the user can play and drag. The eight cells are each in one part of a circle divided into 10 equal sections that start in the middle of the screen. The cells can be moved around the screen by the user and merged with other cells containing the same sound. When the users generate new sounds the probability of which sound is generated depends on the highest sound the user has made through merging.
* User Interactions: When the user taps any place on the screen the game will store the location of the tap. It then takes the location of the tap and calculates which section of the underlying cells on the screen it is closest to. The game then plays the sound of the cell object that was closest to the users tap. If an empty cell is tapped the specific sound for empty cells will play. The user can also hold and drag sounds across the board. When holding down and dragging the selected sound the game will play the sound of the cell it is currently over. When the user lets go of the sound it will merge with the cell it was over if the sounds were the same. When the sounds are the same a new sound will be played when they are merged, and the new sound will be in the cell that the held one was dropped over. If the sounds do not match the cell being dragged by the user will go back to its original place. When the sounds merge the dragged one will be deleted and its original place will now contain an empty cell. To generate a new sound the user needs to hold down over an empty cell and one of the already created sounds will be randomly generated. When the new sound is generated, it will be played so the user knows what sound is now at the spot of the empty cell.
* Design Guidelines: One of the design guidelines this screen follows is being able to be used by people that do and don't have visual impairments. The game is targeted to be accessible to people with blindness and visual impairment, but it can still be used by people without it. Another design guideline the screen follows is low physical effort. The interaction does not require much physical effort because the only actions the user needs to do are tap, drag, and swipe.
* Simulated Back End: This screen uses a simulated back end when it fetches the sound data from the closest cell based on the where the user taps. This is done because the user does not need to know how the cells are stored and managed underneath the screen. That part is something to be known and managed by the developers. <br />

![image](https://github.com/Teaching-Accessibility/course-project-A-Game/assets/108377756/17e751f4-f9cb-4bef-8abc-7f0b6518b592) <br />
SCREEN ID: 2 <br />
TITLE: Invisible Data Structure <br />
DESCRIPTION: This screen is the underlying board structure in unity that is invisible to the user. The speaker shaped objects represent the cell objects that contain the sounds. There are 10 of them on the screen evenly spaced apart into 10 sections. The bright red lines represent the basic sections of each cell and the lighter read lines represent how they expand outside the circle shape to fill the screen. The sounds are played based on which section the tap of the user lands in. This screen implements the same user interactions and design guidelines as screen 1 because they are layered together but this part is invisible. This screen does not use stimulated back end because it is not visible to the user and does not access any other hidden parts.


