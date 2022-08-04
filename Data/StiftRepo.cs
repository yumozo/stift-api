using StiftApi.Models;

namespace StiftApi.Data
{
  public class StiftRepo : IRecordRepo
  {
    private readonly AppDbContext _context;

    public StiftRepo(AppDbContext context)
    {
      _context = context;
    }
    public void AddRecord(IRecord record)
    {
      record.Date = DateTime.Now;
      _context.Add(record);
    }

    public IEnumerable<IRecord> GetAllRecords()
    {
      return _context.Records.ToList();
    }

    public IRecord GetRecordById(int id)
    {
      var record = _context.Records.FirstOrDefault(p => p.Id == id);
      if (record != null)
        return record;
      return null; // I had left this for later.
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }
}