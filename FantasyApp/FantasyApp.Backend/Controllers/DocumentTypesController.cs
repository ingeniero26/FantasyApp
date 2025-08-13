using FantasyApp.Backend.Data;
using FantasyApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FantasyApp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentTypesController : ControllerBase
    {
        private readonly DataContext _context;
        public DocumentTypesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var documentTypes = await _context.DocumentTypes.ToListAsync();
            return Ok(documentTypes);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(DocumentType documentType)
        {
            _context.Add(documentType);
            await _context.SaveChangesAsync();
            return Ok(documentType);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var documentType = await _context.DocumentTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (documentType == null)
            {
                return NotFound();
            }
            return Ok(documentType);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(DocumentType documentType)
        {
            var currentDocumentType = await _context.DocumentTypes.FirstOrDefaultAsync(c => c.Id == documentType.Id);
            if (currentDocumentType == null)
            {
                return NotFound();
            }
            currentDocumentType.Name = documentType.Name;
            currentDocumentType.IsActive = documentType.IsActive;
            _context.Update(currentDocumentType);
            await _context.SaveChangesAsync();
            return Ok(currentDocumentType);
        }
    }
}
