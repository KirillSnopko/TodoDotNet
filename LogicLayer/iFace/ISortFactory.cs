using System.Collections.Generic;


namespace LogicLayer.iFace
{
    public interface ISortFactory<T>
    {
        List<T> sort(string paramSort, List<T> list);
    }
}
