using Microsoft.AspNetCore.Mvc;
using StiftApi.Models;
using StiftApi.Data;
using StiftApi.Dtos;
using AutoMapper;

namespace StiftApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ArchiveController : ControllerBase
{
  private readonly ILogger<ArchiveController> _logger;
  private readonly IStiftRepo _repository;
  private readonly IMapper _mapper;
  private readonly IRecordService? _recordService;

  public ArchiveController(
    ILogger<ArchiveController> logger,
    IStiftRepo repo,
    IMapper mapper
    )
  {
    _logger = logger;
    _repository = repo;
    _mapper = mapper;
  }

  [HttpGet]
  public ActionResult<IEnumerable<RecordReadDto>> GetRecords()
  {
    Console.WriteLine("--> Getting all existing records..."); // Replace it with logger.
    var records = _repository.GetAllRecords();

    if (records != null)
      return Ok(_mapper.Map<IEnumerable<RecordReadDto>>(records));
    else
      return NotFound();
  }

  [HttpGet("{id}", Name = "GetRecordById")]
  public ActionResult<RecordReadDto> GetRecordById(int id)
  {
    Console.WriteLine("--> Getting the record..."); // Replace it with logger.

    var record = _repository.GetRecordById(id);
    if (record != null)
      return Ok(_mapper.Map<RecordReadDto>(record));
    else return NotFound();
  }

  // [HttpPost]
  // public Task<ActionResult<RecordReadDto>> CreateRecord(RecordCreateDto recordCreateDto)
  // {
  //   _recordService.New()
  //   // Creating and posting new Record.
  //   return null;
  // }
  [HttpPost]
  public async Task<ActionResult<RecordReadDto>> CreateRecord(RecordCreateDto recordCreateDto)
  {
    var recordModel = _mapper.Map<Record>(recordCreateDto);
    _repository.AddRecord(recordModel);
    _repository.SaveChanges();

    var recordReadDto = _mapper.Map<RecordReadDto>(recordModel);

    return CreatedAtRoute(nameof(GetRecordById), new { Id = recordReadDto.Id }, recordReadDto);
  }

  [HttpPut]
  public ActionResult EditContent(int id, string text)
  {
    _recordService.EditContent(id, text);

    return Ok();
  }
}