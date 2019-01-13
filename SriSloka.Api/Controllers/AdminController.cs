using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SriSloka.Data;
using SriSloka.Model;
using SriSloka.ViewModel;

namespace SriSloka.Api.Controllers
{
  [Produces("application/json")]
  public class AdminController : BaseApiController
  {
    private readonly IRepository<Standard> _standardRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<AdminController> _logger;
    private readonly IRepository<Staff> _staffRepository;

    public AdminController(IMapper mapper,
      ILogger<AdminController> logger, IRepository<Standard> standardRepository,
      IRepository<Subject> subjectRepository,
      IRepository<Staff> staffRepository, SriSlokaDbContext context,
	    RoleManager<IdentityRole> roleManager,
	  UserManager<ApplicationUser> userManager,
      IConfiguration configuration) : base(context,roleManager, userManager, configuration)
    {
      _standardRepository = standardRepository;
      _mapper = mapper;
      _logger = logger;
      _staffRepository = staffRepository;
    }

    [HttpPost]
    [Route("api/[controller]/Standards")]
    public async Task<IActionResult> CreateStandards([FromBody]StandardDto standardDto)
    {
      try
      {
        _logger.LogInformation("Called API to Create standard.");

        if (standardDto == null)
        {
          _logger.LogCritical("Standard object can't be null. About to throw validation exception.");

          throw new ValidationException("Invalid object. Standard object can't be null");
        }

        _logger.LogInformation(standardDto.ToJson());

        var standard = new Standard();

        _mapper.Map(standardDto, standard);

        await _standardRepository.InsertAsync(standard);
      }
      catch (Exception ex)
      {
        _logger.LogError("AdminController, CreateNew Standard", ex);

        throw new ValidationException(ex.Message);
      }

      return Ok();
    }

    [HttpGet]
    [Route("api/[controller]/Standards")]
    public async Task<List<StandardDto>> GetStandards()
    {
      var standardDtos = new List<StandardDto>();
      try
      {
        _logger.LogInformation("Called API to get standards.");

        var standards = await _standardRepository.AllIncludeAsync();

        foreach (var standard in standards)
        {
          var standardDto = new StandardDto();

          _mapper.Map(standard, standardDto);

          standardDtos.Add(standardDto);
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("AdminController, get Standards", ex);

        throw new ValidationException(ex.Message);
      }

      return standardDtos;
    }

    [HttpPut]
    [Route("api/[controller]/Standards")]
    public async Task<IActionResult> UpdateStandards([FromBody] StandardDto standardDto)
    {
      try
      {
        _logger.LogInformation("Called API to Update standard.");

        if (standardDto == null || standardDto.StandardId == 0)
        {
          _logger.LogCritical("Invalid Standard object. About to throw validation exception.");

          throw new ValidationException("Invalid Standard object");
        }

        _logger.LogInformation(standardDto.ToJson());

        var standard = await _standardRepository.FindByKeyAsync(standardDto.StandardId);

        if (standard == null)
        {
          _logger.LogCritical("Invalid Standard object. About to throw validation exception.");

          throw new ValidationException("Invalid Standard object");
        }

        // Now copy the standarddto fields to standard entity
        _mapper.Map(standardDto, standard);

        await _standardRepository.UpdateAsync(standard);
      }
      catch (Exception ex)
      {
        _logger.LogError("AdminController, Update Standard", ex);

        throw new ValidationException(ex.Message);
      }

      return Ok();
    }

    [HttpPost]
    [Route("api/[controller]/Staff")]
    public async Task<IActionResult> AddStaff([FromBody] StaffDto staffDto)
    {
      try
      {
        _logger.LogInformation("Called API to Add new staff.");

        if (staffDto == null)
        {
          _logger.LogCritical("Staff object can't be null. About to throw validation exception.");

          throw new ValidationException("Invalid object. Staff object can't be null");
        }

        _logger.LogInformation(staffDto.ToJson());

        var staff = new Staff();

        _mapper.Map(staffDto, staff);

        await _staffRepository.InsertAsync(staff);
      }
      catch (Exception ex)
      {
        _logger.LogError("AdminController, CreateNew Staff", ex);

        throw new ValidationException(ex.Message);
      }

      return Ok();
    }


    [HttpGet]
    [Route("api/[controller]/Staff")]
    public async Task<List<StaffDto>> GetStaff()
    {
      var staffDtos = new List<StaffDto>();
      try
      {
        _logger.LogInformation("Called API to get staff.");

        var staff = await _staffRepository.AllIncludeAsync();

        foreach (var staffMember in staff)
        {
          var staffDto = new StaffDto();

          _mapper.Map(staffMember, staffDto);

          staffDtos.Add(staffDto);
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("AdminController, get Staff", ex);

        throw new ValidationException(ex.Message);
      }

      return staffDtos;
    }

    [HttpPut]
    [Route("api/[controller]/Staff")]
    public async Task<IActionResult> UpdateStaff([FromBody] StaffDto staffDto)
    {
      try
      {
        _logger.LogInformation("Called API to Update staff.");

        if (staffDto == null || staffDto.StaffId == 0)
        {
          _logger.LogCritical("Invalid Staff object. About to throw validation exception.");

          throw new ValidationException("Invalid staff object");
        }

        _logger.LogInformation(staffDto.ToJson());

        var staff = await _staffRepository.FindByKeyAsync(staffDto.StaffId);

        if (staff == null)
        {
          _logger.LogCritical("Invalid staff object. About to throw validation exception.");

          throw new ValidationException("Invalid staff object");
        }

        _mapper.Map(staffDto, staff);

        await _staffRepository.UpdateAsync(staff);
      }
      catch (Exception ex)
      {
        _logger.LogError("AdminController, Update staff", ex);

        throw new ValidationException(ex.Message);
      }

      return Ok();
    }
  }
}
