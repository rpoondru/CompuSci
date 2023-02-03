using System;

double position = -1; //initial position
double velocity = 5; //initial velocity
double acceleration = -9.8; //acceleration due to gravity
double c = 0.5; //drag coefficient
double mass = 4; //mass of object
double dt = 0.1; //time step
double totalTime = 100; //total simulation time
double k = 8; //spring constant

//calculate forces
double springForce = -k * (position + 2);
double airResistanceForce = -c * velocity * velocity;
double gravityForce = mass * acceleration;

//net force
double netForce = gravityForce + airResistanceForce + springForce;
acceleration = netForce / mass;

Console.WriteLine("Time (s)\tPosition (m)\tVelocity (m/s)\tAcceleration (m/s^2)");

//iterate over time steps
for (double t = 0; t <= totalTime; t += dt)
{
    //output results to console
    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t\t{3}", t.ToString("F1"), position.ToString("F2"), velocity.ToString("F2"), acceleration.ToString("F2"));
    //update velocity and position
    velocity += acceleration * dt;
    position += velocity * dt;

    //update air resistance force and spring force while checking which direction air resistance should be affecting the net forces
    if (velocity < 0) airResistanceForce = c * velocity * velocity;
    else airResistanceForce = -c * velocity * velocity;
    springForce = -k * (position + 2);
    netForce = gravityForce + airResistanceForce + springForce;
    acceleration = netForce / mass;
}