using System.Collections.Generic;

namespace MonoLib.CollisionDetection.SeparatingAxisTheorem
{
    public interface ISATAble
    {
        (float min, float max) ProjectOntoLine(Line line);
        IEnumerable<Line> GetProjectionLines();
    }
}
