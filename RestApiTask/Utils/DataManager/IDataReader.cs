namespace KasperskyTask.Utils.DataManager
{
    interface IDataReader
    {
        T ReadProperty<T>(string key);
        T ReadObject<T>();
    }
}
