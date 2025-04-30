using PdfSharpCore.Pdf; 
using PdfSharpCore.Pdf.IO; 
using System.Collections.Generic; 
using System.IO; 
using Microsoft.Extensions.Logging; 
using System; 
namespace HitendramahajanSimplyPy.Services 
{ 
    public class PdfMergerService 
    { 
        private readonly ILogger<PdfMergerService> _logger; 
        public PdfMergerService(ILogger<PdfMergerService> logger) 
        { 
            _logger = logger; 
        } 
        public byte[] MergePdfs(List<byte[]> pdfFiles) 
        { 
            _logger.LogInformation("Starting PDF merge process for {Count} files.", pdfFiles.Count); 
            try 
            { 
                using (var outputDocument = new PdfDocument()) 
                { 
                    foreach (var pdf in pdfFiles) 
                    { 
                        using (var stream = new MemoryStream(pdf)) 
                        { 
                            var inputDocument = PdfReader.Open(stream, PdfDocumentOpenMode.Import); 
                            foreach (var page in inputDocument.Pages) 
                            { 
                                outputDocument.AddPage(page); 
                            } 
                        } 
                    } 
                    using (var stream = new MemoryStream()) 
                    { 
                        outputDocument.Save(stream, false); 
                        _logger.LogInformation("PDF merge process completed successfully."); 
                        return stream.ToArray(); 
                    } 
                } 
            } 
            catch (Exception ex) 
            { 
                _logger.LogError(ex, "An error occurred during the PDF merge process."); 
                throw; 
            } 
        } 
    } 
}