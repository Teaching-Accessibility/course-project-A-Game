GROUP MEMBERS:
1) Eli Bennett
2) Sara Wooten: Empty cell sounds & Probability of different sounds spawning
3) Preston ___

FEATURES:

INSTALLMENT INSTRUCTIONS:

UI DOCUMENTATION: <br />
![image](https://github.com/Teaching-Accessibility/course-project-A-Game/assets/108377756/3b49af15-79bf-41d0-bfbe-52b178cdf447) <br />
SCREEN ID: 1 <br />
TITLE: Users View <br />
DESCRIPTION: 
* System Features: This is the simulated screen that the user would see when playing the game in the unity simulator or on an actual phone. The underlying structure of the game contains 8 cells that are not visible to the user but hold the sound objects that the user can play and drag. The eight cells are each in one part of a circle divided into 8 equal sections that start in the middle of the screen. The cells can be moved around the screen by the user and merged with other cells containing the same sound. When the users generate new sounds the probability of which sound is generated depends on the highest sound the user has made through merging.
* User Interactions: When the user taps any place on the screen the game will store the location of the tap. It then takes the location of the tap and calculates which section of the underlying cells on the screen it is closest to. The game then plays the sound of the cell object that was closest to the users tap. If an empty cell is tapped the specific sound for empty cells will play. The user can also hold and drag sounds across the board. When holding down and dragging the selected sound the game will play the sound of the cell it is currently over. When the user lets go of the sound it will merge with the cell it was over if the sounds were the same. When the sounds are the same a new sound will be played when they are merged, and the new sound will be in the cell that the held one was dropped over. If the sounds do not match the cell being dragged by the user will go back to its original place. When the sounds merge the dragged one will be deleted and its original place will now contain an empty cell. To generate a new sound the user needs to hold down over an empty cell and one of the already created sounds will be randomly generated. When the new sound is generated, it will be played so the user knows what sound is now at the spot of the empty cell.
* Design Guidelines: One of the design guidelines this screen follows is being able to be used by people that do and don't have visual impairments. The game is targeted to be accessible to people with blindness and visual impairment, but it can still be used by people without it. Another design guideline the screen follows is low physical effort. The interaction does not require much physical effort because the only actions the user needs to do are tap, drag, and swipe.
* Simulated Back End: This screen uses a simulated back end when it fetches the sound data from the closest cell based on the where the user taps. This is done because the user does not need to know how the cells are stored and managed underneath the screen. That part is something to be known and managed by the developers. <br />

![image](https://github.com/Teaching-Accessibility/course-project-A-Game/assets/108377756/d4f9525e-aebb-4a1f-b430-b8b65351a734)


