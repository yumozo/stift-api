using StiftApi.Models;

namespace StiftApi.Data
{
  public interface IRecordRepo
  {
    bool SaveChanges();
    IEnumerable<IRecord> GetAllRecords();
    IRecord GetRecordById(int id);
    void AddRecord(IRecord record);
  }
}