# Plane Game

This is a project I undertook over a week and a half of lockdown, learning a lot more of unity. Warning, though - none of it is object oriented. 

# What do you do?
*  Fly about
* Shoot other people (it's multiplayer)

# How do you do that?
Shooting:
* Left click to wide-angle shoot (projectile, not raycast)
* Right click to short angle shoot (projectile, not raycast)
* There's a laser emitted from the center of your craft that acts as a crosshair. 

Gaining lock:
* When you have line of sight on someone for more than 5 seconds (TODO, it's instant) you will gain target lock. You will need to keep line of sight to keep a lock and your adversary will know about this the moment you get line of sight on them.

Using weapons that require a lock:
* (TODO) once you have a lock you can fire a raycast weapon with middle click which will automatically aim towards the target, making long range combat more viable.

#  What about flying?
* The flying is simple, intuitive, and easy to use - and probably because about half of it was written by someone else. Check out https://github.com/brihernandez/MouseFlight for the base I wrote upon. 
* Simply aim somewhere to go somewhere. 
* Scroll down to slow down but turn faster
* Scroll up to speed up but turn s l o w l y.

# How can I make a server?
Lol, nobody's asking this. Port forward 7777 and either host or run dedicated in the menu. I'll sometimes (very sometimes) have a server running at 86.31.133.208, but don't count on it. I'm going to try to get a domain name... at some point.
