## Lab 1 [DONE]
1. Create a new 2D project.
2. If you are able to easily import the Standard 2D asset, play around with them a bit. If you're having trouble with this, skip this step.
3. Add in (at least) one image to your scene. To do that, find an image that you like. In the Project window, right-click Assets and choose Import New. Choose the Image. You should see it added to the Assets folder. In the Inspector window, change "Texture Type" to Sprite (2D and UI).
Then click (menu) GameObject -> 2D Object -> Sprite. Click on the sprite to see it in the Inspector window. Rename it to something descriptive of your picture. In the Sprite Renderer section, click on the small circle next to "Sprite" and choose your picture. You should see it loaded into the scene; adjust position and scale as necessary.
4. Create a background by finding an appropriate image and proceeding as above. Then, in the Sprite Renderer section, find "Sorting Layers." Click on it, and choose "Add Sorting Layer." Add a layer called "Background" and drag it up on top of Default. (Higher layers = deeper in background.) Select "Background" in Sorting Layers. OR set the Z value to be greater.
5. Repeat this procedure so that your scene has a distinct background and foreground.
This lab will not be collected, but hang onto it, because we'll revisit it next week.


## Unity Lab 2: movement and user input [DONE]
This is a lab that explores movement and user input in Unity. We are getting started on a semester-long project of creating a "balloon popping game."
1. Open up the project that you were working on last time and get rid of all the prefabs from it. Those were just to play around with. You should be left with a background and foreground.
Create a sprite out of an image (of your choice).  Give it a Rigidbody2D (AddComponent -> Physics 2D). Disable gravity so that it can hang in mid-air.
2. Write a script that allows user input to control the sprite movement, both vertically and horizontally. You may find it useful to refer to the script that we wrote collaboratively in class. You may find it useful to allow for some sort of sudden surge of vertical movement -- up to you. Remember that the sprite should turn around when it changes directions.
3. Create a balloon sprite using another image. This will be your target. Write a new script that controls its movement. This will not be controlled by user input, so make it fully automatic -- it should move across the screen, in whichever directions you choose. Note that you will want to check if it is moving past the edges of the screen (use the transform.position attribute); if it does, flip it around and send it back in the opposite direction. 

## Unity Lab 3 [DONE]
1. By now, you should have: a player object (movement controlled through user input), and a target balloon (automatic movement).
2. Create a pin  sprite and give it a movement script that sends it moving horizontally across the screen. 
Create a prefab out of the pin. Then delete all instances of the pin prefab from the hierarchy. 
 
3. Allow the player to "shoot" pins: on fire input (Input.GetButton("Fire1")*, the player controller should:
a) Create an instance of the pin at the current position of the player. (Refer to the lecture coin spawner code for help with this.)
b) Activate the pin's movement by calling the script to move it across the screen.
 
4. Add collision detection so that the pin can pop the balloon. Make sure that you have colliders (using "trigger"). Make use of tags so that the pin does not accidentally pop the player! When the pin collides with the balloon, it should destroy it.
 
5. Add a sound effect of your choice to the collision.
 
If you've gotten this far, give yourself a giant pat on the back!
 
* In Unity, "Fire1" is mapped to Ctrl. If you want to give more flexibility to use Option and/or Command also, you can also use Fire2/Fire3  https://docs.unity3d.com/Manual/ConventionalGameInput.html

