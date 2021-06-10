# Plane Game

This is a project I undertook over a week of lockdown, learning a lot more of unity. Warning, though - none of it is object oriented. It's a 3D game where you fly about using mouse-aim flight on a multiplayer server (dedicated or self hosted) shooting each other with guns and missiles.

# Some images

![image of the main menu](https://i.imgur.com/IOWSJT7.png)

![Volumetric exhaust](https://i.imgur.com/lVWhUGs.png)

![Just flying around](https://i.imgur.com/bQRrWTR.png)

![Shooting](https://i.imgur.com/Zs5Ozmt.png?1)

# What do you do?
*  Fly about
* Shoot other people

# How do you do that?
Shooting:
* Left click to shoot (projectile, not raycast)

Gaining lock:
* When you have line of sight on someone for more than 5 seconds you will gain target lock. You will need to keep line of sight to keep a lock and your adversary will know about this the moment you get line of sight on them.

Using weapons that require a lock:
* Once you have a lock you can fire a missile, which will follow the target. The only way to escape the missile once lock is established and it has been fired is to lead it into the environment or do quick turns to throw it off course until it runs out of fuel.

#  What about flying?
* The flying is simple, intuitive, and easy to use - and probably because about half of it was written by someone else. Check out https://github.com/brihernandez/MouseFlight for the base I wrote upon. 
* Simply aim somewhere to go somewhere. 
* Scroll down to slow down but turn faster
* Scroll up to speed up but turn s l o w l y.
