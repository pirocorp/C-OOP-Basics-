namespace Proxy
{
    /// <summary>
    /// The 'Proxy Object' class
    /// </summary>
    internal class MathProxy : IMath
    {
        private readonly IMath math = new Math();

        public double Add(double x, double y)
        {
            // Do some security checks, parameter changes, logging or some other proxy work
            return this.math.Add(x, y);
        }

        public double Sub(double x, double y)
        {
            // Do some security checks, parameter changes, logging or some other proxy work
            return this.math.Sub(x, y);
        }

        public double Multiply(double x, double y)
        {
            // Do some security checks, parameter changes, logging or some other proxy work
            return this.math.Multiply(x, y);
        }

        public double Divide(double x, double y)
        {
            // Do some security checks, parameter changes, logging or some other proxy work
            return this.math.Divide(x, y);
        }
    }
}
