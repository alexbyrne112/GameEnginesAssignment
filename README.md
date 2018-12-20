# GameEnginesAssignment_C15492952_Alex_Byrne
First Assignment for Game Engines 1

[![YouTube](https://youtu.be/JF9NQfbgHlk)


__Description__

This is a Unity project in which an audio File is put into the program and the Audio is Analysied and Certain outcomes happe based on the
different Frequency bands and the volume at each band. In this specific project to start you will see a large Orb is the center of the screen.
once the track plays this orb has perlin noise applied to it along with the frequency band value to give it the desired effect of a warping
Sphere to the music. you will also see 2 particle systems emmiting particles that are either "Seeking" or "Fleeing" from an invisible 
GameObject that you cannot see. this gives a circular motion to the particles as they spread outwards.
Next you will see orbs surrounding the big orb. these orbs are gameobjects containing 4 Particle systems in each and they too are affected by the track.
Each small orb is assigned a frequency band and the particles in the gameobject are all acaled based on the value in the frequency band.
you will also notice lights from each of the orbs emmiting light onto the terrain below. the terrain below is also effected by the track.
this like the big orb has perlin noise applied to it in order for it to move as it does and then a frequency band is applied to it to give the pulsing effect 
along with the music.

All of the project was developed by me excluding one of the scripts which is an open source Perlin noise script. The rest was progr5ammed by myself with reference to
lectures and online research.

I am most proud of the Perlin noise and the music implementation into the big orb. this was difficult as the orb is a 6 terrain faces warped into a sphere
and then further warped with the perlin noise and music frequencies. This was difficult and quite confusing but at the very end i got my head
around it. it was very confusing with the different sides being faces of a cube.
