using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SriSloka.Data;
using SriSloka.Model;
using SriSloka.SharedKernel;
using SriSloka.ViewModel;

namespace SriSloka.Api.Controllers
{
    [Produces("application/json")]
    public class SubjectsController : BaseApiController
    {
        private IRepository<Subject> _subjectsRepository { get; set; }
        private readonly IMapper _mapper;
        private readonly ILogger<AdminController> _logger;

        public SubjectsController(IMapper mapper,
            ILogger<AdminController> logger, 
          IRepository<Subject> subjectRepository,
          SriSlokaDbContext context,
			RoleManager<IdentityRole> roleManager,
          UserManager<ApplicationUser> userManager,
          IConfiguration configuration)
          : base(context,roleManager, userManager, configuration)
    {
            _subjectsRepository = subjectRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Subjects([FromBody]SubjectDto subjectDto)
        {
            try
            {
                _logger.LogInformation("Called API to create subjects.");

                if (subjectDto == null)
                {
                    _logger.LogCritical("Subjects object can't be null. " +
                                        "About to throw validation exception.");

                    throw new ValidationException("Invalid object. Subjects object can't be null");
                }

                _logger.LogInformation(subjectDto.ToJson());

                var subject = new Subject();

                _mapper.Map(subjectDto, subject);

                await _subjectsRepository.InsertAsync(subject);
            }
            catch (Exception ex)
            {
                _logger.LogError("AdminController, CreateNew Subjects", ex);

                throw new InvalidOperationException(ex.Message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<List<SubjectDto>> Subjects()
        {
            var subjectsDto = new List<SubjectDto>();
            try
            {
                _logger.LogInformation("Called API to get subjects.");

                var subjects = await _subjectsRepository.AllIncludeAsync(x => x.Traits);

                foreach (var subject in subjects)
                {
                    var subjectDto = new SubjectDto();

                    _mapper.Map(subject, subjectDto);

                    subjectsDto.Add(subjectDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("AdminController, get subjects", ex);

                throw new InvalidOperationException(ex.Message);
            }

            return subjectsDto;
        }

        [HttpPut]
        [Route("api/[controller]")]
        public async Task<IActionResult> UpdateSubjects([FromBody] SubjectDto subjectDto)
        {
            try
            {
                _logger.LogInformation("Called API to update subject.");

                if (subjectDto == null || subjectDto.SubjectId == 0)
                {
                    _logger.LogCritical("Invalid subject object. " +
                                        "About to throw validation exception.");

                    throw new ValidationException("Invalid subject object");
                }

                _logger.LogInformation(subjectDto.ToJson());

                var subject = await _subjectsRepository.FindByKeyAsync(subjectDto.SubjectId);

                if (subject == null)
                {
                    _logger.LogCritical("Invalid subject object. About to throw validation exception.");

                    throw new ValidationException("Invalid subject object");
                }

                // Now copy the standarddto fields to standard entity
                _mapper.Map(subjectDto, subject);

                await _subjectsRepository.UpdateAsync(subject);
            }
            catch (Exception ex)
            {
                _logger.LogError("AdminController, Update subject", ex);

                throw new InvalidOperationException(ex.Message);
            }

            return Ok();
        }
        
        [HttpPost]
        [Route("api/[controller]/{subjectId}/Traits")]
        public async Task<IActionResult> Traits(int subjectId, [FromBody]TraitsDto traitsDto)
        {
            try
            {
                _logger.LogInformation($"Called API to create Traits for subjectId: {subjectId}.");

                if (traitsDto == null || subjectId == 0)
                {
                    _logger.LogCritical("Invalid object. " +
                                        "About to throw validation exception.");

                    throw new ValidationException("Invalid object.");
                }

                _logger.LogInformation(traitsDto.ToJson());

                // Include traits here..
                var subjects = await 
                    _subjectsRepository.FindByIncludeAsync(x=>x.SubjectId == subjectId, x=>x.Traits);

                var subject = subjects.FirstOrDefault();

                if (subject == null)
                {
                    _logger.LogCritical($"Invalid object. No subject found with the subject ID: {subjectId} " );

                    throw new ValidationException("Invalid object.");
                }

                var trait = new Traits(subjectId);

                _mapper.Map(traitsDto, trait);

                subject.Traits.Add(trait);

                await _subjectsRepository.UpdateAsync(subject);
            }
            catch (Exception ex)
            {
                _logger.LogError("AdminController, CreateNew Traits", ex);

                throw new InvalidOperationException(ex.Message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/[controller]/{subjectId}/Traits")]
        public async Task<List<TraitsDto>> Traits(int subjectId)
        {
            var traitsDtoList = new List<TraitsDto>();

            try
            {
                _logger.LogInformation($"Called API to get traits for subjectId:{subjectId}.");

                var subjects = await _subjectsRepository.FindByIncludeAsync(x=> x.SubjectId == subjectId, x => x.Traits);

                var subject = subjects.FirstOrDefault();

                if (subject == null)
                {
                    _logger.LogCritical("Invalid subject Id. " +
                                        "About to throw validation exception.");

                    throw new ValidationException("Invalid subjectId.");
                }

                foreach (var trait in subject.Traits)
                {
                    var traitDto = new TraitsDto();

                    _mapper.Map(trait, traitDto);

                    traitsDtoList.Add(traitDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("AdminController, get subjects >> Traits", ex);

                throw new InvalidOperationException(ex.Message);
            }

            return traitsDtoList;
        }

        [HttpPut]
        [Route("api/[controller]/{subjectId}/Traits")]
        public async Task<IActionResult> UpdateTraits(int subjectId, [FromBody] TraitsDto traitsDto)
        {
            try
            {
                _logger.LogInformation($"Called API to update traits for subjectId:{subjectId}.");

                if (traitsDto == null || subjectId == 0)
                {
                    _logger.LogCritical("Invalid object. " +
                                        "About to throw validation exception.");

                    throw new ValidationException("Invalid object");
                }

                _logger.LogInformation(traitsDto.ToJson());

                var subjects = await 
                    _subjectsRepository.FindByIncludeAsync(x=>x.SubjectId == subjectId, x=>x.Traits);

                var subject = subjects.FirstOrDefault();

                if (subject == null)
                {
                    _logger.LogCritical($"Invalid subject Id:{subjectId}. About to throw validation exception.");

                    throw new ValidationException("Invalid subject object");
                }

                var trait = subject.Traits.FirstOrDefault(x => x.TraitsId == traitsDto.TraitsId);

                if (trait == null)
                {
                    _logger.LogCritical($"Invalid trait Id:{traitsDto.TraitsId}. About to throw validation exception.");

                    throw new ValidationException("Invalid TraitDto ID ");
                }

                // Now copy the traitDto fields to trait entity
                _mapper.Map(traitsDto, trait);

                // here updating child entity status.
                trait.ObjectState = ObjectState.Modified;

                //Update..
                await _subjectsRepository.UpdateAsync(subject);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("AdminController, Update traits for a subject", ex);
                
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
