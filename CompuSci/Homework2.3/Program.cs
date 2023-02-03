using System;
using System.Linq.Expressions;

namespace Projectiles
{
    class Projectile
    {
        private double position;
        private double velocity;
        private double acceleration;
        private double mass;
        public Projectile(double initialPosition, double initialVelocity, double acceleration, double mass)
        {
            position = initialPosition;
            velocity = initialVelocity;
            this.acceleration = acceleration;
            this.mass = mass;
        }

        public void Calculate(double force, double dt)
        {
            acceleration = force / 10;
            velocity = acceleration * dt;
            position = velocity * dt;
        }

        public void Reset()
        {
            position = 0;
            velocity = 0;
            acceleration = 0;
        }

        public void Print()
        {
            Console.WriteLine("Position: {0} m", position);
            Console.WriteLine("Velocity: {0} m/s", velocity);
            Console.WriteLine("Acceleration: {0} m/s^2", acceleration);
        }
    }
    class World
    {
        private Projectile[] projectiles;
        private double time;                
        
        public World(int numProjectiles)
        {
            projectiles = new Projectile[numProjectiles];
            for (int i = 0; i < numProjectiles; i++)
            {
                projectiles[i] = new Projectile(0, 0, 0, 10);
            }
            time = 0;
        }
        public void AddProjectile(Projectile projectile)
        {
            Projectile[] temp = new Projectile[projectiles.Length + 1];
            for (int i = 0; i < projectiles.Length; i++)
            {
                temp[i] = projectiles[i];
            }
            temp[temp.Length - 1] = projectile;
            projectiles = temp;
        }

        //calculate forces like gravity, air resistance using c = 0.5 and spring force of k = 8 
        public void Calculate(double dt)
        {
            for (int i = 0; i < projectiles.Length; i++)
            {
                double force = 0;
                force += -8 * projectiles[i].position;
                force += -0.5 * projectiles[i].velocity;
                force += -9.8 * projectiles[i].mass;
                projectiles[i].Calculate(force, dt);
            }
            time += dt;
        }

        public void Print()
        {
            Console.WriteLine("Time: {0} s", time);
            for (int i = 0; i < projectiles.Length; i++)
            {
                projectiles[i].Print();
            }
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            World world = new World(3);
            world.Calculate(0.01);
            world.Print();
        }
    }
}