## Unity Lab 4: text fields and scenes [DONE]
Make the game more interesting!
1. Make your balloon grow as time goes on -- e.g. increase in size every X seconds. You probably want to use InvokeRepeating.
See here: https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html
2. Add a scoring function. The player should get points when the balloon is popped, with more points given if the balloon is smaller and fewer if the balloon is bigger. Create a textbox that shows the score.
3. If the balloon gets "big enough" (size up to you), the balloon disappears and the player gets no points. 
4. Can you add distractors to make the game more challenging? What if the pins had to avoid flying birds or other balloons? Come up with an appropriate distractor and add it.
5. Up until now, our game has had a single scene/level.
Duplicate your scene twice times to create a two new scenes, and then edit the new scenes, for a total of three levels in your game. Each level should increase in difficulty (e.g. the balloon moves faster, the balloon is smaller, etc. -- any combination of these and/or whatever you'd like).
Every time that your player pops the balloon, the game should transition to the next level. Every time the balloon disappears, the current level should restart.
Use File-Build Settings to include all of your scenes in the build, and then test that the levels work.

## Unity Lab 5: UI [DONE] NOTE: Need to do Extra Credit
You knew this was coming ... the Menu / UI lab:
1. Create a menu scene for your game utilizing buttons (as well as any other UI components that you'd like). Your menu must include at least:
instructions
play game
settings
2. Settings must include a volume control for the sound effects in your game. Use a UI Slider and AudioListener.Volume (https://docs.unity3d.com/ScriptReference/AudioListener-volume.html). Note that Sliders are associated with a component called "value" -- you will need to use that to set the volume.
Extra credit: also include a difficulty control. You decide what makes your game easier or harder, just document your choice.
3. A pause/resume functionality in your game, as well as a link back from the game to the main menu.
4. One other UI component of your choice that has not been used so far (e.g. Dropdown, Toggle, Input Field).

## Unity labs 6 and 7: persistent data and high scores
Persistent data:
1. Your game must have two pieces of data that persist from scene to scene (score, health, settings, name, etc.)
2. Your game should store the top X high scores, where X must be at least 5. They should be displayed in decreasing order of score, but the UI details are completely up to you otherwise. Don't forget to add a link to the high scores from your main menu!

## Unity Lab 8: animations [DONE]
Incorporate two animations into your game. The animations must be launched via scripts*; they can either be two animations of the same game object, like we did in class or two animations of different objects.
*i.e., not an animation of a flying bird that is present the entire scene. You must use code to change the animation or start the animation.


## Final
Lab game submission
This is the link to submit your lab game.

Your final game should have:
* layered background (background  /foreground) [CHECK]
* at least one image [CHECK]
* a player-controlled sprite [CHECK]
* an balloon sprite with automatic movement [CHECK]
* the ability for the player to shoot pins at the enemy [CHECK]
* collision detection of pins, using tags so that a player does not pop himself with his own bullets [CHECK]
* sound effect on collisions [CHECK]
* displayed score for player [CHECK]
* increasing size of balloon and impact on score [CHECK]
* at least one distractor [CHECK]
* at least three levels in increasing order of difficulty. Document the difficulty of each level in the directions.
* Fleeing algorithm implemented as one of the levels  (balloon escapes player)
* scene transitions: Every time that your player pops the balloon, the game should transition to the next level. Every time the balloon gets too big and disappears, the current level should be restarted. [CHECK]
* directions (include the basics of each level)
* settings, including a volume setting with a slider [CHECK]
* menu [CHECK]
* pause/resume and link back to menu
* some other UI (dropdown, toggle, input) [CHECK]
* a data item that persist from scene to scene [CHECK]
* a second data item that persists
* high scores (at least 5, presented in order) [CHECK]
* animation #1 [CHECK]
* animation #2 [CHECK]
* Extra credit: difficulty selection by player (with documentation about difficulty)

Please make sure that your game has links back to the menu on each scene, for easy navigation. 

The game submission is due on Sunday, December 4 at 9:00 AM. It is worth 26 points, one point for each of the components on the list above as well as two points for general game and UI design.

Together with your submission, you   must include a document (in PDF format) that checks off the components and says where to find them in the game if relevant (not in the code -- for example, which image do you have? what animations? which data items persist?)  If you do not have any component on the list above, please note so in the document. If you are missing a component and notify me, it will cost you one point. If you are missing a component and do NOT tell me, it will cost you two points (i.e. minimum grade for this project is -24 points).

Name your submission Last Name + First Name + name of game (e.g. Doe John Balloon Popper).
Please submit as a at itch.io game jam; link https://itch.io/jam/fall-2022-lab-game-submission. Please also submit (via Blackboard)  the PDF of documentation along with a link to the GitHub repository hosting the code. You must submit on both itch and Blackboard to get credit. 

(Note that the due date on the itch jam is later than the date here. The correct due date is December 4 at 9:00 AM).
