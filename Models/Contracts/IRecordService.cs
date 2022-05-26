namespace StiftApi.Models;

interface IRecordService
{
  public IRecord AddNew(string title);
  public IRecord AddCopy(int id);

  public void EditContent(int recordId, string text);
}