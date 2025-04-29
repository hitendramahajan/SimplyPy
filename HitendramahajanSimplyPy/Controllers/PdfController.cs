using HitendramahajanSimplyPy.Services; 
using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using Microsoft.Extensions.Logging; 
namespace HitendramahajanSimplyPy.Controllers 
{ 
    [ApiController] 
    [Route("api/[controller]")] 
    public class PdfController : ControllerBase 
    { 
        private readonly PdfMergerService _pdfMergerService; 
        private readonly ILogger<PdfController> _logger; 
        public PdfController(PdfMergerService pdfMergerService, ILogger<PdfController> logger) 
        { 
            _pdfMergerService = pdfMergerService; 
            _logger = logger; 
        } 
        [HttpPost("merge")] 
        public IActionResult MergePdfs([FromBody] List<byte[]> pdfFiles) 
        { 
            _logger.LogInformation("Received request to merge {Count} PDF files.", pdfFiles.Count); 
            if (pdfFiles == null || pdfFiles.Count == 0) 
            { 
                _logger.LogWarning("No PDF files provided for merging."); 
                return BadRequest("No PDF files provided."); 
            } 
            try 
            { 
                var mergedPdf = _pdfMergerService.MergePdfs(pdfFiles); 
                _logger.LogInformation("Successfully merged PDF files."); 
                return File(mergedPdf, "application/pdf", "merged.pdf"); 
            } 
            catch (Exception ex) 
            { 
                _logger.LogError(ex, "An error occurred while merging PDF files."); 
                return StatusCode(500, "An error occurred while merging PDF files."); 
            } 
        } 
    } 
}