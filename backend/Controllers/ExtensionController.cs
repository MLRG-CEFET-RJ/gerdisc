using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Services.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gerdisc.Controllers
{
    [ApiController]
    [Route("extensions")]
    public class ExtensionController : ControllerBase
    {
        private readonly IExtensionService _extensionService;

        public ExtensionController(IExtensionService extensionService)
        {
            _extensionService = extensionService;
        }

        /// <summary>
        /// Creates a new extension.
        /// </summary>
        /// <param name="extensionDto">The extension data.</param>
        /// <returns>The created extension.</returns>
        [HttpPost]
        [Authorize(Roles = "Administrator, ExtensionManager")]
        public async Task<ActionResult<ExtensionDto>> CreateExtension(ExtensionDto extensionDto)
        {
            try
            {
                var extension = await _extensionService.CreateExtensionAsync(extensionDto);
                return CreatedAtAction(nameof(GetExtension), new { id = extension.Id }, extension);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Gets a extension by its ID.
        /// </summary>
        /// <param name="id">The extension ID.</param>
        /// <returns>The extension.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, ExtensionManager, Developer")]
        public async Task<ActionResult<ExtensionDto>> GetExtension(int id)
        {
            try
            {
                var extension = await _extensionService.GetExtensionAsync(id);
                return Ok(extension);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExtensionDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ExtensionDto>>> GetAllExtensionsAsync()
        {
            var extensionDtos = await _extensionService.GetAllExtensionsAsync();

            return Ok(extensionDtos);
        }

        /// <summary>
        /// Updates a extension by its ID.
        /// </summary>
        /// <param name="id">The extension ID.</param>
        /// <param name="extensionDto">The extension data.</param>
        /// <returns>The updated extension.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator, ExtensionManager")]
        public async Task<ActionResult<ExtensionDto>> UpdateExtension(int id, ExtensionDto extensionDto)
        {
            try
            {
                var extension = await _extensionService.UpdateExtensionAsync(id, extensionDto);
                return Ok(extension);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a extension by its ID.
        /// </summary>
        /// <param name="id">The extension ID.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator, ExtensionManager")]
        public async Task<IActionResult> DeleteExtension(int id)
        {
            try
            {
                await _extensionService.DeleteExtensionAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}