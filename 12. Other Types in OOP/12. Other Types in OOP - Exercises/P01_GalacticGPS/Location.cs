namespace P01_GalacticGPS
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public struct Location
    {
        private double latitude;
        private double longitude;
        private Planet planet;

        public Location(double latitude, double longitude, Planet planet)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.planet = planet;
        }

        public double Latitude
        {
            get => this.latitude;
            set
            {
                if (value > 90 || value < -90)
                {
                    throw new ArgumentException();
                }

                this.latitude = value;
            }
        }

        public double Longitude
        {
            get => this.longitude;
            set
            {
                if (value > 180 || value < -180)
                {
                    throw new ArgumentException();
                }

                this.longitude = value;
            }
        }

        public Planet Planet
        {
            get => this.planet;
            set => this.planet = value;
        }

        public override string ToString()
        {
            return $"{this.Latitude}, {this.Longitude} - {this.Planet}";
        }
    }
}