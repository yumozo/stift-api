using StiftApi.Data;

namespace StiftApi.Models;

public class RecordService : IRecordService
{
  private readonly IStiftRepo _repository;

  public RecordService(IStiftRepo repo)
  {
    _repository = repo;
  }

  // Adds new blank record
  public IRecord AddNew(string title)
  {
    Record record = new Record()
    {
      Title = title,
      Date = DateTime.Now,
      Text = string.Empty
    };

    return record;
  }

  // Creates copy of a chosen record
  public IRecord AddCopy(int id)
  {
    var parentRecord = _repository.GetRecordById(id);

    Record record = new Record()
    {
      Title = parentRecord.Title,
      Date = DateTime.Now,
      Text = parentRecord.Text
    };

    return record;
  }

  // Change text of existing record
  public void EditContent(int recordId, string text)
  {
    var record = _repository.GetRecordById(recordId);
    record.Text = text;
  }
}