namespace UcenjeCS
{
    internal class V02Metode
    {
        // Napisati metodu koja za dva primljena decimalna broja vraća cijeli dio zbroja primljenih brojeva
        // 2.7 i 3.7 vraća 6
        public static int ZbrojCijelogDijela(float a, float b)
        {
            return ZbrojCijelogDijela((double)a, (double)b);
        }

        // Method overloading => potpis metode: naziv + lista parametara

        public static int ZbrojCijelogDijela(double a, double b)
        {
            return (int)(a + b);
        }



    }
}
