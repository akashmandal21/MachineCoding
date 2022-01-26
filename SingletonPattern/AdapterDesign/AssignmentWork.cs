using System;
namespace AdapterDesign
{
    public class AssignmentWork
    {
        private IPen p;
        public IPen getP()
        {
            return this.p;
        }
        public void SetP(IPen p)
        {
            this.p = p;
        }
        public void writeAssignment(string str)
        {
            p.write(str);
        }
    }
}
