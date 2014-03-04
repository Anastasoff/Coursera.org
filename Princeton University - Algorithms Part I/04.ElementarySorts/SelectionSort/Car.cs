namespace SelectionSort
{
    using System;

    public class Car : IComparable<Car>
    {
        public Car(string brand, string model, int year)
        {
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public override bool Equals(object obj)
        {
            Car car = obj as Car;

            if (car == null)
            {
                return false;
            }

            if (!object.Equals(this.Brand, car.Brand))
            {
                return false;
            }

            if (!object.Equals(this.Model, car.Model))
            {
                return false;
            }

            if (this.Year != car.Year)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.Brand, this.Model, this.Model);
        }

        public static bool operator ==(Car firstCar, Car secondCar)
        {
            return Car.Equals(firstCar, secondCar);
        }

        public static bool operator !=(Car firstCar, Car secondCar)
        {
            return !Car.Equals(firstCar, secondCar);
        }

        public int CompareTo(Car car)
        {
            if (this.Brand != car.Brand)
            {
                return this.Brand.CompareTo(car.Brand);
            }

            if (this.Model != car.Model)
            {
                return this.Model.CompareTo(car.Model);
            }

            if (this.Year != car.Year)
            {
                return this.Year.CompareTo(car.Year);
            }

            return 0;
        }
    }
}