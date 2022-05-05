using System;

namespace Data
{
    public abstract class DataAPI
    {
        public static DataAPI CreateApi()
        {
            return new DataAPIBase();
        }
    }

    internal class DataAPIBase : DataAPI
    {

    }
}
