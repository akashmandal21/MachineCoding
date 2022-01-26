using System;

namespace AdapterDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            IPen p = new PenAdapter();
            AssignmentWork aw = new AssignmentWork();
            aw.SetP(p);
            aw.writeAssignment("Writing assignment");
        }
    }
}
