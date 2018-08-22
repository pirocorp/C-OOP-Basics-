namespace _9._Test
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Test
    {
        private dynamic a;

        public Test(ref int a)
        {
            this.a = a;
        }

        public void Modify()
        {
            this.a++;
        }
    }
}