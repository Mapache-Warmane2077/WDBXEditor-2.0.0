using System.Collections;
using System.Collections.Generic;

namespace WDBXEditor.Archives.CASC.Misc
{
    public class ByteArrayComparer : IEqualityComparer, IEqualityComparer<object>
    {
        public new bool Equals(object x, object y)
        {
            return x is not IStructuralEquatable eq ? object.Equals(x, y) : eq.Equals(y, this);
        }

        public int GetHashCode(object obj)
        {
            return obj is not IStructuralEquatable eq ? EqualityComparer<object>.Default.GetHashCode(obj) : eq.GetHashCode(this);
        }
    }
}
