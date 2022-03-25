namespace Seminar_27._01
{
    public delegate double Calculate(double x);
    
    public class F : IFunction
    {
        private Calculate _calculate;

        public F(Calculate del)
        {
            _calculate = del;
        }
        
        public double Function(double x)
        {
            return _calculate(x);
        }
    }
}