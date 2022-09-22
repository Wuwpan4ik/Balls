using System;
using System.Windows.Forms;

namespace GravityBalls
{
	public class WorldModel
	{
		public double BallX;
		public double BallY;
		public double BallRadius;
		public double WorldWidth;
		public double WorldHeight;
		public double xSpeed = 0;
        public double ySpeed = 100;
		public double airResistance = 0.9944;

        public void SimulateTimeframe(double dt)
		{
			BallX = Math.Min(BallX + xSpeed * dt, WorldWidth - BallRadius);
            BallY = Math.Min(BallY + ySpeed * dt , WorldHeight - BallRadius);
			//MouseRepulsion();
			SlowdownBall();
            BounceWall();
			SharpBoost();
        }

		public void forceAttraction()
		{
			if (ySpeed > 0)
			{
				ySpeed *= 1.015;
			} else
			{
				ySpeed /= 1.015;
			}
		}

		public void SlowdownBall()
		{
			xSpeed *= airResistance;
			ySpeed *= airResistance;
			forceAttraction();
		}

		public void MouseRepulsion()
		{
			xSpeed -= (Cursor.Position.X - BallX) * 0.005;
			ySpeed -= (Cursor.Position.Y - BallY) * 0.005;
		}

		public void BounceWall()
        {
            if (BallX == WorldWidth - BallRadius || BallX <= BallRadius) 
				xSpeed *= -1;
            if (BallY == WorldHeight - BallRadius || BallY <= BallRadius) 
				ySpeed *= -1;
        }
		
		public void SharpBoost()
		{
			if (Math.Abs(xSpeed) < 0.5 && Math.Abs(ySpeed) < 0.5)
			{
				xSpeed = 100;
				ySpeed = 100;
			}
		}
	}
}