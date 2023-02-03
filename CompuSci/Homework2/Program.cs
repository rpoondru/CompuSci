using System;
using Utility;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Level1();
            //Level2();
            //Level3();
        }
        
        static private void Level1()
        {
            //Initalize variables
            double positionX = 0;
            double positionZ = 0;
            double velocityX = 3.53553;
            double velocityZ = 3.53553;
            double acceleration = -9.8;
            double mass = 4;
            double dt = 0.001;
            double time = 0;

            //Calculate forces acting on object
            double gravityForce = mass * acceleration;

            double netForce = gravityForce;
            acceleration = netForce / mass;

            double speed = Math.Sqrt((velocityX * velocityX) + (velocityZ * velocityZ));

            Console.WriteLine("Time (s)\tZ Position (m)\tX Position (m)\t Speed (m/s)\tAcceleration (m/s^2)");

            //Loop to update velocity and position before the object hits the ground while outputting variables
            while (positionZ >= 0)
            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t\t{3}\t\t\t{4}", Math.Round(time, 2), Math.Round(positionZ, 2), Math.Round(positionX, 2), Math.Round(speed, 2), Math.Round(Math.Abs(acceleration), 2));

                velocityZ += acceleration * dt;
                positionZ += velocityZ * dt;

                positionX += velocityX * dt;

                netForce = gravityForce;
                acceleration = netForce / mass;
                speed = Math.Sqrt((velocityX * velocityX) + (velocityZ * velocityZ));

                time += dt;
            }

            Console.ReadLine();
        }

        static private void Level2()
        {
            //Initalize position & velocity variables
            double positionX = 0;
            double positionZ = 0;
            double velocityX = 3.53553;
            double velocityZ = 3.53553;
            double speed = Math.Sqrt((velocityX * velocityX) + (velocityZ * velocityZ));

            //Initalize other variables
            double gravity = -9.8;
            double mass = 4;
            double dt = 0.001;
            double time = 0;
            double c = 0.5;

            //Initalize force variables and calculate acceleration 
            double airResistanceForceX = c * speed * speed;
            double airResistanceForceZ = c * speed * speed;
            double gravityForce = mass * gravity;

            double netForceZ = gravityForce - airResistanceForceZ;
            double accelerationZ = netForceZ / mass;

            double netForceX = airResistanceForceX;
            double accelerationX = netForceX / mass;

            double acceleration = Math.Sqrt(Math.Abs(accelerationX * accelerationX + accelerationZ * accelerationZ));

            Console.WriteLine("Time (s)\tZ Position (m)\tX Position (m)\t Speed (m/s)\tAcceleration (m/s^2)");

            //Loop to update velocity, position, and acceleration before the object hits the ground while outputting results
            while(positionZ >= 0)
            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t\t{3}\t\t\t{4}", Math.Round(time, 3), Math.Round(positionZ, 2), Math.Round(positionX, 2), Math.Round(speed, 2), Math.Round(acceleration, 2));

                velocityZ += accelerationZ * dt;
                positionZ += velocityZ * dt;

                velocityX += -accelerationX * dt;
                positionX += velocityX * dt;

                airResistanceForceX = c * velocityX * velocityX;
                airResistanceForceZ = c * velocityZ * velocityZ * Math.Sign(velocityZ);
                
                netForceZ = gravityForce - airResistanceForceZ;
                accelerationZ = netForceZ / mass;

                netForceX = airResistanceForceX;
                accelerationX = netForceX / mass;

                speed = Math.Sqrt((velocityX * velocityX) + (velocityZ * velocityZ));
                acceleration = Math.Sqrt(Math.Abs(accelerationX * accelerationX + accelerationZ * accelerationZ));

                time += dt;
            }

            Console.ReadLine();
        }
        
        static private void Level3()
        {
            //Initalize position & velocity variables while calculating the magnitude of position and velocity
            double PvectorX = -1;
            double PvectorY = 1;
            double PvectorZ = -1;
            double position = Math.Sqrt(PvectorX * PvectorX + PvectorY * PvectorY + PvectorZ * PvectorZ);


            double VvectorX = 5;
            double VvectorY = -1;
            double VvectorZ = 3;
            double speed = Math.Sqrt(VvectorX * VvectorX + VvectorY * VvectorY + VvectorZ * VvectorZ);

            //Initalize other variables
            double gravity = -9.8;
            double mass = 4;
            double dt = 0.01;
            double totalTime = 80;
            double c = 0.5;
            double k = 8;
            double length = 2;

            //Calculates forces acting upon object which are used to calculate acceleration
            double airResistanceForceX = -c * VvectorX * speed;
            double airResistanceForceY = -c * VvectorY * speed;
            double airResistanceForceZ = -c * VvectorZ * speed;

            double springForceX = -k * (PvectorX - length * PvectorX / position);
            double springForceY = -k * (PvectorY - length * PvectorY / position);
            double springForceZ = -k * (PvectorZ - length * PvectorZ / position);

            double gravityForceX = 0;
            double gravityForceY = 0;
            double gravityForceZ = mass * gravity;
            
            double netForceX = springForceX + airResistanceForceX + gravityForceX;
            double netForceY = springForceY + airResistanceForceY + gravityForceY;
            double netForceZ = springForceZ + airResistanceForceZ + gravityForceZ;
            
            double AvectorX = netForceX / mass;
            double AvectorY = netForceY / mass;
            double AvectorZ = netForceZ / mass;
            double acceleration = Math.Sqrt(AvectorX * AvectorX + AvectorY * AvectorY + AvectorZ * AvectorZ);

            Console.WriteLine("Time (s)\tX Position\tY Position\tZ Position\tSpeed Vector (m/s)\tAcceleration (m/s^2)");

            //Loop to update velocity, position, and acceleration while outputting results
            //I used a for loop to 80 seconds because I wanted to see the object oscillate back and forth
            //This also confirmed my answer to the problem on the answer sheet because I was able to make that
            //the velocity never went above 1m/s after 15.32 seconds
            for (double time = 0; time < totalTime; time += dt)
            {

                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t\t{3}\t\t\t{4}\t\t\t{5}", Math.Round(time, 3), Math.Round(PvectorX, 2), Math.Round(PvectorY, 2), Math.Round(PvectorZ, 2), Math.Round(speed, 2), Math.Round(acceleration, 2));

                VvectorX += AvectorX * dt;
                VvectorY += AvectorY * dt;
                VvectorZ += AvectorZ * dt;
                
                PvectorX += VvectorX * dt;
                PvectorY += VvectorY * dt;
                PvectorZ += VvectorZ * dt;

                position = Math.Sqrt(PvectorX * PvectorX + PvectorY * PvectorY + PvectorZ * PvectorZ);
                speed = Math.Sqrt(VvectorX * VvectorX + VvectorY * VvectorY + VvectorZ * VvectorZ);

                airResistanceForceX = -c * VvectorX * speed;
                airResistanceForceY = -c * VvectorY * speed;
                airResistanceForceZ = -c * VvectorZ * speed;

                springForceX = -k * (PvectorX - length * PvectorX / position);
                springForceY = -k * (PvectorY - length * PvectorY / position);
                springForceZ = -k * (PvectorZ - length * PvectorZ / position);

                netForceX = springForceX + airResistanceForceX + gravityForceX;
                netForceY = springForceY + airResistanceForceY + gravityForceY;
                netForceZ = springForceZ + airResistanceForceZ + gravityForceZ;

                AvectorX = netForceX / mass;
                AvectorY = netForceY / mass;
                AvectorZ = netForceZ / mass;
                acceleration = Math.Sqrt(AvectorX * AvectorX + AvectorY * AvectorY + AvectorZ * AvectorZ);
            
            }
            Console.ReadLine();
        }
    }
}