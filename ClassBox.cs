using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;



class Box
{
    private double length;
    private double width;
    private double height;

    public Box (double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get { return this.length; }
        private set {

            if(value <= 0)
            {
                throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                     
            }
            this.length = value; }
    }

    public double Width
    {
        get { return this.width; }
        private set {

            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");

            }
            this.width = value; }
    }

    public double Height
    {
        get { return this.height; }
        private set {

            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");

            }
            this.height = value; }
    }

    public double GetSurfaceArea()
    {
        return (2 * this.length * this.height) + (2 * this.length * this.width) + (2 * this.width * this.height);
    }

    public double GetLateralSurfaceArea()
    {
        return (2 * this.length * this.height) + (2 * this.height * this.width);
    }

    public double GetVolume() {

        return this.length * this.height * this.width;
    }

    public override string ToString()
    {
        string result = 
                $"Surface Area - {this.GetSurfaceArea():F2} \r\n" +
                $"Lateral Surface Area - {this.GetLateralSurfaceArea():F2} \r\n" +
                $"Volume - {this.GetVolume():F2}";

        return result;
    }
}


    public class ClassBox
    {
        public static void Main()
        {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());
        
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        try
        {
            Box box = new Box(length, width, height);
            Console.WriteLine(box);
        }

        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

