using System;
namespace AdapterDesign
{
    public class PenAdapter : IPen
    {
        PilotPen pp = new PilotPen();
        public void write(string str)
        {
            pp.mark(str);
        }

    }
}
