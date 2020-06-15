using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLib.CollisionDetection.SeparatingAxisTheorem
{
    public static class SATHelper
    {
        public static bool RunSAT(this ISATAble first, ISATAble second)
        {
            Line[] projectionLines = first.GetProjectionLines().Concat(second.GetProjectionLines()).ToArray();
            foreach (Line line in projectionLines)
            {
                (float min, float max) fProj = first.ProjectOntoLine(line);
                (float min, float max) sProj = second.ProjectOntoLine(line);

                if (fProj.min > sProj.min)
                {
                    (float min, float max) temp = fProj;
                    fProj = sProj;
                    sProj = temp;
                }

                if (fProj.max < sProj.min)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
