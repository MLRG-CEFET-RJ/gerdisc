using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Models.Mapper;
using gerdisc.Services.Interfaces;

namespace gerdisc.Services
{
    public class OrientationService : IOrientationService
    {
        private readonly IRepository _repository;
        private readonly ILogger<OrientationService> _logger;

        public OrientationService(
            IRepository repository,
            ILogger<OrientationService> logger
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<OrientationDto> CreateOrientationAsync(OrientationDto orientationDto)
        {
            await _repository.Orientation.AddAsync(orientationDto.ToEntity());

            _logger.LogInformation($"Orientation {orientationDto.Id} created successfully.");
            return orientationDto;
        }

        public async Task<OrientationDto> GetOrientationAsync(Guid id)
        {
            var orientationEntity = await _repository.Orientation.GetByIdAsync(id, x => x.Dissertation, x => x.Professor, x => x.CoorientatorId);
            if (orientationEntity == null)
            {
                throw new ArgumentException("Orientation not found.");
            }

            return orientationEntity.ToDto();
        }

        public async Task<IEnumerable<OrientationDto>> GetAllOrientationsAsync()
        {
            var orientations = await _repository.Orientation.GetAllAsync(x => x.Dissertation, x => x.Professor, x => x.CoorientatorId);
            var orientationDtos = new List<OrientationDto>();
            foreach (var orientation in orientations)
            {
                orientationDtos.Add(orientation.ToDto());
            }

            return orientationDtos;
        }

        public async Task<OrientationDto> UpdateOrientationAsync(Guid id, OrientationDto orientationDto)
        {
            var existingDissertation = await _repository.Orientation.GetByIdAsync(id);
            if (existingDissertation == null)
            {
                throw new ArgumentException($"Dissertation with id {id} does not exist.");
            }

            existingDissertation = orientationDto.ToEntity(existingDissertation);

            await _repository.Orientation.UpdateAsync(existingDissertation);

            return existingDissertation.ToDto();
        }

        public async Task DeleteOrientationAsync(Guid id)
        {
            var existingDissertation = await _repository.Dissertation.GetByIdAsync(id);
            if (existingDissertation == null)
            {
                throw new ArgumentException($"Dissertation with id {id} does not exist.");
            }

            await _repository.Dissertation.DeactiveAsync(existingDissertation);
        }
    }
}