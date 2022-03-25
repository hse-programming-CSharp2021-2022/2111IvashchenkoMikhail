namespace Seminar_27._01
{
    public class G
    {
        private F _function1;
        private F _function2;

        public G(Calculate del1, Calculate del2)
        {
            _function1 = new F(del1);
            _function2 = new F(del2);
        }

        public double GF(double x0)
        {
            return _function1.Function(_function2.Function(x0));
        }
    }
}