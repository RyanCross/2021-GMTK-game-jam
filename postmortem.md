# About
This is a postmortem of _Jekyll_, a top-down shooter about a character that is constantly swapping between different forms against their will. You can play/rate it **[here](https://itch.io/jam/gmtk-2021/rate/1087434).**

The goal was to force the player to be constantly adapting to the different playstyles of each form, strategically utilizing the strengths of each form to take out enemies, and mitigating each form's weaknesses on the fly. 

This will be a recap some of the most useful things learned throughout the jam as well as some of the challenges. I hope it will be useful to some jammer's out there.

# The Valuable Stuff 

## Cinemachine's 2D Camera
An easy recommend for anyone working in 2D, you get an extremely customizable camera with high quality features out of the box. This saved SO much time and it's an easy package install from the Asset Manager. 

Perks:
  - Mouse Lookahead
  - Deadzones
  - Softzones (like deadzones, but _gradual_)
  - Much more

It's as easy as creating a 2D camera from the Cinemachine tab and setting your player as the Follow parameter in the inspector.

## TileMaps & Tile Palettes
It hurts my soul that I did any sprite based level development without these tools. Utilizing the tilemap & palette workflow makes map building extremely fast and easy. 

### TileMaps

Tilemaps are a great way to store 2D terrain data for your levels.

Perks:
- Multiple tilemaps in any grid, which allow them to act as layers for building & sorting complex terrain
- Generate editable colliders for an entire tilemap with one click

Here I've placed only the walls on a separate tilemap, and layered it above the base tilemap, allowing me to generate all my wall collisions in one go.

![multiple_tilemaps](https://user-images.githubusercontent.com/10676622/121978939-d8994a80-cd4e-11eb-813c-bc1fa60d5323.png)

### Tile Palettes
Tile palettes are exactly what they sound like, they let you "paint" your TileMaps with ease. You can easily turn an entire Spritesheet into a palette. 

![ewz5l96FNw](https://user-images.githubusercontent.com/10676622/121979322-8dcc0280-cd4f-11eb-819b-8dedf4ec058b.gif)

Setup:
1. Splice your spritesheet via the sprite editor, don't worry if you have extra stuff like character sprites in it. 
2. Open a Tile Palette window via Window -> Tile Palette
3. Drag your spliced spritesheet, not the individual frames, into the Tile Palette window, this will create the palette while preserving the original spritesheet order.
4. Paint away!


### Scriptable Objects
It feels like I just scratched the surface of these, but first impressios are that they're powerful data containers for Unity with a lot of flexibility.

In *Jekyll*, SO's were used to store all of the stats & information about each of Jekyll's forms. This included animation controllers and other game objects like each form's projectile prefab. These object's made form swapping logic easy to implement once the form objects were built. It also had the added perk of making it super easy to tweak the stats on each form!

![scriptableObjects](https://user-images.githubusercontent.com/10676622/121979872-9bce5300-cd50-11eb-9348-59fe9f1211f3.png)

### Planning
I've saved the least technical bit for the end of this section, but planning is so important for a successful jam. Here's a few tips to help you with your next jam.
1. When in the idea creation phase, don't _wait_ for inspiration. Sit down and start writing (or doodling). Putting things on paper will help your brain get past the surface thoughts swirling around in your head and really help with brainstorming. 
2. Make a list of your _capabilities_. What you've done prior or what you know you can do easily. For some people, like myself, this list may be very short. This list isn't meant to be a hard limit on what you can create, but it will aid in realistic idea generation and help protect against overscoping.
3. Use a task management board like Trello. Create small, but meaningful tasks!
4. Follow up on 3, create a "Minimum Viable Product" column, this should ideally contain only the tasks that are required for you to have a functioning game. 

After review, this jam probably my most successful at planning. Even though the game barely scratched the surface of the idea, it (mostly) works; and is a functioning, if barebones representation of the idea. Which in 48hrs is something to be proud of.

# Challenges and Limitations
Lastly, a few personal challenges and limitations I encountered in the jam. Rapid fire style.
1. Math is hard, and my weak background in the subject definitely hurt me when trying to create different shooting patterns for each form. Need to spend some quality time understanding Quaternions and Vector math.
2. Hit FX are REALLY important for communicating damage, and neglecting them until the very end was definitely a mistake, I should have prioritized this over the third dragon form.
3. Last but not least: `beer + sleep deprivation = messy code.` 

